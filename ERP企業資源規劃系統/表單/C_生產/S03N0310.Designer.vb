<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N0310
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
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.txtDataGridViewTitle = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.CK檢驗不合格 = New System.Windows.Forms.CheckBox()
        Me.CK已出貨 = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.s客戶代碼 = New System.Windows.Forms.TextBox()
        Me.s客戶代號 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CK已過磅 = New System.Windows.Forms.CheckBox()
        Me.CK已檢驗 = New System.Windows.Forms.CheckBox()
        Me.CK已進爐 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.工令號碼1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.進貨日期1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.品名1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.規格1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.材質1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.線材爐號1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.狀態1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.過磅狀態1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.檢驗狀態1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.原工令1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.爐號1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.次加工廠商1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.回溫1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.表面1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.表面硬度1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.心部硬度1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.二次廠商1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.加工方式1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.電鍍別1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.客戶工令1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.牙分類1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.重量1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後總重1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.裝袋合計1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後桶數1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.單位1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 152)
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
        Me.SplitContainer.Size = New System.Drawing.Size(992, 396)
        Me.SplitContainer.SplitterDistance = 25
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 40
        '
        'txtDataGridViewTitle
        '
        Me.txtDataGridViewTitle.AutoSize = True
        Me.txtDataGridViewTitle.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtDataGridViewTitle.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtDataGridViewTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtDataGridViewTitle.Location = New System.Drawing.Point(0, 0)
        Me.txtDataGridViewTitle.Name = "txtDataGridViewTitle"
        Me.txtDataGridViewTitle.Size = New System.Drawing.Size(154, 21)
        Me.txtDataGridViewTitle.TabIndex = 0
        Me.txtDataGridViewTitle.Text = "製造過程資料一覽表"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(988, 366)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(980, 333)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "轉待出貨資料瀏灠"
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
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.工令號碼1, Me.進貨日期1, Me.品名1, Me.規格1, Me.材質1, Me.線材爐號1, Me.狀態1, Me.過磅狀態1, Me.檢驗狀態1, Me.原工令1, Me.爐號1, Me.次加工廠商1, Me.回溫1, Me.表面1, Me.表面硬度1, Me.心部硬度1, Me.二次廠商1, Me.加工方式1, Me.電鍍別1, Me.客戶工令1, Me.牙分類1, Me.重量1, Me.磅後總重1, Me.裝袋合計1, Me.磅後桶數1, Me.單位1})
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView.Name = "DataGridView"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView.RowTemplate.Height = 24
        Me.DataGridView.Size = New System.Drawing.Size(974, 327)
        Me.DataGridView.TabIndex = 288
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PreviewControl1)
        Me.TabPage2.Controls.Add(Me.Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(980, 333)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "報表"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 70)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(980, 263)
        Me.PreviewControl1.TabIndex = 5
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnPreviewRep)
        Me.Panel5.Controls.Add(Me.btnDesignRep)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(980, 70)
        Me.Panel5.TabIndex = 6
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(157, 16)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(101, 37)
        Me.btnPreviewRep.TabIndex = 3
        Me.btnPreviewRep.Text = "預覽報表"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(285, 16)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(101, 37)
        Me.btnDesignRep.TabIndex = 1
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.CK檢驗不合格)
        Me.MainPanel.Controls.Add(Me.CK已出貨)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.s客戶代碼)
        Me.MainPanel.Controls.Add(Me.s客戶代號)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.CK已過磅)
        Me.MainPanel.Controls.Add(Me.CK已檢驗)
        Me.MainPanel.Controls.Add(Me.CK已進爐)
        Me.MainPanel.Controls.Add(Me.Button1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 83)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(992, 69)
        Me.MainPanel.TabIndex = 38
        '
        'CK檢驗不合格
        '
        Me.CK檢驗不合格.AutoSize = True
        Me.CK檢驗不合格.Checked = True
        Me.CK檢驗不合格.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK檢驗不合格.Location = New System.Drawing.Point(667, 45)
        Me.CK檢驗不合格.Name = "CK檢驗不合格"
        Me.CK檢驗不合格.Size = New System.Drawing.Size(144, 24)
        Me.CK檢驗不合格.TabIndex = 257
        Me.CK檢驗不合格.Text = "不含 檢驗不合格"
        Me.CK檢驗不合格.UseVisualStyleBackColor = True
        '
        'CK已出貨
        '
        Me.CK已出貨.AutoSize = True
        Me.CK已出貨.Checked = True
        Me.CK已出貨.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK已出貨.Location = New System.Drawing.Point(667, 21)
        Me.CK已出貨.Name = "CK已出貨"
        Me.CK已出貨.Size = New System.Drawing.Size(112, 24)
        Me.CK已出貨.TabIndex = 256
        Me.CK已出貨.Text = "不含 已出貨"
        Me.CK已出貨.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(321, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 21)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "不打勾，代表不列入判斷條件 "
        '
        's客戶代碼
        '
        Me.s客戶代碼.Location = New System.Drawing.Point(43, 19)
        Me.s客戶代碼.Name = "s客戶代碼"
        Me.s客戶代碼.Size = New System.Drawing.Size(106, 29)
        Me.s客戶代碼.TabIndex = 254
        Me.s客戶代碼.Tag = ""
        '
        's客戶代號
        '
        Me.s客戶代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s客戶代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s客戶代號.FormattingEnabled = True
        Me.s客戶代號.Location = New System.Drawing.Point(149, 19)
        Me.s客戶代號.Name = "s客戶代號"
        Me.s客戶代號.Size = New System.Drawing.Size(176, 28)
        Me.s客戶代號.TabIndex = 252
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "客戶"
        '
        'CK已過磅
        '
        Me.CK已過磅.AutoSize = True
        Me.CK已過磅.Checked = True
        Me.CK已過磅.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK已過磅.Location = New System.Drawing.Point(549, 21)
        Me.CK已過磅.Name = "CK已過磅"
        Me.CK已過磅.Size = New System.Drawing.Size(112, 24)
        Me.CK已過磅.TabIndex = 208
        Me.CK已過磅.Text = "包含 已過磅"
        Me.CK已過磅.UseVisualStyleBackColor = True
        '
        'CK已檢驗
        '
        Me.CK已檢驗.AutoSize = True
        Me.CK已檢驗.Checked = True
        Me.CK已檢驗.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK已檢驗.Location = New System.Drawing.Point(437, 21)
        Me.CK已檢驗.Name = "CK已檢驗"
        Me.CK已檢驗.Size = New System.Drawing.Size(112, 24)
        Me.CK已檢驗.TabIndex = 206
        Me.CK已檢驗.Text = "包含 已檢驗"
        Me.CK已檢驗.UseVisualStyleBackColor = True
        '
        'CK已進爐
        '
        Me.CK已進爐.AutoSize = True
        Me.CK已進爐.Checked = True
        Me.CK已進爐.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK已進爐.Location = New System.Drawing.Point(325, 21)
        Me.CK已進爐.Name = "CK已進爐"
        Me.CK已進爐.Size = New System.Drawing.Size(112, 24)
        Me.CK已進爐.TabIndex = 205
        Me.CK已進爐.Text = "包含 已進爐"
        Me.CK已進爐.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(817, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 48)
        Me.Button1.TabIndex = 199
        Me.Button1.Text = "查詢"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '工令號碼1
        '
        Me.工令號碼1.HeaderText = "工令號碼"
        Me.工令號碼1.Name = "工令號碼1"
        Me.工令號碼1.ReadOnly = True
        '
        '進貨日期1
        '
        Me.進貨日期1.HeaderText = "進貨日期"
        Me.進貨日期1.Name = "進貨日期1"
        Me.進貨日期1.ReadOnly = True
        '
        '品名1
        '
        Me.品名1.HeaderText = "品名"
        Me.品名1.Name = "品名1"
        Me.品名1.ReadOnly = True
        '
        '規格1
        '
        Me.規格1.HeaderText = "規格"
        Me.規格1.Name = "規格1"
        Me.規格1.ReadOnly = True
        Me.規格1.Width = 150
        '
        '材質1
        '
        Me.材質1.HeaderText = "材質"
        Me.材質1.Name = "材質1"
        Me.材質1.ReadOnly = True
        Me.材質1.Width = 80
        '
        '線材爐號1
        '
        Me.線材爐號1.HeaderText = "線材爐號"
        Me.線材爐號1.Name = "線材爐號1"
        Me.線材爐號1.ReadOnly = True
        Me.線材爐號1.Width = 80
        '
        '狀態1
        '
        Me.狀態1.HeaderText = "狀態"
        Me.狀態1.Name = "狀態1"
        Me.狀態1.ReadOnly = True
        Me.狀態1.Width = 70
        '
        '過磅狀態1
        '
        Me.過磅狀態1.HeaderText = "過磅狀態"
        Me.過磅狀態1.Name = "過磅狀態1"
        Me.過磅狀態1.ReadOnly = True
        Me.過磅狀態1.Width = 70
        '
        '檢驗狀態1
        '
        Me.檢驗狀態1.HeaderText = "檢驗狀態"
        Me.檢驗狀態1.Name = "檢驗狀態1"
        Me.檢驗狀態1.ReadOnly = True
        '
        '原工令1
        '
        Me.原工令1.HeaderText = "異常品原工令"
        Me.原工令1.Name = "原工令1"
        Me.原工令1.ReadOnly = True
        Me.原工令1.Width = 80
        '
        '爐號1
        '
        Me.爐號1.HeaderText = "爐號"
        Me.爐號1.Name = "爐號1"
        Me.爐號1.ReadOnly = True
        '
        '次加工廠商1
        '
        Me.次加工廠商1.HeaderText = "次加工廠商"
        Me.次加工廠商1.Name = "次加工廠商1"
        Me.次加工廠商1.ReadOnly = True
        Me.次加工廠商1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.次加工廠商1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.次加工廠商1.Width = 80
        '
        '回溫1
        '
        Me.回溫1.HeaderText = "回溫"
        Me.回溫1.Name = "回溫1"
        Me.回溫1.ReadOnly = True
        '
        '表面1
        '
        Me.表面1.HeaderText = "表面"
        Me.表面1.Name = "表面1"
        Me.表面1.ReadOnly = True
        '
        '表面硬度1
        '
        Me.表面硬度1.HeaderText = "表面硬度"
        Me.表面硬度1.Name = "表面硬度1"
        Me.表面硬度1.ReadOnly = True
        '
        '心部硬度1
        '
        Me.心部硬度1.HeaderText = "心部硬度"
        Me.心部硬度1.Name = "心部硬度1"
        Me.心部硬度1.ReadOnly = True
        '
        '二次廠商1
        '
        Me.二次廠商1.HeaderText = "二次廠商"
        Me.二次廠商1.Name = "二次廠商1"
        Me.二次廠商1.ReadOnly = True
        Me.二次廠商1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.二次廠商1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        '加工方式1
        '
        Me.加工方式1.HeaderText = "加工方式"
        Me.加工方式1.Name = "加工方式1"
        Me.加工方式1.Width = 80
        '
        '電鍍別1
        '
        Me.電鍍別1.HeaderText = "電鍍別"
        Me.電鍍別1.Name = "電鍍別1"
        Me.電鍍別1.ReadOnly = True
        Me.電鍍別1.Width = 80
        '
        '客戶工令1
        '
        Me.客戶工令1.HeaderText = "客戶工令"
        Me.客戶工令1.Name = "客戶工令1"
        Me.客戶工令1.ReadOnly = True
        '
        '牙分類1
        '
        Me.牙分類1.HeaderText = "牙分類"
        Me.牙分類1.Name = "牙分類1"
        Me.牙分類1.ReadOnly = True
        Me.牙分類1.Width = 80
        '
        '重量1
        '
        Me.重量1.HeaderText = "重量"
        Me.重量1.Name = "重量1"
        Me.重量1.ReadOnly = True
        Me.重量1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.重量1.Width = 80
        '
        '磅後總重1
        '
        Me.磅後總重1.HeaderText = "磅後總重"
        Me.磅後總重1.Name = "磅後總重1"
        Me.磅後總重1.ReadOnly = True
        Me.磅後總重1.Width = 80
        '
        '裝袋合計1
        '
        Me.裝袋合計1.HeaderText = "裝袋合計"
        Me.裝袋合計1.Name = "裝袋合計1"
        Me.裝袋合計1.Width = 80
        '
        '磅後桶數1
        '
        Me.磅後桶數1.HeaderText = "磅後桶數"
        Me.磅後桶數1.Name = "磅後桶數1"
        Me.磅後桶數1.ReadOnly = True
        '
        '單位1
        '
        Me.單位1.HeaderText = "單位"
        Me.單位1.Name = "單位1"
        Me.單位1.ReadOnly = True
        '
        'S03N0310
        '
        Me.ClientSize = New System.Drawing.Size(992, 573)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "S03N0310"
        Me.Controls.SetChildIndex(Me.MainPanel, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer, 0)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDataGridViewTitle As System.Windows.Forms.Label
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents CK已檢驗 As System.Windows.Forms.CheckBox
    Friend WithEvents CK已進爐 As System.Windows.Forms.CheckBox
    Friend WithEvents CK已過磅 As System.Windows.Forms.CheckBox
    Public WithEvents s客戶代碼 As System.Windows.Forms.TextBox
    Friend WithEvents s客戶代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents CK已出貨 As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents CK檢驗不合格 As System.Windows.Forms.CheckBox
    Friend WithEvents 工令號碼1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 進貨日期1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 品名1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 規格1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 材質1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 線材爐號1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 狀態1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 過磅狀態1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 檢驗狀態1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 原工令1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 爐號1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 次加工廠商1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents 回溫1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 表面1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 表面硬度1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 心部硬度1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 二次廠商1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents 加工方式1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 電鍍別1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 客戶工令1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 牙分類1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 重量1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後總重1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 裝袋合計1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後桶數1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 單位1 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
