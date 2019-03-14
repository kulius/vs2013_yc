Public Class S06N0120
    Public DNS0 As String = INI_Read("CONFIG", "SET", "DNS0") 'DNS設定
    Public DNS1 As String = INI_Read("CONFIG", "SET", "DNS1") 'DNS設定值
    Public DNS2 As String = INI_Read("CONFIG", "SET", "DNS2") 'DNS設定值
    Public FIRM As String = fmMain.FIRM 'DNS設定值
    Private Sub BtnTranData_Click(sender As Object, e As EventArgs) Handles BtnTranData.Click

    End Sub

    Private Sub S06N0120_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If FIRM <> "總公司" Then
            MsgBox("必需在總公司，才能運作此程式")
            Me.Close()
        End If
    End Sub
End Class