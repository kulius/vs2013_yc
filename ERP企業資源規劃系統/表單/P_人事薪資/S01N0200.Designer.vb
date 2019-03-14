<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S01N0200
    Inherits ERP企業資源規劃系統.fmBase1

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.車牌號碼 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.司機代號 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.分類 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.姓名 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.性別2 = New System.Windows.Forms.RadioButton()
        Me.性別1 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.出生日期 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.身份證號 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.員工代號 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.txtDataGridViewTitle = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.滲碳單價 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.調質單價 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.備註 = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.chk通訊地址 = New System.Windows.Forms.CheckBox()
        Me.通訊地址 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.戶籍地址 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.手機 = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.電話 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.籍貫 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.MainPanel.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.車牌號碼)
        Me.MainPanel.Controls.Add(Me.Label6)
        Me.MainPanel.Controls.Add(Me.司機代號)
        Me.MainPanel.Controls.Add(Me.Label4)
        Me.MainPanel.Controls.Add(Me.分類)
        Me.MainPanel.Controls.Add(Me.Label5)
        Me.MainPanel.Controls.Add(Me.姓名)
        Me.MainPanel.Controls.Add(Me.Label3)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 83)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1016, 50)
        Me.MainPanel.TabIndex = 16
        '
        '車牌號碼
        '
        Me.車牌號碼.Location = New System.Drawing.Point(345, 8)
        Me.車牌號碼.Name = "車牌號碼"
        Me.車牌號碼.Size = New System.Drawing.Size(150, 29)
        Me.車牌號碼.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(270, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "車牌號碼"
        '
        '司機代號
        '
        Me.司機代號.Location = New System.Drawing.Point(94, 8)
        Me.司機代號.Name = "司機代號"
        Me.司機代號.Size = New System.Drawing.Size(100, 29)
        Me.司機代號.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "司機代號"
        '
        '分類
        '
        Me.分類.FormattingEnabled = True
        Me.分類.Location = New System.Drawing.Point(847, 8)
        Me.分類.Name = "分類"
        Me.分類.Size = New System.Drawing.Size(150, 28)
        Me.分類.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(804, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "分類"
        '
        '姓名
        '
        Me.姓名.Location = New System.Drawing.Point(596, 8)
        Me.姓名.Name = "姓名"
        Me.姓名.Size = New System.Drawing.Size(150, 29)
        Me.姓名.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "姓名"
        '
        '性別2
        '
        Me.性別2.AutoSize = True
        Me.性別2.Location = New System.Drawing.Point(891, 22)
        Me.性別2.Name = "性別2"
        Me.性別2.Size = New System.Drawing.Size(43, 24)
        Me.性別2.TabIndex = 5
        Me.性別2.Text = "女"
        Me.性別2.UseVisualStyleBackColor = True
        '
        '性別1
        '
        Me.性別1.AutoSize = True
        Me.性別1.Checked = True
        Me.性別1.Location = New System.Drawing.Point(842, 22)
        Me.性別1.Name = "性別1"
        Me.性別1.Size = New System.Drawing.Size(43, 24)
        Me.性別1.TabIndex = 4
        Me.性別1.TabStop = True
        Me.性別1.Text = "男"
        Me.性別1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(799, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 20)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "性別"
        '
        '出生日期
        '
        Me.出生日期.Location = New System.Drawing.Point(591, 18)
        Me.出生日期.Name = "出生日期"
        Me.出生日期.Size = New System.Drawing.Size(170, 29)
        Me.出生日期.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(516, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "出生日期"
        '
        '身份證號
        '
        Me.身份證號.Location = New System.Drawing.Point(340, 21)
        Me.身份證號.Name = "身份證號"
        Me.身份證號.Size = New System.Drawing.Size(150, 29)
        Me.身份證號.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(265, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "身份證號"
        '
        '員工代號
        '
        Me.員工代號.Location = New System.Drawing.Point(89, 21)
        Me.員工代號.Name = "員工代號"
        Me.員工代號.Size = New System.Drawing.Size(100, 29)
        Me.員工代號.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "員工代號"
        '
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 133)
        Me.SplitContainer.Name = "SplitContainer"
        Me.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.BackColor = System.Drawing.Color.LavenderBlush
        Me.SplitContainer.Panel1.Controls.Add(Me.txtDataGridViewTitle)
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitContainer.Panel2.Controls.Add(Me.TabControl)
        Me.SplitContainer.Size = New System.Drawing.Size(1016, 380)
        Me.SplitContainer.SplitterDistance = 29
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 18
        '
        'txtDataGridViewTitle
        '
        Me.txtDataGridViewTitle.AutoSize = True
        Me.txtDataGridViewTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtDataGridViewTitle.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDataGridViewTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDataGridViewTitle.Location = New System.Drawing.Point(0, 0)
        Me.txtDataGridViewTitle.Name = "txtDataGridViewTitle"
        Me.txtDataGridViewTitle.Size = New System.Drawing.Size(122, 21)
        Me.txtDataGridViewTitle.TabIndex = 0
        Me.txtDataGridViewTitle.Text = "司機資料一覽表"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1012, 346)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1004, 313)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "司機資料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView.RowTemplate.Height = 24
        Me.DataGridView.Size = New System.Drawing.Size(998, 307)
        Me.DataGridView.TabIndex = 282
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.滲碳單價)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.調質單價)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.備註)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.chk通訊地址)
        Me.TabPage2.Controls.Add(Me.通訊地址)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.性別2)
        Me.TabPage2.Controls.Add(Me.性別1)
        Me.TabPage2.Controls.Add(Me.戶籍地址)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.手機)
        Me.TabPage2.Controls.Add(Me.出生日期)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.電話)
        Me.TabPage2.Controls.Add(Me.身份證號)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.員工代號)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.籍貫)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1003, 294)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "基本資料"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '滲碳單價
        '
        Me.滲碳單價.Location = New System.Drawing.Point(340, 161)
        Me.滲碳單價.Name = "滲碳單價"
        Me.滲碳單價.Size = New System.Drawing.Size(120, 29)
        Me.滲碳單價.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(265, 164)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 20)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "滲碳單價"
        '
        '調質單價
        '
        Me.調質單價.Location = New System.Drawing.Point(89, 161)
        Me.調質單價.Name = "調質單價"
        Me.調質單價.Size = New System.Drawing.Size(120, 29)
        Me.調質單價.TabIndex = 12
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 164)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 20)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "調質單價"
        '
        '備註
        '
        Me.備註.Location = New System.Drawing.Point(89, 196)
        Me.備註.Multiline = True
        Me.備註.Name = "備註"
        Me.備註.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.備註.Size = New System.Drawing.Size(421, 90)
        Me.備註.TabIndex = 14
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(46, 199)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(41, 20)
        Me.Label30.TabIndex = 51
        Me.Label30.Text = "備註"
        '
        'chk通訊地址
        '
        Me.chk通訊地址.AutoSize = True
        Me.chk通訊地址.Location = New System.Drawing.Point(514, 128)
        Me.chk通訊地址.Name = "chk通訊地址"
        Me.chk通訊地址.Size = New System.Drawing.Size(60, 24)
        Me.chk通訊地址.TabIndex = 11
        Me.chk通訊地址.Text = "同上"
        Me.chk通訊地址.UseVisualStyleBackColor = True
        '
        '通訊地址
        '
        Me.通訊地址.Location = New System.Drawing.Point(89, 126)
        Me.通訊地址.Name = "通訊地址"
        Me.通訊地址.Size = New System.Drawing.Size(421, 29)
        Me.通訊地址.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(14, 129)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 20)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "通訊地址"
        '
        '戶籍地址
        '
        Me.戶籍地址.Location = New System.Drawing.Point(89, 91)
        Me.戶籍地址.Name = "戶籍地址"
        Me.戶籍地址.Size = New System.Drawing.Size(421, 29)
        Me.戶籍地址.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 94)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 20)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "戶籍地址"
        '
        '手機
        '
        Me.手機.Location = New System.Drawing.Point(591, 56)
        Me.手機.Name = "手機"
        Me.手機.Size = New System.Drawing.Size(150, 29)
        Me.手機.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(516, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(73, 20)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "行動電話"
        '
        '電話
        '
        Me.電話.Location = New System.Drawing.Point(340, 56)
        Me.電話.Name = "電話"
        Me.電話.Size = New System.Drawing.Size(150, 29)
        Me.電話.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(265, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 20)
        Me.Label16.TabIndex = 21
        Me.Label16.Text = "聯絡電話"
        '
        '籍貫
        '
        Me.籍貫.Location = New System.Drawing.Point(89, 56)
        Me.籍貫.Name = "籍貫"
        Me.籍貫.Size = New System.Drawing.Size(100, 29)
        Me.籍貫.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(46, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "籍貫"
        '
        'S01N0200
        '
        Me.ClientSize = New System.Drawing.Size(1016, 538)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "S01N0200"
        Me.Controls.SetChildIndex(Me.MainPanel, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer, 0)
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents 性別2 As System.Windows.Forms.RadioButton
    Friend WithEvents 性別1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents 出生日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents 身份證號 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents 姓名 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 員工代號 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 分類 As System.Windows.Forms.ComboBox
    Friend WithEvents 司機代號 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 車牌號碼 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDataGridViewTitle As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents 備註 As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents chk通訊地址 As System.Windows.Forms.CheckBox
    Friend WithEvents 通訊地址 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents 戶籍地址 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents 手機 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents 電話 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents 籍貫 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents 滲碳單價 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents 調質單價 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
