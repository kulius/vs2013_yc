Imports FastReport
Imports FastReport.Utils
Imports System.Collections.Specialized

Public Class S03N0320
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
    Private Sub S03N0320_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        'BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()
        'Tab2_Panel1.Width = WorkingArea_Width()
        Me.WindowState = FormWindowState.Maximized

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
    End Sub
    Private Sub S03N0320_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    Private Sub S03N0320_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
    End Sub
    Private Sub S03N0320_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 貨單序號.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(貨單序號.Text)
            Return False
        Else
            Return True
        End If

    End Function
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        ComboBox_DB(生管人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='04' or 職稱代碼2='04' or 職稱代碼3='04' )", "姓名 ASC")
        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")

        ComboBox_DB(i單位代號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(i次加工廠, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")
        ComboBox_DB(i二次廠商, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")

        ComboBox_DGDB(次加工廠商1, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "", "公司名稱 ASC")
        ComboBox_DGDB(次加工廠商, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "", "公司名稱 ASC")
        ComboBox_DGDB(二次廠商, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")
        ComboBox_DGDB(二次廠商1, DNS, "加工廠主檔", "加工廠代號", "簡稱", "", "公司名稱 ASC")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"貨單序號", "出貨日期", "客戶簡稱", "生管員", "司機姓名", "所屬工廠"}
        Dim arrColWidth() As String = {"120", "120", "100", "100", "160", "160", "100"}

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
        strSSQL = "SELECT top " + PageCount.Text + " m.*, t1.姓名 AS 司機姓名, t2.姓名 AS 生管員,t3.簡稱 as 客戶簡稱  FROM 出貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 司機主檔 AS t1 ON m.司機代號 = t1.司機代號"
        strSSQL &= " LEFT JOIN 員工主檔 AS t2 ON m.生管人員 = t2.員工代號"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t3 ON m.客戶代號 = t3.客戶代號"
        strSSQL &= " WHERE 1=1 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 貨單序號 DESC"

        '顯示欄位
        arrRowName = {"貨單序號", "出貨日期", "客戶簡稱", "生管員", "司機姓名", "所屬工廠"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


        '異動後初始化*****
        SetControls(0)
        intRow = 0
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '載入待出貨資料
    Public Sub FillOrderData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料

        If CK已過磅.Checked Then
            strSearch &= " and  isnull(m.過磅狀態,'') <> '' "
        End If

        If CK已進爐.Checked Then
            strSearch &= " and m.狀態='3' "
        End If

        If CK已檢驗.Checked Then
            strSearch &= " and  isnull(m.檢驗狀態,'') <> ''"
        End If

        If CK已出貨.Checked Then
            strSearch &= " and  m.狀態<>'9'"
        End If

        'If s客戶代號.SelectedValue <> "" Then
        '    strSearch &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        'End If

        If FIRM <> "總公司" Then
            strSearch &= " and m.所屬工廠='" + FIRM + "'"
        End If

        '查詢語法
        strSSQL = "SELECT 'false' as 選,客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",m.次加工廠代號1 as 次加工廠商,m.次加工廠代號2 as 二次廠商,單位代號1 AS 單位"
        strSSQL &= ",產品名稱 AS 品名,isnull(規格代碼,'')+'X'+isnull(長度代碼,'')+長度說明 AS 規格,材質代碼 AS 材質,表面處理代碼 AS 表面"
        strSSQL &= ",m.* FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        ' strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        '   strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0006') AS t9 ON m.加工方式代碼 = t9.一層代碼 "
        '   strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0009') AS t10 ON m.電鍍別代碼 = t10.一層代碼 "
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        'strSSQL &= " WHERE 1=1 and 狀態='3' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>'' "
        strSSQL &= " WHERE 1=1 and 狀態>=0 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY m.工令號碼"
        'strSSQL &= " ORDER BY m.序號,m.製造日期1"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(OrderDataDGV, DNS, strSSQL)

        '異動後初始化*****
        'SetControls(0)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {OutDataDGV}

        Set_Control_RW(TabControl, butStatus)

        DataGridViewR_Control(objDataGridViewR, butStatus)

        貨單序號.ReadOnly = True
        總桶數.ReadOnly = True
        總重量.ReadOnly = True
        所屬工廠.ReadOnly = True
        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = True
                BtnOrderOK.Enabled = False
                btnAdd.Enabled = False
                客戶代碼.ReadOnly = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                strPage = FIRMCODE + Mid(CStr(出貨日期.Value.Year - 1911), 2, 2) + 出貨日期.Value.Month.ToString.PadLeft(2, "0")
                '貨單序號.Text = ERP_AutoNo_貨單序號(DNS, strPage, "出貨單主檔", "貨單序號")
                生管人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                客戶代碼.Focus()
                客戶代碼.ReadOnly = False
                客戶代碼.Text = ""
                BtnOrderOK.Enabled = True
                btnAdd.Enabled = True
                所屬工廠.Text = FIRM

            Case 2 '修改模式
                'TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                生管人員.Focus()
                客戶代碼.ReadOnly = True

                BtnOrderOK.Enabled = True
                btnAdd.Enabled = True
                客戶代號_SelectedIndexChanged(Nothing, Nothing)
            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                生管人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                貨單序號.Focus()
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

        貨單序號.Text = ERP_AutoNo_貨單序號(DNS, strPage, "出貨單主檔", "貨單序號")
        '代號是否有重複
        If dbDataCheck(DNS, "出貨單主檔", "貨單序號 = '" & 貨單序號.Text & "'") = True Then MsgBox("系統訊息：【貨單序號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        For i As Integer = 0 To OutDataDGV.RowCount() - 1
            If OutDataDGV.Rows(i).Cells(2).Value = "" Or dbCount(DNS, "進貨單主檔", "intCount", " 工令號碼 = '" & OutDataDGV.Rows(i).Cells(2).Value & "' and 客戶代號 = '" & 客戶代碼.Text & "'") > 0 Then
            Else
                MsgBox(OutDataDGV.Rows(i).Cells(2).Value + "客戶簡稱不符合")
                OutDataDGV.CurrentCell = OutDataDGV.Rows(i).Cells(2)
                blnCheck = False
            End If
        Next

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '過磅單主檔
        strIRow = "貨單序號,出貨日期,司機代號,生管人員,"
        strIRow &= "客戶代號,總桶數,總重量,所屬工廠,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 貨單序號.Text & "','" & strSystemToDate(出貨日期.Value.ToShortDateString) & "','" & 司機代號.SelectedValue & "','" & 生管人員.SelectedValue & "',"
        strIValue &= "'" & 客戶代號.SelectedValue & "','" & 總桶數.Text & "','" & 總重量.Text & "','" & 所屬工廠.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "出貨單主檔", strIRow, strIValue)

        FormKey = 貨單序號.Text

        '出貨單項目檔
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("工令號碼").Value,
                                           OutDataDGV.Rows(I).Cells("磅後桶數").Value,
                                           OutDataDGV.Rows(I).Cells("單位").Value,
                                           OutDataDGV.Rows(I).Cells("磅後總重").Value,
                                           OutDataDGV.Rows(I).Cells("備註").Value,
                                           OutDataDGV.Rows(I).Cells("爐號").Value,
                                           OutDataDGV.Rows(I).Cells("次加工廠商").Value,
                                           OutDataDGV.Rows(I).Cells("二次廠商").Value,
                                           OutDataDGV.Rows(I).Cells("排序").Value
                                          }

            If strRowValue(0) <> "" Or strRowValue(1) <> "" Or strRowValue(2) <> "" Or strRowValue(3) <> "" Or strRowValue(4) <> "" Then
                strIRow = "貨單序號,工令號碼,桶數,單位,重量,備註,爐號,加工廠代號,二次加工廠代號,排序"
                strIValue = "'" & 貨單序號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "'"
                dbInsert(DNS, "出貨單項目檔", strIRow, strIValue)
            End If
            'If strRowValue(0) <> "" Then
            '    If dbDataCheck(DNS, "出貨單項目檔", "工令號碼 = '" & strRowValue(0) & "'") = True Then
            '        MsgBox("系統訊息：【工令號碼】" + strRowValue(0) + "已有相同之資料!!", MsgBoxStyle.Exclamation, "注意")
            '    Else
            '        strIRow = "貨單序號,工令號碼,桶數,單位,重量,備註,爐號,加工廠代號,二次加工廠代號"
            '        strIValue = "'" & 貨單序號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "'"
            '        dbInsert(DNS, "出貨單項目檔", strIRow, strIValue)
            '    End If
            'End If
        Next

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態='9' "
        strSSQL &= " where 工令號碼 in (select 工令號碼 from 出貨單項目檔 where 貨單序號='" + 貨單序號.Text + "')"
        blnCheck = dbExecute(DNS, strSSQL)

        strSSQL = "update 進貨單主檔 set 狀態='3' "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 出貨單項目檔 ) and 狀態='9' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>''"
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

        For i As Integer = 0 To OutDataDGV.RowCount() - 1
            If OutDataDGV.Rows(i).Cells(2).Value = "" Or dbCount(DNS, "進貨單主檔", "intCount", " 工令號碼 = '" & OutDataDGV.Rows(i).Cells(2).Value & "' and 客戶代號 = '" & 客戶代碼.Text & "'") > 0 Then
            Else
                MsgBox(OutDataDGV.Rows(i).Cells(2).Value + "客戶簡稱不符合")
                OutDataDGV.CurrentCell = OutDataDGV.Rows(i).Cells(2)
                blnCheck = False
            End If
        Next

        If blnCheck = False Then Return False : Exit Function

        GetCtrlUpdateSql(TabPage2, "BCtrl", strUValue)

        '無法SQL的欄位*****
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "貨單序號 = '" & 貨單序號.Text & "'"

        blnCheck = dbEdit(DNS, "出貨單主檔", strUValue, strWValue)

        FormKey = 貨單序號.Text

        '先刪
        dbDelete(DNS, "出貨單項目檔", "貨單序號 = '" & 貨單序號.Text & "'")
        '後加
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("工令號碼").Value,
                                           OutDataDGV.Rows(I).Cells("磅後桶數").Value,
                                           OutDataDGV.Rows(I).Cells("單位").Value,
                                           OutDataDGV.Rows(I).Cells("磅後總重").Value,
                                           OutDataDGV.Rows(I).Cells("備註").Value,
                                           OutDataDGV.Rows(I).Cells("爐號").Value,
                                           OutDataDGV.Rows(I).Cells("次加工廠商").Value,
                                           OutDataDGV.Rows(I).Cells("二次廠商").Value,
                                           OutDataDGV.Rows(I).Cells("排序").Value,
                                           OutDataDGV.Rows(I).Cells("單價").Value,
                                           OutDataDGV.Rows(I).Cells("小計").Value
                                          }


            If strRowValue(0) <> "" Or strRowValue(1) <> "" Or strRowValue(2) <> "" Or strRowValue(3) <> "" Or strRowValue(4) <> "" Then
                strIRow = "貨單序號,工令號碼,桶數,單位,重量,備註,爐號,加工廠代號,二次加工廠代號,排序,單價,小計"
                strIValue = "'" & 貨單序號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "'"
                dbInsert(DNS, "出貨單項目檔", strIRow, strIValue)
                'If dbDataCheck(DNS, "出貨單項目檔", "工令號碼 = '" & strRowValue(0) & "'") = True Then
                '    MsgBox("系統訊息：【工令號碼】" + strRowValue(0) + "已有相同之資料!!", MsgBoxStyle.Exclamation, "注意")
                'Else
                '    strIRow = "貨單序號,工令號碼,桶數,單位,重量,備註,爐號,加工廠代號,二次加工廠代號"
                '    strIValue = "'" & 貨單序號.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "'"
                '    dbInsert(DNS, "出貨單項目檔", strIRow, strIValue)
                'End If
            End If
        Next

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態='9' "
        strSSQL &= " where 工令號碼 in (select 工令號碼 from 出貨單項目檔 where 貨單序號='" + 貨單序號.Text + "')"
        dbExecute(DNS, strSSQL)

        strSSQL = "update 進貨單主檔 set 狀態='3' "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 出貨單項目檔 ) and 狀態='9' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>''"
        dbExecute(DNS, strSSQL)

        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "出貨單主檔", "貨單序號 = '" & 貨單序號.Text & "'")
        blnCheck = dbDelete(DNS, "出貨單項目檔", "貨單序號 = '" & 貨單序號.Text & "'")

        '查詢語法
        strSSQL = "update 進貨單主檔 set 狀態='9' "
        strSSQL &= " where 工令號碼 in (select 工令號碼 from 出貨單項目檔 where 貨單序號='" + 貨單序號.Text + "' )"
        blnCheck = dbExecute(DNS, strSSQL)

        strSSQL = "update 進貨單主檔 set 狀態='3' "
        strSSQL &= " where 工令號碼 not in (select 工令號碼 from 出貨單項目檔 ) and 狀態='9' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>''"
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
    '出貨單主檔
    Sub Weigh(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 出貨單主檔"
        strSQL99 &= " WHERE 貨單序號 = '" & strKey1 & "'"

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
    '出貨單項目檔
    Sub WeighItem(ByVal strKey1 As String)

        Dim blnCheck As Boolean = False '是否有查詢到資料


        '查詢語法
        strSSQL = "SELECT d.桶數 as 磅後桶數,d.單位,d.重量 as 磅後總重,d.備註,d.工令號碼,d.加工廠代號 as 次加工廠商,d.爐號,d.二次加工廠代號 as 二次廠商,d.單價,d.小計"
        strSSQL &= ",'false' as 選,m.客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
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
        strSSQL &= " WHERE d.貨單序號 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY d.排序"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)
        'Dim arrRowName() As String

        '過磅單項目
        'strSSQL = "SELECT m.*, t1.公司名稱 AS 客戶名稱, t2.公司名稱 AS 加工廠名稱 FROM 過磅單項目檔 AS m"
        'strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        'strSSQL &= " LEFT JOIN 加工廠主檔 AS t2 ON m.加工廠代號 = t2.加工廠代號 AND t2.加工廠類型 = 'A'"
        'strSSQL &= " WHERE m.過磅單號 = '" & strKey1 & "'"
        'strSSQL &= " ORDER BY m.序號 ASC"

        'arrRowName = {"客戶代號", "客戶名稱", "加工廠代號", "加工廠名稱", "調質重量", "滲碳重量", "其他重量", "桶數", "備註"}

        'DataGridViewR_DB(Tab2_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub
