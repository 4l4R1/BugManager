Option Strict On
Option Explicit On

Imports System.IO
Imports TimeIntervalControl

'<rule pr="12/100/00948/0065" date="03.09.2012-03.09.2012" time="20-22"	slot="" priority="" file=""/>
Friend Class ChannelPlan
    Private xPlan As XDocument
    Private Rules As New List(Of PlanRule)
    Private PriorityOrder As New List(Of String)
    Private ThisChannel As ChannelSetup
    Private CurrentRoot As XElement

    Private SaveFlag As Boolean
    Private SaveTrigger As System.Timers.Timer

    Friend Sub New(ch As ChannelSetup)
        ThisChannel = ch

        Dim src As Integer = 0
        Dim flocal As New FileInfo(ThisChannel.PlanLocalFn)
        If flocal.Exists Then
            src = 1
        Else
            Try
                If Not flocal.Directory.Exists Then flocal.Directory.Create()
            Catch ex As Exception

            End Try
        End If

        Dim dDst As New FileInfo(ThisChannel.PlanFn)
        If dDst.Exists AndAlso dDst.LastWriteTimeUtc > flocal.LastWriteTimeUtc Then src = 2

        Select Case src
            Case 1 'local file
                xPlan = XDocument.Load(ThisChannel.PlanLocalFn)
            Case 2 'onair plan (on uuem)
                xPlan = XDocument.Load(ThisChannel.PlanFn)
            Case Else 'no file
                xPlan = <?xml version="1.0" encoding="UTF-8" standalone="yes"?><rules/>
        End Select

        SaveTrigger = New System.Timers.Timer(30000)
        With SaveTrigger
            .SynchronizingObject = Form1
            .Enabled = False
            .AutoReset = False
            AddHandler .Elapsed, AddressOf triggerFired
        End With

        If ThisChannel.Virtual Then
            CurrentRoot = If(xPlan.Root.Elements.Any, xPlan.Elements.First, xPlan.Root)
            Return
        End If

        CurrentRoot = xPlan.Root
        GetRules()

    End Sub


    Private Sub triggerFired(sender As Object, e As System.Timers.ElapsedEventArgs)
        SavePlan()
    End Sub
    Private Sub SavePlan()
        Dim flocal As New FileInfo(ThisChannel.PlanLocalFn)
        'If Not flocal.Exists Then Return

        'Dim dDst As New FileInfo(ThisChannel.PlanFn)
        'If dDst.Exists AndAlso dDst.LastWriteTimeUtc >= flocal.LastWriteTimeUtc Then Return 'plan on uuem või sama vana - pole vaja salvestada
        'Try

        ''flocal.CopyTo(ThisChannel.PlanFn, True)

        Dim tmpFn As String = ThisChannel.PlanFn.Replace(".", "_.")
        flocal.CopyTo(tmpFn, True)  'kopeerib ajutise nime all
        If File.Exists(ThisChannel.PlanFn) Then File.Delete(ThisChannel.PlanFn)
        File.Move(tmpFn, ThisChannel.PlanFn)    'failile õige nimi
        SaveFlag = False

        'Catch ex As Exception
        'End Try
    End Sub

    Friend Sub SetRoot(id As String, c As ComboBox)
        If xPlan.Root.Element(id) Is Nothing Then 'uue kategooria loomine
            Dim nElem As XElement = New XElement(id)
            nElem.SetAttributeValue("next", "1"c)
            xPlan.Root.Add(nElem)
        End If

        CurrentRoot = xPlan.Root.Elements(id).First

        Rules.Clear()
        PriorityOrder.Clear()
        GetRules()

        Dim values As New HashSet(Of String)
        For Each r As PlanRule In Rules
            values.Add(r.Value)
        Next

        c.Items.Clear()
        c.Items.Add(String.Empty)
        For Each v As String In values
            c.Items.Add(v)
        Next

        c.SelectedIndex = 0
    End Sub

    Friend Sub RemoveRoot(c As ComboBox)
        Dim id As String = c.Text
        If String.IsNullOrWhiteSpace(id) Then Return

        Dim rElem As XElement = xPlan.Root.Element(id)
        If Not rElem Is Nothing Then
            If rElem.Elements.Any Then Return
            rElem.Remove()
            xPlan.Save(ThisChannel.PlanLocalFn)
        End If

        If c.Items.Contains(id) Then
            Dim i As Integer = c.SelectedIndex
            c.SelectedIndex = -1
            c.Items.Remove(id)
            If i >= c.Items.Count Then i = c.Items.Count - 1
            c.SelectedIndex = i
        End If

    End Sub

    Private Sub GetRules()
        Dim xList As IEnumerable(Of XElement) = From el In CurrentRoot.Elements Where OldElem(el.@date) Select el
        xList.Remove()

        Dim order As String = CurrentRoot.@order
        Dim neededFiles As New HashSet(Of String)
        Dim delfiles As New HashSet(Of String)
        If Not String.IsNullOrWhiteSpace(order) Then PriorityOrder = order.Split(","c).ToList

        For Each xRule As XElement In CurrentRoot.Elements
            Rules.Add(New PlanRule(xRule))
            neededFiles.Add(xRule.@file)
        Next

        For Each f As String In PriorityOrder
            If Not neededFiles.Contains(f) Then delfiles.Add(f)
        Next

        For Each f As String In delfiles
            PriorityOrder.Remove(f)
        Next

        For Each f As String In neededFiles
            If Not PriorityOrder.Contains(f) AndAlso Not f.StartsWith("["c) Then PriorityOrder.Add(f)
        Next
        CurrentRoot.@order = String.Join(","c, PriorityOrder)
    End Sub

    Friend Sub RootList(c As ComboBox)
        c.Items.Clear()
        For Each el As XElement In xPlan.Root.Elements
            If Not el.Name.LocalName = "rule" Then c.Items.Add(el.Name.LocalName)
        Next
        If c.Items.Count > 0 Then c.SelectedIndex = 0
    End Sub

    Friend Sub Check(item As ListViewItem)
        Dim guide As GuideItem = CType(item.Tag, GuideItem)
        SetConditions(guide)
        Dim ViaList As New List(Of String)

        For Each r As PlanRule In Rules
            Dim via As String = r.Value(-1)
            If via.Length > 0 Then ViaList.Add(via)
        Next

        If ViaList.Count > 0 Then
            item.SubItems.Add(String.Join(", ", ViaList))
            If ViaList.Count > 1 Then
                item.BackColor = Color.Gray
            Else
                item.BackColor = Color.LightGray
            End If
        End If
    End Sub

    Friend Sub RemoveActiveFiles(fileset As HashSet(Of String))
        For Each r As PlanRule In Rules
            Dim via As String = r.Value()
            If via.Length > 0 AndAlso fileset.Contains(via) Then fileset.Remove(via)
        Next
    End Sub

    Friend Function ActiveFiles() As HashSet(Of String)
        Dim fileset As New HashSet(Of String)
        For Each r As PlanRule In Rules
            Dim via As String = r.Value()
            If via.Length > 0 Then fileset.Add(via)
        Next
        Return fileset
    End Function

    Friend Function RuleInfo(id As String) As String
        Dim inf As String = String.Empty
        If String.IsNullOrWhiteSpace(id) Then Return inf

        Dim idRules As IEnumerable(Of PlanRule) = From rule In Rules Where rule.Value = id Select rule
        If Not idRules.Any Then Return inf

        'inf = idRules.Count.ToString + ": "
        Dim dMin As Date = Date.MaxValue
        Dim dMax As Date = Date.MinValue

        For Each r As PlanRule In idRules
            Dim dint() As String = r.Source.@date.Split("-"c)
            Dim t As String = r.Source.@time
            If String.IsNullOrWhiteSpace(t) Then t = "6-5"
            Dim tint() As String = t.Split("-"c)
            Dim dFrom As Date = datefromstring(dint(0), tint(0))
            If dFrom < dMin Then dMin = dFrom
            Dim dTo As Date = datefromstring(dint(1), tint(1))
            If dTo > dMax Then dMax = dTo
        Next

        If dMax < Now Then
            inf = "<<<"
        ElseIf dMin > Now Then
            inf = ">>>"
        Else
            inf = "!!!"
        End If

        Return String.Format("{0}: {1:dd.MM.yy} - {2:dd.MM.yy} ", idRules.Count, dMin, dMax) + inf
    End Function

    Private Function datefromstring(d As String, t As String) As Date
        Dim dt As Date
        If Date.TryParse(d, dt) Then
            Dim h As Integer = Integer.Parse(t)
            If h < 6 Then h += 24
            dt = dt.AddHours(h)
        End If
        Return dt
    End Function

    Friend Sub Fill()
        Dialog1.lRules.Items.Clear()

        For Each r As PlanRule In Rules
            GetEditor(r)
        Next

        Dialog()
    End Sub

    Friend Sub Fill(id As String)
        Dialog1.lRules.Items.Clear()

        For Each r As PlanRule In (From rule In Rules Where rule.Value = id Select rule)
            GetEditor(r)
        Next

        Dialog()
    End Sub

    Friend Sub Fill(d As Date)
        Dialog1.lRules.Items.Clear()

        For Each r As PlanRule In Rules '(From rule In Rules Where rule.Value = id Select rule)
            If New TimeIntervalFull(<rule date=<%= r.Source.@date %>/>).Enabled(d) Then
                GetEditor(r)
            End If
        Next

        Dialog()
    End Sub

    Friend Sub Fill(c As ComboBox, items As ListView, forceNew As Boolean)
        Dim gis As New List(Of GuideItem)
        For Each li As ListViewItem In items.SelectedItems
            gis.Add(CType(li.Tag, GuideItem))
        Next

        SetConditions(gis.First)
        Dim ViaList As New List(Of String)

        Dialog1.lRules.Items.Clear()
        For Each r As PlanRule In Rules
            Dim via As String = r.Value(-1)
            If via.Length > 0 Then
                'Dialog1.lRules.Items.Add(New PlanRuleEditor(r, False))
                GetEditor(r)
                ViaList.Add(via)
            End If
        Next

        If c.Text.Length > 0 Then
            If Not PriorityOrder.Contains(c.Text) AndAlso Not c.Text.StartsWith("["c) Then PriorityOrder.Add(c.Text)
            If Not ViaList.Contains(c.Text) OrElse forceNew Then   'pole reegleid selle saatele valitud bugi kohta või vaja lisada
                Dialog1.lRules.Items.Add(New PlanRuleEditor((Create(c.Text, gis)), True))
            End If
        End If

        Dialog()
    End Sub

    Private Sub GetEditor(r As PlanRule)
        If Not PriorityOrder.Contains(r.Value) AndAlso Not r.Value.StartsWith("["c) Then PriorityOrder.Add(r.Value)
        Dialog1.lRules.Items.Add(New PlanRuleEditor(r, False))
    End Sub

    Private Sub Dialog()
        If Dialog1.lRules.Items.Count = 0 Then Return

        Dialog1.FillPriority(PriorityOrder)
        If Dialog1.ShowDialog = DialogResult.OK Then
            For Each re As PlanRuleEditor In Dialog1.lRules.Items
                re.Sync()

                If re.Register Then
                    Rules.Add(re.Rule)
                    'xPlan.Root.Add(re.Rule.Source)
                    CurrentRoot.Add(re.Rule.Source)
                ElseIf Not re.Rule.Activated Then
                    Try
                        re.Rule.Source.Remove()
                        If Rules.Contains(re.Rule) Then Rules.Remove(re.Rule)
                    Catch ex As Exception
                        'MsgBox("1. " + ex.Message)
                    End Try
                End If
            Next

            If ThisChannel.Virtual Then
                Dim nxt As Char = "1"c
                If CurrentRoot.Elements.Any AndAlso CurrentRoot.Elements.Last.@choose Is Nothing Then nxt = "0"c
                CurrentRoot.@next = nxt
            Else
                For Each el As XElement In CurrentRoot.Elements    'bugide pikkused lisada!
                    Try
                        el.@dur = ThisChannel.BugDur(el.@file).ToString
                    Catch ex As Exception
                        'MsgBox("2. " + ex.Message)
                    End Try
                Next

                FindManualFiles()
            End If

            Dialog1.GetPriorities(PriorityOrder)
            SetPriority()

            xPlan.Save(ThisChannel.PlanLocalFn)
            'xPlan.Save(ThisChannel.PlanFn)
            'File.Copy(ThisChannel.PlanLocalFn, ThisChannel.PlanFn, True)
            SaveFlag = True
            SaveTrigger.Stop()
            SaveTrigger.Start()

            With Form1
                Guide.Fill(.cDates.Text.Split(" "c).Last, .LstProgr)
            End With

        End If
    End Sub

    Private Sub FindManualFiles()
        Dim manualFiles As New HashSet(Of String)

        For Each el As XElement In CurrentRoot.Elements
            Dim slots() As String = el.@slot.Split(","c)
            If slots.Contains("1"c) OrElse slots.Contains("31") Then
                Dim f As String = el.@file
                If Not f.StartsWith("["c) Then manualFiles.Add(f)
                'manualFiles.Add(el.@file)
            End If
        Next

        CurrentRoot.@manual = String.Join(","c, manualFiles)
    End Sub

    Friend Function Create(title As String, items As List(Of GuideItem)) As PlanRule

        Dim dMin As Date = items.First.Date_Time
        Dim dMax As Date = items.Last.Date_Time

        Dim ids As New HashSet(Of String)
        For Each gi As GuideItem In items
            ids.Add(gi.ID)
        Next

        Dim xrule As XElement = <rule pr=<%= String.Join(","c, ids) %> title=<%= items.First.Title %> priority="0" date=<%= PlanRule.DateString(dMin, dMax) %> time=<%= PlanRule.TimeString(dMin, dMax) %>/>
        If ThisChannel.Virtual Then
            If CurrentRoot.@next = "1"c Then
                xrule.SetAttributeValue("timeselect", "next")
                xrule.SetAttributeValue("choose", "nextsk")
            End If
        Else
            'xrule.SetAttributeValue("slot", "2"c)
            xrule.SetAttributeValue("slot", "38")
        End If

        xrule.SetAttributeValue("file", title)
        xrule.SetAttributeValue("created", Now)
        xrule.SetAttributeValue("modified", Now)
        'xPlan.Root.Add(xrule)	'aga ei salvesta veel enne kui klipi nime pole

        Return New PlanRule(xrule)
    End Function

    Private Sub SetConditions(guide As GuideItem)
        ConditionControl.NowTitle = guide.Title
        ConditionControl.NowTime = guide.Date_Time
        ConditionControl.NowID() = guide.ID
        ConditionControl.NextID() = guide.ID 'et saatekava reeglit näitaks selle saate ajal
        ConditionControl.NextTime = guide.Date_Time
        ConditionControl.SKID = guide.ID
    End Sub

    Private Function OldElem(d As String) As Boolean
        '(Now.Date - Date.Parse(el.<Kuupaev>.Last.Value)).TotalDays > 14
        If Not d.Contains("-"c) Then Return False

        Dim from_to() As String = d.Split("-"c)

        Return (Now.Date - Date.Parse(from_to(1))).TotalDays > 5 '14
    End Function

    Private Sub SetPriority()
        For Each r As PlanRule In Rules

            If String.IsNullOrWhiteSpace(r.Value) OrElse r.Value.StartsWith("["c) Then
                r.Source.@priority = "0"c
            Else
                If Not PriorityOrder.Contains(r.Value) Then PriorityOrder.Add(r.Value)
                r.Source.@priority = (PriorityOrder.IndexOf(r.Value) + 1).ToString
            End If
        Next

        CurrentRoot.@order = String.Join(","c, PriorityOrder)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        SaveTrigger.Stop()
        If SaveFlag Then SavePlan()
        SaveTrigger.Dispose()
    End Sub
End Class
