<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class R01N0001
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
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.統計日期2 = New System.Windows.Forms.DateTimePicker()
        Me.統計日期1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.司機代號 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RepPanel = New System.Windows.Forms.Panel()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.MainPanel.SuspendLayout()
        Me.RepPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.btnDesignRep)
        Me.MainPanel.Controls.Add(Me.統計日期2)
        Me.MainPanel.Controls.Add(Me.統計日期1)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.Label3)
        Me.MainPanel.Controls.Add(Me.司機代號)
        Me.MainPanel.Controls.Add(Me.Button1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(792, 103)
        Me.MainPanel.TabIndex = 0
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(700, 66)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(89, 37)
        Me.btnDesignRep.TabIndex = 270
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        '統計日期2
        '
        Me.統計日期2.Location = New System.Drawing.Point(278, 66)
        Me.統計日期2.Margin = New System.Windows.Forms.Padding(5)
        Me.統計日期2.Name = "統計日期2"
        Me.統計日期2.Size = New System.Drawing.Size(150, 29)
        Me.統計日期2.TabIndex = 268
        Me.統計日期2.Tag = ""
        '
        '統計日期1
        '
        Me.統計日期1.Location = New System.Drawing.Point(125, 66)
        Me.統計日期1.Margin = New System.Windows.Forms.Padding(5)
        Me.統計日期1.Name = "統計日期1"
        Me.統計日期1.Size = New System.Drawing.Size(143, 29)
        Me.統計日期1.TabIndex = 266
        Me.統計日期1.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(50, 70)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 267
        Me.Label1.Text = "統計日期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 263
        Me.Label3.Text = "司機姓名"
        '
        '司機代號
        '
        Me.司機代號.FormattingEnabled = True
        Me.司機代號.Location = New System.Drawing.Point(125, 19)
        Me.司機代號.Margin = New System.Windows.Forms.Padding(5)
        Me.司機代號.Name = "司機代號"
        Me.司機代號.Size = New System.Drawing.Size(247, 28)
        Me.司機代號.TabIndex = 262
        Me.司機代號.TabStop = False
        Me.司機代號.Tag = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 23)
        Me.Button1.Margin = New System.Windows.Forms.Padding(5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 67)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "預覽列印"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RepPanel
        '
        Me.RepPanel.Controls.Add(Me.PreviewControl1)
        Me.RepPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepPanel.Location = New System.Drawing.Point(0, 103)
        Me.RepPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.RepPanel.Name = "RepPanel"
        Me.RepPanel.Size = New System.Drawing.Size(792, 570)
        Me.RepPanel.TabIndex = 1
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(792, 570)
        Me.PreviewControl1.TabIndex = 1
        '
        'R01N0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 673)
        Me.Controls.Add(Me.RepPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "R01N0001"
        Me.Text = "司機載貨明細"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.RepPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents RepPanel As System.Windows.Forms.Panel
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents 司機代號 As System.Windows.Forms.ComboBox
    Friend WithEvents 統計日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 統計日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
End Class
