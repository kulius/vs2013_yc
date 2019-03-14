<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N0410
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.s客戶代碼 = New System.Windows.Forms.TextBox()
        Me.s客戶代號 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAutoPrice = New System.Windows.Forms.Button()
        Me.進貨日期 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.DataGrid_Det = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CK客戶 = New System.Windows.Forms.CheckBox()
        Me.CK表面硬度 = New System.Windows.Forms.CheckBox()
        Me.CK心部硬度 = New System.Windows.Forms.CheckBox()
        Me.CK加工方式 = New System.Windows.Forms.CheckBox()
        Me.CK表面 = New System.Windows.Forms.CheckBox()
        Me.CK材質 = New System.Windows.Forms.CheckBox()
        Me.CK長度 = New System.Windows.Forms.CheckBox()
        Me.CK規格 = New System.Windows.Forms.CheckBox()
        Me.CK品名 = New System.Windows.Forms.CheckBox()
        Me.DataGrid1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGrid_Det, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.s客戶代碼)
        Me.Panel1.Controls.Add(Me.s客戶代號)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnAutoPrice)
        Me.Panel1.Controls.Add(Me.進貨日期)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnSearch)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 48)
        Me.Panel1.TabIndex = 135
        '
        's客戶代碼
        '
        Me.s客戶代碼.Location = New System.Drawing.Point(55, 13)
        Me.s客戶代碼.Name = "s客戶代碼"
        Me.s客戶代碼.Size = New System.Drawing.Size(78, 27)
        Me.s客戶代碼.TabIndex = 278
        Me.s客戶代碼.Tag = ""
        '
        's客戶代號
        '
        Me.s客戶代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s客戶代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s客戶代號.FormattingEnabled = True
        Me.s客戶代號.Location = New System.Drawing.Point(133, 14)
        Me.s客戶代號.Name = "s客戶代號"
        Me.s客戶代號.Size = New System.Drawing.Size(176, 24)
        Me.s客戶代號.TabIndex = 276
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 277
        Me.Label2.Text = "客戶"
        '
        'btnAutoPrice
        '
        Me.btnAutoPrice.Location = New System.Drawing.Point(757, 10)
        Me.btnAutoPrice.Name = "btnAutoPrice"
        Me.btnAutoPrice.Size = New System.Drawing.Size(112, 30)
        Me.btnAutoPrice.TabIndex = 273
        Me.btnAutoPrice.Text = "自動填入單價"
        Me.btnAutoPrice.UseVisualStyleBackColor = True
        '
        '進貨日期
        '
        Me.進貨日期.Location = New System.Drawing.Point(395, 13)
        Me.進貨日期.Margin = New System.Windows.Forms.Padding(5)
        Me.進貨日期.Name = "進貨日期"
        Me.進貨日期.Size = New System.Drawing.Size(190, 27)
        Me.進貨日期.TabIndex = 272
        Me.進貨日期.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(324, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "進貨日期"
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnSearch.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(598, 10)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(56, 32)
        Me.BtnSearch.TabIndex = 129
        Me.BtnSearch.Text = "查詢"
        Me.BtnSearch.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnExit.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnExit.Location = New System.Drawing.Point(662, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(56, 32)
        Me.btnExit.TabIndex = 130
        Me.btnExit.Text = "離開"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(872, 568)
        Me.TabControl1.TabIndex = 136
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.DataGrid1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(864, 538)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "多筆瀏覽"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DataGrid_Det)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 259)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(864, 279)
        Me.Panel2.TabIndex = 293
        '
        'DataGrid_Det
        '
        Me.DataGrid_Det.AllowUserToAddRows = False
        Me.DataGrid_Det.AllowUserToDeleteRows = False
        Me.DataGrid_Det.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid_Det.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGrid_Det.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid_Det.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGrid_Det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid_Det.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid_Det.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid_Det.Location = New System.Drawing.Point(0, 47)
        Me.DataGrid_Det.Name = "DataGrid_Det"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid_Det.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGrid_Det.RowTemplate.Height = 24
        Me.DataGrid_Det.Size = New System.Drawing.Size(864, 232)
        Me.DataGrid_Det.TabIndex = 293
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CK客戶)
        Me.Panel3.Controls.Add(Me.CK表面硬度)
        Me.Panel3.Controls.Add(Me.CK心部硬度)
        Me.Panel3.Controls.Add(Me.CK加工方式)
        Me.Panel3.Controls.Add(Me.CK表面)
        Me.Panel3.Controls.Add(Me.CK材質)
        Me.Panel3.Controls.Add(Me.CK長度)
        Me.Panel3.Controls.Add(Me.CK規格)
        Me.Panel3.Controls.Add(Me.CK品名)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(864, 47)
        Me.Panel3.TabIndex = 294
        '
        'CK客戶
        '
        Me.CK客戶.AutoSize = True
        Me.CK客戶.Checked = True
        Me.CK客戶.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK客戶.Location = New System.Drawing.Point(656, 13)
        Me.CK客戶.Name = "CK客戶"
        Me.CK客戶.Size = New System.Drawing.Size(59, 20)
        Me.CK客戶.TabIndex = 272
        Me.CK客戶.Text = "客戶"
        Me.CK客戶.UseVisualStyleBackColor = True
        '
        'CK表面硬度
        '
        Me.CK表面硬度.AutoSize = True
        Me.CK表面硬度.Checked = True
        Me.CK表面硬度.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK表面硬度.Location = New System.Drawing.Point(559, 13)
        Me.CK表面硬度.Name = "CK表面硬度"
        Me.CK表面硬度.Size = New System.Drawing.Size(91, 20)
        Me.CK表面硬度.TabIndex = 271
        Me.CK表面硬度.Text = "表面硬度"
        Me.CK表面硬度.UseVisualStyleBackColor = True
        '
        'CK心部硬度
        '
        Me.CK心部硬度.AutoSize = True
        Me.CK心部硬度.Checked = True
        Me.CK心部硬度.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK心部硬度.Location = New System.Drawing.Point(462, 13)
        Me.CK心部硬度.Name = "CK心部硬度"
        Me.CK心部硬度.Size = New System.Drawing.Size(91, 20)
        Me.CK心部硬度.TabIndex = 270
        Me.CK心部硬度.Text = "心部硬度"
        Me.CK心部硬度.UseVisualStyleBackColor = True
        '
        'CK加工方式
        '
        Me.CK加工方式.AutoSize = True
        Me.CK加工方式.Checked = True
        Me.CK加工方式.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK加工方式.Location = New System.Drawing.Point(370, 13)
        Me.CK加工方式.Name = "CK加工方式"
        Me.CK加工方式.Size = New System.Drawing.Size(91, 20)
        Me.CK加工方式.TabIndex = 269
        Me.CK加工方式.Text = "加工方式"
        Me.CK加工方式.UseVisualStyleBackColor = True
        '
        'CK表面
        '
        Me.CK表面.AutoSize = True
        Me.CK表面.Checked = True
        Me.CK表面.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK表面.Location = New System.Drawing.Point(305, 13)
        Me.CK表面.Name = "CK表面"
        Me.CK表面.Size = New System.Drawing.Size(59, 20)
        Me.CK表面.TabIndex = 268
        Me.CK表面.Text = "表面"
        Me.CK表面.UseVisualStyleBackColor = True
        '
        'CK材質
        '
        Me.CK材質.AutoSize = True
        Me.CK材質.Checked = True
        Me.CK材質.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK材質.Location = New System.Drawing.Point(240, 13)
        Me.CK材質.Name = "CK材質"
        Me.CK材質.Size = New System.Drawing.Size(59, 20)
        Me.CK材質.TabIndex = 267
        Me.CK材質.Text = "材質"
        Me.CK材質.UseVisualStyleBackColor = True
        '
        'CK長度
        '
        Me.CK長度.AutoSize = True
        Me.CK長度.Checked = True
        Me.CK長度.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK長度.Location = New System.Drawing.Point(175, 13)
        Me.CK長度.Name = "CK長度"
        Me.CK長度.Size = New System.Drawing.Size(59, 20)
        Me.CK長度.TabIndex = 266
        Me.CK長度.Text = "長度"
        Me.CK長度.UseVisualStyleBackColor = True
        '
        'CK規格
        '
        Me.CK規格.AutoSize = True
        Me.CK規格.Checked = True
        Me.CK規格.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK規格.Location = New System.Drawing.Point(101, 13)
        Me.CK規格.Name = "CK規格"
        Me.CK規格.Size = New System.Drawing.Size(59, 20)
        Me.CK規格.TabIndex = 265
        Me.CK規格.Text = "規格"
        Me.CK規格.UseVisualStyleBackColor = True
        '
        'CK品名
        '
        Me.CK品名.AutoSize = True
        Me.CK品名.Checked = True
        Me.CK品名.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CK品名.Location = New System.Drawing.Point(27, 13)
        Me.CK品名.Name = "CK品名"
        Me.CK品名.Size = New System.Drawing.Size(59, 20)
        Me.CK品名.TabIndex = 264
        Me.CK品名.Text = "品名"
        Me.CK品名.UseVisualStyleBackColor = True
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowUserToAddRows = False
        Me.DataGrid1.AllowUserToDeleteRows = False
        Me.DataGrid1.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid1.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGrid1.RowTemplate.Height = 24
        Me.DataGrid1.Size = New System.Drawing.Size(864, 259)
        Me.DataGrid1.TabIndex = 290
        '
        'S03N0410
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "S03N0410"
        Me.Text = "S03N0410"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.DataGrid_Det, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents 進貨日期 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGrid_Det As System.Windows.Forms.DataGridView
    Friend WithEvents CK規格 As System.Windows.Forms.CheckBox
    Friend WithEvents CK品名 As System.Windows.Forms.CheckBox
    Friend WithEvents CK材質 As System.Windows.Forms.CheckBox
    Friend WithEvents CK長度 As System.Windows.Forms.CheckBox
    Friend WithEvents CK表面 As System.Windows.Forms.CheckBox
    Friend WithEvents CK表面硬度 As System.Windows.Forms.CheckBox
    Friend WithEvents CK心部硬度 As System.Windows.Forms.CheckBox
    Friend WithEvents CK加工方式 As System.Windows.Forms.CheckBox
    Friend WithEvents CK客戶 As System.Windows.Forms.CheckBox
    Friend WithEvents btnAutoPrice As System.Windows.Forms.Button
    Public WithEvents s客戶代碼 As System.Windows.Forms.TextBox
    Friend WithEvents s客戶代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
