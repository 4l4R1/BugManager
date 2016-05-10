Option Strict On
Option Explicit On

Imports System.IO
Imports TimeIntervalControl

Module channelClasses
    Friend ActiveChannel As ChannelSetup
    Friend Guide As ChannelGuide
    Friend Plan As ChannelPlan

    Friend Class ChannelSetup
        Friend Property dirResVid As String
        Friend Property dirResBug As String
        Friend Property GuideFn As String
        Friend Property PlanLocalFn As String
        Friend Property PlanFn As String
        Friend Property DirLocalBug As String
        Friend Property DirBug As String
        Friend Property HD As Boolean = False

        'Friend Property VideoStyle As String
        Friend Property defVideoStyle As String
        Friend Property Virtual As Boolean = False

        Friend Property BugDur As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        'Friend Sub New(xSetup As XElement)
        '	'ch = New ChannelSetup With {.dirVia = "E:\_home_\Saatekava1213\bugid\_res\via-2-t\",
        '	'.GuideFn = "\\192.168.73.22\eetrigraafika\kanal2\guide\kanal2.xml",
        '	'.PlanLocalFn = "E:\Eetrigraafika\Kanal2\bug\plan.xml",
        '	'.PlanFn = "\\192.168.73.22\eetrigraafika\kanal2\bug\plan.xml",
        '	'.DirLocalBug = "E:\Eetrigraafika\Kanal2\via\",
        '	'.DirBug = "\\192.168.73.22\eetrigraafika\kanal2\via\",
        '	'.VideoStyle = "all"}
        'End Sub

        Friend ReadOnly Property Ext As String
            Get
                Return If(HD, ".mov", ".via")
            End Get
        End Property

        Friend Function MoveBug(id As String) As Boolean
            If _Virtual Then Return True


            'If result AndAlso File.Exists(_dirVia + id + "_w.via") Then
            '	result = MoveFile(id + "_w.via")
            'End If
            Dim result As Boolean

            If HD Then
                result = MoveFile(id + Ext)
                Return result
            End If

            result = MoveFile(id + ".via")
            MoveFile(id + "_w.via")
            MoveFile(id + "_v.via")


            Return result
        End Function

        Private Function MoveFile(fn As String) As Boolean
            Dim fIn As New FileInfo(_dirResBug + fn)
            Dim fOut As New FileInfo(_DirBug + fn)

            If Not fIn.Exists Then Return False
            If fOut.Exists Then
                If fOut.LastWriteTimeUtc = fIn.LastWriteTimeUtc Then Return True 'olemas!
                Try
                    fOut.Delete()
                Catch ex As Exception
                    Return False
                End Try
            End If

            fIn.CopyTo(fOut.FullName)

            If Not String.IsNullOrWhiteSpace(DirLocalBug) Then  'kohalik fail samuti!
                fOut = New FileInfo(_DirLocalBug + fn)

                If Not fOut.Exists AndAlso fOut.LastWriteTimeUtc <> fIn.LastWriteTimeUtc Then
                    Try
                        fIn.CopyTo(fOut.FullName, True)
                    Catch ex As Exception

                    End Try
                End If
            End If

            Return True
        End Function

        Friend Function bugStat(id As String) As XElement
            Dim fn As String = String.Format("{0}reports\{1}.xml", DirBug, id)
            If File.Exists(fn) Then
                Try
                    Dim sdoc As XDocument = XDocument.Load(fn)
                    Return sdoc.Root
                Catch ex As Exception

                End Try
            End If
            Return <reports/>
        End Function

        Friend Function combStat(key As String, FromDay As Date, ToDay As Date) As XElement
            Dim elems As New SortedList(Of Date, XElement)
            Dim names As New List(Of String)

            Try
                For Each fi As FileInfo In New DirectoryInfo(DirBug + "reports").GetFiles
                    'If fi.Name.ToLower.StartsWith(key.ToLower) Then 'failidest, mille nimi algab määratuga 
                    If fi.Name.ToLower.Contains(key.ToLower) Then
                        Dim name As String = fi.Name.Replace(fi.Extension, String.Empty)
                        Dim sdoc As XDocument = XDocument.Load(fi.FullName)
                        For Each el As XElement In sdoc.Root.Elements("report") 'kõik <report> elemendid
                            Try
                                Dim d As Date = Date.Parse(el.@time) 'kui sama ajaga veel pole olnud
                                If d >= FromDay AndAlso d <= ToDay.AddHours(18) AndAlso Not elems.ContainsKey(d) Then
                                    elems(d) = el 'nimekirja ajalises järjekorras
                                    If Not names.Contains(name) Then names.Add(name) 'registreeri faili nimi, millest pärit
                                End If

                            Catch ex As Exception

                            End Try
                        Next
                    End If
                Next
            Catch ex As Exception

            End Try

            Dim repEl As XElement = <reports title=<%= String.Join(", ", names) %>/>
            For i As Integer = 0 To elems.Count - 1
                repEl.Add(elems.ElementAt(i).Value)
            Next

            'repEl.Add(elems.Values)
            Return repEl
        End Function

        Friend Sub ReportList(c As ComboBox)
            c.Items.Clear()

            Dim files As New Dictionary(Of String, FileInfo)
            Dim old As New List(Of FileInfo)
            Dim keys As New Dictionary(Of String, Integer)

            Try
                For Each fi As FileInfo In New DirectoryInfo(DirBug + "reports").GetFiles
                    files(fi.Name.Replace(fi.Extension, String.Empty)) = fi
                Next
            Catch ex As Exception

            End Try

            For i As Integer = 0 To -2 Step -1
                Dim key As String = Now.AddMonths(i).ToString("yyyy_MM")
                If files.ContainsKey(key) Then c.Items.Add(key)
            Next

            For Each kv As KeyValuePair(Of String, FileInfo) In files
                If (Now - kv.Value.LastWriteTimeUtc).TotalDays > 365 Then
                    old.Add(kv.Value)
                Else
                    If kv.Key.Contains("_"c) Then
                        Dim split() As String = kv.Key.Split("_"c)
                        For i As Integer = 1 To split.Count
                            Dim subkey As String = String.Join("_"c, split, 0, i)
                            addOne(keys, subkey)
                        Next
                    End If
                End If
            Next

            For Each kv As KeyValuePair(Of String, FileInfo) In files
                For Each kvs As KeyValuePair(Of String, FileInfo) In files
                    If kv.Key <> kvs.Key AndAlso kvs.Key.StartsWith(kv.Key) Then addOne(keys, kv.Key)
                Next
            Next

            For Each kv As KeyValuePair(Of String, Integer) In keys
                If kv.Value > 1 AndAlso Not c.Items.Contains(kv.Key) Then c.Items.Add(kv.Key)
            Next

            Try
                Dim dir As String = DirBug + "old_reports\"
                If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

                For Each fi As FileInfo In old
                    Dim fn As String = dir + fi.Name
                    If File.Exists(fn) Then File.Delete(fn)
                    fi.MoveTo(fn)
                Next
            Catch ex As Exception

            End Try

            If c.Items.Count > 0 Then c.SelectedIndex = 0
        End Sub

        Private Sub addOne(keys As Dictionary(Of String, Integer), key As String)
            Dim count As Integer = If(keys.ContainsKey(key), keys(key) + 1, 1)
            keys(key) = count
        End Sub

        Friend Sub ViaList(c As ComboBox)
            c.Items.Clear()
            If _Virtual Then Return
            c.Items.Add(String.Empty)

            Dim reserv As String = "[reserveeritud]"
            c.Items.Add(reserv)
            ActiveChannel.BugDur(reserv) = 0

            For Each f As FileInfo In New DirectoryInfo(_dirResBug).GetFiles
                If f.Extension.ToLower = ActiveChannel.Ext AndAlso Not f.Name.Contains("_w.") AndAlso Not f.Name.Contains("_v.") Then
                    Dim name As String = f.Name.Replace(f.Extension, String.Empty)
                    c.Items.Add(name)
                    'Dim mi As New Rtx.Media.MediaInfo(f.FullName)
                    'ActiveChannel.BugDur(name) = mi.Duration
                    'ActiveChannel.BugDur(name) = rtx1.GetMediaLength(f.FullName).Frames
                    _BugDur(name) = GetDuration(f.FullName)
                End If
            Next
            If c.Items.Count > 0 Then c.SelectedIndex = 0
        End Sub

        Friend Sub ViaList(c As ComboBox, name As String)
            If String.IsNullOrWhiteSpace(name) Then Return

            If c.Items.Contains(name) Then Return
            c.Items.Add(name)
            _BugDur(name) = GetDuration(_dirResBug + name + ".via")
            c.SelectedIndex = c.Items.Count - 1
        End Sub

        Private Function GetDuration(fn As String) As Integer
            Dim via As New ViaBuildLib.ViaFile
            With via
                .Filename = fn
                Dim d As Integer = .FrameCount
                Return d
            End With
        End Function
    End Class

    Friend Class ChannelGuide
        Private xGuide As XDocument
        Private _todayIndex As Integer = 0

        Friend Sub New(c As ComboBox)
            If File.Exists(ActiveChannel.GuideFn) Then
                xGuide = XDocument.Load(ActiveChannel.GuideFn)
            Else
                xGuide = <?xml version="1.0" encoding="UTF-8" standalone="yes"?><data/>
            End If

            c.Items.Clear()

            Dim content As New List(Of String)

            For Each pElem As XElement In xGuide.Root.Elements
                Dim d As String = pElem.<Kuupaev>.Last.Value
                If Not content.Contains(d) Then
                    content.Add(d)
                    Dim dd As Date
                    If Date.TryParse(d, dd) Then
                        d = dd.ToString("ddd, dd.MM.yyyy")
                        'If Not c.Items.Contains(d) Then
                        If _todayIndex = 0 AndAlso dd = Now.Date Then _todayIndex = c.Items.Count '1. tänase kuupäevaga
                        c.Items.Add(d)
                        'End If
                    End If
                End If
            Next
        End Sub

        Friend ReadOnly Property TodayIndex As Integer
            Get
                Return _todayIndex
            End Get
        End Property

        Friend Sub Fill(d As String, l As ListView)
            Dim xList As IEnumerable(Of XElement) = From el In xGuide.Root.Elements Where el.<Kuupaev>.Last.Value = d Select el

            l.Items.Clear()
            For Each xPr As XElement In xList
                l.Items.Add(New GuideItem(xPr).toListViewItem)
            Next
        End Sub

        Friend Sub Fill(tFind As String, lFind As ListBox)
            lFind.Items.Clear()
            If tFind.Length < 2 Then Return

            Dim key As String = tFind.ToLower.Trim
            Dim xList As IEnumerable(Of XElement) = From el In xGuide.Root.Elements Where el.<Saade>.Last.Value.StartsWith(key, True, System.Globalization.CultureInfo.CurrentCulture) Order By el.<Production_nr>.Last.Value Select el ' Distinct

            For Each xEntry As XElement In xList
                Dim item As String = xEntry.<Production_nr>.Last.Value + " = " + xEntry.<Saade>.Last.Value
                If Not lFind.Items.Contains(item) Then lFind.Items.Add(item)
            Next

            If lFind.Items.Count > 1 Then Return

            Dim seq() As Char = tFind.ToLower.ToCharArray
            xList = From el In xGuide.Root.Elements Where ContainsSequense(el.<Saade>.Last.Value.ToLower, seq) Order By el.<Saade>.Last.Value, el.<Production_nr>.Last.Value Select el

            For Each xEntry As XElement In xList
                Dim item As String = xEntry.<Production_nr>.Last.Value + " = " + xEntry.<Saade>.Last.Value
                If Not lFind.Items.Contains(item) Then lFind.Items.Add(item)
            Next

            If lFind.Items.Count > 1 Then Return

            xList = From el In xGuide.Root.Elements Where ContainsSequense(el.<Saade>.Last.Value.ToLower, seq, 1) Order By el.<Saade>.Last.Value, el.<Production_nr>.Last.Value Select el

            For Each xEntry As XElement In xList
                Dim item As String = xEntry.<Production_nr>.Last.Value + " = " + xEntry.<Saade>.Last.Value
                If Not lFind.Items.Contains(item) Then lFind.Items.Add(item)
            Next
        End Sub

        Private Function ContainsSequense(S As String, seq() As Char) As Boolean
            Dim i As Integer
            For Each c As Char In seq
                i = S.IndexOf(c, i) + 1
                If i = 0 Then Return False
            Next
            Return True
        End Function

        Private Function ContainsSequense(S As String, seq() As Char, lives As Integer) As Boolean
            Dim i As Integer
            For Each c As Char In seq
                Dim index As Integer = S.IndexOf(c, i) + 1
                If index = 0 Then 'Return False
                    If lives < 1 Then Return False
                    lives -= 1
                Else
                    i = index
                End If
            Next
            Return True
        End Function

        Friend Function Find(id As String) As String
            Dim xList As IEnumerable(Of XElement) = From el In xGuide.Root.Elements Where el.<Production_nr>.Last.Value.ToLower.StartsWith(id) Select el

            Return If(xList.Count = 0, String.Empty, xList.<Saade>.Last.Value)
        End Function
    End Class

    Friend Class GuideItem
        Private _id As String = String.Empty
        Private _title As String = String.Empty
        Private _Date_Time As Date = Date.MinValue
        Private _timeStr As String = String.Empty
        Private _dateStr As String = String.Empty

        Friend Sub New(xItem As XElement)
            Try
                _timeStr = xItem.Element("Kell").Value
            Catch ex As Exception
            End Try

            Try
                _dateStr = xItem.Element("Kuupaev").Value
            Catch ex As Exception
            End Try

            Try
                _id = xItem.Element("Production_nr").Value
            Catch ex As Exception
            End Try

            Try
                _title = xItem.Element("Saade").Value
            Catch ex As Exception
            End Try

            _Date_Time = GetDate(_dateStr, _timeStr)
        End Sub

        Private Function GetDate(dStr As String, tStr As String) As Date
            Dim d As Date = Date.MinValue
            If Date.TryParse(dStr, d) AndAlso tStr.Contains(":"c) Then
                Dim h_m() As String = tStr.Split(":"c)
                d = d.AddHours(Val(h_m(0))).AddMinutes(Val(h_m(1)) + 5)
            End If

            Return d
        End Function

        Friend ReadOnly Property ID As String
            Get
                Return _id
            End Get
        End Property

        Friend ReadOnly Property Title As String
            Get
                Return _title
            End Get
        End Property

        Friend ReadOnly Property Date_Time As Date
            Get
                Return _Date_Time
            End Get
        End Property

        Friend Function toListViewItem() As ListViewItem
            Dim li As New ListViewItem

            li.Tag = Me
            li.Text = _timeStr
            li.SubItems.Add(_id)
            li.SubItems.Add(_title)
            If (Now - _Date_Time).TotalMinutes > 0 Then li.ForeColor = Color.DarkBlue

            Plan.Check(li)

            Return li
        End Function

        Friend Function ToXml() As XElement
            Return <pr id=<%= _id %> title=<%= _title %> date=<%= _dateStr %> time=<%= _timeStr %>/>
        End Function
    End Class

    Friend Class PlanRule
        Friend Property Source As XElement
        Friend Property Changed As Boolean

        Private Condition As ConditionControl
        Private _Value As String
        Private slots As List(Of Integer)

        Friend Sub New(xRule As XElement)
            _Source = xRule
            Init()
        End Sub

        Friend Sub Init()
            Condition = ConditionControl.Create(_Source)
            _Value = _Source.@file

            slots = New List(Of Integer)
            slots.Add(-1) 'selle sloti väärtusega annab alati value värrtuse
            Dim slot As String = _Source.@slot
            If String.IsNullOrWhiteSpace(slot) Then Return

            Dim slotIds() As String = slot.Split(","c)
            For Each slotId As String In slotIds
                Dim slotValue As Integer
                If Integer.TryParse(slotId, slotValue) Then
                    If Not slots.Contains(slotValue) Then slots.Add(slotValue)
                End If
            Next

        End Sub

        Friend ReadOnly Property Value() As String
            Get
                Return _Value
            End Get
        End Property

        Friend ReadOnly Property Value(slot As Integer) As String
            Get
                If Condition.Enabled AndAlso slots.Contains(slot) Then
                    Return _Value
                Else
                    Return String.Empty
                End If
            End Get
        End Property

        Friend ReadOnly Property Activated As Boolean
            Get
                'Return (slots.Count > 1) AndAlso _Value.Length > 0
                Return _Value.Length > 0
            End Get
        End Property

        Friend Shared Function DateString(dFrom As Date, dTo As Date) As String
            Select Case dFrom.Hour
                Case 0 To 5
                    dFrom = dFrom.AddDays(-1)
            End Select

            Select Case dTo.Hour
                Case 0 To 5
                    dTo = dTo.AddDays(-1)
            End Select

            Return String.Format("{0:dd.MM.yyyy}-{1:dd.MM.yyyy}", dFrom, dTo)
        End Function

        Friend Shared Function TimeString(dMin As Date, dMax As Date) As String
            Dim h As Integer = dMin.Hour
            Dim hMin, hMax As Integer

            Select Case h
                Case 6 : hMin = 6
                Case 0 : hMin = 23
                Case Else : hMin = h - 1 '7 To 23, 1 To 5
            End Select

            h = dMax.Hour
            Select Case h
                Case 23 : hMax = 0
                Case 5 : hMax = 5
                Case Else : hMax = h + 1 '6 To 22, 0 To 4
            End Select

            Return String.Format("{0:00}-{1:00}", hMin, hMax)
        End Function
    End Class

    Friend Class PlanRuleEditor
        Private _Rule As PlanRule
        Private _Changes As New Dictionary(Of String, String)
        Private _Register As Boolean

        Friend Sub New(r As PlanRule, reg As Boolean)
            _Rule = r
            _Register = reg
        End Sub

        Friend ReadOnly Property Rule As PlanRule
            Get
                Return _Rule
            End Get
        End Property

        Friend ReadOnly Property Register As Boolean
            Get
                Return _Register AndAlso _Rule.Activated
            End Get
        End Property

        Friend ReadOnly Property Changes As Dictionary(Of String, String)
            Get
                Return _Changes
            End Get
        End Property

        Friend Sub Sync()
            For Each k_v As KeyValuePair(Of String, String) In _Changes
                Rule.Source.SetAttributeValue(k_v.Key, k_v.Value)
            Next

            _Changes.Clear()
            _Rule.Init()

            _Rule.Source.SetAttributeValue("modified", Now)
        End Sub

        Public Overrides Function ToString() As String
            'Return MyBase.ToString()
            Dim d As Date = Date.Parse(_Rule.Source.@created)

            Return String.Format("{0} ({1}-{2:yyMMdd-HHmmss)}", _Rule.Source.@file, _Rule.Source.@title, d)
        End Function
    End Class

End Module
