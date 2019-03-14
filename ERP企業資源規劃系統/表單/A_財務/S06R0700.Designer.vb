<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S06R0700
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
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.出貨日期2 = New System.Windows.Forms.DateTimePicker()
        Me.出貨日期1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.RepPanel = New System.Windows.Forms.Panel()
        Me.MainPanel.SuspendLayout()
        Me.RepPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.btnPreviewRep)
        Me.MainPanel.Controls.Add(Me.btnDesignRep)
        Me.MainPanel.Controls.Add(Me.出貨日期2)
        Me.MainPanel.Controls.Add(Me.出貨日期1)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(649, 103)
        Me.MainPanel.TabIndex = 16
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(402, 18)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(101, 64)
        Me.btnPreviewRep.TabIndex = 270
        Me.btnPreviewRep.Text = "預覽報表"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(540, 62)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(89, 37)
        Me.btnDesignRep.TabIndex = 269
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        '出貨日期2
        '
        Me.出貨日期2.Location = New System.Drawing.Point(244, 44)
        Me.出貨日期2.Margin = New System.Windows.Forms.Padding(5)
        Me.出貨日期2.Name = "出貨日期2"
        Me.出貨日期2.Size = New System.Drawing.Size(150, 29)
        Me.出貨日期2.TabIndex = 268
        Me.出貨日期2.Tag = ""
        '
        '出貨日期1
        '
        Me.出貨日期1.Location = New System.Drawing.Point(91, 44)
        Me.出貨日期1.Margin = New System.Windows.Forms.Padding(5)
        Me.出貨日期1.Name = "出貨日期1"
        Me.出貨日期1.Size = New System.Drawing.Size(143, 29)
        Me.出貨日期1.TabIndex = 266
        Me.出貨日期1.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 267
        Me.Label1.Text = "出貨日期"
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(649, 353)
        Me.PreviewControl1.TabIndex = 1
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'RepPanel
        '
        Me.RepPanel.Controls.Add(Me.PreviewControl1)
        Me.RepPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepPanel.Location = New System.Drawing.Point(0, 103)
        Me.RepPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.RepPanel.Name = "RepPanel"
        Me.RepPanel.Size = New System.Drawing.Size(649, 353)
        Me.RepPanel.TabIndex = 17
        '
        'S06R0700
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 456)
        Me.Controls.Add(Me.RepPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "S06R0700"
        Me.Text = "S06R0700"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.RepPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents 出貨日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 出貨日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents RepPanel As System.Windows.Forms.Panel
End Class
