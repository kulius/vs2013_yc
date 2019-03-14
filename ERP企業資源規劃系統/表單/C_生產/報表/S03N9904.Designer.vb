<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S03N9904
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.RecMove1 = New ERP企業資源規劃系統.RecMove()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.所屬年 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGrid1 = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RepPanel = New System.Windows.Forms.Panel()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.s客戶代碼 = New System.Windows.Forms.TextBox()
        Me.s客戶代號 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.RepPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'RecMove1
        '
        Me.RecMove1.Dock = System.Windows.Forms.DockStyle.Top
        Me.RecMove1.FilesPara = Nothing
        Me.RecMove1.GenInsFunc = "() values ()"
        Me.RecMove1.genupdfunc = ""
        Me.RecMove1.Location = New System.Drawing.Point(0, 0)
        Me.RecMove1.Margin = New System.Windows.Forms.Padding(7, 6, 7, 6)
        Me.RecMove1.Name = "RecMove1"
        Me.RecMove1.Setds = Nothing
        Me.RecMove1.Setpos = 0
        Me.RecMove1.Size = New System.Drawing.Size(831, 52)
        Me.RecMove1.TabIndex = 134
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.s客戶代碼)
        Me.Panel1.Controls.Add(Me.s客戶代號)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.所屬年)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.BtnSearch)
        Me.Panel1.Controls.Add(Me.btnExit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(831, 48)
        Me.Panel1.TabIndex = 135
        '
        '所屬年
        '
        Me.所屬年.Location = New System.Drawing.Point(388, 16)
        Me.所屬年.Margin = New System.Windows.Forms.Padding(5)
        Me.所屬年.Name = "所屬年"
        Me.所屬年.Size = New System.Drawing.Size(190, 25)
        Me.所屬年.TabIndex = 272
        Me.所屬年.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(317, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 15)
        Me.Label1.TabIndex = 271
        Me.Label1.Text = "所屬年"
        '
        'BtnSearch
        '
        Me.BtnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnSearch.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.BtnSearch.Location = New System.Drawing.Point(591, 12)
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
        Me.btnExit.Location = New System.Drawing.Point(655, 12)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(56, 32)
        Me.btnExit.TabIndex = 130
        Me.btnExit.Text = "離開"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 100)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(831, 475)
        Me.TabControl1.TabIndex = 136
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGrid1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(823, 445)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "多筆瀏覽"
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowUserToAddRows = False
        Me.DataGrid1.AllowUserToDeleteRows = False
        Me.DataGrid1.AllowUserToOrderColumns = True
        DataGridViewCellStyle13.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle13
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("新細明體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGrid1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.DataGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.DataGrid1.Location = New System.Drawing.Point(0, 0)
        Me.DataGrid1.Name = "DataGrid1"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.DataGrid1.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.DataGrid1.RowTemplate.Height = 24
        Me.DataGrid1.Size = New System.Drawing.Size(823, 445)
        Me.DataGrid1.TabIndex = 290
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RepPanel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(823, 445)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "報表"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RepPanel
        '
        Me.RepPanel.Controls.Add(Me.btnPreviewRep)
        Me.RepPanel.Controls.Add(Me.btnDesignRep)
        Me.RepPanel.Controls.Add(Me.PreviewControl1)
        Me.RepPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepPanel.Location = New System.Drawing.Point(0, 0)
        Me.RepPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.RepPanel.Name = "RepPanel"
        Me.RepPanel.Size = New System.Drawing.Size(823, 445)
        Me.RepPanel.TabIndex = 20
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(11, 3)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(101, 34)
        Me.btnPreviewRep.TabIndex = 272
        Me.btnPreviewRep.Text = "預覽報表"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(131, 3)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(89, 34)
        Me.btnDesignRep.TabIndex = 271
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 45)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(823, 400)
        Me.PreviewControl1.TabIndex = 1
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        's客戶代碼
        '
        Me.s客戶代碼.Location = New System.Drawing.Point(53, 16)
        Me.s客戶代碼.Name = "s客戶代碼"
        Me.s客戶代碼.Size = New System.Drawing.Size(78, 25)
        Me.s客戶代碼.TabIndex = 275
        Me.s客戶代碼.Tag = ""
        '
        's客戶代號
        '
        Me.s客戶代號.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.s客戶代號.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.s客戶代號.FormattingEnabled = True
        Me.s客戶代號.Location = New System.Drawing.Point(131, 17)
        Me.s客戶代號.Name = "s客戶代號"
        Me.s客戶代號.Size = New System.Drawing.Size(176, 23)
        Me.s客戶代號.TabIndex = 273
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 274
        Me.Label2.Text = "客戶"
        '
        'S03N9904
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 575)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RecMove1)
        Me.Font = New System.Drawing.Font("新細明體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "S03N9904"
        Me.Text = "S03N9904"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.RepPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RecMove1 As ERP企業資源規劃系統.RecMove
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents 所屬年 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents RepPanel As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Public WithEvents s客戶代碼 As System.Windows.Forms.TextBox
    Friend WithEvents s客戶代號 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
