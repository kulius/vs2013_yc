<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PreviewReport
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
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblRepKey2 = New System.Windows.Forms.Label()
        Me.lblRepKey1 = New System.Windows.Forms.Label()
        Me.lblRepKey = New System.Windows.Forms.Label()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.lblReportFile = New System.Windows.Forms.Label()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.lblRepKey3 = New System.Windows.Forms.Label()
        Me.lblRepKey4 = New System.Windows.Forms.Label()
        Me.lblRepKey5 = New System.Windows.Forms.Label()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 41)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(689, 449)
        Me.PreviewControl1.TabIndex = 5
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.lblRepKey5)
        Me.Panel5.Controls.Add(Me.lblRepKey4)
        Me.Panel5.Controls.Add(Me.lblRepKey3)
        Me.Panel5.Controls.Add(Me.lblRepKey2)
        Me.Panel5.Controls.Add(Me.lblRepKey1)
        Me.Panel5.Controls.Add(Me.lblRepKey)
        Me.Panel5.Controls.Add(Me.btnPreviewRep)
        Me.Panel5.Controls.Add(Me.lblReportFile)
        Me.Panel5.Controls.Add(Me.btnDesignRep)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(689, 41)
        Me.Panel5.TabIndex = 6
        '
        'lblRepKey2
        '
        Me.lblRepKey2.AutoSize = True
        Me.lblRepKey2.Location = New System.Drawing.Point(540, 4)
        Me.lblRepKey2.Name = "lblRepKey2"
        Me.lblRepKey2.Size = New System.Drawing.Size(58, 20)
        Me.lblRepKey2.TabIndex = 7
        Me.lblRepKey2.Text = "Label2"
        Me.lblRepKey2.Visible = False
        '
        'lblRepKey1
        '
        Me.lblRepKey1.AutoSize = True
        Me.lblRepKey1.Location = New System.Drawing.Point(476, 4)
        Me.lblRepKey1.Name = "lblRepKey1"
        Me.lblRepKey1.Size = New System.Drawing.Size(58, 20)
        Me.lblRepKey1.TabIndex = 6
        Me.lblRepKey1.Text = "Label1"
        Me.lblRepKey1.Visible = False
        '
        'lblRepKey
        '
        Me.lblRepKey.AutoSize = True
        Me.lblRepKey.Location = New System.Drawing.Point(217, 12)
        Me.lblRepKey.Name = "lblRepKey"
        Me.lblRepKey.Size = New System.Drawing.Size(83, 20)
        Me.lblRepKey.TabIndex = 5
        Me.lblRepKey.Text = "lblRepKey"
        '
        'btnPreviewRep
        '
        Me.btnPreviewRep.Location = New System.Drawing.Point(110, 4)
        Me.btnPreviewRep.Name = "btnPreviewRep"
        Me.btnPreviewRep.Size = New System.Drawing.Size(101, 37)
        Me.btnPreviewRep.TabIndex = 4
        Me.btnPreviewRep.Text = "預覽報表"
        Me.btnPreviewRep.UseVisualStyleBackColor = True
        '
        'lblReportFile
        '
        Me.lblReportFile.AutoSize = True
        Me.lblReportFile.Location = New System.Drawing.Point(319, 12)
        Me.lblReportFile.Name = "lblReportFile"
        Me.lblReportFile.Size = New System.Drawing.Size(103, 20)
        Me.lblReportFile.TabIndex = 2
        Me.lblReportFile.Text = "lblReportFile"
        '
        'btnDesignRep
        '
        Me.btnDesignRep.Location = New System.Drawing.Point(3, 4)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(101, 37)
        Me.btnDesignRep.TabIndex = 1
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        'lblRepKey3
        '
        Me.lblRepKey3.AutoSize = True
        Me.lblRepKey3.Location = New System.Drawing.Point(604, 4)
        Me.lblRepKey3.Name = "lblRepKey3"
        Me.lblRepKey3.Size = New System.Drawing.Size(58, 20)
        Me.lblRepKey3.TabIndex = 8
        Me.lblRepKey3.Text = "Label2"
        Me.lblRepKey3.Visible = False
        '
        'lblRepKey4
        '
        Me.lblRepKey4.AutoSize = True
        Me.lblRepKey4.Location = New System.Drawing.Point(476, 18)
        Me.lblRepKey4.Name = "lblRepKey4"
        Me.lblRepKey4.Size = New System.Drawing.Size(58, 20)
        Me.lblRepKey4.TabIndex = 9
        Me.lblRepKey4.Text = "Label2"
        Me.lblRepKey4.Visible = False
        '
        'lblRepKey5
        '
        Me.lblRepKey5.AutoSize = True
        Me.lblRepKey5.Location = New System.Drawing.Point(540, 21)
        Me.lblRepKey5.Name = "lblRepKey5"
        Me.lblRepKey5.Size = New System.Drawing.Size(58, 20)
        Me.lblRepKey5.TabIndex = 10
        Me.lblRepKey5.Text = "Label2"
        Me.lblRepKey5.Visible = False
        '
        'PreviewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(689, 490)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Controls.Add(Me.Panel5)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "PreviewReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "預覽列印"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Public WithEvents lblReportFile As System.Windows.Forms.Label
    Public WithEvents lblRepKey As System.Windows.Forms.Label
    Public WithEvents lblRepKey2 As System.Windows.Forms.Label
    Public WithEvents lblRepKey1 As System.Windows.Forms.Label
    Public WithEvents lblRepKey5 As System.Windows.Forms.Label
    Public WithEvents lblRepKey4 As System.Windows.Forms.Label
    Public WithEvents lblRepKey3 As System.Windows.Forms.Label
End Class
