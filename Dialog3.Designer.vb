<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.chk9 = New System.Windows.Forms.CheckBox()
        Me.chk5 = New System.Windows.Forms.CheckBox()
        Me.chk8 = New System.Windows.Forms.CheckBox()
        Me.chk4 = New System.Windows.Forms.CheckBox()
        Me.chk3 = New System.Windows.Forms.CheckBox()
        Me.chk2 = New System.Windows.Forms.CheckBox()
        Me.chk1 = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 98)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(137, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(9, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(50, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(77, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(50, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'chk9
        '
        Me.chk9.AutoSize = True
        Me.chk9.Location = New System.Drawing.Point(67, 71)
        Me.chk9.Name = "chk9"
        Me.chk9.Size = New System.Drawing.Size(62, 17)
        Me.chk9.TabIndex = 11
        Me.chk9.Text = "viimane"
        Me.chk9.UseVisualStyleBackColor = True
        '
        'chk5
        '
        Me.chk5.AutoSize = True
        Me.chk5.Location = New System.Drawing.Point(67, 2)
        Me.chk5.Name = "chk5"
        Me.chk5.Size = New System.Drawing.Size(38, 17)
        Me.chk5.TabIndex = 10
        Me.chk5.Text = "5+"
        Me.chk5.UseVisualStyleBackColor = True
        '
        'chk8
        '
        Me.chk8.AutoSize = True
        Me.chk8.Location = New System.Drawing.Point(67, 48)
        Me.chk8.Name = "chk8"
        Me.chk8.Size = New System.Drawing.Size(76, 17)
        Me.chk8.TabIndex = 9
        Me.chk8.Text = "eelviimane"
        Me.chk8.UseVisualStyleBackColor = True
        '
        'chk4
        '
        Me.chk4.AutoSize = True
        Me.chk4.Location = New System.Drawing.Point(16, 71)
        Me.chk4.Name = "chk4"
        Me.chk4.Size = New System.Drawing.Size(35, 17)
        Me.chk4.TabIndex = 8
        Me.chk4.Text = "4."
        Me.chk4.UseVisualStyleBackColor = True
        '
        'chk3
        '
        Me.chk3.AutoSize = True
        Me.chk3.Location = New System.Drawing.Point(16, 48)
        Me.chk3.Name = "chk3"
        Me.chk3.Size = New System.Drawing.Size(35, 17)
        Me.chk3.TabIndex = 7
        Me.chk3.Text = "3."
        Me.chk3.UseVisualStyleBackColor = True
        '
        'chk2
        '
        Me.chk2.AutoSize = True
        Me.chk2.Location = New System.Drawing.Point(16, 25)
        Me.chk2.Name = "chk2"
        Me.chk2.Size = New System.Drawing.Size(35, 17)
        Me.chk2.TabIndex = 6
        Me.chk2.Text = "2."
        Me.chk2.UseVisualStyleBackColor = True
        '
        'chk1
        '
        Me.chk1.AutoSize = True
        Me.chk1.Location = New System.Drawing.Point(16, 2)
        Me.chk1.Name = "chk1"
        Me.chk1.Size = New System.Drawing.Size(35, 17)
        Me.chk1.TabIndex = 5
        Me.chk1.Text = "1."
        Me.chk1.UseVisualStyleBackColor = True
        '
        'Dialog3
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(142, 139)
        Me.Controls.Add(Me.chk9)
        Me.Controls.Add(Me.chk4)
        Me.Controls.Add(Me.chk8)
        Me.Controls.Add(Me.chk5)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.chk3)
        Me.Controls.Add(Me.chk1)
        Me.Controls.Add(Me.chk2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog3"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Saate osad"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents chk9 As System.Windows.Forms.CheckBox
	Friend WithEvents chk5 As System.Windows.Forms.CheckBox
	Friend WithEvents chk8 As System.Windows.Forms.CheckBox
	Friend WithEvents chk4 As System.Windows.Forms.CheckBox
	Friend WithEvents chk3 As System.Windows.Forms.CheckBox
	Friend WithEvents chk2 As System.Windows.Forms.CheckBox
	Friend WithEvents chk1 As System.Windows.Forms.CheckBox

End Class
