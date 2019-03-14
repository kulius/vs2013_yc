Imports FastReport
Imports FastReport.Utils
Public Class S03N0310
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
    Dim FRreport As New Report
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0310_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        '寬
        'BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()

        PageCount.Visible = False

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        butAddNew.Visible = False
        butCopy.Visible = False
        butDelete.Visible = False
        butFind.Visible = False
        butSearch.Visible = False
        butEdit.Visible = False
        butSave.Visible = False
        butCancelEdit.Visible = False


        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        Button1.PerformClick()

        Me.WindowState = FormWindowState.Maximized
        'FillData("") '載入資料集
    End Sub
    Private Sub S03N0310_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S03N0310_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
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
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")

        ComboBox_DGDB(次加工廠商1, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "", "公司名稱 ASC")
        ComboBox_DGDB(二次廠商1, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")

        'ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ''ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        ''ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        ''ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        'ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        'ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0005'", "一層代碼 ASC")
        'ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0003'", "一層代碼 ASC")
        'ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0006'", "一層代碼 ASC")
        'ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0007'", "一層代碼 ASC")
        'ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0008'", "一層代碼 ASC")
        'ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0009'", "一層代碼 ASC")
        ''ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ''ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        'ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(預排爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")

        'ComboBox_GG(運費種類, ",含運,自付", ",含運費,自付運費")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        'Dim arrColName() As String = {"工令號碼", "狀態", "檢驗狀態", "過磅狀態", "客戶", "進貨日期", "品名", "規格", "材質", "表面", "回火溫度", "表面硬度", "心部硬度", "線材爐號"}
        'Dim arrColWidth() As String = {"120", "100", "100", "100", "100", "160", "100", "100", "100", "100", "100", "100", "100", "100", "100"}

        'DataGridView.ColumnCount = arrColName.Length
        'DataGridView.RowCount = 1

        'For J As Integer = 0 To arrColName.Length - 1 Step 1
        '    With DataGridView
        '        .Columns(J).Name = arrColName(J) '欄位名稱
        '        .Columns(J).Width = arrColWidth(J) '欄位寬度
        '    End With
        'Next
        'DataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.PaleTurquoise

        'Dim dgvc As DataGridViewColumn = New DataGridViewCheckBoxColumn
        'dgvc.Width = 40
        'dgvc.Name = "選取"

        'DataGridView.Columns.Insert(0, dgvc)

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
        'Dim arrRowName() As String

        ''查詢語法
        'strSSQL = "SELECT top " + PageCount.Text + " m.日期 as 進貨日期,t1.公司名稱 AS 客戶,t2.一層名稱 AS 品名,m.規格代碼 AS 規格,m.材質代碼 AS 材質,t5.一層名稱 AS 狀態,m.表面處理代碼 AS 表面,m.* FROM 進貨單主檔 AS m"
        'strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        ''strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        ''strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        ''strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        'strSSQL &= " WHERE 1=1 "
        'strSSQL &= strSearch
        'strSSQL &= " ORDER BY 工令號碼 DESC"

        ''顯示欄位
        'arrRowName = {"工令號碼", "狀態", "檢驗狀態", "過磅狀態", "客戶", "進貨日期", "品名", "規格", "材質", "表面", "回火溫度", "表面硬度", "心部硬度", "線材爐號"}
        ''"客戶", "工令號碼", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"
        ''開啟產生DataGridView
        'blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)

        ''異動後初始化*****
        'SetControls(0)
        'FlagMoveSeat(0)

        '查詢語法
        strSSQL = "SELECT  客戶批號 as 客戶工令,前工令號碼 as 異常品原工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",m.次加工廠代號1 as 次加工廠商,m.次加工廠代號2 as 二次廠商,單位代號1 AS 單位"
        strSSQL &= ",產品名稱 AS 品名,isnull(t3.一層名稱,'')+'X'+isnull(t8.一層名稱,'')+長度說明 AS 規格,t4.一層名稱 AS 材質,t6.一層名稱 AS 表面"
        strSSQL &= ",* FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0006') AS t9 ON m.加工方式代碼 = t9.一層代碼 "
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0009') AS t10 ON m.電鍍別代碼 = t10.一層代碼 "
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        'strSSQL &= " WHERE 1=1 and 狀態='3' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>'' "
        strSSQL &= " WHERE 1=1 and 狀態>=0"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY m.工令號碼"
        'strSSQL &= " ORDER BY m.序號,m.製造日期1"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(DataGridView, DNS, strSSQL)
        txtCount.Text = DataGridView.RowCount

        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {}

        Set_Control_RW(TabControl, butStatus)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True
                DataGridView.ReadOnly = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True
                DataGridView.ReadOnly = False

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True
                DataGridView.ReadOnly = False

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True
                DataGridView.ReadOnly = False
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
                Dim strKey As String = DataGridView.Rows(intRow).Cells(1).Value.ToString

                '停在選定之儲存格
                ShowData(strKey)
                txtSeat.Text = intRow + 1 '目前位置
                DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
            Catch ex As Exception

            End Try
        End If
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

        ''防呆*****
        ''必輸入
        ''Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號, 開單人員, 司機代號}
        ''Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號", "開單人員", "司機代號"}
        ''blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        ''必數字
        ''Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重, 扭力}
        ''Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重", "扭力"}
        ''blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        'If blnCheck = False Then Return False : Exit Function
        ''防呆結束*****

        ''開啟儲存*****
        ''客戶主檔
        'strUValue = ""

        'GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)

        ''無法SQL的欄位*****

        'strUValue &= "過磅狀態 = '" & "已過磅" & "',"

        'strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        'strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        'strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        'blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)


        ''--異動後初始化--        
        'MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        'ComboBoxList()
        Return blnCheck
    End Function

    '刪除回復成 未進爐狀態
    Public Overrides Sub DeleteData()
        'Dim blnCheck As Boolean = False

        ''--開啟異動--
        'strUValue = "過磅狀態 = '" & "" & "',"

        'strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        'strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        'strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        'blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
        ''--異動後初始化--
        'MessageBox.Show("※資料已回復(未進爐狀態)" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        'ComboBoxList()

    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        MasterData(strKey1) '主檔    
    End Sub
    '主檔
    Sub MasterData(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 進貨單主檔"
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
            ControlReadData(TabControl, objDR99)

            '無法塞值的欄位*****

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub

    '查詢按鈕
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String
        str = " "
        If CK已過磅.Checked Then
            str &= " and  isnull(m.過磅狀態,'') <> '' "
        End If

        If CK已進爐.Checked Then
            str &= " and m.狀態='3' "
        End If

        If CK已檢驗.Checked Then
            str &= " and  isnull(m.檢驗狀態,'') <> ''"
        End If

        If CK已出貨.Checked Then
            str &= " and  m.狀態<>'9'"
        End If

        If s客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If

        If CK檢驗不合格.Checked Then
            str &= " and  檢驗狀態<>'檢驗不合格' and  外觀判定<>'不合格' and  整體判定<>'不合格'"
        End If

        FillData(str)
    End Sub
#End Region

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim blnCheck As Boolean = False

        'For Each dgvr As DataGridViewRow In Me.DataGridView.Rows
        '    If dgvr.Cells(0).Value IsNot Nothing AndAlso CBool(dgvr.Cells(0).Value) Then
        '        MessageBox.Show("表單編號: " + DirectCast(dgvr.DataBoundItem, DataRowView).Row.ItemArray(1) & " 被選取了！")
        '    End If
        'Next

        Dim count As Integer = Convert.ToInt32(DataGridView.Rows.Count.ToString())
        For i As Integer = 0 To count - 1
            '如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到
            DataGridView.EndEdit()
            Dim checkCell As DataGridViewCheckBoxCell = DirectCast(DataGridView.Rows(i).Cells(0), DataGridViewCheckBoxCell)
            Dim flag As [Boolean] = Convert.ToBoolean(checkCell.Value)
            If flag = True Then
                '查找被选择的数据行
                '从 DATAGRIDVIEW 中获取数据项

                Dim z_zcode As String = DataGridView.Rows(i).Cells(1).Value.ToString().Trim()
                ' MessageBox.Show("表單編號: " + z_zcode)
                strUValue = "狀態 = '" & "待出貨" & "',"

                strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
                strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

                strWValue = "工令號碼 = '" & z_zcode & "'"

                blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
            End If
        Next

        ''--開啟異動--

        '--異動後初始化--
        MessageBox.Show("※資料已轉為 狀態(待出貨狀態)" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub

    Private Sub s客戶代碼_Leave(sender As System.Object, e As System.EventArgs) Handles s客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代碼.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代碼.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub

    Private Sub s客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s客戶代號.SelectedIndexChanged
        If s客戶代號.SelectedIndex <> 0 Then
            s客戶代碼.Text = s客戶代號.SelectedValue
        End If
    End Sub

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "待出貨.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", s客戶代碼.Text)
        FRreport.SetParameterValue("RepKey1", CK已過磅.Checked.ToString)
        FRreport.SetParameterValue("RepKey2", CK已進爐.Checked.ToString)
        FRreport.SetParameterValue("RepKey3", CK已檢驗.Checked.ToString)
        FRreport.SetParameterValue("RepKey4", CK已出貨.Checked.ToString)


        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        Dim thisFolder As String = ReportDir
        FRreport.Load(thisFolder + "待出貨.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", s客戶代碼.Text)
        FRreport.SetParameterValue("RepKey1", CK已過磅.Checked.ToString)
        FRreport.SetParameterValue("RepKey2", CK已進爐.Checked.ToString)
        FRreport.SetParameterValue("RepKey3", CK已檢驗.Checked.ToString)
        FRreport.SetParameterValue("RepKey4", CK已出貨.Checked.ToString)
        FRreport.Design()
    End Sub

    Private Sub DataGridView_CellClick_1(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellClick
        txtSeat.Text = e.RowIndex + 1 '目前位置
    End Sub
End Class
