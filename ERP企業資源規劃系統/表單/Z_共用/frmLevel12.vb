Public Class frmLevel12
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
    Private Sub frmLevel12_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {butFind, butSearch}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next
        DataGridView_Basic() 'DataGridView初始化
        '頁面
        Me.Text = strPageName(txtPage.Text) & "基本對照資料維護"
        txtDataGridViewTitle.Text = txtPageName.Text & txtDataGridViewTitle.Text
        Me.TabPage1.Text = txtPageName.Text & Me.TabPage1.Text

        ComboBoxList() 'Combobox初始化

        FillData("") '載入資料集        
    End Sub
    Private Sub frmLevel12_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT * FROM s_一層代碼檔"
        strSSQL &= " WHERE 1=1 AND 類別 = '" & txtPage.Text & "'"
        strSSQL &= " ORDER BY 一層代碼 ASC"
        SqlToExcel(DNS, strSSQL)
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"代碼", "名稱", "其他1", "其他2", "其他3"}
        Dim arrColWidth() As String = {"100", "300", "120", "120", "100"}

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
        strSSQL = "SELECT * FROM s_一層代碼檔"
        strSSQL &= " WHERE 1=1 AND 類別 = '" & txtPage.Text & "'"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 一層代碼 ASC"

        '顯示欄位
        arrRowName = {"一層代碼", "一層名稱", "參數1", "參數2", "參數3"}

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

        Dim objTextBoxM() As TextBox = {M_TextBox1}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        Dim objTextBox1() As TextBox = {M_TextBox2, M_TextBox3, M_TextBox4, M_TextBox5}
        Dim objComboBox1() As ComboBox = {}
        Dim objRadioButton1() As RadioButton = {}
        Dim objDateTimePicker1() As DateTimePicker = {}


        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)
        Basic_Control(objTextBox1, objComboBox1, objRadioButton1, objDateTimePicker1, butStatus)


        '0:一般模式 1:新增模式 2:修改模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True


            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = False

                If txtPage.Text = "S03N0001" Then
                    M_TextBox1.Text = ERP_AutoNo_產品編號(DNS)

                End If
                M_TextBox1.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = False

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = False

                M_TextBox1.Focus()
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
        Dim objArray() As Object = {M_TextBox1, M_TextBox2}
        Dim strArray() As String = {"設定代碼", "顯示名稱"}
        blnCheck = blnInputCheck(objArray, strArray) : If blnCheck = False Then Return False : Exit Function

        '代號是否有重複
        If dbDataCheck(DNS, "s_一層代碼檔", "類別 = '" & txtPage.Text & "' AND 一層代碼 = '" & M_TextBox1.Text & "'") = True Then MsgBox("系統訊息：【" & txtPageName.Text & "代碼】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : Return blnCheck : Exit Function
        '防呆結束*****


        '開啟儲存*****
        strIRow = "一層代碼,一層名稱,參數1,參數2,參數3,類別,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & M_TextBox1.Text & "','" & M_TextBox2.Text & "','" & M_TextBox3.Text & "','" & M_TextBox4.Text & "','" & M_TextBox5.Text & "','" & txtPage.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "s_一層代碼檔", strIRow, strIValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        Dim objArray() As Object = {M_TextBox1, M_TextBox2}
        Dim strArray() As String = {"設定代碼", "顯示名稱"}
        blnCheck = blnInputCheck(objArray, strArray) : If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        strUValue = "一層名稱 = '" & M_TextBox2.Text & "',"
        strUValue &= "參數1 = '" & M_TextBox3.Text & "',"
        strUValue &= "參數2 = '" & M_TextBox4.Text & "',"
        strUValue &= "參數3 = '" & M_TextBox5.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "類別 = '" & txtPage.Text & "'"
        strWValue &= " AND 一層代碼 = '" & M_TextBox1.Text & "'"

        blnCheck = dbEdit(DNS, "s_一層代碼檔", strUValue, strWValue)


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "s_一層代碼檔", "類別 = '" & txtPage.Text & "' AND 一層代碼 = '" & M_TextBox1.Text & "'")

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Level1(strKey1) '一層代碼檔
    End Sub
    '一層代碼檔
    Sub Level1(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM s_一層代碼檔"
        strSQL99 &= " WHERE 類別 = '" & txtPage.Text & "'"
        strSQL99 &= " AND 一層代碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            M_TextBox1.Text = objDR99("一層代碼").ToString
            M_TextBox2.Text = objDR99("一層名稱").ToString
            M_TextBox3.Text = objDR99("參數1").ToString
            M_TextBox4.Text = objDR99("參數2").ToString
            M_TextBox5.Text = objDR99("參數3").ToString
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub

    '頁面種類名稱
    Function strPageName(ByVal strPage As String) As String
        Dim strName As String = ""

        Select Case strPage
            Case "S01N0006"
                strName = "班制" : 編碼說明.Text = ""
                txtOther1.Text = "上班時間" : txtOther2.Text = "下班時間"

            Case "S03N0001"
                strName = "產品資料" : 編碼說明.Text = ""
                txtOther1.Text = "其他1" : txtOther2.Text = "其他2"
            Case "S03N0003"
                strName = "產品分類" : 編碼說明.Text = ""
                txtOther1.Text = "對照數字" : txtOther2.Text = "抽樣數值"
            Case "S03N0004"
                strName = "規格對照" : 編碼說明.Text = ""
                txtOther1.Text = "對照數字" : txtOther2.Text = "抽樣數" : txtOther3.Text = "運費費率"
            Case "S03N0005"
                strName = "長度規格" : 編碼說明.Text = ""
                txtOther1.Text = "對照數字" : txtOther2.Text = "其他"
            Case "S03N0007"
                strName = "規格對照" : 編碼說明.Text = ""
                txtOther1.Text = "其他1" : txtOther2.Text = "其他2"
            Case "S04N0002"
                strName = "強度對照" : 編碼說明.Text = ""
                txtID.Text = "等級代號" : txtName.Text = "等級名稱"
                txtOther1.Text = "其他1" : txtOther2.Text = "其他2"
            Case "S04N0003"
                strName = "硬度規格" : 編碼說明.Text = ""
                txtName.Text = "表面規格"
                txtOther1.Text = "心部規格" : txtOther2.Text = "其他"
                DataGridView.Columns(1).HeaderText = "表面規格"
                DataGridView.Columns(2).HeaderText = "心部規格"
                DataGridView.Columns(3).HeaderText = "其他"
            Case "S03N0011"
                strName = "各爐產能設定" : 編碼說明.Text = ""
                txtID.Text = "爐號" : txtName.Text = "爐號名稱"
                txtOther1.Text = "是否啓用" : txtOther2.Text = "其他2"

            Case "S01N0700"
                strName = "運費單價設定" : 編碼說明.Text = ""
                txtID.Text = "運費單價代號" : txtName.Text = "運費單價名稱"
                txtOther1.Text = "運費單價" : txtOther2.Text = "其他2"


        End Select

        txtPageName.Text = strName

        Return strName
    End Function
#End Region
End Class
