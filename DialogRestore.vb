Imports System.Windows.Forms
Imports System.IO

Public Class DialogRestore
    Private di As DirectoryInfo
    Private exts As New List(Of String) ' From {".via", "_w.via", "_v.via"}
    Private _restored As String

    Friend ReadOnly Property restored As String
        Get
            Return _restored
        End Get
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If lFind.SelectedIndex < 0 Then
            _restored = String.Empty
            Me.DialogResult = DialogResult.Cancel
        Else
            _restored = lFind.SelectedItem.ToString

            For Each ext As String In exts
                Dim name As String = String.Format("\{0}{1}", _restored, ext)
                Dim fi As New FileInfo(di.FullName + name)
                Try
                    If fi.Exists Then fi.MoveTo(di.Parent.FullName + name)
                Catch ex As Exception

                End Try
            Next
            Me.DialogResult = DialogResult.OK
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Friend Function Init(dir As String) As Boolean
        If String.IsNullOrWhiteSpace(dir) Then Return False

        If Not dir.EndsWith("\"c) Then dir += "\"c
        dir += "backup\"

        di = New DirectoryInfo(dir)
        If Not di.Exists Then Return False

        lFind.Items.Clear()

        'From {".via", "_w.via", "_v.via"}
        exts.Clear()
        exts.Add(ActiveChannel.Ext)
        If Not ActiveChannel.HD Then
            exts.Add("_w.via")
            exts.Add("_v.via")
        End If

        For Each f As FileInfo In di.GetFiles
            If f.Extension.ToLower = ActiveChannel.Ext AndAlso Not f.Name.Contains("_w.") AndAlso Not f.Name.Contains("_v.") Then
                lFind.Items.Add(f.Name.Replace(f.Extension, String.Empty))
            End If
        Next

        Return True
    End Function
End Class
