<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S99N0101
    Inherits ERP企業資源規劃系統.fmBase2

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.M_TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAddFun = New System.Windows.Forms.Button()
        Me.btnDelALL = New System.Windows.Forms.Button()
        Me.btnSelectALL = New System.Windows.Forms.Button()
        Me.M_TextBox1 = New System.Windows.Forms.TextBox()
        Me.M_TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.Label()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.txtDataGridViewTitle = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridViewR = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CopyUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCopyUser = New System.Windows.Forms.Button()
        Me.MainPanel.SuspendLayout()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridViewR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.BtnCopyUser)
        Me.MainPanel.Controls.Add(Me.CopyUser)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.M_TextBox3)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.btnAddFun)
        Me.MainPanel.Controls.Add(Me.btnDelALL)
        Me.MainPanel.Controls.Add(Me.btnSelectALL)
        Me.MainPanel.Controls.Add(Me.M_TextBox1)
        Me.MainPanel.Controls.Add(Me.M_TextBox2)
        Me.MainPanel.Controls.Add(Me.txtName)
        Me.MainPanel.Controls.Add(Me.txtID)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 43)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(1016, 100)
        Me.MainPanel.TabIndex = 13
        '
        'M_TextBox3
        '
        Me.M_TextBox3.Location = New System.Drawing.Point(565, 20)
        Me.M_TextBox3.MaxLength = 16
        Me.M_TextBox3.Name = "M_TextBox3"
        Me.M_TextBox3.Size = New System.Drawing.Size(171, 29)
        Me.M_TextBox3.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(490, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 20)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "密碼"
        '
        'btnAddFun
        '
        Me.btnAddFun.Location = New System.Drawing.Point(667, 62)
        Me.btnAddFun.Name = "btnAddFun"
        Me.btnAddFun.Size = New System.Drawing.Size(133, 34)
        Me.btnAddFun.TabIndex = 10
        Me.btnAddFun.Text = "載入所有權限"
        Me.btnAddFun.UseVisualStyleBackColor = True
        '
        'btnDelALL
        '
        Me.btnDelALL.Location = New System.Drawing.Point(99, 63)
        Me.btnDelALL.Name = "btnDelALL"
        Me.btnDelALL.Size = New System.Drawing.Size(75, 32)
        Me.btnDelALL.TabIndex = 9
        Me.btnDelALL.Text = "全取消"
        Me.btnDelALL.UseVisualStyleBackColor = True
        '
        'btnSelectALL
        '
        Me.btnSelectALL.Location = New System.Drawing.Point(18, 63)
        Me.btnSelectALL.Name = "btnSelectALL"
        Me.btnSelectALL.Size = New System.Drawing.Size(75, 32)
        Me.btnSelectALL.TabIndex = 8
        Me.btnSelectALL.Text = "全選"
        Me.btnSelectALL.UseVisualStyleBackColor = True
        '
        'M_TextBox1
        '
        Me.M_TextBox1.Location = New System.Drawing.Point(122, 20)
        Me.M_TextBox1.MaxLength = 16
        Me.M_TextBox1.Name = "M_TextBox1"
        Me.M_TextBox1.Size = New System.Drawing.Size(100, 29)
        Me.M_TextBox1.TabIndex = 1
        '
        'M_TextBox2
        '
        Me.M_TextBox2.Location = New System.Drawing.Point(304, 20)
        Me.M_TextBox2.MaxLength = 16
        Me.M_TextBox2.Name = "M_TextBox2"
        Me.M_TextBox2.Size = New System.Drawing.Size(171, 29)
        Me.M_TextBox2.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.AutoSize = True
        Me.txtName.Location = New System.Drawing.Point(229, 23)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(73, 20)
        Me.txtName.TabIndex = 7
        Me.txtName.Text = "員工姓名"
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(47, 23)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(73, 20)
        Me.txtID.TabIndex = 6
        Me.txtID.Text = "員工代號"
        '
        'SplitContainer
        '
        Me.SplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.IsSplitterFixed = True
        Me.SplitContainer.Location = New System.Drawing.Point(0, 143)
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
        Me.SplitContainer.Size = New System.Drawing.Size(1016, 455)
        Me.SplitContainer.SplitterDistance = 25
        Me.SplitContainer.SplitterWidth = 1
        Me.SplitContainer.TabIndex = 15
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
        Me.txtDataGridViewTitle.Text = "員工資料一覽表"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Controls.Add(Me.TabPage2)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1012, 425)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1004, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "員工資料"
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
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
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
        Me.DataGridView.Size = New System.Drawing.Size(998, 386)
        Me.DataGridView.TabIndex = 282
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridViewR)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1004, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "員工使用權限"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridViewR
        '
        Me.DataGridViewR.AllowUserToAddRows = False
        Me.DataGridViewR.AllowUserToDeleteRows = False
        Me.DataGridViewR.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridViewR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewR.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("微軟正黑體", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column7, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column8})
        Me.DataGridViewR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewR.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.DataGridViewR.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewR.Name = "DataGridViewR"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGridViewR.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewR.RowTemplate.Height = 24
        Me.DataGridViewR.Size = New System.Drawing.Size(998, 386)
        Me.DataGridViewR.TabIndex = 283
        '
        'Column1
        '
        Me.Column1.HeaderText = "查詢"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 80
        '
        'Column2
        '
        Me.Column2.HeaderText = "程式代碼"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column2.Width = 140
        '
        'Column7
        '
        Me.Column7.HeaderText = "模組別"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.HeaderText = "程式名稱"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 300
        '
        'Column4
        '
        Me.Column4.HeaderText = "新增"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 80
        '
        'Column5
        '
        Me.Column5.HeaderText = "修改"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 80
        '
        'Column6
        '
        Me.Column6.HeaderText = "刪除"
        Me.Column6.Name = "Column6"
        Me.Column6.Width = 80
        '
        'Column8
        '
        Me.Column8.HeaderText = "列印"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 80
        '
        'CopyUser
        '
        Me.CopyUser.Location = New System.Drawing.Point(407, 65)
        Me.CopyUser.MaxLength = 16
        Me.CopyUser.Name = "CopyUser"
        Me.CopyUser.Size = New System.Drawing.Size(100, 29)
        Me.CopyUser.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(210, 69)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(195, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "複製員工權限(請輸入代號)"
        '
        'BtnCopyUser
        '
        Me.BtnCopyUser.Location = New System.Drawing.Point(513, 63)
        Me.BtnCopyUser.Name = "BtnCopyUser"
        Me.BtnCopyUser.Size = New System.Drawing.Size(102, 33)
        Me.BtnCopyUser.TabIndex = 15
        Me.BtnCopyUser.Text = "複製權限"
        Me.BtnCopyUser.UseVisualStyleBackColor = True
        '
        'S99N0101
        '
        Me.ClientSize = New System.Drawing.Size(1016, 623)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "S99N0101"
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
        CType(Me.DataGridViewR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents M_TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents M_TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDataGridViewTitle As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridViewR As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnDelALL As System.Windows.Forms.Button
    Friend WithEvents btnSelectALL As System.Windows.Forms.Button
    Friend WithEvents btnAddFun As System.Windows.Forms.Button
    Friend WithEvents M_TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCopyUser As System.Windows.Forms.Button
    Friend WithEvents CopyUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
