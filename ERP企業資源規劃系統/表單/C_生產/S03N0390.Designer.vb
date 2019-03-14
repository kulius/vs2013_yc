<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N0390
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.OutDataDGV = New System.Windows.Forms.DataGridView()
        Me.貨單序號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.出貨日期 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.工令號碼 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.品名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.規格 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.材質 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.加工方式 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.電鍍別 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後總重 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.單價 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.小計 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.報價單價 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.長度 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.司機姓名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後桶數 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.爐號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.客戶工令 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.單位 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.次加工廠商 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.牙分類 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.二次廠商 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.進貨日期 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.線材爐號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.客戶 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.備註 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.憑單號碼 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.序號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CK含稅 = New System.Windows.Forms.CheckBox()
        Me.t總金額 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.t含稅 = New System.Windows.Forms.TextBox()
        Me.t金額 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.t重量 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.t筆數 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.PreviewControl2 = New FastReport.Preview.PreviewControl()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.CK司機代號 = New System.Windows.Forms.CheckBox()
        Me.CK貨單序號 = New System.Windows.Forms.CheckBox()
        Me.LB結帳日 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSerach = New System.Windows.Forms.Button()
        Me.出貨日期迄 = New System.Windows.Forms.DateTimePicker()
        Me.出貨日期起 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.s客戶代碼 = New System.Windows.Forms.TextBox()
        Me.s客戶代號 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAutoPrice = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.OutDataDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 163)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(941, 390)
        Me.TabControl1.TabIndex = 33
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.OutDataDGV)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(933, 357)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "出貨記錄"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'OutDataDGV
        '
        Me.OutDataDGV.AllowUserToAddRows = False
        Me.OutDataDGV.AllowUserToDeleteRows = False
        Me.OutDataDGV.AllowUserToOrderColumns = True
        DataGridViewCellStyle7.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.OutDataDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.OutDataDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OutDataDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.OutDataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutDataDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.貨單序號, Me.出貨日期, Me.工令號碼, Me.品名, Me.規格, Me.材質, Me.加工方式, Me.電鍍別, Me.磅後總重, Me.單價, Me.小計, Me.報價單價, Me.長度, Me.司機姓名, Me.磅後桶數, Me.爐號, Me.客戶工令, Me.單位, Me.次加工廠商, Me.牙分類, Me.二次廠商, Me.進貨日期, Me.線材爐號, Me.客戶, Me.備註, Me.憑單號碼, Me.序號})
        Me.OutDataDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutDataDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.OutDataDGV.Location = New System.Drawing.Point(0, 0)
        Me.OutDataDGV.Name = "OutDataDGV"
        DataGridViewCellStyle12.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.OutDataDGV.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.OutDataDGV.RowTemplate.Height = 24
        Me.OutDataDGV.Size = New System.Drawing.Size(933, 284)
        Me.OutDataDGV.TabIndex = 289
        '
        '貨單序號
        '
        Me.貨單序號.HeaderText = "貨單序號"
        Me.貨單序號.Name = "貨單序號"
        Me.貨單序號.ReadOnly = True
        Me.貨單序號.Width = 80
        '
        '出貨日期
        '
        Me.出貨日期.HeaderText = "出貨日期"
        Me.出貨日期.Name = "出貨日期"
        Me.出貨日期.ReadOnly = True
        '
        '工令號碼
        '
        Me.工令號碼.HeaderText = "工令號碼"
        Me.工令號碼.Name = "工令號碼"
        Me.工令號碼.ReadOnly = True
        Me.工令號碼.Width = 80
        '
        '品名
        '
        Me.品名.HeaderText = "品名"
        Me.品名.Name = "品名"
        Me.品名.ReadOnly = True
        '
        '規格
        '
        Me.規格.HeaderText = "規格"
        Me.規格.Name = "規格"
        Me.規格.ReadOnly = True
        Me.規格.Width = 150
        '
        '材質
        '
        Me.材質.HeaderText = "材質"
        Me.材質.Name = "材質"
        Me.材質.ReadOnly = True
        Me.材質.Width = 80
        '
        '加工方式
        '
        Me.加工方式.HeaderText = "加工方式"
        Me.加工方式.Name = "加工方式"
        Me.加工方式.ReadOnly = True
        Me.加工方式.Width = 80
        '
        '電鍍別
        '
        Me.電鍍別.HeaderText = "電鍍別"
        Me.電鍍別.Name = "電鍍別"
        Me.電鍍別.ReadOnly = True
        Me.電鍍別.Width = 80
        '
        '磅後總重
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.磅後總重.DefaultCellStyle = DataGridViewCellStyle9
        Me.磅後總重.HeaderText = "磅後總重"
        Me.磅後總重.Name = "磅後總重"
        Me.磅後總重.ReadOnly = True
        Me.磅後總重.Width = 80
        '
        '單價
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.單價.DefaultCellStyle = DataGridViewCellStyle10
        Me.單價.HeaderText = "單價"
        Me.單價.Name = "單價"
        Me.單價.Width = 80
        '
        '小計
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.小計.DefaultCellStyle = DataGridViewCellStyle11
        Me.小計.HeaderText = "小計"
        Me.小計.Name = "小計"
        Me.小計.Width = 80
        '
        '報價單價
        '
        Me.報價單價.HeaderText = "報價單價"
        Me.報價單價.Name = "報價單價"
        Me.報價單價.ReadOnly = True
        Me.報價單價.Width = 80
        '
        '長度
        '
        Me.長度.HeaderText = "長度"
        Me.長度.Name = "長度"
        Me.長度.ReadOnly = True
        Me.長度.Width = 80
        '
        '司機姓名
        '
        Me.司機姓名.HeaderText = "司機姓名"
        Me.司機姓名.Name = "司機姓名"
        Me.司機姓名.ReadOnly = True
        '
        '磅後桶數
        '
        Me.磅後桶數.HeaderText = "磅後桶數"
        Me.磅後桶數.Name = "磅後桶數"
        Me.磅後桶數.ReadOnly = True
        Me.磅後桶數.Width = 80
        '
        '爐號
        '
        Me.爐號.HeaderText = "爐號"
        Me.爐號.Name = "爐號"
        Me.爐號.ReadOnly = True
        Me.爐號.Width = 40
        '
        '客戶工令
        '
        Me.客戶工令.HeaderText = "客戶工令"
        Me.客戶工令.Name = "客戶工令"
        Me.客戶工令.ReadOnly = True
        '
        '單位
        '
        Me.單位.HeaderText = "單位"
        Me.單位.Name = "單位"
        Me.單位.ReadOnly = True
        Me.單位.Width = 40
        '
        '次加工廠商
        '
        Me.次加工廠商.HeaderText = "次加工廠商"
        Me.次加工廠商.Name = "次加工廠商"
        Me.次加工廠商.ReadOnly = True
        Me.次加工廠商.Width = 90
        '
        '牙分類
        '
        Me.牙分類.HeaderText = "牙分類"
        Me.牙分類.Name = "牙分類"
        Me.牙分類.ReadOnly = True
        Me.牙分類.Width = 80
        '
        '二次廠商
        '
        Me.二次廠商.HeaderText = "二次廠商"
        Me.二次廠商.Name = "二次廠商"
        Me.二次廠商.ReadOnly = True
        Me.二次廠商.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.二次廠商.Width = 80
        '
        '進貨日期
        '
        Me.進貨日期.HeaderText = "進貨日期"
        Me.進貨日期.Name = "進貨日期"
        Me.進貨日期.ReadOnly = True
        Me.進貨日期.Width = 80
        '
        '線材爐號
        '
        Me.線材爐號.HeaderText = "線材爐號"
        Me.線材爐號.Name = "線材爐號"
        Me.線材爐號.ReadOnly = True
        Me.線材爐號.Width = 80
        '
        '客戶
        '
        Me.客戶.HeaderText = "客戶"
        Me.客戶.Name = "客戶"
        Me.客戶.ReadOnly = True
        '
        '備註
        '
        Me.備註.HeaderText = "備註"
        Me.備註.Name = "備註"
        '
        '憑單號碼
        '
        Me.憑單號碼.HeaderText = "憑單號碼"
        Me.憑單號碼.Name = "憑單號碼"
        '
        '序號
        '
        Me.序號.HeaderText = "序號"
        Me.序號.Name = "序號"
        Me.序號.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CK含稅)
        Me.Panel1.Controls.Add(Me.t總金額)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.t含稅)
        Me.Panel1.Controls.Add(Me.t金額)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.t重量)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.t筆數)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 284)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(933, 73)
        Me.Panel1.TabIndex = 290
        '
        'CK含稅
        '
        Me.CK含稅.AutoSize = True
        Me.CK含稅.Location = New System.Drawing.Point(405, 43)
        Me.CK含稅.Name = "CK含稅"
        Me.CK含稅.Size = New System.Drawing.Size(60, 24)
        Me.CK含稅.TabIndex = 265
        Me.CK含稅.Text = "含稅"
        Me.CK含稅.UseVisualStyleBackColor = True
        '
        't總金額
        '
        Me.t總金額.Enabled = False
        Me.t總金額.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.t總金額.Location = New System.Drawing.Point(675, 41)
        Me.t總金額.Name = "t總金額"
        Me.t總金額.Size = New System.Drawing.Size(101, 29)
        Me.t總金額.TabIndex = 264
        Me.t總金額.Tag = ""
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(598, 45)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 20)
        Me.Label9.TabIndex = 263
        Me.Label9.Text = "總金額"
        '
        't含稅
        '
        Me.t含稅.Enabled = False
        Me.t含稅.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.t含稅.Location = New System.Drawing.Point(484, 41)
        Me.t含稅.Name = "t含稅"
        Me.t含稅.Size = New System.Drawing.Size(101, 29)
        Me.t含稅.TabIndex = 262
        Me.t含稅.Tag = ""
        '
        't金額
        '
        Me.t金額.Enabled = False
        Me.t金額.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.t金額.Location = New System.Drawing.Point(274, 41)
        Me.t金額.Name = "t金額"
        Me.t金額.Size = New System.Drawing.Size(101, 29)
        Me.t金額.TabIndex = 260
        Me.t金額.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(233, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(41, 20)
        Me.Label7.TabIndex = 259
        Me.Label7.Text = "金額"
        '
        't重量
        '
        Me.t重量.Enabled = False
        Me.t重量.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.t重量.Location = New System.Drawing.Point(484, 9)
        Me.t重量.Name = "t重量"
        Me.t重量.Size = New System.Drawing.Size(101, 29)
        Me.t重量.TabIndex = 258
        Me.t重量.Tag = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(405, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 257
        Me.Label6.Text = "重量合計"
        '
        't筆數
        '
        Me.t筆數.Enabled = False
        Me.t筆數.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.t筆數.Location = New System.Drawing.Point(274, 9)
        Me.t筆數.Name = "t筆數"
        Me.t筆數.Size = New System.Drawing.Size(101, 29)
        Me.t筆數.TabIndex = 256
        Me.t筆數.Tag = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(233, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 20)
        Me.Label5.TabIndex = 255
        Me.Label5.Text = "筆數"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(933, 357)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "客戶單價"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.PreviewControl1)
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(933, 357)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "出貨統計表"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(3, 47)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(927, 307)
        Me.PreviewControl1.TabIndex = 3
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnPreviewRep)
        Me.Panel2.Controls.Add(Me.btnDesignRep)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 44)
        Me.Panel2.TabIndex = 4
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(39, 3)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(101, 37)
        Me.btnPreviewRep.TabIndex = 3
        Me.btnPreviewRep.Text = "預覽報表"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(167, 3)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(101, 37)
        Me.btnDesignRep.TabIndex = 1
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.PreviewControl2)
        Me.TabPage4.Controls.Add(Me.Panel3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(933, 357)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "發票明細"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'PreviewControl2
        '
        Me.PreviewControl2.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl2.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl2.Location = New System.Drawing.Point(3, 47)
        Me.PreviewControl2.Name = "PreviewControl2"
        Me.PreviewControl2.Size = New System.Drawing.Size(927, 307)
        Me.PreviewControl2.TabIndex = 5
        Me.PreviewControl2.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(927, 44)
        Me.Panel3.TabIndex = 6
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(39, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 37)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "預覽報表"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(167, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(101, 37)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "設計報表"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.btnAutoPrice)
        Me.MainPanel.Controls.Add(Me.CK司機代號)
        Me.MainPanel.Controls.Add(Me.CK貨單序號)
        Me.MainPanel.Controls.Add(Me.LB結帳日)
        Me.MainPanel.Controls.Add(Me.Label3)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.btnSerach)
        Me.MainPanel.Controls.Add(Me.出貨日期迄)
        Me.MainPanel.Controls.Add(Me.出貨日期起)
        Me.MainPanel.Controls.Add(Me.Label4)
        Me.MainPanel.Controls.Add(Me.s客戶代碼)
        Me.MainPanel.Controls.Add(Me.s客戶代號)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 83)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(941, 80)
        Me.MainPanel.TabIndex = 34
        '
        'CK司機代號
        '
        Me.CK司機代號.AutoSize = True
        Me.CK司機代號.Checked = True
        Me.CK司機代號.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK司機代號.Location = New System.Drawing.Point(323, 51)
        Me.CK司機代號.Name = "CK司機代號"
        Me.CK司機代號.Size = New System.Drawing.Size(214, 24)
        Me.CK司機代號.TabIndex = 263
        Me.CK司機代號.Text = "不含未出貨(司機代號為空)"
        Me.CK司機代號.UseVisualStyleBackColor = True
        '
        'CK貨單序號
        '
        Me.CK貨單序號.AutoSize = True
        Me.CK貨單序號.Location = New System.Drawing.Point(129, 51)
        Me.CK貨單序號.Name = "CK貨單序號"
        Me.CK貨單序號.Size = New System.Drawing.Size(188, 24)
        Me.CK貨單序號.TabIndex = 262
        Me.CK貨單序號.Text = "不含已列應收帳款貨單"
        Me.CK貨單序號.UseVisualStyleBackColor = True
        '
        'LB結帳日
        '
        Me.LB結帳日.AutoSize = True
        Me.LB結帳日.Location = New System.Drawing.Point(74, 48)
        Me.LB結帳日.Name = "LB結帳日"
        Me.LB結帳日.Size = New System.Drawing.Size(0, 20)
        Me.LB結帳日.TabIndex = 261
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 260
        Me.Label3.Text = "結帳日"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(519, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(21, 20)
        Me.Label2.TabIndex = 259
        Me.Label2.Text = "~"
        '
        'btnSerach
        '
        Me.btnSerach.Location = New System.Drawing.Point(707, 16)
        Me.btnSerach.Name = "btnSerach"
        Me.btnSerach.Size = New System.Drawing.Size(94, 38)
        Me.btnSerach.TabIndex = 258
        Me.btnSerach.Text = "查詢"
        Me.btnSerach.UseVisualStyleBackColor = True
        '
        '出貨日期迄
        '
        Me.出貨日期迄.Location = New System.Drawing.Point(540, 16)
        Me.出貨日期迄.Name = "出貨日期迄"
        Me.出貨日期迄.Size = New System.Drawing.Size(147, 29)
        Me.出貨日期迄.TabIndex = 257
        Me.出貨日期迄.Tag = "MCtrl"
        '
        '出貨日期起
        '
        Me.出貨日期起.Location = New System.Drawing.Point(378, 16)
        Me.出貨日期起.Name = "出貨日期起"
        Me.出貨日期起.Size = New System.Drawing.Size(141, 29)
        Me.出貨日期起.TabIndex = 255
        Me.出貨日期起.Tag = "MCtrl"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(305, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 256
        Me.Label4.Text = "出貨日期"
        '
        's客戶代碼
        '
        Me.s客戶代碼.Location = New System.Drawing.Point(51, 16)
        Me.s客戶代碼.Name = "s客戶代碼"
        Me.s客戶代碼.Size = New System.Drawing.Size(78, 29)
        Me.s客戶代碼.TabIndex = 254
        Me.s客戶代碼.Tag = ""
        '
        's客戶代號
        '
        Me.s客戶代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s客戶代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s客戶代號.FormattingEnabled = True
        Me.s客戶代號.Location = New System.Drawing.Point(129, 16)
        Me.s客戶代號.Name = "s客戶代號"
        Me.s客戶代號.Size = New System.Drawing.Size(176, 28)
        Me.s客戶代號.TabIndex = 252
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "客戶"
        '
        'btnAutoPrice
        '
        Me.btnAutoPrice.Location = New System.Drawing.Point(807, 16)
        Me.btnAutoPrice.Name = "btnAutoPrice"
        Me.btnAutoPrice.Size = New System.Drawing.Size(94, 38)
        Me.btnAutoPrice.TabIndex = 264
        Me.btnAutoPrice.Text = "複製報價單價"
        Me.btnAutoPrice.UseVisualStyleBackColor = True
        '
        'S03N0390
        '
        Me.ClientSize = New System.Drawing.Size(941, 578)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "S03N0390"
        Me.Text = "7         "
        Me.Controls.SetChildIndex(Me.MainPanel, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.OutDataDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Public WithEvents s客戶代碼 As System.Windows.Forms.TextBox
    Friend WithEvents s客戶代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OutDataDGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSerach As System.Windows.Forms.Button
    Friend WithEvents 出貨日期迄 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 出貨日期起 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LB結帳日 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CK含稅 As System.Windows.Forms.CheckBox
    Public WithEvents t總金額 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents t含稅 As System.Windows.Forms.TextBox
    Public WithEvents t金額 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents t重量 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Public WithEvents t筆數 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CK貨單序號 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents PreviewControl2 As FastReport.Preview.PreviewControl
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CK司機代號 As System.Windows.Forms.CheckBox
    Friend WithEvents 貨單序號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 出貨日期 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 工令號碼 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 品名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 規格 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 材質 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 加工方式 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 電鍍別 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後總重 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 單價 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 小計 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 報價單價 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 長度 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 司機姓名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後桶數 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 爐號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 客戶工令 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 單位 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 次加工廠商 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 牙分類 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 二次廠商 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 進貨日期 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 線材爐號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 客戶 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 備註 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 憑單號碼 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 序號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAutoPrice As System.Windows.Forms.Button

End Class
