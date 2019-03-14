Imports FastReport
Imports FastReport.Utils
Imports System.Collections.Specialized

Public Class S03N0400
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
    Private Sub S03N0400_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.WindowState = FormWindowState.Maximized

        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
    End Sub
    Private Sub S03N0400_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    Private Sub S03N0400_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
    End Sub
    Private Sub S03N0400_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 轉廠單號.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(轉廠單號.Text)
            Return False
        Else
            Return True
        End If

    End Function
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()

        ComboBox_DB(i單位代號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(i次加工廠, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")
        ComboBox_DB(i二次廠商, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")

        ComboBox_DGDB(次加工廠商, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "", "公司名稱 ASC")
        ComboBox_DGDB(二次廠商, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"轉廠單號", "轉廠日期", "所屬工廠", "目地工廠"}
        Dim arrColWidth() As String = {"120", "120", "100", "100"}

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

    'DataGridView控制行列增減
    Private Sub btnDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        For Each r As DataGridViewRow In OutDataDGV.SelectedRows
            If Not r.IsNewRow Then
                OutDataDGV.Rows.Remove(r)
            End If
        Next
    End Sub
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        If FIRM <> "總公司" Then
            strSearch &= " and m.所屬工廠='" + FIRM + "'"
        End If

        '查詢語法
        strSSQL = "SELECT top " + PageCount.Text + " m.*  FROM 轉廠單主檔 AS m"
        strSSQL &= " WHERE 1=1 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 轉廠單號 DESC"

        '顯示欄位
        arrRowName = {"轉廠單號", "轉廠日期", "所屬工廠", "目地工廠"}

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
        Dim objDataGridViewR() As DataGridView = {OutDataDGV}

        Set_Control_RW(TabControl, butStatus)

        DataGridViewR_Control(objDataGridViewR, butStatus)

        轉廠單號.ReadOnly = True
        所屬工廠.ReadOnly = True
        目地工廠.ReadOnly = True
        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = True
                btnAdd.Enabled = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                strPage = FIRMCODE + Mid(CStr(轉廠日期.Value.Year - 1911), 2, 2) + 轉廠日期.Value.Month.ToString.PadLeft(2, "0")
                '轉廠單號.Text = ERP_AutoNo_轉廠單號(DNS, strPage, "轉廠單主檔", "轉廠單號")

                btnAdd.Enabled = True

                所屬工廠.Text = FIRM
                If FIRM = "楠梓廠" Then
                    目地工廠.Text = "崗山廠"
                ElseIf FIRM = "崗山廠" Then
                    目地工廠.Text = "楠梓廠"
                End If


            Case 2 '修改模式
                'TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                btnAdd.Enabled = True
            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                轉廠單號.Focus()
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
        Dim objArray_Input() As Object = {}
        Dim strArray_Input() As String = {}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {}
        Dim strArray_Numeric() As String = {}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        轉廠單號.Text = ERP_AutoNo_貨單序號(DNS, strPage, "轉廠單主檔", "轉廠單號")
        '代號是否有重複
        If dbDataCheck(DNS, "轉廠單主檔", "轉廠單號 = '" & 轉廠單號.Text & "'") = True Then MsgBox("系統訊息：【轉廠單號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False


        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '過磅單主檔
        strIRow = "轉廠單號,轉廠日期,所屬工廠,目地工廠,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 轉廠單號.Text & "','" & strSystemToDate(轉廠日期.Value.ToShortDateString) & "','" & 所屬工廠.Text & "','" & 目地工廠.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "轉廠單主檔", strIRow, strIValue)

        FormKey = 轉廠單號.Text

        '轉廠單項目檔
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("工令號碼").Value,
                                           OutDataDGV.Rows(I).Cells("備註").Value
                                          }

            If strRowValue(0) <> "" Or strRowValue(1) <> "" Then
                strIRow = "轉廠單號,工令號碼,備註"
                strIValue = "'" & 轉廠單號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "'"
                dbInsert(DNS, "轉廠單項目檔", strIRow, strIValue)
            End If
        Next

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態='-2' ,狀態備份=狀態  "
        strSSQL &= " where 工令號碼 in (select 工令號碼 from 轉廠單項目檔 where 轉廠單號='" + 轉廠單號.Text + "')"
        blnCheck = dbExecute(DNS, strSSQL)

        strSSQL = "update 進貨單主檔 set 狀態=狀態備份 "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 轉廠單項目檔 ) and 狀態='-2' "
        blnCheck = dbExecute(DNS, strSSQL)


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
        strWValue = "轉廠單號 = '" & 轉廠單號.Text & "'"

        blnCheck = dbEdit(DNS, "轉廠單主檔", strUValue, strWValue)

        FormKey = 轉廠單號.Text

        '先刪
        dbDelete(DNS, "轉廠單項目檔", "轉廠單號 = '" & 轉廠單號.Text & "'")
        '轉廠單項目檔
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("工令號碼").Value,
                                           OutDataDGV.Rows(I).Cells("備註").Value
                                          }

            If strRowValue(0) <> "" Or strRowValue(1) <> "" Then
                strIRow = "轉廠單號,工令號碼,備註"
                strIValue = "'" & 轉廠單號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "'"
                dbInsert(DNS, "轉廠單項目檔", strIRow, strIValue)
            End If
        Next

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態='-2' ,狀態備份=狀態  "
        strSSQL &= " where 狀態<>'-2' and 工令號碼 in (select 工令號碼 from 轉廠單項目檔 where 轉廠單號='" + 轉廠單號.Text + "')"
        blnCheck = dbExecute(DNS, strSSQL)

        strSSQL = "update 進貨單主檔 set 狀態=狀態備份 "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 轉廠單項目檔 ) and 狀態='-2' "
        blnCheck = dbExecute(DNS, strSSQL)

        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "轉廠單主檔", "轉廠單號 = '" & 轉廠單號.Text & "'")
        blnCheck = dbDelete(DNS, "轉廠單項目檔", "轉廠單號 = '" & 轉廠單號.Text & "'")

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態=狀態備份 "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 轉廠單項目檔 ) and 狀態='-2' "
        blnCheck = dbExecute(DNS, strSSQL)

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
        WeighItem(strKey1) '過磅單項目檔
    End Sub
    '轉廠單主檔
    Sub Weigh(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 轉廠單主檔"
        strSQL99 &= " WHERE 轉廠單號 = '" & strKey1 & "'"

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
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '轉廠單項目檔
    Sub WeighItem(ByVal strKey1 As String)

        Dim blnCheck As Boolean = False '是否有查詢到資料


        '查詢語法
        strSSQL = "SELECT 'false' as 選,m.客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量 "
        strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",單位代號1 AS 單位"
        strSSQL &= ",t2.一層名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面"
        strSSQL &= ",* FROM 轉廠單項目檔 AS d left JOIN 進貨單主檔  as m on m.工令號碼=d.工令號碼 "
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
        strSSQL &= " WHERE d.轉廠單號 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY d.工令號碼"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)

    End Sub
