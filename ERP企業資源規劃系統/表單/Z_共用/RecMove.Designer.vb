<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RecMove
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.RecIns = New System.Windows.Forms.Button()
        Me.RecUpdCMD = New System.Windows.Forms.Button()
        Me.RecDel = New System.Windows.Forms.Button()
        Me.GotoRec = New System.Windows.Forms.Button()
        Me.Recpos = New System.Windows.Forms.TextBox()
        Me.LastRec = New System.Windows.Forms.Button()
        Me.NextRec = New System.Windows.Forms.Button()
        Me.PreRec = New System.Windows.Forms.Button()
        Me.FirstRec = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'RecIns
        '
        Me.RecIns.Location = New System.Drawing.Point(210, 3)
        Me.RecIns.Name = "RecIns"
        Me.RecIns.Size = New System.Drawing.Size(48, 23)
        Me.RecIns.TabIndex = 32
        Me.RecIns.Text = "新增"
        '
        'RecUpdCMD
        '
        Me.RecUpdCMD.Location = New System.Drawing.Point(250, 3)
        Me.RecUpdCMD.Name = "RecUpdCMD"
        Me.RecUpdCMD.Size = New System.Drawing.Size(48, 23)
        Me.RecUpdCMD.TabIndex = 31
        Me.RecUpdCMD.Text = "修改"
        '
        'RecDel
        '
        Me.RecDel.Location = New System.Drawing.Point(298, 3)
        Me.RecDel.Name = "RecDel"
        Me.RecDel.Size = New System.Drawing.Size(40, 23)
        Me.RecDel.TabIndex = 30
        Me.RecDel.Text = "刪除"
        '
        'GotoRec
        '
        Me.GotoRec.Location = New System.Drawing.Point(122, 3)
        Me.GotoRec.Name = "GotoRec"
        Me.GotoRec.Size = New System.Drawing.Size(24, 23)
        Me.GotoRec.TabIndex = 29
        Me.GotoRec.Text = "G"
        Me.GotoRec.Visible = False
        '
        'Recpos
        '
        Me.Recpos.Location = New System.Drawing.Point(66, 3)
        Me.Recpos.Name = "Recpos"
        Me.Recpos.Size = New System.Drawing.Size(72, 22)
        Me.Recpos.TabIndex = 28
        Me.Recpos.Text = "TextBox1"
        '
        'LastRec
        '
        Me.LastRec.Location = New System.Drawing.Point(178, 3)
        Me.LastRec.Name = "LastRec"
        Me.LastRec.Size = New System.Drawing.Size(32, 23)
        Me.LastRec.TabIndex = 27
        Me.LastRec.Text = ">>"
        '
        'NextRec
        '
        Me.NextRec.Location = New System.Drawing.Point(146, 3)
        Me.NextRec.Name = "NextRec"
        Me.NextRec.Size = New System.Drawing.Size(32, 23)
        Me.NextRec.TabIndex = 26
        Me.NextRec.Text = ">"
        '
        'PreRec
        '
        Me.PreRec.Location = New System.Drawing.Point(34, 3)
        Me.PreRec.Name = "PreRec"
        Me.PreRec.Size = New System.Drawing.Size(32, 23)
        Me.PreRec.TabIndex = 25
        Me.PreRec.Text = "<"
        '
        'FirstRec
        '
        Me.FirstRec.Location = New System.Drawing.Point(2, 3)
        Me.FirstRec.Name = "FirstRec"
        Me.FirstRec.Size = New System.Drawing.Size(32, 23)
        Me.FirstRec.TabIndex = 24
        Me.FirstRec.Text = "<<"
        '
        'RecMove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RecIns)
        Me.Controls.Add(Me.RecUpdCMD)
        Me.Controls.Add(Me.RecDel)
        Me.Controls.Add(Me.GotoRec)
        Me.Controls.Add(Me.Recpos)
        Me.Controls.Add(Me.LastRec)
        Me.Controls.Add(Me.NextRec)
        Me.Controls.Add(Me.PreRec)
        Me.Controls.Add(Me.FirstRec)
        Me.Name = "RecMove"
        Me.Size = New System.Drawing.Size(344, 28)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RecIns As System.Windows.Forms.Button
    Friend WithEvents RecUpdCMD As System.Windows.Forms.Button
    Friend WithEvents RecDel As System.Windows.Forms.Button
    Friend WithEvents GotoRec As System.Windows.Forms.Button
    Friend WithEvents Recpos As System.Windows.Forms.TextBox
    Friend WithEvents LastRec As System.Windows.Forms.Button
    Friend WithEvents NextRec As System.Windows.Forms.Button
    Friend WithEvents PreRec As System.Windows.Forms.Button
    Friend WithEvents FirstRec As System.Windows.Forms.Button

End Class
