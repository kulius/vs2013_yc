﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class fmLogin
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
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents butLogin As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmLogin))
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.butLogin = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.chkRember = New System.Windows.Forms.CheckBox()
        Me.txtSystem = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.所屬工廠 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtUser
        '
        Me.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUser.Location = New System.Drawing.Point(208, 106)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(200, 22)
        Me.txtUser.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(208, 160)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(200, 22)
        Me.txtPass.TabIndex = 2
        '
        'butLogin
        '
        Me.butLogin.BackgroundImage = CType(resources.GetObject("butLogin.BackgroundImage"), System.Drawing.Image)
        Me.butLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butLogin.Location = New System.Drawing.Point(249, 212)
        Me.butLogin.Name = "butLogin"
        Me.butLogin.Size = New System.Drawing.Size(60, 30)
        Me.butLogin.TabIndex = 4
        Me.butLogin.Text = "確定(&O)"
        '
        'butExit
        '
        Me.butExit.BackgroundImage = CType(resources.GetObject("butExit.BackgroundImage"), System.Drawing.Image)
        Me.butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butExit.Location = New System.Drawing.Point(315, 212)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(60, 30)
        Me.butExit.TabIndex = 5
        Me.butExit.Text = "取消(&C)"
        '
        'chkRember
        '
        Me.chkRember.AutoSize = True
        Me.chkRember.Location = New System.Drawing.Point(208, 188)
        Me.chkRember.Name = "chkRember"
        Me.chkRember.Size = New System.Drawing.Size(96, 16)
        Me.chkRember.TabIndex = 3
        Me.chkRember.Text = "記住我的帳號"
        Me.chkRember.UseVisualStyleBackColor = True
        '
        'txtSystem
        '
        Me.txtSystem.AutoSize = True
        Me.txtSystem.BackColor = System.Drawing.Color.AliceBlue
        Me.txtSystem.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSystem.Location = New System.Drawing.Point(33, 9)
        Me.txtSystem.Name = "txtSystem"
        Me.txtSystem.Size = New System.Drawing.Size(73, 20)
        Me.txtSystem.TabIndex = 7
        Me.txtSystem.Text = "系統名稱"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(8, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "請輸入使用者名稱及密碼"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(8, 227)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(180, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "系統最佳解析度：1024 x 768"
        '
        '所屬工廠
        '
        Me.所屬工廠.FormattingEnabled = True
        Me.所屬工廠.Items.AddRange(New Object() {"楠梓廠", "岡山廠", "總公司", "岡山廠崗山主機"})
        Me.所屬工廠.Location = New System.Drawing.Point(10, 184)
        Me.所屬工廠.Name = "所屬工廠"
        Me.所屬工廠.Size = New System.Drawing.Size(121, 20)
        Me.所屬工廠.TabIndex = 10
        Me.所屬工廠.Text = "總公司"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(10, 162)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox1.TabIndex = 11
        Me.CheckBox1.Text = "記住我的工廠"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'fmLogin
        '
        Me.AcceptButton = Me.butLogin
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.CancelButton = Me.butExit
        Me.ClientSize = New System.Drawing.Size(431, 272)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.所屬工廠)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSystem)
        Me.Controls.Add(Me.chkRember)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butLogin)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmLogin"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "系統名稱"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkRember As System.Windows.Forms.CheckBox
    Friend WithEvents txtSystem As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents 所屬工廠 As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