#End Region

#Region "物件異動選擇項"

    '切換頁時 重新拉取資料
    Private Sub TabControl_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl.SelectedIndexChanged
        'If TabControl.TabIndex = 3 Then
        '    If MyTableStatus <> 0 And 客戶代號.SelectedIndex <> 0 Then
        '        Dim str As String
        '        str = " "
        '        If 客戶代號.SelectedValue <> "" Then
        '            str &= " and m.客戶代號 ='" + 客戶代號.SelectedValue + "'"
        '        End If
        '        FillOrderData(str)
        '    End If
        'End If
    End Sub

    '依日期變換 貨單序號
    Private Sub 出貨日期_ValueChanged(sender As System.Object, e As System.EventArgs) Handles 出貨日期.ValueChanged
        If MyTableStatus = 1 Then
            strPage = FIRMCODE + Mid(CStr(出貨日期.Value.Year - 1911), 2, 2) + 出貨日期.Value.Month.ToString.PadLeft(2, "0")
            '貨單序號.Text = ERP_AutoNo_貨單序號(DNS, strPage, "出貨單主檔", "貨單序號")
        End If
    End Sub

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
            FillOrderData(str)
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


    '待出貨轉出貨
    Private Sub BtnOrderOK_Click(sender As System.Object, e As System.EventArgs) Handles BtnOrderOK.Click
        Dim rcount = OutDataDGV.RowCount
        For I As Integer = 0 To OrderDataDGV.RowCount - 1 Step 1
            If OrderDataDGV.Rows(I).Cells("選").Value = "true" Then
                rcount = rcount + 1
                OrderDataDGV.Rows(I).Selected = True
                OutDataDGV.Rows.Add(New Object() {False,
                rcount,
                OrderDataDGV.Rows(I).Cells("工令號碼1").Value,
                OrderDataDGV.Rows(I).Cells("爐號1").Value,
                OrderDataDGV.Rows(I).Cells("品名1").Value,
                OrderDataDGV.Rows(I).Cells("規格1").Value,
                OrderDataDGV.Rows(I).Cells("材質1").Value,
                OrderDataDGV.Rows(I).Cells("磅後桶數1").Value,
                OrderDataDGV.Rows(I).Cells("單位1").Value,
                OrderDataDGV.Rows(I).Cells("磅後總重1").Value,
                OrderDataDGV.Rows(I).Cells("電鍍別1").Value,
                OrderDataDGV.Rows(I).Cells("次加工廠商1").Value,
                OrderDataDGV.Rows(I).Cells("客戶工令1").Value,
                OrderDataDGV.Rows(I).Cells("牙分類1").Value,
                OrderDataDGV.Rows(I).Cells("二次廠商1").Value,
                OrderDataDGV.Rows(I).Cells("進貨日期1").Value,
                OrderDataDGV.Rows(I).Cells("線材爐號1").Value,
                OrderDataDGV.Rows(I).Cells("加工方式1").Value
                                                 })
            End If
        Next

        For Each row As DataGridViewRow In OrderDataDGV.SelectedRows
            OrderDataDGV.Rows.Remove(row)
        Next

        TabControl.SelectedTab = Me.TabPage2
    End Sub


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

    Private Sub btnSerach_Click(sender As System.Object, e As System.EventArgs) Handles btnSerach.Click
        Dim str As String
        str = " "
        If s客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If

        If s貨單序號.Text <> "" Then
            str &= " and m.貨單序號 like '" + s貨單序號.Text + "%'"
        End If
        FillData(str)
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        'strSQL99 = "SELECT * FROM 出貨單主檔"
        'strSQL99 &= " WHERE 貨單序號 = '" & strKey1 & "'"


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

    Private Sub OutDataDGV_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OutDataDGV.CellEndEdit

        'If e.ColumnIndex = 1 Then
        '    '開啟查詢
        '    objCon99 = New SqlConnection(DNS)
        '    objCon99.Open()

        '    '查詢語法
        '    strSSQL = "SELECT 'false' as 選,客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        '    strSSQL &= ",t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        '    strSSQL &= ",m.次加工廠代號1 as 次加工廠商,t12.簡稱 as 二次廠商,單位代號1 AS 單位"
        '    strSSQL &= ",t2.一層名稱 AS 品名,t3.一層名稱+'X'+t8.一層名稱+長度說明 AS 規格,t4.一層名稱 AS 材質,t6.一層名稱 AS 表面"
        '    strSSQL &= ",* FROM 進貨單主檔 AS m"
        '    strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        '    strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0006') AS t9 ON m.加工方式代碼 = t9.一層代碼 "
        '    strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0009') AS t10 ON m.電鍍別代碼 = t10.一層代碼 "
        '    strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        '    strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        '    strSSQL &= " WHERE 1=1 and 狀態>='3' and isnull(過磅狀態,'')<>'' and isnull(檢驗狀態,'')<>'' "
        '    strSSQL &= " and m.工令號碼='" + OutDataDGV.Rows(e.RowIndex).Cells("工令號碼").Value + "'"
        '    strSSQL &= " and m.客戶代號 ='" + 客戶代號.SelectedValue + "'"
        '    strSSQL &= " ORDER BY m.工令號碼"

        '    objCmd99 = New SqlCommand(strSSQL, objCon99)
        '    objDR99 = objCmd99.ExecuteReader

        '    If objDR99.Read Then

        '    Else
        '        MsgBox("客戶簡稱不符合")
        '    End If

        '    objDR99.Close()    '關閉連結
        '    objCon99.Close()
        '    objCmd99.Dispose() '手動釋放資源
        '    objCon99.Dispose()
        '    objCon99 = Nothing '移除指標
        'End If




        Dim T重量 As Integer = 0

        Dim UintCount(5) As TUintCount

        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            For j As Integer = 0 To UintCount.Length - 1
                If UintCount(j).單位 = OutDataDGV.Rows(I).Cells("單位").Value Then
                    Exit For
                End If

                If UintCount(j).單位 = "" Then
                    UintCount(j).單位 = OutDataDGV.Rows(I).Cells("單位").Value
                    Exit For
                End If
            Next
        Next





        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            If OutDataDGV.Rows(I).Cells("磅後總重").Value <> 0 Then
                T重量 = T重量 + OutDataDGV.Rows(I).Cells("磅後總重").Value
            End If

            For j As Integer = 0 To UintCount.Length - 1
                If UintCount(j).單位 = OutDataDGV.Rows(I).Cells("單位").Value Then
                    UintCount(j).桶數 = UintCount(j).桶數 + OutDataDGV.Rows(I).Cells("磅後桶數").Value
                End If
            Next
        Next

        總重量.Text = T重量.ToString

        總桶數.Text = ""
        For j As Integer = 0 To UintCount.Length - 1
            If UintCount(j).單位 <> "" Then
                總桶數.Text = 總桶數.Text + UintCount(j).桶數.ToString + UintCount(j).單位 + ","
            End If

        Next

    End Sub

    Structure TUintCount
        Dim 桶數 As Integer
        Dim 單位 As String
    End Structure

