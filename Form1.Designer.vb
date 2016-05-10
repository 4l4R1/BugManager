<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cMode = New System.Windows.Forms.ComboBox()
        Me.LstProgr = New System.Windows.Forms.ListView()
        Me.Time = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Title = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.bugs = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cDates = New System.Windows.Forms.ComboBox()
        Me.wbr = New System.Windows.Forms.WebBrowser()
        Me.bCopy = New System.Windows.Forms.Button()
        Me.cReport = New System.Windows.Forms.ComboBox()
        Me.bReport = New System.Windows.Forms.Button()
        Me.dRepFrom = New System.Windows.Forms.DateTimePicker()
        Me.dRepTo = New System.Windows.Forms.DateTimePicker()
        Me.Tab1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grCntrl = New System.Windows.Forms.GroupBox()
        Me.bRestore = New System.Windows.Forms.Button()
        Me.addMultiBug = New System.Windows.Forms.Button()
        Me.lInf = New System.Windows.Forms.Label()
        Me.bExmpl = New System.Windows.Forms.Button()
        Me.bk11test = New System.Windows.Forms.Button()
        Me.bk12test = New System.Windows.Forms.Button()
        Me.bk2test = New System.Windows.Forms.Button()
        Me.bSelDate = New System.Windows.Forms.Button()
        Me.bSelVia = New System.Windows.Forms.Button()
        Me.bAll = New System.Windows.Forms.Button()
        Me.bPlay = New System.Windows.Forms.Button()
        Me.Chk169 = New System.Windows.Forms.CheckBox()
        Me.bk2 = New System.Windows.Forms.Button()
        Me.bk11 = New System.Windows.Forms.Button()
        Me.bk12 = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.grStyle = New System.Windows.Forms.GroupBox()
        Me.addMultiStyle = New System.Windows.Forms.Button()
        Me.bSelDate2 = New System.Windows.Forms.Button()
        Me.bSelStyle = New System.Windows.Forms.Button()
        Me.bAll2 = New System.Windows.Forms.Button()
        Me.bStyleIdDel = New System.Windows.Forms.Button()
        Me.bStyleValueAdd = New System.Windows.Forms.Button()
        Me.bStyleIdAdd = New System.Windows.Forms.Button()
        Me.cStyleValue = New System.Windows.Forms.ComboBox()
        Me.cStyleId = New System.Windows.Forms.ComboBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.grBug = New System.Windows.Forms.GroupBox()
        Me.gSelect = New System.Windows.Forms.GroupBox()
        Me.rEtc = New System.Windows.Forms.RadioButton()
        Me.rSk = New System.Windows.Forms.RadioButton()
        Me.rBug = New System.Windows.Forms.RadioButton()
        Me.cXy = New System.Windows.Forms.CheckBox()
        Me.bExmplMaker = New System.Windows.Forms.Button()
        Me.gAlign = New System.Windows.Forms.GroupBox()
        Me.rRight = New System.Windows.Forms.RadioButton()
        Me.rCenter = New System.Windows.Forms.RadioButton()
        Me.rLeft = New System.Windows.Forms.RadioButton()
        Me.chk169only = New System.Windows.Forms.CheckBox()
        Me.chkVia = New System.Windows.Forms.CheckBox()
        Me.chkExample = New System.Windows.Forms.CheckBox()
        Me.cPos = New System.Windows.Forms.CheckBox()
        Me.bMakeVia = New System.Windows.Forms.Button()
        Me.chkWide = New System.Windows.Forms.CheckBox()
        Me.tDir = New System.Windows.Forms.TextBox()
        Me.bDir = New System.Windows.Forms.Button()
        Me.cVias = New System.Windows.Forms.ComboBox()
        Me.rK2 = New System.Windows.Forms.RadioButton()
        Me.Tab1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grCntrl.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.grStyle.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.grBug.SuspendLayout()
        Me.gSelect.SuspendLayout()
        Me.gAlign.SuspendLayout()
        Me.SuspendLayout()
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Originaalfailide asukoht"
        Me.FolderBrowserDialog1.SelectedPath = "E:\Eetrigraafika\bug"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'cMode
        '
        Me.cMode.FormattingEnabled = True
        Me.cMode.Location = New System.Drawing.Point(4, 12)
        Me.cMode.Name = "cMode"
        Me.cMode.Size = New System.Drawing.Size(165, 21)
        Me.cMode.TabIndex = 15
        '
        'LstProgr
        '
        Me.LstProgr.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Time, Me.ID, Me.Title, Me.bugs})
        Me.LstProgr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.LstProgr.FullRowSelect = True
        Me.LstProgr.GridLines = True
        Me.LstProgr.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LstProgr.Location = New System.Drawing.Point(505, 11)
        Me.LstProgr.Margin = New System.Windows.Forms.Padding(2)
        Me.LstProgr.Name = "LstProgr"
        Me.LstProgr.Size = New System.Drawing.Size(666, 591)
        Me.LstProgr.TabIndex = 18
        Me.LstProgr.UseCompatibleStateImageBehavior = False
        Me.LstProgr.View = System.Windows.Forms.View.Details
        '
        'Time
        '
        Me.Time.Text = "Aeg"
        Me.Time.Width = 48
        '
        'ID
        '
        Me.ID.Text = "ID"
        Me.ID.Width = 130
        '
        'Title
        '
        Me.Title.Text = "Saade"
        Me.Title.Width = 250
        '
        'bugs
        '
        Me.bugs.Text = "Bugid"
        Me.bugs.Width = 232
        '
        'cDates
        '
        Me.cDates.FormattingEnabled = True
        Me.cDates.Location = New System.Drawing.Point(380, 12)
        Me.cDates.Name = "cDates"
        Me.cDates.Size = New System.Drawing.Size(117, 21)
        Me.cDates.TabIndex = 19
        '
        'wbr
        '
        Me.wbr.Location = New System.Drawing.Point(4, 225)
        Me.wbr.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbr.Name = "wbr"
        Me.wbr.Size = New System.Drawing.Size(496, 340)
        Me.wbr.TabIndex = 25
        '
        'bCopy
        '
        Me.bCopy.Location = New System.Drawing.Point(451, 571)
        Me.bCopy.Name = "bCopy"
        Me.bCopy.Size = New System.Drawing.Size(46, 22)
        Me.bCopy.TabIndex = 26
        Me.bCopy.Text = "Copy"
        Me.bCopy.UseVisualStyleBackColor = True
        '
        'cReport
        '
        Me.cReport.FormattingEnabled = True
        Me.cReport.Location = New System.Drawing.Point(4, 573)
        Me.cReport.Name = "cReport"
        Me.cReport.Size = New System.Drawing.Size(123, 21)
        Me.cReport.TabIndex = 27
        '
        'bReport
        '
        Me.bReport.Location = New System.Drawing.Point(347, 572)
        Me.bReport.Name = "bReport"
        Me.bReport.Size = New System.Drawing.Size(51, 22)
        Me.bReport.TabIndex = 28
        Me.bReport.Text = "Report"
        Me.bReport.UseVisualStyleBackColor = True
        '
        'dRepFrom
        '
        Me.dRepFrom.CustomFormat = "yyyy.MM.dd"
        Me.dRepFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dRepFrom.Location = New System.Drawing.Point(133, 574)
        Me.dRepFrom.Name = "dRepFrom"
        Me.dRepFrom.Size = New System.Drawing.Size(101, 20)
        Me.dRepFrom.TabIndex = 29
        '
        'dRepTo
        '
        Me.dRepTo.CustomFormat = "yyyy.MM.dd"
        Me.dRepTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dRepTo.Location = New System.Drawing.Point(240, 574)
        Me.dRepTo.Name = "dRepTo"
        Me.dRepTo.Size = New System.Drawing.Size(101, 20)
        Me.dRepTo.TabIndex = 30
        '
        'Tab1
        '
        Me.Tab1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.Tab1.Controls.Add(Me.TabPage1)
        Me.Tab1.Controls.Add(Me.TabPage2)
        Me.Tab1.Controls.Add(Me.TabPage3)
        Me.Tab1.Location = New System.Drawing.Point(4, 39)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.SelectedIndex = 0
        Me.Tab1.Size = New System.Drawing.Size(496, 184)
        Me.Tab1.TabIndex = 32
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grCntrl)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(488, 155)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "bugmanager"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grCntrl
        '
        Me.grCntrl.Controls.Add(Me.bRestore)
        Me.grCntrl.Controls.Add(Me.addMultiBug)
        Me.grCntrl.Controls.Add(Me.lInf)
        Me.grCntrl.Controls.Add(Me.bExmpl)
        Me.grCntrl.Controls.Add(Me.bk11test)
        Me.grCntrl.Controls.Add(Me.bk12test)
        Me.grCntrl.Controls.Add(Me.bk2test)
        Me.grCntrl.Controls.Add(Me.bSelDate)
        Me.grCntrl.Controls.Add(Me.bSelVia)
        Me.grCntrl.Controls.Add(Me.bAll)
        Me.grCntrl.Controls.Add(Me.bPlay)
        Me.grCntrl.Controls.Add(Me.Chk169)
        Me.grCntrl.Controls.Add(Me.bk2)
        Me.grCntrl.Controls.Add(Me.bk11)
        Me.grCntrl.Controls.Add(Me.bk12)
        Me.grCntrl.Location = New System.Drawing.Point(6, 6)
        Me.grCntrl.Name = "grCntrl"
        Me.grCntrl.Size = New System.Drawing.Size(475, 143)
        Me.grCntrl.TabIndex = 25
        Me.grCntrl.TabStop = False
        '
        'bRestore
        '
        Me.bRestore.Location = New System.Drawing.Point(6, 87)
        Me.bRestore.Name = "bRestore"
        Me.bRestore.Size = New System.Drawing.Size(87, 23)
        Me.bRestore.TabIndex = 33
        Me.bRestore.Text = "Vanad bugid"
        Me.bRestore.UseVisualStyleBackColor = True
        '
        'addMultiBug
        '
        Me.addMultiBug.Location = New System.Drawing.Point(445, 11)
        Me.addMultiBug.Name = "addMultiBug"
        Me.addMultiBug.Size = New System.Drawing.Size(23, 117)
        Me.addMultiBug.TabIndex = 32
        Me.addMultiBug.Text = "------"
        Me.addMultiBug.UseVisualStyleBackColor = True
        '
        'lInf
        '
        Me.lInf.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lInf.AutoSize = True
        Me.lInf.Location = New System.Drawing.Point(116, 92)
        Me.lInf.Name = "lInf"
        Me.lInf.Size = New System.Drawing.Size(39, 13)
        Me.lInf.TabIndex = 31
        Me.lInf.Text = "Label1"
        Me.lInf.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'bExmpl
        '
        Me.bExmpl.Location = New System.Drawing.Point(6, 117)
        Me.bExmpl.Name = "bExmpl"
        Me.bExmpl.Size = New System.Drawing.Size(71, 21)
        Me.bExmpl.TabIndex = 30
        Me.bExmpl.Text = "Näidis"
        Me.bExmpl.UseVisualStyleBackColor = True
        '
        'bk11test
        '
        Me.bk11test.Location = New System.Drawing.Point(176, 46)
        Me.bk11test.Name = "bk11test"
        Me.bk11test.Size = New System.Drawing.Size(52, 21)
        Me.bk11test.TabIndex = 29
        Me.bk11test.Text = "test"
        Me.bk11test.UseVisualStyleBackColor = True
        Me.bk11test.Visible = False
        '
        'bk12test
        '
        Me.bk12test.Location = New System.Drawing.Point(234, 46)
        Me.bk12test.Name = "bk12test"
        Me.bk12test.Size = New System.Drawing.Size(52, 21)
        Me.bk12test.TabIndex = 28
        Me.bk12test.Text = "test"
        Me.bk12test.UseVisualStyleBackColor = True
        '
        'bk2test
        '
        Me.bk2test.Location = New System.Drawing.Point(118, 46)
        Me.bk2test.Name = "bk2test"
        Me.bk2test.Size = New System.Drawing.Size(52, 21)
        Me.bk2test.TabIndex = 27
        Me.bk2test.Text = "test"
        Me.bk2test.UseVisualStyleBackColor = True
        '
        'bSelDate
        '
        Me.bSelDate.Location = New System.Drawing.Point(328, 93)
        Me.bSelDate.Name = "bSelDate"
        Me.bSelDate.Size = New System.Drawing.Size(111, 35)
        Me.bSelDate.TabIndex = 22
        Me.bSelDate.Text = "valitud kuupäeva reeglid"
        Me.bSelDate.UseVisualStyleBackColor = True
        '
        'bSelVia
        '
        Me.bSelVia.Location = New System.Drawing.Point(328, 11)
        Me.bSelVia.Name = "bSelVia"
        Me.bSelVia.Size = New System.Drawing.Size(111, 35)
        Me.bSelVia.TabIndex = 21
        Me.bSelVia.Text = "valitud bugi reeglid"
        Me.bSelVia.UseVisualStyleBackColor = True
        '
        'bAll
        '
        Me.bAll.Location = New System.Drawing.Point(328, 52)
        Me.bAll.Name = "bAll"
        Me.bAll.Size = New System.Drawing.Size(111, 35)
        Me.bAll.TabIndex = 20
        Me.bAll.Text = "kõik reeglid"
        Me.bAll.UseVisualStyleBackColor = True
        '
        'bPlay
        '
        Me.bPlay.Location = New System.Drawing.Point(6, 18)
        Me.bPlay.Name = "bPlay"
        Me.bPlay.Size = New System.Drawing.Size(71, 21)
        Me.bPlay.TabIndex = 10
        Me.bPlay.Text = "Ekraanile"
        Me.bPlay.UseVisualStyleBackColor = True
        Me.bPlay.Visible = False
        '
        'Chk169
        '
        Me.Chk169.AutoSize = True
        Me.Chk169.Location = New System.Drawing.Point(6, 45)
        Me.Chk169.Name = "Chk169"
        Me.Chk169.Size = New System.Drawing.Size(47, 17)
        Me.Chk169.TabIndex = 9
        Me.Chk169.Text = "16:9"
        Me.Chk169.UseVisualStyleBackColor = True
        Me.Chk169.Visible = False
        '
        'bk2
        '
        Me.bk2.Location = New System.Drawing.Point(119, 18)
        Me.bk2.Name = "bk2"
        Me.bk2.Size = New System.Drawing.Size(51, 21)
        Me.bk2.TabIndex = 12
        Me.bk2.Text = "K2"
        Me.bk2.UseVisualStyleBackColor = True
        '
        'bk11
        '
        Me.bk11.Location = New System.Drawing.Point(176, 19)
        Me.bk11.Name = "bk11"
        Me.bk11.Size = New System.Drawing.Size(52, 21)
        Me.bk11.TabIndex = 13
        Me.bk11.Text = "K11"
        Me.bk11.UseVisualStyleBackColor = True
        '
        'bk12
        '
        Me.bk12.Location = New System.Drawing.Point(234, 19)
        Me.bk12.Name = "bk12"
        Me.bk12.Size = New System.Drawing.Size(52, 21)
        Me.bk12.TabIndex = 14
        Me.bk12.Text = "K12"
        Me.bk12.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.grStyle)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(488, 155)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "stylemanager"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'grStyle
        '
        Me.grStyle.Controls.Add(Me.addMultiStyle)
        Me.grStyle.Controls.Add(Me.bSelDate2)
        Me.grStyle.Controls.Add(Me.bSelStyle)
        Me.grStyle.Controls.Add(Me.bAll2)
        Me.grStyle.Controls.Add(Me.bStyleIdDel)
        Me.grStyle.Controls.Add(Me.bStyleValueAdd)
        Me.grStyle.Controls.Add(Me.bStyleIdAdd)
        Me.grStyle.Controls.Add(Me.cStyleValue)
        Me.grStyle.Controls.Add(Me.cStyleId)
        Me.grStyle.Location = New System.Drawing.Point(6, 6)
        Me.grStyle.Name = "grStyle"
        Me.grStyle.Size = New System.Drawing.Size(475, 143)
        Me.grStyle.TabIndex = 32
        Me.grStyle.TabStop = False
        '
        'addMultiStyle
        '
        Me.addMultiStyle.Location = New System.Drawing.Point(445, 11)
        Me.addMultiStyle.Name = "addMultiStyle"
        Me.addMultiStyle.Size = New System.Drawing.Size(23, 117)
        Me.addMultiStyle.TabIndex = 35
        Me.addMultiStyle.Text = "------"
        Me.addMultiStyle.UseVisualStyleBackColor = True
        '
        'bSelDate2
        '
        Me.bSelDate2.Location = New System.Drawing.Point(328, 92)
        Me.bSelDate2.Name = "bSelDate2"
        Me.bSelDate2.Size = New System.Drawing.Size(111, 35)
        Me.bSelDate2.TabIndex = 32
        Me.bSelDate2.Text = "valitud kuupäeva reeglid"
        Me.bSelDate2.UseVisualStyleBackColor = True
        '
        'bSelStyle
        '
        Me.bSelStyle.Location = New System.Drawing.Point(328, 51)
        Me.bSelStyle.Name = "bSelStyle"
        Me.bSelStyle.Size = New System.Drawing.Size(111, 35)
        Me.bSelStyle.TabIndex = 31
        Me.bSelStyle.Text = "valitud style reeglid"
        Me.bSelStyle.UseVisualStyleBackColor = True
        '
        'bAll2
        '
        Me.bAll2.Location = New System.Drawing.Point(328, 11)
        Me.bAll2.Name = "bAll2"
        Me.bAll2.Size = New System.Drawing.Size(111, 35)
        Me.bAll2.TabIndex = 30
        Me.bAll2.Text = "kõik reeglid"
        Me.bAll2.UseVisualStyleBackColor = True
        '
        'bStyleIdDel
        '
        Me.bStyleIdDel.Enabled = False
        Me.bStyleIdDel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.bStyleIdDel.Location = New System.Drawing.Point(61, 16)
        Me.bStyleIdDel.Name = "bStyleIdDel"
        Me.bStyleIdDel.Size = New System.Drawing.Size(25, 25)
        Me.bStyleIdDel.TabIndex = 34
        Me.bStyleIdDel.Text = "-"
        Me.bStyleIdDel.UseVisualStyleBackColor = True
        '
        'bStyleValueAdd
        '
        Me.bStyleValueAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.bStyleValueAdd.Location = New System.Drawing.Point(92, 57)
        Me.bStyleValueAdd.Name = "bStyleValueAdd"
        Me.bStyleValueAdd.Size = New System.Drawing.Size(25, 25)
        Me.bStyleValueAdd.TabIndex = 33
        Me.bStyleValueAdd.Text = "+"
        Me.bStyleValueAdd.UseVisualStyleBackColor = True
        '
        'bStyleIdAdd
        '
        Me.bStyleIdAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(186, Byte))
        Me.bStyleIdAdd.Location = New System.Drawing.Point(92, 16)
        Me.bStyleIdAdd.Name = "bStyleIdAdd"
        Me.bStyleIdAdd.Size = New System.Drawing.Size(25, 25)
        Me.bStyleIdAdd.TabIndex = 32
        Me.bStyleIdAdd.Text = "+"
        Me.bStyleIdAdd.UseVisualStyleBackColor = True
        '
        'cStyleValue
        '
        Me.cStyleValue.FormattingEnabled = True
        Me.cStyleValue.Location = New System.Drawing.Point(123, 59)
        Me.cStyleValue.Name = "cStyleValue"
        Me.cStyleValue.Size = New System.Drawing.Size(199, 21)
        Me.cStyleValue.TabIndex = 31
        '
        'cStyleId
        '
        Me.cStyleId.FormattingEnabled = True
        Me.cStyleId.Location = New System.Drawing.Point(123, 19)
        Me.cStyleId.Name = "cStyleId"
        Me.cStyleId.Size = New System.Drawing.Size(199, 21)
        Me.cStyleId.TabIndex = 30
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.grBug)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(488, 155)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "bugmaker"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'grBug
        '
        Me.grBug.Controls.Add(Me.gSelect)
        Me.grBug.Controls.Add(Me.cXy)
        Me.grBug.Controls.Add(Me.bExmplMaker)
        Me.grBug.Controls.Add(Me.gAlign)
        Me.grBug.Controls.Add(Me.chk169only)
        Me.grBug.Controls.Add(Me.chkVia)
        Me.grBug.Controls.Add(Me.chkExample)
        Me.grBug.Controls.Add(Me.cPos)
        Me.grBug.Controls.Add(Me.bMakeVia)
        Me.grBug.Controls.Add(Me.chkWide)
        Me.grBug.Controls.Add(Me.tDir)
        Me.grBug.Controls.Add(Me.bDir)
        Me.grBug.Location = New System.Drawing.Point(6, 6)
        Me.grBug.Name = "grBug"
        Me.grBug.Size = New System.Drawing.Size(475, 143)
        Me.grBug.TabIndex = 18
        Me.grBug.TabStop = False
        '
        'gSelect
        '
        Me.gSelect.Controls.Add(Me.rK2)
        Me.gSelect.Controls.Add(Me.rEtc)
        Me.gSelect.Controls.Add(Me.rSk)
        Me.gSelect.Controls.Add(Me.rBug)
        Me.gSelect.Location = New System.Drawing.Point(242, 101)
        Me.gSelect.Name = "gSelect"
        Me.gSelect.Size = New System.Drawing.Size(227, 37)
        Me.gSelect.TabIndex = 36
        Me.gSelect.TabStop = False
        Me.gSelect.Text = "Renderduse tüüp"
        '
        'rEtc
        '
        Me.rEtc.AutoSize = True
        Me.rEtc.Location = New System.Drawing.Point(181, 14)
        Me.rEtc.Name = "rEtc"
        Me.rEtc.Size = New System.Drawing.Size(40, 17)
        Me.rEtc.TabIndex = 34
        Me.rEtc.TabStop = True
        Me.rEtc.Text = "etc"
        Me.rEtc.UseVisualStyleBackColor = True
        '
        'rSk
        '
        Me.rSk.AutoSize = True
        Me.rSk.Location = New System.Drawing.Point(56, 16)
        Me.rSk.Name = "rSk"
        Me.rSk.Size = New System.Drawing.Size(39, 17)
        Me.rSk.TabIndex = 33
        Me.rSk.TabStop = True
        Me.rSk.Text = "SK"
        Me.rSk.UseVisualStyleBackColor = True
        '
        'rBug
        '
        Me.rBug.AutoSize = True
        Me.rBug.Location = New System.Drawing.Point(6, 15)
        Me.rBug.Name = "rBug"
        Me.rBug.Size = New System.Drawing.Size(44, 17)
        Me.rBug.TabIndex = 32
        Me.rBug.TabStop = True
        Me.rBug.Text = "Bug"
        Me.rBug.UseVisualStyleBackColor = True
        '
        'cXy
        '
        Me.cXy.AutoSize = True
        Me.cXy.Location = New System.Drawing.Point(180, 61)
        Me.cXy.Name = "cXy"
        Me.cXy.Size = New System.Drawing.Size(102, 17)
        Me.cXy.TabIndex = 35
        Me.cXy.Text = "Ainult positsioon"
        Me.cXy.UseVisualStyleBackColor = True
        Me.cXy.Visible = False
        '
        'bExmplMaker
        '
        Me.bExmplMaker.Location = New System.Drawing.Point(6, 117)
        Me.bExmplMaker.Name = "bExmplMaker"
        Me.bExmplMaker.Size = New System.Drawing.Size(71, 21)
        Me.bExmplMaker.TabIndex = 34
        Me.bExmplMaker.Text = "Näidis"
        Me.bExmplMaker.UseVisualStyleBackColor = True
        '
        'gAlign
        '
        Me.gAlign.Controls.Add(Me.rRight)
        Me.gAlign.Controls.Add(Me.rCenter)
        Me.gAlign.Controls.Add(Me.rLeft)
        Me.gAlign.Location = New System.Drawing.Point(88, 101)
        Me.gAlign.Name = "gAlign"
        Me.gAlign.Size = New System.Drawing.Size(132, 37)
        Me.gAlign.TabIndex = 31
        Me.gAlign.TabStop = False
        Me.gAlign.Text = "4:3 Joondus"
        '
        'rRight
        '
        Me.rRight.AutoSize = True
        Me.rRight.Location = New System.Drawing.Point(95, 16)
        Me.rRight.Name = "rRight"
        Me.rRight.Size = New System.Drawing.Size(36, 17)
        Me.rRight.TabIndex = 34
        Me.rRight.TabStop = True
        Me.rRight.Text = "->|"
        Me.rRight.UseVisualStyleBackColor = True
        '
        'rCenter
        '
        Me.rCenter.AutoSize = True
        Me.rCenter.Location = New System.Drawing.Point(48, 16)
        Me.rCenter.Name = "rCenter"
        Me.rCenter.Size = New System.Drawing.Size(41, 17)
        Me.rCenter.TabIndex = 33
        Me.rCenter.TabStop = True
        Me.rCenter.Text = "|<>|"
        Me.rCenter.UseVisualStyleBackColor = True
        '
        'rLeft
        '
        Me.rLeft.AutoSize = True
        Me.rLeft.Location = New System.Drawing.Point(6, 16)
        Me.rLeft.Name = "rLeft"
        Me.rLeft.Size = New System.Drawing.Size(36, 17)
        Me.rLeft.TabIndex = 32
        Me.rLeft.TabStop = True
        Me.rLeft.Text = "|<-"
        Me.rLeft.UseVisualStyleBackColor = True
        '
        'chk169only
        '
        Me.chk169only.AutoSize = True
        Me.chk169only.Location = New System.Drawing.Point(366, 80)
        Me.chk169only.Name = "chk169only"
        Me.chk169only.Size = New System.Drawing.Size(75, 17)
        Me.chk169only.TabIndex = 29
        Me.chk169only.Text = "ainult 16:9"
        Me.chk169only.UseVisualStyleBackColor = True
        '
        'chkVia
        '
        Me.chkVia.AutoSize = True
        Me.chkVia.Checked = True
        Me.chkVia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVia.Location = New System.Drawing.Point(366, 41)
        Me.chkVia.Name = "chkVia"
        Me.chkVia.Size = New System.Drawing.Size(53, 17)
        Me.chkVia.TabIndex = 24
        Me.chkVia.Text = "Video"
        Me.chkVia.UseVisualStyleBackColor = True
        '
        'chkExample
        '
        Me.chkExample.AutoSize = True
        Me.chkExample.Checked = True
        Me.chkExample.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkExample.Location = New System.Drawing.Point(366, 61)
        Me.chkExample.Name = "chkExample"
        Me.chkExample.Size = New System.Drawing.Size(55, 17)
        Me.chkExample.TabIndex = 23
        Me.chkExample.Text = "Näidis"
        Me.chkExample.UseVisualStyleBackColor = True
        '
        'cPos
        '
        Me.cPos.AutoSize = True
        Me.cPos.Location = New System.Drawing.Point(180, 41)
        Me.cPos.Name = "cPos"
        Me.cPos.Size = New System.Drawing.Size(167, 17)
        Me.cPos.TabIndex = 15
        Me.cPos.Text = "Suuruse/positsiooni muutmine"
        Me.cPos.UseVisualStyleBackColor = True
        '
        'bMakeVia
        '
        Me.bMakeVia.Location = New System.Drawing.Point(358, 9)
        Me.bMakeVia.Name = "bMakeVia"
        Me.bMakeVia.Size = New System.Drawing.Size(111, 30)
        Me.bMakeVia.TabIndex = 6
        Me.bMakeVia.Text = "Render"
        Me.bMakeVia.UseVisualStyleBackColor = True
        '
        'chkWide
        '
        Me.chkWide.AutoSize = True
        Me.chkWide.Location = New System.Drawing.Point(6, 41)
        Me.chkWide.Name = "chkWide"
        Me.chkWide.Size = New System.Drawing.Size(168, 17)
        Me.chkWide.TabIndex = 7
        Me.chkWide.Text = "originaal  on 16:9 (720 kaadril)"
        Me.chkWide.UseVisualStyleBackColor = True
        '
        'tDir
        '
        Me.tDir.Location = New System.Drawing.Point(6, 15)
        Me.tDir.Name = "tDir"
        Me.tDir.Size = New System.Drawing.Size(310, 20)
        Me.tDir.TabIndex = 0
        '
        'bDir
        '
        Me.bDir.Image = Global.eg2012.My.Resources.Resources.folder_open
        Me.bDir.Location = New System.Drawing.Point(322, 9)
        Me.bDir.Name = "bDir"
        Me.bDir.Size = New System.Drawing.Size(30, 30)
        Me.bDir.TabIndex = 1
        Me.bDir.UseVisualStyleBackColor = True
        '
        'cVias
        '
        Me.cVias.FormattingEnabled = True
        Me.cVias.Location = New System.Drawing.Point(175, 12)
        Me.cVias.Name = "cVias"
        Me.cVias.Size = New System.Drawing.Size(199, 21)
        Me.cVias.TabIndex = 11
        '
        'rK2
        '
        Me.rK2.AutoSize = True
        Me.rK2.Location = New System.Drawing.Point(101, 14)
        Me.rK2.Name = "rK2"
        Me.rK2.Size = New System.Drawing.Size(60, 17)
        Me.rK2.TabIndex = 35
        Me.rK2.TabStop = True
        Me.rK2.Text = "k2 logo"
        Me.rK2.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1177, 607)
        Me.Controls.Add(Me.Tab1)
        Me.Controls.Add(Me.dRepTo)
        Me.Controls.Add(Me.dRepFrom)
        Me.Controls.Add(Me.bReport)
        Me.Controls.Add(Me.cReport)
        Me.Controls.Add(Me.bCopy)
        Me.Controls.Add(Me.wbr)
        Me.Controls.Add(Me.cDates)
        Me.Controls.Add(Me.cVias)
        Me.Controls.Add(Me.LstProgr)
        Me.Controls.Add(Me.cMode)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Bug Manager"
        Me.Tab1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.grCntrl.ResumeLayout(False)
        Me.grCntrl.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.grStyle.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.grBug.ResumeLayout(False)
        Me.grBug.PerformLayout()
        Me.gSelect.ResumeLayout(False)
        Me.gSelect.PerformLayout()
        Me.gAlign.ResumeLayout(False)
        Me.gAlign.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents cMode As System.Windows.Forms.ComboBox
    Friend WithEvents LstProgr As System.Windows.Forms.ListView
    Friend WithEvents Time As System.Windows.Forms.ColumnHeader
    Friend WithEvents ID As System.Windows.Forms.ColumnHeader
    Friend WithEvents Title As System.Windows.Forms.ColumnHeader
    Friend WithEvents bugs As System.Windows.Forms.ColumnHeader
    Friend WithEvents cDates As System.Windows.Forms.ComboBox
    Friend WithEvents wbr As System.Windows.Forms.WebBrowser
    Friend WithEvents bCopy As System.Windows.Forms.Button
    Friend WithEvents cReport As System.Windows.Forms.ComboBox
    Friend WithEvents bReport As System.Windows.Forms.Button
    Friend WithEvents dRepFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dRepTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Tab1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grCntrl As System.Windows.Forms.GroupBox
    Friend WithEvents bRestore As System.Windows.Forms.Button
    Friend WithEvents addMultiBug As System.Windows.Forms.Button
    Friend WithEvents lInf As System.Windows.Forms.Label
    Friend WithEvents bExmpl As System.Windows.Forms.Button
    Friend WithEvents bk11test As System.Windows.Forms.Button
    Friend WithEvents bk12test As System.Windows.Forms.Button
    Friend WithEvents bk2test As System.Windows.Forms.Button
    Friend WithEvents bSelDate As System.Windows.Forms.Button
    Friend WithEvents cVias As System.Windows.Forms.ComboBox
    Friend WithEvents bSelVia As System.Windows.Forms.Button
    Friend WithEvents bAll As System.Windows.Forms.Button
    Friend WithEvents bPlay As System.Windows.Forms.Button
    Friend WithEvents Chk169 As System.Windows.Forms.CheckBox
    Friend WithEvents bk2 As System.Windows.Forms.Button
    Friend WithEvents bk11 As System.Windows.Forms.Button
    Friend WithEvents bk12 As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grStyle As System.Windows.Forms.GroupBox
    Friend WithEvents addMultiStyle As System.Windows.Forms.Button
    Friend WithEvents bSelDate2 As System.Windows.Forms.Button
    Friend WithEvents bSelStyle As System.Windows.Forms.Button
    Friend WithEvents bAll2 As System.Windows.Forms.Button
    Friend WithEvents bStyleIdDel As System.Windows.Forms.Button
    Friend WithEvents bStyleValueAdd As System.Windows.Forms.Button
    Friend WithEvents bStyleIdAdd As System.Windows.Forms.Button
    Friend WithEvents cStyleValue As System.Windows.Forms.ComboBox
    Friend WithEvents cStyleId As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents grBug As System.Windows.Forms.GroupBox
    Friend WithEvents gAlign As System.Windows.Forms.GroupBox
    Friend WithEvents rRight As System.Windows.Forms.RadioButton
    Friend WithEvents rCenter As System.Windows.Forms.RadioButton
    Friend WithEvents rLeft As System.Windows.Forms.RadioButton
    Friend WithEvents chk169only As System.Windows.Forms.CheckBox
    Friend WithEvents chkVia As System.Windows.Forms.CheckBox
    Friend WithEvents chkExample As System.Windows.Forms.CheckBox
    Friend WithEvents cPos As System.Windows.Forms.CheckBox
    Friend WithEvents bMakeVia As System.Windows.Forms.Button
    Friend WithEvents chkWide As System.Windows.Forms.CheckBox
    Friend WithEvents tDir As System.Windows.Forms.TextBox
    Friend WithEvents bDir As System.Windows.Forms.Button
    Friend WithEvents bExmplMaker As Button
    Friend WithEvents cXy As CheckBox
    Friend WithEvents gSelect As GroupBox
    Friend WithEvents rEtc As RadioButton
    Friend WithEvents rSk As RadioButton
    Friend WithEvents rBug As RadioButton
    Friend WithEvents rK2 As RadioButton
End Class
