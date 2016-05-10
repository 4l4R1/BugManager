Imports System.Windows.Forms

Public Class Dialog3
	Private Cheks As New List(Of CheckBox)
	Private EmptyText As String = "alati"

	Public Sub New()
		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Cheks.Add(chk1)
		Cheks.Add(chk2)
		Cheks.Add(chk3)
		Cheks.Add(chk4)
		Cheks.Add(chk5)
		Cheks.Add(chk8)
		Cheks.Add(chk9)
	End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

	Friend Function InitialValue(slots() As String, base As Integer, b As Button) As Boolean   'reegli laadimisel esialgne nupu tekst
		If slots.Contains(base.ToString) Then
			b.Text = EmptyText
			Return True
		End If

		Dim slotMarks As New List(Of String)

		For i As Integer = 1 To 4
			If slots.Contains(SlotValue(base, i)) Then slotMarks.Add(i.ToString + "."c)
		Next

		If slots.Contains(SlotValue(base, 5)) Then slotMarks.Add("5+")
		If slots.Contains(SlotValue(base, 8)) Then slotMarks.Add("-2")
		If slots.Contains(SlotValue(base, 9)) Then slotMarks.Add("-1")

		If slotMarks.Count = 0 Then
			b.Text = EmptyText
			Return False
		End If

		b.Text = String.Join(" "c, slotMarks)
		Return True
	End Function

	Friend Sub Init(setup As String)   'initialiseerimine dialoogi kasutamise eel
		For Each c As CheckBox In Cheks
			c.Checked = False
		Next

		If setup = EmptyText Then Return
		If String.IsNullOrWhiteSpace(setup) Then Return 'peaks olema välistatud

		For Each slotMark As String In setup.Split(" "c)
			Select Case slotMark
				Case "1." : chk1.Checked = True
				Case "2." : chk2.Checked = True
				Case "3." : chk3.Checked = True
				Case "4." : chk4.Checked = True
				Case "5+" : chk5.Checked = True
				Case "-2" : chk8.Checked = True
				Case "-1" : chk9.Checked = True
			End Select
		Next
	End Sub

	Friend Function Value() As String	'dialoogi kasutamise järgne string
		Dim slotMarks As New List(Of String)

		For Each c As CheckBox In Cheks
			If c.Checked Then
				Select Case c.Text
					Case "viimane"
						slotMarks.Add("-1")
					Case "eelviimane"
						slotMarks.Add("-2")
					Case Else
						slotMarks.Add(c.Text)
				End Select
			End If
		Next

		If slotMarks.Count = 0 Then Return EmptyText
		Return String.Join(" "c, slotMarks)
	End Function

	Friend Sub ValueSlots(base As Integer, state As String, values As List(Of String))	'Value-s saadud stringile vastavate sloti Id-de saamine
		If state = EmptyText OrElse String.IsNullOrWhiteSpace(state) Then
			values.Add(base.ToString)
		Else

			For Each slotMark As String In state.Split(" "c)
				Select Case slotMark
					Case "1." : values.Add(SlotValue(base, 1))
					Case "2." : values.Add(SlotValue(base, 2))
					Case "3." : values.Add(SlotValue(base, 3))
					Case "4." : values.Add(SlotValue(base, 4))
					Case "5+" : values.Add(SlotValue(base, 5))
					Case "-2" : values.Add(SlotValue(base, 8))
					Case "-1" : values.Add(SlotValue(base, 9))
				End Select
			Next
		End If
	End Sub

	Private Function SlotValue(base As Integer, slot As Integer) As String
		Return (10 * base + slot).ToString
	End Function
End Class
