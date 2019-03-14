Public Class S04N0100
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
    Private Sub S04N0100_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S04N0100_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S04N0100 As New S_S03N0110

        '開啟視窗
        S_S04N0100.MdiParent = fmMain
        S_S04N0100.Show()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT m.*, t1.一層名稱 FROM 產品機械性質主檔 AS m"
        strSSQL &= " LEFT JOIN s_一層代碼檔 AS t1 ON m.產品分類代號 = t1.一層代碼 AND t1.類別 = 'S03N0003'"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY m.依據標準 ASC"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(產品分類代號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0003'", "一層名稱 ASC")
        ComboBox_DB(規格代碼起, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "參數1 ASC")
        ComboBox_DB(規格代碼迄, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "參數1 ASC")
        ComboBox_DB(表面規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(心部規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"自動編號", "依據標準", "產品分類", "強度級數", "規格1", "規格2"}
        Dim arrColWidth() As String = {"0", "160", "160", "120", "100", "100"}

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
        strSSQL = "SELECT m.*, t1.一層名稱 FROM 產品機械性質主檔 AS m"
        strSSQL &= " LEFT JOIN s_一層代碼檔 AS t1 ON m.產品分類代號 = t1.一層代碼 AND t1.類別 = 'S03N0003'"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY m.依據標準 ASC"

        '顯示欄位
        arrRowName = {"自動編號", "依據標準", "一層名稱", "強度級數", "規格代碼起", "規格代碼迄"}

        '開啟產生DataGridView
        Me.DataGridView.Columns("自動編號").Visible = True
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)
        'Me.DataGridView.Columns("自動編號").Visible = False


        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {}

        Dim objTextBoxM() As TextBox = {}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {依據標準, 表面硬度, 心部硬度, 保證強度, 伸長率, 斷面收縮, 降伏點強度, 滲碳層, 安全負荷, _
                                        內部抗拉強度, 內部滲碳層, 內部心部硬度, 內部表面硬度, _
                                        備註, 抗拉強度}
        Dim objComboBox1() As ComboBox = {產品分類代號, 規格代碼起, 規格代碼迄, 表面規格, 心部規格, 強度級數}
        Dim objRadioButton1() As RadioButton = {頭部敲擊1, 頭部敲擊2, 頭部敲擊3, 頭部敲擊4}
        Dim objDateTimePicker1() As DateTimePicker = {}


        DataGridViewR_Control(objDataGridViewR, butStatus)
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

                頭部敲擊1.Checked = True
                依據標準.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                依據標準.Focus()
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
        Dim objArray_Input() As Object = {依據標準, 產品分類代號, 規格代碼起, 規格代碼迄, 強度級數}
        Dim strArray_Input() As String = {"依據標準", "產品分類", "規格代碼起", "規格代碼迄", "強度級數"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '代號是否有重複
        If dbDataCheck(DNS, "產品機械性質主檔", "依據標準 = '" & 依據標準.Text & "' AND 產品分類代號 = '" & 產品分類代號.SelectedValue & "' AND 規格代碼起 = '" & 規格代碼起.Text & "' AND 規格代碼迄 = '" & 規格代碼迄.Text & "' AND 強度級數 = '" & 強度級數.Text & "'") = True Then MsgBox("系統訊息：【該產品機械性質】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        Dim strValue1 As String = ""
        If 頭部敲擊1.Checked = True Then strValue1 = ""
        If 頭部敲擊2.Checked = True Then strValue1 = "5"
        If 頭部敲擊3.Checked = True Then strValue1 = "10"
        If 頭部敲擊4.Checked = True Then strValue1 = "15"

        Dim 規格對照起 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼起.SelectedValue & "'")
        Dim 規格對照迄 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼迄.SelectedValue & "'")

        strIRow = "依據標準,產品分類代號,規格代碼起,規格代碼迄,強度級數,"
        strIRow &= "表面硬度,心部硬度,抗拉強度,保證強度,伸長率,"
        strIRow &= "斷面收縮,降伏點強度,滲碳層,安全負荷,頭部敲擊,"
        strIRow &= "內部抗拉強度,內部滲碳層,內部表面硬度,內部心部硬度,"
        strIRow &= "表面規格,心部規格,規格對照起,規格對照迄,"
        strIRow &= "備註,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 依據標準.Text & "','" & 產品分類代號.SelectedValue & "','" & 規格代碼起.SelectedValue & "','" & 規格代碼迄.SelectedValue & "','" & 強度級數.SelectedValue & "',"
        strIValue &= "'" & 表面硬度.Text & "','" & 心部硬度.Text & "','" & 抗拉強度.Text & "','" & 保證強度.Text & "','" & 伸長率.Text & "',"
        strIValue &= "'" & 斷面收縮.Text & "','" & 降伏點強度.Text & "','" & 滲碳層.Text & "','" & 安全負荷.Text & "','" & strValue1 & "',"
        strIValue &= "'" & 內部抗拉強度.Text & "','" & 內部滲碳層.Text & "','" & 內部表面硬度.Text & "','" & 內部心部硬度.Text & "',"
        strIValue &= "'" & 表面規格.SelectedValue & "','" & 心部規格.SelectedValue & "','" & 規格對照起 & "','" & 規格對照迄 & "',"
        strIValue &= "'" & 備註.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "產品機械性質主檔", strIRow, strIValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return (blnCheck)
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入         
        Dim objArray_Input() As Object = {依據標準, 產品分類代號, 規格代碼起, 規格代碼迄, 強度級數}
        Dim strArray_Input() As String = {"依據標準", "產品分類", "規格代碼起", "規格代碼迄", "強度級數"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存***** 
        Dim strValue1 As String = ""
        If 頭部敲擊1.Checked = True Then strValue1 = ""
        If 頭部敲擊2.Checked = True Then strValue1 = "5"
        If 頭部敲擊3.Checked = True Then strValue1 = "10"
        If 頭部敲擊4.Checked = True Then strValue1 = "15"

        Dim 規格對照起 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼起.SelectedValue & "'")
        Dim 規格對照迄 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼迄.SelectedValue & "'")


        strUValue = "依據標準 = '" & 依據標準.Text & "',"
        strUValue &= "產品分類代號 = '" & 產品分類代號.SelectedValue & "',"
        strUValue &= "規格代碼起 = '" & 規格代碼起.Text & "',"
        strUValue &= "規格代碼迄 = '" & 規格代碼迄.Text & "',"
        strUValue &= "強度級數 = '" & 強度級數.Text & "',"
        strUValue &= "表面硬度 = '" & 表面硬度.Text & "',"
        strUValue &= "心部硬度 = '" & 心部硬度.Text & "',"
        strUValue &= "抗拉強度 = '" & 抗拉強度.Text & "',"
        strUValue &= "保證強度 = '" & 保證強度.Text & "',"
        strUValue &= "伸長率 = '" & 伸長率.Text & "',"
        strUValue &= "斷面收縮 = '" & 斷面收縮.Text & "',"
        strUValue &= "降伏點強度 = '" & 降伏點強度.Text & "',"
        strUValue &= "滲碳層 = '" & 滲碳層.Text & "',"
        strUValue &= "安全負荷 = '" & 安全負荷.Text & "',"
        strUValue &= "頭部敲擊 = '" & strValue1 & "',"
        strUValue &= "內部抗拉強度 = '" & 內部抗拉強度.Text & "',"
        strUValue &= "內部滲碳層 = '" & 內部滲碳層.Text & "',"
        strUValue &= "內部表面硬度 = '" & 內部表面硬度.Text & "',"
        strUValue &= "內部心部硬度 = '" & 內部心部硬度.Text & "',"
        strUValue &= "備註 = '" & 備註.Text & "',"
        strUValue &= "規格對照起 = '" & 規格對照起 & "',"
        strUValue &= "規格對照迄 = '" & 規格對照迄 & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "自動編號 = '" & txtID.Text & "'"

        blnCheck = dbEdit(DNS, "產品機械性質主檔", strUValue, strWValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "產品機械性質主檔", "自動編號 = '" & txtID.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Machine(strKey1) '產品機械性質主檔        
    End Sub
    '產品機械性質主檔
    Sub Machine(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 產品機械性質主檔"
        strSQL99 &= " WHERE 自動編號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            txtID.Text = objDR99("自動編號").ToString
            依據標準.Text = objDR99("依據標準").ToString
            規格代碼起.SelectedValue = objDR99("規格代碼起").ToString
            規格代碼迄.SelectedValue = objDR99("規格代碼迄").ToString
            強度級數.SelectedValue = objDR99("強度級數").ToString
            表面規格.SelectedValue = objDR99("表面規格").ToString
            心部規格.SelectedValue = objDR99("心部規格").ToString
            表面硬度.Text = objDR99("表面硬度").ToString
            心部硬度.Text = objDR99("心部硬度").ToString
            抗拉強度.Text = objDR99("抗拉強度").ToString
            保證強度.Text = objDR99("保證強度").ToString
            伸長率.Text = objDR99("伸長率").ToString
            斷面收縮.Text = objDR99("斷面收縮").ToString
            降伏點強度.Text = objDR99("降伏點強度").ToString
            滲碳層.Text = objDR99("滲碳層").ToString
            安全負荷.Text = objDR99("安全負荷").ToString
            內部抗拉強度.Text = objDR99("內部抗拉強度").ToString
            內部滲碳層.Text = objDR99("內部滲碳層").ToString
            內部心部硬度.Text = objDR99("內部心部硬度").ToString
            內部表面硬度.Text = objDR99("內部表面硬度").ToString
            備註.Text = objDR99("備註").ToString


            '非文字欄位*****
            產品分類代號.SelectedValue = objDR99("產品分類代號").ToString

            頭部敲擊1.Checked = IIf(objDR99("頭部敲擊").ToString = "", True, False)
            頭部敲擊2.Checked = IIf(objDR99("頭部敲擊").ToString = "5", True, False)
            頭部敲擊3.Checked = IIf(objDR99("頭部敲擊").ToString = "10", True, False)
            頭部敲擊4.Checked = IIf(objDR99("頭部敲擊").ToString = "15", True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
#End Region
End Class
