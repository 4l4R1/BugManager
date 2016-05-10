Option Strict On
Option Explicit On

Imports System.IO
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Text

Module VideoClassesHD

    Friend Class VideoSequenceHD
        Friend Property DirHome As String
        Friend Property DirExmpl As String = String.Empty
        Friend Property DirHD As String = String.Empty

        Friend Property Files As List(Of IndexedFile)
        Private Render As Boolean
        Private Interlaced As Boolean
        Private _Width As Double
        Private _Height As Double
        Private VideoName As String

        Friend Shared DirRes As String = "E:\Eetrigraafika\bug\_res\"
        Friend Shared Property FnBack As String

        Friend Enum RenderMode
            None = 0
            Bug = 1
            logo = 2
            'multi = 3
        End Enum

        Private dInfo As DirectoryInfo

        Friend Sub New(src As String, example As Boolean, mode As RenderMode, fields As Boolean)
            If Not src.EndsWith("\"c) Then src += "\"c
            DirHome = src
            dInfo = New DirectoryInfo(DirHome)
            Select Case mode
                Case RenderMode.logo
                    'VideoName = src.TrimEnd("\"c)
                    VideoName = ActiveChannel.dirResVid + dInfo.Name
                    'Case RenderMode.multi
                    '    VideoName = dInfo.Parent.Parent.Parent.FullName + "\" + dInfo.Name
                Case Else
                    VideoName = ActiveChannel.dirResBug + dInfo.Name
            End Select

            DirHD = src + "hd\"

            Cleanup()
            If mode > 0 Then
                Directory.CreateDirectory(DirHD)
                Render = True
            End If

            Interlaced = fields

            If example Then
                DirExmpl = String.Format("{0}temp\{1:yyMMddHHmmss}\", DirRes, Now)
                Directory.CreateDirectory(DirExmpl)
            End If


            Dim fNs As New List(Of String)
            Dim exts As New List(Of String) From {".png", ".tga"} ', ".tif", ".tiff"}
            For Each f As FileInfo In dInfo.GetFiles
                If exts.Contains(f.Extension.ToLower) Then
                    fNs.Add(f.Name)
                End If
            Next
            fNs.Sort()

            _Files = New List(Of IndexedFile)
            Dim i As Integer
            For Each fn As String In fNs
                _Files.Add(New IndexedFile(i, fn))
                i += 1
            Next

            GetSize()
        End Sub

        ' saatekava
        Friend Sub New(src As String, fields As Boolean)
            If Not src.EndsWith("\"c) Then src += "\"c
            DirHome = src
            dInfo = New DirectoryInfo(DirHome)
            'VideoName = dInfo.Parent.FullName + "\2-15-sk-" + dInfo.Name.ToLower
            VideoName = ActiveChannel.dirResVid + "\2-15-sk-" + dInfo.Name.ToLower
            DirHD = src + "hd\"

            Cleanup()
            Directory.CreateDirectory(DirHD)
            Render = True
            Interlaced = fields

            Dim fNs As New List(Of String)
            Dim exts As New List(Of String) From {".png", ".tga"} ', ".tif", ".tiff"}
            For Each f As FileInfo In dInfo.GetFiles
                If exts.Contains(f.Extension.ToLower) Then
                    fNs.Add(f.Name)
                End If
            Next
            fNs.Sort()

            _Files = New List(Of IndexedFile)
            Dim i As Integer
            For Each fn As String In fNs
                _Files.Add(New IndexedFile(i, fn))
                i += 1
            Next

            GetSize()
        End Sub

        Private Sub GetSize()
            If _Files.Count = 0 Then Return

            Dim Frame As New ViaBuildLib.Image
            With Frame
                .Filename = DirHome + _Files(0).Name
                _Width = .Width
                _Height = .Height
            End With
        End Sub

        Friend ReadOnly Property Width As Double
            Get
                Return _Width
            End Get
        End Property

        Friend ReadOnly Property Height As Double
            Get
                Return _Height
            End Get
        End Property

        Friend ReadOnly Property Name As String
            Get
                Return dInfo.Name
            End Get
        End Property

        Friend ReadOnly Property Duration As Integer
            Get
                Return _Files.Count + 2
            End Get
        End Property

        Friend Sub Proccess(id As String)

            Dim processor As FrameProcessorHD = FrameProcessorHD.Create(Me, id)

            'For Each ifn As IndexedFile In _Files
            '    processor.proccess(ifn)
            'Next

            Try
                Parallel.ForEach(_Files, AddressOf processor.proccess)

                Dim tasks As New List(Of Task)

                If Render Then tasks.Add(Task.Factory.StartNew(AddressOf MakeHdVideo))

                If DirExmpl.Length > 0 Then 'näidisvideo
                    tasks.Add(Task.Factory.StartNew(AddressOf MakeVideo))
                End If

                Task.WaitAll(tasks.ToArray)
                Cleanup()
            Catch ex As Exception

            End Try

        End Sub

        'Friend Sub Proccess(Mode As Integer)
        '    Dim id As String
        '    Dim h As Integer

        '    Select Case Mode
        '        Case 1 'logo vasakul pool,lõikab paremalt ära. Eeldab 169 kaadrit piksliformaadiga 1 (HD)
        '            h = 162
        '            id = "1024_left_cut_0,0,720,162"
        '        Case 110 'temp kanal11 maskifailid
        '            h = 120
        '            id = "mask_right_cut_0,0,720,120"
        '        Case 111
        '            h = 120
        '            id = "1024_right_cut_0,0,720,120"
        '        Case 2 'logo paremal pool,lõikab vasakult ära. Eeldab 169 kaadrit piksliformaadiga 1 (HD) (kanal2-1415)
        '            h = 200
        '            id = "1024_right_cut_0,0,720,200"
        '        Case Else   '(1000) hd video vajab 169 formaadis pilti
        '            id = "hd_resize"
        '    End Select

        '    Dim processor As FrameProcessor = FrameProcessor.Create(Me, id)

        '    Try

        '        'If id.StartsWith("hd") Then
        '        '    For Each ifn As IndexedFile In _Files
        '        '        processor.proccess(ifn)
        '        '        GC.Collect()
        '        '        Threading.Thread.Sleep(100)
        '        '    Next
        '        'Else
        '        Parallel.ForEach(Of IndexedFile)(_Files, AddressOf processor.proccess)
        '        'End If

        '        Dim fnVia As String
        '        Dim tasks As New List(Of Task)
        '        Dim viaAct As Action(Of Object) = AddressOf MakeVia
        '        Dim viaOpt As ViaOptions

        '        If Render Then
        '            fnVia = dInfo.Parent.FullName + "\" + dInfo.Name + ".via"
        '            viaOpt = New ViaOptions(fnVia, Dir43)
        '            viaOpt.ThumbFiles = True
        '            viaOpt.Height = h
        '            viaOpt.ClearBegEnd = False
        '            tasks.Add(Task.Factory.StartNew(viaAct, viaOpt))

        '            fnVia = dInfo.Parent.FullName + "\" + dInfo.Name + "_w.via"
        '            viaOpt = New ViaOptions(fnVia, Dir169)
        '            viaOpt.Height = h
        '            viaOpt.ThumbFiles = True
        '            viaOpt.ClearBegEnd = False
        '            tasks.Add(Task.Factory.StartNew(viaAct, viaOpt))
        '        End If

        '        If DirExmpl.Length > 0 Then 'näidisvideo
        '            tasks.Add(Task.Factory.StartNew(AddressOf MakeVideo))
        '        End If

        '        If DirHD.Length > 0 Then  'hd video
        '            tasks.Add(Task.Factory.StartNew(AddressOf MakeHdVideo))
        '        End If

        '        Task.WaitAll(tasks.ToArray)
        '    Catch ex As Exception

        '    End Try

        'End Sub

        Private Sub MakeVideo()
            Try
                For i As Integer = _Files.Count To _Files.Count + 8    'natuke tühja ruumi lõppu
                    Dim fn As String = String.Format("{0}frame{1:0000}.png", _DirExmpl, i)
                    Try
                        File.Copy(FnBack, fn, False)
                    Catch ex As Exception

                    End Try
                Next

                Dim mpeg As New VideoFile(DirExmpl, New DirectoryInfo(DirHome).Name, String.Empty)
                mpeg.encode()
                'TODO vajadusel võiks encode anda märku vea olemasolust (encoderi  veastream on olemas)
            Catch ex As Exception
                Return
            End Try

            Try
                If Directory.Exists(DirExmpl) Then Directory.Delete(DirExmpl, True)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub MakeHdVideo()
            Try
                Dim codec As String = If(Interlaced, "proResF", "png")
                'If Name = String.Empty Then Name = New DirectoryInfo(DirHome).Name
                Dim mpeg As New VideoFile(DirHD, VideoName, codec)
                mpeg.encode()
                'TODO vajadusel võiks encode anda märku vea olemasolust (encoderi  veastream on olemas)
            Catch ex As Exception
                MsgBox(ex.Message)
                'Return
            End Try

            'Try
            '    If Directory.Exists(DirHD) Then Directory.Delete(DirHD, True)
            'Catch ex As Exception
            'End Try
        End Sub

        Friend Sub Cleanup()
            Try
                If Directory.Exists(DirExmpl) Then Directory.Delete(DirExmpl, True)
            Catch ex As Exception
            End Try

            Try
                If Directory.Exists(DirHD) Then Directory.Delete(DirHD, True)
            Catch ex As Exception
            End Try
        End Sub
    End Class

    Friend MustInherit Class FrameProcessorHD

        Protected Shared sizePal As New Size(720, 576)
        Protected Shared size43 As New Size(768, 576)
        Protected Shared size169 As New Size(1024, 576)
        Protected Shared sizeHD As New Size(1920, 1080)

        Friend Sub New(init As String)
            'lBack.LayerFromFile(VideoSequence.DirRes + "back.png")
            ' bBack = New Bitmap(VideoSequence.DirRes + "back.png")
        End Sub

        Friend Shared Function Create(video As VideoSequenceHD, id As String) As FrameProcessorHD
            Dim processor As FrameProcessorHD

            Dim ids() As String = id.Split("_"c)
            'Dim idSel As String = String.Join("_", ids, 3)

            Select Case ids(0)
                'Case "hd"
                   ' processor = New FrameProcessor_HD(ids(1))
                    'Case "720"
                    '    Select Case ids(1)
                    '        Case "43"
                    '            processor = New FrameProcessor_720_43(ids(2)) '"720_43_left", "720_43_right"
                    '        Case Else '"169"
                    '            processor = New FrameProcessor_720_169(ids(2)) '"720_169_left", "720_169_right"
                    '    End Select
                    'Case "1024"
                    '    If ids.Count < 3 Then
                    '        processor = New FrameProcessor_1024_169(ids(1)) '1024_left,1024_right,1024_center,1024_## (0..99)
                    '    Else
                    '        Select Case ids(2)
                    '            Case "cut"
                    '                processor = New FrameProcessor_1024_169_cut(ids(1), ids(3)) '"1024_left_cut_x,y,w,h",1024_right_cut_x,y,w,h"
                    '            Case Else
                    '                processor = New FrameProcessor_1024_169(ids(1)) '1024_left,1024_right
                    '        End Select
                    '    End If
                    'Case "mask"
                    '    Dim maskfn As String = New DirectoryInfo(video.Dir).Parent.FullName + "\maskdiff.png"
                    '    processor = New FrameProcessor_mask_169_cut(ids(1), ids(3), maskfn)
                Case "draw"
                    processor = New FrameProcessorHD_Draw(ids)
                Case Else
                    processor = New FrameProcessorHD_Full()
            End Select


            'Select Case idSel
            '    Case "720_43_left", "720_43_right"
            '        processor = New FrameProcessor_720_43(id)
            '    Case "720_169_left", "720_169_right"
            '        processor = New FrameProcessor_720_169(id)
            '    Case "1024_169_left", "1024_169_right"
            '        If ids.Count > 3 Then
            '            If ids(3) = ("cut") Then processor = New FrameProcessor_1024_169_cut(ids(2), ids(4)) '"cut_x,y,w,h"
            '        Else
            '            processor = New FrameProcessor_1024_169(id)
            '        End If

            '    Case Else '"240_43"
            '        If id.StartsWith("w") Then
            '            processor = New FrameProcessor_240_169(id)
            '        Else
            '            processor = New FrameProcessor_240_43(id)
            '        End If

            'End Select
            processor.Parent = video

            Return processor
        End Function

        Protected Property Parent As VideoSequenceHD

        Friend MustOverride Sub proccess(ifn As IndexedFile)

        Friend Sub Example(b As Bitmap, index As Integer) ', fn As String)
            If Parent.DirExmpl.Length = 0 Then Return

            Dim fn As String = String.Format("{0}frame{1:0000}.png", Parent.DirExmpl, index)

            'Dim bb As Bitmap
            'Try
            '    bb = New Bitmap(bBack) 'parallel.foreach ei kannata
            'Catch ex As Exception
            '    bb = New Bitmap(VideoSequence.DirRes + "back.png")
            'End Try

            'Dim bb As Bitmap = New Bitmap(VideoSequence.DirRes + "back.png")
            Dim bb As Bitmap = New Bitmap(VideoSequenceHD.FnBack)

            Dim g As Graphics = Graphics.FromImage(bb)
            g.DrawImageUnscaled(b, 0, 0)

            bb.Save(fn)

            g.Dispose()
            bb.Dispose()
        End Sub

        Protected Function Resize(b As Bitmap, s As Size) As Bitmap
            Dim b2 As New Bitmap(b, s)
            b.Dispose()
            Return b2
        End Function

        Protected Function GetBitmap(ifn As IndexedFile) As Bitmap
            Dim b As Bitmap
            Dim fi As FileInfo = New FileInfo(Parent.DirHome + ifn.Name)

            Try
                b = New Bitmap(fi.FullName)
                Return b
            Catch ex As Exception

            End Try
            If Not fi.Extension.ToLower = ".png" Then
                Try
                    Dim Frame As New ViaBuildLib.Image
                    With Frame
                        .Filename = fi.FullName
                        ifn.Name = fi.Name.Replace(fi.Extension, ".png")
                        .Convert(Parent.DirHome + ifn.Name)
                    End With

                    fi.Delete()
                    b = New Bitmap(Parent.DirHome + ifn.Name)
                    Return b
                Catch ex As Exception

                End Try
            End If
            Return New Bitmap(1, 1)
        End Function

        'Protected Sub MultiplyAlpha(b As Bitmap)
        '    For x As Integer = 0 To b.Width - 1
        '        For y As Integer = 0 To b.Height - 1
        '            With b.GetPixel(x, y)
        '                Dim cf As Double = .A / 255
        '                Dim c As Color = Color.FromArgb(.A, CInt(cf * .R), CInt(cf * .G), CInt(cf * .B))
        '                b.SetPixel(x, y, c)
        '                'End If
        '            End With
        '        Next
        '    Next

        '    b.PixelFormat=
        'End Sub
    End Class

    Friend Class FrameProcessorHD_Full
        Inherits FrameProcessorHD

        Friend Sub New()
            MyBase.New("")
            'MyBase.New(init)
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim bHD As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            bHD.SetResolution(96, 96)

            If bHD.Width <> sizeHD.Width OrElse bHD.Height <> sizeHD.Height Then bHD = Resize(bHD, sizeHD)

            'bHD.Save(Parent.DirHD + ifn.Name)
            'TargaFile.SaveAsTarga(Parent.DirHD + ifn.Name.ToLower.Replace(".png", ".tga"), bHD)
            TargaFile.SaveAsTarga($"{Parent.DirHD}fr{ifn.Index:00000}.tga", bHD)

            bHD = Resize(bHD, sizePal) '720x576
            Example(bHD, ifn.Index)

            bHD.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessorHD_Draw
        Inherits FrameProcessorHD

        'Private x43, x169
        Private xPos, yPos As Integer
        Private sizeLogo As Size
        Private rightSide As Char

        Friend Sub New(xywh() As String)
            MyBase.New(xywh(0))

            xPos = Integer.Parse(xywh(1))
            yPos = Integer.Parse(xywh(2))

            Try
                Dim w = Integer.Parse(xywh(3))
                Dim h = Integer.Parse(xywh(4))
                sizeLogo = New Size(w, h)
            Catch ex As Exception
                sizeLogo = New Size(450, 300) 'New Size(240, 160)
            End Try

            Try
                'If xywh(5).StartsWith("r"c) Then
                '    rightSide = 1
                'ElseIf xywh(5).StartsWith("c"c) Then
                '    
                'End If
                rightSide = xywh(5).ToLower.First
            Catch ex As Exception

            End Try
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b As Bitmap = GetBitmap(ifn)
            b.SetResolution(96, 96)

            If Not (b.Size = sizeLogo) Then  'kaadri suurus vajalikuks
                b = Resize(b, sizeLogo)
            End If

            Dim bHD As Bitmap = New Bitmap(sizeHD.Width, sizeHD.Height) '1920, 1080)
            bHD.SetResolution(96, 96)

            Dim x As Integer 'logo asukohal vasakus või paremas servas
            Select Case rightSide
                Case "r"c
                    x = bHD.Width - b.Width - xPos
                Case "c"c
                    x = CInt(0.5 * (bHD.Width - b.Width))
                Case Else
                    x = xPos
            End Select
            Dim gHD As Graphics = Graphics.FromImage(bHD)
            gHD.DrawImageUnscaled(b, x, yPos)
            gHD.Dispose()

            'bHD.Save(Parent.DirHD + ifn.Name)
            'TargaFile.SaveAsTarga(Parent.DirHD + ifn.Name.ToLower.Replace(".png", ".tga"), bHD)
            TargaFile.SaveAsTarga($"{Parent.DirHD}fr{ifn.Index:00000}.tga", bHD)

            bHD = Resize(bHD, sizePal) '720x576
            Example(bHD, ifn.Index)

            bHD.Dispose()
            b.Dispose()
        End Sub
    End Class

End Module
