Imports System.Windows.Forms

Public Class DialogResizeHD
    'Const sMax As Double = 28800 '240,120
    Const sMax As Double = 135000 '450, 300
    Private ratio As Double
    Private origSize As SizeF
    Private blocked As Boolean

    Friend Sub Init(w As Double, h As Double, xy As Boolean)
        If xy Then
            InitXY(w, h)
            Return
        End If

        Me.Text = "Bugi suurus ja positsioon"
        ConfGui(True)
        numX.Minimum = 0
        numY.Minimum = 0
        numX.Value = 124 '60
        numY.Value = 72 '32

        ratio = w / h
        origSize = New SizeF(CSng(w), CSng(h))
        blocked = True
        rOrig.Checked = True

        ReCalc2spec(w, h)
        blocked = False
    End Sub

    Private Sub InitXY(w As Double, h As Double)

        blocked = True
        Me.Text = "Bugi positsioon"
        ConfGui(False)

        numX.Minimum = -1920
        numY.Minimum = -1080
        numX.Value = 0
        numY.Value = 0

        numW.Value = CInt(w)
        numH.Value = CInt(h)

        ratio = w / h

        rOrig.Checked = True


        blocked = False

    End Sub

    Private Sub ConfGui(value As Boolean)
        numW.Visible = value
        numH.Visible = value
        lblW.Visible = value
        lblH.Visible = value
        GroupBox1.Visible = value
    End Sub


    Friend Function Command(style As String) As String
        'draw_x_y_w_h_r/l
        Return String.Format("draw_{0}_{1}_{2}_{3}_{4}", numX.Value, numY.Value, numW.Value, numH.Value, style)
    End Function


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ReCalc2spec(w As Double, h As Double)
        If w * h > sMax Then   '1024*576=589824
            Dim z As Double = System.Math.Sqrt(sMax / (w * h)) '169.7/768=0.221
            w *= z
            h *= z
        End If

        If w > 960 Then 'pool ekraani
            Dim z As Double = 960 / w
            w *= z
            h *= z
        End If

        If h > 540 Then 'pool ekraani
            Dim z As Double = 540 / h
            w *= z
            h *= z
        End If

        numW.Value = CDec(Int(w))
        numH.Value = CDec(Int(h))
    End Sub

    Private Sub ReCalcW(sender As Object, e As EventArgs) Handles r720.CheckedChanged, r768.CheckedChanged, rPal.CheckedChanged, rOrig.CheckedChanged, numH.ValueChanged
        If rFree.Checked Then Return

        If blocked Then Return
        blocked = True

        Dim r As Double = GetRatio()
        numW.Value = CDec(Int(numH.Value * r))
        bSpec.Visible = (numW.Value * numH.Value > sMax)

        blocked = False
    End Sub

    Private Sub ReCalcH(sender As Object, e As EventArgs) Handles numW.ValueChanged
        If rFree.Checked Then Return

        If blocked Then Return
        blocked = True

        Dim r As Double = GetRatio()
        numH.Value = CDec(Int(numW.Value / r))
        bSpec.Visible = (numW.Value * numH.Value > sMax)

        blocked = False
    End Sub

    Private Function GetRatio() As Double
        If rOrig.Checked Then
            Return ratio '16/9=1.78
        ElseIf r720.Checked Then
            Return ratio * (1024 / 720)
        ElseIf r768.Checked Then
            Return ratio * (1024 / 768)
        Else    'rPal
            Return ratio * (768 / 720)
        End If
    End Function

    'Private Function SetSize() As Double
    '    If rOrig.Checked Then
    '        'Return ratio '16/9=1.78

    '    ElseIf r720.Checked Then
    '        Return ratio * (1024 / 720)
    '    ElseIf r768.Checked Then
    '        Return ratio * (1024 / 768)
    '    Else    'rPal
    '        Return ratio * (768 / 720)
    '    End If
    'End Function


    Private Sub bSpec_Click(sender As Object, e As EventArgs) Handles bSpec.Click
        blocked = True
        ReCalc2spec(numW.Value, numH.Value)
        bSpec.Visible = False
        blocked = False
    End Sub


End Class