#End Region

#Region "物件異動選擇項"

    '依日期變換 轉廠單號
    Private Sub 轉廠日期_ValueChanged(sender As System.Object, e As System.EventArgs) Handles 轉廠日期.ValueChanged
        If MyTableStatus = 1 Then
            strPage = FIRMCODE + Mid(CStr(轉廠日期.Value.Year - 1911), 2, 2) + 轉廠日期.Value.Month.ToString.PadLeft(2, "0")
            '轉廠單號.Text = ERP_AutoNo_轉廠單號(DNS, strPage, "轉廠單主檔", "轉廠單號")
        End If
    End Sub


#End Region





    '轉成待出貨
    Private Sub OutData_btnDec_Click(sender As System.Object, e As System.EventArgs) Handles OutData_btnDec.Click
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            If OutDataDGV.Rows(I).Cells("待").Value = "true" Then
                OutDataDGV.Rows(I).Selected = True
            End If
        Next

        For Each row As DataGridViewRow In OutDataDGV.SelectedRows
            OutDataDGV.Rows.Remove(row)
        Next
    End Sub



    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        'strSQL99 = "SELECT * FROM 轉廠單主檔"
        'strSQL99 &= " WHERE 轉廠單號 = '" & strKey1 & "'"


        strSSQL = "SELECT 'false' as 選,客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",m.次加工廠代號1 as 次加工廠商,m.次加工廠代號2 as 二次廠商,單位代號1 AS 單位"
        strSSQL &= ",t2.一層名稱 AS 品名,isnull(t3.一層名稱,'')+'X'+isnull(t8.一層名稱,'')+長度說明 AS 規格,t4.一層名稱 AS 材質,t6.一層名稱 AS 表面"
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
        'strSSQL &= " WHERE 1=1 and 狀態='3' and isnull(過磅狀態,'')<>'' and 外觀判定='合格' and 整體判定='合格'  "
        strSSQL &= " where m.工令號碼='" & i工令.Text & "'"

        objCmd99 = New SqlCommand(strSSQL, objCon99)
        objDR99 = objCmd99.ExecuteReader

        Dim rcount = OutDataDGV.RowCount + 1
        If i桶數.Text = "" Then
            i桶數.Text = "0"
        End If
        If i重量.Text = "" Then
            i重量.Text = "0"
        End If

        If objDR99.Read Then
            OutDataDGV.Rows.Add(New Object() {False,
                    rcount,
                    i工令.Text,
                    i爐號.Text,
                    objDR99("品名").ToString,
                    objDR99("規格").ToString,
            objDR99("材質").ToString,
            i桶數.Text,
            i單位代號.SelectedValue,
            i重量.Text,
            objDR99("電鍍別").ToString,
            i次加工廠.SelectedValue,
            objDR99("客戶工令").ToString,
            objDR99("牙分類").ToString,
            i二次廠商.SelectedValue,
            objDR99("進貨日期").ToString,
            objDR99("線材爐號").ToString,
            objDR99("加工方式").ToString,
            i備註.Text
                                                     })
        Else
            OutDataDGV.Rows.Add(New Object() {False, rcount, i工令.Text, i爐號.Text, "", "", "", i桶數.Text, i單位代號.SelectedValue, i重量.Text, "", i次加工廠.SelectedValue, "", "", i二次廠商.SelectedValue, "", "", "", i備註.Text})
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標


    End Sub





