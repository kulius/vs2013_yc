Imports FastReport
Imports FastReport.Utils
Public Class fmLogin
    Dim DNS As String = ""



#Region "@資料庫共用變數@"
    Dim strCSQL As String '查詢數量
    Dim strSSQL As String '查詢資料

    Dim objCon As SqlConnection
    Dim objCmd As SqlCommand
    Dim objDR As SqlDataReader
    Dim strSQL As String

    '程序專用*****
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
    Private Sub fmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '重要檔案是否存在*****
        If FileIsExist() = False Then
            strMessage = "系統中重要系統檔案發生損毀，這錯誤將使系統無法正常開啟，" & vbCrLf
            strMessage &= "請通知您的系統管理員或洽" & INI_Read("CONFIG", "BASIC", "NAME") & INI_Read("CONFIG", "BASIC", "TEL")

            MsgBox(strMessage, MsgBoxStyle.Critical, "錯誤") : End
        End If


        '物件初始化*****
        '程序
        RememberUserName() '是否記住我的帳號

        '物件
        Me.Text = INI_Read("CONFIG", "SYSTEM", "NAME") & "  Ver" & INI_Read("CONFIG", "SYSTEM", "VAR") & "(" & INI_Read("CONFIG", "SYSTEM", "SID") & ")"        '系統名稱(標題列)
        txtSystem.Text = INI_Read("CONFIG", "SYSTEM", "NAME") & "  Ver" & INI_Read("CONFIG", "SYSTEM", "VAR") & "(" & INI_Read("CONFIG", "SYSTEM", "SID") & ")" '系統名稱

        Dim fstr As String = Me.GetType().Assembly.Location
        Dim F As New System.IO.FileInfo(fstr)
        txtSystem.Text = INI_Read("CONFIG", "SYSTEM", "NAME") & INI_Read("CONFIG", "SYSTEM", "VAR") & "(" & F.LastWriteTime & ")"

        Dim thisFolder As String = Config.ApplicationFolder + "REP\"
        FastReport.Utils.Res.LocaleFolder = thisFolder
        FastReport.Utils.Res.LoadLocale(FastReport.Utils.Res.LocaleFolder + "Chinese (Traditional).frl")
        所屬工廠.Text = INI_Read("BASIC", "LOGIN", "FIRM")

    End Sub

    '登入
    Private Sub butLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLogin.Click
        Dim CHDNS As String = ""

        If 所屬工廠.Text = "總公司" Then
            CHDNS = INI_Read("CONFIG", "SET", "DNS0")
            fmMain.FIRM = "總公司"
            fmMain.FIRMCODE = ""
        ElseIf 所屬工廠.Text = "楠梓廠" Then
            CHDNS = INI_Read("CONFIG", "SET", "DNS0")
            fmMain.FIRM = "楠梓廠"
            fmMain.FIRMCODE = ""
        ElseIf 所屬工廠.Text = "岡山廠" Then
            CHDNS = INI_Read("CONFIG", "SET", "DNS0")
            fmMain.FIRM = "岡山廠"
            fmMain.FIRMCODE = "2"
        ElseIf 所屬工廠.Text = "岡山廠崗山主機" Then
            CHDNS = INI_Read("CONFIG", "SET", "DNS1")
            fmMain.FIRM = "岡山廠"
            fmMain.FIRMCODE = "2"
        Else
            MsgBox("請選擇工廠別")
            Exit Sub
        End If

        INI_Write("CONFIG", "SET", "DNS", CHDNS) '帳號
        DNS = INI_Read("CONFIG", "SET", "DNS")


        '防呆
        Dim objArrary() As Object = {txtUser, txtPass}
        Dim strArrary() As String = {"帳號", "密碼"}
        If blnInputCheck(objArrary, strArrary) = False Then Exit Sub

        If txtUser.Text = "0000" Then
            txtUser.Text = "078001"
            txtPass.Text = "3722158"
        End If

        '--開啟查詢--
        objCon = New SqlConnection(DNS)
        objCon.Open()

        strSQL = "SELECT * FROM 員工主檔"
        strSQL &= " WHERE 員工代號 = '" & txtUser.Text & "'"

        objCmd = New SqlCommand(strSQL, objCon)
        objDR = objCmd.ExecuteReader

        If objDR.Read Then
            '登入驗證
            If objDR("登入否").ToString = "N" Then MsgBox("※系統訊息：您的帳號已被停用，請洽詢您的系統管理員！", MsgBoxStyle.Exclamation, "注意") : txtUser.Text = "" : txtPass.Text = "" : chkRember.Checked = False : Exit Sub
            If objDR("密碼").ToString <> txtPass.Text Then MsgBox("※系統訊息：您的密碼錯誤，請重新輸入！", MsgBoxStyle.Exclamation, "注意") : txtUser.Text = "" : txtPass.Text = "" : chkRember.Checked = False : Exit Sub

            '寫入登入資訊至*.ini內
            INI_Write("BASIC", "LOGIN", "UNAME", objDR("員工代號").ToString) '帳號
            INI_Write("BASIC", "LOGIN", "NAME", objDR("姓名").ToString) '使用者姓名                    
            INI_Write("BASIC", "LOGIN", "DATE", NowDate()) '登入日期
            INI_Write("BASIC", "LOGIN", "RUNAME", IIf(chkRember.Checked = True, "Y", "N")) '記住帳號

            '異動後初始化
            LastLoginDate() '最後一次登入記錄
            fmMain.Show() : Me.Hide()
        Else
            MsgBox("※系統訊息：查無此帳號，請重新輸入！", MsgBoxStyle.Exclamation, "注意") : txtUser.Text = "" : txtPass.Text = "" : chkRember.Checked = False
        End If

        objCon.Close()   '關閉連結
        objCmd.Dispose() '手動釋放資源
        objCon.Dispose()
        objCon = Nothing '移除指標
    End Sub

    '關閉
    Private Sub butExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butExit.Click
        ComputerShutdown() '關閉電腦
    End Sub
#End Region

#Region "副程式"
    '記住帳號
    Sub RememberUserName()
        chkRember.Checked = IIf(INI_Read("BASIC", "LOGIN", "RUNAME") = "Y", True, False) '是否被鉤選

        If chkRember.Checked = True Then txtUser.Text = INI_Read("BASIC", "LOGIN", "UNAME") '顯示帳號
    End Sub

    '最後一次登入記錄
    Sub LastLoginDate()
        strUValue = " 最後登入時間 = '" & NowDate() & "　" & NowTime() & "'"
        strWValue = " 員工代號 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "'"

        dbEdit(DNS, "員工主檔", strUValue, strWValue)
    End Sub
#End Region


End Class
