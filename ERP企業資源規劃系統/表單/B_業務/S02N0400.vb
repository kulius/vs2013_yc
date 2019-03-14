Public Class S02N0400
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
    Private Sub S02N0400_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '按鍵
        Me.WindowState = FormWindowState.Maximized

        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集   
        DG_通用規格_CellClick(Nothing, Nothing)
    End Sub
    Private Sub S02N0300_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S02N0400 As New S_S02N0400

        '開啟視窗
        S_S02N0400.MdiParent = fmMain
        S_S02N0400.Show()
    End Sub

    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT m.報價單號, m.報價日期, m.客戶代號, t1.公司名稱, t1.簡稱 FROM 報價主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY m.報價單號 ASC"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        'ComboBox_DGDB(規格_起, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DGDB(規格_迄, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DGDB(尺寸_起, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        'ComboBox_DGDB(尺寸_迄, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")

        ComboBox_DB(規格查詢, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' -- '+參數1", "類別 = 'S03N0004'", "")
        ComboBox_DB(長度查詢, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' -- '+參數1", "類別 = 'S03N0005'", "")

        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "客戶代號 ASC")
        ComboBox_DB(付款方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S02N0003'", "一層代碼 ASC")
        ComboBox_DB(交易幣別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S02N0004'", "一層代碼 ASC")

        ComboBox_GG(稅率課稅別代碼, ",不計,內含,外加", ",不計,內含,外加")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"報價單號", "報價日期", "客戶代號", "客戶名稱", "客戶簡稱"}
        Dim arrColWidth() As String = {"120", "120", "100", "240", "180"}

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
        strSSQL = "SELECT m.報價單號, m.報價日期, m.客戶代號, t1.公司名稱, t1.簡稱 FROM 報價主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY m.報價單號 ASC"

        '顯示欄位
        arrRowName = {"報價單號", "報價日期", "客戶代號", "公司名稱", "簡稱"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        'Dim objDataGridViewR() As DataGridView = {Tab2_DataGridViewR1}

        Dim objTextBoxM() As TextBox = {報價單號}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {所屬稅率, 備註}
        Dim objComboBox1() As ComboBox = {客戶代號, 聯絡人員, 業務人員1, 業務人員2, 付款方式代碼, 交易幣別代碼, 稅率課稅別代碼}
        Dim objRadioButton1() As RadioButton = {}
        Dim objDateTimePicker1() As DateTimePicker = {報價日期}

        'DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                Dim intQuoteNumber As String = dbMaxMin(DNS, "報價主檔", "Max", "報價單號", "strMax", "報價單號 LIKE 'A" & Mid(strDateToString(NowDate), 1, 6) & "%'")
                報價單號.Text = "A" & Mid(strDateToString(NowDate), 1, 6) & strZero(3, IIf(intQuoteNumber = "", "1", Mid(intQuoteNumber, 8, 3)))
                報價單號.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                Dim intQuoteNumber As String = dbMaxMin(DNS, "報價主檔", "Max", "報價單號", "strMax", "報價單號 LIKE 'A" & Mid(strDateToString(NowDate), 1, 6) & "%'")
                報價單號.Text = "A" & Mid(strDateToString(NowDate), 1, 6) & strZero(3, IIf(intQuoteNumber = "", "1", Mid(intQuoteNumber, 8, 3)))
                報價單號.Focus()
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
        Dim objArray_Input() As Object = {報價單號, 客戶代號}
        Dim strArray_Input() As String = {"報價單號", "客戶代號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {所屬稅率}
        Dim strArray_Numeric() As String = {"所屬稅率"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        '代號是否有重複
        If dbDataCheck(DNS, "報價主檔", "報價單號 = '" & 報價單號.Text & "'") = True Then MsgBox("系統訊息：【報價單號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '報價主檔
        strIRow = "報價單號,報價日期,客戶代號,聯絡人員,業務人員1,業務人員2,"
        strIRow &= "付款方式代碼,交易幣別代碼,稅率課稅別代碼,所屬稅率,報價總計,備註,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 報價單號.Text & "','" & strSystemToDate(報價日期.Value.ToShortDateString) & "','" & 客戶代號.SelectedValue & "','" & 聯絡人員.SelectedValue & "','" & 業務人員1.SelectedValue & "','" & 業務人員2.SelectedValue & "',"
        strIValue &= "'" & 付款方式代碼.SelectedValue & "','" & 交易幣別代碼.SelectedValue & "','" & 稅率課稅別代碼.SelectedValue & "','" & 所屬稅率.Text & "','0','" & 備註.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "報價主檔", strIRow, strIValue)


        ''報價項目檔
        'Dim intTotalPrice As Double = 0 '報價總金額
        'For I As Integer = 0 To DataGridView.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("品名類別").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("規格起").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("規格迄").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("尺寸起").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("尺寸迄").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("加工方式").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("材質類別").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("表面處理").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("其他說明").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("報價單價").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("以品名判定").Value}

        '    If strRowValue(0) <> "" Then
        '        strIRow = "報價單號,序號,品名類別,規格起,規格迄,尺寸起,尺寸迄,"
        '        strIRow &= "加工方式,材質類別,表面處理,其他說明,報價單價,以品名判定"

        '        strIValue = "'" & 報價單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "',"
        '        strIValue &= "'" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "'"

        '        dbInsert(DNS, "報價項目檔", strIRow, strIValue)
        '        intTotalPrice += IIf(IsNumeric(strRowValue(9)) = True, strRowValue(9), 0)
        '    End If
        'Next

        '報價總金額計算回寫
        ' dbEdit(DNS, "報價主檔", "報價總計 = '" & intTotalPrice & "'", "報價單號 = '" & 報價單號.Text & "'")


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
        Dim objArray_Input() As Object = {報價單號, 客戶代號}
        Dim strArray_Input() As String = {"報價單號", "客戶代號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {所屬稅率}
        Dim strArray_Numeric() As String = {"所屬稅率"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '客戶主檔
        strUValue = "報價日期 = '" & strSystemToDate(報價日期.Value.ToShortDateString) & "',"
        strUValue &= "客戶代號 = '" & 客戶代號.SelectedValue & "',"
        strUValue &= "聯絡人員 = '" & 聯絡人員.SelectedValue & "',"
        strUValue &= "業務人員1 = '" & 業務人員1.SelectedValue & "',"
        strUValue &= "業務人員2 = '" & 業務人員2.SelectedValue & "',"
        strUValue &= "付款方式代碼 = '" & 付款方式代碼.SelectedValue & "',"
        strUValue &= "交易幣別代碼 = '" & 交易幣別代碼.SelectedValue & "',"
        strUValue &= "稅率課稅別代碼 = '" & 稅率課稅別代碼.SelectedValue & "',"
        strUValue &= "所屬稅率 = '" & 所屬稅率.Text & "',"
        strUValue &= "報價總計 = '0',"
        strUValue &= "備註 = '" & 備註.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "報價單號 = '" & 報價單號.Text & "'"

        blnCheck = dbEdit(DNS, "報價主檔", strUValue, strWValue)


        ''相關聯絡人檔
        ''先刪
        'dbDelete(DNS, "報價項目檔", "報價單號 = '" & 報價單號.Text & "'")
        ''後加
        'Dim intTotalPrice As Double = 0 '報價總金額
        'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("品名類別").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("規格起").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("規格迄").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("尺寸起").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("尺寸迄").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("加工方式").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("材質類別").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("表面處理").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("其他說明").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("報價單價").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("以品名判定").Value}

        '    If strRowValue(0) <> "" Then
        '        '報價項目
        '        strIRow = "報價單號,序號,品名類別,規格起,規格迄,尺寸起,尺寸迄,"
        '        strIRow &= "加工方式,材質類別,表面處理,其他說明,報價單價,以品名判定"

        '        strIValue = "'" & 報價單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "',"
        '        strIValue &= "'" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "'"

        '        dbInsert(DNS, "報價項目檔", strIRow, strIValue)
        '        intTotalPrice += IIf(IsNumeric(strRowValue(9)) = True, strRowValue(9), 0)
        '    End If
        'Next

        ''報價總金額計算回寫
        'dbEdit(DNS, "報價主檔", "報價總計 = '" & intTotalPrice & "'", "報價單號 = '" & 報價單號.Text & "'")


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "報價主檔", "報價單號 = '" & 報價單號.Text & "'")
        blnCheck = dbDelete(DNS, "報價項目檔", "報價單號 = '" & 報價單號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Quote(strKey1) '報價主檔
        QuoteItem(strKey1) '報價項目檔
        QuotestandItem() '通用規格檔
        standItem() '挑選規格檔
        standItem1() '填寫尺吋1檔
        standItem2() '填寫尺吋2檔
        standItem3() '填寫尺吋3檔
        standItem4() '填寫尺吋4檔
        standItem5() '填寫尺吋5檔
    End Sub
    '報價主檔
    Sub Quote(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 報價主檔"
        strSQL99 &= " WHERE 報價單號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            報價單號.Text = objDR99("報價單號").ToString
            報價總計.Text = FormatNumber(objDR99("報價總計").ToString, 0, -1, 0, -1)
            所屬稅率.Text = objDR99("所屬稅率").ToString
            備註.Text = objDR99("備註").ToString


            '非文字欄位*****
            報價日期.Value = IIf(IsDate(objDR99("報價日期").ToString) = False, Now, objDR99("報價日期").ToString)

            客戶代號.SelectedValue = objDR99("客戶代號").ToString
            聯絡人員.SelectedValue = objDR99("聯絡人員").ToString
            業務人員1.SelectedValue = objDR99("業務人員1").ToString
            業務人員2.SelectedValue = objDR99("業務人員2").ToString
            付款方式代碼.SelectedValue = objDR99("付款方式代碼").ToString
            交易幣別代碼.SelectedValue = objDR99("交易幣別代碼").ToString
            稅率課稅別代碼.SelectedValue = objDR99("稅率課稅別代碼").ToString
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '報價項目檔
    Sub QuoteItem(ByVal strKey1 As String)
        'Dim arrRowName() As String

        ''薪資結構
        'strSSQL = "SELECT * FROM 報價項目檔"
        'strSSQL &= " WHERE 報價單號 = '" & strKey1 & "'"
        'strSSQL &= " ORDER BY 序號 ASC"

        'arrRowName = {"品名類別", "規格起", "規格迄", "尺寸起", "尺寸迄", _
        '              "加工方式", "材質類別", "表面處理", "其他說明", "報價單價", "以品名判定"}

        'DataGridViewR_DB(Tab2_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub
    '通用規格檔
    Sub QuotestandItem()
        strSSQL = "SELECT m.規格起 as 規格_起,m.規格迄 as 規格_迄 FROM 報價通用規格檔 AS m"
        strSSQL &= " ORDER BY m.序號 ASC"

        DataGridView_HeaderDB(DG_通用規格, DNS, strSSQL)
    End Sub
    Sub standItem()
        strSSQL = "SELECT m.規格起+'-'+規格迄 as 規格起迄 FROM 報價通用規格檔 AS m"
        strSSQL &= " ORDER BY m.序號 ASC"

        DataGridView_HeaderDB(DG_規格起迄, DNS, strSSQL)
    End Sub
    Sub standItem1()
        strSSQL = "SELECT m.尺寸起+'-'+尺寸迄 as 尺寸起迄 FROM 報價通用尺寸檔 AS m"
        strSSQL &= " inner join 報價通用規格檔 d on m.規格起=d.規格起 and m.規格迄=d.規格迄"
        strSSQL &= " where 顯示位置=1"
        strSSQL &= " ORDER BY d.序號 ASC"

        DataGridView_HeaderDB(DG_尺寸起迄1, DNS, strSSQL)
    End Sub
    Sub standItem2()
        strSSQL = "SELECT m.尺寸起+'-'+尺寸迄 as 尺寸起迄 FROM 報價通用尺寸檔 AS m"
        strSSQL &= " inner join 報價通用規格檔 d on m.規格起=d.規格起 and m.規格迄=d.規格迄"
        strSSQL &= " where 顯示位置=2"
        strSSQL &= " ORDER BY d.序號 ASC"

        DataGridView_HeaderDB(DG_尺寸起迄2, DNS, strSSQL)
    End Sub
    Sub standItem3()
        strSSQL = "SELECT m.尺寸起+'-'+尺寸迄 as 尺寸含矯 FROM 報價通用尺寸檔 AS m"
        strSSQL &= " inner join 報價通用規格檔 d on m.規格起=d.規格起 and m.規格迄=d.規格迄"
        strSSQL &= " where 顯示位置=3"
        strSSQL &= " ORDER BY d.序號 ASC"

        DataGridView_HeaderDB(DG_尺寸起迄3, DNS, strSSQL)
    End Sub
    Sub standItem4()
        strSSQL = "SELECT m.尺寸起+'-'+尺寸迄 as 尺寸含矯 FROM 報價通用尺寸檔 AS m"
        strSSQL &= " inner join 報價通用規格檔 d on m.規格起=d.規格起 and m.規格迄=d.規格迄"
        strSSQL &= " where 顯示位置=4"
        strSSQL &= " ORDER BY d.序號 ASC"

        DataGridView_HeaderDB(DG_尺寸起迄4, DNS, strSSQL)
    End Sub
    Sub standItem5()
        strSSQL = "SELECT m.尺寸起+'-'+尺寸迄 as 尺寸含矯 FROM 報價通用尺寸檔 AS m"
        strSSQL &= " inner join 報價通用規格檔 d on m.規格起=d.規格起 and m.規格迄=d.規格迄"
        strSSQL &= " where 顯示位置=5"
        strSSQL &= " ORDER BY d.序號 ASC"

        DataGridView_HeaderDB(DG_尺寸起迄5, DNS, strSSQL)
    End Sub
#End Region

#Region "物件異動選擇項"
    '產生聯絡人、業務人員選項及其他相關資訊
    Private Sub 客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Try
            '相關選單
            ComboBox_DB(聯絡人員, DNS, "相關聯絡人檔", "聯絡人員", "聯絡人員", "種類 = 'C' AND 代號 = '" & 客戶代號.SelectedValue & "'", "序號 ASC")
            ComboBox_DB(業務人員1, DNS, "相關聯絡人檔", "聯絡人員", "聯絡人員", "種類 = 'C' AND 代號 = '" & 客戶代號.SelectedValue & "'", "序號 ASC")
            ComboBox_DB(業務人員2, DNS, "相關聯絡人檔", "聯絡人員", "聯絡人員", "種類 = 'C' AND 代號 = '" & 客戶代號.SelectedValue & "'", "序號 ASC")

            '相關資料
            統一編號.Text = dbGetSingleRow(DNS, "客戶主檔", "統一編號", "客戶代號 = '" & 客戶代號.SelectedValue & "'")
            客戶電話.Text = dbGetSingleRow(DNS, "客戶主檔", "電話1", "客戶代號 = '" & 客戶代號.SelectedValue & "'")
            客戶傳真.Text = dbGetSingleRow(DNS, "客戶主檔", "傳真1", "客戶代號 = '" & 客戶代號.SelectedValue & "'")
        Catch ex As Exception

        End Try
    End Sub
    '產生其他相關資訊
    Private Sub 聯絡人員_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles 聯絡人員.SelectedIndexChanged
        Try
            聯絡人員手機.Text = dbGetSingleRow(DNS, "相關聯絡人檔", "手機", "種類 = 'C' AND 代號 = '" & 客戶代號.SelectedValue & "' AND 聯絡人員 = '" & 聯絡人員.SelectedValue & "'")
            聯絡人員分機.Text = dbGetSingleRow(DNS, "相關聯絡人檔", "分機", "種類 = 'C' AND 代號 = '" & 客戶代號.SelectedValue & "' AND 聯絡人員 = '" & 聯絡人員.SelectedValue & "'")
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub 客戶代號_SelectedIndexChanged_1(sender As System.Object, e As System.EventArgs) Handles 客戶代號.SelectedIndexChanged
        If 客戶代號.SelectedIndex <> 0 Then
            客戶代碼.Text = 客戶代號.SelectedValue
        End If
    End Sub

    Private Sub 客戶代碼_Leave(sender As System.Object, e As System.EventArgs) Handles 客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & 客戶代碼.Text & "'") > 0 Then
            客戶代號.SelectedValue = 客戶代碼.Text
        Else
            客戶代號.SelectedValue = ""
        End If
    End Sub

    Private Sub btnSaveData_Click(sender As System.Object, e As System.EventArgs) Handles btnSave通用規格.Click
        '先刪
        dbDelete(DNS, "報價通用規格檔", "1=1")
        '後加
        '應收帳款項目檔
        For I As Integer = 0 To DG_通用規格.RowCount - 1 Step 1
            Dim strRowValue() As String = {DG_通用規格.Rows(I).Cells("規格_起").Value,
                                           DG_通用規格.Rows(I).Cells("規格_迄").Value,
                                           DG_通用規格.Rows(I).Cells("規格數值_起").Value,
                                           DG_通用規格.Rows(I).Cells("規格數值_迄").Value}

            'If strRowValue(0) <> "" Then
            strIRow = "規格起,規格迄,規格數值起,規格數值迄"
            strIValue = "'" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "'"
            dbInsert(DNS, "報價通用規格檔", strIRow, strIValue)
            ' End If
        Next
        '先刪

        dbDelete(DNS, "報價通用尺寸檔", "規格起+規格迄 not in (select 規格起+規格迄 from 報價通用規格檔)")

        DG_通用規格_CellClick(Nothing, Nothing)
    End Sub

    Private Sub btnadd通用規格_Click(sender As System.Object, e As System.EventArgs) Handles btnadd通用規格.Click
        DG_通用規格.Rows.Add(New Object() {"", "", 0, 0})
    End Sub

    Private Sub btndel通用格規_Click(sender As System.Object, e As System.EventArgs) Handles btndel通用格規.Click
        For Each r As DataGridViewRow In DG_通用規格.SelectedRows
            If Not r.IsNewRow Then
                DG_通用規格.Rows.Remove(r)
            End If
        Next
    End Sub

    Private Sub btnadd通用尺寸_Click(sender As System.Object, e As System.EventArgs) Handles btnadd通用尺寸.Click
        DG_通用尺寸.Rows.Add(New Object() {"", "", 0, 0, 1})
    End Sub

    Private Sub btndel通用尺寸_Click(sender As System.Object, e As System.EventArgs) Handles btndel通用尺寸.Click
        For Each r As DataGridViewRow In DG_通用尺寸.SelectedRows
            If Not r.IsNewRow Then
                DG_通用尺寸.Rows.Remove(r)
            End If
        Next
    End Sub


    Private Sub btnSave通用尺寸_Click(sender As System.Object, e As System.EventArgs) Handles btnSave通用尺寸.Click
        Dim 通用規格起 As String = DG_通用規格.CurrentRow.Cells("規格_起").Value
        Dim 通用規格迄 As String = DG_通用規格.CurrentRow.Cells("規格_迄").Value
        Dim 通用規格數值起 As String = DG_通用規格.CurrentRow.Cells("規格數值_起").Value
        Dim 通用規格數值迄 As String = DG_通用規格.CurrentRow.Cells("規格數值_迄").Value



        '先刪
        dbDelete(DNS, "報價通用尺寸檔", "規格起 = '" & 通用規格起 & "' and 規格迄 = '" & 通用規格迄 & "'")
        '後加
        '應收帳款項目檔
        For I As Integer = 0 To DG_通用尺寸.RowCount - 1 Step 1
            Dim strRowValue() As String = {DG_通用尺寸.Rows(I).Cells("尺寸_起").Value,
                                           DG_通用尺寸.Rows(I).Cells("尺寸_迄").Value,
                                           DG_通用尺寸.Rows(I).Cells("顯示位置").Value,
                                           DG_通用尺寸.Rows(I).Cells("尺寸數值_起").Value,
                                           DG_通用尺寸.Rows(I).Cells("尺寸數值_迄").Value}

            'If strRowValue(0) <> "" Then
            strIRow = "尺寸起,尺寸迄,顯示位置,尺寸數值起,尺寸數值迄,規格起,規格迄,規格數值起,規格數值迄"
            strIValue = "'" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & 通用規格起 & "','" & 通用規格迄 & "','" & 通用規格數值起 & "','" & 通用規格數值迄 & "'"
            dbInsert(DNS, "報價通用尺寸檔", strIRow, strIValue)
            ' End If
        Next
    End Sub

    Private Sub DG_通用規格_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_通用規格.CellClick
        Try
            Dim 通用規格起 As String = DG_通用規格.CurrentRow.Cells("規格_起").Value
            Dim 通用規格迄 As String = DG_通用規格.CurrentRow.Cells("規格_迄").Value
            Dim 通用規格數值起 As String = DG_通用規格.CurrentRow.Cells("規格數值_起").Value
            Dim 通用規格數值迄 As String = DG_通用規格.CurrentRow.Cells("規格數值_迄").Value

            'MsgBox(通用規格起)
            'MsgBox(通用規格迄)

            strSSQL = "SELECT m.尺寸起 as 尺寸_起,m.尺寸迄 as 尺寸_迄,顯示位置,m.尺寸數值起 as 尺寸數值_起,m.尺寸數值迄 as 尺寸數值_迄 FROM 報價通用尺寸檔 AS m"
            strSSQL &= " where  規格起 = '" & 通用規格起 & "' and 規格迄 = '" & 通用規格迄 & "'"
            strSSQL &= " ORDER BY m.序號 ASC"

            DataGridView_HeaderDB(DG_通用尺寸, DNS, strSSQL)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub DG_通用尺寸_Leave(sender As System.Object, e As System.EventArgs) Handles DG_通用尺寸.Leave
        btnSave通用尺寸.PerformClick()
    End Sub

    Private Sub DG_通用規格_Leave(sender As System.Object, e As System.EventArgs) Handles DG_通用規格.Leave
        btnSave通用規格.PerformClick()
    End Sub

    Private Sub DG_通用規格_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_通用規格.CellEndEdit
        Dim 直徑規格數字1 As String = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & DG_通用規格.CurrentRow.Cells("規格_起").Value & "'")

        If IsNumeric(直徑規格數字1) Then
            DG_通用規格.CurrentRow.Cells("規格數值_起").Value = 直徑規格數字1
        End If

        Dim 直徑規格數字2 As String = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & DG_通用規格.CurrentRow.Cells("規格_迄").Value & "'")
        If IsNumeric(直徑規格數字2) Then
            DG_通用規格.CurrentRow.Cells("規格數值_迄").Value = 直徑規格數字2
        End If
    End Sub

    Private Sub DG_通用尺寸_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DG_通用尺寸.CellEndEdit
        Dim 數字1 As String = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0005' and 一層代碼 = '" & DG_通用尺寸.CurrentRow.Cells("尺寸_起").Value & "'")
        If IsNumeric(數字1) Then
            DG_通用尺寸.CurrentRow.Cells("尺寸數值_起").Value = 數字1
        End If


        Dim 數字2 As String = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0005' and 一層代碼 = '" & DG_通用尺寸.CurrentRow.Cells("尺寸_迄").Value & "'")
        If IsNumeric(數字2) Then
            DG_通用尺寸.CurrentRow.Cells("尺寸數值_迄").Value = 數字2
        End If
    End Sub
End Class
