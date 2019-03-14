Imports FastReport
Imports FastReport.Utils
Imports System.Collections.Specialized

Public Class S03N0330
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
    Dim strPage As String = ""
    Dim FRreport As New Report
    Dim FormKey As String = "" '目前編輯的KEY值
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0330_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
    End Sub
    Private Sub S03N0330_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    Private Sub S03N0330_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
    End Sub
    Private Sub S03N0330_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 出貨退回編號.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(出貨退回編號.Text)
            Return False
        Else
            Return True
        End If

    End Function
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        ComboBox_GG(處理方式, ",轉入進貨單,不轉入進貨單", ",轉入進貨單,不轉入進貨單")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"出貨退回編號", "工令號碼", "退回日期", "客戶簡稱", "新工令號碼", "退回備註", "所屬工廠", "應收帳款扣款日期", "退回金額"}
        Dim arrColWidth() As String = {"120", "120", "120", "100", "100", "160", "100", "100", "100"}

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
        strSSQL = "SELECT top " + PageCount.Text + " m.*, t1.姓名 AS 司機姓名,t3.簡稱 as 客戶簡稱  FROM 出貨退回主檔 AS m"
        strSSQL &= " LEFT JOIN 司機主檔 AS t1 ON m.司機代號 = t1.司機代號"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t3 ON m.客戶代號 = t3.客戶代號"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 退回日期 DESC"

        '顯示欄位
        arrRowName = {"出貨退回編號", "工令號碼", "退回日期", "客戶簡稱", "新工令號碼", "退回備註", "所屬工廠", "應收帳款扣款日期", "退回金額"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****
        SetControls(0)
        intRow = 0
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Set_Control_RW(TabControl, butStatus)


        所屬工廠.ReadOnly = True
        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = True
                客戶代碼.ReadOnly = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                strPage = FIRMCODE + Mid(CStr(退回日期.Value.Year - 1911), 2, 2) + 退回日期.Value.Month.ToString.PadLeft(2, "0")
                OutDataDGV.Rows.Clear()
                客戶代碼.Focus()
                客戶代碼.ReadOnly = False
                客戶代碼.Text = ""
                所屬工廠.Text = FIRM

            Case 2 '修改模式
                'TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                客戶代碼.ReadOnly = True
            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
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
        Dim objArray_Input() As Object = {工令號碼, 客戶代號}
        Dim strArray_Input() As String = {"工令號碼", "客戶代號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {}
        Dim strArray_Numeric() As String = {}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        Dim ii As Integer = dbCount(DNS, "出貨退回主檔", "intCount", "工令號碼 = '" & 工令號碼.Text & "'")

        If ii = 0 Then
            出貨退回編號.Text = 工令號碼.Text
        Else
            出貨退回編號.Text = 工令號碼.Text + "_" + CStr(ii)
        End If




        '代號是否有重複
        If dbDataCheck(DNS, "出貨退回主檔", "出貨退回編號 = '" & 出貨退回編號.Text & "'") = True Then MsgBox("系統訊息：【出貨退回編號】已有相同之退回資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False



        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '過磅單主檔
        strIRow = "工令號碼,退回日期,司機代號,退回備註,"
        strIRow &= "客戶代號,退回桶數,退回重量,退回金額,所屬工廠,"
        strIRow &= "應收帳款扣款日期,處理方式,出貨退回編號,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 工令號碼.Text & "','" & strSystemToDate(退回日期.Value.ToShortDateString) & "','" & 司機代號.SelectedValue & "','" & 退回備註.Text & "',"
        strIValue &= "'" & 客戶代號.SelectedValue & "','" & 退回桶數.Text & "','" & 退回重量.Text & "','" & 退回金額.Text & "','" & 所屬工廠.Text & "',"
        strIValue &= "'" & strSystemToDate(退回日期.Value.ToShortDateString) & "','" & 處理方式.Text & "','" & 出貨退回編號.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "出貨退回主檔", strIRow, strIValue)

        'strSSQL = "INSERT INTO 進貨單主檔 (工令號碼, 前工令號碼, 日期, 時間,進貨日期,車次序號, 客戶代號, 加工廠代號, 開單人員,司機代號, 客戶單號, 客戶批號, 產品代碼,規格代碼, 長度代碼, 長度說明,品名分類代碼,加工方式代碼, 材質代碼, 規範分類, 強度級數,"
        'strSSQL &= " 表面處理代碼, 電鍍別代碼, 次加工廠代號1, 次加工廠代號2,數量1, 單位代號1, 數量2, 單位代號2,數量3,單位代號3, 數量4, 單位代號4,淨重, 線材爐號, 依據標準, 表面硬度,心部硬度, 抗拉強度, 滲碳層, 扭力,華司材質, 華司硬度, 試片, 存放位置,"
        'strSSQL &= " 運費種類, 回火溫度, 以前爐號, 預排爐號,注意事項1, 注意事項2, 注意事項3,品管備註1, 品管備註2, 品管備註3,製造備註1, 製造備註2, 製造備註3,流量, CP值, 氨值1,氨值2,氨值3, 氨值4, 加熱爐1,加熱爐2,加熱爐3, 加熱爐4, 加熱爐5,加熱爐6,加熱爐7,加熱爐8,"
        'strSSQL &= " 加熱爐油溫, 加熱爐速度, 回火爐1,回火爐2,回火爐3, 回火爐4, 回火爐5, 回火爐6, 回火爐速度,裝袋合計,序號,狀態,牙分類,產品名稱,所屬工廠,扭力強度值,建立人員,建立日期,修改人員,修改日期)"
        'strSSQL &= " SELECT '" & 新工令號碼.Text & "', 工令號碼, 日期, 時間,進貨日期,車次序號, 客戶代號, 加工廠代號, 開單人員,司機代號, 客戶單號, 客戶批號, 產品代碼,規格代碼, 長度代碼, 長度說明,品名分類代碼,加工方式代碼, 材質代碼, 規範分類, 強度級數,"
        'strSSQL &= " 表面處理代碼, 電鍍別代碼, 次加工廠代號1, 次加工廠代號2,數量1, 單位代號1, 數量2, 單位代號2,數量3,單位代號3, 數量4, 單位代號4,淨重, 線材爐號, 依據標準, 表面硬度,心部硬度, 抗拉強度, 滲碳層, 扭力,華司材質, 華司硬度, 試片, 存放位置,"
        'strSSQL &= " 運費種類, 回火溫度, 以前爐號, 預排爐號,注意事項1, 注意事項2, 注意事項3,品管備註1, 品管備註2, 品管備註3,製造備註1, 製造備註2, 製造備註3,流量, CP值, 氨值1,氨值2,氨值3, 氨值4, 加熱爐1,加熱爐2,加熱爐3, 加熱爐4, 加熱爐5,加熱爐6,加熱爐7,加熱爐8,"
        'strSSQL &= " 加熱爐油溫, 加熱爐速度, 回火爐1,回火爐2,回火爐3, 回火爐4, 回火爐5, 回火爐6, 回火爐速度,裝袋合計,序號,'0',牙分類,產品名稱,所屬工廠,扭力強度值,'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        'strSSQL &= "  FROM 進貨單主檔 where 工令號碼 = '" & 工令號碼.Text & "'"
        'blnCheck = dbExecute(DNS, strSSQL)

        FormKey = 出貨退回編號.Text

        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = True
        strUValue = ""


        If blnCheck = False Then Return False : Exit Function

        GetCtrlUpdateSql(TabPage2, "BCtrl", strUValue)

        '無法SQL的欄位*****
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "出貨退回編號 = '" & 出貨退回編號.Text & "'"

        blnCheck = dbEdit(DNS, "出貨退回主檔", strUValue, strWValue)

        FormKey = 出貨退回編號.Text



        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "出貨退回主檔", "出貨退回編號 = '" & 出貨退回編號.Text & "'")


        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub

    Public Overrides Sub AfterEndEdit()
        ShowData(FormKey)
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Weigh(strKey1) '過磅單主檔
    End Sub
    '出貨退回主檔
    Sub Weigh(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 出貨退回主檔"
        strSQL99 &= " WHERE 出貨退回編號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            ControlReadData(TabControl, objDR99)

            ShowOutData(objDR99("工令號碼").ToString, objDR99("客戶代號").ToString)
        End If

        'objDR99.Close()    '關閉連結
        'objCon99.Close()
        'objCmd99.Dispose() '手動釋放資源
        'objCon99.Dispose()
        'objCon99 = Nothing '移除指標
    End Sub
    '出貨單項目檔

    Sub ShowOutData(ByVal strKey1 As String, ByVal strKey2 As String)
        '查詢語法
        strSSQL = "SELECT d.小計,d.桶數 as 磅後桶數,d.單位,d.重量 as 磅後總重,d.備註,d.工令號碼,d.加工廠代號 as 次加工廠商,d.爐號,d.二次加工廠代號 as 二次廠商"
        strSSQL &= ",m.客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",單位代號1 AS 單位"
        strSSQL &= ",t2.一層名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面"
        strSSQL &= ",* FROM 出貨單項目檔 AS d left JOIN 進貨單主檔  as m on m.工令號碼=d.工令號碼 "
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0006') AS t9 ON m.加工方式代碼 = t9.一層代碼 "
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0009') AS t10 ON m.電鍍別代碼 = t10.一層代碼 "
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        strSSQL &= " WHERE d.工令號碼 = '" & strKey1 & "' and m.客戶代號='" & strKey2 & "'"
        strSSQL &= " ORDER BY d.排序"


        objCon99 = New SqlConnection(DNS)
        objCon99.Open()


        objCmd99 = New SqlCommand(strSSQL, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            If MyTableStatus = 1 Then
                退回桶數.Text = objDR99("磅後桶數").ToString
                退回重量.Text = objDR99("磅後總重").ToString
                退回金額.Text = objDR99("小計").ToString
            End If


            objDR99.Close()    '關閉連結
            objCon99.Close()
            objCmd99.Dispose() '手動釋放資源
            objCon99.Dispose()
            objCon99 = Nothing '移除指標

            '顯示欄位
            DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)
        Else
            MsgBox("在出貨資料中無此客戶的工令號碼")
            objDR99.Close()    '關閉連結
            objCon99.Close()
            objCmd99.Dispose() '手動釋放資源
            objCon99.Dispose()
            objCon99 = Nothing '移除指標
            '顯示欄位
            DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)

        End If

        '查詢語法
        strSSQL = "SELECT *"
        strSSQL &= ",* FROM 進貨單主檔 m "
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        strSSQL &= " WHERE m.前工令號碼 = '" & strKey1 & "'"
        DataGridView_HeaderDB(InDataDGV, DNS, strSSQL)

    End Sub

#End Region

#Region "物件異動選擇項"


    Private Sub 客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles 客戶代號.SelectedIndexChanged
        If 客戶代號.SelectedIndex <> 0 Then
            客戶代碼.Text = 客戶代號.SelectedValue
        End If

        If MyTableStatus <> 0 And 客戶代號.SelectedIndex <> 0 Then
            Dim str As String
            str = " "
            If 客戶代號.SelectedValue <> "" Then
                str &= " and m.客戶代號 ='" + 客戶代號.SelectedValue + "'"
            End If
        End If
    End Sub

    Private Sub s客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s客戶代號.SelectedIndexChanged
        If s客戶代號.SelectedIndex <> 0 Then
            s客戶代碼.Text = s客戶代號.SelectedValue
        End If
    End Sub

    Private Sub 客戶代碼_Leave(sender As System.Object, e As System.EventArgs) Handles 客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & 客戶代碼.Text & "'") > 0 Then
            客戶代號.SelectedValue = 客戶代碼.Text
        Else
            客戶代號.SelectedValue = ""
        End If
    End Sub

    Private Sub s客戶代碼_Leave(sender As System.Object, e As System.EventArgs) Handles s客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代碼.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代碼.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub

