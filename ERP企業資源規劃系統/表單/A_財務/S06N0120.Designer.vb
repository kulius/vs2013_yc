<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class S06N0120
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
        Me.BtnTranData = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnTranData
        '
        Me.BtnTranData.Location = New System.Drawing.Point(197, 71)
        Me.BtnTranData.Name = "BtnTranData"
        Me.BtnTranData.Size = New System.Drawing.Size(199, 103)
        Me.BtnTranData.TabIndex = 0
        Me.BtnTranData.Text = "轉入楠梓及崗山廠資料"
        Me.BtnTranData.UseVisualStyleBackColor = True
        '
        'S06N0120
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 292)
        Me.Controls.Add(Me.BtnTranData)
        Me.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.Name = "S06N0120"
        Me.Text = "S06N0120"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnTranData As System.Windows.Forms.Button
End Class
