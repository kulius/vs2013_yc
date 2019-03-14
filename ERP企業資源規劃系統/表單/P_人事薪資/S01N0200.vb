Public Class S01N0200
#Region "@資料庫共用變數@"
    Dim strCSQL As String '查詢數量
    Dim strSSQL As String '查詢資料

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
    Private Sub S01N0200_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S01N0200_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S01N0200 As New S_S01N0200

        '開啟視窗
        S_S01N0200.MdiParent = fmMain
        S_S01N0200.Show()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT * FROM 司機主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY 車牌號碼, 司機代號 ASC"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_GG(分類, "A,B", "公司員工,外雇")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"司機代號", "車牌號碼", "姓名", "電話", "手機"}
        Dim arrColWidth() As String = {"100", "100", "160", "120", "120"}

        DataGridView.ColumnCount = arrColName.Length
        DataGridView.RowCount = 1

        For J As Integer = 0 To arrColName.Length - 1 Step 1
            With DataGridView
                .Columns(J).Name = arrColName(J) '欄位名稱
                .Columns(J).Width = arrColWidth(J) '欄位寬度
            End With
        Next
    End Sub
    '欄位顏色
    Private Sub DataGridView_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView.Paint
        Dim d As DataGridView

        d = CType(sender, DataGridView)
        For Me.I = 0 To d.Rows.Count - 1
            If I Mod 2 = 0 Then
                d.Rows(I).DefaultCellStyle.BackColor = Color.White
            Else
                d.Rows(I).DefaultCellStyle.BackColor = Color.Lavender
            End If
        Next
    End Sub
    '選擇欄位值
    Private Sub DataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellClick
        intCol = e.ColumnIndex
        intRow = e.RowIndex

        FlagMoveSeat(0) '讀取值
    End Sub
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        '查詢語法
        strSSQL = "SELECT * FROM 司機主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 車牌號碼, 司機代號 ASC"

        '顯示欄位
        arrRowName = {"司機代號", "車牌號碼", "姓名", "電話", "手機"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {}

        Dim objTextBoxM() As TextBox = {司機代號}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {車牌號碼, 姓名, _
                                        員工代號, 身份證號, 籍貫, 電話, 手機, 戶籍地址, 通訊地址, _
                                        調質單價, 滲碳單價, 備註}
        Dim objComboBox1() As ComboBox = {分類}
        Dim objRadioButton1() As RadioButton = {性別1, 性別2}
        Dim objDateTimePicker1() As DateTimePicker = {出生日期}


        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

                chk通訊地址.Enabled = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                性別1.Checked = True
                chk通訊地址.Enabled = True
                司機代號.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk通訊地址.Enabled = True

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk通訊地址.Enabled = True
                司機代號.Focus()
        End Select
    End Sub
    '移動DataGridView指標
    Public Overrides Sub FlagMoveSeat(ByVal strStatus As Integer)
        '防呆機制
        If strStatus = 0 Then If intCol < 0 Or intRow < 0 Then Exit Sub '只有[隨機]需判斷，防止索引值超出陣列


        '依按鍵狀態停止格數
        Select Case strStatus
            Case "1"
                intCol = 0 : intRow = 0
            Case "2"
                intCol = 0 : intRow = IIf(intRow - 1 < 0, 0, intRow - 1)
            Case "3"
                intCol = 0 : intRow = IIf(intRow + 1 > txtCount.Text - 1, txtCount.Text - 1, intRow + 1)
            Case "4"
                intCol = 0 : intRow = txtCount.Text - 1
        End Select


        '資料查詢*****
        If DataGridView.Rows.Count > 0 Then
            Try
                '關鍵值
                Dim strKey As String = DataGridView.Rows(intRow).Cells(0).Value.ToString

                '停在選定之儲存格
                ShowData(strKey)
                txtSeat.Text = intRow + 1 '目前位置
                DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
            Catch ex As Exception

            End Try
        End If
    End Sub

    '新增
    Public Overrides Function InsertData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {司機代號, 姓名}
        Dim strArray_Input() As String = {"司機代號", "姓名"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {調質單價, 滲碳單價}
        Dim strArray_Numeric() As String = {"調質單價", "滲碳單價"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        '代號是否有重複
        If dbDataCheck(DNS, "司機主檔", "司機代號 = '" & 司機代號.Text & "'") = True Then MsgBox("系統訊息：【司機代號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        strIRow = "司機代號,分類,員工代號,車牌號碼,"
        strIRow &= "姓名,性別,身份證號,出生日期,籍貫,"
        strIRow &= "電話,手機,戶籍地址,通訊地址,"
        strIRow &= "調質單價,滲碳單價,備註,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 司機代號.Text & "','" & 分類.SelectedValue & "','" & 員工代號.Text & "','" & 車牌號碼.Text & "',"
        strIValue &= "'" & 姓名.Text & "','" & IIf(性別1.Checked = True, "M", "F") & "','" & 身份證號.Text & "','" & IIf(出生日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(出生日期.Value.ToShortDateString)) & "','" & 籍貫.Text & "',"
        strIValue &= "'" & 電話.Text & "','" & 手機.Text & "','" & 戶籍地址.Text & "','" & 通訊地址.Text & "',"
        strIValue &= "'" & 調質單價.Text & "','" & 滲碳單價.Text & "','" & 備註.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "司機主檔", strIRow, strIValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入         
        Dim objArray_Input() As Object = {司機代號, 姓名}
        Dim strArray_Input() As String = {"司機代號", "姓名"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {調質單價, 滲碳單價}
        Dim strArray_Numeric() As String = {"調質單價", "滲碳單價"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****        
        strUValue = "分類 = '" & 分類.SelectedValue & "',"
        strUValue &= "員工代號 = '" & 員工代號.Text & "',"
        strUValue &= "車牌號碼 = '" & 車牌號碼.Text & "',"
        strUValue &= "姓名 = '" & 姓名.Text & "',"
        strUValue &= "性別 = '" & IIf(性別1.Checked = True, "M", "F") & "',"
        strUValue &= "身份證號 = '" & 身份證號.Text & "',"
        strUValue &= "出生日期 = '" & IIf(出生日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(出生日期.Value.ToShortDateString)) & "',"
        strUValue &= "籍貫 = '" & 籍貫.Text & "',"
        strUValue &= "電話 = '" & 電話.Text & "',"
        strUValue &= "手機 = '" & 手機.Text & "',"
        strUValue &= "戶籍地址 = '" & 戶籍地址.Text & "',"
        strUValue &= "通訊地址 = '" & 通訊地址.Text & "',"
        strUValue &= "調質單價 = '" & 調質單價.Text & "',"
        strUValue &= "滲碳單價 = '" & 滲碳單價.Text & "',"
        strUValue &= "備註 = '" & 備註.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "司機代號 = '" & 司機代號.Text & "'"

        blnCheck = dbEdit(DNS, "司機主檔", strUValue, strWValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "司機主檔", "司機代號 = '" & 司機代號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Driver(strKey1) '司機主檔        
    End Sub
    '司機主檔
    Sub Driver(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 司機主檔"
        strSQL99 &= " WHERE 司機代號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            司機代號.Text = objDR99("司機代號").ToString
            車牌號碼.Text = objDR99("車牌號碼").ToString
            姓名.Text = objDR99("姓名").ToString

            員工代號.Text = objDR99("員工代號").ToString
            身份證號.Text = objDR99("身份證號").ToString
            籍貫.Text = objDR99("籍貫").ToString
            電話.Text = objDR99("電話").ToString
            手機.Text = objDR99("手機").ToString
            戶籍地址.Text = objDR99("戶籍地址").ToString
            通訊地址.Text = objDR99("通訊地址").ToString
            調質單價.Text = objDR99("調質單價").ToString
            滲碳單價.Text = objDR99("滲碳單價").ToString
            備註.Text = objDR99("備註").ToString


            '非文字欄位*****
            出生日期.Value = IIf(IsDate(objDR99("出生日期").ToString) = False, Now, objDR99("出生日期").ToString)

            分類.SelectedValue = objDR99("分類").ToString

            性別1.Checked = IIf(objDR99("性別").ToString = "M", True, False)
            性別2.Checked = IIf(objDR99("性別").ToString = "F", True, False)

            chk通訊地址.Checked = IIf(objDR99("戶籍地址").ToString = objDR99("通訊地址").ToString, True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
#End Region

#Region "物件異動選擇項"
    '複製戶籍地址
    Private Sub chk通訊地址_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk通訊地址.CheckedChanged
        Select Case chk通訊地址.Checked
            Case True : 通訊地址.Text = 戶籍地址.Text
            Case False : 通訊地址.Text = ""
        End Select
    End Sub
#End Region
End Class
