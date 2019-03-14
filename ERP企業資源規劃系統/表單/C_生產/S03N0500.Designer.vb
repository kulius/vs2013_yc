<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N0500
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

    '注意:  以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSerach = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.委外廠商 = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.所屬工廠 = New System.Windows.Forms.TextBox()
        Me.i二次廠商 = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.i單位代號 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.i備註 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.i重量 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.i桶數 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.i爐號 = New System.Windows.Forms.TextBox()
        Me.i工令 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.i次加工廠 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.委外日期 = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.委外單號 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OutData_btnDec = New System.Windows.Forms.Button()
        Me.Tab2_Panel1 = New System.Windows.Forms.Panel()
        Me.OutDataDGV = New System.Windows.Forms.DataGridView()
        Me.待 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.排序 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.工令號碼 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.爐號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.品名 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.規格 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.材質 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後桶數 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.單位 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.磅後總重 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.電鍍別 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.次加工廠商 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.客戶工令 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.牙分類 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.二次廠商 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.進貨日期 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.線材爐號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.加工方式 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.備註 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.單價 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.小計 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Tab2_Panel1.SuspendLayout()
        CType(Me.OutDataDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Controls.Add(Me.TabPage5)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 83)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(909, 476)
        Me.TabControl.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(901, 443)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "委外單資料"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGridView)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(895, 373)
        Me.Panel2.TabIndex = 1
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
        Me.DataGridView.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView.RowTemplate.Height = 24
        Me.DataGridView.Size = New System.Drawing.Size(895, 373)
        Me.DataGridView.TabIndex = 283
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnSerach)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(895, 64)
        Me.Panel1.TabIndex = 0
        '
        'btnSerach
        '
        Me.btnSerach.Location = New System.Drawing.Point(640, 18)
        Me.btnSerach.Name = "btnSerach"
        Me.btnSerach.Size = New System.Drawing.Size(84, 27)
        Me.btnSerach.TabIndex = 254
        Me.btnSerach.Text = "蒐尋"
        Me.btnSerach.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.委外廠商)
        Me.TabPage2.Controls.Add(Me.Label47)
        Me.TabPage2.Controls.Add(Me.所屬工廠)
        Me.TabPage2.Controls.Add(Me.i二次廠商)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.i單位代號)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.i備註)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.i重量)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.i桶數)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.i爐號)
        Me.TabPage2.Controls.Add(Me.i工令)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.i次加工廠)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.btnAdd)
        Me.TabPage2.Controls.Add(Me.委外日期)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.委外單號)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.OutData_btnDec)
        Me.TabPage2.Controls.Add(Me.Tab2_Panel1)
        Me.TabPage2.Controls.Add(Me.ShapeContainer1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(901, 443)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "委外內容"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(699, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "委外廠商"
        '
        '委外廠商
        '
        Me.委外廠商.Location = New System.Drawing.Point(774, 6)
        Me.委外廠商.Name = "委外廠商"
        Me.委外廠商.Size = New System.Drawing.Size(107, 29)
        Me.委外廠商.TabIndex = 269
        Me.委外廠商.Tag = "MCtrl"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(515, 10)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(73, 20)
        Me.Label47.TabIndex = 268
        Me.Label47.Text = "所屬工廠"
        '
        '所屬工廠
        '
        Me.所屬工廠.Location = New System.Drawing.Point(590, 6)
        Me.所屬工廠.Name = "所屬工廠"
        Me.所屬工廠.Size = New System.Drawing.Size(107, 29)
        Me.所屬工廠.TabIndex = 267
        Me.所屬工廠.Tag = "MCtrl"
        '
        'i二次廠商
        '
        Me.i二次廠商.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.i二次廠商.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.i二次廠商.FormattingEnabled = True
        Me.i二次廠商.Location = New System.Drawing.Point(524, 84)
        Me.i二次廠商.Name = "i二次廠商"
        Me.i二次廠商.Size = New System.Drawing.Size(136, 28)
        Me.i二次廠商.TabIndex = 216
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(444, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(73, 20)
        Me.Label16.TabIndex = 217
        Me.Label16.Text = "二次廠商"
        '
        'i單位代號
        '
        Me.i單位代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.i單位代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.i單位代號.FormattingEnabled = True
        Me.i單位代號.Location = New System.Drawing.Point(694, 44)
        Me.i單位代號.Name = "i單位代號"
        Me.i單位代號.Size = New System.Drawing.Size(71, 28)
        Me.i單位代號.TabIndex = 10
        Me.i單位代號.Tag = ""
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(667, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 20)
        Me.Label13.TabIndex = 222
        Me.Label13.Text = "備註"
        '
        'i備註
        '
        Me.i備註.Location = New System.Drawing.Point(723, 83)
        Me.i備註.Name = "i備註"
        Me.i備註.Size = New System.Drawing.Size(167, 29)
        Me.i備註.TabIndex = 13
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(771, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 20)
        Me.Label12.TabIndex = 220
        Me.Label12.Text = "重量"
        '
        'i重量
        '
        Me.i重量.Location = New System.Drawing.Point(818, 44)
        Me.i重量.Name = "i重量"
        Me.i重量.Size = New System.Drawing.Size(72, 29)
        Me.i重量.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(647, 48)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(41, 20)
        Me.Label11.TabIndex = 220
        Me.Label11.Text = "單位"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(520, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 20)
        Me.Label10.TabIndex = 218
        Me.Label10.Text = "桶數"
        '
        'i桶數
        '
        Me.i桶數.Location = New System.Drawing.Point(567, 44)
        Me.i桶數.Name = "i桶數"
        Me.i桶數.Size = New System.Drawing.Size(72, 29)
        Me.i桶數.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(420, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 20)
        Me.Label9.TabIndex = 216
        Me.Label9.Text = "爐號"
        '
        'i爐號
        '
        Me.i爐號.Location = New System.Drawing.Point(467, 44)
        Me.i爐號.Name = "i爐號"
        Me.i爐號.Size = New System.Drawing.Size(43, 29)
        Me.i爐號.TabIndex = 8
        '
        'i工令
        '
        Me.i工令.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.i工令.Location = New System.Drawing.Point(283, 44)
        Me.i工令.Name = "i工令"
        Me.i工令.Size = New System.Drawing.Size(131, 29)
        Me.i工令.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(236, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 20)
        Me.Label8.TabIndex = 214
        Me.Label8.Text = "工令"
        '
        'i次加工廠
        '
        Me.i次加工廠.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.i次加工廠.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.i次加工廠.FormattingEnabled = True
        Me.i次加工廠.Location = New System.Drawing.Point(283, 83)
        Me.i次加工廠.Name = "i次加工廠"
        Me.i次加工廠.Size = New System.Drawing.Size(152, 28)
        Me.i次加工廠.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(204, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 20)
        Me.Label7.TabIndex = 215
        Me.Label7.Text = "次加工廠"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(120, 44)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 63)
        Me.btnAdd.TabIndex = 208
        Me.btnAdd.TabStop = False
        Me.btnAdd.Text = "追加"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        '委外日期
        '
        Me.委外日期.Location = New System.Drawing.Point(340, 6)
        Me.委外日期.Name = "委外日期"
        Me.委外日期.Size = New System.Drawing.Size(170, 29)
        Me.委外日期.TabIndex = 2
        Me.委外日期.Tag = "BCtrl"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(265, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "委外日期"
        '
        '委外單號
        '
        Me.委外單號.Location = New System.Drawing.Point(89, 6)
        Me.委外單號.Name = "委外單號"
        Me.委外單號.Size = New System.Drawing.Size(150, 29)
        Me.委外單號.TabIndex = 1
        Me.委外單號.Tag = "MCtrl"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 20)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = " 委外單號"
        '
        'OutData_btnDec
        '
        Me.OutData_btnDec.Location = New System.Drawing.Point(33, 45)
        Me.OutData_btnDec.Name = "OutData_btnDec"
        Me.OutData_btnDec.Size = New System.Drawing.Size(81, 60)
        Me.OutData_btnDec.TabIndex = 13
        Me.OutData_btnDec.Text = "刪除"
        Me.OutData_btnDec.UseVisualStyleBackColor = True
        '
        'Tab2_Panel1
        '
        Me.Tab2_Panel1.Controls.Add(Me.OutDataDGV)
        Me.Tab2_Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Tab2_Panel1.Location = New System.Drawing.Point(3, 129)
        Me.Tab2_Panel1.Name = "Tab2_Panel1"
        Me.Tab2_Panel1.Size = New System.Drawing.Size(895, 311)
        Me.Tab2_Panel1.TabIndex = 102
        '
        'OutDataDGV
        '
        Me.OutDataDGV.AllowUserToAddRows = False
        Me.OutDataDGV.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.OutDataDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.OutDataDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OutDataDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.OutDataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OutDataDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.待, Me.排序, Me.工令號碼, Me.爐號, Me.品名, Me.規格, Me.材質, Me.磅後桶數, Me.單位, Me.磅後總重, Me.電鍍別, Me.次加工廠商, Me.客戶工令, Me.牙分類, Me.二次廠商, Me.進貨日期, Me.線材爐號, Me.加工方式, Me.備註, Me.單價, Me.小計})
        Me.OutDataDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutDataDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.OutDataDGV.Location = New System.Drawing.Point(0, 0)
        Me.OutDataDGV.Name = "OutDataDGV"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.OutDataDGV.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.OutDataDGV.RowTemplate.Height = 24
        Me.OutDataDGV.Size = New System.Drawing.Size(895, 311)
        Me.OutDataDGV.TabIndex = 288
        '
        '待
        '
        Me.待.HeaderText = "待"
        Me.待.Name = "待"
        Me.待.Width = 40
        '
        '排序
        '
        Me.排序.HeaderText = "排序"
        Me.排序.Name = "排序"
        Me.排序.Width = 40
        '
        '工令號碼
        '
        Me.工令號碼.HeaderText = "工令號碼"
        Me.工令號碼.Name = "工令號碼"
        Me.工令號碼.Width = 80
        '
        '爐號
        '
        Me.爐號.HeaderText = "爐號"
        Me.爐號.Name = "爐號"
        Me.爐號.Width = 40
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
        '磅後桶數
        '
        Me.磅後桶數.HeaderText = "磅後桶數"
        Me.磅後桶數.Name = "磅後桶數"
        Me.磅後桶數.Width = 80
        '
        '單位
        '
        Me.單位.HeaderText = "單位"
        Me.單位.Name = "單位"
        Me.單位.Width = 40
        '
        '磅後總重
        '
        Me.磅後總重.HeaderText = "磅後總重"
        Me.磅後總重.Name = "磅後總重"
        Me.磅後總重.Width = 80
        '
        '電鍍別
        '
        Me.電鍍別.HeaderText = "電鍍別"
        Me.電鍍別.Name = "電鍍別"
        Me.電鍍別.ReadOnly = True
        Me.電鍍別.Width = 80
        '
        '次加工廠商
        '
        Me.次加工廠商.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.次加工廠商.HeaderText = "次加工廠商"
        Me.次加工廠商.Name = "次加工廠商"
        Me.次加工廠商.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.次加工廠商.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.次加工廠商.Width = 90
        '
        '客戶工令
        '
        Me.客戶工令.HeaderText = "客戶工令"
        Me.客戶工令.Name = "客戶工令"
        Me.客戶工令.ReadOnly = True
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
        Me.二次廠商.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.二次廠商.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
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
        '加工方式
        '
        Me.加工方式.HeaderText = "加工方式"
        Me.加工方式.Name = "加工方式"
        Me.加工方式.ReadOnly = True
        Me.加工方式.Width = 80
        '
        '備註
        '
        Me.備註.HeaderText = "備註"
        Me.備註.Name = "備註"
        '
        '單價
        '
        Me.單價.HeaderText = "單價"
        Me.單價.Name = "單價"
        Me.單價.ReadOnly = True
        Me.單價.Width = 5
        '
        '小計
        '
        Me.小計.HeaderText = "小計"
        Me.小計.Name = "小計"
        Me.小計.ReadOnly = True
        Me.小計.Width = 5
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(3, 3)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Size = New System.Drawing.Size(895, 437)
        Me.ShapeContainer1.TabIndex = 216
        Me.ShapeContainer1.TabStop = False
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.PreviewControl1)
        Me.TabPage5.Controls.Add(Me.Panel5)
        Me.TabPage5.Location = New System.Drawing.Point(4, 29)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(901, 443)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "委外單"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 70)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(901, 373)
        Me.PreviewControl1.TabIndex = 3
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.btnPreviewRep)
        Me.Panel5.Controls.Add(Me.btnDesignRep)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(901, 70)
        Me.Panel5.TabIndex = 4
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
        'S03N0500
        '
        Me.ClientSize = New System.Drawing.Size(909, 584)
        Me.Controls.Add(Me.TabControl)
        Me.Name = "S03N0500"
        Me.Controls.SetChildIndex(Me.TabControl, 0)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Tab2_Panel1.ResumeLayout(False)
        CType(Me.OutDataDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSerach As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents 委外廠商 As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents 所屬工廠 As System.Windows.Forms.TextBox
    Friend WithEvents i二次廠商 As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents i單位代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents i備註 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents i重量 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents i桶數 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents i爐號 As System.Windows.Forms.TextBox
    Friend WithEvents i工令 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents i次加工廠 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents 委外日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents 委外單號 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OutData_btnDec As System.Windows.Forms.Button
    Friend WithEvents Tab2_Panel1 As System.Windows.Forms.Panel
    Friend WithEvents OutDataDGV As System.Windows.Forms.DataGridView
    Friend WithEvents 待 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents 排序 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 工令號碼 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 爐號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 品名 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 規格 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 材質 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後桶數 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 單位 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 磅後總重 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 電鍍別 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 次加工廠商 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents 客戶工令 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 牙分類 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 二次廠商 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents 進貨日期 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 線材爐號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 加工方式 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 備註 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 單價 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 小計 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button

End Class
