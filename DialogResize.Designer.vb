<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DialogResize
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.lblW = New System.Windows.Forms.Label()
        Me.lblH = New System.Windows.Forms.Label()
        Me.numH = New System.Windows.Forms.NumericUpDown()
        Me.numW = New System.Windows.Forms.NumericUpDown()
        Me.lblX = New System.Windows.Forms.Label()
        Me.lblY = New System.Windows.Forms.Label()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        Me.numX = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rPal = New System.Windows.Forms.RadioButton()
        Me.r768 = New System.Windows.Forms.RadioButton()
        Me.rFree = New System.Windows.Forms.RadioButton()
        Me.r720 = New System.Windows.Forms.RadioButton()
        Me.rOrig = New System.Windows.Forms.RadioButton()
        Me.bSpec = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numW, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(175, 119)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'lblW
        '
        Me.lblW.AutoSize = True
        Me.lblW.Location = New System.Drawing.Point(13, 39)
        Me.lblW.Name = "lblW"
        Me.lblW.Size = New System.Drawing.Size(18, 13)
        Me.lblW.TabIndex = 23
        Me.lblW.Text = "W"
        '
        'lblH
        '
        Me.lblH.AutoSize = True
        Me.lblH.Location = New System.Drawing.Point(92, 39)
        Me.lblH.Name = "lblH"
        Me.lblH.Size = New System.Drawing.Size(15, 13)
        Me.lblH.TabIndex = 22
        Me.lblH.Text = "H"
        '
        'numH
        '
        Me.numH.Location = New System.Drawing.Point(112, 37)
        Me.numH.Maximum = New Decimal(New Integer() {576, 0, 0, 0})
        Me.numH.Name = "numH"
        Me.numH.Size = New System.Drawing.Size(54, 20)
        Me.numH.TabIndex = 21
        '
        'numW
        '
        Me.numW.Location = New System.Drawing.Point(33, 37)
        Me.numW.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.numW.Name = "numW"
        Me.numW.Size = New System.Drawing.Size(50, 20)
        Me.numW.TabIndex = 20
        '
        'lblX
        '
        Me.lblX.AutoSize = True
        Me.lblX.Location = New System.Drawing.Point(13, 9)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(14, 13)
        Me.lblX.TabIndex = 27
        Me.lblX.Text = "X"
        '
        'lblY
        '
        Me.lblY.AutoSize = True
        Me.lblY.Location = New System.Drawing.Point(92, 9)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(14, 13)
        Me.lblY.TabIndex = 26
        Me.lblY.Text = "Y"
        '
        'numY
        '
        Me.numY.Location = New System.Drawing.Point(112, 7)
        Me.numY.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(53, 20)
        Me.numY.TabIndex = 25
        '
        'numX
        '
        Me.numX.Location = New System.Drawing.Point(33, 7)
        Me.numX.Maximum = New Decimal(New Integer() {1024, 0, 0, 0})
        Me.numX.Name = "numX"
        Me.numX.Size = New System.Drawing.Size(53, 20)
        Me.numX.TabIndex = 24
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rPal)
        Me.GroupBox1.Controls.Add(Me.r768)
        Me.GroupBox1.Controls.Add(Me.rFree)
        Me.GroupBox1.Controls.Add(Me.r720)
        Me.GroupBox1.Controls.Add(Me.rOrig)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(154, 85)
        Me.GroupBox1.TabIndex = 29
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Proportsioon"
        '
        'rPal
        '
        Me.rPal.AutoSize = True
        Me.rPal.Location = New System.Drawing.Point(64, 17)
        Me.rPal.Name = "rPal"
        Me.rPal.Size = New System.Drawing.Size(70, 17)
        Me.rPal.TabIndex = 4
        Me.rPal.TabStop = True
        Me.rPal.Text = "720->768"
        Me.rPal.UseVisualStyleBackColor = True
        '
        'r768
        '
        Me.r768.AutoSize = True
        Me.r768.Location = New System.Drawing.Point(64, 63)
        Me.r768.Name = "r768"
        Me.r768.Size = New System.Drawing.Size(76, 17)
        Me.r768.TabIndex = 3
        Me.r768.TabStop = True
        Me.r768.Text = "768->1024"
        Me.r768.UseVisualStyleBackColor = True
        '
        'rFree
        '
        Me.rFree.AutoSize = True
        Me.rFree.Location = New System.Drawing.Point(6, 40)
        Me.rFree.Name = "rFree"
        Me.rFree.Size = New System.Drawing.Size(50, 17)
        Me.rFree.TabIndex = 2
        Me.rFree.TabStop = True
        Me.rFree.Text = "Vaba"
        Me.rFree.UseVisualStyleBackColor = True
        '
        'r720
        '
        Me.r720.AutoSize = True
        Me.r720.Location = New System.Drawing.Point(64, 40)
        Me.r720.Name = "r720"
        Me.r720.Size = New System.Drawing.Size(76, 17)
        Me.r720.TabIndex = 1
        Me.r720.TabStop = True
        Me.r720.Text = "720->1024"
        Me.r720.UseVisualStyleBackColor = True
        '
        'rOrig
        '
        Me.rOrig.AutoSize = True
        Me.rOrig.Location = New System.Drawing.Point(6, 19)
        Me.rOrig.Name = "rOrig"
        Me.rOrig.Size = New System.Drawing.Size(52, 17)
        Me.rOrig.TabIndex = 0
        Me.rOrig.TabStop = True
        Me.rOrig.Text = "Algne"
        Me.rOrig.UseVisualStyleBackColor = True
        '
        'bSpec
        '
        Me.bSpec.Location = New System.Drawing.Point(178, 36)
        Me.bSpec.Name = "bSpec"
        Me.bSpec.Size = New System.Drawing.Size(84, 21)
        Me.bSpec.TabIndex = 30
        Me.bSpec.Text = "max lubatud"
        Me.bSpec.UseVisualStyleBackColor = True
        Me.bSpec.Visible = False
        '
        'DialogResize
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(333, 160)
        Me.Controls.Add(Me.bSpec)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblX)
        Me.Controls.Add(Me.lblY)
        Me.Controls.Add(Me.numY)
        Me.Controls.Add(Me.numX)
        Me.Controls.Add(Me.lblW)
        Me.Controls.Add(Me.lblH)
        Me.Controls.Add(Me.numH)
        Me.Controls.Add(Me.numW)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogResize"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Bugi suurus ja positsioon"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.numH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numW, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents lblW As Label
    Friend WithEvents lblH As Label
    Friend WithEvents numH As NumericUpDown
    Friend WithEvents numW As NumericUpDown
    Friend WithEvents lblX As Label
    Friend WithEvents lblY As Label
    Friend WithEvents numY As NumericUpDown
    Friend WithEvents numX As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rFree As RadioButton
    Friend WithEvents r720 As RadioButton
    Friend WithEvents rOrig As RadioButton
    Friend WithEvents r768 As RadioButton
    Friend WithEvents rPal As RadioButton
    Friend WithEvents bSpec As Button
End Class
