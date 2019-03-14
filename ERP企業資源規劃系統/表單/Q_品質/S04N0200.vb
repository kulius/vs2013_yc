Imports System.IO
Imports System.Drawing.Imaging
Public Class S04N0200
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
    Dim FileAddrValue As String = INI_Read("CONFIG", "SET", "MachineFile") 'DNS設定值
#End Region

#Region "@Form及功能操作@"
    Private Sub S04N0200_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        BCtrl.Visible = False
        BasicPanel.Visible = False
        BaseStatusStrip.Visible = False

        Me.Height = 670

        FileAddr.Text = FileAddrValue

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        txtAutoComplete()
        'DataGridView_Basic() 'DataGridView初始化
        'FillData("") '載入資料集
    End Sub
    Private Sub S04N0200_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S04N0200_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
        If e.KeyCode = Keys.Down Then SendKeys.Send("{tab}")
        If e.KeyCode = Keys.Up Then SendKeys.Send("+{TAB}")
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
    '自動完成
    Public Sub txtAutoComplete()
        'Dim namesCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection
        ''開啟查詢
        'objCon99 = New SqlConnection(DNS)
        'objCon99.Open()

        'strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        'strSQL99 &= " WHERE 類別 = 'S04N0004'"

        'objCmd99 = New SqlCommand(strSQL99, objCon99)
        'objDR99 = objCmd99.ExecuteReader

        'If objDR99.HasRows Then
        '    While objDR99.Read
        '        namesCollection.Add(objDR99("一層代碼").ToString)
        '    End While
        'End If

        'objDR99.Close()

        '品管備註.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '品管備註.AutoCompleteSource = AutoCompleteSource.CustomSource
        '品管備註.AutoCompleteCustomSource = namesCollection

    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態>'3' and isnull(檢驗狀態,'')<>'' ", "工令號碼")
        ComboBox_DB(s爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        'ComboBox_DB(s未檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') = ''", "工令號碼")
        'ComboBox_DB(s已檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') <> ''", "工令號碼")
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') <> '' and 狀態='已出貨'", "工令號碼")

        ComboBox_DB(表面硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(心部硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(華司硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        '  ComboBox_DB(滲碳層規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(檢驗人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='05' or 職稱代碼2='05' or 職稱代碼3='05' )", "姓名 ASC")

        ComboBox_DB(金相審核人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='05' or 職稱代碼2='05' or 職稱代碼3='05' )", "姓名 ASC")
        ComboBox_DB(金相檢驗人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='05' or 職稱代碼2='05' or 職稱代碼3='05' )", "姓名 ASC")

        ComboBox_DB(操作人員1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(操作人員2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' ) ", "姓名 ASC")
        ComboBox_DB(操作人員3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(組長1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(班別1, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別2, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別3, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")



        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        'ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        'ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        'ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")
        'ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0009'", "一層代碼 ASC")
        'ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        'ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")

        ComboBox_GG(金相結果判定, ",合格,不合格,待處理", ",合格,不合格,待處理")
        ComboBox_GG(滲碳層規格, ",HV0.3,HV0.5,HV1.0,HRC", ",HV0.3,HV0.5,HV1.0,HRC")



        ComboBox_DB(品管備註, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S04N0004'", "一層名稱 ASC")

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
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        'Dim blnCheck As Boolean = False '是否有查詢到資料
        'Dim arrRowName() As String

        ''查詢語法
        'strSSQL = "SELECT m.*,t1.公司名稱 AS 客戶,t2.一層名稱 AS 品名,t3.一層名稱 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        'strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        'strSSQL &= " WHERE 1=1"
        'strSSQL &= strSearch
        'strSSQL &= " ORDER BY 工令號碼 DESC"

        ''顯示欄位
        'arrRowName = {"工令號碼", "客戶", "日期", "品名", "規格", "材質", "表面", "回火溫度", "表面硬度", "心部硬度", "線材爐號", "狀態"}
        ''"客戶", "工令號碼", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"
        ''開啟產生DataGridView
        'blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        ''異動後初始化*****
        'SetControls(0)
        'FlagMoveSeat(0)
        'If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {}

        Set_Control_RW(MainPanel, butStatus)
        Set_Control_RW(TabControl, butStatus)
        國際標準.ReadOnly = True
        表面硬度值.ReadOnly = True
        心部硬度值.ReadOnly = True
        抗拉強度值.ReadOnly = True
        降伏強度值.ReadOnly = True
        伸長率值.ReadOnly = True
        '扭力強度值.ReadOnly = True
        滲碳層1值.ReadOnly = True
        斷面收縮率值.ReadOnly = True
        安全負荷值.ReadOnly = True
        降伏點值起迄.ReadOnly = True
        最大負荷值起迄.ReadOnly = True
        斷面積值起迄.ReadOnly = True



        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()
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

        'strUValue = ""

        'GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)

        ''IIf(試片1.Checked = True, "Y", "N")

        ''無法SQL的欄位*****
        'strUValue &= "拉力機編號 = '" & IIf(拉力機編號1.Checked = True, "50T", "100T") & "',"
        'strUValue &= "外觀判定 = '" & IIf(外觀判定1.Checked = True, "合格", "不合格") & "',"
        'If 整體判定1.Checked = True Then
        '    strUValue &= "整體判定 = '" & "合格" & "',"
        '    strUValue &= "檢驗狀態 = '" & "檢驗合格" & "',"
        'ElseIf 整體判定2.Checked = True Then
        '    strUValue &= "整體判定 = '" & "不合格" & "',"
        '    strUValue &= "檢驗狀態 = '" & "檢驗不合格" & "',"
        'Else
        '    strUValue &= "整體判定 = '" & "待處理" & "',"
        'End If


        'strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        'strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        'strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        'blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)



        ''--異動後初始化--        
        'MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function

    ''刪除
    'Public Overrides Sub DeleteData()
    '    Dim blnCheck As Boolean = False

    '    '--開啟異動--
    '    blnCheck = dbDelete(DNS, "進貨單主檔", "工令號碼 = '" & 工令號碼.Text & "'")

    '    '--異動後初始化--
    '    MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    FillData("")
    'End Sub

    'Form關閉前，把狀態變為0，以防止出現緊告視窗
    Public Overrides Sub BeforeFormClose()
        MyTableStatus = 0
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Machine(strKey1) '產品機械性質主檔    
        Set_Control_ZERO(TabPage6)
        Set_Control_ZERO(TabPage5)
    End Sub
    '主檔
    Sub Machine(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT "
        strSQL99 &= " m.* FROM 進貨單主檔 m "
        strSQL99 &= " WHERE m.工令號碼 = '" & strKey1 & "'"

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
            ControlReadData(TabControl, objDR99)

            '無法塞值的欄位*****
            拉力機編號1.Checked = IIf(objDR99("拉力機編號").ToString = "50T", True, False)
            拉力機編號2.Checked = IIf(objDR99("拉力機編號").ToString = "100T", True, False)

            整體判定1.Checked = IIf(objDR99("整體判定").ToString = "合格", True, False)
            整體判定2.Checked = IIf(objDR99("整體判定").ToString = "不合格", True, False)
            整體判定3.Checked = IIf(objDR99("整體判定").ToString = "待處理", True, False)

            外觀判定1.Checked = IIf(objDR99("外觀判定").ToString = "合格", True, False)
            外觀判定2.Checked = IIf(objDR99("外觀判定").ToString = "不合格", True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標


        '   If 國際標準.Text = "" Then
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT t1.表面硬度 as 表面硬度值,t1.表面規格 as 表面硬度規格,t1.心部硬度 as 心部硬度值,t1.心部規格 as 心部硬度規格"
        strSQL99 &= " ,t1.抗拉強度 as 抗拉強度值,t1.降伏點強度 as 降伏強度值,t1.伸長率 as 伸長率值,t1.滲碳層 as 滲碳層1值 "
        strSQL99 &= " ,t1.斷面收縮 as 斷面收縮率值,t1.安全負荷 as 安全負荷值"
        'strSQL99 &= " ,t1. as 降伏點值起迄,t1. as 最大負荷值起迄,t1. as 斷面積值起迄 "
        strSQL99 &= " ,m.扭力 as 扭力強度值,m.依據標準 as 國際標準 "
        strSQL99 &= "  FROM 進貨單主檔 m "
        strSQL99 &= " LEFT JOIN 產品機械性質主檔 AS t1 ON m.依據標準 = t1.依據標準"
        strSQL99 &= " WHERE m.工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            If objDR99("國際標準").ToString <> 國際標準.Text Then
                ControlReadData(TabControl, objDR99)
            End If
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
        '    End If

        If CK抗拉強度.Checked = False And CK表面硬度.Checked = False And CK心部硬度.Checked = False And CK滲碳層.Checked = False And CK最大負荷.Checked = False Then
            If CK抗拉強度值.Checked = False And CK表面硬度值.Checked = False And CK心部硬度值.Checked = False And CK降伏強度值.Checked = False And CK降伏點值起迄.Checked = False And CK最大負荷值起迄.Checked = False And CK斷面積值起迄.Checked = False Then
                CK抗拉強度值.Checked = True
                CK表面硬度值.Checked = True
                CK心部硬度值.Checked = True
                CK降伏強度值.Checked = True
                CK降伏點值起迄.Checked = True
                CK最大負荷值起迄.Checked = True
                CK斷面積值起迄.Checked = True
            End If
        End If


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

        Button1.PerformClick()
    End Sub
#End Region


    Private Sub s爐號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s爐號.SelectedIndexChanged
        ComboBox_DB(s未檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(檢驗狀態,'')='' and 預排爐號='" + s爐號.Text + "'", "序號")
        ComboBox_DB(s已檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(檢驗狀態,'')<>'' and 預排爐號='" + s爐號.Text + "'", "製造日期1")
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態>'3' and isnull(檢驗狀態,'')<>'' ", "工令號碼")
    End Sub

    Private Sub s未檢驗工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s未檢驗工令.SelectedIndexChanged
        If s未檢驗工令.SelectedIndex <> 0 Then
            s已檢驗工令.SelectedIndex = 0
            's歷史資料.SelectedIndex = 0
            工令輸入.Text = ""
            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s未檢驗工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s未檢驗工令.SelectedValue + "'"
            End If
            ShowData(s未檢驗工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)
        End If
    End Sub

    Private Sub s已檢驗工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s已檢驗工令.SelectedIndexChanged
        If s已檢驗工令.SelectedIndex <> 0 Then
            s未檢驗工令.SelectedIndex = 0
            's歷史資料.SelectedIndex = 0
            工令輸入.Text = ""
            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s已檢驗工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s已檢驗工令.SelectedValue + "'"
            End If
            ShowData(s已檢驗工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)
        End If
    End Sub

    Private Sub 整體判定1_Leave(sender As System.Object, e As System.EventArgs) Handles 檢驗人員.Leave, 整體判定3.Leave, 整體判定2.Leave, 整體判定1.Leave, 外觀判定2.Leave, 外觀判定1.Leave, Button1.Click
        Dim blnCheck As Boolean = False

        '   If 檢驗人員.SelectedIndex <> 0 Then
        strUValue = ""
        GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)
        GetCtrlUpdateSql(MainPanel, "BCtrl", strUValue)
        '無法SQL的欄位*****

        If 拉力機編號1.Checked = True Then
            strUValue &= "拉力機編號 = '" & "50T" & "',"
        ElseIf 拉力機編號2.Checked = True Then
            strUValue &= "拉力機編號 = '" & "100T" & "',"
        Else
            strUValue &= "拉力機編號 = '',"
        End If

        'strUValue &= "外觀判定 = '" & IIf(外觀判定1.Checked = True, "合格", "不合格") & "',"
        If 外觀判定1.Checked = True Then
            strUValue &= "外觀判定 = '" & "合格" & "',"
        ElseIf 外觀判定2.Checked = True Then
            strUValue &= "外觀判定 = '" & "不合格" & "',"
        End If

        If 整體判定1.Checked = True Then
            strUValue &= "整體判定 = '" & "合格" & "',"
        ElseIf 整體判定2.Checked = True Then
            strUValue &= "整體判定 = '" & "不合格" & "',"
        ElseIf 整體判定3.Checked = True Then
            strUValue &= "整體判定 = '" & "待處理" & "',"
            strUValue &= "檢驗狀態 = '" & "待處理" & "',"
        End If

        If (整體判定2.Checked = True) Or (外觀判定2.Checked = True) Then
            strUValue &= "檢驗狀態 = '" & "檢驗不合格" & "',"
        End If
        If (整體判定1.Checked = True) And (外觀判定1.Checked = True) Then
            strUValue &= "檢驗狀態 = '" & "檢驗合格" & "',"
        End If
        'strUValue &= "狀態 = '" & "4" & "',"
        'strUValue &= "檢驗狀態 = '" & "已檢驗" & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"
        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

        '--異動後初始化--        
        'MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '  End If
    End Sub

    Public Shared Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function

    Private Sub s歷史資料_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub CK抗拉強度_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CK表面硬度.CheckedChanged, CK滲碳層.CheckedChanged, CK抗拉強度.CheckedChanged, CK心部硬度.CheckedChanged, CK最大負荷.CheckedChanged, CK扭力強度.CheckedChanged
        If CK抗拉強度.Checked Then CK抗拉強度值.Checked = False
        If CK表面硬度.Checked Then CK表面硬度值.Checked = False
        If CK心部硬度.Checked Then CK心部硬度值.Checked = False
        If CK滲碳層.Checked Then CK滲碳層值.Checked = False
        If CK最大負荷.Checked Then CK最大負荷值起迄.Checked = False
        If CK扭力強度.Checked Then CK扭力強度值.Checked = False
    End Sub

    Private Sub CK表面硬度值_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CK表面硬度值.CheckedChanged, CK滲碳層1值.CheckedChanged, CK抗拉強度值.CheckedChanged, CK心部硬度值.CheckedChanged, CK滲碳層值.CheckedChanged, CK最大負荷值起迄.CheckedChanged, CK扭力強度值.CheckStateChanged
        If CK抗拉強度值.Checked Then CK抗拉強度.Checked = False
        If CK表面硬度值.Checked Then CK表面硬度.Checked = False
        If CK心部硬度值.Checked Then CK心部硬度.Checked = False
        If CK滲碳層值.Checked Then CK滲碳層.Checked = False
        If CK最大負荷值起迄.Checked Then CK最大負荷.Checked = False
        If CK扭力強度值.Checked Then CK扭力強度.Checked = False
    End Sub

    Private Sub HV1_TextChanged(sender As System.Object, e As System.EventArgs) Handles HV3.TextChanged, HV2.TextChanged, HV1.TextChanged
        Dim A1, A2, A3 As Integer

        Try
            If IsNumeric(HV1.Text) Then
                A1 = CInt(HV1.Text)
            Else
                A1 = 0
            End If

            If IsNumeric(HV2.Text) Then
                A2 = CInt(HV2.Text)
            Else
                A2 = 0
            End If

            If IsNumeric(HV3.Text) Then
                A3 = CInt(HV3.Text)
            Else
                A3 = 0
            End If

            HV12.Text = (A1 - A2).ToString

            If A1 - A2 <= 30 Then HV12OK.Text = "OK" Else HV12OK.Text = "NG"

            HV13.Text = (A1 - A3).ToString

            If A1 - A3 >= -30 Then HV13OK.Text = "OK" Else HV13OK.Text = "NG"
        Catch ex As Exception

        End Try



    End Sub

    Private Sub 拉力資料_Click(sender As System.Object, e As System.EventArgs) Handles 拉力資料.Click
        TabControl.SelectedTab = Me.TabPage5
        Dim filePath1 As String = FileAddrValue + "\" + 工令號碼.Text + ".50T"
        Dim filePath2 As String = FileAddrValue + "\" + 工令號碼.Text + ".100"

        If My.Computer.FileSystem.FileExists(filePath1) Then
            拉力機編號1.Checked = True
            拉力機編號2.Checked = False
            讀取拉力資料(filePath1)
        ElseIf My.Computer.FileSystem.FileExists(filePath2) Then
            拉力機編號1.Checked = False
            拉力機編號2.Checked = True
            讀取拉力資料(filePath2)
        Else
            拉力機編號1.Checked = False
            拉力機編號2.Checked = False
            With OpenFileDialog1
                .InitialDirectory = FileAddrValue
                .RestoreDirectory = True
                .FileName = 工令號碼.Text
            End With

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                FileAddr.Text = OpenFileDialog1.FileName
                讀取拉力資料(OpenFileDialog1.FileName)
            End If

        End If


    End Sub

    Private Sub 讀取拉力資料(file As String)
        Dim szAllFileData As String
        Dim arr() As String
        szAllFileData = My.Computer.FileSystem.ReadAllText(file)
        RichTextBox1.Clear()
        Set_Control_SPACE(TabPage5)
        arr = szAllFileData.Split(" ".ToCharArray())
        Dim i As Object
        For Each i In arr
            RichTextBox1.Text += i + " "
        Next i

        Dim SW As New StreamReader(file)
        Dim temp As String
        Dim temp拉力機資料() As String
        Dim 拉力機資料(10) As String
        Dim QQ As Integer
        While True
            temp = SW.ReadLine ' 一次讀取一行
            If Trim(temp) <> "" Then
                temp拉力機資料 = temp.Split(" ".ToCharArray())
                QQ = 0
                For j As Integer = 0 To temp拉力機資料.Length - 1
                    If Trim(temp拉力機資料(j)) <> "" Then
                        拉力機資料(QQ) = Trim(temp拉力機資料(j))
                        QQ = QQ + 1
                    End If
                Next

                For Q As Integer = 0 To 拉力機資料.Length - 1
                    If 拉力機資料(Q) = "1" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值1.Text = 拉力機資料(Q + 2)
                        抗拉強度值1.Text = 拉力機資料(Q + 3)
                        降伏點值1.Text = 拉力機資料(Q + 4)
                        降伏強度值1.Text = 拉力機資料(Q + 5)
                        伸長率值1.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "2" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值2.Text = 拉力機資料(Q + 2)
                        抗拉強度值2.Text = 拉力機資料(Q + 3)
                        降伏點值2.Text = 拉力機資料(Q + 4)
                        降伏強度值2.Text = 拉力機資料(Q + 5)
                        伸長率值2.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "3" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值3.Text = 拉力機資料(Q + 2)
                        抗拉強度值3.Text = 拉力機資料(Q + 3)
                        降伏點值3.Text = 拉力機資料(Q + 4)
                        降伏強度值3.Text = 拉力機資料(Q + 5)
                        伸長率值3.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "4" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值4.Text = 拉力機資料(Q + 2)
                        抗拉強度值4.Text = 拉力機資料(Q + 3)
                        降伏點值4.Text = 拉力機資料(Q + 4)
                        降伏強度值4.Text = 拉力機資料(Q + 5)
                        伸長率值4.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "5" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值5.Text = 拉力機資料(Q + 2)
                        抗拉強度值5.Text = 拉力機資料(Q + 3)
                        降伏點值5.Text = 拉力機資料(Q + 4)
                        降伏強度值5.Text = 拉力機資料(Q + 5)
                        伸長率值5.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "6" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值6.Text = 拉力機資料(Q + 2)
                        抗拉強度值6.Text = 拉力機資料(Q + 3)
                        降伏點值6.Text = 拉力機資料(Q + 4)
                        降伏強度值6.Text = 拉力機資料(Q + 5)
                        伸長率值6.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "7" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值7.Text = 拉力機資料(Q + 2)
                        抗拉強度值7.Text = 拉力機資料(Q + 3)
                        降伏點值7.Text = 拉力機資料(Q + 4)
                        降伏強度值7.Text = 拉力機資料(Q + 5)
                        伸長率值7.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If

                    If 拉力機資料(Q) = "8" Then
                        斷面積.Text = 拉力機資料(Q + 1)
                        最大負荷值8.Text = 拉力機資料(Q + 2)
                        抗拉強度值8.Text = 拉力機資料(Q + 3)
                        降伏點值8.Text = 拉力機資料(Q + 4)
                        降伏強度值8.Text = 拉力機資料(Q + 5)
                        伸長率值8.Text = 拉力機資料(Q + 6)
                        Exit For
                    End If
                Next
            End If


            If temp Is Nothing Then Exit While '讀取不到就結束

        End While
        斷面積值起迄.Text = 斷面積.Text

        Dim MaxValue As Double = 0
        Dim MinValue As Double = 0

        Dim arrValue() As String = {抗拉強度值1.Text, 抗拉強度值2.Text, 抗拉強度值3.Text, 抗拉強度值4.Text, 抗拉強度值5.Text, 抗拉強度值6.Text, 抗拉強度值7.Text, 抗拉強度值8.Text}
        抗拉強度值起迄.Text = GetMinArr(arrValue) + GetMaxArr(arrValue)

        Dim arrValue1() As String = {降伏強度值1.Text, 降伏強度值2.Text, 降伏強度值3.Text, 降伏強度值4.Text, 降伏強度值5.Text, 降伏強度值6.Text, 降伏強度值7.Text, 降伏強度值8.Text}
        降伏強度值起迄.Text = GetMinArr(arrValue1) + GetMaxArr(arrValue1)

        Dim arrValue2() As String = {伸長率值1.Text, 伸長率值2.Text, 伸長率值3.Text, 伸長率值4.Text, 伸長率值5.Text, 伸長率值6.Text, 伸長率值7.Text, 伸長率值8.Text}
        伸長率值起迄.Text = GetMinArr(arrValue2) + GetMaxArr(arrValue2)

        Dim arrValue3() As String = {Val(降伏強度值1.Text) * 斷面積.Text, Val(降伏強度值2.Text) * 斷面積.Text, Val(降伏強度值3.Text) * 斷面積.Text, Val(降伏強度值4.Text) * 斷面積.Text, Val(降伏強度值5.Text) * 斷面積.Text, Val(降伏強度值6.Text) * 斷面積.Text, Val(降伏強度值7.Text) * 斷面積.Text, Val(降伏強度值8.Text) * 斷面積.Text}
        降伏點值起迄.Text = GetMinArr(arrValue3) + GetMaxArr(arrValue3)

        Dim arrValue4() As String = {最大負荷值1.Text, 最大負荷值2.Text, 最大負荷值3.Text, 最大負荷值4.Text, 最大負荷值5.Text, 最大負荷值6.Text, 最大負荷值7.Text, 最大負荷值8.Text}
        最大負荷值起迄.Text = GetMinArr(arrValue4) + GetMaxArr(arrValue4)



        strUValue = ""
        GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)
        GetCtrlUpdateSql(MainPanel, "BCtrl", strUValue)
        '無法SQL的欄位*****
        strUValue &= "拉力機編號 = '" & IIf(拉力機編號1.Checked = True, "50T", "100T") & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"
        dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

    End Sub

    Private Function GetMinArr(arr() As String) As String
        Array.Sort(arr)
        For J As Integer = 0 To arr.Length - 1 Step 1
            If arr(J) <> "0" And arr(J) <> "" Then
                Return arr(J) + "~"
                Exit Function
            End If
        Next
        Return ""
    End Function

    Private Function GetMaxArr(arr() As String) As String
        Array.Reverse(arr)
        For J As Integer = 0 To arr.Length - 1 Step 1
            If arr(J) <> "0" And arr(J) <> "" Then
                Return arr(J)
                Exit Function
            End If
        Next
        Return ""
    End Function




    Private Sub 檢驗報告_Click(sender As System.Object, e As System.EventArgs) Handles 檢驗報告.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "客戶加工單-樣品識別單.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 套表列印_Click(sender As System.Object, e As System.EventArgs) Handles 套表列印.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "檢驗報告書.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 不合格處理單_Click(sender As System.Object, e As System.EventArgs) Handles 不合格處理單.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "不合格品處理單.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 完爐時間_Enter(sender As System.Object, e As System.EventArgs) Handles 完爐時間.Enter
        Dim tb As System.Windows.Forms.TextBox = DirectCast(sender, System.Windows.Forms.TextBox)
        If tb.Text = "" Then
            tb.Text = NowTime()
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As System.Object, e As System.EventArgs) Handles 工令輸入.Leave
        If 工令輸入.Text <> "" Then
            's未檢驗工令.SelectedIndex = -1
            's已檢驗工令.SelectedIndex = -1


            If dbCount(DNS, "進貨單主檔", "intCount", "工令號碼 = '" & 工令輸入.Text & "'") > 0 Then
                ShowData(工令輸入.Text)
                butEdit.PerformClick()
                SetControls(2)
            Else
                MsgBox("無此工令號碼")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim MaxValue As Double = 0
        Dim MinValue As Double = 0

        Dim arrValue() As String = {抗拉強度值1.Text, 抗拉強度值2.Text, 抗拉強度值3.Text, 抗拉強度值4.Text, 抗拉強度值5.Text, 抗拉強度值6.Text, 抗拉強度值7.Text, 抗拉強度值8.Text}
        抗拉強度值起迄.Text = GetMinArr(arrValue) + GetMaxArr(arrValue)

        Dim arrValue1() As String = {降伏強度值1.Text, 降伏強度值2.Text, 降伏強度值3.Text, 降伏強度值4.Text, 降伏強度值5.Text, 降伏強度值6.Text, 降伏強度值7.Text, 降伏強度值8.Text}
        降伏強度值起迄.Text = GetMinArr(arrValue1) + GetMaxArr(arrValue1)

        Dim arrValue2() As String = {伸長率值1.Text, 伸長率值2.Text, 伸長率值3.Text, 伸長率值4.Text, 伸長率值5.Text, 伸長率值6.Text, 伸長率值7.Text, 伸長率值8.Text}
        伸長率值起迄.Text = GetMinArr(arrValue2) + GetMaxArr(arrValue2)

        Dim arrValue3() As String = {Val(降伏強度值1.Text) * 斷面積.Text, Val(降伏強度值2.Text) * 斷面積.Text, Val(降伏強度值3.Text) * 斷面積.Text, Val(降伏強度值4.Text) * 斷面積.Text, Val(降伏強度值5.Text) * 斷面積.Text, Val(降伏強度值6.Text) * 斷面積.Text, Val(降伏強度值7.Text) * 斷面積.Text, Val(降伏強度值8.Text) * 斷面積.Text}
        降伏點值起迄.Text = GetMinArr(arrValue3) + GetMaxArr(arrValue3)

        Dim arrValue4() As String = {最大負荷值1.Text, 最大負荷值2.Text, 最大負荷值3.Text, 最大負荷值4.Text, 最大負荷值5.Text, 最大負荷值6.Text, 最大負荷值7.Text, 最大負荷值8.Text}
        最大負荷值起迄.Text = GetMinArr(arrValue4) + GetMaxArr(arrValue4)
    End Sub

    Private Sub BtnRData_Click(sender As Object, e As EventArgs) Handles BtnRData.Click
        If s爐號.SelectedIndex <> 0 Then
            TotalTime = 0
            Dim svalue1 As String = ""
            Dim svalue2 As String = ""
            If s未檢驗工令.SelectedIndex <> 0 Then
                svalue1 = s未檢驗工令.SelectedValue
            End If

            If s已檢驗工令.SelectedIndex <> 0 Then
                svalue2 = s已檢驗工令.SelectedValue
            End If

            ComboBox_DB(s未檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(檢驗狀態,'')='' and 預排爐號='" + s爐號.Text + "'", "序號")
            ComboBox_DB(s已檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態='3' and isnull(檢驗狀態,'')<>'' and 預排爐號='" + s爐號.Text + "'", "製造日期1")


            Try
                If svalue1 <> "" Then s未檢驗工令.SelectedValue = svalue1
                If svalue2 <> "" Then s已檢驗工令.SelectedValue = svalue2
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        拉力機編號1.Checked = False
        拉力機編號2.Checked = False
    End Sub

    Private Sub 工令輸入_KeyDown(sender As Object, e As KeyEventArgs) Handles 工令輸入.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub


    Private Sub 熱處理成品檢查記錄表_Click(sender As Object, e As EventArgs) Handles 熱處理成品檢查記錄表.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "熱處理成品檢查記錄表.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub


    Private Sub 金相1圖_Click(sender As Object, e As EventArgs) Handles 金相1圖.Click, 金相6圖.Click, 金相5圖.Click, 金相4圖.Click, 金相3圖.Click, 金相2圖.Click
        With OpenFileDialog2
            ' Dim FileAddrValue As String = INI_Read("CONFIG", "SET", "HeadFile") 'DNS設定值
            '.InitialDirectory = FileAddrValue
            .Filter = "(Image Files)|*.jpg;*.png;*.bmp;*.gif;*.ico|Jpg, | *.jpg|Png, | *.png|Bmp, | *.bmp|Gif, | *.gif|Ico | *.ico"
            .FilterIndex = 1
        End With

        If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
            Dim btn As Button = CType(sender, Button)
            If btn.Text = "金相1圖" Then
                金相1.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相1.SizeMode = PictureBoxSizeMode.StretchImage
                金相1.BorderStyle = BorderStyle.Fixed3D
            ElseIf btn.Text = "金相2圖" Then
                金相2.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相2.SizeMode = PictureBoxSizeMode.StretchImage
                金相2.BorderStyle = BorderStyle.Fixed3D
            ElseIf btn.Text = "金相3圖" Then
                金相3.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相3.SizeMode = PictureBoxSizeMode.StretchImage
                金相3.BorderStyle = BorderStyle.Fixed3D
            ElseIf btn.Text = "金相4圖" Then
                金相4.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相4.SizeMode = PictureBoxSizeMode.StretchImage
                金相4.BorderStyle = BorderStyle.Fixed3D
            ElseIf btn.Text = "金相5圖" Then
                金相5.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相5.SizeMode = PictureBoxSizeMode.StretchImage
                金相5.BorderStyle = BorderStyle.Fixed3D
            ElseIf btn.Text = "金相6圖" Then
                金相6.Image = Image.FromFile(OpenFileDialog2.FileName)
                金相6.SizeMode = PictureBoxSizeMode.StretchImage
                金相6.BorderStyle = BorderStyle.Fixed3D
            End If
        End If


    End Sub

    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter
        金相1.Image = Nothing
        金相2.Image = Nothing
        金相3.Image = Nothing
        金相4.Image = Nothing
        金相5.Image = Nothing
        金相6.Image = Nothing

        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        If 圖倍率1.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='1' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相1.Image = pictures
            Catch ex As Exception

            End Try
        End If

        If 圖倍率2.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='2' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相2.Image = pictures
            Catch ex As Exception

            End Try
        End If

        If 圖倍率3.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='3' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相3.Image = pictures
            Catch ex As Exception

            End Try
        End If

        If 圖倍率4.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='4' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相4.Image = pictures
            Catch ex As Exception

            End Try
        End If

        If 圖倍率5.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='5' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相5.Image = pictures
            Catch ex As Exception

            End Try
        End If

        If 圖倍率6.Text <> "" Then
            strSQL99 = "SELECT 金相圖檔 FROM 進貨單金相圖檔"
            strSQL99 &= " WHERE 序號='6' and  工令號碼 = '" & 工令號碼.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)

            Try
                Dim pictureData As Byte() = DirectCast(objCmd99.ExecuteScalar(), Byte())
                Dim pictures As Image = Nothing
                Using stream As New System.IO.MemoryStream(pictureData)
                    pictures = Image.FromStream(stream)

                End Using
                金相6.Image = pictures
            Catch ex As Exception

            End Try
        End If


        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub

    Private Sub 金相儲存_Click(sender As Object, e As EventArgs) Handles 金相儲存.Click
        Button1.PerformClick()

        Dim blnCheck As Boolean = False

        dbDelete(DNS, "進貨單金相圖檔", "工令號碼 = '" & 工令號碼.Text & "'")

        If 圖倍率1.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "1" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相1.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='1' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If

        If 圖倍率2.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "2" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相2.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='2' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If

        If 圖倍率3.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "3" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相3.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='3' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If

        If 圖倍率4.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "4" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相4.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='4' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If

        If 圖倍率5.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "5" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相2.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='5' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If

        If 圖倍率6.Text <> "" Then
            strIRow = "工令號碼,序號"
            strIValue = "'" & 工令號碼.Text & "','" & "6" & "'"
            blnCheck = dbInsert(DNS, "進貨單金相圖檔", strIRow, strIValue)

            Try
                Dim imgData As Byte()         ' storage for the img bytes
                imgData = ImgToByteArray(金相6.Image, ImageFormat.Bmp)

                strUValue = "UPDATE 進貨單金相圖檔 SET 金相圖檔=@金相圖檔 WHERE 序號='6' and 工令號碼 = '" & 工令號碼.Text & "'"
                Dim sqlCommand As New SqlCommand
                sqlCommand.Parameters.Add("@金相圖檔", SqlDbType.VarBinary)
                sqlCommand.Parameters("@金相圖檔").Value = imgData

                objCon99 = New SqlConnection(DNS)
                objCon99.Open()

                With sqlCommand
                    .CommandText = strUValue
                    .Connection = objCon99
                    .ExecuteNonQuery()
                End With

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub 金相報告書_Click(sender As Object, e As EventArgs) Handles 金相報告書.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "金相報告書.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub
End Class


