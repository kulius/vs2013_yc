<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class R01N0008
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
        Me.s爐號 = New System.Windows.Forms.ComboBox()
        Me.l爐號 = New System.Windows.Forms.Label()
        Me.報表名稱 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.製造日期2 = New System.Windows.Forms.DateTimePicker()
        Me.製造日期1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RepPanel = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.MainPanel.SuspendLayout()
        Me.RepPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.s爐號)
        Me.MainPanel.Controls.Add(Me.l爐號)
        Me.MainPanel.Controls.Add(Me.報表名稱)
        Me.MainPanel.Controls.Add(Me.Label2)
        Me.MainPanel.Controls.Add(Me.btnPreviewRep)
        Me.MainPanel.Controls.Add(Me.btnDesignRep)
        Me.MainPanel.Controls.Add(Me.製造日期2)
        Me.MainPanel.Controls.Add(Me.製造日期1)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(692, 116)
        Me.MainPanel.TabIndex = 14
        '
        's爐號
        '
        Me.s爐號.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.s爐號.FormattingEnabled = True
        Me.s爐號.Location = New System.Drawing.Point(91, 86)
        Me.s爐號.Name = "s爐號"
        Me.s爐號.Size = New System.Drawing.Size(60, 28)
        Me.s爐號.TabIndex = 274
        Me.s爐號.Visible = False
        '
        'l爐號
        '
        Me.l爐號.AutoSize = True
        Me.l爐號.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.l爐號.Location = New System.Drawing.Point(43, 90)
        Me.l爐號.Name = "l爐號"
        Me.l爐號.Size = New System.Drawing.Size(41, 20)
        Me.l爐號.TabIndex = 273
        Me.l爐號.Text = "爐號"
        Me.l爐號.Visible = False
        '
        '報表名稱
        '
        Me.報表名稱.FormattingEnabled = True
        Me.報表名稱.Items.AddRange(New Object() {"全爐產量表", "個爐產量表", "組長及個人產量表", "個人產量表", "各爐個人每日產量明細表", "各爐個人不合格品明細表", "產量異常資料表"})
        Me.報表名稱.Location = New System.Drawing.Point(91, 56)
        Me.報表名稱.Name = "報表名稱"
        Me.報表名稱.Size = New System.Drawing.Size(305, 28)
        Me.報表名稱.TabIndex = 272
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 271
        Me.Label2.Text = "報表名稱"
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
        Me.btnDesignRep.Location = New System.Drawing.Point(564, 59)
        Me.btnDesignRep.Name = "btnDesignRep"
        Me.btnDesignRep.Size = New System.Drawing.Size(89, 37)
        Me.btnDesignRep.TabIndex = 269
        Me.btnDesignRep.Text = "設計報表"
        Me.btnDesignRep.UseVisualStyleBackColor = True
        '
        '製造日期2
        '
        Me.製造日期2.Location = New System.Drawing.Point(244, 24)
        Me.製造日期2.Margin = New System.Windows.Forms.Padding(5)
        Me.製造日期2.Name = "製造日期2"
        Me.製造日期2.Size = New System.Drawing.Size(150, 29)
        Me.製造日期2.TabIndex = 268
        Me.製造日期2.Tag = ""
        '
        '製造日期1
        '
        Me.製造日期1.Location = New System.Drawing.Point(91, 24)
        Me.製造日期1.Margin = New System.Windows.Forms.Padding(5)
        Me.製造日期1.Name = "製造日期1"
        Me.製造日期1.Size = New System.Drawing.Size(143, 29)
        Me.製造日期1.TabIndex = 266
        Me.製造日期1.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 267
        Me.Label1.Text = "製造日期"
        '
        'RepPanel
        '
        Me.RepPanel.Controls.Add(Me.TabControl1)
        Me.RepPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RepPanel.Location = New System.Drawing.Point(0, 116)
        Me.RepPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.RepPanel.Name = "RepPanel"
        Me.RepPanel.Size = New System.Drawing.Size(692, 319)
        Me.RepPanel.TabIndex = 15
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(692, 319)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.PreviewControl1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(684, 286)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "報表"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(3, 3)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(678, 280)
        Me.PreviewControl1.TabIndex = 3
        Me.PreviewControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'R01N0008
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 435)
        Me.Controls.Add(Me.RepPanel)
        Me.Controls.Add(Me.MainPanel)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "R01N0008"
        Me.Text = "R01N0008"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.RepPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents 製造日期2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 製造日期1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RepPanel As System.Windows.Forms.Panel
    Friend WithEvents 報表名稱 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents s爐號 As System.Windows.Forms.ComboBox
    Friend WithEvents l爐號 As System.Windows.Forms.Label
End Class
