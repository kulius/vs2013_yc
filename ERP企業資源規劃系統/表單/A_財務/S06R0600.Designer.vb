﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S06R0600
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
        Me.btnPreviewRep = New System.Windows.Forms.Button()
        Me.btnDesignRep = New System.Windows.Forms.Button()
        Me.PreviewControl1 = New FastReport.Preview.PreviewControl()
        Me.MainPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.MainPanel.SuspendLayout()
        Me.SuspendLayout()
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
        'PreviewControl1
        '
        Me.PreviewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.PreviewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PreviewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.PreviewControl1.Location = New System.Drawing.Point(0, 103)
        Me.PreviewControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.PreviewControl1.Name = "PreviewControl1"
        Me.PreviewControl1.Size = New System.Drawing.Size(645, 400)
        Me.PreviewControl1.TabIndex = 17
        '
        'MainPanel
        '
        Me.MainPanel.Controls.Add(Me.TextBox2)
        Me.MainPanel.Controls.Add(Me.TextBox1)
        Me.MainPanel.Controls.Add(Me.btnPreviewRep)
        Me.MainPanel.Controls.Add(Me.btnDesignRep)
        Me.MainPanel.Controls.Add(Me.Label1)
        Me.MainPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.MainPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainPanel.Margin = New System.Windows.Forms.Padding(5)
        Me.MainPanel.Name = "MainPanel"
        Me.MainPanel.Size = New System.Drawing.Size(645, 103)
        Me.MainPanel.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 20)
        Me.Label1.TabIndex = 267
        Me.Label1.Text = "憑單號碼"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(97, 44)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(141, 29)
        Me.TextBox1.TabIndex = 271
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(252, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(141, 29)
        Me.TextBox2.TabIndex = 272
        '
        'S06R0600
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(645, 503)
        Me.Controls.Add(Me.PreviewControl1)
        Me.Controls.Add(Me.MainPanel)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "S06R0600"
        Me.Text = "S06R0600"
        Me.MainPanel.ResumeLayout(False)
        Me.MainPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPreviewRep As System.Windows.Forms.Button
    Friend WithEvents btnDesignRep As System.Windows.Forms.Button
    Friend WithEvents PreviewControl1 As FastReport.Preview.PreviewControl
    Friend WithEvents MainPanel As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
