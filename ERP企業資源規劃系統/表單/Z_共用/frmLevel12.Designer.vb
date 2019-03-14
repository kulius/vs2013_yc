<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLevel12
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
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.txtDataGridViewTitle = New System.Windows.Forms.Label()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.M_TextBox4 = New System.Windows.Forms.TextBox()
        Me.txtOther2 = New System.Windows.Forms.Label()
        Me.M_TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtOther1 = New System.Windows.Forms.Label()
        Me.編碼說明 = New System.Windows.Forms.Label()
        Me.txtPageName = New System.Windows.Forms.TextBox()
        Me.txtPage = New System.Windows.Forms.TextBox()
        Me.M_TextBox1 = New System.Windows.Forms.TextBox()
        Me.M_TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.Label()
        Me.M_TextBox5 = New System.Windows.Forms.TextBox()
        Me.txtOther3 = New System.Windows.Forms.Label()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
        Me.TabControl.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer.Size = New System.Drawing.Size(792, 405)
        Me.SplitContainer.SplitterDistance = 25
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
        Me.txtDataGridViewTitle.Text = "選項資料一覽表"
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabPage1)
        Me.TabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl.Location = New System.Drawing.Point(0, 0)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(788, 375)
        Me.TabControl.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(780, 342)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "選項資料"
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
        Me.DataGridView.Size = New System.Drawing.Size(774, 336)
        Me.DataGridView.TabIndex = 282
        '
        'MainPanel
        '
        Me.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainPanel.Controls.Add(Me.M_TextBox5)
        Me.MainPanel.Controls.Add(Me.txtOther3)
        Me.MainPanel.Controls.Add(Me.M_TextBox4)
        Me.MainPanel.Controls.Add(Me.txtOther2)
        Me.MainPanel.Controls.Add(Me.M_TextBox3)
        Me.MainPanel.Controls.Add(Me.txtOther1)
        Me.MainPanel.Controls.Add(Me.編碼說明)
        Me.MainPanel.Controls.Add(Me.txtPageName)
        Me.MainPanel.Controls.Add(Me.txtPage)
        Me.MainPanel.Controls.Add(Me.M_TextBox1)
        Me.MainPanel.Controls.Add(Me.M_TextBox2)
        Me.MainPanel.Controls.Add(Me.txtName)
        Me.MainPanel.Controls.Add(Me.txtID)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 43)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(4)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(792, 100)
        Me.MainPanel.TabIndex = 16
        '
        'M_TextBox4
        '
        Me.M_TextBox4.Location = New System.Drawing.Point(407, 56)
        Me.M_TextBox4.MaxLength = 8
        Me.M_TextBox4.Name = "M_TextBox4"
        Me.M_TextBox4.Size = New System.Drawing.Size(131, 29)
        Me.M_TextBox4.TabIndex = 4
        '
        'txtOther2
        '
        Me.txtOther2.AutoSize = True
        Me.txtOther2.Location = New System.Drawing.Point(332, 59)
        Me.txtOther2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtOther2.Name = "txtOther2"
        Me.txtOther2.Size = New System.Drawing.Size(73, 20)
        Me.txtOther2.TabIndex = 13
        Me.txtOther2.Text = "其他參數"
        '
        'M_TextBox3
        '
        Me.M_TextBox3.Location = New System.Drawing.Point(122, 55)
        Me.M_TextBox3.MaxLength = 8
        Me.M_TextBox3.Name = "M_TextBox3"
        Me.M_TextBox3.Size = New System.Drawing.Size(131, 29)
        Me.M_TextBox3.TabIndex = 3
        '
        'txtOther1
        '
        Me.txtOther1.AutoSize = True
        Me.txtOther1.Location = New System.Drawing.Point(47, 58)
        Me.txtOther1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtOther1.Name = "txtOther1"
        Me.txtOther1.Size = New System.Drawing.Size(73, 20)
        Me.txtOther1.TabIndex = 11
        Me.txtOther1.Text = "其他參數"
        Me.txtOther1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '編碼說明
        '
        Me.編碼說明.AutoSize = True
        Me.編碼說明.Location = New System.Drawing.Point(224, 24)
        Me.編碼說明.Name = "編碼說明"
        Me.編碼說明.Size = New System.Drawing.Size(73, 20)
        Me.編碼說明.TabIndex = 10
        Me.編碼說明.Text = "編碼說明"
        '
        'txtPageName
        '
        Me.txtPageName.Location = New System.Drawing.Point(622, 38)
        Me.txtPageName.Name = "txtPageName"
        Me.txtPageName.Size = New System.Drawing.Size(100, 29)
        Me.txtPageName.TabIndex = 9
        Me.txtPageName.Visible = False
        '
        'txtPage
        '
        Me.txtPage.Location = New System.Drawing.Point(622, 3)
        Me.txtPage.Name = "txtPage"
        Me.txtPage.Size = New System.Drawing.Size(100, 29)
        Me.txtPage.TabIndex = 8
        Me.txtPage.Visible = False
        '
        'M_TextBox1
        '
        Me.M_TextBox1.Location = New System.Drawing.Point(122, 20)
        Me.M_TextBox1.MaxLength = 8
        Me.M_TextBox1.Name = "M_TextBox1"
        Me.M_TextBox1.Size = New System.Drawing.Size(100, 29)
        Me.M_TextBox1.TabIndex = 1
        '
        'M_TextBox2
        '
        Me.M_TextBox2.Location = New System.Drawing.Point(407, 21)
        Me.M_TextBox2.MaxLength = 16
        Me.M_TextBox2.Name = "M_TextBox2"
        Me.M_TextBox2.Size = New System.Drawing.Size(200, 29)
        Me.M_TextBox2.TabIndex = 2
        '
        'txtName
        '
        Me.txtName.AutoSize = True
        Me.txtName.Location = New System.Drawing.Point(333, 24)
        Me.txtName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(73, 20)
        Me.txtName.TabIndex = 7
        Me.txtName.Text = "顯示名稱"
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(47, 23)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(73, 20)
        Me.txtID.TabIndex = 6
        Me.txtID.Text = "設定代碼"
        '
        'M_TextBox5
        '
        Me.M_TextBox5.Location = New System.Drawing.Point(644, 56)
        Me.M_TextBox5.MaxLength = 8
        Me.M_TextBox5.Name = "M_TextBox5"
        Me.M_TextBox5.Size = New System.Drawing.Size(131, 29)
        Me.M_TextBox5.TabIndex = 14
        '
        'txtOther3
        '
        Me.txtOther3.AutoSize = True
        Me.txtOther3.Location = New System.Drawing.Point(569, 59)
        Me.txtOther3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtOther3.Name = "txtOther3"
        Me.txtOther3.Size = New System.Drawing.Size(73, 20)
        Me.txtOther3.TabIndex = 15
        Me.txtOther3.Text = "其他參數"
        '
        'frmLevel12
        '
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.SplitContainer)
        Me.Controls.Add(Me.MainPanel)
        Me.Name = "frmLevel12"
        Me.Text = "基本對照資料維護"
        Me.Controls.SetChildIndex(Me.MainPanel, 0)
        Me.Controls.SetChildIndex(Me.SplitContainer, 0)
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel1.PerformLayout()
        Me.SplitContainer.Panel2.ResumeLayout(False)
        Me.SplitContainer.ResumeLayout(False)
        Me.TabControl.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents txtDataGridViewTitle As System.Windows.Forms.Label
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents M_TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents M_TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtName As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents txtPage As System.Windows.Forms.TextBox
    Friend WithEvents txtPageName As System.Windows.Forms.TextBox
    Friend WithEvents 編碼說明 As System.Windows.Forms.Label
    Friend WithEvents M_TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents txtOther1 As System.Windows.Forms.Label
    Friend WithEvents M_TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents txtOther2 As System.Windows.Forms.Label
    Friend WithEvents M_TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents txtOther3 As System.Windows.Forms.Label

End Class
