﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S_S02N0400
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(S_S02N0400))
        Me.btnDefine = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.S_TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtID = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.報價日期起 = New System.Windows.Forms.DateTimePicker()
        Me.報價日期迄 = New System.Windows.Forms.DateTimePicker()
        Me.S_TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.S_TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDefine
        '
        Me.btnDefine.Image = CType(resources.GetObject("btnDefine.Image"), System.Drawing.Image)
        Me.btnDefine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDefine.Location = New System.Drawing.Point(263, 155)
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
        Me.Label2.Text = "報價日期"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.S_TextBox3)
        Me.Panel1.Controls.Add(Me.S_TextBox2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.報價日期迄)
        Me.Panel1.Controls.Add(Me.報價日期起)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.S_TextBox1)
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Location = New System.Drawing.Point(14, 20)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 125)
        Me.Panel1.TabIndex = 13
        '
        'S_TextBox1
        '
        Me.S_TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.S_TextBox1.Location = New System.Drawing.Point(95, 17)
        Me.S_TextBox1.MaxLength = 10
        Me.S_TextBox1.Name = "S_TextBox1"
        Me.S_TextBox1.Size = New System.Drawing.Size(120, 27)
        Me.S_TextBox1.TabIndex = 1
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(20, 20)
        Me.txtID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(72, 16)
        Me.txtID.TabIndex = 52
        Me.txtID.Text = "報價單號"
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(371, 155)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(100, 30)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "取消(&Z)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        '報價日期起
        '
        Me.報價日期起.Location = New System.Drawing.Point(95, 50)
        Me.報價日期起.Name = "報價日期起"
        Me.報價日期起.Size = New System.Drawing.Size(170, 27)
        Me.報價日期起.TabIndex = 55
        '
        '報價日期迄
        '
        Me.報價日期迄.Location = New System.Drawing.Point(271, 50)
        Me.報價日期迄.Name = "報價日期迄"
        Me.報價日期迄.Size = New System.Drawing.Size(170, 27)
        Me.報價日期迄.TabIndex = 56
        '
        'S_TextBox2
        '
        Me.S_TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.S_TextBox2.Location = New System.Drawing.Point(95, 83)
        Me.S_TextBox2.MaxLength = 10
        Me.S_TextBox2.Name = "S_TextBox2"
        Me.S_TextBox2.Size = New System.Drawing.Size(120, 27)
        Me.S_TextBox2.TabIndex = 57
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 86)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 58
        Me.Label3.Text = "客戶代號"
        '
        'S_TextBox3
        '
        Me.S_TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.S_TextBox3.Location = New System.Drawing.Point(243, 83)
        Me.S_TextBox3.MaxLength = 10
        Me.S_TextBox3.Name = "S_TextBox3"
        Me.S_TextBox3.Size = New System.Drawing.Size(120, 27)
        Me.S_TextBox3.TabIndex = 59
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(217, 88)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "～"
        '
        'S_S02N0400
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(484, 198)
        Me.Controls.Add(Me.btnDefine)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Font = New System.Drawing.Font("新細明體", 12.0!)
        Me.MaximizeBox = False
        Me.Name = "S_S02N0400"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "設定查詢條件"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDefine As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents S_TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents 報價日期迄 As System.Windows.Forms.DateTimePicker
    Friend WithEvents 報價日期起 As System.Windows.Forms.DateTimePicker
    Friend WithEvents S_TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents S_TextBox3 As System.Windows.Forms.TextBox
End Class
