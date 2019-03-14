<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class R01N0009
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
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.RepPanel = New System.Windows.Forms.Panel()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.製造日期1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.MainPanel.SuspendLayout()
        Me.RepPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.btnDesignRep)
        Me.MainPanel.Controls.Add(Me.製造日期1)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Controls.Add(Me.btnPreviewRep)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(8)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(786, 105)
        Me.MainPanel.TabIndex = 2
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(448, 8)
        Me.btnPreviewRep.Margin = New System.Windows.Forms.Padding(8)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(109, 65)
        Me.btnPreviewRep.TabIndex = 0
        Me.btnPreviewRep.Text = "預覽列印"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'RepPanel
        '
        Me.RepPanel.Controls.Add(Me.PreviewControl1)
        Me.RepPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepPanel.Location = New System.Drawing.Point(0, 105)
        Me.RepPanel.Margin = New System.Windows.Forms.Padding(8)
        Me.RepPanel.Name = "RepPanel"
        Me.RepPanel.Size = New System.Drawing.Size(786, 354)
        Me.RepPanel.TabIndex = 3
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 0)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(8)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(786, 354)
        Me.PreviewControl1.TabIndex = 1
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        '製造日期1
        '
        Me.製造日期1.Location = New System.Drawing.Point(133, 24)
        Me.製造日期1.Margin = New System.Windows.Forms.Padding(5)
        Me.製造日期1.Name = "製造日期1"
        Me.製造日期1.Size = New System.Drawing.Size(143, 29)
        Me.製造日期1.TabIndex = 268
        Me.製造日期1.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 269
        Me.Label1.Text = "製造日期"
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(685, 57)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(89, 37)
        Me.btnDesignRep.TabIndex = 270
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        'R01N0009
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 459)
        Me.Controls.Add(Me.RepPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "R01N0009"
        Me.Text = "BaseReport"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.RepPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents RepPanel As System.Windows.Forms.Panel
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents 製造日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
End Class
