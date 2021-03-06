﻿Public Class S02N0202
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
    Private Sub S02N0202_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()
        Tab3_Panel1.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {butPrint}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S02N0300_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S02N0202 As New S_S02N0202

        '開啟視窗
        S_S02N0202.MdiParent = fmMain
        S_S02N0202.Show()
    End Sub

    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT * FROM 加工廠主檔 AS m"
        strSSQL &= " WHERE 1=1 AND 加工廠類型 = 'B'" '次加工廠資料
        strSSQL &= " ORDER BY 加工廠代號 ASC"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S02N0005'", "一層代碼 ASC")
        ComboBox_DB(所屬區域代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S02N0006'", "一層代碼 ASC")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"加工廠代號", "加工廠名稱", "電話", "傳真", "加工廠地址", "統一編號"}
        Dim arrColWidth() As String = {"120", "160", "120", "120", "260", "120"}

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

    'DataGridView控制行列增減
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles Tab3_btnAdd.Click
        Me.Tab3_DataGridViewR1.Rows.Add()
    End Sub
    Private Sub btnDec_Click(sender As System.Object, e As System.EventArgs) Handles Tab3_btnDec.Click
        For Each r As DataGridViewRow In Tab3_DataGridViewR1.SelectedRows
            If Not r.IsNewRow Then
                Tab3_DataGridViewR1.Rows.Remove(r)
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
        strSSQL = "SELECT * FROM 加工廠主檔 AS m"
        strSSQL &= " WHERE 1=1 AND 加工廠類型 = 'B'" '次加工廠資料
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 加工廠代號 ASC"

        '顯示欄位
        arrRowName = {"加工廠代號", "公司名稱", "電話1", "傳真1", "營業地址", "統一編號"}

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

        Dim objTextBoxM() As TextBox = {}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {加工廠代號, 公司名稱, 公司抬頭, 負責人, 統一編號, 簡稱, _
                                        營業郵遞區號, 營業地址, 帳單郵遞區號, 帳單地址, 工廠郵遞區號, 工廠地址, _
                                        電話1, 傳真1, 工廠電話1, 工廠傳真1, 網址, E_Mail, 產品項目, _
                                        備註1, 備註2, 備註3, 備註4, 備註5, 備註6, 備註7, 備註8, 備註9, 備註10}
        Dim objComboBox1() As ComboBox = {}
        Dim objRadioButton1() As RadioButton = {}
        Dim objDateTimePicker1() As DateTimePicker = {}

        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

                chk地址.Enabled = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk地址.Enabled = True
                加工廠代號.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk地址.Enabled = True

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                chk地址.Enabled = True
                加工廠代號.Focus()
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
        Dim objArray_Input() As Object = {加工廠代號, 公司名稱}
        Dim strArray_Input() As String = {"加工廠代號", "公司名稱"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '代號是否有重複
        If dbDataCheck(DNS, "加工廠主檔", "加工廠類型 = 'B' AND 加工廠代號 = '" & 加工廠代號.Text & "'") = True Then MsgBox("系統訊息：【加工廠代號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '加工廠主檔
        strIRow = "加工廠代號,加工廠類型,分類代碼,所屬區域代碼,統一編號,負責人,公司名稱,公司抬頭,簡稱,"
        strIRow &= "營業郵遞區號,營業地址,帳單郵遞區號,帳單地址,工廠郵遞區號,工廠地址,"
        strIRow &= "電話1,電話2,電話3,傳真1,傳真2,工廠電話1,工廠傳真1,網址,E_Mail,產品項目,"
        strIRow &= "備註1,備註2,備註3,備註4,備註5,"
        strIRow &= "備註6,備註7,備註8,備註9,備註10,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 加工廠代號.Text & "','B','" & 分類代碼.SelectedValue & "','" & 所屬區域代碼.SelectedValue & "','" & 統一編號.Text & "','" & 負責人.Text & "','" & 公司名稱.Text & "','" & 公司抬頭.Text & "','" & 簡稱.Text & "',"
        strIValue &= "'" & 營業郵遞區號.Text & "','" & 營業地址.Text & "','" & 帳單郵遞區號.Text & "','" & 帳單地址.Text & "','" & 工廠郵遞區號.Text & "','" & 工廠地址.Text & "',"
        strIValue &= "'" & 電話1.Text & "','" & 電話2.Text & "','" & 電話3.Text & "','" & 傳真1.Text & "','" & 傳真2.Text & "','" & 工廠電話1.Text & "','" & 工廠傳真1.Text & "','" & 網址.Text & "','" & E_Mail.Text & "','" & 產品項目.Text & "',"
        strIValue &= "'" & 備註1.Text & "','" & 備註2.Text & "','" & 備註3.Text & "','" & 備註4.Text & "','" & 備註5.Text & "',"
        strIValue &= "'" & 備註6.Text & "','" & 備註7.Text & "','" & 備註8.Text & "','" & 備註9.Text & "','" & 備註10.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "加工廠主檔", strIRow, strIValue)


        '相關聯絡人檔
        For I As Integer = 0 To Tab3_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab3_DataGridViewR1.Rows(I).Cells("聯絡人員").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("分機").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("部門").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("職稱").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("手機").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("E_Mail_R").Value}

            If strRowValue(0) <> "" Then
                strIRow = "代號,序號,種類,聯絡人員,分機,部門,職稱,手機,E_Mail"
                strIValue = "'" & 加工廠代號.Text & "','" & I + 1 & "','P','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "'"
                dbInsert(DNS, "相關聯絡人檔", strIRow, strIValue)
            End If
        Next


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
        Dim objArray_Input() As Object = {加工廠代號, 公司名稱}
        Dim strArray_Input() As String = {"加工廠代號", "公司名稱"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        '加工廠主檔
        strUValue = "分類代碼 = '" & 分類代碼.SelectedValue & "',"
        strUValue &= "加工廠代號 = '" & 加工廠代號.Text & "',"
        strUValue &= "所屬區域代碼 = '" & 所屬區域代碼.SelectedValue & "',"
        strUValue &= "統一編號 = '" & 統一編號.Text & "',"
        strUValue &= "負責人 = '" & 負責人.Text & "',"
        strUValue &= "公司名稱 = '" & 公司名稱.Text & "',"
        strUValue &= "公司抬頭 = '" & 公司抬頭.Text & "',"
        strUValue &= "簡稱 = '" & 簡稱.Text & "',"
        strUValue &= "營業郵遞區號 = '" & 營業郵遞區號.Text & "',"
        strUValue &= "營業地址 = '" & 營業地址.Text & "',"
        strUValue &= "帳單郵遞區號 = '" & 帳單郵遞區號.Text & "',"
        strUValue &= "帳單地址 = '" & 帳單地址.Text & "',"
        strUValue &= "工廠郵遞區號 = '" & 工廠郵遞區號.Text & "',"
        strUValue &= "工廠地址 = '" & 工廠地址.Text & "',"
        strUValue &= "電話1 = '" & 電話1.Text & "',"
        strUValue &= "電話2 = '" & 電話2.Text & "',"
        strUValue &= "電話3 = '" & 電話3.Text & "',"
        strUValue &= "傳真1 = '" & 傳真1.Text & "',"
        strUValue &= "傳真2 = '" & 傳真2.Text & "',"
        strUValue &= "工廠電話1 = '" & 工廠電話1.Text & "',"
        strUValue &= "工廠傳真1 = '" & 工廠傳真1.Text & "',"
        strUValue &= "網址 = '" & 網址.Text & "',"
        strUValue &= "E_Mail = '" & E_Mail.Text & "',"
        strUValue &= "產品項目 = '" & 產品項目.Text & "',"
        strUValue &= "備註1 = '" & 備註1.Text & "',"
        strUValue &= "備註2 = '" & 備註2.Text & "',"
        strUValue &= "備註3 = '" & 備註3.Text & "',"
        strUValue &= "備註4 = '" & 備註4.Text & "',"
        strUValue &= "備註5 = '" & 備註5.Text & "',"
        strUValue &= "備註6 = '" & 備註6.Text & "',"
        strUValue &= "備註7 = '" & 備註7.Text & "',"
        strUValue &= "備註8 = '" & 備註8.Text & "',"
        strUValue &= "備註9 = '" & 備註9.Text & "',"
        strUValue &= "備註10 = '" & 備註10.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "加工廠類型 = 'B'"
        strWValue &= " AND 加工廠代號 = '" & 原加工廠代號.Text & "'"

        blnCheck = dbEdit(DNS, "加工廠主檔", strUValue, strWValue)


        '相關聯絡人檔
        '先刪
        dbDelete(DNS, "相關聯絡人檔", "種類 = 'Q' AND 代號 = '" & 原加工廠代號.Text & "'")
        '後加
        For I As Integer = 0 To Tab3_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab3_DataGridViewR1.Rows(I).Cells("聯絡人員").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("分機").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("部門").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("職稱").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("手機").Value,
                                           Tab3_DataGridViewR1.Rows(I).Cells("E_Mail_R").Value}

            If strRowValue(0) <> "" Then
                strIRow = "代號,序號,種類,聯絡人員,分機,部門,職稱,手機,E_Mail"
                strIValue = "'" & 加工廠代號.Text & "','" & I + 1 & "','Q','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "'"
                dbInsert(DNS, "相關聯絡人檔", strIRow, strIValue)
            End If
        Next


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "加工廠主檔", "加工廠代號 = '" & 原加工廠代號.Text & "'")
        blnCheck = dbDelete(DNS, "相關聯絡人檔", "種類 = 'Q' AND 代號 = '" & 原加工廠代號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Process(strKey1) '加工廠主檔
        OtherContact(strKey1) '相關聯絡人檔
    End Sub
    '加工廠主檔
    Sub Process(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 加工廠主檔"
        strSQL99 &= " WHERE 加工廠類型 = 'B'"
        strSQL99 &= " AND 加工廠代號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            加工廠代號.Text = objDR99("加工廠代號").ToString
            原加工廠代號.Text = objDR99("加工廠代號").ToString
            統一編號.Text = objDR99("統一編號").ToString
            負責人.Text = objDR99("負責人").ToString
            公司名稱.Text = objDR99("公司名稱").ToString
            公司抬頭.Text = objDR99("公司抬頭").ToString
            簡稱.Text = objDR99("簡稱").ToString

            營業郵遞區號.Text = objDR99("營業郵遞區號").ToString
            營業地址.Text = objDR99("營業地址").ToString
            帳單郵遞區號.Text = objDR99("帳單郵遞區號").ToString
            帳單地址.Text = objDR99("帳單地址").ToString
            工廠郵遞區號.Text = objDR99("工廠郵遞區號").ToString
            工廠地址.Text = objDR99("工廠地址").ToString
            電話1.Text = objDR99("電話1").ToString
            電話2.Text = objDR99("電話2").ToString
            電話3.Text = objDR99("電話3").ToString
            傳真1.Text = objDR99("傳真1").ToString
            傳真2.Text = objDR99("傳真2").ToString
            工廠電話1.Text = objDR99("工廠電話1").ToString
            工廠傳真1.Text = objDR99("工廠傳真1").ToString
            網址.Text = objDR99("網址").ToString
            E_Mail.Text = objDR99("E_Mail").ToString
            產品項目.Text = objDR99("產品項目").ToString
            備註1.Text = objDR99("備註1").ToString
            備註2.Text = objDR99("備註2").ToString
            備註3.Text = objDR99("備註3").ToString
            備註4.Text = objDR99("備註4").ToString
            備註5.Text = objDR99("備註5").ToString
            備註6.Text = objDR99("備註6").ToString
            備註7.Text = objDR99("備註7").ToString
            備註8.Text = objDR99("備註8").ToString
            備註9.Text = objDR99("備註9").ToString
            備註10.Text = objDR99("備註10").ToString

            '非文字欄位*****
            分類代碼.SelectedValue = objDR99("分類代碼").ToString
            所屬區域代碼.SelectedValue = objDR99("所屬區域代碼").ToString

            chk地址.Checked = IIf(objDR99("營業地址").ToString = objDR99("帳單地址").ToString And objDR99("營業地址").ToString = objDR99("工廠地址").ToString, True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '相關聯絡人檔
    Sub OtherContact(ByVal strKey1 As String)
        Dim arrRowName() As String

        '相關聯絡人
        strSSQL = "SELECT * FROM 相關聯絡人檔"
        strSSQL &= " WHERE 種類 = 'Q'"
        strSSQL &= " AND 代號 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY 序號 ASC"

        arrRowName = {"聯絡人員", "分機", "部門", "職稱", "手機", "E_Mail"}

        DataGridViewR_DB(Tab3_DataGridViewR1, DNS, strSSQL, arrRowName)
    End Sub
#End Region

#Region "物件異動選擇項"
    '複製地址
    Private Sub chk地址_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chk地址.CheckedChanged
        Select Case chk地址.Checked
            Case True
                帳單郵遞區號.Text = 營業郵遞區號.Text : 帳單地址.Text = 營業地址.Text
                工廠郵遞區號.Text = 營業郵遞區號.Text : 工廠地址.Text = 營業地址.Text
            Case False
                帳單郵遞區號.Text = "" : 帳單地址.Text = ""
                工廠郵遞區號.Text = "" : 工廠地址.Text = ""
        End Select
    End Sub
#End Region
End Class