#End Region





    Private Sub btnSerach_Click(sender As System.Object, e As System.EventArgs) Handles btnSerach.Click
        Dim str As String
        str = " "
        If s客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If

        If s工令號碼.Text <> "" Then
            str &= " and m.工令號碼 like '" + s工令號碼.Text + "%'"
        End If
        FillData(str)
    End Sub

  

  

#Region "報表處理"
    '列印

#End Region


    Private Sub 工令號碼_Leave(sender As System.Object, e As System.EventArgs) Handles 工令號碼.Leave
        If 工令號碼.Text <> "" Then
            ShowOutData(工令號碼.Text, 客戶代號.SelectedValue)
        End If

        'Dim istr = InStr(1, 工令號碼.Text, "_")
        'If istr < 1 Then
        '    新工令號碼.Text = 工令號碼.Text + "_A"
        'Else
        '    Dim subString As String = Microsoft.VisualBasic.Strings.Right(工令號碼.Text, 1)
        '    Dim i As Integer = Asc(subString) ' Convert to ASCII integer.
        '    Dim x As Char = Chr(I + 1)      ' Convert ASCII integer to char.
        'End If



    End Sub


    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        btnPreviewRep_Click(sender, e)
    End Sub

    Private Sub btnPreviewRep_Click(sender As Object, e As EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "出貨退回單.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", 工令號碼.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As Object, e As EventArgs) Handles btnDesignRep.Click
        FRreport.Design()
    End Sub
End Class