#Region "報表處理"
    '列印
    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Try
            Dim thisFolder As String = ReportDir

            FRreport.Preview = PreviewControl1
            FRreport.Load(thisFolder + "轉廠預備單.frx")
            FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
            FRreport.SetParameterValue("RepKey", 轉廠單號.Text)
            FRreport.Prepare()
            FRreport.ShowPrepared()
        Catch ex As Exception

        End Try
        'report.Show()
        'report.Dispose()
    End Sub
    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        FRreport.Design()
    End Sub

    Private Sub TabPage5_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage5.Enter
        btnPreviewRep_Click(sender, e)
    End Sub


    Private Sub btnDesignRep1_Click(sender As System.Object, e As System.EventArgs)
        FRreport.Design()
    End Sub

#End Region


    Private Sub i工令_Leave(sender As System.Object, e As System.EventArgs) Handles i工令.Leave
        If i工令.Text <> "" Then

            '開啟查詢
            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            strSQL99 = "SELECT * FROM 進貨單主檔"
            strSQL99 &= " WHERE 工令號碼 = '" & i工令.Text & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)
            objDR99 = objCmd99.ExecuteReader

            If objDR99.Read Then
                i爐號.Text = objDR99("預排爐號").ToString
                i桶數.Text = objDR99("磅後桶數").ToString
                i重量.Text = objDR99("磅後總重").ToString
                i單位代號.SelectedValue = objDR99("單位代號1").ToString
                i次加工廠.SelectedValue = objDR99("次加工廠代號1").ToString
                i二次廠商.SelectedValue = objDR99("次加工廠代號2").ToString
            Else
                MsgBox("找不到工令")
                i工令.Text = ""
                i桶數.Text = "0"
                i重量.Text = "0"
                i單位代號.SelectedValue = ""
                i次加工廠.SelectedValue = ""
                i二次廠商.SelectedValue = ""
            End If


            objDR99.Close()    '關閉連結
            objCon99.Close()
            objCmd99.Dispose() '手動釋放資源
            objCon99.Dispose()
            objCon99 = Nothing '移除指標
        End If

    End Sub



End Class
