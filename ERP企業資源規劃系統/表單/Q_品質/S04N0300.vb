Imports System.IO
Public Class S04N0300
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
    Dim TotalTime As Integer
    Dim FileAddrValue As String = INI_Read("CONFIG", "SET", "MachineFile") 'DNS設定值
#End Region

#Region "@Form及功能操作@"
    Private Sub S04N0300_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        BCtrl.Visible = False
        BasicPanel.Visible = False
        BaseStatusStrip.Visible = False

        Me.Height = 670

        FileAddr.Text = FileAddrValue

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        txtAutoComplete()
        'DataGridView_Basic() 'DataGridView初始化
        'FillData("") '載入資料集
    End Sub
    Private Sub S04N0300_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S04N0300_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
        If e.KeyCode = Keys.Down Then SendKeys.Send("{tab}")
        If e.KeyCode = Keys.Up Then SendKeys.Send("+{TAB}")
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
        '查詢語法
        strSSQL = "SELECT m.*,t1.公司名稱 AS 客戶,t2.一層名稱 AS 品名,t3.一層名稱 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " WHERE 1=1"
        strSSQL &= " ORDER BY 工令號碼 DESC"
        SqlToExcel(DNS, strSSQL)
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
    '自動完成
    Public Sub txtAutoComplete()
        'Dim namesCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection
        ''開啟查詢
        'objCon99 = New SqlConnection(DNS)
        'objCon99.Open()

        'strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        'strSQL99 &= " WHERE 類別 = 'S04N0004'"

        'objCmd99 = New SqlCommand(strSQL99, objCon99)
        'objDR99 = objCmd99.ExecuteReader

        'If objDR99.HasRows Then
        '    While objDR99.Read
        '        namesCollection.Add(objDR99("一層代碼").ToString)
        '    End While
        'End If

        'objDR99.Close()

        '品管備註.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '品管備註.AutoCompleteSource = AutoCompleteSource.CustomSource
        '品管備註.AutoCompleteCustomSource = namesCollection

    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態>'3' and isnull(檢驗狀態,'')<>'' ", "工令號碼")
        ComboBox_DB(s爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        'ComboBox_DB(s未檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') = ''", "工令號碼")
        'ComboBox_DB(s已檢驗工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') <> ''", "工令號碼")
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "isnull(檢驗狀態,'') <> '' and 狀態='已出貨'", "工令號碼")

        ComboBox_DB(表面硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(心部硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(華司硬度規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0003'", "一層代碼 ASC")
        ComboBox_DB(檢驗人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='05' or 職稱代碼2='05' or 職稱代碼3='05' )", "姓名 ASC")

        ComboBox_DB(操作人員1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(操作人員2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' ) ", "姓名 ASC")
        ComboBox_DB(操作人員3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DB(組長1, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長2, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(組長3, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='12' or 職稱代碼2='12' or 職稱代碼3='12' )", "姓名 ASC")
        ComboBox_DB(班別1, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別2, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")
        ComboBox_DB(班別3, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S01N0006'", "一層代碼 ASC")



        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        'ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        'ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        'ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        'ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")
        'ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0009'", "一層代碼 ASC")
        'ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        'ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "加工廠代號+' '+公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")

        ComboBox_DB(品管備註, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S04N0004'", "一層名稱 ASC")

        ComboBox_DGDB(單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "參數1 ASC")
        ComboBox_DGDB(收料單位, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "參數1 ASC")
        ComboBox_DGDB(入料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        ComboBox_DGDB(收料人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")

        ComboBox_GG(處理方式, ",轉入進貨單,不轉入進貨單", ",轉入進貨單,不轉入進貨單")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        ''欄位名稱
        'Dim arrColName() As String = {"工令號碼", "客戶", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"}
        'Dim arrColWidth() As String = {"120", "120", "100", "160", "100", "100", "100", "100", "100", "100", "100", "100"}

        'DataGridView.ColumnCount = arrColName.Length
        'DataGridView.RowCount = 1

        'For J As Integer = 0 To arrColName.Length - 1 Step 1
        '    With DataGridView
        '        .Columns(J).Name = arrColName(J) '欄位名稱
        '        .Columns(J).Width = arrColWidth(J) '欄位寬度
        '    End With
        'Next
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
    
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {}

        Set_Control_RW(MainPanel, butStatus)
        Set_Control_RW(TabControl, butStatus)
        國際標準.ReadOnly = True
        表面硬度值.ReadOnly = True
        心部硬度值.ReadOnly = True
        抗拉強度值.ReadOnly = True
        降伏強度值.ReadOnly = True
        伸長率值.ReadOnly = True
        '扭力強度值.ReadOnly = True
        滲碳層1值.ReadOnly = True
        斷面收縮率值.ReadOnly = True
        安全負荷值.ReadOnly = True
        降伏點值起迄.ReadOnly = True
        最大負荷值起迄.ReadOnly = True
        斷面積值起迄.ReadOnly = True



        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()

            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage6
                'DataGridView.Enabled = False
                斷面積.Focus()
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
        'If DataGridView.Rows.Count > 0 Then
        '    Try
        '        '關鍵值
        '        Dim strKey As String = DataGridView.Rows(intRow).Cells(0).Value.ToString

        '        '停在選定之儲存格
        '        ShowData(strKey)
        '        txtSeat.Text = intRow + 1 '目前位置
        '        DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
        '    Catch ex As Exception

        '    End Try
        'End If
    End Sub


    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = True

        Return blnCheck
    End Function

    Public Overrides Sub BeforeFormClose()
        MyTableStatus = 0
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Machine(strKey1) '產品機械性質主檔    
        MasterItem(strKey1)
        Set_Control_ZERO(TabPage6)
        Set_Control_ZERO(TabPage5)
    End Sub
    '主檔
    Sub Machine(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT "
        strSQL99 &= " m.* FROM 進貨單主檔 m "
        strSQL99 &= " WHERE m.工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            ControlReadData(MainPanel, objDR99)
            ControlReadData(TabControl, objDR99)

            '無法塞值的欄位*****
            拉力機編號1.Checked = IIf(objDR99("拉力機編號").ToString = "50T", True, False)
            拉力機編號2.Checked = IIf(objDR99("拉力機編號").ToString = "100T", True, False)

            整體判定1.Checked = IIf(objDR99("整體判定").ToString = "合格", True, False)
            整體判定2.Checked = IIf(objDR99("整體判定").ToString = "不合格", True, False)
            整體判定3.Checked = IIf(objDR99("整體判定").ToString = "待處理", True, False)

            外觀判定1.Checked = IIf(objDR99("外觀判定").ToString = "合格", True, False)
            外觀判定2.Checked = IIf(objDR99("外觀判定").ToString = "不合格", True, False)

            不合格品處理1.Checked = IIf(objDR99("不合格品處理").ToString = "重回染", True, False)
            不合格品處理2.Checked = IIf(objDR99("不合格品處理").ToString = "重做", True, False)
            不合格品處理3.Checked = IIf(objDR99("不合格品處理").ToString = "報廢", True, False)
            不合格品處理4.Checked = IIf(objDR99("不合格品處理").ToString = "無", True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標



        '    End If

  


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

    Sub MasterItem(ByVal strKey1 As String)

        strSSQL = "SELECT m.* FROM 製造單項目檔 AS m"
        strSSQL &= " WHERE m.工令號碼 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY m.桶號 ASC"

        DataGridView_HeaderDB(Tab2_DataGridViewR1, DNS, strSSQL)

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value > 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        入料桶數.Text = T桶數
        入料總重.Text = T重量

        T重量 = 0
        T桶數 = 0
        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If


    End Sub

    Public Sub ShowBackData(ByVal strKey1 As String)
        MachineBack(strKey1) '產品機械性質主檔    
        Set_Control_ZERO(TabPage6)
        Set_Control_ZERO(TabPage5)
    End Sub
    Sub MachineBack(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT "
        strSQL99 &= " m.* FROM 不合格品主檔 m "
        strSQL99 &= " WHERE m.工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '異動狀態*****
            建立人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("建立人員").ToString & "'")
            建立日期.Text = objDR99("建立日期").ToString
            修改人員.Text = dbGetSingleRow(DNS, "員工主檔", "姓名", "員工代號 = '" & objDR99("修改人員").ToString & "'")
            修改日期.Text = objDR99("修改日期").ToString

            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            ControlReadData(MainPanel, objDR99)
            ControlReadData(TabControl, objDR99)

            '無法塞值的欄位*****
            拉力機編號1.Checked = IIf(objDR99("拉力機編號").ToString = "50T", True, False)
            拉力機編號2.Checked = IIf(objDR99("拉力機編號").ToString = "100T", True, False)

            整體判定1.Checked = IIf(objDR99("整體判定").ToString = "合格", True, False)
            整體判定2.Checked = IIf(objDR99("整體判定").ToString = "不合格", True, False)
            整體判定3.Checked = IIf(objDR99("整體判定").ToString = "待處理", True, False)

            外觀判定1.Checked = IIf(objDR99("外觀判定").ToString = "合格", True, False)
            外觀判定2.Checked = IIf(objDR99("外觀判定").ToString = "不合格", True, False)

            不合格品處理1.Checked = IIf(objDR99("不合格品處理").ToString = "重回染", True, False)
            不合格品處理2.Checked = IIf(objDR99("不合格品處理").ToString = "重做", True, False)
            不合格品處理3.Checked = IIf(objDR99("不合格品處理").ToString = "報廢", True, False)
            不合格品處理4.Checked = IIf(objDR99("不合格品處理").ToString = "無", True, False)
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標


        '   If 國際標準.Text = "" Then
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT t1.表面硬度 as 表面硬度值,t1.表面規格 as 表面硬度規格,t1.心部硬度 as 心部硬度值,t1.心部規格 as 心部硬度規格"
        strSQL99 &= " ,t1.抗拉強度 as 抗拉強度值,t1.降伏點強度 as 降伏強度值,t1.伸長率 as 伸長率值,t1.滲碳層 as 滲碳層1值 "
        strSQL99 &= " ,t1.斷面收縮 as 斷面收縮率值,t1.安全負荷 as 安全負荷值"
        'strSQL99 &= " ,t1. as 降伏點值起迄,t1. as 最大負荷值起迄,t1. as 斷面積值起迄 "
        strSQL99 &= " ,m.扭力 as 扭力強度值,m.依據標準 as 國際標準 "
        strSQL99 &= "  FROM 不合格品主檔 m "
        strSQL99 &= " LEFT JOIN 產品機械性質主檔 AS t1 ON m.依據標準 = t1.依據標準"
        strSQL99 &= " WHERE m.工令號碼 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            '找尋某一容器下的所有控制項，傳入objDR99的值，要控制項的名稱 等於 欄位名稱才會塞值
            If objDR99("國際標準").ToString <> 國際標準.Text Then
                ControlReadData(TabControl, objDR99)
            End If
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
        '    End If

        If CK抗拉強度.Checked = False And CK表面硬度.Checked = False And CK心部硬度.Checked = False And CK滲碳層.Checked = False And CK最大負荷.Checked = False Then
            If CK抗拉強度值.Checked = False And CK表面硬度值.Checked = False And CK心部硬度值.Checked = False And CK降伏強度值.Checked = False And CK降伏點值起迄.Checked = False And CK最大負荷值起迄.Checked = False And CK斷面積值起迄.Checked = False Then
                CK抗拉強度值.Checked = True
                CK表面硬度值.Checked = True
                CK心部硬度值.Checked = True
                CK降伏強度值.Checked = True
                CK降伏點值起迄.Checked = True
                CK最大負荷值起迄.Checked = True
                CK斷面積值起迄.Checked = True
            End If
        End If


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
#End Region


    Private Sub s爐號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s爐號.SelectedIndexChanged
        ComboBox_DB(s不合格工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "檢驗狀態='檢驗不合格' and 預排爐號='" + s爐號.Text + "'", "序號")
        ComboBox_DB(s不合格工令備份, DNS, "不合格品主檔", "工令號碼", "工令號碼", "預排爐號='" + s爐號.Text + "'", "序號")
        'ComboBox_DB(s歷史資料, DNS, "進貨單主檔", "工令號碼", "工令號碼", "狀態>'3' and isnull(檢驗狀態,'')<>'' ", "工令號碼")
    End Sub

    Private Sub s不合格工令_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s不合格工令.SelectedIndexChanged
        If s不合格工令.SelectedIndex <> 0 Then

            工令輸入.Text = ""
            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s不合格工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s不合格工令.SelectedValue + "'"
            End If
            ShowData(s不合格工令.SelectedValue)
            butEdit.PerformClick()
            SetControls(2)
        End If
    End Sub





    Private Sub 套表列印_Click(sender As System.Object, e As System.EventArgs)
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "檢驗報告書.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 不合格處理單_Click(sender As System.Object, e As System.EventArgs)
        Dim PreviewReport As New PreviewReport
        PreviewReport.lblRepKey.Text = 工令號碼.Text
        PreviewReport.lblReportFile.Text = "不合格品處理單.frx"
        PreviewReport.btnPreviewRep_Click(sender, e)
        PreviewReport.ShowDialog()
    End Sub

    Private Sub 完爐時間_Enter(sender As System.Object, e As System.EventArgs) Handles 完爐時間.Enter
        Dim tb As System.Windows.Forms.TextBox = DirectCast(sender, System.Windows.Forms.TextBox)
        If tb.Text = "" Then
            tb.Text = NowTime()
        End If
    End Sub

    Private Sub TextBox1_Leave(sender As System.Object, e As System.EventArgs) Handles 工令輸入.Leave
        If 工令輸入.Text <> "" Then
            ShowBackData(工令輸入.Text)
        End If
    End Sub


    Private Sub BtnRData_Click(sender As Object, e As EventArgs) Handles BtnRData.Click
        If s爐號.SelectedIndex <> 0 Then
            TotalTime = 0
            Dim svalue1 As String = ""
            Dim svalue2 As String = ""
            If s不合格工令.SelectedIndex <> 0 Then
                svalue1 = s不合格工令.SelectedValue
            End If

            ComboBox_DB(s不合格工令, DNS, "進貨單主檔", "工令號碼", "工令號碼", "檢驗狀態='檢驗不合格' and 預排爐號='" + s爐號.Text + "'", "序號")

            ComboBox_DB(s不合格工令備份, DNS, "不合格品主檔", "工令號碼", "工令號碼", "預排爐號='" + s爐號.Text + "'", "序號")



            Try
                If svalue1 <> "" Then s不合格工令.SelectedValue = svalue1
            Catch ex As Exception

            End Try

        End If
    End Sub


    Private Sub 工令輸入_KeyDown(sender As Object, e As KeyEventArgs) Handles 工令輸入.KeyDown
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If s不合格工令.Text = "" Then
            Exit Sub
        End If

        Dim blnCheck As Boolean = False

        '先刪
        dbDelete(DNS, "製造單項目檔", "工令號碼 = '" & 工令號碼.Text & "'")

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0
        Dim TX重量 As Integer = 0
        Dim TX桶數 As Integer = 0

        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            Dim strRowValue() As String = {Tab2_DataGridViewR1.Rows(I).Cells("桶號").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("狀態").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("空桶重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("單位").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("生料重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("生料淨重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("入料人員").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("磅後重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料人員").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("重量差1").Value,
                                            Tab2_DataGridViewR1.Rows(I).Cells("備註").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料單位").Value,
                                           Tab2_DataGridViewR1.Rows(I).Cells("收料空桶重").Value}

            If strRowValue(0) <> "" Then
                strIRow = "工令號碼,桶號,狀態,空桶重,單位,生料重,生料淨重,入料人員,磅後重,磅後淨重,收料人員,重量差,備註,收料單位,收料空桶重"
                strIValue = "'" & 工令號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "','" & strRowValue(5) & "','" & strRowValue(6) & "','" & strRowValue(7) & "','" & strRowValue(8) & "','" & strRowValue(9) & "','" & strRowValue(10) & "','" & strRowValue(11) & "','" & strRowValue(12) & "','" & strRowValue(13) & "'"
                blnCheck = dbInsert(DNS, "製造單項目檔", strIRow, strIValue)
            End If

            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 And Tab2_DataGridViewR1.Rows(I).Cells("狀態").Value <> "不合格" Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            ElseIf Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                TX重量 = TX重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                TX桶數 = TX桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        不合格桶數.Text = TX桶數
        不合格重量.Text = TX重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If


        '   If 檢驗人員.SelectedIndex <> 0 Then
        strUValue = ""
        GetCtrlUpdateSql(TabPage1, "BCtrl", strUValue)

        If 不合格品處理1.Checked = True Then
            strUValue &= "不合格品處理 = '" & "重回染" & "',"
            strUValue &= " 狀態 = '" & "-1" & "',"
        ElseIf 不合格品處理2.Checked = True Then
            strUValue &= "不合格品處理 = '" & "重做" & "',"
            strUValue &= " 狀態 = '" & "-1" & "',"
        ElseIf 不合格品處理3.Checked = True Then
            strUValue &= "不合格品處理 = '" & "報廢" & "',"
            strUValue &= " 狀態 = '" & "-1" & "',"
        ElseIf 不合格品處理4.Checked = True Then
            strUValue &= "不合格品處理 = '" & "無" & "',"
        ElseIf 不合格品處理5.Checked = True Then
            strUValue &= "不合格品處理 = '" & "部份出貨" & "',"
        End If

        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"
        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

    End Sub

    Private Sub s不合格工令備份_SelectedIndexChanged(sender As Object, e As EventArgs) Handles s不合格工令備份.SelectedIndexChanged
        If s不合格工令備份.SelectedIndex <> 0 Then

            工令輸入.Text = ""
            Dim str As String
            str = " "
            If s爐號.Text <> "" Then
                str &= " and 預排爐號 ='" + s爐號.SelectedValue + "'"
            End If
            If s不合格工令.Text <> "" Then
                str &= " and 工令號碼 ='" + s不合格工令備份.SelectedValue + "'"
            End If
            ShowBackData(s不合格工令備份.SelectedValue)
            'butEdit.PerformClick()
            'SetControls(2)
        End If
    End Sub

    Private Sub Tab2_DataGridViewR1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles Tab2_DataGridViewR1.CellEndEdit
        ' Try

        Dim T重量 As Integer = 0
        Dim T桶數 As Integer = 0
        Dim TX重量 As Integer = 0
        Dim TX桶數 As Integer = 0
        For I As Integer = 0 To Tab2_DataGridViewR1.RowCount - 1 Step 1
            If Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 And Tab2_DataGridViewR1.Rows(I).Cells("狀態").Value <> "不合格" Then
                T重量 = T重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                T桶數 = T桶數 + 1
            ElseIf Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value <> 0 Then
                TX重量 = TX重量 + Tab2_DataGridViewR1.Rows(I).Cells("磅後淨重").Value
                TX桶數 = TX桶數 + 1
            End If
        Next

        磅後桶數.Text = T桶數
        磅後總重.Text = T重量

        不合格桶數.Text = TX桶數
        不合格重量.Text = TX重量

        桶數差.Text = CInt(裝袋合計.Text) - T桶數
        If IsNumeric(進貨重量.Text) Then
            重量差.Text = CInt(進貨重量.Text) - T重量
        Else
            進貨重量.Text = 0
            重量差.Text = CInt(進貨重量.Text) - T重量
        End If
    End Sub

    Private Sub 不合格處理單_Click_1(sender As Object, e As EventArgs) Handles 不合格處理單.Click

    End Sub

    Private Sub 套表列印_Click_1(sender As Object, e As EventArgs) Handles 套表列印.Click

    End Sub
End Class

