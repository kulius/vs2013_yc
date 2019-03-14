<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N0190
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.s規格代碼 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.s工令號碼 = New System.Windows.Forms.TextBox()
        Me.s客戶代號1 = New System.Windows.Forms.TextBox()
        Me.s客戶代號 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.客戶簡稱2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.爐號2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.進貨日期2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.工令號碼2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.品名2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.規格2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.材質2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.表面2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.回温2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.桶數2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.淨重2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.狀態2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.表面硬度2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.心部硬度2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.線材爐號2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.s規格代碼)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.s工令號碼)
        Me.Panel1.Controls.Add(Me.s客戶代號1)
        Me.Panel1.Controls.Add(Me.s客戶代號)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(892, 73)
        Me.Panel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(801, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 29)
        Me.Button1.TabIndex = 257
        Me.Button1.Text = "查詢"
        Me.Button1.UseVisualStyleBackColor = True
        '
        's規格代碼
        '
        Me.s規格代碼.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s規格代碼.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s規格代碼.FormattingEnabled = True
        Me.s規格代碼.Location = New System.Drawing.Point(602, 23)
        Me.s規格代碼.Name = "s規格代碼"
        Me.s規格代碼.Size = New System.Drawing.Size(178, 28)
        Me.s規格代碼.TabIndex = 256
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(559, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 255
        Me.Label2.Text = "規格"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(346, 27)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(73, 20)
        Me.Label19.TabIndex = 254
        Me.Label19.Tag = "BCtrl"
        Me.Label19.Text = "工令號碼"
        '
        's工令號碼
        '
        Me.s工令號碼.Location = New System.Drawing.Point(425, 23)
        Me.s工令號碼.Name = "s工令號碼"
        Me.s工令號碼.Size = New System.Drawing.Size(132, 29)
        Me.s工令號碼.TabIndex = 253
        Me.s工令號碼.Tag = ""
        '
        's客戶代號1
        '
        Me.s客戶代號1.Location = New System.Drawing.Point(52, 23)
        Me.s客戶代號1.Name = "s客戶代號1"
        Me.s客戶代號1.Size = New System.Drawing.Size(106, 29)
        Me.s客戶代號1.TabIndex = 251
        Me.s客戶代號1.Tag = ""
        '
        's客戶代號
        '
        Me.s客戶代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s客戶代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s客戶代號.FormattingEnabled = True
        Me.s客戶代號.Location = New System.Drawing.Point(164, 23)
        Me.s客戶代號.Name = "s客戶代號"
        Me.s客戶代號.Size = New System.Drawing.Size(176, 28)
        Me.s客戶代號.TabIndex = 249
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 20)
        Me.Label6.TabIndex = 250
        Me.Label6.Text = "客戶"
        '
        'DataGridView
        '
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.客戶簡稱2, Me.爐號2, Me.進貨日期2, Me.工令號碼2, Me.品名2, Me.規格2, Me.材質2, Me.表面2, Me.回温2, Me.桶數2, Me.淨重2, Me.狀態2, Me.表面硬度2, Me.心部硬度2, Me.線材爐號2})
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGridView.Location = New System.Drawing.Point(0, 156)
        Me.DataGridView.Name = "DataGridView"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridView.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView.RowTemplate.Height = 24
        Me.DataGridView.Size = New System.Drawing.Size(892, 392)
        Me.DataGridView.TabIndex = 284
        '
        '客戶簡稱2
        '
        Me.客戶簡稱2.HeaderText = "客戶簡稱"
        Me.客戶簡稱2.Name = "客戶簡稱2"
        Me.客戶簡稱2.ReadOnly = True
        '
        '爐號2
        '
        Me.爐號2.HeaderText = "爐號"
        Me.爐號2.Name = "爐號2"
        Me.爐號2.ReadOnly = True
        Me.爐號2.Width = 70
        '
        '進貨日期2
        '
        Me.進貨日期2.HeaderText = "進貨日期"
        Me.進貨日期2.Name = "進貨日期2"
        Me.進貨日期2.ReadOnly = True
        '
        '工令號碼2
        '
        Me.工令號碼2.HeaderText = "工令號碼"
        Me.工令號碼2.Name = "工令號碼2"
        Me.工令號碼2.ReadOnly = True
        '
        '品名2
        '
        Me.品名2.HeaderText = "品名"
        Me.品名2.Name = "品名2"
        Me.品名2.ReadOnly = True
        '
        '規格2
        '
        Me.規格2.HeaderText = "規格"
        Me.規格2.Name = "規格2"
        Me.規格2.ReadOnly = True
        Me.規格2.Width = 150
        '
        '材質2
        '
        Me.材質2.HeaderText = "材質"
        Me.材質2.Name = "材質2"
        Me.材質2.ReadOnly = True
        '
        '表面2
        '
        Me.表面2.HeaderText = "表面"
        Me.表面2.Name = "表面2"
        Me.表面2.ReadOnly = True
        '
        '回温2
        '
        Me.回温2.HeaderText = "回温"
        Me.回温2.Name = "回温2"
        Me.回温2.ReadOnly = True
        Me.回温2.Width = 70
        '
        '桶數2
        '
        Me.桶數2.HeaderText = "桶數"
        Me.桶數2.Name = "桶數2"
        Me.桶數2.ReadOnly = True
        Me.桶數2.Width = 70
        '
        '淨重2
        '
        Me.淨重2.HeaderText = "淨重"
        Me.淨重2.Name = "淨重2"
        Me.淨重2.ReadOnly = True
        Me.淨重2.Width = 70
        '
        '狀態2
        '
        Me.狀態2.HeaderText = "狀態"
        Me.狀態2.Name = "狀態2"
        Me.狀態2.ReadOnly = True
        '
        '表面硬度2
        '
        Me.表面硬度2.HeaderText = "表面硬度"
        Me.表面硬度2.Name = "表面硬度2"
        Me.表面硬度2.ReadOnly = True
        '
        '心部硬度2
        '
        Me.心部硬度2.HeaderText = "心部硬度"
        Me.心部硬度2.Name = "心部硬度2"
        Me.心部硬度2.ReadOnly = True
        '
        '線材爐號2
        '
        Me.線材爐號2.HeaderText = "線材爐號"
        Me.線材爐號2.Name = "線材爐號2"
        Me.線材爐號2.ReadOnly = True
        '
        'S03N0190
        '
        Me.ClientSize = New System.Drawing.Size(892, 573)
        Me.Controls.Add(Me.DataGridView)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "S03N0190"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.DataGridView, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Public WithEvents s客戶代號1 As System.Windows.Forms.TextBox
    Friend WithEvents s客戶代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents s工令號碼 As System.Windows.Forms.TextBox
    Friend WithEvents s規格代碼 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 客戶簡稱2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 爐號2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 進貨日期2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 工令號碼2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 品名2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 規格2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 材質2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 表面2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 回温2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 桶數2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 淨重2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 狀態2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 表面硬度2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 心部硬度2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 線材爐號2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