#Region "報表處理"
    '列印
    Public Overrides Sub PrintWindows()
        TabControl.SelectedTab = Me.TabPage4
    End Sub
    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Try
            Dim thisFolder As String = ReportDir

            FRreport.Preview = PreviewControl1
            FRreport.Load(thisFolder + "預備單.frx")
            FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
            FRreport.SetParameterValue("RepKey", 貨單序號.Text)
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

    Private Sub btnPreviewRep1_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep1.Click
        Try
            Dim thisFolder As String = ReportDir

            FRreport.Preview = PreviewControl2
            FRreport.Load(thisFolder + "送貨單.frx")
            FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
            FRreport.SetParameterValue("RepKey", 貨單序號.Text)
            FRreport.Prepare()
            FRreport.ShowPrepared()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDesignRep1_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep1.Click
        FRreport.Design()
    End Sub

    Private Sub TabPage6_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage6.Enter
        btnPreviewRep1_Click(sender, e)
    End Sub
#End Region


    Private Sub i工令_Leave(sender As System.Object, e As System.EventArgs) Handles i工令.Leave
        If i工令.Text <> "" Then

            '開啟查詢
            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            strSQL99 = "SELECT * FROM 進貨單主檔"
            strSQL99 &= " WHERE 工令號碼 = '" & i工令.Text & "' and 客戶代號 = '" & 客戶代碼.Text & "'"

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
                MsgBox("客戶簡稱不符合")
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


    Private Sub OutDataDGV_RowPrePaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles OutDataDGV.RowPrePaint
        'If (OutDataDGV.Rows.Count <= e.RowIndex) Then Return

        'If (e.RowIndex < 0) Then Return

        'If (OutDataDGV.Rows(e.RowIndex).Cells(1).Value = Nothing) Then Return

        'If OutDataDGV.Rows(e.RowIndex).Cells(1).Value = "" Then
        '    Dim row As DataGridViewRow = OutDataDGV.Rows(e.RowIndex)
        '    row.DefaultCellStyle.BackColor = Color.SkyBlue

        '    If (row.Selected) Then
        '        row.DefaultCellStyle.SelectionBackColor = Color.Yellow
        '        row.DefaultCellStyle.SelectionForeColor = Color.Red

        '    End If
        'End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim str As String
        str = " "
        If 客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + 客戶代號.SelectedValue + "'"
        End If
        FillOrderData(str)
    End Sub
End Class
