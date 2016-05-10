Option Strict On
Option Explicit On

Imports System.IO
Imports System.Drawing
Imports System.Threading.Tasks
Imports System.Text

Module VideoClasses

    Friend Class VideoSequence
        Friend Property DirHome As String
        Friend Property Dir43 As String
        Friend Property Dir169 As String
        Friend Property DirExmpl As String = String.Empty
        Friend Property DirHD As String = String.Empty

        Friend Property Files As List(Of IndexedFile)
        Private Render As Boolean
        Private _Width As Double
        Private _Height As Double

        Friend Property Only169 As Boolean

        Friend Shared DirRes As String = "E:\Eetrigraafika\bug\_res\"
        Friend Shared Property FnBack As String

        Private dInfo As DirectoryInfo

        Friend Sub New(src As String, example As Boolean, via As Boolean, hd As Boolean)
            If Not src.EndsWith("\"c) Then src += "\"c
            DirHome = src
            dInfo = New DirectoryInfo(DirHome)
            Dir43 = src + "43\"
            Dir169 = src + "169\"
            'DirHD = If(hd, src + "hd\", String.Empty)
            'DirExmpl = If(example, String.Format("{0}temp\{1:yyMMddHHmmss}\", DirRes, Now), String.Empty)

            Cleanup()
            If via Then
                Directory.CreateDirectory(Dir43)
                Directory.CreateDirectory(Dir169)

            End If
            Render = via

            If example Then
                DirExmpl = String.Format("{0}temp\{1:yyMMddHHmmss}\", DirRes, Now)
                Directory.CreateDirectory(DirExmpl)
            End If

            If hd Then
                DirHD = src + "hd\"
                Directory.CreateDirectory(DirHD)
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
            '_Width = GetWidth()
            GetSize()

            'DirHD = If(_Width >= 1024, src + "hd\", String.Empty)
            'If DirHD.Length > 0 Then Directory.CreateDirectory(DirHD)

        End Sub

        'Private Function GetWidth() As Double
        '    If _Files.Count = 0 Then Return 0
        '    Dim Frame As New ViaBuildLib.Image
        '    With Frame
        '        .Filename = Dir + _Files(0).Name
        '        Return .Width
        '    End With
        'End Function

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

            Dim processor As FrameProcessor = FrameProcessor.Create(Me, id)

            'For Each ifn As IndexedFile In _Files
            '    processor.proccess(ifn)
            'Next

            Try
                Parallel.ForEach(Of IndexedFile)(_Files, AddressOf processor.proccess)

                Dim fnVia As String
                Dim tasks As New List(Of Task)
                Dim viaAct As Action(Of Object) = AddressOf MakeVia

                If Render Then

                    If Only169 Then
                        fnVia = ActiveChannel.dirResBug + dInfo.Name + ".via"
                        tasks.Add(Task.Factory.StartNew(viaAct, New ViaOptions(fnVia, Dir169)))

                        If Directory.Exists(Dir43) Then Directory.Delete(Dir43, True) 'kustuta mittevajalik 43
                        fnVia = ActiveChannel.dirResBug + dInfo.Name + "_w.via"
                        If File.Exists(fnVia) Then File.Delete(fnVia) 'kui on olemas _w variant, kustuta
                    Else
                        fnVia = ActiveChannel.dirResBug + dInfo.Name + ".via"
                        tasks.Add(Task.Factory.StartNew(viaAct, New ViaOptions(fnVia, Dir43)))

                        fnVia = ActiveChannel.dirResBug + dInfo.Name + "_w.via"
                        tasks.Add(Task.Factory.StartNew(viaAct, New ViaOptions(fnVia, Dir169)))
                    End If

                    'If DirHD.Length > 0 Then
                    '    tasks.Add(Task.Factory.StartNew(AddressOf MakeHdVideo))
                    'End If
                End If

                If DirExmpl.Length > 0 Then 'näidisvideo
                    tasks.Add(Task.Factory.StartNew(AddressOf MakeVideo))
                End If

                Task.WaitAll(tasks.ToArray)
            Catch ex As Exception

            End Try

        End Sub

        Friend Sub Proccess(Mode As Integer)
            Dim id As String
            Dim h As Integer

            Select Case Mode
                Case 1 'logo vasakul pool,lõikab paremalt ära. Eeldab 169 kaadrit piksliformaadiga 1 (HD)
                    h = 162
                    id = "1024_left_cut_0,0,720,162"
                Case 110 'temp kanal11 maskifailid
                    h = 120
                    id = "mask_right_cut_0,0,720,120"
                Case 111
                    h = 120
                    id = "1024_right_cut_0,0,720,120"
                Case 2 'logo paremal pool,lõikab vasakult ära. Eeldab 169 kaadrit piksliformaadiga 1 (HD) (kanal2-1415)
                    h = 200
                    id = "1024_right_cut_0,0,720,200"
                Case Else   '(1000) hd video vajab 169 formaadis pilti
                    id = "hd_resize"
            End Select

            Dim processor As FrameProcessor = FrameProcessor.Create(Me, id)

            Try

                'If id.StartsWith("hd") Then
                '    For Each ifn As IndexedFile In _Files
                '        processor.proccess(ifn)
                '        GC.Collect()
                '        Threading.Thread.Sleep(100)
                '    Next
                'Else
                Parallel.ForEach(Of IndexedFile)(_Files, AddressOf processor.proccess)
                'End If

                Dim fnVia As String
                Dim tasks As New List(Of Task)
                Dim viaAct As Action(Of Object) = AddressOf MakeVia
                Dim viaOpt As ViaOptions

                If Render Then
                    fnVia = dInfo.Parent.FullName + "\" + dInfo.Name + ".via"
                    viaOpt = New ViaOptions(fnVia, Dir43)
                    viaOpt.ThumbFiles = True
                    viaOpt.Height = h
                    viaOpt.ClearBegEnd = False
                    tasks.Add(Task.Factory.StartNew(viaAct, viaOpt))

                    fnVia = dInfo.Parent.FullName + "\" + dInfo.Name + "_w.via"
                    viaOpt = New ViaOptions(fnVia, Dir169)
                    viaOpt.Height = h
                    viaOpt.ThumbFiles = True
                    viaOpt.ClearBegEnd = False
                    tasks.Add(Task.Factory.StartNew(viaAct, viaOpt))
                End If

                If DirExmpl.Length > 0 Then 'näidisvideo
                    tasks.Add(Task.Factory.StartNew(AddressOf MakeVideo))
                End If

                If DirHD.Length > 0 Then  'hd video
                    tasks.Add(Task.Factory.StartNew(AddressOf MakeHdVideo))
                End If

                Task.WaitAll(tasks.ToArray)
            Catch ex As Exception

            End Try

        End Sub

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
                Dim mpeg As New VideoFile(DirHD, New DirectoryInfo(DirHome).Name, "png")
                mpeg.encode()
                'TODO vajadusel võiks encode anda märku vea olemasolust (encoderi  veastream on olemas)
            Catch ex As Exception
                Return
            End Try

            Try
                If Directory.Exists(DirHD) Then Directory.Delete(DirHD, True)
            Catch ex As Exception
            End Try
        End Sub

        Private Sub MakeVia(viaobj As Object)  'viaFn As String, dirSrc As String)
            Dim viaopt As ViaOptions = CType(viaobj, ViaOptions)
            Dim via As New ViaBuildLib.ViaFile
            Dim ViaFrame As New ViaBuildLib.Image

            Try
                With via
                    .Filename = viaopt.name ' viaFn
                    .Height = viaopt.Height ' 576
                    .Width = viaopt.Width '720
                    .FieldDominance = 0
                    .Open()

                    If viaopt.ClearBegEnd Then
                        ViaFrame.Filename = DirRes + "clear.png"
                        .AddFrame(ViaFrame)
                    End If


                    For Each ifn As IndexedFile In _Files
                        ViaFrame.Filename = viaopt.source + ifn.Name
                        .AddFrame(ViaFrame)
                    Next

                    If viaopt.ClearBegEnd Then
                        ViaFrame.Filename = DirRes + "clear.png"
                        .AddFrame(ViaFrame)
                    End If

                    Try
                        ViaFrame.Filename = viaopt.source + _Files(CInt(_Files.Count * 0.85)).Name
                        .Thumbnail = ViaFrame

                        If viaopt.ThumbFiles Then ViaFrame.Convert(viaopt.name.Replace(".via", ".png"))

                    Catch ex As Exception

                    End Try
                    .Close()
                End With
            Catch ex As Exception
                Return
            End Try

            Try
                If Directory.Exists(viaopt.source) Then Directory.Delete(viaopt.source, True)
            Catch ex As Exception
            End Try
        End Sub

        Friend Sub Cleanup()
            Try
                If Directory.Exists(Dir43) Then Directory.Delete(Dir43, True)
            Catch ex As Exception
            End Try

            Try
                If Directory.Exists(Dir169) Then Directory.Delete(Dir169, True)
            Catch ex As Exception
            End Try

            Try
                If Directory.Exists(DirExmpl) Then Directory.Delete(DirExmpl, True)
            Catch ex As Exception
            End Try

            Try
                If Directory.Exists(DirHD) Then Directory.Delete(DirHD, True)
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub MakeClearVia(viaFn As String, frames As Integer)
        '	Dim via As New ViaBuildLib.ViaFile
        '	Dim ViaFrame As New ViaBuildLib.Image

        '	With via
        '		.Filename = viaFn
        '		.Height = 576
        '		.Width = 720
        '		.Open()
        '		ViaFrame.Filename = DirRes + "clear.png"

        '		For i As Integer = 1 To frames
        '			.AddFrame(ViaFrame)
        '		Next

        '		.Close()
        '	End With
        'End Sub
    End Class

    Friend Class SKsequence
        Private Shared exts As New List(Of String) From {".png", ".tga"} ', ".tif", ".tiff"}
        Private _dir As DirectoryInfo

        Friend Sub New(dir As String)
            '_dir = dir
            'If Not _dir.EndsWith("\"c) Then _dir += "\"c
            _dir = New DirectoryInfo(dir)
        End Sub

        Friend Sub Process()
            Dim tasks As New List(Of Task)
            Dim viaAct As Action(Of Object) = AddressOf MakeVia

            Dim fi11 As New DirectoryInfo(_dir.FullName + "\1")
            If fi11.Exists Then 'kanal11

                For Each sdir As DirectoryInfo In _dir.GetDirectories
                    Dim fns As New List(Of String)
                    GetDirFiles(sdir, fns)
                    fns.Add(_dir.Parent.FullName + "\11-1415-" + _dir.Name.ToLower + "-" + sdir.Name + ".via") ' + "_start.via")
                    tasks.Add(Task.Factory.StartNew(viaAct, fns))
                Next
            Else
                Dim fnMain As New List(Of String)
                Dim fnLoop As New List(Of String)

                GetDirFiles(_dir, fnMain)

                'taustapildi keevitamine seq taha
                'MergeBackground(fnMain)
                'Return

                Dim diLoop As New DirectoryInfo(_dir.FullName + "\loop")
                If Not diLoop.Exists Then

                    Dim fnl As New FileInfo(fnMain.Last)
                    For i As Integer = 0 To 149
                        fnLoop.Add(fnMain.Last)
                    Next
                Else
                    GetDirFiles(diLoop, fnLoop)
                End If

                fnMain.Add(_dir.Parent.FullName + "\2-1415-" + _dir.Name.ToLower + ".via") ' + "_start.via")
                fnLoop.Add(_dir.Parent.FullName + "\2-1415-" + _dir.Name.ToLower + "-loop.via")

                tasks.Add(Task.Factory.StartNew(viaAct, fnMain))
                tasks.Add(Task.Factory.StartNew(viaAct, fnLoop))

            End If

            Task.WaitAll(tasks.ToArray)
        End Sub


        Private Sub GetDirFiles(d As DirectoryInfo, l As List(Of String))
            For Each f As FileInfo In d.GetFiles
                If exts.Contains(f.Extension.ToLower) Then
                    l.Add(f.FullName)
                End If
            Next
            l.Sort()
        End Sub

        'Private Sub MakeVia(frames As List(Of String)) ', fn As String)  'viaFn As String, dirSrc As String)
        Private Sub MakeVia(f As Object)
            Dim frames As List(Of String) = CType(f, List(Of String))
            Dim via As New ViaBuildLib.ViaFile
            Dim ViaFrame As New ViaBuildLib.Image

            Try
                With via
                    .Filename = frames.Last ' fn
                    frames.Remove(frames.Last)
                    .Height = 576
                    .Width = 720
                    .Resize = True
                    .Open()

                    For Each ifn As String In frames
                        ViaFrame.Filename = ifn
                        .AddFrame(ViaFrame)
                    Next

                    ViaFrame.Filename = frames(CInt(frames.Count * 0.85))
                    .Thumbnail = ViaFrame

                    .Close()
                End With
            Catch ex As Exception
                Return
            End Try
        End Sub

        Private Sub MergeBackground(l As List(Of String))
            'taustapildi keevitamine seq taha
            For Each fn As String In l
                Dim fi As New FileInfo(fn)
                Dim b As Bitmap = New Bitmap(fn)
                Dim bb As Bitmap = New Bitmap("E:\_home_\Saated\eetrigraafika\Kanal 2\sk1415\gears-back.png")
                Dim g As Graphics = Graphics.FromImage(bb)
                g.DrawImageUnscaled(b, 0, 0)
                bb.Save("E:\_home_\Saated\eetrigraafika\Kanal 2\sk1415\gears\" + fi.Name)
                g.Dispose()
                b.Dispose()
                bb.Dispose()
            Next
        End Sub
    End Class

    Friend Class LabelSequence
        Private Shared exts As New List(Of String) From {".png", ".tga"} ', ".tif", ".tiff"}
        'Private _dir As DirectoryInfo

        Friend Property Dir As String
        Friend Property Dir43 As String
        Friend Property Dir169 As String

        Private dirVia As String
        Friend Property Files As List(Of IndexedFile)

        Private W As Integer

        Friend Sub New(src As String)
            '_dir = dir
            'If Not _dir.EndsWith("\"c) Then _dir += "\"c
            Dim di As New DirectoryInfo(src)

            If Not src.EndsWith("\"c) Then src += "\"c
            dirVia = src + "label\"
            _Dir = src
            _Dir43 = dirVia + "43\"
            _Dir169 = dirVia + "169\"

            dirVia += di.Name 'faili põhinimi direktorile liidetud

            If Not Directory.Exists(_Dir43) Then Directory.CreateDirectory(_Dir43)
            If Not Directory.Exists(_Dir169) Then Directory.CreateDirectory(_Dir169)

            W = MaxAlpha(di.GetFiles.Last)

            Dim fNs As New List(Of String)

            For Each f As FileInfo In di.GetFiles
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
        End Sub

        Friend Sub Proccess()

            Dim processor As FrameProcessor = New LabelProcessor1415(Me, W)

            Try
                Parallel.ForEach(Of IndexedFile)(_Files, AddressOf processor.proccess)

                Dim fnVia As String
                Dim tasks As New List(Of Task)
                Dim viaAct As Action(Of Object) = AddressOf MakeVia


                fnVia = dirVia + ".via"
                tasks.Add(Task.Factory.StartNew(viaAct, New ViaOptions(fnVia, Dir43)))

                fnVia = dirVia + "_w.via"
                tasks.Add(Task.Factory.StartNew(viaAct, New ViaOptions(fnVia, Dir169)))

                Task.WaitAll(tasks.ToArray)
            Catch ex As Exception

            End Try

        End Sub

        Private Sub MakeVia(viaobj As Object)  'viaFn As String, dirSrc As String)
            Dim viaopt As ViaOptions = CType(viaobj, ViaOptions)
            Dim via As New ViaBuildLib.ViaFile
            Dim ViaFrame As New ViaBuildLib.Image

            ViaFrame.Filename = viaopt.source + _Files.First.Name
            viaopt.Width = ViaFrame.Width   'via suurus 1. kaadri järgi
            viaopt.Height = ViaFrame.Height

            Try
                With via
                    .Filename = viaopt.name ' viaFn
                    .Height = viaopt.Height ' 576
                    .Width = viaopt.Width '720
                    .FieldDominance = 0
                    .Open()

                    For i As Integer = 0 To CInt(.Width / 4) + 4 'fix tühjade kaadrite arv
                        .AddFrame(ViaFrame)
                    Next

                    For Each ifn As IndexedFile In _Files
                        ViaFrame.Filename = viaopt.source + ifn.Name
                        .AddFrame(ViaFrame)
                    Next

                    Try
                        ViaFrame.Filename = viaopt.source + _Files(CInt(_Files.Count * 0.85)).Name
                        .Thumbnail = ViaFrame

                        If viaopt.ThumbFiles Then ViaFrame.Convert(viaopt.name.Replace(".via", ".png"))

                    Catch ex As Exception

                    End Try
                    .Close()
                End With
            Catch ex As Exception
                Return
            End Try

            Try
                ' If Directory.Exists(viaopt.source) Then Directory.Delete(viaopt.source, True)

                Dim fi As New FileInfo(viaopt.name)
                fi.CopyTo("E:\Eetrigraafika\Kanal2\info1415\" + fi.Name, True)

            Catch ex As Exception
            End Try
        End Sub

        Private Function MaxAlpha(fi As FileInfo) As Integer
            Dim bb As Bitmap = New Bitmap(fi.FullName)
            Dim y As Integer = CInt(bb.Height / 2)

            For x As Integer = bb.Width - 1 To 1 Step -1
                If bb.GetPixel(x, y).A > 0 Then
                    Return Math.Min(bb.Width, x + 4)
                End If
            Next

            Return 0
        End Function
    End Class

    Friend MustInherit Class FrameProcessor

        Protected Shared sizePal As New Size(720, 576)
        Protected Shared size43 As New Size(768, 576)
        Protected Shared size169 As New Size(1024, 576)
        Protected Shared sizeHD As New Size(1920, 1080)

        Friend Sub New(init As String)
            'lBack.LayerFromFile(VideoSequence.DirRes + "back.png")
            ' bBack = New Bitmap(VideoSequence.DirRes + "back.png")
        End Sub

        Friend Shared Function Create(video As VideoSequence, id As String) As FrameProcessor
            Dim processor As FrameProcessor

            Dim ids() As String = id.Split("_"c)
            'Dim idSel As String = String.Join("_", ids, 3)

            Select Case ids(0)
                Case "hd"
                    processor = New FrameProcessor_HD(ids(1))
                Case "720"
                    Select Case ids(1)
                        Case "43"
                            processor = New FrameProcessor_720_43(ids(2)) '"720_43_left", "720_43_right"
                        Case Else '"169"
                            processor = New FrameProcessor_720_169(ids(2)) '"720_169_left", "720_169_right"
                    End Select
                Case "1024"
                    If ids.Count < 3 Then
                        processor = New FrameProcessor_1024_169(ids(1)) '1024_left,1024_right,1024_center,1024_## (0..99)
                    Else
                        Select Case ids(2)
                            Case "cut"
                                processor = New FrameProcessor_1024_169_cut(ids(1), ids(3)) '"1024_left_cut_x,y,w,h",1024_right_cut_x,y,w,h"
                            Case Else
                                processor = New FrameProcessor_1024_169(ids(1)) '1024_left,1024_right
                        End Select
                    End If
                Case "mask"
                    Dim maskfn As String = New DirectoryInfo(video.DirHome).Parent.FullName + "\maskdiff.png"
                    processor = New FrameProcessor_mask_169_cut(ids(1), ids(3), maskfn)
                Case "draw"
                    processor = New FrameProcessor_Draw(ids)
                Case Else
                    If id.StartsWith("w") Then
                        processor = New FrameProcessor_240_169(id)
                    Else
                        processor = New FrameProcessor_240_43(id)
                    End If
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

        Protected Property Parent As VideoSequence

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
            Dim bb As Bitmap = New Bitmap(VideoSequence.FnBack)

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

    Friend MustInherit Class FrameProcessor_sideswitch
        Inherits FrameProcessor

        Protected rectCut As Rectangle
        Friend Sub New(init As String)
            MyBase.New(init)

            'If init.EndsWith("right") Then
            If init = "right" Then
                rectCut = New Rectangle(256, 0, 768, 576)   'lõige 1024 laiusega kaadrist
            ElseIf init.StartsWith("c"c) Then   'center
                rectCut = New Rectangle(128, 0, 768, 576)
            ElseIf Char.IsDigit(init.First) Then    'protsent vasaku ja parema joonduse vahel
                Dim pr As Double
                If Double.TryParse(init, pr) Then
                    If pr > 0.999 Then pr /= 100 'kuiväärtus alla 1 siis võtta koefitsendina 
                Else
                    pr = 0
                End If
                rectCut = New Rectangle(CInt(256 * pr), 0, 768, 576)
            Else
                rectCut = New Rectangle(0, 0, 768, 576)
            End If
        End Sub

    End Class

    Friend Class FrameProcessor_720_43
        Inherits FrameProcessor_sideswitch

        Friend Sub New(init As String)
            MyBase.New(init)
        End Sub

        Friend Overrides Sub proccess(ifn As IndexedFile) '720 laiusega kaader mis on 43 formaadis!
            Dim b43 As Bitmap = GetBitmap(ifn) '  New Bitmap(Parent.Dir + fn)
            File.Copy(Parent.DirHome + ifn.Name, Parent.Dir43 + ifn.Name) 'png kui oli tga

            b43.SetResolution(96, 96)
            b43 = Resize(b43, size43) '720->768
            Dim b169 As New Bitmap(size169.Width, size169.Height)
            b169.SetResolution(96, 96)

            Dim g As Graphics = Graphics.FromImage(b169) 'joonistab kujutise laiemale kaadrile
            g.DrawImageUnscaled(b43, rectCut.Location)
            g.Dispose()
            b43.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)
            b169.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_720_169
        Inherits FrameProcessor_sideswitch

        Friend Sub New(init As String)
            MyBase.New(init)
        End Sub

        Friend Overrides Sub proccess(ifn As IndexedFile) '720 laiusega kaader mis on 169 formaadis!
            Dim b169 As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            File.Copy(Parent.DirHome + ifn.Name, Parent.Dir169 + ifn.Name)

            b169.SetResolution(96, 96)
            Example(b169, ifn.Index)

            b169 = Resize(b169, size169) 'lõikamiseks venitada täislaiusesse

            Dim b43 As Bitmap = b169.Clone(rectCut, Imaging.PixelFormat.Format32bppArgb) ' b169.PixelFormat)
            b43 = Resize(b43, sizePal)

            b43.Save(Parent.Dir43 + ifn.Name)
            b43.Dispose()
            b169.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_HD
        Inherits FrameProcessor_sideswitch

        Friend Sub New(init As String)
            MyBase.New(init)
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim bHD As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            bHD.SetResolution(96, 96)

            If bHD.Width <> sizeHD.Width OrElse bHD.Height <> sizeHD.Height Then bHD = Resize(bHD, sizeHD)

            'bHD.Save(Parent.DirHD + ifn.Name)
            TargaFile.SaveAsTarga(Parent.DirHD + ifn.Name.ToLower.Replace(".png", ".tga"), bHD)
            bHD.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_1024_169
        Inherits FrameProcessor_sideswitch

        Friend Sub New(init As String)
            MyBase.New(init)
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b169 As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            b169.SetResolution(96, 96)

            'If Parent.DirHD.Length > 0 Then
            '    Dim bHD As New Bitmap(b169, sizeHD)
            '    bHD.Save(String.Format("{0}frame{1:0000}.png", Parent.DirHD, ifn.Index), Drawing.Imaging.ImageFormat.Png)
            '    bHD.Dispose()
            'End If

            If b169.Width > 1024 OrElse b169.Height <> 576 Then b169 = Resize(b169, size169)

            Dim b43 As Bitmap = b169.Clone(rectCut, Imaging.PixelFormat.Format32bppArgb) ' b169.PixelFormat)
            b43 = Resize(b43, sizePal)
            b43.Save(Parent.Dir43 + ifn.Name)

            b43.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)
            b169.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_1024_169_cut
        Inherits FrameProcessor_sideswitch

        Private finalCut As Rectangle

        Friend Sub New(side As String, cut As String)
            MyBase.New(side)

            Try
                Dim values() As String = cut.Split(","c)
                finalCut = New Rectangle(CInt(values(0)), CInt(values(1)), CInt(values(2)), CInt(values(3)))
            Catch ex As Exception
                finalCut = New Rectangle(0, 0, 720, 576)
            End Try
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b169 As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            b169.SetResolution(96, 96)
            If b169.Width > 1024 OrElse b169.Height <> 576 Then b169 = Resize(b169, size169)

            Dim b43 As Bitmap = b169.Clone(rectCut, Imaging.PixelFormat.Format32bppArgb) ' b169.PixelFormat)
            b43 = Resize(b43, sizePal)
            Dim b43c As Bitmap = b43.Clone(finalCut, Imaging.PixelFormat.Format32bppArgb)
            b43c.Save(Parent.Dir43 + ifn.Name)

            b43.Dispose()
            b43c.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)

            Dim b169c As Bitmap = b169.Clone(finalCut, Imaging.PixelFormat.Format32bppArgb)
            b169c.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
            b169c.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_mask_169_cut
        Inherits FrameProcessor_sideswitch

        Private finalCut As Rectangle
        ' Private bmask As Bitmap
        Private mFn As String

        Friend Sub New(side As String, cut As String, maskfn As String)
            MyBase.New(side)

            Try
                Dim values() As String = cut.Split(","c)
                finalCut = New Rectangle(CInt(values(0)), CInt(values(1)), CInt(values(2)), CInt(values(3)))
            Catch ex As Exception
                finalCut = New Rectangle(0, 0, 720, 576)
            End Try

            mFn = maskfn
            'bmask = New Bitmap(maskfn)
            'bmask.SetResolution(96, 96)
            'If bmask.Width > 1024 OrElse bmask.Height <> 576 Then bmask = Resize(bmask, size169)
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b169 As Bitmap = GetBitmap(ifn) ' New Bitmap(Parent.Dir + fn)
            b169.SetResolution(96, 96)
            If b169.Width > 1024 OrElse b169.Height <> 576 Then b169 = Resize(b169, size169)
            MakeMask(b169)

            Dim b43 As Bitmap = b169.Clone(rectCut, Imaging.PixelFormat.Format32bppArgb) ' b169.PixelFormat)
            b43 = Resize(b43, sizePal)
            Dim b43c As Bitmap = b43.Clone(finalCut, Imaging.PixelFormat.Format32bppArgb)
            b43c.Save(Parent.Dir43 + ifn.Name)

            b43.Dispose()
            b43c.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)

            Dim b169c As Bitmap = b169.Clone(finalCut, Imaging.PixelFormat.Format32bppArgb)
            b169c.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
            b169c.Dispose()
        End Sub

        Private Sub MakeMask(bframe As Bitmap)
            Dim bmask As New Bitmap(mFn)
            bmask.SetResolution(96, 96)
            If bmask.Width > 1024 OrElse bmask.Height <> 576 Then bmask = Resize(bmask, size169)

            For x As Integer = 0 To bframe.Width - 1
                For y As Integer = finalCut.Y To finalCut.Y + finalCut.Height - 1
                    Dim a As Byte = Math.Min(bmask.GetPixel(x, y).R, bframe.GetPixel(x, y).A)
                    bframe.SetPixel(x, y, Color.FromArgb(a, 255, 255, 255))
                Next
            Next
            bmask.Dispose()
        End Sub
    End Class


    Friend Class FrameProcessor_240_43
        Inherits FrameProcessor

        Private x43, x169, y As Integer

        Friend Sub New(init As String)
            MyBase.New(init)

            If init.StartsWith("xy") Then
                Dim xy() As String = init.Split("_"c)
                If xy.Count = 3 Then
                    Dim x As Double = Double.Parse(xy(1))
                    x43 = CInt(x * (768 / 720))
                    x169 = CInt(x * (1024 / 720))

                    y = Integer.Parse(xy(2))
                End If
            Else
                x43 = 64
                x169 = 85
                y = 32
            End If
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b As Bitmap = GetBitmap(ifn)
            b.SetResolution(96, 96)

            Dim b43 As Bitmap = New Bitmap(size43.Width, size43.Height) '768, 576)
            b43.SetResolution(96, 96)
            Dim x As Integer = If(x43 > 0, x43, b43.Width - b.Width + x43) 'logo asukohal vasakus või paremas servas

            Dim g43 As Graphics = Graphics.FromImage(b43)
            g43.DrawImageUnscaled(b, x, y)
            g43.Dispose()

            b43 = Resize(b43, sizePal)
            b43.Save(Parent.Dir43 + ifn.Name)
            b43.Dispose()

            Dim b169 As Bitmap = New Bitmap(size169.Width, size169.Height) '1024, 576)
            b169.SetResolution(96, 96)
            x = If(x169 > 0, x169, b169.Width - b.Width + x169) 'logo asukohal vasakus või paremas servas

            Dim g169 As Graphics = Graphics.FromImage(b169)
            g169.DrawImageUnscaled(b, x, y)
            g169.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)
            b169.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
            b.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_240_169
        Inherits FrameProcessor

        Private x43, x169, y As Integer

        Friend Sub New(init As String)
            MyBase.New(init)

            Dim xy() As String = init.Split("_"c)

            If xy.Count = 3 Then
                Dim x As Double = Double.Parse(xy(1))
                x43 = CInt(x) ' CInt(x * (768 / 720))
                x169 = x43 'CInt(x * (1024 / 720))
                y = Integer.Parse(xy(2))
            Else
                x43 = 64
                x169 = 64 '85
                y = 32
            End If
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b As Bitmap = GetBitmap(ifn)
            b.SetResolution(96, 96)

            Dim b169 As Bitmap = New Bitmap(sizePal.Width, sizePal.Height) '720, 576)
            b169.SetResolution(96, 96)
            Dim x As Integer = If(x169 > 0, x169, b169.Width - b.Width + x169) 'logo asukohal vasakus või paremas servas

            Dim g169 As Graphics = Graphics.FromImage(b169)
            g169.DrawImageUnscaled(b, x, y)
            g169.Dispose()

            'b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)
            b169.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()

            Dim s43 As New Size(CInt(b.Width / 0.75), b.Height)
            b = Resize(b, s43) 'NB venitab 43 jaoks logo laiemaks

            Dim b43 As Bitmap = New Bitmap(sizePal.Width, sizePal.Height) '720, 576)
            b43.SetResolution(96, 96)
            x = If(x43 > 0, x43, b43.Width - b.Width + x43) 'logo asukohal vasakus või paremas servas

            Dim g43 As Graphics = Graphics.FromImage(b43)
            g43.DrawImageUnscaled(b, x, y)
            g43.Dispose()

            'b43 = Resize(b43, sizePal)
            b43.Save(Parent.Dir43 + ifn.Name)
            b43.Dispose()
            b.Dispose()
        End Sub
    End Class

    Friend Class FrameProcessor_Draw
        Inherits FrameProcessor

        Private x43, x169, y As Integer
        Private sizeLogo As Size
        Private rightSide As Boolean

        Friend Sub New(xywh() As String)
            MyBase.New(xywh(0))

            'If init.StartsWith("xy") Then
            'Dim xy() As String = init.Split("_"c)
            'If xy.Count = 3 Then
            Dim x As Double = Double.Parse(xywh(1))
            x43 = CInt(x) 'CInt(x * (768 / 720))
            x169 = CInt(x) 'CInt(x * (1024 / 720))

            y = Integer.Parse(xywh(2))

            Try
                Dim w = Integer.Parse(xywh(3))
                Dim h = Integer.Parse(xywh(4))
                sizeLogo = New Size(w, h)
            Catch ex As Exception
                sizeLogo = New Size(240, 160)
            End Try

            Try
                rightSide = xywh(5).StartsWith("r"c)
            Catch ex As Exception

            End Try
            'End If
            'Else
            '    x43 = 64
            '    x169 = 85
            '    y = 32
            'End If
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b As Bitmap = GetBitmap(ifn)
            b.SetResolution(96, 96)

            If Not (b.Size = sizeLogo) Then  'kaadri suurus vajalikuks
                b = Resize(b, sizeLogo)
            End If

            Dim b43 As Bitmap = New Bitmap(size43.Width, size43.Height) '768, 576)
            b43.SetResolution(96, 96)
            Dim x As Integer = If(rightSide, b43.Width - b.Width - x43, x43) 'logo asukohal vasakus või paremas servas

            Dim g43 As Graphics = Graphics.FromImage(b43)
            g43.DrawImageUnscaled(b, x, y)
            g43.Dispose()

            b43 = Resize(b43, sizePal) '720x576
            b43.Save(Parent.Dir43 + ifn.Name)
            b43.Dispose()

            Dim b169 As Bitmap = New Bitmap(size169.Width, size169.Height) '1024, 576)
            b169.SetResolution(96, 96)
            x = If(rightSide, b169.Width - b.Width - x169, x169) 'logo asukohal vasakus või paremas servas

            Dim g169 As Graphics = Graphics.FromImage(b169)
            g169.DrawImageUnscaled(b, x, y)
            g169.Dispose()

            b169 = Resize(b169, sizePal)
            Example(b169, ifn.Index)
            b169.Save(Parent.Dir169 + ifn.Name)
            b169.Dispose()
            b.Dispose()
        End Sub
    End Class

    Friend Class LabelProcessor1415
        Inherits FrameProcessor

        Private label As LabelSequence

        Private rectCut As Rectangle
        Private s43 As Size
        Private s169 As Size
        Private cf As Double

        Friend Sub New(l As LabelSequence, w As Integer)
            MyBase.New(String.Empty)

            Dim h As Integer = 30 '28

            label = l
            rectCut = New Rectangle(0, 4, w, 32)

            Dim w43 As Integer = CInt(w * (h / 32))
            s43 = New Size(w43, h)

            Dim w169 As Integer = CInt(w * (h / 32) * 0.7)
            s169 = New Size(w169, h)

            cf = 2 / 3 '0.75
        End Sub

        Friend Overrides Sub Proccess(ifn As IndexedFile)
            Dim b = New Bitmap(label.Dir + ifn.Name)
            b.SetResolution(96, 96)
            ColorCorrection(b)

            Dim bCut As Bitmap = b.Clone(rectCut, Imaging.PixelFormat.Format32bppArgb)
            bCut.SetResolution(96, 96)

            Dim b43 As New Bitmap(bCut, s43)
            b43.Save(label.Dir43 + ifn.Name)
            b43.Dispose()

            Dim b169 As New Bitmap(bCut, s169)
            b169.Save(label.Dir169 + ifn.Name)
            b169.Dispose()

            bCut.Dispose()
            b.Dispose()
        End Sub

        Private Sub ColorCorrection(b As Bitmap)
            For x As Integer = 0 To 11
                For y As Integer = 0 To b.Height - 1
                    With b.GetPixel(x, y)
                        'If .B > 15 AndAlso .B = .G AndAlso .B = .R Then
                        Dim c As Color = Color.FromArgb(.A, CInt(cf * .R), CInt(cf * .G), CInt(cf * .B))
                        b.SetPixel(x, y, c)
                        'End If
                    End With
                Next
            Next
        End Sub
    End Class


    Friend Class VideoFile
        Friend Shared DirFmpeg As String = "E:\_home_\bin\ffmpeg\"

        Private _name As String = String.Empty
        Private _dir As String
        'Private _hd As Boolean
        Private _CodecID As String
        Private Out As String = String.Empty
        Private Err As String = String.Empty

        Friend Sub New(dir As String, name As String, codecID As String)
            '_hd = hd
            _CodecID = codecID
            _name = name
            _dir = dir '+ "exmpl\"
            If Not _dir.EndsWith("\"c) Then _dir += "\"
        End Sub

        Friend Sub encode()
            ' If _name.Length = 0 Then Return
            If Not Directory.Exists(_dir) Then Return

            Dim vFn As String '= VideoSequence.DirRes + "example\" + _name + ".mp4"
            Dim logname As String
            Dim cmdline As String

            If _name.Contains("\") Then
                vFn = _name
                logname = _name.Substring(_name.LastIndexOf("\") + 1)
            Else
                vFn = ActiveChannel.dirResBug + _name
                logname = _name
            End If
            logname = VideoSequence.DirRes + "logs\" + logname

            Select Case _CodecID
                Case "png"
                    'vFn = VideoSequence.DirRes + "hd\" + _name + ".mov"
                    vFn += ".mov"
                    logname += "_mov"
                    cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -s 1920x1080 -codec:v png -y ""{1}""", GetPattern, vFn)
                    'vFn = ActiveChannel.dirVia + _name + ".ts" 'Out.ts
                    'cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -s 1920x1080 -vcodec vc2 -strict -1 ""{1}""", GetPattern, vFn) 
                Case "proRes" 'Alpha
                    vFn += ".mov"
                    logname += "_mov"
                    cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -s 1920x1080 -field_order tt -vcodec prores_ks -profile:v 4 -pix_fmt yuva444p10 -y ""{1}""", GetPattern, vFn)
                Case "proResF" 'Alpha+fields
                    vFn += ".mov"
                    logname += "_mov"
                    cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -s 1920x1080 -field_order tt -vcodec prores_ks -profile:v 4 -pix_fmt yuva444p10 -top 1 -flags +ildct+ilme -y ""{1}""", GetPattern, vFn)
                Case "DNxHD"
                    vFn += ".mov"
                    logname += "_mov"
                    cmdline = String.Format("-f image2 {0} -aspect 16: 9 -r 25 -codec:v dnxhd -b:v 120M -y ""{1}""", GetPattern, vFn) 'ei mängi alpha
                Case Else   'example video
                    vFn = VideoSequence.DirRes + "example\" + _name + ".mp4"
                    logname += "_mp4"
                    cmdline = String.Format("-f image2 {0} -codec:v libx264 -s 720x576 -aspect 16:9 -b:v 850000 -r 25 -y ""{1}""", GetPattern, vFn)
            End Select


            'If _hd Then 'läbipaistev HD video
            '    vFn = VideoSequence.DirRes + "hd\" + _name + ".mov"
            '    logname = _name + "_mov"
            'Else
            '    vFn = VideoSequence.DirRes + "example\" + _name + ".mp4"
            '    logname = _name + "_mp4"
            'End If

            If File.Exists(vFn) Then File.Delete(vFn)



            'mpeg2
            'cmdline = String.Format("-f image2 {0} -f mpegts -vcodec mpeg2video -s 720x576 -aspect 16:9 -b:v {1} -r 25 -y ""{2}""",  GetPattern, 50000000, VideoSequence.DirRes + "example\" + name + ".mpg")

            'h264

            'If _hd Then 'läbipaistev HD video
            '    'ffmpeg.exe -i \\pathToRenderFolder\image_%%5d.png” -r 25 -b:v 5000000 -c:v wmv1 -vf “[in] split [T1],fifo, lutrgb=r=0:g=0:b=0, pad=in_w:in_h:0:0:0×000000, [T2] overlay [out]; [T1] fifo, pad=in_w:in_h:0:0:0×000000[T2]” -y “\\pathToRenderFolder\video.wmv”
            '    'cmdline = String.Format("-f image2 {0} -codec:v png -s 1920x1080 -aspect 16:9 -r 25 -y ""{1}""", GetPattern, vFn)
            '    'Dim filter As String = " -vf ""[in] split [T1],fifo, lutrgb=r=0:g=0:b=0, pad=in_w:in_h:0:0:0x000000, [T2] overlay [out]; [T1] fifo, pad=in_w:in_h:0:0:0x000000[T2]"""
            '    cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -s 1920x1080 -codec:v png -y ""{1}""", GetPattern, vFn)
            '    'cmdline = String.Format("-f image2 {0} -aspect 16:9 -r 25 -codec:v dnxhd -b:v 120M -y ""{1}""", GetPattern, vFn) 'ei mängi alpha
            'Else
            '    cmdline = String.Format("-f image2 {0} -codec:v libx264 -s 720x576 -aspect 16:9 -b:v 850000 -r 25 -y ""{1}""", GetPattern, vFn)
            'End If

            Dim Proc As New Diagnostics.Process

            With Proc.StartInfo
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .FileName = DirFmpeg + "bin\ffmpeg.exe"
                .Arguments = cmdline
            End With

            AddHandler Proc.OutputDataReceived, AddressOf OutHandler
            AddHandler Proc.ErrorDataReceived, AddressOf ErrHandler

            Proc.Start()

            Proc.BeginOutputReadLine()
            Proc.BeginErrorReadLine()

            Proc.WaitForExit()
            Proc.Dispose()
            'If Not String.IsNullOrEmpty(Out) Then
            '    Dim f1 As TextWriter = FileIO.FileSystem.OpenTextFileWriter(VideoSequence.DirRes + "example\logs\" + logname + ".txt", True)
            '    f1.Write(Out)
            '    f1.Close()
            'End If

            If Not String.IsNullOrEmpty(Err) Then
                Dim f1 As TextWriter = FileIO.FileSystem.OpenTextFileWriter(logname + ".txt", True)
                f1.Write(Err)
                f1.Close()
            End If
        End Sub

        Private Sub OutHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
            If Not String.IsNullOrEmpty(outLine.Data) Then
                Out += outLine.Data + Environment.NewLine
            End If
        End Sub

        Private Sub ErrHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
            If Not String.IsNullOrEmpty(outLine.Data) Then
                Err += outLine.Data + Environment.NewLine
            End If
        End Sub

        Private Function GetPattern() As String
            '-start_number 0 -i foo-%03d.jpeg
            Dim ext As String, fn As String, start As Integer
            Dim f As FileInfo = New DirectoryInfo(_dir).GetFiles.First

            ext = f.Extension

            Dim name As String = f.Name.Replace(ext, "")

            Dim index As Integer = 0
            Dim pos As Integer

            For Each C As Char In name.ToCharArray
                index += 1
                If Not Char.IsDigit(C) Then pos = index
            Next

            fn = _dir + If(pos > 0, name.Substring(0, pos), String.Empty)
            name = name.Substring(pos)
            start = CInt(Val(name))
            fn += String.Format("%0{0}d", name.Length)

            Return String.Format("-start_number {0} -i ""{1}{2}""", start, fn, ext)
        End Function
    End Class

    Friend Class IndexedFile

        Friend Sub New(i As Integer, fn As String)
            _index = i
            _Name = fn
        End Sub

        Friend Property Name As String
        Private _index As Integer
        Friend ReadOnly Property Index As Integer
            Get
                Return _index
            End Get
        End Property
    End Class

    Friend Class ViaOptions
        Friend Sub New(fn As String, dir As String)
            _name = fn
            _source = dir
            _ClearBegEnd = True
        End Sub

        Friend Sub New(fn As String, dir As String, s As Size)
            _name = fn
            _source = dir
            _ClearBegEnd = True
            _Height = s.Height
            _Width = s.Width
        End Sub

        Private _name As String
        Friend ReadOnly Property name As String
            Get
                Return _name
            End Get
        End Property

        Private _source As String
        Friend ReadOnly Property source As String
            Get
                Return _source
            End Get
        End Property

        Friend Property ThumbFiles As Boolean
        Friend Property ClearBegEnd As Boolean

        Friend Property Height As Integer = 576
        Friend Property Width As Integer = 720
    End Class
    'ffmpeg -f image2 -start_number 0 -i foo-%03d.jpeg -r 25		   (img-000.jpeg...)
    'ffmpeg -pattern_type glob -i "*.png" -r 10 out.mkv
    '-codec:v libx264  out.mp4
End Module
