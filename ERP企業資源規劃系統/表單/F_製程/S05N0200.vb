Public Class S05N0200
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
#Region "單用變數"
    Dim strPage As String = "FA" & Mid(Now.Year, 3, 2)
    Dim TotalTime As Integer
    Dim select收料人員 As String = ""
    Dim select收料單位 As String = ""
    Dim select收料空桶重 As String = ""
#End Region

#Region "@Form及功能操作@"
    Private Sub S05N0200_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        '寬
        'BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next
        BCtrl.Visible = False
        BasicPanel.Visible = False

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        'DataGridView_Basic() 'DataGridView初始化
        'FillData("") '載入資料集
        For i As Integer = 0 To Tab2_DataGridViewR1.Columns.Count - 1
            Tab2_DataGridViewR1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub S05N0200_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S05N0200_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub

    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT m.*,t1.公司名稱 AS 客戶,t2.一層名稱 AS 品名,t3.一層名稱 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY 工令號碼 DESC"
        SqlToExcel(DNS, strSSQL)
    End Sub
    '袛允許輸入數字
    Private Sub TextKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        '使用 Char.IsDigit 方法 : 指示指定的 Unicode 字元是否分類為十進位數字。
        'e.KeyChar == (Char)48 ~ 57 -----> 0~9
        'Char.IsControl 方法 : 指示指定的 Unicode 字元是否分類為控制字元。
        'e.KeyChar == (Char)8 -----------> Backpace
        'e.KeyChar == (Char)13-----------> Enter
        If Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DGDB(單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "參數1 ASC")
        ComboBox_DGDB(收料單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "參數1 ASC")
        ComboBox_DGDB(入料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DGDB(收料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")



        ComboBox_DB(s爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")


        'ComboBox_DB(產量操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        ComboBox_DB(操作人員1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(操作人員2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' ) ", "姓名 ASC")
        ComboBox_DB(操作人員3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")

        'ComboBox_DB(產量過磅人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")

        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")


        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")

        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        ''欄位名稱
        'Dim arrColName() As String = {"工令號碼", "客戶", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"}
        'Dim arrColWidth() As String = {"120", "120", "100", "160", "100", "100", "100", "100", "100", "100", "100", "100"}

        'DataGridView.ColumnCount = arrColName.Length
        'DataGridView.RowCount = 1

        'For J As Integer = 0 To arrColName.Length - 1 Step 1
        '    With DataGridView
        '        .Columns(J).Name = arrColName(J) '欄位名稱
        '        .Columns(J).Width = arrColWidth(J) '欄位寬度
        '    End With
        'Next
    End Sub
    '欄位顏色
    Private Sub DataGridView_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
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
    Private Sub DataGridView_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        intCol = e.ColumnIndex
        intRow = e.RowIndex

        FlagMoveSeat(0) '讀取值
    End Sub

    'DataGridView控制行列增減
    Private Sub Tab2_btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Tab2_DataGridViewR1.Rows.Add()
    End Sub

    Private Sub Tab2_btnDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each r As DataGridViewRow In Tab2_DataGridViewR1.SelectedRows
            If Not r.IsNewRow Then
                Tab2_DataGridViewR1.Rows.Remove(r)
            End If
        Next
    End Sub
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        '查詢語法
        strSSQL = "SELECT m.*,t1.公司名稱 AS 客戶,t2.一層名稱 AS 品名,t3.一層名稱 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 工令號碼 DESC"

        '顯示欄位
        arrRowName = {"工令號碼", "客戶", "日期", "品名", "規格", "材質", "表面", "回火溫度", "表面硬度", "心部硬度", "線材爐號", "狀態"}
        '"客戶", "工令號碼", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"
        '開啟產生DataGridView
        'blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)

        Set_Control_RW(MainPanel, butStatus)
        裝袋合計.ReadOnly = True
        進貨重量.ReadOnly = True
        磅後桶數.ReadOnly = True
        磅後總重.ReadOnly = True
        桶數差.ReadOnly = True
        重量差.ReadOnly = True
        入料桶數.ReadOnly = True
        入料總重.ReadOnly = True


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式

            Case 1 '新增模式
                Tab2_DataGridViewR1.Focus()

            Case 2 '修改模式
                Tab2_DataGridViewR1.Focus()

            Case 3 '複製模式
                Tab2_DataGridViewR1.Focus()
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


        ''資料查詢*****
        'If DataGridView.Rows.Count > 0 Then
        '    Try
        '        '關鍵值
        '        Dim strKey As String = DataGridView.Rows(intRow).Cells(0).Value.ToString

        '        '停在選定之儲存格
        '        ShowData(strKey)
        '        txtSeat.Text = intRow + 1 '目前位置
        '        DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub

    ''新增
    'Public Overrides Function InsertData() As Boolean
    '    Dim blnCheck As Boolean = False

    '    '防呆*****
    '    '必輸入
    '    Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號, 開單人員, 司機代號}
    '    Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號", "開單人員", "司機代號"}
    '    blnCheck = blnInputCheck(objArray_Input, strArray_Input)

    '    '必數字
    '    Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重, 扭力}
    '    Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重", "扭力"}
    '    blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

    '    '代號是否有重複
    '    If dbDataCheck(DNS, "進貨單主檔", "工令號碼 = '" & 工令號碼.Text & "'") = True Then MsgBox("系統訊息：【工令號碼】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

    '    If blnCheck = False Then Return False : Exit Function
    '    '防呆結束*****

    '    '開啟儲存*****
    '    '過磅單主檔
    '    strIRow = "工令號碼, 前工令號碼, 日期, 時間,"
    '    strIRow &= "車次序號, 客戶代號, 加工廠代號, 開單人員,"
    '    strIRow &= "司機代號, 客戶單號, 客戶批號, 產品代碼,"
    '    strIRow &= "規格代碼, 長度代碼, 長度說明,品名分類代碼,"
    '    strIRow &= "加工方式代碼, 材質代碼, 規範分類, 強度級數,"
    '    strIRow &= "表面處理代碼, 電鍍別代碼, 次加工廠代號1, 次加工廠代號2,"
    '    strIRow &= "數量1, 單位代號1, 數量2, 單位代號2,"
    '    strIRow &= "數量3,單位代號3, 數量4, 單位代號4,"
    '    strIRow &= "淨重, 線材爐號, 依據標準, 表面硬度,"
    '    strIRow &= "心部硬度, 抗拉強度, 滲碳層, 扭力,"
    '    strIRow &= "華司材質, 華司硬度, 試片, 存放位置,"
    '    strIRow &= "運費種類, 回火溫度, 以前爐號, 預排爐號,"
    '    strIRow &= "注意事項1, 注意事項2, 注意事項3, 注意事項4,"
    '    strIRow &= "建立人員,建立日期,修改人員,修改日期"

    '    strIValue = "'" & 工令號碼.Text & "','" & 前工令號碼.Text & "','" & strSystemToDate(日期.Value.ToShortDateString) & "','" & 時間.Text & "',"
    '    strIValue &= "'" & 車次序號.Text & "','" & 客戶代號.SelectedValue & "','" & 加工廠代號.SelectedValue & "','" & 開單人員.SelectedValue & "',"
    '    strIValue &= "'" & 司機代號.SelectedValue & "','" & 客戶單號.Text & "','" & 客戶批號.Text & "','" & 產品代碼.SelectedValue & "',"
    '    strIValue &= "'" & 規格代碼.SelectedValue & "','" & 長度代碼.SelectedValue & "','" & 長度說明.Text & "','" & 品名分類代碼.SelectedValue & "',"
    '    strIValue &= "'" & 加工方式代碼.SelectedValue & "','" & 材質代碼.SelectedValue & "','" & 規範分類.Text & "','" & 強度級數.Text & "',"
    '    strIValue &= "'" & 表面處理代碼.SelectedValue & "','" & 電鍍別代碼.SelectedValue & "','" & 次加工廠代號1.SelectedValue & "','" & 次加工廠代號2.SelectedValue & "',"
    '    strIValue &= "'" & 數量1.Text & "','" & 單位代號1.SelectedValue & "','" & 數量2.Text & "','" & 單位代號2.SelectedValue & "',"
    '    strIValue &= "'" & 數量3.Text & "','" & 長度代碼.SelectedValue & "','" & 數量3.Text & "','" & 單位代號3.SelectedValue & "',"
    '    strIValue &= "'" & 淨重.Text & "','" & 線材爐號.Text & "','" & 依據標準.Text & "','" & 表面硬度.Text & "',"
    '    strIValue &= "'" & 心部硬度.Text & "','" & 抗拉強度.Text & "','" & 滲碳層.Text & "','" & 扭力.Text & "',"
    '    strIValue &= "'" & 華司材質.Text & "','" & 華司硬度.Text & "','" & IIf(試片1.Checked = True, "Y", "N") & "','" & 存放位置.Text & "',"
    '    strIValue &= "'" & 運費種類.SelectedValue & "','" & 回火溫度.Text & "','" & 以前爐號.Text & "','" & 預排爐號.SelectedValue & "',"
    '    strIValue &= "'" & 注意事項1.Text & "','" & 注意事項2.Text & "','" & 注意事項3.Text & "','" & 注意事項4.Text & "',"
    '    strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

    '    blnCheck = dbInsert(DNS, "進貨單主檔", strIRow, strIValue)




    '    '--異動後初始化--        
    '    MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    FillData("")
    '    Return blnCheck
    'End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = True

        '防呆*****
        '必輸入
        'Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號, 開單人員, 司機代號}
        'Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號", "開單人員", "司機代號"}
        'blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        'Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重, 扭力}
        'Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重", "扭力"}
        'blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****

        '開啟儲存*****
        '客戶主檔
        strUValue = ""

        GetCtrlUpdateSql(MainPanel, "BCtrl", strUValue)

        '無法SQL的欄位*****

        strUValue &= "過磅狀態 = '" & "已過磅" & "',"

        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        'strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        ComboBoxList()
        Return blnCheck
    End Function

    '刪除回復成 未過磅狀態
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        strUValue = "過磅狀態 = '" & "" & "',"

        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        '   strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
        '--異動後初始化--
        MessageBox.Show("※資料已回復(未過磅狀態)" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        ComboBoxList()

    End Sub
    'Form關閉前，把狀態變為0，以防止出現緊告視窗
    Public Overrides Sub BeforeFormClose()
        MyTableStatus = 0
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        MasterData(strKey1) '主檔    
        MasterItem(strKey1) '桶數、重量
    End Sub
    '主檔
    Sub MasterData(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT 淨重 AS 進貨重量 ,* FROM 進貨單主檔"
        strSQL99 &= " WHERE 工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            ControlReadData(MainPanel, objDR99)

            '無法塞值的欄位*****

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '項目檔
    Sub MasterItem(ByVal strKey1 As String)

        strSSQL = "SELECT case when b.姓名 is null then '' else m.收料人員 end as 收料人員,m.* FROM 製造單項目檔 AS m"
        strSSQL &= " left join 員工主檔 b on m.收料人員=b.員工代號  and 離職日期=''"
        strSSQL &= " WHERE m.工令號碼 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY m.桶號 ASC"

        DataGridView_HeaderDB(Tab2_DataGridViewR1, DNS, strSSQL)

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value > 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        入料桶數.Text = T桶數
        入料總重.Text = T重量

        T重量 = 0
        T桶數 = 0
        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If


        If dbCount(DNS, "製造單項目檔", "intCount", "工令號碼 = '" & strKey1 & "'") = 0 Then
            Dim T1 As Integer = CInt(裝袋合計.Text)
            For i1 = 1 To T1 + 5
                Tab2_DataGridViewR1.Rows.Add(New Object() {i1, 0, 0, "", 0, "", 0, 0, "", 0, ""})
            Next
        End If


        'Dim arrRowName() As String

        ''過磅單項目
        'strSSQL = "SELECT m.* FROM 製造單項目檔 AS m"
        'strSSQL &= " WHERE m.工令號碼 = '" & strKey1 & "'"
        'strSSQL &= " ORDER BY m.序號 ASC"

        'arrRowName = {"重量", "桶號", "備註"}

        'DataGridViewR_DB(Tab2_DataGridViewR1, DNS, strSSQL, arrRowName)

        'If dbCount(DNS, "製造單項目檔", "intCount", "工令號碼 = '" & strKey1 & "'") = 0 Then
        '    Dim T1 As Integer = CInt(裝袋合計.Text)
        '    For i1 = 1 To T1 + 5
        '        Tab2_DataGridViewR1.Rows.Add(New Object() {0, i1, ""})
        '    Next
        'End If
    End Sub
    '查詢按鈕
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim str As String
        str = " "
        If s爐號.Text <> "" Then
            str &= " and 預排爐號 ='" + s爐號.Text + "'"
        End If
        If s未過磅工令.Text <> "" Then
            str &= " and 工令號碼 ='" + s未過磅工令.Text + "'"
        End If
        If s已過磅工令.Text <> "" Then
            str &= " and 工令號碼 ='" + s已過磅工令.Text + "'"
        End If


        FillData(str)
    End Sub
#End Region
#Region "物件異動選擇項"
    Private Sub Tab2_DataGridViewR1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tab2_DataGridViewR1.CellEndEdit
        ' Try
        Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料淨重").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("空桶重").Value
        Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後淨重").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料空桶重").Value
        Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("重量差1").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料淨重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後淨重").Value


        If Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料人員").Value = "" Then
            Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料人員").Value = select收料人員
        Else
            select收料人員 = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料人員").Value
        End If

        If Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料單位").Value = "" Then
            Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料單位").Value = select收料單位
        Else
            select收料單位 = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料單位").Value
        End If

        'If Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料空桶重").Value = "0" Then
        '    Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料空桶重").Value = select收料空桶重
        'Else
        '    select收料空桶重 = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("收料空桶重").Value
        'End If

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0
        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If
        ' Catch ex As Exception

        ' End Try



    End Sub
    Private Sub s爐號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s爐號.SelectedIndexChanged
        ComboBox_DB(s未過磅工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(過磅狀態,'')='' and 預排爐號='" + s爐號.Text + "'", "序號")
        ComboBox_DB(s已過磅工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(過磅狀態,'')<>'' and 預排爐號='" + s爐號.Text + "'", "製造日期1")

    End Sub
    Private Sub s未過磅工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s未過磅工令.SelectedIndexChanged
        If s未過磅工令.SelectedIndex <> 0 Then
            s已過磅工令.SelectedIndex = 0

            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s未過磅工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s未過磅工令.SelectedValue + "'"
            End If
            ShowData(s未過磅工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)
        End If
    End Sub

    Private Sub s已過磅工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s已過磅工令.SelectedIndexChanged
        If s已過磅工令.SelectedIndex <> 0 Then
            s未過磅工令.SelectedIndex = 0

            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s已過磅工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s已過磅工令.SelectedValue + "'"
            End If
            ShowData(s已過磅工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)
        End If
    End Sub



#End Region


    Private Sub 產量操作人員_Leave(sender As System.Object, e As System.EventArgs)
        'Dim blnCheck As Boolean = False

        'If 產量過磅人員.SelectedIndex <> 0 Then
        '    strUValue = ""
        '    GetCtrlUpdateSql(MainPanel, "BCtrl", strUValue)
        '    '無法SQL的欄位*****
        '    'strUValue &= "狀態 = '" & "5" & "',"
        '    strUValue &= "過磅狀態 = '" & "已過磅" & "',"
        '    strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        '    strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        '    strWValue = "工令號碼 = '" & 工令號碼.Text & "'"
        '    blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

        '    '先刪
        '    dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")

        '    For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '        Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("桶號").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("空桶重").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("單位").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("生料重").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("磅後重").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("收料人員").Value,
        '                                       Tab2_DataGridViewR1.Rows(I).Cells("重量差").Value,
        '                                        Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

        '        If strRowValue(0) <> "" Then
        '            strIRow = "工令號碼,桶號,空桶重,單位,生料重,生料淨重,入料人員,磅後重,磅後淨重,收料人員,重量差,備註"
        '            strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "'"
        '            blnCheck = dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
        '        End If
        '    Next

        '    ''先刪
        '    'dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")

        '    'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("重量").Value,
        '    '                                   Tab2_DataGridViewR1.Rows(I).Cells("桶號").Value,
        '    '                                    Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

        '    '    If strRowValue(0) <> "" Then
        '    '        strIRow = "工令號碼,重量,桶號,備註"
        '    '        strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "'"
        '    '        blnCheck = dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
        '    '    End If
        '    'Next

        '    '--異動後初始化--        
        '    'MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub


    Private Sub btnSaveData_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveData.Click
        If 工令號碼.Text = "" Then
            Exit Sub
        End If

        MainPanel.Enabled = False

        Dim blnCheck As Boolean = False
        '先刪
        dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("桶號").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("空桶重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("單位").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("生料重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("磅後重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料人員").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("重量差1").Value,
                                            Tab2_DataGridViewR1.Rows(I).Cells("備註").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料單位").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料空桶重").Value}

            If strRowValue(0) <> "" Then
                strIRow = "工令號碼,桶號,空桶重,單位,生料重,生料淨重,入料人員,磅後重,磅後淨重,收料人員,重量差,備註,收料單位,收料空桶重"
                strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "','" & strRowValue(11) & "','" & strRowValue(12) & "'"
                blnCheck = dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
            End If

            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If

        strUValue = ""
        GetCtrlUpdateSql(MainPanel, "BCtrl", strUValue)
        '無法SQL的欄位*****
        'strUValue &= "狀態 = '" & "5" & "',"
        strUValue &= "過磅狀態 = '" & "已過磅" & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"
        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
        MainPanel.Enabled = True
    End Sub

    Private Sub 工令輸入_Leave(sender As System.Object, e As System.EventArgs) Handles 工令輸入.Leave
        If 工令輸入.Text <> "" Then
            's未過磅工令.SelectedIndex = 0
            's已過磅工令.SelectedIndex = 0
            If dbCount(DNS, "進貨單主檔", "intCount", "工令號碼 = '" & 工令輸入.Text & "'") > 0 Then
                ShowData(工令輸入.Text)
            Else
                MsgBox("無此工令號碼")
            End If

            'butEdit.PerformClick()
            'SetControls(2)
        End If
    End Sub

    Private Sub Tab2_DataGridViewR1_Leave(sender As Object, e As EventArgs) Handles Tab2_DataGridViewR1.Leave
        btnSaveData.PerformClick()
    End Sub

    Private Sub 操作人員1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 操作人員3.SelectedIndexChanged, 操作人員2.SelectedIndexChanged, 操作人員1.SelectedIndexChanged
        btnSaveData.PerformClick()
    End Sub

    Private Sub BtnRData_Click_1(sender As Object, e As EventArgs) Handles BtnRData.Click
        btnSaveData.PerformClick()
        If s爐號.SelectedIndex <> 0 Then
            TotalTime = 0
            Dim svalue1 As String = ""
            Dim svalue2 As String = ""
            If s未過磅工令.SelectedIndex <> 0 Then
                svalue1 = s未過磅工令.SelectedValue
            End If

            If s已過磅工令.SelectedIndex <> 0 Then
                svalue2 = s已過磅工令.SelectedValue
            End If

            ComboBox_DB(s未過磅工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(過磅狀態,'')='' and 預排爐號='" + s爐號.Text + "'", "序號")
            ComboBox_DB(s已過磅工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(過磅狀態,'')<>'' and 預排爐號='" + s爐號.Text + "'", "製造日期1")


            Try
                If svalue1 <> "" Then s未過磅工令.SelectedValue = svalue1
                If svalue2 <> "" Then s已過磅工令.SelectedValue = svalue2
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        TotalTime = TotalTime + 1
        Dim t1 As Integer = TotalTime \ 60
        Dim t2 As Integer = TotalTime Mod 60
        TimeCheck.Text = CStr(t1) + "分" + CStr(t2) + "秒"

        If TotalTime = 600 Then
            BtnRData.PerformClick()
            TotalTime = 0
        End If
    End Sub

    Private Sub 工令輸入_KeyDown(sender As Object, e As KeyEventArgs) Handles 工令輸入.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub

    Private Sub BtnClearData_Click(sender As Object, e As EventArgs) Handles BtnClearData.Click
        For Each row As DataGridViewRow In Tab2_DataGridViewR1.SelectedRows
            row.Cells("磅後重").Value = 0
            row.Cells("生料淨重").Value = 0
            row.Cells("磅後淨重").Value = 0
            row.Cells("重量差1").Value = 0
            row.Cells("收料人員").Value = ""
            row.Cells("收料單位").Value = ""
            row.Cells("收料空桶重").Value = 0
        Next

        'For Each row As DataGridViewRow In Tab2_DataGridViewR1.NewRowIndex
        '    Dim T重量 As Integer = 0
        '    Dim T桶數 As Integer = 0
        '    For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '        If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
        '            T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
        '            T桶數 = T桶數 + 1
        '        End If
        '    Next

        '    磅後桶數.Text = T桶數
        '    磅後總重.Text = T重量

        '    桶數差.Text = CInt(裝袋合計.Text) - T桶數
        '    If IsNumeric(進貨重量.Text) Then
        '        重量差.Text = CInt(進貨重量.Text) - T重量
        '    Else
        '        進貨重量.Text = 0
        '        重量差.Text = CInt(進貨重量.Text) - T重量
        '    End If
        'Next

        btnSaveData.PerformClick()
    End Sub
End Class
