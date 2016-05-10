Option Strict On
Option Explicit On

Imports System.Windows.Forms

Public Class Dialog1
	Private chkDays As List(Of CheckBox)

	Private ChkValues As New Dictionary(Of CheckBox, Integer)
	Private ValueChks As New Dictionary(Of Integer, CheckBox)
    Private chkFineSlots As New List(Of CheckBox)
    Private chkMainSlots As New List(Of CheckBox)

	Private ActiveEditor As PlanRuleEditor
	Private ChangeSet As New HashSet(Of String)

	Private prTextBlock As Boolean
	Private prListBlock As Boolean
    Private PriorityChange As Boolean

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		chkDays = New List(Of CheckBox) From {chkE, ChkT, ChkK, ChkN, ChkR, ChkL, ChkP}
		InitSlotChecks()
	End Sub

	Private Sub Dialog1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
		'OK_Button.Enabled = False
        lRules.SelectedIndex = lRules.Items.Count - 1
        SyncPriority()
    End Sub

	Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If WarnDisable() Then Return

        Me.DialogResult = DialogResult.OK
		SaveRule()
        Me.Close()
	End Sub

	Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
		Me.DialogResult = DialogResult.Cancel
		ChangeSet.Clear()
		Me.Close()
    End Sub

    Friend Sub FillPriority(l As List(Of String))

        With lPriority
            .BeginUpdate()
            .Items.Clear()
            For Each f As String In l
                .Items.Add(f)
            Next
            .EndUpdate()
        End With
        PriorityChange = False
    End Sub

    Friend Sub GetPriorities(l As List(Of String))
        If Not PriorityChange Then Return

        l.Clear()
        For Each s As String In lPriority.Items
            l.Add(s)
        Next
    End Sub

	Private Sub lRules_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lRules.SelectedIndexChanged
        If lRules.SelectedIndex < 0 Then Return

        If Not ActiveEditor Is Nothing Then
            If WarnDisable() Then Return
            SaveRule()
        End If

		ActiveEditor = CType(lRules.SelectedItem, PlanRuleEditor)
		Dim DayStr As String = String.Empty
		'<rule pr="12/100/00948/0065" date="03.09.2012-03.09.2012" time="20-22"	slot="" priority="" file=""/>

		prTextBlock = True

		lPrs.Items.Clear()
		tID.Text = String.Empty
		tFromPart.Text = String.Empty
		tToPart.Text = String.Empty

		prTextBlock = False

        chkNext.Enabled = True
        ChkTime.Checked = False
        gSlotMain.Visible = False

		cFromTime.SelectedIndex = 0
		cToTime.SelectedIndex = 23
		tmFix.Value = Now.Date.AddHours(6)

		For Each attr As XAttribute In ActiveEditor.Rule.Source.Attributes
			Dim value As String = String.Empty
			If Not ActiveEditor.Changes.TryGetValue(attr.Name.LocalName, value) Then value = attr.Value

			Select Case attr.Name.LocalName
				Case "pr"
					If value.Contains(","c) Then
						Dim prs() As String = value.Split(","c)
						For Each pr As String In prs
							lPrs.Items.Add(pr.Trim)
						Next
					Else
						lPrs.Items.Add(value.Trim)
					End If
					lPrs.SelectedIndex = lPrs.Items.Count - 1
				Case "date"
					Dim dates() As String = value.Split("-"c)
					Dim d1 As Date
					If Not Date.TryParse(dates(0), d1) Then
						d1 = Today
					End If
					dFromDate.Value = d1
					Dim d2 As Date
					If dates.Count = 1 OrElse Not Date.TryParse(dates(1), d2) Then
						d2 = d1
					End If
					dToDate.Value = d2
				Case "time"
					Dim times() As String = value.Split("-"c)
					cFromTime.Text = Val(times(0)).ToString("00")
					If times.Count > 1 Then
						cToTime.Text = Val(times(1)).ToString("00")
					Else
						cToTime.Text = cFromTime.Text
					End If
					ChkTime.Checked = True
				Case "day"
					DayStr = value
				Case "file"
					If Not cVias.Items.Contains(value) Then cVias.Items.Add(value)
					cVias.SelectedItem = value
                Case "slot"
                    SetSlotControl(value)
                    chkNext.Enabled = False
				Case "fixtime"
					Dim ts As TimeSpan
					If TimeSpan.TryParse(value, ts) Then
						tmFix.Value = Now.Date + ts
                    End If
                Case "timeselect", "choose", "prselect"
                    chkNext.Checked = If(attr.Value.StartsWith("next"), True, False)
            End Select
		Next

		For Each chk As CheckBox In chkDays
			chk.Checked = DayStr.Contains(chk.Text)
		Next
		ChangeSet.Clear()	 'tühistab initialiseerimise käigus	toimunud muudatused 
	End Sub

	Private Sub lPrs_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lPrs.SelectedIndexChanged
		If prListBlock Then Return
		If lPrs.SelectedIndex < 0 Then Return

		prTextBlock = True

		tID.Text = String.Empty
		tFromPart.Text = String.Empty
		tToPart.Text = String.Empty

		Dim value As String = lPrs.SelectedItem.ToString
		If value.Contains("/"c) Then
			Try
				Dim fields() As String = value.Split("/"c)
				tID.Text = String.Format("{0}/{1}/{2}", fields(0), fields(1), fields(2))
                lblPrg.Text = Guide.Find(tID.Text)
				If fields.Count > 3 Then
					If fields(3).Contains("-") Then
						Dim parts() As String = fields(3).Split("-"c)
						tFromPart.Text = Val(parts(0)).ToString
						tToPart.Text = Val(parts(1)).ToString
					Else
						tFromPart.Text = Val(fields(3)).ToString
					End If
				End If
			Catch ex As Exception

			End Try
		Else
			tID.Text = value
            lblPrg.Text = value
		End If
		prTextBlock = False
		SetTitle()
	End Sub

	Private Sub SetTitle()
        Me.Text = String.Format("{0} ({1})", cVias.Text, lblPrg.Text)
	End Sub

	'<rule pr="12/100/00948/0065" date="03.09.2012-03.09.2012" time="20-22"	slot="" priority="" file=""/>
	Private Sub SaveRule()
		If ChangeSet.Count = 0 Then Return

		For Each key As String In ChangeSet
			Select Case key
				Case "pr"
					Dim prs As New List(Of String)

					For Each item As Object In lPrs.Items
						Dim pr As String = item.ToString
						If Not String.IsNullOrWhiteSpace(pr) Then prs.Add(pr)
					Next

					If prs.Count > 0 Then
						ActiveEditor.Changes(key) = String.Join(","c, prs)
					Else
						ActiveEditor.Changes(key) = Nothing
					End If
				Case "date"
					If dToDate.Value < dFromDate.Value Then dToDate.Value = dFromDate.Value
					ActiveEditor.Changes(key) = String.Format("{0:dd.MM.yyyy}-{1:dd.MM.yyyy}", dFromDate.Value, dToDate.Value)
				Case "time"
					If ChkTime.Checked Then
						ActiveEditor.Changes(key) = String.Format("{0}-{1}", cFromTime.SelectedItem, cToTime.SelectedItem)
					Else
						ActiveEditor.Changes(key) = Nothing	' String.Empty
					End If
				Case "day"
					Dim ParseStr As String = String.Empty

					For Each c As CheckBox In chkDays
						If c.Checked Then ParseStr += c.Text
					Next

					If ParseStr.Length > 0 Then
						ActiveEditor.Changes(key) = ParseStr
					Else
						ActiveEditor.Changes(key) = Nothing
					End If
				Case "slot"
					GetSlotValues(key)
				Case "priority"
                    'ActiveEditor.Changes(key) = nPriority.ToString
				Case "file"
					ActiveEditor.Changes(key) = cVias.Text
				Case "fixtime"
					If ChkFix.Checked Then
						ActiveEditor.Changes(key) = tmFix.Value.ToString("HH:mm:ss")
					Else
						ActiveEditor.Changes(key) = Nothing
                    End If
                Case "next"
                    Dim value As String = If(chkNext.Checked, "next", Nothing)
                    ActiveEditor.Changes("timeselect") = value
                    ' If chkSK.Checked Then value = "nextsk"
                    value = If(chkNext.Checked, "nextsk", Nothing)
                    ActiveEditor.Changes("choose") = value
            End Select
		Next

		OK_Button.Enabled = True
        ChangeSet.Clear()    'muudatused on registreeritud
        ActiveEditor = Nothing
	End Sub

	Private Sub bAll_Click(sender As System.Object, e As System.EventArgs) Handles bAll.Click
		ActivateRule(True)
	End Sub

	Private Sub bDel_Click(sender As System.Object, e As System.EventArgs) Handles bDel.Click
		ActivateRule(False)
		chkManual.Checked = False
	End Sub

	Private Sub ActivateRule(state As Boolean)
		For Each chk As CheckBox In ChkValues.Keys 'chkSlots
			chk.Checked = False
		Next
		chkAllSlots.Checked = state
	End Sub

	Private Sub InitSlotChecks()
        SetupCheckValue(chkManual, 1, False)
        SetupCheckValue(chkAllSlots, 2, True)

        SetupCheckValue(ChkDisabled, 38, True) 'keelatud slot, hoiatada kui on jäänud märgituks

        SetupCheckValue(chkSK, 30, True)   'saatekava
        SetupCheckValue(ChkFix, 31, True)      'fikseeritud kellaaeg

        SetupCheckValue(ChkStart, 3, False)   'saate algus

		SetupSlotFineControl(chkPreMain, bPre, 4) 'enne pausi
		SetupSlotFineControl(chkPostMain, bPost, 5)	'peale pausi

		SetupSlotFineControl(chkBegMain, bBeg, 6)  '  saateosa algus
		SetupSlotFineControl(chkCntrMain, bCntr, 7)	'saateosa
		SetupSlotFineControl(chkEndMain, bEnd, 8)	'  saateosa lõpp

        SetupCheckValue(ChkEnd, 9, False)     'saate lõpp

        SetupCheckValue(chkSpecial, 1000, False)
	End Sub

    Private Sub SetupCheckValue(chk As CheckBox, value As Integer, MainList As Boolean)
        ChkValues(chk) = value
        ValueChks(value) = chk
        If MainList Then chkMainSlots.Add(chk)
    End Sub

	Private Sub SetupSlotFineControl(c As CheckBox, b As Button, v As Integer)
		c.Tag = b
		b.Tag = c
		ChkValues(c) = v
		chkFineSlots.Add(c)

		AddHandler c.CheckedChanged, AddressOf chkFine_CheckedChanged
		AddHandler b.Click, AddressOf bFine_Click
	End Sub

	Private Sub SetSlotControl(setup As String)

        chkAllSlots.Checked = True
		For Each chk As CheckBox In ChkValues.Keys
			chk.Checked = False
		Next

        ' If setup.Length = 0 Then Return
        If String.IsNullOrWhiteSpace(setup) Then Return

		Dim slots() As String = setup.Split(","c)
		For Each sl As String In slots
			Dim slot As Integer = Integer.Parse(sl)
            'If slot = 39 Then Return ' slotid deaktiveeritud

			If ValueChks.ContainsKey(slot) Then
				ValueChks(slot).Checked = True
			End If

			If slot > 999 Then
				chkSpecial.Checked = True
				nSpecial.Value = slot - 1000
			End If
		Next

		For Each c As CheckBox In chkFineSlots
			Dim b As Button = CType(c.Tag, Button)
			c.Checked = Dialog3.InitialValue(slots, ChkValues(c), b)
		Next

		gSlotMain.Visible = True
	End Sub

	Private Sub GetSlotValues(key As String)	'As String
		Dim ValueList As New List(Of String)

		GetSlotValue(chkManual, ValueList)

		If chkAllSlots.Checked Then
			GetSlotValue(chkAllSlots, ValueList)
		ElseIf chkSK.Checked Then
			GetSlotValue(chkSK, ValueList)
		ElseIf ChkFix.Checked Then
			GetSlotValue(ChkFix, ValueList)
		Else
			GetSlotValue(chkSK, ValueList)
			GetSlotValue(ChkStart, ValueList)

			For Each c As CheckBox In chkFineSlots
				If c.Checked Then GetSlotGroupValue(c, ValueList)
			Next

			GetSlotValue(ChkEnd, ValueList)
			GetSlotValue(chkSpecial, ValueList)
		End If

		If ValueList.Count > 0 Then
			ActiveEditor.Changes(key) = String.Join(","c, ValueList)
		Else
			ActiveEditor.Changes(key) = String.Empty
		End If
	End Sub

	Private Sub GetSlotGroupValue(chk As CheckBox, values As List(Of String))
		Dim b As Button = CType(chk.Tag, Button)
		Dialog3.ValueSlots(ChkValues(chk), b.Text, values)
	End Sub

	Private Sub GetSlotValue(chk As CheckBox, lst As List(Of String))
		If chk.Checked Then lst.Add(ChkValues(chk).ToString)
	End Sub

	Private Sub pr_changed(sender As System.Object, e As System.EventArgs) Handles tID.TextChanged, tFromPart.TextChanged, tToPart.TextChanged
		If prTextBlock Then Return
		If lPrs.SelectedIndex < 0 Then Return

		prListBlock = True
		ChangeSet.Add("pr")

		Dim pr As String = tID.Text

		Dim value As Integer = CInt(Val(tFromPart.Text))
		If pr.Contains("/"c) AndAlso value > 0 Then
			Dim value2 As Integer = CInt(Val(tToPart.Text))
			If value2 > value Then
				pr += "/"c + value.ToString + "-"c + value2.ToString '("0000")
			Else
				pr += "/"c + value.ToString("0000")
			End If
		End If

		lPrs.Items(lPrs.SelectedIndex) = pr
		prListBlock = False
	End Sub

	Private Sub bDelPr_Click(sender As System.Object, e As System.EventArgs) Handles bDelPr.Click
		If lPrs.SelectedIndex < 0 Then Return
		ChangeSet.Add("pr")
		lPrs.Items.Remove(lPrs.SelectedItem)
		lPrs.SelectedIndex = lPrs.Items.Count - 1
	End Sub

	Private Sub bAddPr_Click(sender As System.Object, e As System.EventArgs) Handles bAddPr.Click
		ChangeSet.Add("pr")

		Dim pr As String = String.Empty
		If Dialog2.ShowDialog = Windows.Forms.DialogResult.OK Then pr = Dialog2.lId.Text
        Dialog2.lId.Text = String.Empty
        Dialog2.lName.Text = String.Empty

		If String.IsNullOrWhiteSpace(pr) Then Return
		lPrs.Items.Add(pr)
		lPrs.SelectedIndex = lPrs.Items.Count - 1
	End Sub

	Private Sub date_changed(sender As System.Object, e As System.EventArgs) Handles dFromDate.ValueChanged, dToDate.ValueChanged
		ChangeSet.Add("date")
	End Sub

	Private Sub ChkTime_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkTime.CheckedChanged
		cFromTime.Visible = ChkTime.Checked
		cToTime.Visible = ChkTime.Checked
		ChangeSet.Add("time")
	End Sub

	Private Sub time_changed(sender As System.Object, e As System.EventArgs) Handles cFromTime.SelectedIndexChanged, cToTime.SelectedIndexChanged
		ChangeSet.Add("time")
	End Sub

	Private Sub day_changed(sender As System.Object, e As System.EventArgs) Handles chkE.CheckedChanged, ChkT.CheckedChanged, ChkK.CheckedChanged, ChkN.CheckedChanged, ChkR.CheckedChanged, ChkL.CheckedChanged, ChkP.CheckedChanged
		ChangeSet.Add("day")
	End Sub

    'Private Sub priority_changed(sender As System.Object, e As System.EventArgs)
    '    ChangeSet.Add("priority")
    'End Sub

	Private Sub file_changed(sender As System.Object, e As System.EventArgs) Handles cVias.SelectedIndexChanged
		ChangeSet.Add("file")
        SetTitle()
        SyncPriority()
    End Sub

    Private Sub SyncPriority()
        Dim t As String = cVias.Text

        If Not lPriority.Items.Contains(t) Then
            If String.IsNullOrWhiteSpace(t) OrElse t.StartsWith("[") Then
                lPriority.SelectedIndex = -1
                Return
            End If
            lPriority.Items.Add(t)
        End If

        lPriority.SelectedIndex = lPriority.Items.IndexOf(t)
    End Sub

	'---------------------------------------------------------------------------------------------------
    Private Sub ChkDisabled_CheckedChanged(sender As Object, e As EventArgs) Handles ChkDisabled.CheckedChanged
        chkMain_CheckedChanged(ChkDisabled)
        ChkDisabled.Visible = ChkDisabled.Checked
    End Sub

	Private Sub chkAllSlots_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAllSlots.CheckedChanged
        chkMain_CheckedChanged(chkAllSlots)
    End Sub

	Private Sub chkSK_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSK.CheckedChanged
        chkMain_CheckedChanged(chkSK)
        chkNext.Checked = chkSK.Checked
	End Sub

    Private Sub ChkFix_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles ChkFix.CheckedChanged
        ChangeSet.Add("fixtime")
        chkMain_CheckedChanged(ChkFix)
        tmFix.Visible = ChkFix.Checked
    End Sub

    Private Sub chkMain_CheckedChanged(chk As CheckBox)
        ChangeSet.Add("slot")
        gSlotSelect.Visible = Not chkAllSlots.Checked AndAlso Not chkSK.Checked AndAlso Not ChkFix.Checked AndAlso Not ChkDisabled.Checked

        Dim chkOk As Boolean = False

        For Each c As CheckBox In chkMainSlots
            If chk.Checked AndAlso Not c Is chk Then c.Checked = False 'kustutada kõik teised
            If c.Checked Then chkOk = True
        Next

        gSlotSelect.Visible = Not chkOk 'fine kontroll nähtav kui ühtegi linnukest pole
    End Sub

	Private Sub tmFix_ValueChanged(sender As System.Object, e As System.EventArgs) Handles tmFix.ValueChanged
		ChangeSet.Add("fixtime")
	End Sub

	Private Sub slot_changed(sender As System.Object, e As System.EventArgs) Handles ChkStart.CheckedChanged, ChkEnd.CheckedChanged, chkManual.CheckedChanged
		ChangeSet.Add("slot")
	End Sub

	Private Sub nSpecial_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nSpecial.ValueChanged
		ChangeSet.Add("slot")
		ChkValues(chkSpecial) = 1000 + Decimal.ToInt32(nSpecial.Value)
	End Sub

	Private Sub chkSpecial_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkSpecial.CheckedChanged
		ChangeSet.Add("slot")
		nSpecial.Visible = chkSpecial.Checked
	End Sub

   

	Private Sub chkFine_CheckedChanged(sender As System.Object, e As System.EventArgs) ' Handles chkBegMain.CheckedChanged
		ChangeSet.Add("slot")
		Dim c As CheckBox = CType(sender, CheckBox)
		Dim b As Button = CType(c.Tag, Button)
		b.Enabled = c.Checked
	End Sub

	Private Sub bFine_Click(sender As System.Object, e As System.EventArgs)	'Handles bPre.Click
		Dim b As Button = CType(sender, Button)
		Dim c As CheckBox = CType(b.Tag, CheckBox)

		Dialog3.Text = c.Text
		Dialog3.Init(b.Text)
		If Dialog3.ShowDialog = Windows.Forms.DialogResult.OK Then
			Dim t As String = Dialog3.Value
			If t = b.Text Then Return
			ChangeSet.Add("slot")
			b.Text = t
		End If
	End Sub

    Private Sub chkNext_CheckedChanged(sender As Object, e As EventArgs) Handles chkNext.CheckedChanged
        ChangeSet.Add("next")
    End Sub

    Private Sub bUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUp.Click
        With lPriority
            If .SelectedIndex < 1 Then Return
            PriorityChange = True
            Dim o As Object = .SelectedItem
            Dim i As Integer = .SelectedIndex
            .Items.RemoveAt(.SelectedIndex)
            .Items.Insert(i - 1, o)
            .SelectedIndex = i - 1
            .Tag = 1
        End With
    End Sub

    Private Sub bDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDown.Click
        With lPriority
            If .SelectedIndex < 0 Or .SelectedIndex = .Items.Count - 1 Then Return
            PriorityChange = True
            Dim o As Object = .SelectedItem
            Dim i As Integer = .SelectedIndex + 1
            .Items.RemoveAt(.SelectedIndex)
            .Items.Insert(i, o)
            .SelectedIndex = i
        End With
    End Sub

    Private Sub lPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lPriority.SelectedIndexChanged
        With lPriority
            bUp.Enabled = (.SelectedIndex > 0)
            bDown.Enabled = (.SelectedIndex > -1) AndAlso (.SelectedIndex < .Items.Count - 1)
        End With
    End Sub

    Private Function WarnDisable() As Boolean
        If gSlotMain.Visible = False Then Return False 'slottideta reziim

        If ChkDisabled.Checked Then
            MessageBox.Show("Käivitusajad määramata!", "Hoiatus", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Return ChkDisabled.Checked
    End Function

End Class
