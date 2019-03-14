Public Class S03N0110
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
    Dim nowStatus As Integer '編輯狀態
    Dim FormKey As String = "" '目前編輯的KEY值


#End Region
#Region "單用變數"
    Dim strPage As String = Mid(Now.Year, 3, 2)
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0110_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()
        Tab2_Panel1.Width = WorkingArea_Width()

        txtDataGridViewTitle.Text = FIRM + txtDataGridViewTitle.Text

        '按鍵
        Dim btnItems() As ToolStripButton = {butPrint, butSearch}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
        If FIRMCODE = "1" Then
            strPage = "E1" & strPage
        ElseIf FIRMCODE = "2" Then
            strPage = "E2" & strPage
        Else
            strPage = "E0" & strPage
        End If

    End Sub

    Private Sub S03N0110_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
    End Sub
    Private Sub S03N0110_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub



    Private Sub S03N0110_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S03N0110 As New S_S03N0110

        '開啟視窗
        S_S03N0110.MdiParent = fmMain
        S_S03N0110.Show()
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 過磅單號.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(過磅單號.Text)
            Return False
        Else
            Return True
        End If

    End Function
    Public Overrides Sub AfterEndEdit()
        ShowData(FormKey)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名+' '+司機代號", "", "姓名 ASC")
        ComboBox_DB(過磅人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and 職稱代碼1='04'", "姓名 ASC")

        ComboBox_DB(i客戶名稱, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(i前加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DGDB(客戶名稱, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DGDB(加工廠代號, DNS, "(select 加工廠代號,公司名稱 from 加工廠主檔 union select 加工廠代號,加工廠代號 from 過磅單項目檔 where 加工廠代號 not in (select 加工廠代號 from 加工廠主檔 ) ) as 加工廠主檔", "加工廠代號", "公司名稱", "", "公司名稱 ASC")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"過磅單號", "過磅日期", "時間", "載貨員", "過磅員", "車次序號", "進出貨", "所屬工廠"}
        Dim arrColWidth() As String = {"120", "120", "100", "160", "160", "100", "100", "100"}

        DataGridView.ColumnCount = arrColName.Length
        DataGridView.RowCount = 1

        For J As Integer = 0 To arrColName.Length - 1 Step 1
            With DataGridView
                .Columns(J).Name = arrColName(J) '欄位名稱
                .Columns(J).Width = arrColWidth(J) '欄位寬度
            End With
        Next


    End Sub
    '點二下切換至資料顯示
    Private Sub DataGridView_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView.DoubleClick
        TabControl.SelectedTab = Me.TabPage2
    End Sub
    '欄位顏色
    Private Sub DataGridView_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Tab2_DataGridViewR1.Paint
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

    'Tab2_DataGridViewR1 控制行列增減
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab2_btnAdd.Click
        'Me.Tab2_DataGridViewR1.Rows.Add()
        If i客戶代號.Text <> "" And i前加工廠代號.SelectedValue <> "" Then
            Tab2_DataGridViewR1.Rows.Add(New Object() {i客戶代號.Text, i客戶名稱.SelectedValue, i前加工廠代號.SelectedValue, ""})
        Else
            MsgBox("請輸入客戶代號、加工廠代號")
            i客戶代號.Focus()
        End If

    End Sub
    Private Sub btnDec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tab2_btnDec.Click
        For Each r As DataGridViewRow In Tab2_DataGridViewR1.SelectedRows
            If Not r.IsNewRow Then
                Tab2_DataGridViewR1.Rows.Remove(r)
            End If
        Next
    End Sub
    'Tab2_DataGridViewR1 值變換帶動其他欄位改變
    Private Sub Tab2_DataGridViewR1_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tab2_DataGridViewR1.CellValueChanged
        ' 取得變更後的值 
        Try
            If Tab2_DataGridViewR1.Rows.Count > 0 And nowStatus <> 0 Then
                If Tab2_DataGridViewR1.Columns(e.ColumnIndex).Name = "客戶名稱" Then
                    Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("客戶代號").Value = Tab2_DataGridViewR1(e.ColumnIndex, e.RowIndex).Value.ToString()
                ElseIf Tab2_DataGridViewR1.Columns(e.ColumnIndex).Name = "客戶代號" Then
                    If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & Tab2_DataGridViewR1(e.ColumnIndex, e.RowIndex).Value.ToString() & "'") > 0 Then
                        Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("客戶名稱").Value = Tab2_DataGridViewR1(e.ColumnIndex, e.RowIndex).Value.ToString()
                    Else
                        Tab2_DataGridViewR1.Rows(e.RowIndex).Cells("客戶名稱").Value = ""
                    End If

                End If

                'Dim dr As String
                'dr = Tab2_DataGridViewR1(e.ColumnIndex, e.RowIndex).Value.ToString()
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        If FIRM <> "總公司" Then
            strSearch &= " and 所屬工廠='" + FIRM + "'"
        End If


        '查詢語法
        strSSQL = "SELECT top " + PageCount.Text + " m.*, t1.姓名 AS 司機姓名, t2.姓名 AS 員工姓名, CASE WHEN m.分類 = 'I' THEN '進貨' WHEN m.分類 = 'O' THEN '出貨' ELSE '' END AS '進出貨' FROM 過磅單主檔 AS m"
        strSSQL &= " LEFT JOIN 司機主檔 AS t1 ON m.司機代號 = t1.司機代號"
        strSSQL &= " LEFT JOIN 員工主檔 AS t2 ON m.過磅人員 = t2.員工代號"
        strSSQL &= " WHERE 1=1 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 日期 DESC,車次序號 DESC"

        '顯示欄位
        arrRowName = {"過磅單號", "日期", "時間", "司機姓名", "員工姓名", "車次序號", "進出貨", "所屬工廠"}

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
        nowStatus = butStatus
        Dim objDataGridViewR() As DataGridView = {Tab2_DataGridViewR1}

        Dim objTextBoxM() As TextBox = {過磅單號, 車次序號, 時間}
        Dim objComboBoxM() As ComboBox = {司機代號}
        Dim objRadioButtonM() As RadioButton = {分類1, 分類2}
        Dim objDateTimePickerM() As DateTimePicker = {日期}

        Dim objTextBox1() As TextBox = {地磅序號, 調質重量, 車號, 總重, _
                                        滲碳重量, 空車重, 其他重量, 空桶重}
        Dim objComboBox1() As ComboBox = {過磅人員}
        Dim objRadioButton1() As RadioButton = {}
        Dim objDateTimePicker1() As DateTimePicker = {}


        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)

        所屬工廠.ReadOnly = True
        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                'TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

                '進貨次數.Text = "0" : 出貨次數.Text = "0" : 淨重.Text = "0"

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                '進貨次數.Text = "0" : 出貨次數.Text = "0"
                淨重.Text = "0"
                調質重量.Text = "0"
                滲碳重量.Text = "0"
                其他重量.Text = "0"
                其他重量1.Text = "0"
                總重.Text = "0"
                空車重.Text = "0"
                空桶重.Text = "0"
                時間.Text = NowTime()
                '過磅人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                分類1.Checked = True
                過磅單號.Text = ERP_AutoNo(DNS, strPage, "過磅單主檔", "過磅單號")
                日期.Focus()
                所屬工廠.Text = FIRM


            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                '進貨次數.Text = "0" : 出貨次數.Text = "0"
                淨重.Text = "0"
                時間.Text = NowTime()
                '過磅人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                過磅單號.Text = ERP_AutoNo(DNS, strPage, "過磅單主檔", "過磅單號")
                日期.Focus()
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

        調質重量.Focus()
        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {過磅單號, 司機代號, 過磅人員, 車號}
        Dim strArray_Input() As String = {"過磅單號", "載貨員", "過磅員", "車號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)
        If blnCheck = False Then Return False : Exit Function

        '必數字
        Dim objArray_Numeric() As Object = {調質重量, 總重, 滲碳重量, 空車重, 其他重量, 空桶重, 其他重量1}
        Dim strArray_Numeric() As String = {"調質重量", "總重", "滲碳重量", "空車重", "其他重量", "空桶重", "其他重量1"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)
        If blnCheck = False Then Return False : Exit Function

        Dim sum1 As Double = CDbl(調質重量.Text) + CDbl(滲碳重量.Text) + CDbl(其他重量.Text) + CDbl(其他重量1.Text)
        If sum1 <> CDbl(淨重.Text) Then
            MsgBox("運費數量有誤，4種重量合計數需等於(＝)淨重重量")
            blnCheck = False
        End If
        If blnCheck = False Then Return False : Exit Function

        過磅單號.Text = ERP_AutoNo(DNS, strPage, "過磅單主檔", "過磅單號")
        '代號是否有重複
        If dbDataCheck(DNS, "過磅單主檔", "過磅單號 = '" & 過磅單號.Text & "'") = True Then MsgBox("系統訊息：【過磅單號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""

        Dim sYear As Integer = 日期.Value.Year
        Select Case sYear
            Case 2014
                S1 = "4"
            Case 2015
                S1 = "5"
            Case 2016
                S1 = "6"
            Case 2017
                S1 = "7"
            Case 2018
                S1 = "8"
            Case 2019
                S1 = "9"
            Case 2020
                S1 = "A"
            Case 2021
                S1 = "B"
            Case 2022
                S1 = "C"
            Case 2023
                S1 = "D"
            Case Else
                S1 = Mid(sYear.ToString, 4, 1)
        End Select

        Dim sMonth As Integer = 日期.Value.Month
        Select Case sMonth
            Case 10
                S2 = "A"
            Case 11
                S2 = "B"
            Case 12
                S2 = "C"
            Case Else
                S2 = sMonth.ToString
        End Select

        Dim DayArray() As String = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", _
            "F", "G", "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "W", _
            "X", "Y"}

        Dim sDay As Integer = 日期.Value.Day
        S3 = DayArray(sDay - 1)



        S4 = 司機代號.SelectedValue
        'If 分類1.Checked Then
        '    S5 = DayArray(dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'"))
        'End If
        'If 分類2.Checked Then
        '    S5 = DayArray(dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'"))
        'End If
        S5 = DayArray(dbCount(DNS, "過磅單主檔", "intCount", "司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'"))
        'Dim String5 As String = dbGetSingleRow(DNS, "過磅單主檔", "車次序號", "司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'", "車次序號 DESC")
        'If String5 = "" Then
        '    S5 = DayArray(0)
        'Else
        '    S5 = DayArray(CInt(Mid(String5, 5, 1)))
        'End If

        車次序號.Text = FIRMCODE + S1 + S2 + S3 + S4 + S5


        '開啟儲存*****
        '過磅單主檔
        strIRow = "過磅單號,分類,司機代號,過磅人員,"
        strIRow &= "日期,時間,車次序號,地磅序號,車號,"
        strIRow &= "調質重量,總重,滲碳重量,空車重,其他重量,空桶重,淨重,"
        strIRow &= "進貨次數,出貨次數,其他重量1,所屬工廠,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 過磅單號.Text & "','" & IIf(分類1.Checked = True, "I", "O") & "','" & 司機代號.SelectedValue & "','" & 過磅人員.SelectedValue & "',"
        strIValue &= "'" & strSystemToDate(日期.Value.ToShortDateString) & "','" & 時間.Text & "','" & 車次序號.Text & "','" & 地磅序號.Text & "','" & 車號.Text & "',"
        strIValue &= "'" & 調質重量.Text & "','" & 總重.Text & "','" & 滲碳重量.Text & "','" & 空車重.Text & "','" & 其他重量.Text & "','" & 空桶重.Text & "','" & 淨重.Text & "',"
        strIValue &= "'" & 進貨次數.Text & "','" & 出貨次數.Text & "','" & 其他重量1.Text & "','" & 所屬工廠.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "過磅單主檔", strIRow, strIValue)


        '過磅單項目檔
        'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("客戶代號").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("前加工廠代號").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("調質重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("滲碳重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("其他重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("桶數").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

        '    If strRowValue(0) <> "" Then
        '        strIRow = "過磅單號,序號,客戶代號,加工廠代號,調質重量,滲碳重量,其他重量,桶數,備註,車次序號"
        '        strIValue = "'" & 過磅單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & 車次序號.Text & "'"
        '        dbInsert(DNS, "過磅單項目檔", strIRow, strIValue)
        '    End If
        'Next

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("客戶代號").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("加工廠代號").Value,
                                            Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

            If strRowValue(0) <> "" And strRowValue(1) <> "" Then
                strIRow = "過磅單號,序號,客戶代號,加工廠代號,備註,車次序號"
                strIValue = "'" & 過磅單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & 車次序號.Text & "'"
                dbInsert(DNS, "過磅單項目檔", strIRow, strIValue)
            End If
        Next

        FormKey = 過磅單號.Text
        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False
        調質重量.Focus()
        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {過磅單號, 司機代號, 過磅人員}
        Dim strArray_Input() As String = {"過磅單號", "載貨員", "過磅員"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)
        If blnCheck = False Then Return False : Exit Function

        '必數字
        Dim objArray_Numeric() As Object = {調質重量, 總重, 滲碳重量, 空車重, 其他重量, 空桶重, 其他重量1}
        Dim strArray_Numeric() As String = {"調質重量", "總重", "滲碳重量", "空車重", "其他重量", "空桶重", "其他重量1"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)
        If blnCheck = False Then Return False : Exit Function

        If 調質重量.Text = "" Then
            調質重量.Text = 0
        End If

        If 滲碳重量.Text = "" Then
            滲碳重量.Text = 0
        End If

        If 其他重量.Text = "" Then
            其他重量.Text = 0
        End If

        If 其他重量1.Text = "" Then
            其他重量1.Text = 0
        End If

        Dim sum1 As Double = CDbl(調質重量.Text) + CDbl(滲碳重量.Text) + CDbl(其他重量.Text) + CDbl(其他重量1.Text)
        If sum1 <> CDbl(淨重.Text) Then
            MsgBox("運費數量有誤，4種重量合計數需等於(＝)淨重重量")
            blnCheck = False
        End If
        If blnCheck = False Then Return False : Exit Function


        '防呆結束*****


        '開啟儲存*****
        '客戶主檔
        strUValue = "分類 = '" & IIf(分類1.Checked = True, "I", "O") & "',"
        'strUValue &= "司機代號 = '" & 司機代號.SelectedValue & "',"
        'strUValue &= "日期 = '" & strSystemToDate(日期.Value.ToShortDateString) & "',"
        'strUValue &= "時間 = '" & 時間.Text & "',"
        'strUValue &= "車次序號 = '" & 車次序號.Text & "',"
        strUValue &= "過磅人員 = '" & 過磅人員.SelectedValue & "',"
        strUValue &= "地磅序號 = '" & 地磅序號.Text & "',"
        strUValue &= "車號 = '" & Trim(車號.Text) & "',"
        strUValue &= "調質重量 = '" & 調質重量.Text & "',"
        strUValue &= "總重 = '" & 總重.Text & "',"
        strUValue &= "滲碳重量 = '" & 滲碳重量.Text & "',"
        strUValue &= "空車重 = '" & 空車重.Text & "',"
        strUValue &= "其他重量 = '" & 其他重量.Text & "',"
        strUValue &= "空桶重 = '" & 空桶重.Text & "',"
        strUValue &= "淨重 = '" & 淨重.Text & "',"
        strUValue &= "其他重量1 = '" & 其他重量1.Text & "',"
        strUValue &= "所屬工廠 = '" & 所屬工廠.Text & "',"

        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "過磅單號 = '" & 過磅單號.Text & "'"

        blnCheck = dbEdit(DNS, "過磅單主檔", strUValue, strWValue)

        FormKey = 過磅單號.Text

        '相關聯絡人檔
        '先刪
        dbDelete(DNS, "過磅單項目檔", "過磅單號 = '" & 過磅單號.Text & "'")
        '後加
        'For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
        '    Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("客戶代號").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("前加工廠代號").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("調質重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("滲碳重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("其他重量_R").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("桶數").Value,
        '                                   Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

        '    If strRowValue(0) <> "" Then
        '        strIRow = "過磅單號,序號,客戶代號,加工廠代號,調質重量,滲碳重量,其他重量,桶數,備註,車次序號"
        '        strIValue = "'" & 過磅單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & 車次序號.Text & "'"
        '        dbInsert(DNS, "過磅單項目檔", strIRow, strIValue)
        '    End If
        'Next

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("客戶代號").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("加工廠代號").Value,
                                            Tab2_DataGridViewR1.Rows(I).Cells("備註").Value}

            If strRowValue(0) <> "" And strRowValue(1) <> "" Then
                strIRow = "過磅單號,序號,客戶代號,加工廠代號,備註,車次序號"
                strIValue = "'" & 過磅單號.Text & "','" & I + 1 & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & 車次序號.Text & "'"
                dbInsert(DNS, "過磅單項目檔", strIRow, strIValue)
            End If
        Next


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '代號是否有重複
        If dbDataCheck(DNS, "進貨單主檔", "車次序號 = '" & 車次序號.Text & "'") = True Then
            MsgBox("系統訊息：【進貨單】有此車次序號!!", MsgBoxStyle.Exclamation, "注意")
            blnCheck = True
        End If

        If blnCheck = True Then Exit Sub


        '--開啟異動--
        blnCheck = dbDelete(DNS, "過磅單主檔", "過磅單號 = '" & 過磅單號.Text & "'")
        blnCheck = dbDelete(DNS, "過磅單項目檔", "過磅單號 = '" & 過磅單號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Weigh(strKey1) '過磅單主檔
        WeighItem(strKey1) '過磅單項目檔
    End Sub
    '過磅單主檔
    Sub Weigh(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT  * FROM 過磅單主檔"
        strSQL99 &= " WHERE 過磅單號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            過磅單號.Text = objDR99("過磅單號").ToString
            車次序號.Text = objDR99("車次序號").ToString
            進貨次數.Text = objDR99("進貨次數").ToString
            出貨次數.Text = objDR99("出貨次數").ToString

            車號.Text = objDR99("車號").ToString
            時間.Text = objDR99("時間").ToString
            地磅序號.Text = objDR99("地磅序號").ToString
            調質重量.Text = objDR99("調質重量").ToString
            總重.Text = objDR99("總重").ToString
            滲碳重量.Text = objDR99("滲碳重量").ToString
            空車重.Text = objDR99("空車重").ToString
            其他重量.Text = objDR99("其他重量").ToString
            其他重量1.Text = objDR99("其他重量1").ToString
            空桶重.Text = objDR99("空桶重").ToString
            淨重.Text = objDR99("淨重").ToString
            過磅備註.Text = objDR99("備註").ToString
            所屬工廠.Text = objDR99("所屬工廠").ToString

            '非文字欄位*****
            日期.Value = IIf(IsDate(objDR99("日期").ToString) = False, Now, objDR99("日期").ToString)

            司機代號.SelectedValue = objDR99("司機代號").ToString
            過磅人員.SelectedValue = objDR99("過磅人員").ToString

            分類1.Checked = IIf(objDR99("分類").ToString = "I", True, False)
            分類2.Checked = IIf(objDR99("分類").ToString = "O", True, False)

            If 分類1.Checked Then
                Label1.Text = "前加工廠"
            Else
                Label1.Text = "次加工廠"
            End If
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '過磅單項目檔
    Sub WeighItem(ByVal strKey1 As String)
        Dim arrRowName() As String

        '過磅單項目
        strSSQL = "SELECT m.*, t1.公司名稱 AS 客戶名稱, t2.公司名稱 AS 加工廠名稱 FROM 過磅單項目檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t2 ON m.加工廠代號 = t2.加工廠代號 AND t2.加工廠類型 = 'A'"
        strSSQL &= " WHERE m.過磅單號 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY m.序號 ASC"

        arrRowName = {"客戶代號", "客戶代號", "加工廠代號", "備註"}
        DataGridViewR_DB(Tab2_DataGridViewR1, DNS, strSSQL, arrRowName)

    End Sub
#End Region

#Region "物件異動選擇項"
    '司機代號
    Private Sub 司機代號_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 司機代號.SelectedIndexChanged
        If nowStatus <> 0 Then

            If 司機代號.SelectedValue = "" Then Exit Sub
            If 分類1.Checked Then
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If

            If 分類2.Checked Then
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If


            車號.Text = dbGetSingleRow(DNS, "司機主檔", "車牌號碼", "司機代號 = '" & 司機代號.SelectedValue & "'")
            地磅序號.Focus()
        End If
    End Sub

    Private Sub i客戶名稱_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles i客戶名稱.SelectedIndexChanged
        If MyTableStatus <> 0 Then
            i客戶代號.Text = i客戶名稱.SelectedValue
        End If
    End Sub

    Private Sub i客戶代號_Leave(sender As System.Object, e As System.EventArgs) Handles i客戶代號.Leave
        If MyTableStatus <> 0 Then
            If dbCount(DNS, "客戶主檔", "intCount", "往來否 = 'Y' and 客戶代號 = '" & i客戶代號.Text & "'") > 0 Then
                i客戶名稱.SelectedValue = i客戶代號.Text
            Else
                i客戶名稱.SelectedValue = ""
            End If

        End If
    End Sub

    Private Sub 分類1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles 分類1.CheckedChanged
        ComboBox_DB(i前加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")
        If 分類1.Checked Then
            Label1.Text = "前加工廠"
            TabPage2.BackColor = Color.Pink
        End If

        If nowStatus <> 0 Then
            If 司機代號.SelectedValue = "" Then Exit Sub
            If 分類1.Checked Then
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If

            If 分類2.Checked Then
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If
        End If
        'ComboBox_DGDB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")
    End Sub

    Private Sub 分類2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles 分類2.CheckedChanged
        ComboBox_DB(i前加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'B'", "公司名稱 ASC")
        If 分類2.Checked Then
            Label1.Text = "次加工廠"
            TabPage2.BackColor = Color.GreenYellow
        End If
        If nowStatus <> 0 Then
            If 司機代號.SelectedValue = "" Then Exit Sub
            If 分類1.Checked Then
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                進貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'I' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If

            If 分類2.Checked Then
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'") + 1
            Else
                出貨次數.Text = dbCount(DNS, "過磅單主檔", "intCount", "分類 = 'O' AND 司機代號 = '" & 司機代號.SelectedValue & "' and 日期='" & strSystemToDate(日期.Value.ToShortDateString) & "'")
            End If
        End If
        'ComboBox_DGDB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'B'", "公司名稱 ASC")
    End Sub
    '重量計算
    Sub intWeigh()
        Dim intValue1 As Double = 0 : Dim intValue2 As Double = 0 : Dim intValue3 As Double = 0
        Dim intValue4 As Double = 0 : Dim intValue5 As Double = 0 : Dim intValue6 As Double = 0

        '防呆
        intValue1 = IIf(IsNumeric(調質重量.Text) = False, 0, 調質重量.Text)
        intValue2 = IIf(IsNumeric(總重.Text) = False, 0, 總重.Text)
        intValue3 = IIf(IsNumeric(滲碳重量.Text) = False, 0, 滲碳重量.Text)
        intValue4 = IIf(IsNumeric(空車重.Text) = False, 0, 空車重.Text)
        intValue5 = IIf(IsNumeric(其他重量.Text) = False, 0, 其他重量.Text)
        intValue6 = IIf(IsNumeric(空桶重.Text) = False, 0, 空桶重.Text)

        '調質重量.Text = intValue2 - intValue3 - intValue4 - intValue5 - intValue6
        淨重.Text = intValue2 - intValue4 - intValue6
    End Sub
    Private Sub 調質重量_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 調質重量.LostFocus
        If IsNumeric(調質重量.Text) = False Then 調質重量.Text = "" : Exit Sub

        If 總重.Text = "" Then 總重.Text = 調質重量.Text
        intWeigh()
    End Sub
    Private Sub 總重_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 總重.LostFocus
        If IsNumeric(總重.Text) = False Then 總重.Text = "" : Exit Sub

        If 調質重量.Text = "" Then 調質重量.Text = 總重.Text
        intWeigh()
    End Sub
    Private Sub 滲碳重量_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 滲碳重量.LostFocus
        If IsNumeric(滲碳重量.Text) = False Then 滲碳重量.Text = "" : Exit Sub

        intWeigh()
    End Sub
    Private Sub 空車重_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 空車重.LostFocus
        If IsNumeric(空車重.Text) = False Then 空車重.Text = "" : Exit Sub

        intWeigh()
    End Sub
    Private Sub 其他重量_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 其他重量.LostFocus
        If IsNumeric(其他重量.Text) = False Then 其他重量.Text = "" : Exit Sub

        intWeigh()
    End Sub
    Private Sub 空桶重_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 空桶重.LostFocus
        If IsNumeric(空桶重.Text) = False Then 空桶重.Text = "" : Exit Sub

        intWeigh()
    End Sub
#End Region

    'If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")






End Class
