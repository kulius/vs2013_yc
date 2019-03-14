Public Class S03N0200
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
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0200_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        'BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()
        Me.WindowState = FormWindowState.Maximized

        '按鍵
        Dim btnItems() As ToolStripButton = {butAddNew, butCopy, butDelete, butFind, butSearch}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        'DataGridView_Basic() 'DataGridView初始化
        'DataGridView1_Basic()

        's回火1.Text = "0"
        's回火2.Text = "999"


        'FillData("") '載入資料集
        TabControl.SelectedTab = Me.TabPage1
        txtAutoComplete()
    End Sub
    Private Sub S03N0200_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    Private Sub S03N0200_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
        'If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
        'If e.KeyCode = Keys.Down Then SendKeys.Send("{tab}")
        'If e.KeyCode = Keys.Up Then SendKeys.Send("+{TAB}")
    End Sub

    Private Sub S03N0200_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView1.Focused Then
            intRow = DataGridView1.CurrentCell.RowIndex
            FlagMoveSeat1(0)
        End If

        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            FlagMoveSeat(0)
        End If
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 工令號碼.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(工令號碼.Text)
            Return False
        Else
            Return True
        End If

    End Function
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    '自動完成
    Public Sub txtAutoComplete()
        Dim namesCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        strSQL99 &= " WHERE 類別 = 'S04N0004'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.HasRows Then
            While objDR99.Read
                namesCollection.Add(objDR99("一層代碼").ToString)
            End While
        End If

        objDR99.Close()

        品管備註1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        品管備註1.AutoCompleteSource = AutoCompleteSource.CustomSource
        品管備註1.AutoCompleteCustomSource = namesCollection
        品管備註2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        品管備註2.AutoCompleteSource = AutoCompleteSource.CustomSource
        品管備註2.AutoCompleteCustomSource = namesCollection
        品管備註3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        品管備註3.AutoCompleteSource = AutoCompleteSource.CustomSource
        品管備註3.AutoCompleteCustomSource = namesCollection

        Dim namesCollection1 As AutoCompleteStringCollection = New AutoCompleteStringCollection

        strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        strSQL99 &= " WHERE 類別 = 'S04N0001'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.HasRows Then
            While objDR99.Read
                namesCollection1.Add(objDR99("一層代碼").ToString)
            End While
        End If

        objDR99.Close()

        製造備註1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註1.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註1.AutoCompleteCustomSource = namesCollection1
        製造備註2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註2.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註2.AutoCompleteCustomSource = namesCollection1
        製造備註3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註3.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註3.AutoCompleteCustomSource = namesCollection1

        Dim namesCollection2 As AutoCompleteStringCollection = New AutoCompleteStringCollection

        'strSQL99 = "SELECT  注意事項1 FROM 進貨單主檔"
        'strSQL99 &= " union SELECT  注意事項2 FROM 進貨單主檔 "
        'strSQL99 &= " union SELECT  注意事項3 FROM 進貨單主檔 "


        'objCmd99 = New SqlCommand(strSQL99, objCon99)
        'objDR99 = objCmd99.ExecuteReader

        'If objDR99.HasRows Then
        '    While objDR99.Read
        '        namesCollection1.Add(objDR99("注意事項1").ToString)
        '    End While
        'End If

        'objDR99.Close()

        '注意事項1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '注意事項1.AutoCompleteSource = AutoCompleteSource.CustomSource
        '注意事項1.AutoCompleteCustomSource = namesCollection1
        '注意事項2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '注意事項2.AutoCompleteSource = AutoCompleteSource.CustomSource
        '注意事項2.AutoCompleteCustomSource = namesCollection1
        '注意事項3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '注意事項3.AutoCompleteSource = AutoCompleteSource.CustomSource
        '注意事項3.AutoCompleteCustomSource = namesCollection1
    End Sub
