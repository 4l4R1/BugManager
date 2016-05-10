Imports System.Windows.Forms

Public Class Dialog2

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
		tFind.Text = String.Empty
		Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
		tFind.Text = String.Empty
		Me.Close()
    End Sub

	Private Sub tFind_TextChanged(sender As System.Object, e As System.EventArgs) Handles tFind.TextChanged
		Guide.Fill(tFind.Text, lFind)
		lFind.Visible = CBool(lFind.Items.Count)
		Label1.Text = If(tFind.Text.Length < 2, "Trüki otsitava saate nimi!", "Ei leia sellist saadet!")
    End Sub

    Private Sub lFind_DoubleClick(sender As Object, e As EventArgs) Handles lFind.DoubleClick
        If lFind.SelectedIndex < 0 Then Return
        Me.DialogResult = DialogResult.OK
        tFind.Text = String.Empty
        Me.Close()
    End Sub

	Private Sub lFind_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lFind.SelectedIndexChanged
		If lFind.SelectedIndex < 0 Then Return

		Dim spl() As String = lFind.SelectedItem.ToString.Split("="c)
        lId.Text = spl(0).Trim
        lName.Text = spl(1).Trim
	End Sub

	Private Sub Dialog2_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
		tFind.Select()
	End Sub
End Class
