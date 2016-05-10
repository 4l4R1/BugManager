<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.tID = New System.Windows.Forms.TextBox()
        Me.tFromPart = New System.Windows.Forms.TextBox()
        Me.tToPart = New System.Windows.Forms.TextBox()
        Me.cVias = New System.Windows.Forms.ComboBox()
        Me.cFromTime = New System.Windows.Forms.ComboBox()
        Me.cToTime = New System.Windows.Forms.ComboBox()
        Me.dFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dToDate = New System.Windows.Forms.DateTimePicker()
        Me.chkE = New System.Windows.Forms.CheckBox()
        Me.ChkT = New System.Windows.Forms.CheckBox()
        Me.ChkK = New System.Windows.Forms.CheckBox()
        Me.ChkN = New System.Windows.Forms.CheckBox()
        Me.ChkR = New System.Windows.Forms.CheckBox()
        Me.ChkL = New System.Windows.Forms.CheckBox()
        Me.ChkP = New System.Windows.Forms.CheckBox()
        Me.bDel = New System.Windows.Forms.Button()
        Me.bAll = New System.Windows.Forms.Button()
        Me.chkManual = New System.Windows.Forms.CheckBox()
        Me.ChkEnd = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkTime = New System.Windows.Forms.CheckBox()
        Me.gSlotMain = New System.Windows.Forms.GroupBox()
        Me.ChkDisabled = New System.Windows.Forms.CheckBox()
        Me.ChkFix = New System.Windows.Forms.CheckBox()
        Me.tmFix = New System.Windows.Forms.DateTimePicker()
        Me.chkSK = New System.Windows.Forms.CheckBox()
        Me.gSlotSelect = New System.Windows.Forms.GroupBox()
        Me.bEnd = New System.Windows.Forms.Button()
        Me.bCntr = New System.Windows.Forms.Button()
        Me.bBeg = New System.Windows.Forms.Button()
        Me.chkEndMain = New System.Windows.Forms.CheckBox()
        Me.chkCntrMain = New System.Windows.Forms.CheckBox()
        Me.chkBegMain = New System.Windows.Forms.CheckBox()
        Me.bPost = New System.Windows.Forms.Button()
        Me.chkPostMain = New System.Windows.Forms.CheckBox()
        Me.bPre = New System.Windows.Forms.Button()
        Me.chkPreMain = New System.Windows.Forms.CheckBox()
        Me.nSpecial = New System.Windows.Forms.NumericUpDown()
        Me.chkSpecial = New System.Windows.Forms.CheckBox()
        Me.ChkStart = New System.Windows.Forms.CheckBox()
        Me.chkAllSlots = New System.Windows.Forms.CheckBox()
        Me.lRules = New System.Windows.Forms.ListBox()
        Me.lPrs = New System.Windows.Forms.ListBox()
        Me.bDelPr = New System.Windows.Forms.Button()
        Me.bAddPr = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.chkNext = New System.Windows.Forms.CheckBox()
        Me.lPriority = New System.Windows.Forms.ListBox()
        Me.bUp = New System.Windows.Forms.Button()
        Me.bDown = New System.Windows.Forms.Button()
        Me.lblPrg = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout
        Me.gSlotMain.SuspendLayout
        Me.gSlotSelect.SuspendLayout
        CType(Me.nSpecial,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(442, 480)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50!))
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
        'tID
        '
        Me.tID.Location = New System.Drawing.Point(249, 189)
        Me.tID.Name = "tID"
        Me.tID.Size = New System.Drawing.Size(78, 20)
        Me.tID.TabIndex = 1
        Me.tID.Text = "12/100/00948"
        Me.ToolTip1.SetToolTip(Me.tID, "Saate ID")
        '
        'tFromPart
        '
        Me.tFromPart.Location = New System.Drawing.Point(333, 189)
        Me.tFromPart.Name = "tFromPart"
        Me.tFromPart.Size = New System.Drawing.Size(40, 20)
        Me.tFromPart.TabIndex = 2
        Me.tFromPart.Tag = "12/100/00948"
        Me.tFromPart.Text = "12345"
        Me.ToolTip1.SetToolTip(Me.tFromPart, "Max osa nr")
        '
        'tToPart
        '
        Me.tToPart.Location = New System.Drawing.Point(379, 189)
        Me.tToPart.Name = "tToPart"
        Me.tToPart.Size = New System.Drawing.Size(40, 20)
        Me.tToPart.TabIndex = 3
        Me.tToPart.Tag = "12/100/00948"
        Me.tToPart.Text = "12345"
        Me.ToolTip1.SetToolTip(Me.tToPart, "Min osa nr")
        '
        'cVias
        '
        Me.cVias.FormattingEnabled = true
        Me.cVias.Location = New System.Drawing.Point(249, 117)
        Me.cVias.Name = "cVias"
        Me.cVias.Size = New System.Drawing.Size(170, 21)
        Me.cVias.TabIndex = 12
        '
        'cFromTime
        '
        Me.cFromTime.FormattingEnabled = true
        Me.cFromTime.Items.AddRange(New Object() {"06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "00", "01", "02", "03", "04", "05"})
        Me.cFromTime.Location = New System.Drawing.Point(329, 245)
        Me.cFromTime.Name = "cFromTime"
        Me.cFromTime.Size = New System.Drawing.Size(41, 21)
        Me.cFromTime.TabIndex = 13
        Me.cFromTime.Visible = false
        '
        'cToTime
        '
        Me.cToTime.FormattingEnabled = true
        Me.cToTime.Items.AddRange(New Object() {"06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "00", "01", "02", "03", "04", "05"})
        Me.cToTime.Location = New System.Drawing.Point(377, 245)
        Me.cToTime.Name = "cToTime"
        Me.cToTime.Size = New System.Drawing.Size(41, 21)
        Me.cToTime.TabIndex = 14
        Me.cToTime.Visible = false
        '
        'dFromDate
        '
        Me.dFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dFromDate.Location = New System.Drawing.Point(104, 245)
        Me.dFromDate.Name = "dFromDate"
        Me.dFromDate.Size = New System.Drawing.Size(78, 20)
        Me.dFromDate.TabIndex = 15
        '
        'dToDate
        '
        Me.dToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dToDate.Location = New System.Drawing.Point(188, 245)
        Me.dToDate.Name = "dToDate"
        Me.dToDate.Size = New System.Drawing.Size(78, 20)
        Me.dToDate.TabIndex = 16
        '
        'chkE
        '
        Me.chkE.AutoSize = true
        Me.chkE.Location = New System.Drawing.Point(12, 280)
        Me.chkE.Name = "chkE"
        Me.chkE.Size = New System.Drawing.Size(33, 17)
        Me.chkE.TabIndex = 19
        Me.chkE.Text = "E"
        Me.chkE.UseVisualStyleBackColor = true
        '
        'ChkT
        '
        Me.ChkT.AutoSize = true
        Me.ChkT.Location = New System.Drawing.Point(51, 280)
        Me.ChkT.Name = "ChkT"
        Me.ChkT.Size = New System.Drawing.Size(33, 17)
        Me.ChkT.TabIndex = 20
        Me.ChkT.Text = "T"
        Me.ChkT.UseVisualStyleBackColor = true
        '
        'ChkK
        '
        Me.ChkK.AutoSize = true
        Me.ChkK.Location = New System.Drawing.Point(90, 280)
        Me.ChkK.Name = "ChkK"
        Me.ChkK.Size = New System.Drawing.Size(33, 17)
        Me.ChkK.TabIndex = 21
        Me.ChkK.Text = "K"
        Me.ChkK.UseVisualStyleBackColor = true
        '
        'ChkN
        '
        Me.ChkN.AutoSize = true
        Me.ChkN.Location = New System.Drawing.Point(129, 280)
        Me.ChkN.Name = "ChkN"
        Me.ChkN.Size = New System.Drawing.Size(34, 17)
        Me.ChkN.TabIndex = 22
        Me.ChkN.Text = "N"
        Me.ChkN.UseVisualStyleBackColor = true
        '
        'ChkR
        '
        Me.ChkR.AutoSize = true
        Me.ChkR.Location = New System.Drawing.Point(168, 280)
        Me.ChkR.Name = "ChkR"
        Me.ChkR.Size = New System.Drawing.Size(34, 17)
        Me.ChkR.TabIndex = 23
        Me.ChkR.Text = "R"
        Me.ChkR.UseVisualStyleBackColor = true
        '
        'ChkL
        '
        Me.ChkL.AutoSize = true
        Me.ChkL.Location = New System.Drawing.Point(207, 280)
        Me.ChkL.Name = "ChkL"
        Me.ChkL.Size = New System.Drawing.Size(32, 17)
        Me.ChkL.TabIndex = 24
        Me.ChkL.Text = "L"
        Me.ChkL.UseVisualStyleBackColor = true
        '
        'ChkP
        '
        Me.ChkP.AutoSize = true
        Me.ChkP.Location = New System.Drawing.Point(246, 280)
        Me.ChkP.Name = "ChkP"
        Me.ChkP.Size = New System.Drawing.Size(33, 17)
        Me.ChkP.TabIndex = 25
        Me.ChkP.Text = "P"
        Me.ChkP.UseVisualStyleBackColor = true
        '
        'bDel
        '
        Me.bDel.Location = New System.Drawing.Point(335, 39)
        Me.bDel.Name = "bDel"
        Me.bDel.Size = New System.Drawing.Size(41, 25)
        Me.bDel.TabIndex = 6
        Me.bDel.Text = "reset"
        Me.bDel.UseVisualStyleBackColor = true
        '
        'bAll
        '
        Me.bAll.Location = New System.Drawing.Point(276, 39)
        Me.bAll.Name = "bAll"
        Me.bAll.Size = New System.Drawing.Size(51, 25)
        Me.bAll.TabIndex = 5
        Me.bAll.Text = "default"
        Me.bAll.UseVisualStyleBackColor = true
        '
        'chkManual
        '
        Me.chkManual.AutoSize = true
        Me.chkManual.Location = New System.Drawing.Point(147, 19)
        Me.chkManual.Name = "chkManual"
        Me.chkManual.Size = New System.Drawing.Size(95, 17)
        Me.chkManual.TabIndex = 4
        Me.chkManual.Text = "Käsitsi käivitus"
        Me.chkManual.UseVisualStyleBackColor = true
        '
        'ChkEnd
        '
        Me.ChkEnd.AutoSize = true
        Me.ChkEnd.Location = New System.Drawing.Point(270, 16)
        Me.ChkEnd.Name = "ChkEnd"
        Me.ChkEnd.Size = New System.Drawing.Size(51, 17)
        Me.ChkEnd.TabIndex = 1
        Me.ChkEnd.Text = "lõpus"
        Me.ChkEnd.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(288, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "prioriteet"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Location = New System.Drawing.Point(9, 248)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Kuupäevadel (k.a.)"
        '
        'ChkTime
        '
        Me.ChkTime.AutoSize = true
        Me.ChkTime.Location = New System.Drawing.Point(284, 247)
        Me.ChkTime.Name = "ChkTime"
        Me.ChkTime.Size = New System.Drawing.Size(43, 17)
        Me.ChkTime.TabIndex = 18
        Me.ChkTime.Text = "Kell"
        Me.ChkTime.UseVisualStyleBackColor = true
        '
        'gSlotMain
        '
        Me.gSlotMain.Controls.Add(Me.ChkDisabled)
        Me.gSlotMain.Controls.Add(Me.ChkFix)
        Me.gSlotMain.Controls.Add(Me.tmFix)
        Me.gSlotMain.Controls.Add(Me.chkSK)
        Me.gSlotMain.Controls.Add(Me.gSlotSelect)
        Me.gSlotMain.Controls.Add(Me.chkAllSlots)
        Me.gSlotMain.Controls.Add(Me.chkManual)
        Me.gSlotMain.Controls.Add(Me.bAll)
        Me.gSlotMain.Controls.Add(Me.bDel)
        Me.gSlotMain.Location = New System.Drawing.Point(12, 306)
        Me.gSlotMain.Name = "gSlotMain"
        Me.gSlotMain.Size = New System.Drawing.Size(408, 203)
        Me.gSlotMain.TabIndex = 31
        Me.gSlotMain.TabStop = false
        Me.gSlotMain.Text = "Lubatud"
        '
        'ChkDisabled
        '
        Me.ChkDisabled.AutoSize = true
        Me.ChkDisabled.ForeColor = System.Drawing.Color.Red
        Me.ChkDisabled.Location = New System.Drawing.Point(147, 42)
        Me.ChkDisabled.Name = "ChkDisabled"
        Me.ChkDisabled.Size = New System.Drawing.Size(97, 17)
        Me.ChkDisabled.TabIndex = 40
        Me.ChkDisabled.Text = "MÄÄRAMATA!"
        Me.ChkDisabled.UseVisualStyleBackColor = true
        Me.ChkDisabled.Visible = false
        '
        'ChkFix
        '
        Me.ChkFix.AutoSize = true
        Me.ChkFix.Location = New System.Drawing.Point(17, 42)
        Me.ChkFix.Name = "ChkFix"
        Me.ChkFix.Size = New System.Drawing.Size(42, 17)
        Me.ChkFix.TabIndex = 45
        Me.ChkFix.Text = "kell"
        Me.ChkFix.UseVisualStyleBackColor = true
        '
        'tmFix
        '
        Me.tmFix.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.tmFix.Location = New System.Drawing.Point(57, 39)
        Me.tmFix.Name = "tmFix"
        Me.tmFix.ShowUpDown = true
        Me.tmFix.Size = New System.Drawing.Size(68, 20)
        Me.tmFix.TabIndex = 46
        Me.tmFix.Visible = false
        '
        'chkSK
        '
        Me.chkSK.AutoSize = true
        Me.chkSK.Location = New System.Drawing.Point(276, 19)
        Me.chkSK.Name = "chkSK"
        Me.chkSK.Size = New System.Drawing.Size(95, 17)
        Me.chkSK.TabIndex = 14
        Me.chkSK.Text = "saatekava ajal"
        Me.chkSK.UseVisualStyleBackColor = true
        '
        'gSlotSelect
        '
        Me.gSlotSelect.Controls.Add(Me.bEnd)
        Me.gSlotSelect.Controls.Add(Me.bCntr)
        Me.gSlotSelect.Controls.Add(Me.bBeg)
        Me.gSlotSelect.Controls.Add(Me.chkEndMain)
        Me.gSlotSelect.Controls.Add(Me.chkCntrMain)
        Me.gSlotSelect.Controls.Add(Me.chkBegMain)
        Me.gSlotSelect.Controls.Add(Me.bPost)
        Me.gSlotSelect.Controls.Add(Me.chkPostMain)
        Me.gSlotSelect.Controls.Add(Me.bPre)
        Me.gSlotSelect.Controls.Add(Me.chkPreMain)
        Me.gSlotSelect.Controls.Add(Me.nSpecial)
        Me.gSlotSelect.Controls.Add(Me.chkSpecial)
        Me.gSlotSelect.Controls.Add(Me.ChkStart)
        Me.gSlotSelect.Controls.Add(Me.ChkEnd)
        Me.gSlotSelect.Location = New System.Drawing.Point(6, 68)
        Me.gSlotSelect.Name = "gSlotSelect"
        Me.gSlotSelect.Size = New System.Drawing.Size(396, 129)
        Me.gSlotSelect.TabIndex = 5
        Me.gSlotSelect.TabStop = false
        Me.gSlotSelect.Text = "Valikuliselt"
        Me.gSlotSelect.Visible = false
        '
        'bEnd
        '
        Me.bEnd.Enabled = false
        Me.bEnd.Location = New System.Drawing.Point(270, 102)
        Me.bEnd.Name = "bEnd"
        Me.bEnd.Size = New System.Drawing.Size(100, 20)
        Me.bEnd.TabIndex = 44
        Me.bEnd.UseVisualStyleBackColor = true
        '
        'bCntr
        '
        Me.bCntr.Enabled = false
        Me.bCntr.Location = New System.Drawing.Point(141, 102)
        Me.bCntr.Name = "bCntr"
        Me.bCntr.Size = New System.Drawing.Size(100, 20)
        Me.bCntr.TabIndex = 43
        Me.bCntr.UseVisualStyleBackColor = true
        '
        'bBeg
        '
        Me.bBeg.Enabled = false
        Me.bBeg.Location = New System.Drawing.Point(11, 102)
        Me.bBeg.Name = "bBeg"
        Me.bBeg.Size = New System.Drawing.Size(100, 20)
        Me.bBeg.TabIndex = 42
        Me.bBeg.UseVisualStyleBackColor = true
        '
        'chkEndMain
        '
        Me.chkEndMain.AutoSize = true
        Me.chkEndMain.Location = New System.Drawing.Point(270, 85)
        Me.chkEndMain.Name = "chkEndMain"
        Me.chkEndMain.Size = New System.Drawing.Size(97, 17)
        Me.chkEndMain.TabIndex = 41
        Me.chkEndMain.Text = "saateosa lõpus"
        Me.chkEndMain.UseVisualStyleBackColor = true
        '
        'chkCntrMain
        '
        Me.chkCntrMain.AutoSize = true
        Me.chkCntrMain.Location = New System.Drawing.Point(141, 85)
        Me.chkCntrMain.Name = "chkCntrMain"
        Me.chkCntrMain.Size = New System.Drawing.Size(103, 17)
        Me.chkCntrMain.TabIndex = 40
        Me.chkCntrMain.Text = "saateosa keskel"
        Me.chkCntrMain.UseVisualStyleBackColor = true
        '
        'chkBegMain
        '
        Me.chkBegMain.AutoSize = true
        Me.chkBegMain.Location = New System.Drawing.Point(11, 85)
        Me.chkBegMain.Name = "chkBegMain"
        Me.chkBegMain.Size = New System.Drawing.Size(108, 17)
        Me.chkBegMain.TabIndex = 39
        Me.chkBegMain.Text = "saateosa alguses"
        Me.chkBegMain.UseVisualStyleBackColor = true
        '
        'bPost
        '
        Me.bPost.Enabled = false
        Me.bPost.Location = New System.Drawing.Point(270, 59)
        Me.bPost.Name = "bPost"
        Me.bPost.Size = New System.Drawing.Size(100, 20)
        Me.bPost.TabIndex = 38
        Me.bPost.UseVisualStyleBackColor = true
        '
        'chkPostMain
        '
        Me.chkPostMain.AutoSize = true
        Me.chkPostMain.Location = New System.Drawing.Point(270, 42)
        Me.chkPostMain.Name = "chkPostMain"
        Me.chkPostMain.Size = New System.Drawing.Size(80, 17)
        Me.chkPostMain.TabIndex = 37
        Me.chkPostMain.Text = "peale pausi"
        Me.chkPostMain.UseVisualStyleBackColor = true
        '
        'bPre
        '
        Me.bPre.Enabled = false
        Me.bPre.Location = New System.Drawing.Point(11, 59)
        Me.bPre.Name = "bPre"
        Me.bPre.Size = New System.Drawing.Size(100, 20)
        Me.bPre.TabIndex = 36
        Me.bPre.UseVisualStyleBackColor = true
        '
        'chkPreMain
        '
        Me.chkPreMain.AutoSize = true
        Me.chkPreMain.Location = New System.Drawing.Point(11, 42)
        Me.chkPreMain.Name = "chkPreMain"
        Me.chkPreMain.Size = New System.Drawing.Size(78, 17)
        Me.chkPreMain.TabIndex = 30
        Me.chkPreMain.Text = "enne pausi"
        Me.chkPreMain.UseVisualStyleBackColor = true
        '
        'nSpecial
        '
        Me.nSpecial.Location = New System.Drawing.Point(218, 14)
        Me.nSpecial.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.nSpecial.Name = "nSpecial"
        Me.nSpecial.Size = New System.Drawing.Size(40, 20)
        Me.nSpecial.TabIndex = 29
        Me.nSpecial.Visible = false
        '
        'chkSpecial
        '
        Me.chkSpecial.AutoSize = true
        Me.chkSpecial.Location = New System.Drawing.Point(141, 16)
        Me.chkSpecial.Name = "chkSpecial"
        Me.chkSpecial.Size = New System.Drawing.Size(73, 17)
        Me.chkSpecial.TabIndex = 1
        Me.chkSpecial.Text = "special id:"
        Me.chkSpecial.UseVisualStyleBackColor = true
        '
        'ChkStart
        '
        Me.ChkStart.AutoSize = true
        Me.ChkStart.Location = New System.Drawing.Point(11, 19)
        Me.ChkStart.Name = "ChkStart"
        Me.ChkStart.Size = New System.Drawing.Size(62, 17)
        Me.ChkStart.TabIndex = 1
        Me.ChkStart.Text = "alguses"
        Me.ChkStart.UseVisualStyleBackColor = true
        '
        'chkAllSlots
        '
        Me.chkAllSlots.AutoSize = true
        Me.chkAllSlots.Location = New System.Drawing.Point(17, 19)
        Me.chkAllSlots.Name = "chkAllSlots"
        Me.chkAllSlots.Size = New System.Drawing.Size(93, 17)
        Me.chkAllSlots.TabIndex = 0
        Me.chkAllSlots.Text = "alati saate ajal"
        Me.chkAllSlots.UseVisualStyleBackColor = true
        '
        'lRules
        '
        Me.lRules.FormattingEnabled = true
        Me.lRules.Location = New System.Drawing.Point(12, 8)
        Me.lRules.Name = "lRules"
        Me.lRules.Size = New System.Drawing.Size(407, 108)
        Me.lRules.TabIndex = 32
        '
        'lPrs
        '
        Me.lPrs.FormattingEnabled = true
        Me.lPrs.Location = New System.Drawing.Point(12, 117)
        Me.lPrs.Name = "lPrs"
        Me.lPrs.Size = New System.Drawing.Size(231, 121)
        Me.lPrs.TabIndex = 33
        '
        'bDelPr
        '
        Me.bDelPr.Location = New System.Drawing.Point(249, 215)
        Me.bDelPr.Name = "bDelPr"
        Me.bDelPr.Size = New System.Drawing.Size(36, 23)
        Me.bDelPr.TabIndex = 34
        Me.bDelPr.Text = "- id"
        Me.bDelPr.UseVisualStyleBackColor = true
        '
        'bAddPr
        '
        Me.bAddPr.Location = New System.Drawing.Point(291, 215)
        Me.bAddPr.Name = "bAddPr"
        Me.bAddPr.Size = New System.Drawing.Size(36, 23)
        Me.bAddPr.TabIndex = 35
        Me.bAddPr.Text = "+ id"
        Me.bAddPr.UseVisualStyleBackColor = true
        '
        'chkNext
        '
        Me.chkNext.AutoSize = true
        Me.chkNext.Location = New System.Drawing.Point(333, 219)
        Me.chkNext.Name = "chkNext"
        Me.chkNext.Size = New System.Drawing.Size(85, 17)
        Me.chkNext.TabIndex = 36
        Me.chkNext.Text = "enne saadet"
        Me.chkNext.UseVisualStyleBackColor = true
        '
        'lPriority
        '
        Me.lPriority.FormattingEnabled = true
        Me.lPriority.Location = New System.Drawing.Point(426, 10)
        Me.lPriority.Name = "lPriority"
        Me.lPriority.Size = New System.Drawing.Size(161, 459)
        Me.lPriority.TabIndex = 37
        '
        'bUp
        '
        Me.bUp.Image = Global.eg2012.My.Resources.Resources.up
        Me.bUp.Location = New System.Drawing.Point(334, 272)
        Me.bUp.Name = "bUp"
        Me.bUp.Size = New System.Drawing.Size(36, 30)
        Me.bUp.TabIndex = 38
        Me.bUp.UseVisualStyleBackColor = true
        '
        'bDown
        '
        Me.bDown.Image = Global.eg2012.My.Resources.Resources.down
        Me.bDown.Location = New System.Drawing.Point(382, 272)
        Me.bDown.Name = "bDown"
        Me.bDown.Size = New System.Drawing.Size(36, 30)
        Me.bDown.TabIndex = 39
        Me.bDown.UseVisualStyleBackColor = true
        '
        'lblPrg
        '
        Me.lblPrg.AutoSize = true
        Me.lblPrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186,Byte))
        Me.lblPrg.Location = New System.Drawing.Point(249, 163)
        Me.lblPrg.Name = "lblPrg"
        Me.lblPrg.Size = New System.Drawing.Size(13, 16)
        Me.lblPrg.TabIndex = 40
        Me.lblPrg.Text = "-"
        '
        'Dialog1
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(600, 520)
        Me.Controls.Add(Me.lblPrg)
        Me.Controls.Add(Me.bDown)
        Me.Controls.Add(Me.bUp)
        Me.Controls.Add(Me.lPriority)
        Me.Controls.Add(Me.chkNext)
        Me.Controls.Add(Me.bAddPr)
        Me.Controls.Add(Me.bDelPr)
        Me.Controls.Add(Me.lPrs)
        Me.Controls.Add(Me.lRules)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gSlotMain)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ChkP)
        Me.Controls.Add(Me.ChkL)
        Me.Controls.Add(Me.ChkR)
        Me.Controls.Add(Me.ChkN)
        Me.Controls.Add(Me.ChkK)
        Me.Controls.Add(Me.ChkT)
        Me.Controls.Add(Me.chkE)
        Me.Controls.Add(Me.ChkTime)
        Me.Controls.Add(Me.dToDate)
        Me.Controls.Add(Me.dFromDate)
        Me.Controls.Add(Me.cToTime)
        Me.Controls.Add(Me.cFromTime)
        Me.Controls.Add(Me.cVias)
        Me.Controls.Add(Me.tToPart)
        Me.Controls.Add(Me.tFromPart)
        Me.Controls.Add(Me.tID)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.gSlotMain.ResumeLayout(false)
        Me.gSlotMain.PerformLayout
        Me.gSlotSelect.ResumeLayout(false)
        Me.gSlotSelect.PerformLayout
        CType(Me.nSpecial,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
	Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
	Friend WithEvents OK_Button As System.Windows.Forms.Button
	Friend WithEvents Cancel_Button As System.Windows.Forms.Button
	Friend WithEvents tID As System.Windows.Forms.TextBox
	Friend WithEvents tFromPart As System.Windows.Forms.TextBox
	Friend WithEvents tToPart As System.Windows.Forms.TextBox
	Friend WithEvents cVias As System.Windows.Forms.ComboBox
	Friend WithEvents cFromTime As System.Windows.Forms.ComboBox
	Friend WithEvents cToTime As System.Windows.Forms.ComboBox
	Friend WithEvents dFromDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents dToDate As System.Windows.Forms.DateTimePicker
	Friend WithEvents chkE As System.Windows.Forms.CheckBox
	Friend WithEvents ChkT As System.Windows.Forms.CheckBox
	Friend WithEvents ChkK As System.Windows.Forms.CheckBox
	Friend WithEvents ChkN As System.Windows.Forms.CheckBox
	Friend WithEvents ChkR As System.Windows.Forms.CheckBox
	Friend WithEvents ChkL As System.Windows.Forms.CheckBox
	Friend WithEvents ChkP As System.Windows.Forms.CheckBox
	Friend WithEvents ChkEnd As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents ChkTime As System.Windows.Forms.CheckBox
	Friend WithEvents chkManual As System.Windows.Forms.CheckBox
	Friend WithEvents bDel As System.Windows.Forms.Button
	Friend WithEvents bAll As System.Windows.Forms.Button
	Friend WithEvents gSlotMain As System.Windows.Forms.GroupBox
	Friend WithEvents nSpecial As System.Windows.Forms.NumericUpDown
	Friend WithEvents gSlotSelect As System.Windows.Forms.GroupBox
	Friend WithEvents ChkStart As System.Windows.Forms.CheckBox
	Friend WithEvents chkSpecial As System.Windows.Forms.CheckBox
	Friend WithEvents chkAllSlots As System.Windows.Forms.CheckBox
	Friend WithEvents chkSK As System.Windows.Forms.CheckBox
	Friend WithEvents lRules As System.Windows.Forms.ListBox
	Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
	Friend WithEvents lPrs As System.Windows.Forms.ListBox
	Friend WithEvents bDelPr As System.Windows.Forms.Button
	Friend WithEvents bAddPr As System.Windows.Forms.Button
	Friend WithEvents bPre As System.Windows.Forms.Button
	Friend WithEvents bPost As System.Windows.Forms.Button
	Friend WithEvents chkPostMain As System.Windows.Forms.CheckBox
	Friend WithEvents chkPreMain As System.Windows.Forms.CheckBox
	Friend WithEvents bEnd As System.Windows.Forms.Button
	Friend WithEvents bCntr As System.Windows.Forms.Button
	Friend WithEvents bBeg As System.Windows.Forms.Button
	Friend WithEvents chkEndMain As System.Windows.Forms.CheckBox
	Friend WithEvents chkCntrMain As System.Windows.Forms.CheckBox
	Friend WithEvents chkBegMain As System.Windows.Forms.CheckBox
	Friend WithEvents ChkFix As System.Windows.Forms.CheckBox
    Friend WithEvents tmFix As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNext As System.Windows.Forms.CheckBox
    Friend WithEvents lPriority As System.Windows.Forms.ListBox
    Friend WithEvents bUp As System.Windows.Forms.Button
    Friend WithEvents bDown As System.Windows.Forms.Button
    Friend WithEvents ChkDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents lblPrg As System.Windows.Forms.Label

End Class
