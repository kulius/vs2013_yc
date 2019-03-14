Imports FastReport
Imports FastReport.Utils
Public Class S05N0100
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
    Dim TotalTime As Integer
    Dim strMessage As String = "" '訊息字串
    Dim strIRow, strIValue, strUValue, strWValue As String '資料處理參數(新增欄位；新增資料；異動資料；條件)     
    Dim select入料人員 As String = ""
    Dim select入料單位 As String = ""
#End Region
#Region "單用變數"
    Dim strPage As String = "FA" & Mid(Now.Year, 3, 2)
    Dim FRreport As New Report
#End Region

#Region "@Form及功能操作@"
    Private Sub S05N0100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        '寬
        ' BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()

        TabControl.SelectedTab = Me.TabPage1

        '按鍵
        Dim btnItems() As ToolStripButton = {butAddNew, butCopy, butDelete, butFind, butSearch, butPrint, butSave, butCancelEdit}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next
        BCtrl.Visible = False
        BasicPanel.Visible = False

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        'FillData("") '載入資料集
        For i As Integer = 0 To Tab2_DataGridViewR1.Columns.Count - 1
            Tab2_DataGridViewR1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub S05N0100_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S05N0100_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
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
        ComboBox_DGDB(收料單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DGDB(單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DGDB(入料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DGDB(收料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")


        ComboBox_DB(s爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011' and 參數1='Y' ", "一層名稱 ASC")
        ComboBox_DB(操作人員1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(操作人員2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' ) ", "姓名 ASC")
        ComboBox_DB(操作人員3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(組長1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(班別1, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別2, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別3, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S01N0006'", "一層代碼 ASC")

        'ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        'ComboBox_DB(品管人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")

        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        'ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        'ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        'ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        'ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")
        'ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0009'", "一層代碼 ASC")
        'ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        'ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(預排爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        'ComboBox_GG(運費種類, ",含運,自付", ",含運費,自付運費")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")

        ComboBox_DB(r爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        ComboBox_DB(r組長, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
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
        Dim objDataGridViewR() As DataGridView = {}
        Set_Control_RW(MainPanel, butStatus)
        Set_Control_RW(TabControl, butStatus)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                'TabControl.SelectedTab = Me.TabPage1
                'DataGridView.Enabled = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage1
                'DataGridView.Enabled = False
                '製造日期1.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage1
                'DataGridView.Enabled = False
                '製造日期1.Focus()

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage1
                'DataGridView.Enabled = False
                '製造日期1.Focus()
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

        'If blnCheck = False Then Return False : Exit Function
        ''防呆結束*****

        ''開啟儲存*****
        ''客戶主檔
        'strUValue = ""

        'GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)
        ''無法SQL的欄位*****
        'strUValue &= "進爐狀態 = '" & "已進爐" & "',"
        'strUValue &= "狀態 = '" & "3" & "',"
        'strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        'strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        'strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        'blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

        ''先刪
        'dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")
        ''後加
        'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("重量").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("桶數").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

        '    If strRowValue(0) <> "" Then
        '        strIRow = "工令號碼,重量,桶數,備註"
        '        strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "'"
        '        dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
        '    End If
        'Next


        '--異動後初始化--        
        'MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        'ComboBoxList()
        Return blnCheck
    End Function

    '刪除回復成 未進爐狀態
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        strUValue = "進爐狀態 = '" & "" & "',"
        strUValue &= "狀態 = '" & "2" & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
        '--異動後初始化--
        MessageBox.Show("※資料已回復(未進爐狀態)" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

        strSQL99 = "SELECT t1.一層名稱+'X'+isnull(t2.一層名稱,'')+長度說明 AS 規格,* FROM 進貨單主檔 m"
        strSQL99 &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t1 ON m.規格代碼 = t1.一層代碼"
        strSQL99 &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t2 ON m.長度代碼 = t2.一層代碼 "
        strSQL99 &= " WHERE 工令號碼 = '" & strKey1 & "'"

        'strSSQL = "SELECT t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        'strSSQL &= ",客戶簡稱 = case when t1.簡稱<>t7.簡稱 then t7.簡稱+'-'+t1.簡稱 else t1.簡稱 end ,t7.簡稱"
        'strSSQL &= ",t2.一層名稱 AS 品名,t3.一層名稱+'X'+t8.一層名稱+長度說明 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        'strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        'strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            ControlReadData(TabControl, objDR99)
            ControlReadData(MainPanel, objDR99)

            '無法塞值的欄位*****

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標

        PictureBox1.Image = Nothing

        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT 頭部記號 FROM 進貨單頭部記號檔"
        strSQL99 &= " WHERE 工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        Try
            Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
            Dim pictures As Image = Nothing
            Using stream As New System.IO.MemoryStream(pictureData)
                pictures = Image.FromStream(stream)

            End Using
            PictureBox1.Image = pictures
        Catch ex As Exception

        End Try


        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '項目檔
    Sub MasterItem(ByVal strKey1 As String)
        '過磅單項目
        strSSQL = "SELECT m.* FROM 製造單項目檔 AS m"
        strSSQL &= " WHERE m.工令號碼 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY m.序號 ASC"

        DataGridView_HeaderDB(Tab2_DataGridViewR1, DNS, strSSQL)

        If dbCount(DNS, "製造單項目檔", "intCount", "工令號碼 = '" & strKey1 & "'") = 0 Then
            Dim T1 As Integer = CInt(裝袋合計.Text)
            For i1 = 1 To T1 + 5
                Tab2_DataGridViewR1.Rows.Add(New Object() {i1, 0, 0, "", 0, "", 0, 0, "", 0, ""})
            Next
        End If
    End Sub
    '查詢按鈕
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, s爐號.SelectedIndexChanged
        If s爐號.SelectedIndex <> 0 Then
            TotalTime = 0
            Dim svalue1 As String = ""
            Dim svalue2 As String = ""
            If s未進爐工令.SelectedIndex <> 0 Then
                svalue1 = s未進爐工令.SelectedValue
            End If

            If s已進爐工令.SelectedIndex <> 0 Then
                svalue2 = s已進爐工令.SelectedValue
            End If

            ComboBox_DB(s未進爐工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='2' and 序號<>99.9 and 序號 >=1  and 預排爐號='" + s爐號.Text + "'", "序號")
            ComboBox_DB(s已進爐工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and 預排爐號='" + s爐號.Text + "'", "製造日期1")


            Try
                If svalue1 <> "" Then s未進爐工令.SelectedValue = svalue1
                If svalue2 <> "" Then s已進爐工令.SelectedValue = svalue2
            Catch ex As Exception

            End Try

        End If
    End Sub
#End Region
#Region "物件異動選擇項"
 
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        TotalTime = TotalTime + 1
        Dim t1 As Integer = TotalTime \ 60
        Dim t2 As Integer = TotalTime Mod 60
        TimeCheck.Text = CStr(t1) + "分" + CStr(t2) + "秒"

        If TotalTime = 600 Then
            Button1.PerformClick()
            TotalTime = 0
        End If
    End Sub

    Private Sub s未進爐工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s未進爐工令.SelectedIndexChanged
        If s未進爐工令.SelectedIndex <> 0 Then
            s已進爐工令.SelectedIndex = 0

            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s未進爐工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s未進爐工令.SelectedValue + "'"
            End If
            ShowData(s未進爐工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)

            If 製造時間1.Text = "" Then
                班別1.SelectedValue = INI_Read("BASIC", "LOGIN", "FIRM1")
                操作人員1.SelectedValue = INI_Read("BASIC", "LOGIN", "FIRM2")
                組長1.SelectedValue = INI_Read("BASIC", "LOGIN", "FIRM3")
                桶數1.Text = INI_Read("BASIC", "LOGIN", "FIRM4")
            End If
        End If
    End Sub
    Private Sub 桶數1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles 桶數3.KeyPress, 桶數2.KeyPress, 桶數1.KeyPress
        Dim tb As System.Windows.Forms.TextBox = DirectCast(sender, System.Windows.Forms.TextBox)
        e.Handled = True
        '输入0－9和回连键时有效  
        If (e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = "" Then
            e.Handled = False
        End If
        '输入小数点情况  
        If e.KeyChar = "." Then
            '小数点不能在第一位  
            If tb.Text.Length <= 0 Then
                e.Handled = True
            Else
                '小数点不在第一位  
                Dim f As Double
                If Double.TryParse(tb.Text + e.KeyChar, f) Then
                    e.Handled = False
                End If
            End If
        End If
    End Sub

    Private Sub s已進爐工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s已進爐工令.SelectedIndexChanged
        If s已進爐工令.SelectedIndex <> 0 Then
            s未進爐工令.SelectedIndex = 0

            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s已進爐工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s已進爐工令.SelectedValue + "'"
            End If
            ShowData(s已進爐工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)

        End If
    End Sub




#End Region

#Region "儲存"
    Private Sub 製造日期1_Leave(sender As System.Object, e As System.EventArgs) Handles 製造時間3.Leave, 製造時間2.Leave, 製造時間1.Leave, 製造日期3.Leave, 製造日期2.Leave, 製造日期1.Leave, 組長3.Leave, 組長2.Leave, 組長1.Leave, 班別3.Leave, 班別2.Leave, 班別1.Leave, 桶數3.Leave, 桶數2.Leave, 桶數1.Leave, 操作人員3.Leave, 操作人員2.Leave, 操作人員1.Leave, 製造重量3.Leave, 製造重量2.Leave, 製造重量1.Leave, btnSaveData.Click, 完爐時間.Leave, 完爐日期.Leave, Tab2_DataGridViewR1.Leave
        Dim blnCheck As Boolean = False

        If 工令號碼.Text = "" Then
            MsgBox("未選擇工令，無法存檔")
            Exit Sub
        End If
        If 製造時間1.Text <> "" And 班別1.SelectedIndex <> 0 And 操作人員1.SelectedIndex <> 0 And 桶數1.Text <> "" And 組長1.SelectedIndex <> 0 Then
            strUValue = "製造日期1 = '" & strSystemToDate(製造日期1.Value.ToShortDateString) & "',"
            strUValue &= "製造時間1 = '" & 製造時間1.Text & "',"
            strUValue &= "班別1 = '" & 班別1.SelectedValue & "',"
            strUValue &= "操作人員1 = '" & 操作人員1.SelectedValue & "',"
            strUValue &= "組長1 = '" & 組長1.SelectedValue & "',"
            strUValue &= "桶數1= '" & 桶數1.Text & "',"
            strUValue &= "製造重量1= '" & 製造重量1.Text & "',"
            strUValue &= "狀態 = '" & "3" & "',"
            strUValue &= "完爐日期 = '" & strSystemToDate(完爐日期.Value.ToShortDateString) & "',"
            strUValue &= "完爐時間 = '" & 完爐時間.Text & "',"
            strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
            strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
            strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

            blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

            INI_Write("BASIC", "LOGIN", "FIRM1", 班別1.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM2", 操作人員1.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM3", 組長1.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM4", 桶數1.Text)


        End If

        If 製造時間2.Text <> "" And 班別2.SelectedIndex <> 0 And 操作人員2.SelectedIndex <> 0 And 桶數2.Text <> "" And 組長2.SelectedIndex <> 0 Then
            strUValue = "製造日期2 = '" & strSystemToDate(製造日期2.Value.ToShortDateString) & "',"
            strUValue &= "製造時間2 = '" & 製造時間2.Text & "',"
            strUValue &= "班別2 = '" & 班別2.SelectedValue & "',"
            strUValue &= "操作人員2 = '" & 操作人員2.SelectedValue & "',"
            strUValue &= "組長2 = '" & 組長2.SelectedValue & "',"
            strUValue &= "桶數2= '" & 桶數2.Text & "',"
            strUValue &= "製造重量2= '" & 製造重量2.Text & "',"
            strUValue &= "狀態 = '" & "3" & "',"
            strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
            strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
            strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

            blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

            INI_Write("BASIC", "LOGIN", "FIRM1", 班別2.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM2", 操作人員2.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM3", 組長2.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM4", 桶數2.Text)
        End If

        If 製造時間3.Text <> "" And 班別3.SelectedIndex <> 0 And 操作人員3.SelectedIndex <> 0 And 桶數3.Text <> "" And 組長3.SelectedIndex <> 0 Then
            strUValue = "製造日期3 = '" & strSystemToDate(製造日期3.Value.ToShortDateString) & "',"
            strUValue &= "製造時間3 = '" & 製造時間3.Text & "',"
            strUValue &= "班別3 = '" & 班別3.SelectedValue & "',"
            strUValue &= "操作人員3 = '" & 操作人員3.SelectedValue & "',"
            strUValue &= "組長3 = '" & 組長3.SelectedValue & "',"
            strUValue &= "桶數3= '" & 桶數3.Text & "',"
            strUValue &= "製造重量3= '" & 製造重量3.Text & "',"
            strUValue &= "狀態 = '" & "3" & "',"
            strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
            strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
            strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

            blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

            INI_Write("BASIC", "LOGIN", "FIRM1", 班別3.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM2", 操作人員3.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM3", 組長3.SelectedValue)
            INI_Write("BASIC", "LOGIN", "FIRM4", 桶數3.Text)
        End If


        '先刪
        dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")

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
                                           Tab2_DataGridViewR1.Rows(I).Cells("重量差").Value,
                                            Tab2_DataGridViewR1.Rows(I).Cells("備註").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料單位").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料空桶重").Value}

            If strRowValue(0) <> "" Then
                strIRow = "工令號碼,桶號,空桶重,單位,生料重,生料淨重,入料人員,磅後重,磅後淨重,收料人員,重量差,備註,收料單位,收料空桶重"
                strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "','" & strRowValue(11) & "','" & strRowValue(12) & "'"
                blnCheck = dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
            End If
        Next

    End Sub
    '將製程資料清空、並且將工令返回
    Private Sub btnDelData_Click(sender As System.Object, e As System.EventArgs) Handles btnDelData.Click
        Dim blnCheck As Boolean = False
        製造時間1.Text = ""
        班別1.SelectedIndex = 0
        操作人員1.SelectedIndex = 0
        桶數1.Text = ""
        製造重量1.Text = ""
        組長1.SelectedIndex = 0
        製造時間2.Text = ""
        班別2.SelectedIndex = 0
        操作人員2.SelectedIndex = 0
        桶數2.Text = ""
        製造重量2.Text = ""
        組長2.SelectedIndex = 0
        製造時間3.Text = ""
        班別3.SelectedIndex = 0
        操作人員3.SelectedIndex = 0
        桶數3.Text = ""
        製造重量3.Text = ""
        組長3.SelectedIndex = 0

        strUValue = "製造日期1 = '" & "" & "',"
        strUValue &= "製造時間1 = '" & 製造時間1.Text & "',"
        strUValue &= "班別1 = '" & 班別1.SelectedValue & "',"
        strUValue &= "操作人員1 = '" & 操作人員1.SelectedValue & "',"
        strUValue &= "組長1 = '" & 組長1.SelectedValue & "',"
        strUValue &= "桶數1= '" & 桶數1.Text & "',"
        strUValue &= "製造重量1= '" & 製造重量1.Text & "',"
        strUValue &= "製造日期2 = '" & "" & "',"
        strUValue &= "製造時間2 = '" & 製造時間2.Text & "',"
        strUValue &= "班別2 = '" & 班別2.SelectedValue & "',"
        strUValue &= "操作人員2 = '" & 操作人員2.SelectedValue & "',"
        strUValue &= "組長2 = '" & 組長2.SelectedValue & "',"
        strUValue &= "桶數2= '" & 桶數2.Text & "',"
        strUValue &= "製造重量2= '" & 製造重量1.Text & "',"
        strUValue &= "製造日期3 = '" & "" & "',"
        strUValue &= "製造時間3 = '" & 製造時間3.Text & "',"
        strUValue &= "班別3 = '" & 班別3.SelectedValue & "',"
        strUValue &= "操作人員3 = '" & 操作人員3.SelectedValue & "',"
        strUValue &= "組長3 = '" & 組長3.SelectedValue & "',"
        strUValue &= "桶數3= '" & 桶數3.Text & "',"
        strUValue &= "製造重量3= '" & 製造重量1.Text & "',"
        strUValue &= "狀態 = '" & "2" & "',"
        strUValue &= "過磅狀態 = '" & "" & "',"
        strUValue &= "檢驗狀態 = '" & "" & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

    End Sub

    Private Sub Tab2_btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles Tab2_btnAdd.Click
        Tab2_DataGridViewR1.Rows.Add(New Object() {Tab2_DataGridViewR1.RowCount + 1, 0, 0, "", 0, "", 0, 0, "", 0, ""})
    End Sub

    Private Sub Tab2_btnDec_Click(sender As System.Object, e As System.EventArgs) Handles Tab2_btnDec.Click
        For Each r As DataGridViewRow In Tab2_DataGridViewR1.SelectedRows
            If Not r.IsNewRow Then
                Tab2_DataGridViewR1.Rows.Remove(r)
            End If
        Next
    End Sub

    Private Sub Tab2_DataGridViewR1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tab2_DataGridViewR1.CellEndEdit
        Try
            Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料淨重").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("空桶重").Value
            Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後淨重").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("空桶重").Value
            Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("重量差").Value = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("生料淨重").Value - Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("磅後淨重").Value

            If Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("入料人員").Value = "" Then
                Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("入料人員").Value = select入料人員
            Else
                select入料人員 = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("入料人員").Value
            End If

            If Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("單位").Value = "" Then
                Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("單位").Value = select入料單位
            Else
                select入料單位 = Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("單位").Value
            End If


            Dim T重量 As Integer = 0
            Dim T桶數 As Integer = 0
            If 操作人員1.SelectedValue <> "" Then
                ' MsgBox("操作人員1" + 操作人員1.SelectedValue)
                '  MsgBox("入料人員" + Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value)
                T重量 = 0
                T桶數 = 0
                For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
                    If Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value = 操作人員1.SelectedValue Then
                        T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value
                        T桶數 = T桶數 + 1
                    End If
                Next
                桶數1.Text = T桶數
                製造重量1.Text = T重量
            End If

            If 操作人員2.SelectedValue <> "" Then
                T重量 = 0
                T桶數 = 0
                For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
                    If Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value = 操作人員2.SelectedValue Then
                        T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value
                        T桶數 = T桶數 + 1
                    End If
                Next
                桶數2.Text = T桶數
                製造重量2.Text = T重量
            End If

            If 操作人員3.SelectedValue <> "" Then
                T重量 = 0
                T桶數 = 0
                For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
                    If Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value = 操作人員3.SelectedValue Then
                        T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value
                        T桶數 = T桶數 + 1
                    End If
                Next
                桶數3.Text = T桶數
                製造重量3.Text = T重量
            End If
        Catch ex As Exception

        End Try


        'Dim T重量 As Integer = 0
        'Dim T桶數 As Integer = 0
        'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    If Tab2_DataGridViewR1.Rows(I).Cells("重量").Value <> 0 Then
        '        T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("重量").Value
        '        T桶數 = T桶數 + 1
        '    End If
        'Next

        '磅後桶數.Text = T桶數
        '磅後總重.Text = T重量

        '桶數差.Text = CInt(裝袋合計.Text) - T桶數
        'If IsNumeric(進貨重量.Text) Then
        '    重量差.Text = CInt(進貨重量.Text) - T重量
        'Else
        '    進貨重量.Text = 0
        '    重量差.Text = CInt(進貨重量.Text) - T重量
        'End If
    End Sub

#End Region

#Region "報表"
    Private Sub r班別_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles r班別.SelectedIndexChanged
        If r班別.SelectedIndex = 0 Then
            r班別時間.Text = "08:00~15:59"
        ElseIf r班別.SelectedIndex = 1 Then
            r班別時間.Text = "16:00~23:59"
        ElseIf r班別.SelectedIndex = 2 Then
            r班別時間.Text = "00:00~07:59"
        ElseIf r班別.SelectedIndex = 3 Then
            r班別時間.Text = "08:00~19:59"
        ElseIf r班別.SelectedIndex = 4 Then
            r班別時間.Text = "20:00~07:59(有跨日)"
        End If

    End Sub



    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "熱處理工程記錄表.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", r爐號.SelectedValue)
        FRreport.SetParameterValue("RepKey1", r組長.SelectedValue)
        FRreport.SetParameterValue("RepKey2", strSystemToDate(r製造日期.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey3", r班別.Text)
        FRreport.SetParameterValue("RepKey4", r班別時間.Text)
        FRreport.SetParameterValue("RepKey5", r組長.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub


    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        FRreport.Load(ReportDir + "熱處理工程記錄表.frx")
        FRreport.Design()
    End Sub
#End Region





    Private Sub 工令輸入_Leave(sender As System.Object, e As System.EventArgs) Handles 工令輸入.Leave
        If 工令輸入.Text <> "" Then
            's未進爐工令.SelectedIndex = -1
            's已進爐工令.SelectedIndex = -1
            If dbCount(DNS, "進貨單主檔", "intCount", "工令號碼 = '" & 工令輸入.Text & "'") > 0 Then
                ShowData(工令輸入.Text)
                butEdit.PerformClick()
                SetControls(2)
            Else
                MsgBox("無此工令號碼")
            End If

        End If
    End Sub

    Private Sub 製造時間1_Enter(sender As Object, e As EventArgs) Handles 製造時間1.Enter
        If 製造時間1.Text = "" Then
            製造時間1.Text = NowTime().Substring(0, 5)
        End If
    End Sub

    Private Sub 製造時間2_Enter(sender As Object, e As EventArgs) Handles 製造時間2.Enter
        If 製造時間2.Text = "" Then
            製造時間2.Text = NowTime().Substring(0, 5)
        End If
    End Sub

    Private Sub 製造時間3_Enter(sender As Object, e As EventArgs) Handles 製造時間3.Enter
        If 製造時間3.Text = "" Then
            製造時間3.Text = NowTime().Substring(0, 5)
        End If
    End Sub


    Private Sub 工令輸入_KeyDown(sender As Object, e As KeyEventArgs) Handles 工令輸入.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub
End Class
