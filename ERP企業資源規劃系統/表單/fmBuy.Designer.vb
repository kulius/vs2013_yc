<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmBuy
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

    Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents txtCPU As System.Windows.Forms.Label
    Friend WithEvents txtMAC As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents txtMB As System.Windows.Forms.Label

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmBuy))
        Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.txtSN = New System.Windows.Forms.Label()
        Me.txtCPU = New System.Windows.Forms.Label()
        Me.txtMB = New System.Windows.Forms.Label()
        Me.txtMAC = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel.SuspendLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel
        '
        Me.TableLayoutPanel.ColumnCount = 2
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.0!))
        Me.TableLayoutPanel.Controls.Add(Me.LogoPictureBox, 0, 0)
        Me.TableLayoutPanel.Controls.Add(Me.txtSN, 1, 0)
        Me.TableLayoutPanel.Controls.Add(Me.txtCPU, 1, 1)
        Me.TableLayoutPanel.Controls.Add(Me.txtMB, 1, 2)
        Me.TableLayoutPanel.Controls.Add(Me.txtMAC, 1, 3)
        Me.TableLayoutPanel.Controls.Add(Me.txtDescription, 1, 4)
        Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
        Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel.Location = New System.Drawing.Point(9, 8)
        Me.TableLayoutPanel.Name = "TableLayoutPanel"
        Me.TableLayoutPanel.RowCount = 6
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel.Size = New System.Drawing.Size(396, 239)
        Me.TableLayoutPanel.TabIndex = 0
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogoPictureBox.Image = CType(resources.GetObject("LogoPictureBox.Image"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(3, 3)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.TableLayoutPanel.SetRowSpan(Me.LogoPictureBox, 6)
        Me.LogoPictureBox.Size = New System.Drawing.Size(124, 233)
        Me.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoPictureBox.TabIndex = 0
        Me.LogoPictureBox.TabStop = False
        '
        'txtSN
        '
        Me.txtSN.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtSN.Location = New System.Drawing.Point(136, 0)
        Me.txtSN.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtSN.MaximumSize = New System.Drawing.Size(0, 16)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(257, 16)
        Me.txtSN.TabIndex = 0
        Me.txtSN.Text = "產品序號"
        Me.txtSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCPU
        '
        Me.txtCPU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtCPU.Location = New System.Drawing.Point(136, 23)
        Me.txtCPU.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtCPU.MaximumSize = New System.Drawing.Size(0, 16)
        Me.txtCPU.Name = "txtCPU"
        Me.txtCPU.Size = New System.Drawing.Size(257, 16)
        Me.txtCPU.TabIndex = 0
        Me.txtCPU.Text = "CPU序號"
        Me.txtCPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMB
        '
        Me.txtMB.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMB.Location = New System.Drawing.Point(136, 46)
        Me.txtMB.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtMB.MaximumSize = New System.Drawing.Size(0, 16)
        Me.txtMB.Name = "txtMB"
        Me.txtMB.Size = New System.Drawing.Size(257, 16)
        Me.txtMB.TabIndex = 0
        Me.txtMB.Text = "MB序號"
        Me.txtMB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMAC
        '
        Me.txtMAC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMAC.Location = New System.Drawing.Point(136, 69)
        Me.txtMAC.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.txtMAC.MaximumSize = New System.Drawing.Size(0, 16)
        Me.txtMAC.Name = "txtMAC"
        Me.txtMAC.Size = New System.Drawing.Size(257, 16)
        Me.txtMAC.TabIndex = 0
        Me.txtMAC.Text = "MAC序號"
        Me.txtMAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDescription.Location = New System.Drawing.Point(136, 95)
        Me.txtDescription.Margin = New System.Windows.Forms.Padding(6, 3, 3, 3)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDescription.Size = New System.Drawing.Size(257, 113)
        Me.txtDescription.TabIndex = 0
        Me.txtDescription.TabStop = False
        Me.txtDescription.Text = "描述 :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(在執行階段中，將會以應用程式的組件資訊取代標籤的文字。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "請在專案設計工具的 [應用程式] 窗格中，自訂應用程式的組件資訊。)"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(318, 215)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 21)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "確定(&O)"
        '
        'fmBuy
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(414, 255)
        Me.Controls.Add(Me.TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "fmBuy"
        Me.Padding = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "資訊"
        Me.TableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel.PerformLayout()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtSN As System.Windows.Forms.Label

End Class
