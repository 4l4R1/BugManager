Option Strict On
Option Explicit On

Imports System.IO
Imports TimeIntervalControl

Public Class Form1
    'Private rtx1 As New RtxLib.Rtx
    Private Setup As New List(Of ChannelSetup)
    'Private ActiveChannel As ChannelSetup
    Private channels As New Dictionary(Of Button, ChannelSetup)
    Private stylemode As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Calendar = New TimePeriod("E:\Eetrigraafika\conf\calendar.xml")

        Dim ch As ChannelSetup
        'Setup.Add(New ChannelSetup)	'0=empty
        '----------------------------------------------------------------------------------------
        'ch = New ChannelSetup With {.dirVia = "E:\Eetrigraafika\bug\_res\via-2-11\",
        ' .GuideFn = "\\INCA2\eetrigraafika\kanal2\guide\kanal2.xml",
        ' .PlanLocalFn = "E:\Eetrigraafika\Kanal2\bug\planTest.xml",
        ' .PlanFn = "E:\Eetrigraafika\Kanal2\bug\plan.xml",
        ' .DirBug = "E:\Eetrigraafika\Kanal2\bug\",
        ' .defVideoStyle = "left"}

        ch = New ChannelSetup With {.dirResBug = "E:\Eetrigraafika\bug\_res\hd-2-11\",
         .dirResVid = "E:\_home_\doc\Saated\eetrigraafika\Kanal 2\_renders\",
         .GuideFn = "\\INCA2\eetrigraafika\kanal2\guide\kanal2.xml",
         .PlanLocalFn = "E:\Eetrigraafika\Kanal2\bugHD\planTest.xml",
         .PlanFn = "E:\Caspar\Eetrigraafika\Kanal2\bugHD\plan.xml",
         .DirLocalBug = "E:\Eetrigraafika\Kanal2\bugHD\",
         .DirBug = "E:\Caspar\Eetrigraafika\Kanal2\bugHD\",
         .defVideoStyle = "left", .HD = True}

        Setup.Add(ch)
        channels.Add(bk2test, ch)
        cMode.Items.Add("Bugid - K2 HD TEST")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = "E:\Eetrigraafika\bug\_res\via-2-11\",
         .dirResVid = "E:\_home_\doc\Saated\eetrigraafika\Kanal 2\_renders\",
         .GuideFn = "\\INCA2\eetrigraafika\kanal2\guide\kanal2.xml",
         .PlanLocalFn = "E:\Eetrigraafika\Kanal2\bug\planReal.xml",
         .PlanFn = "\\INCA2\eetrigraafika\kanal2\bug\plan.xml",
         .DirLocalBug = "E:\Eetrigraafika\Kanal2\bug\",
         .DirBug = "\\INCA2\eetrigraafika\kanal2\bug\",
         .defVideoStyle = "left"}

        Setup.Add(ch)
        channels.Add(bk2, ch)
        cMode.Items.Add("Bugid - K2")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = "E:\Eetrigraafika\bug\_res\via-2-11\",
         .dirResVid = "E:\_home_\doc\Saated\eetrigraafika\Kanal 11\_renders\",
         .GuideFn = "\\INCA2\eetrigraafika\kanal11\guide\kanal11.xml",
         .PlanLocalFn = "E:\Eetrigraafika\Kanal11\bug\plan.xml",
         .PlanFn = "\\INCA11\eetrigraafika11\kanal11\bug\plan.xml",
         .DirLocalBug = "E:\Eetrigraafika\Kanal11\bug\",
         .DirBug = "\\INCA11\eetrigraafika11\kanal11\bug\",
         .defVideoStyle = "left"}

        Setup.Add(ch)
        channels.Add(bk11, ch)
        cMode.Items.Add("Bugid - K11")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = "E:\Eetrigraafika\bug\_res\hd-12\",
        .dirResVid = "E:\_home_\doc\Saated\eetrigraafika\Kanal 12\_renders\",
        .GuideFn = "\\INCA2\eetrigraafika\kanal12\guide\kanal12.xml",
        .PlanLocalFn = "E:\Eetrigraafika\Kanal2\bugHD\planTest.xml",
        .PlanFn = "\\CASPAR_K12-HP\Caspar\Eetrigraafika\Kanal12\bugHD\plan.xml",
        .DirLocalBug = "E:\Caspar\Eetrigraafika\Kanal12\bugHD\",
        .DirBug = "\\CASPAR_K12-HP\Caspar\Eetrigraafika\Kanal12\bugHD\",
        .defVideoStyle = "right", .HD = True}

        Setup.Add(ch)
        channels.Add(bk12test, ch)
        cMode.Items.Add("Bugid - K12 HD TEST")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = "E:\Eetrigraafika\bug\_res\via-12\",
        .dirResVid = "E:\_home_\doc\Saated\eetrigraafika\Kanal 12\_renders\",
        .GuideFn = "\\INCA2\eetrigraafika\kanal12\guide\kanal12.xml",
        .PlanLocalFn = "E:\Eetrigraafika\Kanal12\bug\planReal.xml",
        .PlanFn = "\\RTX12\eetrigraafika12\Kanal12\bug\plan.xml",
        .DirLocalBug = "E:\Eetrigraafika\Kanal12\bug\",
        .DirBug = "\\RTX12\eetrigraafika12\Kanal12\bug\",
        .defVideoStyle = "right"}

        Setup.Add(ch)
        channels.Add(bk12, ch)
        cMode.Items.Add("Bugid - K12")
        '----------------------------------------------------------------------------------------
        '      ch = New ChannelSetup With {.dirVia = "E:\Eetrigraafika\bug\_res\via-2-t\",
        '       .GuideFn = "\\192.168.73.22\eetrigraafika\kanal2\guide\kanal2.xml",
        '       .PlanLocalFn = "E:\Eetrigraafika\Kanal2\messages\plan.xml",
        '       .PlanFn = "\\192.168.73.22\eetrigraafika\kanal2\messages\plan.xml",
        '       .DirLocalBug = "E:\Eetrigraafika\Kanal2\messages\",
        '       .DirBug = "\\192.168.73.22\eetrigraafika\kanal2\messages\",
        '       .VideoStyle = "all"}

        'Setup.Add(ch)
        'channels.Add(btk2, ch)
        'cMode.Items.Add("Teated - K2")
        '-----------------------------------------------------------------------------------------
        '.PlanFn = "\\K2-ALARI\EetrigraafikaX\Kanal2\styles\plan.xml",
        ch = New ChannelSetup With {.dirResBug = String.Empty, .dirResVid = String.Empty,
        .GuideFn = "\\INCA2\eetrigraafika\kanal2\guide\kanal2.xml",
        .PlanLocalFn = "E:\Eetrigraafika\Kanal2\styles\testPlan.xml",
        .PlanFn = "E:\Eetrigraafika\Kanal2\styles\plan.xml",
        .DirLocalBug = String.Empty,
        .DirBug = "\\K2-ALARI\EetrigraafikaX\Kanal2\styles\",
        .defVideoStyle = "all",
        .Virtual = True}

        Setup.Add(ch)
        cMode.Items.Add("Style - K2 TEST")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = String.Empty, .dirResVid = String.Empty,
       .GuideFn = "\\INCA2\eetrigraafika\kanal2\guide\kanal2.xml",
       .PlanLocalFn = "E:\Eetrigraafika\Kanal2\styles\planReal.xml",
       .PlanFn = "\\INCA2\eetrigraafika\kanal2\styles\plan.xml",
       .DirLocalBug = String.Empty,
       .DirBug = "\\INCA2\eetrigraafika\kanal2\styles\",
       .defVideoStyle = "all",
       .Virtual = True}

        Setup.Add(ch)
        cMode.Items.Add("Style - K2")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = String.Empty, .dirResVid = String.Empty,
       .GuideFn = "\\INCA2\eetrigraafika\kanal11\guide\kanal11.xml",
       .PlanLocalFn = "E:\Eetrigraafika\Kanal11\styles\plan.xml",
       .PlanFn = "\\INCA11\eetrigraafika11\kanal11\styles\plan.xml",
       .DirLocalBug = String.Empty,
       .DirBug = "\\INCA11\eetrigraafika11\kanal11\styles\",
       .defVideoStyle = "all",
       .Virtual = True}

        Setup.Add(ch)
        cMode.Items.Add("Style - K11")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = String.Empty, .dirResVid = String.Empty,
       .GuideFn = "\\INCA2\eetrigraafika\kanal12\guide\kanal12.xml",
       .PlanLocalFn = "E:\Eetrigraafika\Kanal12\styles\testplan.xml",
       .PlanFn = "E:\Eetrigraafika\Kanal12\styles\plan.xml",
       .DirLocalBug = String.Empty,
       .DirBug = "E:\Eetrigraafika\Kanal12\styles\",
       .defVideoStyle = "all",
       .Virtual = True}

        Setup.Add(ch)
        cMode.Items.Add("Style - K12 TEST")
        '----------------------------------------------------------------------------------------
        ch = New ChannelSetup With {.dirResBug = String.Empty, .dirResVid = String.Empty,
       .GuideFn = "\\INCA2\eetrigraafika\kanal12\guide\kanal12.xml",
       .PlanLocalFn = "E:\Eetrigraafika\Kanal12\styles\realplan.xml",
       .PlanFn = "\\RTX12\eetrigraafika12\Kanal12\styles\plan.xml",
       .DirLocalBug = String.Empty,
       .DirBug = "\\RTX12\eetrigraafika12\Kanal12\styles\",
       .defVideoStyle = "all",
       .Virtual = True}

        Setup.Add(ch)
        cMode.Items.Add("Style - K12")
        '----------------------------------------------------------------------------------------
        'Setup.Add(New ChannelSetup)	'tühi
        'cMode.Items.Add("keelatud")
        'cMode.Items.AddRange({"Bugid - K2TEST", "Bugid - K2", "Bugid - K11", "Bugid - K12", "Teated- K2", "Eetrigraafika"})
        grStyle.Location = grCntrl.Location

        Cleanup()
        cMode.SelectedIndex = 0
    End Sub

    Private Sub Control()

        Dim missingfiles As New HashSet(Of String)
        For Each via As String In Plan.ActiveFiles
            If ChannelBugUpdate(via) Then missingfiles.Add(via)
        Next

        If missingfiles.Count = 0 Then Return

        Dim report As String = String.Join(", ", missingfiles)
        If MessageBox.Show(report, "Paigutada need failid?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Return

        For Each via As String In missingfiles
            If Not ActiveChannel.MoveBug(via) Then
                MessageBox.Show(via + "kopeermine ei õnnestunud", "Kopeerimine", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Next

    End Sub

    Private Sub Cleanup()
        Dim srcFiles As New Dictionary(Of String, HashSet(Of String))

        'kõikide via asukohtade piisavalt vanade failide nimekiri
        For Each ch As ChannelSetup In channels.Values
            If Not srcFiles.ContainsKey(ch.dirResBug) Then
                Dim files As New HashSet(Of String)
                For Each f As FileInfo In New DirectoryInfo(ch.dirResBug).GetFiles
                    If (Date.UtcNow - f.LastWriteTimeUtc).TotalDays > 60 Then '100 Then
                        If f.Extension.ToLower = ch.Ext AndAlso Not f.Name.Contains("_w.") AndAlso Not f.Name.Contains("_v.") Then
                            files.Add(f.Name.Replace(f.Extension, String.Empty))
                        End If
                    End If
                Next
                srcFiles(ch.dirResBug) = files
            End If
        Next

        'välistada kustutatavatest failidest need millel on kehtivad reeglid
        For Each ch As ChannelSetup In channels.Values
            Dim plan As New ChannelPlan(ch)
            plan.RemoveActiveFiles(srcFiles(ch.dirResBug))
        Next

        'kinnitava küsimuse koostamine
        Dim report As String = String.Empty
        Dim reportcount As Integer = 0

        For Each Dir_list As KeyValuePair(Of String, HashSet(Of String)) In srcFiles
            If Dir_list.Value.Count > 0 Then
                reportcount += Dir_list.Value.Count
                report += New DirectoryInfo(Dir_list.Key).Name + ":" + System.Environment.NewLine
                report += String.Join(", ", Dir_list.Value) + System.Environment.NewLine + System.Environment.NewLine
            End If
        Next

        If reportcount = 0 Then 'pole midagi kustutada
            'MessageBox.Show("Pole midagi kustutada", "Puhastus")
            Return
        End If

        If MessageBox.Show(report, "Kustutada need failid?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Cancel Then Return

        'kustutada eetrigraafika failid
        Dim fn As String
        For Each ch As ChannelSetup In channels.Values
            For Each f As String In srcFiles(ch.dirResBug)
                fn = ch.DirBug + f + ch.Ext
                If File.Exists(fn) Then File.Delete(fn)
                If Not ch.HD Then
                    fn = ch.DirBug + f + "_w.via"
                    If File.Exists(fn) Then File.Delete(fn)
                End If
            Next
        Next

        'arhiveerida kohalikud failid
        For Each Dir_list As KeyValuePair(Of String, HashSet(Of String)) In srcFiles
            Dim backup As String = Dir_list.Key + "backup\"
            If Not Directory.Exists(backup) Then Directory.CreateDirectory(backup)
            For Each f As String In Dir_list.Value

                MoveBackupfile(Dir_list.Key + f + ".via", backup + f + ".via")
                MoveBackupfile(Dir_list.Key + f + "_w.via", backup + f + "_w.via")
                MoveBackupfile(Dir_list.Key + f + ".mov", backup + f + ".mov")
            Next
        Next
    End Sub

    Private Sub MoveBackupfile(fn As String, fn2 As String)
        Dim fi2 As New FileInfo(fn2)
        'If File.Exists(fn2) Then File.Move(fn2, fn2.Replace(ActiveChannel.Ext, Now.ToString("_MMdd_HHmmss") + ActiveChannel.Ext))
        If fi2.Exists Then fi2.MoveTo(fn2.Replace(fi2.Extension, Now.ToString("_MMdd_HHmmss") + fi2.Extension))
        If File.Exists(fn) Then File.Move(fn, fn2)
    End Sub

    Private Sub cMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cMode.SelectedIndexChanged

        ActiveChannel = Setup(cMode.SelectedIndex)

        'grBug.Enabled = True
        'grStyle.Visible = False
        stylemode = False

        Select Case cMode.SelectedIndex
            Case 0    'K2TEST
                bk2.Enabled = True
                bk11.Enabled = True
                bk12test.Enabled = False
                bk12.Enabled = False
                bk2test.Enabled = True

            Case 1    'K2
                bk2.Enabled = True
                bk11.Enabled = True
                bk12test.Enabled = False
                bk12.Enabled = False
                bk2test.Enabled = False
            Case 2   'k11
                bk2.Enabled = True
                bk11.Enabled = True
                bk12test.Enabled = False
                bk12.Enabled = False
                bk2test.Enabled = False
            Case 3  'k12 test
                bk2.Enabled = False
                bk11.Enabled = False
                bk12test.Enabled = True
                bk12.Enabled = True
            Case 4  'k12
                bk2.Enabled = False
                bk11.Enabled = False
                bk12test.Enabled = True
                bk12.Enabled = True
                'Case 5  'k2	 teated
                '    bk2.Enabled = False
                '    bk11.Enabled = False
                '    bk12test.Enabled = False
                '    bk12.Enabled = False
                '    btk2.Enabled = True
                '    bk2test.Enabled = False
            Case 5 To 9 'style settingud
                'grStyle.Visible = True
                'grBug.Enabled = False
                stylemode = True
            Case Else
                'grBug.Enabled = False
                grCntrl.Enabled = False
                LstProgr.Enabled = False
                cDates.Items.Clear()
                Return
        End Select

        If ActiveChannel.HD Then
            chk169only.Text = "interlaced"
        Else
            chk169only.Text = "ainult 16:9"
        End If

        cVias.Visible = Not stylemode

        Tab1.TabPages.Clear()

        If stylemode Then
            Tab1.TabPages.Add(TabPage2)

            Plan = New ChannelPlan(ActiveChannel)
            Plan.RootList(cStyleId)
        Else
            Tab1.TabPages.Add(TabPage1)
            Tab1.TabPages.Add(TabPage3)
            Tab1.SelectedTab = Tab1.TabPages(0)

            ActiveChannel.ReportList(cReport)
            ActiveChannel.ViaList(cVias)

            If ActiveChannel.defVideoStyle = "right" Then
                rRight.Checked = True
            Else
                rLeft.Checked = True
            End If

            rEtc.Checked = True

            With Dialog1.cVias
                .Items.Clear()
                For Each item In cVias.Items
                    .Items.Add(item)
                Next
            End With

            dRepFrom.Value = Today.AddMonths(-2)
            dRepTo.Value = Today

            Plan = New ChannelPlan(ActiveChannel)
        End If

        'chkSide.Checked = If(ActiveChannel.defVideoStyle = "right", True, False)



        'grCntrl.Visible = not grStyle.Visible

        'LstProgr.Enabled = grBug.Enabled OrElse grStyle.Visible
        'grCntrl.Enabled = grBug.Enabled

        'If grCntrl.Visible Then
        '    ActiveChannel.ReportList(cReport)
        '    ActiveChannel.ViaList(cVias)

        '    With Dialog1.cVias
        '        .Items.Clear()
        '        For Each item In cVias.Items
        '            .Items.Add(item)
        '        Next
        '    End With

        '    dRepFrom.Value = Today.AddMonths(-2)
        '    dRepTo.Value = Today

        '    Plan = New ChannelPlan(ActiveChannel)
        'Else
        '    Plan = New ChannelPlan(ActiveChannel)

        '    Plan.RootList(cStyleId)
        'End If

        Guide = New ChannelGuide(cDates)
        cDates.SelectedIndex = Guide.TodayIndex
    End Sub

    Private Sub SetTitle()
        Me.Text = cMode.Text
        If cMode.SelectedIndex < cMode.Items.Count Then
            Try
                Me.Text += " "c + cDates.Text 'Date.Parse(cDates.Text).ToString(" dddd, dd. MMM")
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub bPlay_Click(sender As Object, e As EventArgs)
        'Dim id As String = cVias.SelectedItem.ToString
        'Dim fn As String = ActiveChannel.dirVia + id
        'If Chk169.Checked Then fn += "_w"
        'fn += ".via"

        'If Not File.Exists(fn) Then Return

        'bPlay.Enabled = False

        'Dim cntx As RtxLib.RTXContext = rtx1.NewContext

        'Dim fb As New RtxLib.FrameBuffer
        'fb.Setup(cntx)

        'Dim anim As New RtxLib.Animation
        'anim.FrameBuffer = fb
        'anim.AddFile(fn)
        'anim.Setup(cntx)
        'anim.Take()

        ''ChannelControl(id)
        'anim.Wait()

        'bPlay.Enabled = True
    End Sub

    Private Sub cmdExmpl_Click(sender As Object, e As EventArgs) Handles bExmpl.Click, bExmplMaker.Click
        Dim b As Button = CType(sender, Button)

        Dim id As String = cVias.SelectedItem.ToString
        Dim fn As String = VideoSequence.DirRes + "example\" + id + ".mp4"
        If Not File.Exists(fn) Then Return

        b.Enabled = False
        Dim Proc As Diagnostics.Process = Diagnostics.Process.Start(fn)
        Proc.WaitForExit()
        Proc.Dispose()

        ' Dim fnList As New System.Collections.Specialized.StringCollection
        'fnList.Add(fn)
        'Clipboard.SetFileDropList(fnList)

        'Try
        '    Clipboard.SetText(fn)
        'Catch ex As Exception

        'End Try


        b.Enabled = True
    End Sub

    Private Sub cVias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cVias.SelectedIndexChanged
        bk2.ForeColor = SystemColors.ControlText
        bk11.ForeColor = SystemColors.ControlText
        bk12.ForeColor = SystemColors.ControlText
        bPlay.Enabled = cVias.Text.Length > 0 AndAlso Not cVias.Text.StartsWith("["c)
        bExmpl.Enabled = bPlay.Enabled

        bk2.ForeColor = SystemColors.ControlText
        bk11.ForeColor = SystemColors.ControlText
        bk12.ForeColor = SystemColors.ControlText

        Dim stat As Statistics

        If cVias.Text.Length > 0 Then
            Dim t As String = cVias.Text
            ChannelControl(t)
            ' MessageBox.Show(ActiveChannel.bugStat(t).ToString)
            stat = New Statistics(t, ActiveChannel.bugStat(t))
            bSelVia.Text = t + " reeglid"
            bSelVia.Enabled = True
            lInf.Text = Plan.RuleInfo(cVias.Text)
        Else
            bSelVia.Text = "Valitud bugi reeglid"
            bSelVia.Enabled = False
            If cReport.Items.Count > 0 Then
                stat = New Statistics(ActiveChannel.combStat(cReport.Items(0).ToString, dRepFrom.Value, dRepTo.Value))
            Else
                stat = New Statistics("pole valitud!", <reports/>)
            End If
            lInf.Text = String.Empty
        End If

        wbr.DocumentText = stat.page
    End Sub

    Private Sub bMakeVia_Click(sender As Object, e As EventArgs) Handles bMakeVia.Click
        Dim dirFrames As String = tDir.Text

        If Not Directory.Exists(dirFrames) Then Return
        bMakeVia.Enabled = False

        If ActiveChannel.HD Then
            If rBug.Checked Then
                MakeHDMov(dirFrames)
            ElseIf rSk.Checked Then
                Dim hdSk As New VideoSequenceHD(dirFrames, False)
                If dirFrames.Contains("matte") Then
                    hdSk.Proccess("matte")
                Else
                    hdSk.Proccess(String.Empty)
                End If

            ElseIf rK2.Checked Then
                IdentFiles_K2_15(dirFrames)
            ElseIf rK11.Checked Then
                IdentFiles_K11_15(dirFrames)
            Else
                MakeLogoHD(dirFrames)
            End If
        Else
            If rBug.Checked Then
                MakeVia(dirFrames)
            ElseIf rSk.Checked Then
                Dim vSk As New SKsequence(dirFrames)
                vSk.Process()
            Else
                MakeLogo(dirFrames)
            End If
        End If



        'If ActiveChannel.HD Then
        '    MakeHDMov(dirFrames)
        'Else
        '    MakeVia(dirFrames)
        'End If

        bMakeVia.Enabled = True
    End Sub

    Private Sub MakeVia(dirFrames As String)
        Dim style As String '= If(chkSide.Checked, "right", "left")
        'chkSide.Checked = If(ActiveChannel.defVideoStyle = "right", True, False)
        'Try
        If rLeft.Checked Then
            style = "left"
            If ActiveChannel.defVideoStyle = "right" Then rRight.Checked = True
        ElseIf rRight.Checked Then
            style = "right"
            If Not ActiveChannel.defVideoStyle = "right" Then rLeft.Checked = True
        Else
            style = "center"
            If ActiveChannel.defVideoStyle = "right" Then rRight.Checked = True Else rLeft.Checked = True
        End If

        VideoSequence.FnBack = If(style = "right", VideoSequence.DirRes + "back_r.png", VideoSequence.DirRes + "back.png")

        Dim video As New VideoSequence(dirFrames, chkExample.Checked, chkVia.Checked, False)

        If chk169only.Checked Then
            video.Only169 = True    '169 via ainult ilma _w nimes
            chk169only.Checked = False
        End If

        If video.Width > 0 Then
            If cPos.Checked OrElse video.Height < 576 Then    'häälestatav suurus ja positsioon
                DialogResize.Init(video.Width, video.Height, cXy.Checked)
                If DialogResize.ShowDialog = Windows.Forms.DialogResult.OK Then
                    video.Proccess(DialogResize.Command(style)) '"draw_x_y_w_h_style"
                End If
                cXy.Checked = False
            Else
                Select Case video.Width
                    'Case 0 'pole faile, lahkuda
                    Case Is > 720    'ilmselgelt 16:9
                        video.Proccess("1024_" + style)
                    Case Else '720-eeldatavasti 4:3
                        If chkWide.Checked Then 'aga võimalik ka et 16:9, määrata eelnevalt
                            video.Proccess("720_169_" + style)
                        Else
                            video.Proccess("720_43_" + style)
                        End If
                End Select
            End If

            With cVias.Items
                If .Contains(video.Name) Then .Remove(video.Name)
                .Add(video.Name)
                ActiveChannel.BugDur(video.Name) = video.Duration
                cVias.SelectedIndex = .Count - 1
            End With
        End If

        video.Cleanup()
    End Sub

    Private Sub MakeLogo(dirFrames As String)
        Dim video As VideoSequence
        Dim mode As Integer

        If dirFrames.ToLower.Contains("kanal11") Then
            If dirFrames.ToLower.Contains("mask") Then
                mode = 110
            Else
                mode = 111
            End If
        ElseIf dirFrames.ToLower.Contains("kanal12") Then
            mode = 1
        Else '"kanal2"
            mode = 2
            'IdentFiles_K2_1415(dir)
            dirFrames += "\all"
        End If


        'Select Case b.Name
        '    Case "bLogoK12"

        '    Case Else

        '        mode = 0
        '        'IdentFiles_K2_1415(dir)
        '        dir += "\all"
        'End Select

        If dirFrames.EndsWith("all") Then

            For Each d As DirectoryInfo In New DirectoryInfo(dirFrames).GetDirectories
                video = New VideoSequence(d.FullName, False, True, False)
                video.Proccess(mode)
            Next

            Return

        End If
        If Not Directory.Exists(dirFrames) Then Return

        video = New VideoSequence(dirFrames, False, True, False)
        video.Proccess(mode)
    End Sub

    Private Sub MakeHDMov(dirFrames As String)
        Dim style As String

        If rLeft.Checked Then
            style = "left"
            If ActiveChannel.defVideoStyle = "right" Then rRight.Checked = True
        ElseIf rRight.Checked Then
            style = "right"
            If Not ActiveChannel.defVideoStyle = "right" Then rLeft.Checked = True
        Else
            style = "center"
            If ActiveChannel.defVideoStyle = "right" Then rRight.Checked = True Else rLeft.Checked = True
        End If

        VideoSequenceHD.FnBack = If(style = "right", VideoSequenceHD.DirRes + "back_r.png", VideoSequenceHD.DirRes + "back.png")

        Dim mode As VideoSequenceHD.RenderMode = If(chkVia.Checked, VideoSequenceHD.RenderMode.Bug, VideoSequenceHD.RenderMode.None)
        Dim video As New VideoSequenceHD(dirFrames, chkExample.Checked, mode, chk169only.Checked) 'chk169only = interlaced

        If video.Width > 0 Then
            If cPos.Checked OrElse video.Height < 576 Then    'häälestatav suurus ja positsioon
                DialogResizeHD.Init(video.Width, video.Height, cXy.Checked)
                If DialogResizeHD.ShowDialog = Windows.Forms.DialogResult.OK Then
                    video.Proccess(DialogResizeHD.Command(style)) '"draw_x_y_w_h_style"
                End If
                cXy.Checked = False
            Else
                video.Proccess("full")
            End If

            With cVias.Items
                If .Contains(video.Name) Then .Remove(video.Name)
                .Add(video.Name)
                ActiveChannel.BugDur(video.Name) = video.Duration
                cVias.SelectedIndex = .Count - 1
            End With
        End If

        video.Cleanup()
    End Sub

    Private Sub MakeLogoHD(dirFrames As String)
        Dim videoHD As VideoSequenceHD

        Dim fn As String = dirFrames + "\maskdiff.png"
        Dim matteMode As String = String.Empty

        If Not File.Exists(fn) Then fn = New DirectoryInfo(dirFrames).Parent.FullName + "\maskdiff.png"
        If File.Exists(fn) Then
            matteMode = "mask"
            FrameProcessorHD_Mask.SetMask(fn)
        End If
        Dim mode As String

        If dirFrames.EndsWith("all") Then
            For Each d As DirectoryInfo In New DirectoryInfo(dirFrames).GetDirectories
                videoHD = New VideoSequenceHD(d.FullName, False, VideoSequenceHD.RenderMode.logo, chk169only.Checked) 'chk169only = interlaced
                mode = If(d.Name.Contains("matte"), matteMode, String.Empty)
                videoHD.Proccess(mode)
            Next
            Return
        End If

        videoHD = New VideoSequenceHD(dirFrames, False, VideoSequenceHD.RenderMode.logo, chk169only.Checked) 'chk169only = interlaced
        mode = If(dirFrames.Contains("matte"), matteMode, String.Empty)
        videoHD.Proccess(mode)
    End Sub


    'Private Sub bSk_Click(sender As Object, e As EventArgs) Handles bSk.Click
    '    Dim dir As String = tDir.Text

    '    If Not Directory.Exists(dir) Then Return

    '    bSk.Enabled = False

    '    If ActiveChannel.HD Then
    '        Dim hdSk As New VideoSequenceHD(dir, False)
    '        hdSk.Proccess(String.Empty)
    '    Else
    '        Dim vSk As New SKsequence(dir)
    '        vSk.Process()
    '    End If

    '    bSk.Enabled = True
    'End Sub

    'Private Sub bLabel_Click(sender As Object, e As EventArgs) Handles bLabel.Click
    '    Dim dir As String = tDir.Text
    '    If Not Directory.Exists(dir) Then Return

    '    bLabel.Enabled = False
    '    Dim ls As New LabelSequence(dir)
    '    ls.Proccess()

    '    bLabel.Enabled = True
    'End Sub

    'Private Sub bLogoK2_Click(sender As Object, e As EventArgs) Handles bLogoK2.Click

    '    Dim dir As String = tDir.Text
    '    If Not Directory.Exists(dir) Then Return
    '    Dim mode As Integer
    '    Dim b As Button = CType(sender, Button)

    '    If ActiveChannel.HD Then
    '        Dim videoHD As VideoSequenceHD
    '        If dir.EndsWith("all") Then
    '            b.Enabled = False

    '            For Each d As DirectoryInfo In New DirectoryInfo(dir).GetDirectories
    '                videoHD = New VideoSequenceHD(d.FullName, False, VideoSequenceHD.RenderMode.multi, chk169only.Checked) 'chk169only = interlaced
    '                videoHD.Proccess(String.Empty)
    '            Next
    '            b.Enabled = True
    '            Return
    '        End If

    '        b.Enabled = False
    '        videoHD = New VideoSequenceHD(dir, False, VideoSequenceHD.RenderMode.logo, chk169only.Checked) 'chk169only = interlaced
    '        videoHD.Proccess(String.Empty)
    '        b.Enabled = True
    '    Else
    '        Dim video As VideoSequence
    '        If dir.ToLower.Contains("kanal11") Then
    '            If dir.ToLower.Contains("mask") Then
    '                mode = 110
    '            Else
    '                mode = 111
    '            End If
    '        ElseIf dir.ToLower.Contains("kanal12") Then
    '            mode = 1
    '        Else '"kanal2"
    '            mode = 2
    '            'IdentFiles_K2_1415(dir)
    '            dir += "\all"
    '        End If


    '        'Select Case b.Name
    '        '    Case "bLogoK12"

    '        '    Case Else

    '        '        mode = 0
    '        '        'IdentFiles_K2_1415(dir)
    '        '        dir += "\all"
    '        'End Select

    '        If dir.EndsWith("all") Then
    '            b.Enabled = False

    '            For Each d As DirectoryInfo In New DirectoryInfo(dir).GetDirectories
    '                video = New VideoSequence(d.FullName, False, True, False)
    '                video.Proccess(mode)
    '            Next
    '            b.Enabled = True
    '            Return

    '        End If
    '        If Not Directory.Exists(dir) Then Return

    '        b.Enabled = False

    '        video = New VideoSequence(dir, False, True, False)
    '        video.Proccess(mode)
    '        b.Enabled = True
    '    End If
    'End Sub


    'Private Sub bLogoHD_Click(sender As Object, e As EventArgs) Handles bLogoHD.Click
    '    Dim dir As String = tDir.Text
    '    If Not Directory.Exists(dir) Then Return
    '    Dim b As Button = CType(sender, Button)
    '    b.Enabled = False

    '    Dim video = New VideoSequence(dir, False, False, True)

    '    Dim mode As Integer = 1000
    '    video.Proccess(mode)

    '    b.Enabled = True
    'End Sub

    Private Sub IdentFiles_K2_15(dir As String)
        Dim di As New DirectoryInfo(dir)

        Dim tmpl As String = "\"c + New DirectoryInfo(dir).GetFiles.First.Name
        Dim dir1 As String
        Dim fn As String = String.Empty
        Dim j As Integer

        dir += "\all"
        If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

        'If di.Name = "matte" Then   'mattel polnud kõiki kaadreid
        '    For i As Integer = 1 To 376
        '        fn = di.FullName + NumFileName(tmpl, i)
        '        If Not File.Exists(fn) Then File.Copy(di.FullName + tmpl, fn)
        '    Next
        '    tmpl = "\frame00000.png"
        '    fn = di.FullName + tmpl
        '    If Not File.Exists(fn) Then 'nihutada maski seq ettepoole 1 kaadri võrra!
        '        Dim fn1 As String
        '        For i As Integer = 1 To 376
        '            fn1 = di.FullName + NumFileName(tmpl, i)
        '            If File.Exists(fn1) Then File.Move(fn1, fn)
        '            fn = fn1
        '        Next
        '    End If
        'End If

        If di.Name = "orange" Then   'logod
            dir1 = dir + "\2-15-logo1-on"
            If Not Directory.Exists(dir1) Then
                Directory.CreateDirectory(dir1)
                j = 0
                For i As Integer = 0 To 74
                    File.Copy(di.FullName + NumFileName(tmpl, i), dir1 + NumFileName(tmpl, j))
                    j += 1
                Next
            End If

            dir1 = dir + "\2-15-logo1-off"
            If Not Directory.Exists(dir1) Then
                Directory.CreateDirectory(dir1)
                j = 0
                For i As Integer = 327 To 376
                    File.Copy(di.FullName + NumFileName(tmpl, i), dir1 + NumFileName(tmpl, j))
                    j += 1
                Next
            End If
        End If

        dir1 = dir + "\2-15-" + di.Name + "-short"
        If Not Directory.Exists(dir1) Then
            Directory.CreateDirectory(dir1)
            j = 0
            For i As Integer = 80 To 318
                File.Copy(di.FullName + NumFileName(tmpl, i), dir1 + NumFileName(tmpl, j))
                j += 1
            Next
        End If

        dir1 = dir + "\2-15-" + di.Name + "-long"
        If Not Directory.Exists(dir1) Then
            Directory.CreateDirectory(dir1)
            j = 0
            For i As Integer = 80 To 200
                fn = NumFileName(tmpl, i)
                File.Copy(di.FullName + fn, dir1 + NumFileName(tmpl, j))
                j += 1
            Next

            For i As Integer = 0 To 124
                File.Copy(di.FullName + fn, dir1 + NumFileName(tmpl, j))
                j += 1
            Next

            For i As Integer = 201 To 318
                fn = NumFileName(tmpl, i)
                File.Copy(di.FullName + fn, dir1 + NumFileName(tmpl, j))
                j += 1
            Next
        End If

        dir1 = dir + "\2-15-" + di.Name + "-on"
        If Not Directory.Exists(dir1) Then
            Directory.CreateDirectory(dir1)
            j = 0
            For i As Integer = 80 To 183
                File.Copy(di.FullName + NumFileName(tmpl, i), dir1 + NumFileName(tmpl, j))
                j += 1
            Next
        End If

        dir1 = dir + "\2-15-" + di.Name + "-off"
        If Not Directory.Exists(dir1) Then
            Directory.CreateDirectory(dir1)
            j = 0
            For i As Integer = 249 To 318
                File.Copy(di.FullName + NumFileName(tmpl, i), dir1 + NumFileName(tmpl, j))
                j += 1
            Next
        End If
        MakeLogoHD(dir)
    End Sub

    Private Sub IdentFiles_K11_15(dir As String)
        MakeLogoHD(dir)
    End Sub

    Private Function NumFileName(tmpl As String, nr As Integer) As String
        Return tmpl.Replace("00000", String.Format("{0:00000}", nr))
    End Function

    Private Sub ChannelControl(id As String)
        For Each b As Button In channels.Keys

            b.ForeColor = SystemColors.ControlText
            If b.Enabled AndAlso Not id.StartsWith("["c) Then
                Dim update As Integer = 0

                Dim exts As New List(Of String)
                exts.Add(ActiveChannel.Ext)
                If Not ActiveChannel.HD Then
                    exts.Add("_w.via")
                    exts.Add("_v.via")
                End If

                For Each ext As String In exts ' {".via", "_w.via", "_v.via"}
                    update += viaUpdate(ActiveChannel.dirResBug, channels(b).DirBug, id, ext)
                    Select Case update
                        Case 1
                            b.ForeColor = Color.DarkRed 'fail puudub
                            Return
                        Case Is > 1
                            b.ForeColor = Color.DarkOrange 'uuendatud
                            Return
                    End Select
                Next
                b.ForeColor = Color.Green
            End If
        Next
    End Sub

    Private Function ChannelBugUpdate(id As String) As Boolean
        If id.StartsWith("["c) Then Return False

        Dim update As Integer = 0

        Dim exts As New List(Of String)
        exts.Add(ActiveChannel.Ext)
        If Not ActiveChannel.HD Then
            exts.Add("_w.via")
            exts.Add("_v.via")
        End If

        For Each ext As String In exts ' {".via", "_w.via", "_v.via"}
            update += viaUpdate(ActiveChannel.dirResBug, ActiveChannel.DirBug, id, ext)
            If update > 0 Then Return True
        Next
        Return False
    End Function

    Private Function viaUpdate(dSrc As String, dDst As String, id As String, ext As String) As Integer
        Dim fSrc As New FileInfo(dSrc + id + ext)
        If Not fSrc.Exists Then Return 0 'pole mida kontrollida
        Dim fDst As New FileInfo(dDst + id + ext)
        If Not fDst.Exists Then Return 1 'fail sihtkohas puudu
        If fSrc.LastWriteTimeUtc > fDst.LastWriteTimeUtc Then Return 2 'fail uuem kui sihtkohas
        Return 0 'uuendusi pole
    End Function

    Private Sub bk_Click(sender As Object, e As EventArgs) Handles bk11.Click, bk11test.Click, bk12.Click, bk12test.Click, bk2.Click, bk2test.Click
        Dim bk As Button = CType(sender, Button)
        Dim dir As String = channels(bk).DirBug
        Try
            If ActiveChannel.MoveBug(cVias.SelectedItem.ToString) Then
                bk.ForeColor = Color.Green
                Return
            End If
        Catch ex As Exception

        End Try

        bk.ForeColor = Color.Red
    End Sub

    Private Sub cDates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cDates.SelectedIndexChanged
        Guide.Fill(cDates.Text.Split(" "c).Last, LstProgr)
        SetTitle()
        bSelDate.Text = cDates.Text + " reeglid"
        bSelDate2.Text = bSelDate.Text
    End Sub

    Private Sub LstProgr_DoubleClick(sender As Object, e As EventArgs) Handles LstProgr.DoubleClick
        If LstProgr.SelectedItems.Count = 0 Then Return
        Dim force As Boolean = My.Computer.Keyboard.ShiftKeyDown

        If ActiveChannel.Virtual Then
            If Not cStyleValue.Items.Contains(cStyleValue.Text) Then cStyleValue.Items.Add(cStyleValue.Text)
            If Not Dialog1.cVias.Items.Contains(cStyleValue.Text) Then Dialog1.cVias.Items.Add(cStyleValue.Text)
            Plan.Fill(cStyleValue, LstProgr, force)
        Else
            Plan.Fill(cVias, LstProgr, force)
            Control()
            lInf.Text = Plan.RuleInfo(cVias.Text)
        End If
    End Sub

    Private Sub addMultiBug_Click(sender As Object, e As EventArgs) Handles addMultiBug.Click
        If LstProgr.SelectedItems.Count = 0 Then Return
        If ActiveChannel.Virtual Then Return
        Dim force As Boolean = My.Computer.Keyboard.ShiftKeyDown

        Plan.Fill(cVias, LstProgr, force)
        Control()
        lInf.Text = Plan.RuleInfo(cVias.Text)
    End Sub

    Private Sub addMultiStyle_Click(sender As Object, e As EventArgs) Handles addMultiStyle.Click
        If LstProgr.SelectedItems.Count = 0 Then Return
        If Not ActiveChannel.Virtual Then Return

        Dim force As Boolean = My.Computer.Keyboard.ShiftKeyDown

        If Not cStyleValue.Items.Contains(cStyleValue.Text) Then cStyleValue.Items.Add(cStyleValue.Text)
        If Not Dialog1.cVias.Items.Contains(cStyleValue.Text) Then Dialog1.cVias.Items.Add(cStyleValue.Text)
        Plan.Fill(cStyleValue, LstProgr, force)
    End Sub

    'Private Sub MultiBug(force As Boolean)
    '    Plan.Fill(cVias, LstProgr, force)
    '    Control()
    '    lInf.Text = Plan.RuleInfo(cVias.Text)
    'End Sub

    'Private Sub MultiStyle(force As Boolean)
    '    If Not cStyleValue.Items.Contains(cStyleValue.Text) Then cStyleValue.Items.Add(cStyleValue.Text)
    '    If Not Dialog1.cVias.Items.Contains(cStyleValue.Text) Then Dialog1.cVias.Items.Add(cStyleValue.Text)
    '    Plan.Fill(cStyleValue, LstProgr, force)
    'End Sub

    Private Sub bAll_Click(sender As Object, e As EventArgs) Handles bAll.Click
        Plan.Fill()
        Control()
        lInf.Text = Plan.RuleInfo(cVias.Text)
    End Sub

    Private Sub bAll2_Click(sender As Object, e As EventArgs) Handles bAll2.Click
        Plan.Fill()
    End Sub

    Private Sub bSelStyle_Click(sender As Object, e As EventArgs) Handles bSelStyle.Click
        Plan.Fill(cStyleValue.Text)
    End Sub

    Private Sub bSelVia_Click(sender As Object, e As EventArgs) Handles bSelVia.Click
        Plan.Fill(cVias.Text)
        Control()
        lInf.Text = Plan.RuleInfo(cVias.Text)
    End Sub

    Private Sub bSelDate_Click(sender As Object, e As EventArgs) Handles bSelDate.Click
        Dim d As Date
        If Date.TryParse(cDates.Text.Split(" "c).Last, d) Then
            Plan.Fill(d.AddHours(12))
            Control()
            lInf.Text = Plan.RuleInfo(cVias.Text)
        End If
    End Sub

    Private Sub bSelDate2_Click(sender As Object, e As EventArgs) Handles bSelDate2.Click
        Dim d As Date
        If Date.TryParse(cDates.Text.Split(" "c).Last, d) Then
            Plan.Fill(d.AddHours(12))
        End If
    End Sub

    Private Sub bCopy_Click(sender As Object, e As EventArgs) Handles bCopy.Click

        Dim nl As String = System.Environment.NewLine

        Dim sb As New System.Text.StringBuilder(My.Resources.htmlClipboardHeader)
        sb.Append(System.Environment.NewLine)
        sb.Append(wbr.DocumentText)
        Dim cTxt As String = sb.ToString
        Dim nFrm As String = "D8"

        sb.Replace("<<<<<<<1", (cTxt.IndexOf("<HTML>") + "<HTML>".Length).ToString(nFrm))
        sb.Replace("<<<<<<<2", (cTxt.IndexOf("</HTML>")).ToString(nFrm))
        sb.Replace("<<<<<<<3", (cTxt.IndexOf("<!--StartFragment -->") + "<!--StartFragment -->".Length).ToString(nFrm))
        sb.Replace("<<<<<<<4", (cTxt.IndexOf("<!--EndFragment -->")).ToString(nFrm))

        Clipboard.SetText(sb.ToString, TextDataFormat.Html)
    End Sub

    Private Sub bReport_Click(sender As Object, e As EventArgs) Handles bReport.Click
        Dim stat As Statistics = New Statistics(ActiveChannel.combStat(cReport.Text, dRepFrom.Value, dRepTo.Value))
        wbr.DocumentText = stat.page
    End Sub

    Private Sub bDir_Click(sender As Object, e As EventArgs) Handles bDir.Click
        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then tDir.Text = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub cStyleId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cStyleId.SelectedIndexChanged
        If cStyleId.SelectedIndex < 0 Then Return

        Plan.SetRoot(cStyleId.Text, cStyleValue)
        Guide.Fill(cDates.Text.Split(" "c).Last, LstProgr) 'saatekava kontroll kategooria järgi
        bAll2.Text = cStyleId.Text + " reeglid"
        bStyleIdDel.Enabled = cStyleValue.Items.Count < 2

        ActiveChannel.ReportList(cReport)
    End Sub

    Private Sub cStyleValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cStyleValue.SelectedIndexChanged
        If cStyleValue.SelectedIndex < 0 Then Return
        Dim stat As Statistics

        With Dialog1.cVias
            .Items.Clear()
            For Each item In cStyleValue.Items
                .Items.Add(item)
            Next
        End With
        bSelStyle.Text = cStyleValue.Text + " reeglid"

        Dim t As String = cStyleValue.Text
        If String.IsNullOrWhiteSpace(t) Then
            If cReport.Items.Count > 0 Then
                stat = New Statistics(ActiveChannel.combStat(cReport.Items(0).ToString, dRepFrom.Value, dRepTo.Value))
            Else
                stat = New Statistics("pole valitud!", <reports/>)
            End If
        Else
            stat = New Statistics(t, ActiveChannel.bugStat(t))
        End If

        wbr.DocumentText = stat.page
    End Sub

    Private Sub bStyleIdAdd_Click(sender As Object, e As EventArgs) Handles bStyleIdAdd.Click
        With cStyleId
            If Not .Items.Contains(.Text) Then
                .Items.Add(.Text)
                .SelectedIndex = .Items.Count - 1
            End If
        End With

    End Sub

    Private Sub bStyleIdDel_Click(sender As Object, e As EventArgs) Handles bStyleIdDel.Click
        Plan.RemoveRoot(cStyleId)
    End Sub

    Private Sub bStyleValueAdd_Click(sender As Object, e As EventArgs) Handles bStyleValueAdd.Click
        With cStyleValue
            If Not .Items.Contains(.Text) Then
                .Items.Add(.Text)
                .SelectedIndex = .Items.Count - 1
                bStyleIdDel.Enabled = False
            End If
        End With
    End Sub

    Private Sub bRestore_Click(sender As Object, e As EventArgs) Handles bRestore.Click
        If DialogRestore.Init(ActiveChannel.dirResBug) Then
            If DialogRestore.ShowDialog = Windows.Forms.DialogResult.OK Then
                ActiveChannel.ViaList(cVias, DialogRestore.restored)
            End If
        End If
    End Sub

    Private Sub cPos_CheckedChanged(sender As Object, e As EventArgs) Handles cPos.CheckedChanged
        cXy.Visible = cPos.Checked
    End Sub

    Private Sub tDir_TextChanged(sender As Object, e As EventArgs) Handles tDir.TextChanged
        Dim t As String = tDir.Text.ToLower

        If t.Contains("\bug") Then
            rBug.Checked = True
        ElseIf tDir.Text.ToLower.Contains("\sk") Then
            rSk.Checked = True
        ElseIf tDir.Text.ToLower.Contains("\2ident") Then
            rK2.Checked = True
        ElseIf tDir.Text.ToLower.Contains("\11ident") Then
            rK11.Checked = True
        Else
            rEtc.Checked = True
        End If
    End Sub

    Private Sub rSk_CheckedChanged(sender As Object, e As EventArgs) Handles rSk.CheckedChanged

    End Sub
End Class
