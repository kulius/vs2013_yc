Public NotInheritable Class fmBuy
#Region "@Form及功能操作@"
    Private Sub fmBuy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- 初始化 --
        txtSN.Text = "SN：" '產品序號
        txtCPU.Text = "CPU：" & strCPU() 'CPU序號
        txtMB.Text = "MB：" & "" 'MB序號
        txtMAC.Text = "MAC：" & strMAC() 'MAC序號

        '描述
        txtDescription.Text = "系統編號：" & INI_Read("CONFIG", "SYSTEM", "SID") & vbCrLf
        txtDescription.Text &= "系統名稱：" & INI_Read("CONFIG", "SYSTEM", "NAME") & vbCrLf
        txtDescription.Text &= "系統版本：" & INI_Read("CONFIG", "SYSTEM", "VAR")
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
#End Region
End Class
