Imports NPOI
Imports NPOI.HSSF.UserModel
Imports NPOI.SS.UserModel
Imports System.IO
Public Class S01N0100
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
    Private Sub S01N0100_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {butPrint}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S01N0100_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S01N0100 As New S_S01N0100

        '開啟視窗
        S_S01N0100.MdiParent = fmMain
        S_S01N0100.Show()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        strSSQL = "SELECT *,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0001' AND m.廠別代碼 = t1.一層代碼) AS 廠別,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0002' AND m.部門代碼 = t1.一層代碼) AS 部門,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0003' AND m.僱用性質代碼 = t1.一層代碼) AS 僱用性質"
        strSSQL &= " FROM 員工主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY 員工代號 ASC"
        SqlToExcel(DNS, strSSQL)

        'Dim wb As IWorkbook = New HSSFWorkbook
        'Dim ws As ISheet

        'strSSQL = "SELECT *,"
        'strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0001' AND m.廠別代碼 = t1.一層代碼) AS 廠別,"
        'strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0002' AND m.部門代碼 = t1.一層代碼) AS 部門,"
        'strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0003' AND m.僱用性質代碼 = t1.一層代碼) AS 僱用性質"
        'strSSQL &= " FROM 員工主檔 AS m"
        'strSSQL &= " WHERE 1=1"
        'strSSQL &= " ORDER BY 員工代號 ASC"

        ''開啟查詢
        'objCon99 = New SqlConnection(DNS)
        'objCon99.Open()

        'objCmd99 = New SqlCommand(strSSQL, objCon99)
        'objDR99 = objCmd99.ExecuteReader
        'Dim dt As DataTable = New DataTable()
        'dt.Load(objDR99, LoadOption.OverwriteChanges)

        'If dt.TableName <> String.Empty Then
        '    ws = wb.CreateSheet(dt.TableName)
        'Else
        '    ws = wb.CreateSheet("Sheet1")
        'End If

        'ws.CreateRow(0) '第一行為欄位名稱
        'Dim i As Integer
        'For i = 0 To dt.Columns.Count - 1 Step i + 1
        '    ws.GetRow(0).CreateCell(i).SetCellValue(dt.Columns(i).ColumnName)
        'Next

        'For i = 0 To dt.Rows.Count - 1
        '    ws.CreateRow(i + 1)
        '    Dim j As Integer = 0
        '    For j = 0 To dt.Columns.Count - 1
        '        ws.GetRow(i + 1).CreateCell(j).SetCellValue(dt.Rows(i)(j).ToString())
        '    Next
        'Next

        'Dim file As FileStream = New FileStream("npoi.xls", FileMode.Create) '產生檔案
        'wb.Write(file)
        'file.Close()

        'Dim process As New Process
        'process.Start(Application.StartupPath + "\npoi.xls")

        'objDR99.Close()    '關閉連結
        'objCon99.Close()
        'objCmd99.Dispose() '手動釋放資源
        'objCon99.Dispose()
        'objCon99 = Nothing '移除指標
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(廠別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0001'", "一層代碼 ASC")
        ComboBox_DB(僱用性質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0003'", "一層代碼 ASC")
        ComboBox_DB(部門代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0002'", "一層代碼 ASC")

        ComboBox_DB(職稱代碼1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0004'", "一層代碼 ASC")
        ComboBox_DB(職稱代碼2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0004'", "一層代碼 ASC")
        ComboBox_DB(職稱代碼3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S01N0004'", "一層代碼 ASC")

        ComboBox_GG(婚姻, ",未婚,已婚,其他", ",未婚,已婚,其他")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"員工代號", "廠別", "部門", "僱用性質", "姓名", "最後登入時間", "允許登入"}
        Dim arrColWidth() As String = {"100", "100", "100", "120", "160", "180", "100"}

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
    Private Sub DataGridView_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridView.Paint, Tab3_DataGridViewR1.Paint
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
        strSSQL = "SELECT *,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0001' AND m.廠別代碼 = t1.一層代碼) AS 廠別,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0002' AND m.部門代碼 = t1.一層代碼) AS 部門,"
        strSSQL &= " (SELECT 一層名稱 FROM s_一層代碼檔 AS t1 WHERE t1.類別 = 'S01N0003' AND m.僱用性質代碼 = t1.一層代碼) AS 僱用性質"
        strSSQL &= " FROM 員工主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 員工代號 ASC"

        '顯示欄位
        arrRowName = {"員工代號", "廠別", "部門", "僱用性質", "姓名", "最後登入時間", "登入否"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****    
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {Tab3_DataGridViewR1}

        Dim objTextBoxM() As TextBox = {員工代號}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {姓名, 身份證號, _
                                        籍貫, 子女數, 電話, 手機, E_Mail, 通訊地址, 戶籍地址, _
                                        緊急聯絡人, 關係, 聯絡電話, 聯絡手機, _
                                        備註}
        Dim objComboBox1() As ComboBox = {廠別代碼, 僱用性質代碼, 部門代碼, _
                                          職稱代碼1, 職稱代碼2, 職稱代碼3, 婚姻}
        Dim objRadioButton1() As RadioButton = {性別1, 性別2, _
                                                登入否1, 登入否2}
        Dim objDateTimePicker1() As DateTimePicker = {出生日期, _
                                                      到職日期, 離職日期}

        Dim objTextBox2() As TextBox = {基本薪資, 扶養人數, 代扣所得稅年月, 代扣所得稅, _
                                        勞保投保薪資, 勞保保費, 健保投保薪資, 健保保費, _
                                        立帳郵局, 郵局局號, 郵局帳號, 戶名, 戶名身份證號, _
                                        年資, 特休日數, 已休日數, 剩餘特休}
        Dim objComboBox2() As ComboBox = {}
        Dim objRadioButton2() As RadioButton = {}
        Dim objDateTimePicker2() As DateTimePicker = {到職日期, 離職日期}


        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)
        Basic_Control(objTextBox2, objComboBox2, objRadioButton2, objDateTimePicker2, butStatus)


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

                chk戶籍地址.Enabled = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                性別1.Checked = True
                登入否1.Checked = True
                最後登入時間.Text = ""
                chk戶籍地址.Enabled = True
                員工代號.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk戶籍地址.Enabled = True

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                最後登入時間.Text = ""
                chk戶籍地址.Enabled = True
                員工代號.Focus()
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

    '在使用者按下[新增]之後
    Public Overrides Sub AfterAddNew()
        Dim arrRowName() As String

        '薪資結構
        strSSQL = "SELECT * FROM s_一層代碼檔"
        strSSQL &= " WHERE 類別 = 'S01N0005'"
        strSSQL &= " ORDER BY 一層代碼 ASC"

        arrRowName = {"一層代碼", "一層名稱"}

        DataGridViewR_DB(Tab3_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub
    '在使用者按下[修改]之後
    Public Overrides Sub AfterEdit()
        Dim arrRowName() As String

        '薪資結構
        strSSQL = "SELECT m.一層代碼, m.一層名稱, ISNULL(t1.金額, N'0') AS 金額 FROM s_一層代碼檔 AS m"
        strSSQL &= " LEFT JOIN 員工薪資結構檔 AS t1 ON m.一層代碼 = t1.薪資項目代碼"
        strSSQL &= " WHERE m.類別 = 'S01N0005'"
        strSSQL &= " ORDER BY m.一層代碼 ASC"

        arrRowName = {"一層代碼", "一層名稱", "金額"}

        DataGridViewR_DB(Tab3_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub

    '新增
    Public Overrides Function InsertData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {員工代號, 姓名}
        Dim strArray_Input() As String = {"員工代號", "姓名"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input) : If blnCheck = False Then Return False : Exit Function

        '必數字
        Dim objArray_Numeric() As Object = {子女數, _
                                            基本薪資, 扶養人數, 代扣所得稅, 勞保投保薪資, 勞保保費, 健保投保薪資, 健保保費, _
                                            年資, 特休日數, 已休日數, 剩餘特休}
        Dim strArray_Numeric() As String = {"子女數", _
                                            "基本薪資", "扶養人數", "扣所得稅", "勞保投保薪資", "勞保保費", "健保投保薪資", "健保保費", _
                                            "年資", "特休時數", "已休時數", "剩餘特休"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric) : If blnCheck = False Then Return False : Exit Function

        '代號是否有重複
        If dbDataCheck(DNS, "員工主檔", "員工代號 = '" & 員工代號.Text & "'") = True Then MsgBox("系統訊息：【員工代號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False
        '防呆結束*****


        '開啟儲存*****
        '員工主檔
        strIRow = "員工代號,密碼,廠別代碼,部門代碼,僱用性質代碼,職稱代碼1,職稱代碼2,職稱代碼3,"
        strIRow &= "姓名,性別,身份證號,出生日期,籍貫,婚姻,子女數,"
        strIRow &= "電話,手機,E_Mail,通訊地址,戶籍地址,緊急聯絡人,關係,聯絡電話,聯絡手機,"
        strIRow &= "到職日期,離職日期,備註,登入否,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 員工代號.Text & "','" & 員工代號.Text & "','" & 廠別代碼.SelectedValue & "','" & 部門代碼.SelectedValue & "','" & 僱用性質代碼.SelectedValue & "','" & 職稱代碼1.SelectedValue & "','" & 職稱代碼2.SelectedValue & "','" & 職稱代碼3.SelectedValue & "',"
        strIValue &= "'" & 姓名.Text & "','" & IIf(性別1.Checked = True, "M", "F") & "','" & 身份證號.Text & "','" & IIf(出生日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(出生日期.Value.ToShortDateString)) & "','" & 籍貫.Text & "','" & 婚姻.SelectedValue & "','" & 子女數.Text & "',"
        strIValue &= "'" & 電話.Text & "','" & 手機.Text & "','" & E_Mail.Text & "','" & 通訊地址.Text & "','" & 戶籍地址.Text & "','" & 緊急聯絡人.Text & "','" & 關係.Text & "','" & 聯絡電話.Text & "','" & 聯絡手機.Text & "',"
        strIValue &= "'" & IIf(到職日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(到職日期.Value.ToShortDateString)) & "','" & IIf(離職日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(離職日期.Value.ToShortDateString)) & "','" & 備註.Text & "','" & IIf(登入否1.Checked = True, "Y", "N") & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "員工主檔", strIRow, strIValue)


        '員工薪資主檔
        strIRow = "員工代號,基本薪資,扶養人數,代扣所得稅年月,代扣所得稅,"
        strIRow &= "勞保投保日期,勞保投保薪資,勞保保費,健保投保日期,健保投保薪資,健保保費,"
        strIRow &= "立帳郵局,郵局局號,郵局帳號,戶名,戶名身份證號,"
        strIRow &= "年資,特休日數,已休日數,剩餘特休"

        strIValue = "'" & 員工代號.Text & "','" & 基本薪資.Text & "','" & 扶養人數.Text & "','" & 代扣所得稅年月.Text & "','" & 代扣所得稅.Text & "',"
        strIValue &= "'" & IIf(勞保投保日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(勞保投保日期.Value.ToShortDateString)) & "','" & 勞保投保薪資.Text & "','" & 勞保保費.Text & "','" & IIf(健保投保日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(健保投保日期.Value.ToShortDateString)) & "','" & 健保投保薪資.Text & "','" & 健保保費.Text & "',"
        strIValue &= "'" & 立帳郵局.Text & "','" & 郵局局號.Text & "','" & 郵局帳號.Text & "','" & 戶名.Text & "','" & 戶名身份證號.Text & "',"
        strIValue &= "'" & 年資.Text & "','" & 特休日數.Text & "','" & 已休日數.Text & "','" & 剩餘特休.Text & "'"

        dbInsert(DNS, "員工薪資主檔", strIRow, strIValue)


        ''員工薪資結構檔
        'For I As Integer = 0 To Tab3_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab3_DataGridViewR1.Rows(I).Cells("薪資項目代碼").Value,
        '                                   Tab3_DataGridViewR1.Rows(I).Cells("金額").Value}

        '    strIRow = "員工代號,薪資項目代碼,金額,排序"
        '    strIValue = "'" & 員工代號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & I + 1 & "'"
        '    dbInsert(DNS, "員工薪資結構檔", strIRow, strIValue)
        'Next


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
        Dim objArray_Input() As Object = {員工代號, 姓名}
        Dim strArray_Input() As String = {"員工代號", "姓名"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input) : If blnCheck = False Then Return False : Exit Function

        '必數字
        Dim objArray_Numeric() As Object = {子女數, _
                                            基本薪資, 扶養人數, 代扣所得稅, 勞保投保薪資, 勞保保費, 健保投保薪資, 健保保費, _
                                            年資, 特休日數, 已休日數, 剩餘特休}
        Dim strArray_Numeric() As String = {"子女數", _
                                            "基本薪資", "扶養人數", "扣所得稅", "勞保投保薪資", "勞保保費", "健保投保薪資", "健保保費", _
                                            "年資", "特休時數", "已休時數", "剩餘特休"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric) : If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '員工主檔
        strUValue = "廠別代碼 = '" & 廠別代碼.SelectedValue & "',"
        strUValue &= "部門代碼 = '" & 部門代碼.SelectedValue & "',"
        strUValue &= "僱用性質代碼 = '" & 僱用性質代碼.SelectedValue & "',"
        strUValue &= "職稱代碼1 = '" & 職稱代碼1.SelectedValue & "',"
        strUValue &= "職稱代碼2 = '" & 職稱代碼2.SelectedValue & "',"
        strUValue &= "職稱代碼3 = '" & 職稱代碼3.SelectedValue & "',"
        strUValue &= "姓名 = '" & 姓名.Text & "',"
        strUValue &= "性別 = '" & IIf(性別1.Checked = True, "M", "F") & "',"
        strUValue &= "身份證號 = '" & 身份證號.Text & "',"
        strUValue &= "出生日期 = '" & IIf(出生日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(出生日期.Value.ToShortDateString)) & "',"
        strUValue &= "籍貫 = '" & 籍貫.Text & "',"
        strUValue &= "婚姻 = '" & 婚姻.SelectedValue & "',"
        strUValue &= "子女數 = '" & 子女數.Text & "',"
        strUValue &= "電話 = '" & 電話.Text & "',"
        strUValue &= "手機 = '" & 手機.Text & "',"
        strUValue &= "E_Mail = '" & E_Mail.Text & "',"
        strUValue &= "通訊地址 = '" & 通訊地址.Text & "',"
        strUValue &= "戶籍地址 = '" & 戶籍地址.Text & "',"
        strUValue &= "緊急聯絡人 = '" & 緊急聯絡人.Text & "',"
        strUValue &= "關係 = '" & 關係.Text & "',"
        strUValue &= "聯絡電話 = '" & 聯絡電話.Text & "',"
        strUValue &= "聯絡手機 = '" & 聯絡手機.Text & "',"
        strUValue &= "到職日期 = '" & IIf(到職日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(到職日期.Value.ToShortDateString)) & "',"
        strUValue &= "離職日期 = '" & IIf(離職日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(離職日期.Value.ToShortDateString)) & "',"
        strUValue &= "備註 = '" & 備註.Text & "',"
        strUValue &= "登入否 = '" & IIf(登入否1.Checked = True, "Y", "N") & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "員工代號 = '" & 員工代號.Text & "'"

        blnCheck = dbEdit(DNS, "員工主檔", strUValue, strWValue)


        '員工薪資主檔        
        strUValue = "基本薪資 = '" & 基本薪資.Text & "',"
        strUValue &= "扶養人數 = '" & 扶養人數.Text & "',"
        strUValue &= "代扣所得稅年月 = '" & 代扣所得稅年月.Text & "',"
        strUValue &= "代扣所得稅 = '" & 代扣所得稅.Text & "',"
        strUValue &= "勞保投保日期 = '" & IIf(勞保投保日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(勞保投保日期.Value.ToShortDateString)) & "',"
        strUValue &= "勞保投保薪資 = '" & 勞保投保薪資.Text & "',"
        strUValue &= "勞保保費 = '" & 勞保保費.Text & "',"
        strUValue &= "健保投保日期 = '" & IIf(健保投保日期.Value.ToShortDateString = Now.Date, "", strSystemToDate(健保投保日期.Value.ToShortDateString)) & "',"
        strUValue &= "健保投保薪資 = '" & 健保投保薪資.Text & "',"
        strUValue &= "健保保費 = '" & 健保保費.Text & "',"
        strUValue &= "立帳郵局 = '" & 立帳郵局.Text & "',"
        strUValue &= "郵局局號 = '" & 郵局局號.Text & "',"
        strUValue &= "郵局帳號 = '" & 郵局帳號.Text & "',"
        strUValue &= "戶名 = '" & 戶名.Text & "',"
        strUValue &= "戶名身份證號 = '" & 戶名身份證號.Text & "',"
        strUValue &= "年資 = '" & 年資.Text & "',"
        strUValue &= "特休日數 = '" & 特休日數.Text & "',"
        strUValue &= "已休日數 = '" & 已休日數.Text & "',"
        strUValue &= "剩餘特休 = '" & 剩餘特休.Text & "'"

        strWValue = "員工代號 = '" & 員工代號.Text & "'"

        dbEdit(DNS, "員工薪資主檔", strUValue, strWValue)


        ''員工薪資結構檔
        ''先刪
        'dbDelete(DNS, "員工薪資結構檔", "員工代號 = '" & 員工代號.Text & "'")
        ''後加
        'For I As Integer = 0 To Tab3_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab3_DataGridViewR1.Rows(I).Cells("薪資項目代碼").Value,
        '                                   Tab3_DataGridViewR1.Rows(I).Cells("金額").Value}

        '    strIRow = "員工代號,薪資項目代碼,金額,排序"
        '    strIValue = "'" & 員工代號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & I + 1 & "'"
        '    dbInsert(DNS, "員工薪資結構檔", strIRow, strIValue)
        'Next


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "員工主檔", "員工代號 = '" & 員工代號.Text & "'")
        blnCheck = dbDelete(DNS, "員工薪資主檔", "員工代號 = '" & 員工代號.Text & "'")
        blnCheck = dbDelete(DNS, "員工薪資結構檔", "員工代號 = '" & 員工代號.Text & "'")
        blnCheck = dbDelete(DNS, "員工權限檔", "員工代號 = '" & 員工代號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Users(strKey1) '員工主檔
        UsersPay(strKey1) '員工薪資主檔
        UsersItem(strKey1) '員工薪資結構檔
    End Sub
    '員工主檔
    Sub Users(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 員工主檔"
        strSQL99 &= " WHERE 員工代號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            員工代號.Text = objDR99("員工代號").ToString
            姓名.Text = objDR99("姓名").ToString
            身份證號.Text = objDR99("身份證號").ToString
            籍貫.Text = objDR99("籍貫").ToString
            子女數.Text = objDR99("子女數").ToString
            電話.Text = objDR99("電話").ToString
            手機.Text = objDR99("手機").ToString
            E_Mail.Text = objDR99("E_Mail").ToString
            通訊地址.Text = objDR99("通訊地址").ToString
            戶籍地址.Text = objDR99("戶籍地址").ToString
            緊急聯絡人.Text = objDR99("緊急聯絡人").ToString
            關係.Text = objDR99("關係").ToString
            聯絡電話.Text = objDR99("聯絡電話").ToString
            聯絡手機.Text = objDR99("聯絡手機").ToString
            備註.Text = objDR99("備註").ToString
            最後登入時間.Text = objDR99("最後登入時間").ToString


            '非文字欄位*****
            出生日期.Value = IIf(IsDate(objDR99("出生日期").ToString) = False, Now, objDR99("出生日期").ToString)
            到職日期.Value = IIf(IsDate(objDR99("到職日期").ToString) = False, Now, objDR99("到職日期").ToString)
            離職日期.Value = IIf(IsDate(objDR99("離職日期").ToString) = False, Now, objDR99("離職日期").ToString)

            廠別代碼.SelectedValue = objDR99("廠別代碼").ToString
            僱用性質代碼.SelectedValue = objDR99("僱用性質代碼").ToString
            部門代碼.SelectedValue = objDR99("部門代碼").ToString
            職稱代碼1.SelectedValue = objDR99("職稱代碼1").ToString
            職稱代碼2.SelectedValue = objDR99("職稱代碼2").ToString
            職稱代碼3.SelectedValue = objDR99("職稱代碼3").ToString
            婚姻.SelectedValue = objDR99("婚姻").ToString

            性別1.Checked = IIf(objDR99("性別").ToString = "M", True, False)
            性別2.Checked = IIf(objDR99("性別").ToString = "F", True, False)
            登入否1.Checked = IIf(objDR99("登入否").ToString = "Y", True, False)
            登入否2.Checked = IIf(objDR99("登入否").ToString = "N", True, False)

            chk戶籍地址.Checked = IIf(objDR99("戶籍地址").ToString = objDR99("通訊地址").ToString, True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '員工薪資主檔
    Sub UsersPay(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 員工薪資主檔"
        strSQL99 &= " WHERE 員工代號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '文字欄位*****
            基本薪資.Text = objDR99("基本薪資").ToString
            扶養人數.Text = objDR99("扶養人數").ToString
            代扣所得稅年月.Text = objDR99("代扣所得稅年月").ToString
            代扣所得稅.Text = objDR99("代扣所得稅").ToString
            勞保投保薪資.Text = objDR99("勞保投保薪資").ToString
            勞保保費.Text = objDR99("勞保保費").ToString
            健保投保薪資.Text = objDR99("健保投保薪資").ToString
            健保保費.Text = objDR99("健保保費").ToString
            立帳郵局.Text = objDR99("立帳郵局").ToString
            郵局局號.Text = objDR99("郵局局號").ToString
            郵局帳號.Text = objDR99("郵局帳號").ToString
            戶名.Text = objDR99("戶名").ToString
            戶名身份證號.Text = objDR99("戶名身份證號").ToString
            年資.Text = objDR99("年資").ToString
            特休日數.Text = objDR99("特休日數").ToString
            已休日數.Text = objDR99("已休日數").ToString
            剩餘特休.Text = objDR99("剩餘特休").ToString

            '非文字欄位*****
            勞保投保日期.Value = IIf(IsDate(objDR99("勞保投保日期").ToString) = False, Now, objDR99("勞保投保日期").ToString)
            健保投保日期.Value = IIf(IsDate(objDR99("健保投保日期").ToString) = False, Now, objDR99("健保投保日期").ToString)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '員工薪資結構檔
    Sub UsersItem(ByVal strKey1 As String)
        Dim arrRowName() As String

        '薪資結構
        strSSQL = "SELECT m.一層代碼, m.一層名稱, ISNULL(t1.金額, N'0') AS 金額 FROM s_一層代碼檔 AS m"
        strSSQL &= " LEFT JOIN 員工薪資結構檔 AS t1 ON m.一層代碼 = t1.薪資項目代碼"
        strSSQL &= " WHERE m.類別 = 'S01N0005'"
        strSSQL &= " AND t1.員工代號 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY m.一層代碼 ASC"

        arrRowName = {"一層代碼", "一層名稱", "金額"}

        DataGridViewR_DB(Tab3_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub
#End Region

#Region "物件異動選擇項"
    '複製通訊地址
    Private Sub chk戶籍地址_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk戶籍地址.CheckedChanged
        Select Case chk戶籍地址.Checked
            Case True : 戶籍地址.Text = 通訊地址.Text
            Case False : 戶籍地址.Text = ""
        End Select
    End Sub
#End Region
End Class
