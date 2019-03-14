Public Class S04N0005
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
    Private Sub S04N005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    Private Sub S04N005_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S01N0200 As New S_S01N0200

        '開啟視窗
        S_S01N0200.MdiParent = fmMain
        S_S01N0200.Show()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT * FROM 扭力規格主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY 自動編號 asc"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(品名分類, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_DB(直徑規格, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0005'", "一層代碼 ASC")

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"自動編號", "品名分類", "強度級數", "直徑規格", "扭力值1", "扭力值2"}
        Dim arrColWidth() As String = {"100", "100", "160", "120", "120", "120"}

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
        strSSQL = "SELECT * FROM 扭力規格主檔 AS m"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 自動編號 asc"

        '顯示欄位
        arrRowName = {"自動編號", "品名分類", "強度級數", "直徑規格", "扭力值1", "扭力值2"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)


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

        Dim objTextBox1() As TextBox = {扭力值1, 扭力值2}
        Dim objComboBox1() As ComboBox = {品名分類, 強度級數, 直徑規格}
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

            Case 1 '新增模式
                DataGridView.Enabled = False
                品名分類.Focus()

            Case 2 '修改模式
                DataGridView.Enabled = False

            Case 3 '複製模式
                DataGridView.Enabled = False
                品名分類.Focus()
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
        Dim objArray_Input() As Object = {品名分類, 強度級數, 直徑規格, 扭力值1, 扭力值2}
        Dim strArray_Input() As String = {"品名分類", "強度級數", "直徑規格", "扭力值1", "扭力值2"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        'Dim objArray_Numeric() As Object = {調質單價, 滲碳單價}
        'Dim strArray_Numeric() As String = {"調質單價", "滲碳單價"}
        'blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        '代號是否有重複
        ' If dbDataCheck(DNS, "扭力規格主檔", "自動編號 = '" & 自動編號.Text & "'") = True Then MsgBox("系統訊息：【自動編號】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        strIRow = "品名分類, 強度級數, 直徑規格,"
        strIRow &= "扭力值1, 扭力值2,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 品名分類.SelectedValue & "','" & 強度級數.SelectedValue & "','" & 直徑規格.SelectedValue & "',"
        strIValue &= "'" & 扭力值1.Text & "','" & 扭力值2.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "扭力規格主檔", strIRow, strIValue)


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
        Dim objArray_Input() As Object = {品名分類, 強度級數, 直徑規格, 扭力值1, 扭力值2}
        Dim strArray_Input() As String = {"品名分類", "強度級數", "直徑規格", "扭力值1", "扭力值2"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        'Dim objArray_Numeric() As Object = {調質單價, 滲碳單價}
        'Dim strArray_Numeric() As String = {"調質單價", "滲碳單價"}
        'blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****

        '開啟儲存*****        
        strUValue = "品名分類 = '" & 品名分類.SelectedValue & "',"
        strUValue &= "強度級數 = '" & 強度級數.SelectedValue & "',"
        strUValue &= "直徑規格 = '" & 直徑規格.SelectedValue & "',"
        strUValue &= "扭力值1 = '" & 扭力值1.Text & "',"
        strUValue &= "扭力值2 = '" & 扭力值2.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "自動編號 = '" & 自動編號.Text & "'"

        blnCheck = dbEdit(DNS, "扭力規格主檔", strUValue, strWValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "扭力規格主檔", "自動編號 = '" & 自動編號.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Driver(strKey1) '扭力規格主檔        
    End Sub
    '扭力規格主檔
    Sub Driver(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 扭力規格主檔"
        strSQL99 &= " WHERE 自動編號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "建立人員", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "修改人員", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '文字欄位*****
            自動編號.Text = objDR99("自動編號").ToString
            扭力值1.Text = objDR99("扭力值1").ToString
            扭力值2.Text = objDR99("扭力值2").ToString


            '非文字欄位*****

            品名分類.SelectedValue = objDR99("品名分類").ToString
            強度級數.SelectedValue = objDR99("強度級數").ToString
            直徑規格.SelectedValue = objDR99("直徑規格").ToString

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
#End Region

#Region "物件異動選擇項"
    '複製戶籍地址
    Private Sub chk通訊地址_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Select Case chk通訊地址.Checked
        '    Case True : 通訊地址.Text = 戶籍地址.Text
        '    Case False : 通訊地址.Text = ""
        'End Select
    End Sub
#End Region
End Class
