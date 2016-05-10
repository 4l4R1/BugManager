Imports System.Drawing

Public Class cgEffect

    Public Sub New(dir As String, s As Size, count As Integer)
        For i As Integer = 0 To count
            Dim b As Bitmap = New Bitmap(s.Width, s.Height, Imaging.PixelFormat.Format32bppArgb)
            Dim g As Graphics = Graphics.FromImage(b)

            If i > 0 Then
                Dim len As Single = CSng(i / count * s.Width)

                Dim color2 As Color = Color.FromArgb(95, Color.Black)
                Dim pen2 As Drawing.Pen = New Pen(color2, CInt(s.Height * 0.5))
                g.DrawRectangle(pen2, len, 0, s.Width - len, CInt(s.Height * 0.5))

                Dim c As Integer = CInt(i / count * 255)
                Dim color1 As Color = Color.FromArgb(250, c, 0, 255 - c)
                Dim pen1 As Drawing.Pen = New Pen(color1, s.Height)
                g.DrawRectangle(pen1, 0, 0, len, s.Height)

            End If


            b.Save(String.Format(dir, i))
            g.Dispose()
            b.Dispose()

        Next
    End Sub
End Class