#End Region
#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "簡稱+' '+客戶代號", "往來否 = 'Y'", "公司名稱 ASC")


        ComboBox_DB(s進度1, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = '狀態'", "一層代碼 ASC")


        ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        ComboBox_DB(品管人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")

        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        'ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        'ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")
        ' ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0009'", "一層代碼 ASC")
        'ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        'ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(預排爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        ComboBox_DGDB(爐號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        ComboBox_DGDB(爐號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")
        ' ComboBox_GG(運費種類, ",含運,自付", ",含運費,自付運費")
    End Sub
    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"客戶簡稱", "爐號", "進貨日期", "工令號碼", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "狀態"}
        Dim arrColWidth() As String = {"120", "60", "100", "100", "100", "100", "100", "100", "100", "100", "100", "100"}

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
    '點二下切換至資料顯示
    Private Sub DataGridView_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView.DoubleClick
        TabControl.SelectedTab = Me.TabPage2
    End Sub

    'DataGridView1初始化
    Sub DataGridView1_Basic()
        '欄位名稱
        Dim arrColName() As String = {"爐號", "序號", "客戶簡稱", "工令號碼", "進貨日期", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "表面硬度", "心部硬度", "線材爐號"}
        Dim arrColWidth() As String = {"40", "40", "100", "60", "60", "100", "100", "100", "100", "60", "60", "60", "100", "100", "60"}



        DataGridView1.ColumnCount = arrColName.Length
        DataGridView1.RowCount = 1

        For J As Integer = 0 To arrColName.Length - 1 Step 1
            With DataGridView1
                .Columns(J).Name = arrColName(J) '欄位名稱
                .Columns(J).Width = arrColWidth(J) '欄位寬度
            End With
        Next
    End Sub
    '爐內進貨選擇欄位值
    Private Sub DataGridView1_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        intCol = e.ColumnIndex
        intRow = e.RowIndex

        FlagMoveSeat1(0) '讀取值
    End Sub
    '爐內進貨點二下切換至資料顯示
    Private Sub DataGridView1_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView1.DoubleClick
        TabControl.SelectedTab = Me.TabPage2
    End Sub
#End Region

#Region "共用底層"
    '載入資料
    Public Overrides Sub FillData(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        '查詢語法
        strSSQL = "SELECT t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,裝袋合計 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",客戶簡稱 = case when t1.簡稱<>t7.簡稱 then t7.簡稱+'-'+t1.簡稱 else t1.簡稱 end ,t7.簡稱"
        strSSQL &= ",產品名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,t5.一層名稱 AS 狀態,m.表面處理代碼 AS 表面 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        strSSQL &= " WHERE 1=1 and 狀態<='2' and 狀態 >=0 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 工令號碼 DESC"

        '顯示欄位

        arrRowName = {"客戶簡稱", "爐號", "進貨日期", "工令號碼", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "狀態", "表面硬度", "心部硬度", "線材爐號"}
        '"客戶", "工令號碼", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"
        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)

        '計算合計
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT isnull(sum(淨重),0) as 淨重  FROM 進貨單主檔 m"
        strSQL99 &= " WHERE 1=1 and 狀態<='2' and 狀態 >=0"
        strSQL99 &= strSearch

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            Try

            Catch ex As Exception

            End Try
            lb重量合計1.Text = "重量合計：" + CInt(objDR99("淨重")).ToString("#,##0")
        End If


        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
        '異動狀態*****



        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    '載入資料
    Public Sub FillData1(ByVal strSearch As String)
        Dim blnCheck As Boolean = False '是否有查詢到資料
        Dim arrRowName() As String

        '查詢語法
        strSSQL = "SELECT t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温 "
        strSSQL &= ",客戶簡稱 = case when t1.簡稱<>t7.簡稱 then t7.簡稱+'-'+t1.簡稱 else t1.簡稱 end ,t7.簡稱"
        strSSQL &= ",產品名稱 AS 品名,m.規格代碼+'X'+isnull(m.長度代碼,'')+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面,t9.簡稱 as 次加工廠 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t9 ON m.次加工廠代號1 = t9.加工廠代號"
        strSSQL &= " WHERE 1=1 and 狀態<='2' and 狀態 >=0 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 序號,工令號碼"

        '顯示欄位

        arrRowName = {"爐號", "序號", "客戶簡稱", "工令號碼", "進貨日期", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "表面硬度", "心部硬度", "線材爐號", "應對交期", "次加工廠"}
        'arrRowName = {"爐號", "序號", "客戶簡稱", "工令號碼", "進貨日期", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "表面硬度", "心部硬度", "線材爐號"}

        blnCheck = DataGridView_DB(DataGridView1, DNS, strSSQL, arrRowName, txtCount)

        '計算合計
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT isnull(sum(淨重),0) as 淨重  FROM 進貨單主檔 m"
        strSQL99 &= " WHERE 1=1 and 狀態<='2' and 狀態 >=0 and 序號<>99.9"
        strSQL99 &= strSearch

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            lb重量合計2.Text = "重量合計：" + CInt(objDR99("淨重")).ToString("#,##0")
        End If


        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標

        '異動後初始化*****
        'SetControls(0)
        FlagMoveSeat1(0)
    End Sub

    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)

        Set_Control_RW(TabControl, butStatus)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                'TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

            Case 1 '新增模式
                'TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False


            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                流量.Focus()

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False

                '時間.Text = NowTime() : 開單人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                '工令號碼.Text = ERP_AutoNo(DNS, strPage, "進貨單主檔", "工令號碼")
                '工令號碼.Focus()
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
                Dim strKey As String = DataGridView.Rows(intRow).Cells(3).Value.ToString

                '停在選定之儲存格
                ShowData(strKey)
                txtSeat.Text = intRow + 1 '目前位置
                DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
            Catch ex As Exception

            End Try
        End If
    End Sub
    '移動DataGridView指標
    Public Sub FlagMoveSeat1(ByVal strStatus As Integer)
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
        If DataGridView1.Rows.Count > 0 Then
            Try
                '關鍵值
                Dim strKey As String = DataGridView1.Rows(intRow).Cells(3).Value.ToString

                '停在選定之儲存格
                ShowData(strKey)
                txtSeat.Text = intRow + 1 '目前位置
                DataGridView1.CurrentCell = DataGridView1.Item(intCol, intRow) '選取位置
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
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入
        'Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號, 開單人員, 司機代號}
        'Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號", "開單人員", "司機代號"}
        'blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重}
        Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重"}
        blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****

        '開啟儲存*****
        '客戶主檔
        strUValue = "製造日期 = '" & strSystemToDate(製造日期.Value.ToShortDateString) & "',"
        strUValue &= "製造時間 = '" & 製造時間.Text & "',"
        strUValue &= "操作人員 = '" & 操作人員.SelectedValue & "',"
        strUValue &= "品管人員 = '" & 品管人員.SelectedValue & "',"
        strUValue &= "班別 = '" & 班別.SelectedValue & "',"
        strUValue &= "流量 = '" & 流量.Text & "',"
        strUValue &= "CP值 = '" & CP值.Text & "',"
        strUValue &= "氨值1 = '" & 氨值1.Text & "',"
        strUValue &= "氨值2 = '" & 氨值2.Text & "',"
        strUValue &= "氨值3 = '" & 氨值3.Text & "',"
        strUValue &= "氨值4 = '" & 氨值4.Text & "',"
        strUValue &= "加熱爐1 = '" & 加熱爐1.Text & "',"
        strUValue &= "加熱爐2 = '" & 加熱爐2.Text & "',"
        strUValue &= "加熱爐3 = '" & 加熱爐3.Text & "',"
        strUValue &= "加熱爐4 = '" & 加熱爐4.Text & "',"
        strUValue &= "加熱爐5 = '" & 加熱爐5.Text & "',"
        strUValue &= "加熱爐6 = '" & 加熱爐6.Text & "',"
        strUValue &= "加熱爐7 = '" & 加熱爐7.Text & "',"
        strUValue &= "加熱爐8 = '" & 加熱爐8.Text & "',"
        strUValue &= "加熱爐油溫 = '" & 加熱爐油溫.Text & "',"
        strUValue &= "加熱爐速度 = '" & 加熱爐速度.Text & "',"
        strUValue &= "回火爐1 = '" & 回火爐1.Text & "',"
        strUValue &= "回火爐2 = '" & 回火爐2.Text & "',"
        strUValue &= "回火爐3 = '" & 回火爐3.Text & "',"
        strUValue &= "回火爐4 = '" & 回火爐4.Text & "',"
        strUValue &= "回火爐5 = '" & 回火爐5.Text & "',"
        strUValue &= "回火爐6 = '" & 回火爐6.Text & "',"
        strUValue &= "回火溫度 = '" & 回火爐2.Text & "',"
        strUValue &= "回火爐速度 = '" & 回火爐速度.Text & "',"
        strUValue &= "注意事項1 = '" & 注意事項1.Text & "',"
        strUValue &= "注意事項2 = '" & 注意事項2.Text & "',"
        strUValue &= "注意事項3 = '" & 注意事項3.Text & "',"
        strUValue &= "品管備註1 = '" & 品管備註1.Text & "',"
        strUValue &= "品管備註2 = '" & 品管備註2.Text & "',"
        strUValue &= "品管備註3 = '" & 品管備註3.Text & "',"
        strUValue &= "製造備註1 = '" & 製造備註1.Text & "',"
        strUValue &= "製造備註2 = '" & 製造備註2.Text & "',"
        strUValue &= "製造備註3 = '" & 製造備註3.Text & "',"
        strUValue &= "存放位置 = '" & 存放位置.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)



        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim str As String = ""
        If s爐號.Text <> "" Then
            str = " and m.預排爐號 ='" + s爐號.Text + "'"
        End If

        FillData1(str)

        For i As Integer = 0 To DataGridView1.RowCount() - 1
            If 工令號碼.Text = DataGridView1.Rows(i).Cells(3).Value Then
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)
                Exit For
            End If
        Next


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
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Machine(strKey1) '產品機械性質主檔        
    End Sub
    '主檔
    Sub Machine(ByVal strKey1 As String)
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

            ControlReadData(TabControl, objDR99)

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標

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
    End Sub
    '分爐排程查詢
    Private Sub btn分爐排程查詢_Click(sender As System.Object, e As System.EventArgs) Handles btn分爐排程查詢.Click
        Dim str As String
        str = " "
        If s回火1.Text <> "" Then
            str &= " and m.回火爐2 >='" + s回火1.Text + "'"
        End If
        If s回火2.Text <> "" Then
            str &= " and m.回火爐2 <='" + s回火2.Text + "'"
        End If
        If s客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If

        If s爐號1.Text <> "" Then
            str &= " and m.預排爐號 ='" + s爐號1.Text + "'"
        End If

        If s線材爐號1.Text <> "" Then
            str &= " and m.線材爐號 ='" + s線材爐號1.Text + "'"
        End If

        If s進度1.SelectedValue <> "" Then
            If s進度1.SelectedValue <> "0" Then
                str &= " and m.狀態 ='" + s進度1.SelectedValue + "'"
            End If
        End If


        FillData(str)
    End Sub
    '爐內進貨查詢
    Private Sub s爐號_TextChanged(sender As System.Object, e As System.EventArgs) Handles s爐號.TextChanged
        If s爐號.Text <> "" Then
            Dim str As String = ""
            If s爐號.Text <> "" Then
                str = " and m.預排爐號 ='" + s爐號.Text + "'"
            End If

            FillData1(str)
            TabControl.SelectedTab = Me.TabPage3
        End If
    End Sub
#End Region

#Region "物件異動選擇項"
    Private Sub s客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s客戶代號.SelectedIndexChanged
        Try
            s客戶代號1.Text = s客戶代號.SelectedValue
        Catch ex As Exception

        End Try

    End Sub
    Private Sub s客戶代號1_Leave(sender As System.Object, e As System.EventArgs) Handles s客戶代號1.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代號1.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代號1.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub
    Private Sub 加熱爐2_Leave(sender As System.Object, e As System.EventArgs) Handles 加熱爐2.Leave
        Try
            加熱爐1.Text = CStr(CInt(加熱爐2.Text) - 30)
            加熱爐3.Text = 加熱爐2.Text
            加熱爐4.Text = 加熱爐2.Text
            加熱爐5.Text = 加熱爐2.Text
            加熱爐6.Text = 加熱爐2.Text
            加熱爐7.Text = 加熱爐2.Text
            加熱爐8.Text = 加熱爐2.Text
            If 預排爐號.Text = "E" Then
                加熱爐3.Text = ""
                加熱爐4.Text = ""
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub 回火爐2_Leave(sender As System.Object, e As System.EventArgs) Handles 回火爐2.Leave
        Try
            回火爐1.Text = CStr(CInt(回火爐2.Text) - 30)
            回火爐3.Text = 回火爐2.Text
            回火爐4.Text = 回火爐2.Text
            回火爐5.Text = 回火爐2.Text
            回火爐6.Text = 回火爐2.Text

            If (預排爐號.Text = "L") Or (預排爐號.Text = "M") Then
                回火爐1.Text = CStr(CInt(回火爐2.Text) - 60)
            End If
        Catch ex As Exception

        End Try



    End Sub
#End Region

    Private Sub btn重排_Click(sender As System.Object, e As System.EventArgs) Handles btn重排.Click
        Dim str As String = ""
        If s爐號.Text <> "" Then
            str = " and m.預排爐號 ='" + s爐號.Text + "'"
        End If

        FillData1(str)
    End Sub
    '編輯序號直接更新
    Private Sub DataGridView1_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim view As DataGridView = CType(sender, DataGridView)

        'If e.RowIndex = view.RowCount - 1 Then
        '    Return
        'End If

        'MsgBox(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString())
        Try
            Dim value As String = ""
            Dim data As Single = 0
            Select Case e.ColumnIndex
                Case 1
                    value = view.CurrentCell.Value
                    If value = "" Then
                        MsgBox("不能為空")
                        view.CurrentCell.Value = 99
                    Else
                        strUValue = "序號 = '" & value & "',"
                        strUValue &= "狀態 = '" & "2" & "'"
                        strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                        dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

                        If value = "99.9" Then
                            strUValue = "序號 = '" & value & "',"
                            strUValue &= "狀態 = '" & "1" & "'"
                            strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                            dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
                        End If

                        If value < "1" Then
                            strUValue = "序號 = '" & value & "',"
                            strUValue &= "狀態 = '" & "1" & "'"
                            strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                            dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
                        End If

                    End If

                Case 0
                    value = view.CurrentCell.Value
                    strUValue = "預排爐號 = '" & value & "'"
                    strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                    dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

                Case 15
                    value = view.CurrentCell.Value
                    strUValue = "應對交期 = '" & value & "'"
                    strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                    dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

                    'Case 9
                    '    value = view.CurrentCell.Value
                    '    strUValue = "回火爐2 = '" & value & "',"
                    '    strUValue &= "回火爐1 = '" & value - 30 & "',"
                    '    strUValue &= "回火爐3 = '" & value & "',"
                    '    strUValue &= "回火爐4 = '" & value & "',"
                    '    strUValue &= "回火爐5 = '" & value & "',"
                    '    strUValue &= "回火爐6 = '" & value & "'"
                    '    strWValue = "工令號碼 = '" & DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                    '    dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
            End Select
        Catch ex As Exception

        End Try



    End Sub

    Private Sub btn重編_Click(sender As System.Object, e As System.EventArgs) Handles btn重編.Click
        Dim str As String = ""
        If s爐號.Text <> "" Then
            str = " and 預排爐號 ='" + s爐號.Text + "'"
        End If

        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 進貨單主檔 m"
        strSQL99 &= " WHERE 1=1 and 狀態<='2' and 狀態 >=0"
        strSQL99 &= " and 序號 <> 99.9"
        strSQL99 &= str
        strSQL99 &= " ORDER BY 序號"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader
        Dim i As Integer = 0
        While objDR99.Read()
            i = i + 1
            strUValue = "序號 = '" & i.ToString & "',"
            strUValue &= "狀態 = '" & "2" & "'"
            strWValue = "工令號碼 = '" & objDR99("工令號碼").ToString & "'"
            dbEdit(DNS, "進貨單主檔", strUValue, strWValue)
        End While


        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標

        FillData1(str)
    End Sub

    '爐內排程 修改後立即存檔
    Private Sub DataGridView_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellEndEdit
        Dim view As DataGridView = CType(sender, DataGridView)

        'If e.RowIndex = view.RowCount - 1 Then
        '    Return
        'End If

        'MsgBox(DataGridView1.Rows(e.RowIndex).Cells(3).Value.ToString())

        Try
            Dim value As String = ""
            Dim data As Single = 0
            Select Case e.ColumnIndex
                Case 1
                    value = view.CurrentCell.Value
                    strUValue = "預排爐號 = '" & value & "'"
                    strWValue = "工令號碼 = '" & DataGridView.Rows(e.RowIndex).Cells(3).Value.ToString() & "'"
                    dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

            End Select
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btuSOld_Click(sender As System.Object, e As System.EventArgs) Handles btuSOld.Click
        Dim S_S03N0120_1 As New S_S03N0120_1

        '開啟視窗
        S_S03N0120_1.MdiParent = fmMain
        S_S03N0120_1.sPageName = "S03N0200"
        S_S03N0120_1.Show()

        For Each MdiChildForm As Object In My.Forms.fmMain.MdiChildren
            If MdiChildForm.Name = "S_S03N0120_1" Then
                If CK1.Checked Then
                    MdiChildForm.產品代碼.SelectedValue = 產品代碼.SelectedValue
                End If
                If CK2.Checked Then
                    MdiChildForm.規格代碼.SelectedValue = 規格代碼.SelectedValue
                End If
                If CK3.Checked Then
                    MdiChildForm.長度代碼.SelectedValue = 長度代碼.Text
                End If
                If CK1.Checked Then
                    MdiChildForm.品名分類代碼.SelectedValue = 品名分類代碼.SelectedValue
                End If
                If CK5.Checked Then
                    MdiChildForm.加工方式代碼.SelectedValue = 加工方式代碼.SelectedValue
                End If
                If CK6.Checked Then
                    MdiChildForm.材質代碼.SelectedValue = 材質代碼.SelectedValue
                End If

                If CK7.Checked Then
                    MdiChildForm.強度級數.SelectedValue = 強度級數.SelectedValue
                End If

                If CK8.Checked Then
                    MdiChildForm.線材爐號.Text = 線材爐號.Text
                End If

                'MdiChildForm.btnSerData.Click()
            End If
        Next

    End Sub

    Private Sub 未交明細_Click(sender As System.Object, e As System.EventArgs) Handles 未交明細.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = s客戶代號.SelectedValue
        PreviewReport.lblReportFile.Text = "未交明細.frx"
        PreviewReport.lblRepKey1.Text = s回火1.Text
        PreviewReport.lblRepKey2.Text = s回火2.Text
        PreviewReport.lblRepKey3.Text = s爐號1.Text
        PreviewReport.lblRepKey4.Text = s進度1.SelectedValue
        PreviewReport.lblRepKey5.Text = s線材爐號1.Text
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 分爐製造工令_Click(sender As System.Object, e As System.EventArgs) Handles 分爐製造工令.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = s爐號.Text
        PreviewReport.lblReportFile.Text = "分爐製造工作令.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 品管列印_Click(sender As System.Object, e As System.EventArgs) Handles 品管列印.Click
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = s爐號.Text
        PreviewReport.lblReportFile.Text = "熱處理成品重量明細記錄表.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()

        PreviewReport.lblRepKey.Text = s爐號.Text
        PreviewReport.lblReportFile.Text = "熱處理加工最終檢驗記錄表.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub DataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub
End Class
