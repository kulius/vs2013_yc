Imports System.Data
Imports System.Data.SqlClient

Public Class S99N9999
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值

#Region "@資料庫共用變數@"
    '副程式專用
    Dim objCon99 As SqlConnection
    Dim objCmd99 As SqlCommand
    Dim objDR99 As SqlDataReader
    Dim strSQL99 As String
#End Region
#Region "@固定公用變數@"
    Dim I As Integer '累進變數
    Dim strMessage As String = "" '訊息字串
    Dim strIRow, strIValue, strUValue, strWValue As String '資料處理參數(新增欄位；新增資料；異動資料；條件)      
#End Region

#Region "@Form及功能操作@"
    Private Sub S99N9999_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****
        txtOldPass.Text = "" : txtNewPass.Text = "" : txtComPass.Text = ""
        txtOldPass.Focus()
    End Sub

    '儲存
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        '防呆*****
        Dim objArrary() As Object = {txtOldPass, txtNewPass, txtComPass}
        Dim strArrary() As String = {"原密碼", "新密碼", "確認新密碼"}
        If blnInputCheck(objArrary, strArrary) = False Then Exit Sub


        '--開啟查詢--
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT 密碼 FROM 員工主檔"
        strSQL99 &= " WHERE 員工代號 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            If objDR99("密碼").ToString = txtOldPass.Text Then
                If txtNewPass.Text = txtComPass.Text Then
                    '開啟儲存
                    strUValue = "密碼 = '" & txtComPass.Text & "' "
                    strWValue &= "員工代號 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "'"

                    dbEdit(DNS, "員工主檔", strUValue, strWValue)


                    '異動後初始化
                    MsgBox("※密碼已變更成功，下次登入請輸入新密碼！", MsgBoxStyle.Information, "成功") : Me.Close()
                Else
                    MsgBox("※兩次輸入的密碼不相同，請重新輸入！", MsgBoxStyle.Exclamation, "注意")
                End If
            Else
                MsgBox("※輸入的舊密碼不相符，請重新輸入！", MsgBoxStyle.Exclamation, "注意")
            End If
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub

    '取消
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
#End Region
End Class