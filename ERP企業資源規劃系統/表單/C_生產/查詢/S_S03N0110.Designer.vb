<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S_S03N0110
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(S_S03N0110))
        Me.S_TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnDefine = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.S_ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.S_Date = New System.Windows.Forms.DateTimePicker()
        Me.CK1 = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'S_TextBox1
        '
        Me.S_TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.S_TextBox1.Location = New System.Drawing.Point(95, 50)
        Me.S_TextBox1.MaxLength = 10
        Me.S_TextBox1.Name = "S_TextBox1"
        Me.S_TextBox1.Size = New System.Drawing.Size(120, 27)
        Me.S_TextBox1.TabIndex = 2
        '
        'btnDefine
        '
        Me.btnDefine.Image = CType(resources.GetObject("btnDefine.Image"), System.Drawing.Image)
        Me.btnDefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefine.Location = New System.Drawing.Point(263, 154)
        Me.btnDefine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnDefine.Name = "btnDefine"
        Me.btnDefine.Size = New System.Drawing.Size(100, 30)
        Me.btnDefine.TabIndex = 15
        Me.btnDefine.Text = "確定(&Y)"
        Me.btnDefine.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 21)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "設定搜尋條件"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "車次序號"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CK1)
        Me.Panel1.Controls.Add(Me.S_Date)
        Me.Panel1.Controls.Add(Me.S_ComboBox1)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.S_TextBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(14, 20)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 124)
        Me.Panel1.TabIndex = 13
        '
        'S_ComboBox1
        '
        Me.S_ComboBox1.FormattingEnabled = True
        Me.S_ComboBox1.Location = New System.Drawing.Point(95, 20)
        Me.S_ComboBox1.Name = "S_ComboBox1"
        Me.S_ComboBox1.Size = New System.Drawing.Size(200, 24)
        Me.S_ComboBox1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(36, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 16)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "載貨員"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(371, 154)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "取消(&Z)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'S_Date
        '
        Me.S_Date.Location = New System.Drawing.Point(95, 80)
        Me.S_Date.Name = "S_Date"
        Me.S_Date.Size = New System.Drawing.Size(170, 27)
        Me.S_Date.TabIndex = 80
        '
        'CK1
        '
        Me.CK1.AutoSize = True
        Me.CK1.Location = New System.Drawing.Point(1, 83)
        Me.CK1.Name = "CK1"
        Me.CK1.Size = New System.Drawing.Size(91, 20)
        Me.CK1.TabIndex = 81
        Me.CK1.Text = "過磅日期"
        Me.CK1.UseVisualStyleBackColor = True
        '
        'S_S03N0110
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(484, 196)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.MaximizeBox = False
        Me.Name = "S_S03N0110"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定查詢條件"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents S_TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnDefine As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents S_ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents S_Date As System.Windows.Forms.DateTimePicker
    Friend WithEvents CK1 As System.Windows.Forms.CheckBox
End Class
