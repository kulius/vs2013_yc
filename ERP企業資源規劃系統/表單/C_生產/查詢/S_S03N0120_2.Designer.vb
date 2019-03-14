<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S_S03N0120_2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(S_S03N0120_2))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDefine = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.廠外退回 = New System.Windows.Forms.RadioButton()
        Me.廠內退回 = New System.Windows.Forms.RadioButton()
        Me.BackDataDGV = New System.Windows.Forms.DataGridView()
        Me.出貨退回編號 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.工令號碼 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.退回備註 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.轉廠 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BackDataDGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnDefine)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(695, 73)
        Me.Panel1.TabIndex = 0
        '
        'btnDefine
        '
        Me.btnDefine.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnDefine.Image = CType(resources.GetObject("btnDefine.Image"), System.Drawing.Image)
        Me.btnDefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefine.Location = New System.Drawing.Point(456, 31)
        Me.btnDefine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(100, 30)
        Me.btnDefine.TabIndex = 259
        Me.btnDefine.Text = "確定(&Y)"
        Me.btnDefine.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(564, 31)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 260
        Me.btnCancel.Text = "取消(&Z)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.轉廠)
        Me.GroupBox2.Controls.Add(Me.廠外退回)
        Me.GroupBox2.Controls.Add(Me.廠內退回)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 11)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(425, 56)
        Me.GroupBox2.TabIndex = 258
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "MCtrl"
        Me.GroupBox2.Text = "請選擇退回來源"
        '
        '廠外退回
        '
        Me.廠外退回.AutoSize = True
        Me.廠外退回.ForeColor = System.Drawing.SystemColors.ControlText
        Me.廠外退回.Location = New System.Drawing.Point(123, 23)
        Me.廠外退回.Name = "廠外退回"
        Me.廠外退回.Size = New System.Drawing.Size(91, 24)
        Me.廠外退回.TabIndex = 216
        Me.廠外退回.Tag = "BCtrl"
        Me.廠外退回.Text = "廠外退回"
        Me.廠外退回.UseVisualStyleBackColor = True
        '
        '廠內退回
        '
        Me.廠內退回.AutoSize = True
        Me.廠內退回.ForeColor = System.Drawing.SystemColors.ControlText
        Me.廠內退回.Location = New System.Drawing.Point(26, 23)
        Me.廠內退回.Name = "廠內退回"
        Me.廠內退回.Size = New System.Drawing.Size(91, 24)
        Me.廠內退回.TabIndex = 215
        Me.廠內退回.Tag = "BCtrl"
        Me.廠內退回.Text = "廠內退回"
        Me.廠內退回.UseVisualStyleBackColor = True
        '
        'BackDataDGV
        '
        Me.BackDataDGV.AllowUserToAddRows = False
        Me.BackDataDGV.AllowUserToDeleteRows = False
        Me.BackDataDGV.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BackDataDGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.BackDataDGV.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.BackDataDGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.BackDataDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BackDataDGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.出貨退回編號, Me.工令號碼, Me.退回備註})
        Me.BackDataDGV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BackDataDGV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.BackDataDGV.Location = New System.Drawing.Point(0, 73)
        Me.BackDataDGV.Name = "BackDataDGV"
        DataGridViewCellStyle3.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.BackDataDGV.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.BackDataDGV.RowTemplate.Height = 24
        Me.BackDataDGV.Size = New System.Drawing.Size(695, 248)
        Me.BackDataDGV.TabIndex = 15
        '
        '出貨退回編號
        '
        Me.出貨退回編號.HeaderText = "出貨退回編號"
        Me.出貨退回編號.Name = "出貨退回編號"
        Me.出貨退回編號.ReadOnly = True
        '
        '工令號碼
        '
        Me.工令號碼.HeaderText = "工令號碼"
        Me.工令號碼.Name = "工令號碼"
        Me.工令號碼.ReadOnly = True
        '
        '退回備註
        '
        Me.退回備註.HeaderText = "退回備註"
        Me.退回備註.Name = "退回備註"
        Me.退回備註.ReadOnly = True
        '
        '轉廠
        '
        Me.轉廠.AutoSize = True
        Me.轉廠.ForeColor = System.Drawing.SystemColors.ControlText
        Me.轉廠.Location = New System.Drawing.Point(220, 23)
        Me.轉廠.Name = "轉廠"
        Me.轉廠.Size = New System.Drawing.Size(59, 24)
        Me.轉廠.TabIndex = 217
        Me.轉廠.Tag = "BCtrl"
        Me.轉廠.Text = "轉廠"
        Me.轉廠.UseVisualStyleBackColor = True
        '
        'S_S03N0120_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 321)
        Me.Controls.Add(Me.BackDataDGV)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "S_S03N0120_2"
        Me.Text = "S_S03N0120_2"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BackDataDGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BackDataDGV As System.Windows.Forms.DataGridView
    Friend WithEvents 出貨退回編號 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 工令號碼 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents 退回備註 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents 廠外退回 As System.Windows.Forms.RadioButton
    Friend WithEvents 廠內退回 As System.Windows.Forms.RadioButton
    Friend WithEvents btnDefine As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents 轉廠 As System.Windows.Forms.RadioButton
End Class
