<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S_S03N0120_1
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

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(S_S03N0120_1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.產品名稱 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.線材爐號 = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.強度級數 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSerData = New System.Windows.Forms.Button()
        Me.材質代碼 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.加工方式代碼 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.品名分類代碼 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.長度代碼 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.規格代碼 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.產品代碼 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDefine = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 21)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "設定搜尋條件"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.產品名稱)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.線材爐號)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.強度級數)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnSerData)
        Me.Panel1.Controls.Add(Me.材質代碼)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.加工方式代碼)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.品名分類代碼)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.長度代碼)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.規格代碼)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.產品代碼)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(812, 124)
        Me.Panel1.TabIndex = 17
        '
        '產品名稱
        '
        Me.產品名稱.Location = New System.Drawing.Point(58, 95)
        Me.產品名稱.Name = "產品名稱"
        Me.產品名稱.Size = New System.Drawing.Size(138, 22)
        Me.產品名稱.TabIndex = 147
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 148
        Me.Label3.Text = "產品名稱"
        '
        '線材爐號
        '
        Me.線材爐號.Location = New System.Drawing.Point(657, 64)
        Me.線材爐號.Name = "線材爐號"
        Me.線材爐號.Size = New System.Drawing.Size(138, 22)
        Me.線材爐號.TabIndex = 145
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(601, 69)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(53, 12)
        Me.Label29.TabIndex = 146
        Me.Label29.Text = "線材爐號"
        '
        '強度級數
        '
        Me.強度級數.FormattingEnabled = True
        Me.強度級數.Location = New System.Drawing.Point(658, 32)
        Me.強度級數.Name = "強度級數"
        Me.強度級數.Size = New System.Drawing.Size(137, 20)
        Me.強度級數.TabIndex = 128
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(601, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 129
        Me.Label2.Text = "強度級數"
        '
        'btnSerData
        '
        Me.btnSerData.Location = New System.Drawing.Point(458, 96)
        Me.btnSerData.Name = "btnSerData"
        Me.btnSerData.Size = New System.Drawing.Size(75, 23)
        Me.btnSerData.TabIndex = 127
        Me.btnSerData.Text = "蒐尋"
        Me.btnSerData.UseVisualStyleBackColor = True
        '
        '材質代碼
        '
        Me.材質代碼.FormattingEnabled = True
        Me.材質代碼.Location = New System.Drawing.Point(458, 66)
        Me.材質代碼.Name = "材質代碼"
        Me.材質代碼.Size = New System.Drawing.Size(137, 20)
        Me.材質代碼.TabIndex = 120
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(415, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 12)
        Me.Label15.TabIndex = 126
        Me.Label15.Text = "材質"
        '
        '加工方式代碼
        '
        Me.加工方式代碼.FormattingEnabled = True
        Me.加工方式代碼.Location = New System.Drawing.Point(268, 66)
        Me.加工方式代碼.Name = "加工方式代碼"
        Me.加工方式代碼.Size = New System.Drawing.Size(137, 20)
        Me.加工方式代碼.TabIndex = 119
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(201, 69)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "加工方式"
        '
        '品名分類代碼
        '
        Me.品名分類代碼.FormattingEnabled = True
        Me.品名分類代碼.Location = New System.Drawing.Point(59, 66)
        Me.品名分類代碼.Name = "品名分類代碼"
        Me.品名分類代碼.Size = New System.Drawing.Size(137, 20)
        Me.品名分類代碼.TabIndex = 118
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 12)
        Me.Label13.TabIndex = 124
        Me.Label13.Text = "品名分類"
        '
        '長度代碼
        '
        Me.長度代碼.FormattingEnabled = True
        Me.長度代碼.Location = New System.Drawing.Point(458, 32)
        Me.長度代碼.Name = "長度代碼"
        Me.長度代碼.Size = New System.Drawing.Size(137, 20)
        Me.長度代碼.TabIndex = 117
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(415, 35)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 12)
        Me.Label12.TabIndex = 123
        Me.Label12.Text = "長度"
        '
        '規格代碼
        '
        Me.規格代碼.FormattingEnabled = True
        Me.規格代碼.Location = New System.Drawing.Point(268, 32)
        Me.規格代碼.Name = "規格代碼"
        Me.規格代碼.Size = New System.Drawing.Size(137, 20)
        Me.規格代碼.TabIndex = 116
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(225, 35)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 12)
        Me.Label11.TabIndex = 122
        Me.Label11.Text = "規格"
        '
        '產品代碼
        '
        Me.產品代碼.FormattingEnabled = True
        Me.產品代碼.Location = New System.Drawing.Point(59, 32)
        Me.產品代碼.Name = "產品代碼"
        Me.產品代碼.Size = New System.Drawing.Size(137, 20)
        Me.產品代碼.TabIndex = 115
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 35)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 12)
        Me.Label10.TabIndex = 121
        Me.Label10.Text = "品名"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDefine)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 311)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(812, 56)
        Me.Panel2.TabIndex = 21
        '
        'btnDefine
        '
        Me.btnDefine.Image = CType(resources.GetObject("btnDefine.Image"), System.Drawing.Image)
        Me.btnDefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefine.Location = New System.Drawing.Point(588, 10)
        Me.btnDefine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(100, 30)
        Me.btnDefine.TabIndex = 21
        Me.btnDefine.Text = "確定(&Y)"
        Me.btnDefine.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(696, 10)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "取消(&Z)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 124)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(812, 187)
        Me.Panel3.TabIndex = 22
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
        Me.DataGridView.Size = New System.Drawing.Size(812, 187)
        Me.DataGridView.TabIndex = 283
        '
        'S_S03N0120_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(812, 367)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "S_S03N0120_1"
        Me.Text = "S_S03N0120_1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnSerData As System.Windows.Forms.Button
    Public WithEvents 材質代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 加工方式代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 品名分類代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 長度代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 規格代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 產品代碼 As System.Windows.Forms.ComboBox
    Public WithEvents 強度級數 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Public WithEvents 線材爐號 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Public WithEvents 產品名稱 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents btnDefine As System.Windows.Forms.Button
End Class
