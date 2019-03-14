Imports FastReport
Imports FastReport.Utils
Imports System.IO
Imports System.Drawing.Imaging

Public Class S03N0120
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
    Dim Status As Integer = 0 '目前編輯狀態
    Dim FormKey As String = "" '目前編輯的KEY值
#End Region
#Region "單用變數"
    Dim strPage As String = "FA" & Mid(Now.Year, 3, 2)
    Dim FRreport As New Report
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0120_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        'BasicPanel.Width = WorkingArea_Width()
        'MainPanel.Width = WorkingArea_Width()
        'SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {butCopy}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next


        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
        txtAutoComplete()
        '把所有的ComboBox加上FOCUS即點開
        Set_Control_ComboBox(TabControl)

    End Sub
    Private Sub S03N0120_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S03N0120_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage2, e)
        ControlFocus(TabPage4, e)
    End Sub
    Private Sub S03N0120_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S03N0120 As New S_S03N0120

        '開啟視窗
        S_S03N0120.MdiParent = fmMain
        S_S03N0120.Show()
    End Sub
    '自動完成
    Public Sub txtAutoComplete()
        Dim namesCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        strSQL99 &= " WHERE 類別 = 'S03N0012'"

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

        製造備註1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註1.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註1.AutoCompleteCustomSource = namesCollection
        製造備註2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註2.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註2.AutoCompleteCustomSource = namesCollection
        製造備註3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        製造備註3.AutoCompleteSource = AutoCompleteSource.CustomSource
        製造備註3.AutoCompleteCustomSource = namesCollection


        注意事項1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        注意事項1.AutoCompleteSource = AutoCompleteSource.CustomSource
        注意事項1.AutoCompleteCustomSource = namesCollection
        注意事項2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        注意事項2.AutoCompleteSource = AutoCompleteSource.CustomSource
        注意事項2.AutoCompleteCustomSource = namesCollection
        注意事項3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        注意事項3.AutoCompleteSource = AutoCompleteSource.CustomSource
        注意事項3.AutoCompleteCustomSource = namesCollection

        'Dim namesCollection1 As AutoCompleteStringCollection = New AutoCompleteStringCollection

        'strSQL99 = "SELECT  一層代碼 FROM s_一層代碼檔"
        'strSQL99 &= " WHERE 類別 = 'S04N0001'"

        'objCmd99 = New SqlCommand(strSQL99, objCon99)
        'objDR99 = objCmd99.ExecuteReader

        'If objDR99.HasRows Then
        '    While objDR99.Read
        '        namesCollection1.Add(objDR99("一層代碼").ToString)
        '    End While
        'End If

        'objDR99.Close()

        '製造備註1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '製造備註1.AutoCompleteSource = AutoCompleteSource.CustomSource
        '製造備註1.AutoCompleteCustomSource = namesCollection1
        '製造備註2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '製造備註2.AutoCompleteSource = AutoCompleteSource.CustomSource
        '製造備註2.AutoCompleteCustomSource = namesCollection1
        '製造備註3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        '製造備註3.AutoCompleteSource = AutoCompleteSource.CustomSource
        '製造備註3.AutoCompleteCustomSource = namesCollection1

        'Dim namesCollection2 As AutoCompleteStringCollection = New AutoCompleteStringCollection

        'strSQL99 = "SELECT  注意事項1 FROM 進貨單主檔 where 注意事項1<>''  group by 注意事項1"
        'strSQL99 &= " union SELECT  注意事項2 FROM 進貨單主檔 where 注意事項2<>'' group by 注意事項2 "
        'strSQL99 &= " union SELECT  注意事項3 FROM 進貨單主檔 where 注意事項3<>'' group by 注意事項3 "


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
        'ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類='I'", "車次序號")

        '  ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        'ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = ''", "姓名 ASC")
        ComboBox_DB(開單人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='04' or 職稱代碼2='04' or 職稱代碼3='04')", "姓名 ASC")
        ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
        ComboBox_DB(o客戶, DNS, "客戶主檔", "客戶代號", "簡稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(o規格, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        ComboBox_DB(o狀態, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = '狀態' and 一層名稱<>''", "一層代碼 ASC")
        '   ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱+' '+加工廠代號", "加工廠類型 = 'A'", "公司名稱 ASC")

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(表面處理代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0008'", "一層代碼 ASC")
        ComboBox_DB(電鍍別代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0009'", "一層代碼 ASC")
        ComboBox_DB(次加工廠代號1, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(次加工廠代號2, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'B'", "加工廠代號 ASC")
        ComboBox_DB(單位代號1, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號2, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號3, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        ComboBox_DB(單位代號4, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0010'", "一層名稱 ASC")
        'ComboBox_DB(預排爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")

        'ComboBox_DB(前工令號碼, DNS, "出貨退回主檔", "工令號碼", "工令號碼", "isnull(新工令號碼,'') = ''", "工令號碼 ASC")

        ComboBox_GG(運費種類, ",含運,自付", ",含運費,自付運費")
        ComboBox_GG(牙分類, ",全牙,半牙,無", ",全牙,半牙,無")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"工令號碼", "日期", "時間", "車次序號", "客戶簡稱", "客戶單號", "所屬工廠", "狀態", "過磅狀態", "檢驗狀態"}
        Dim arrColWidth() As String = {"120", "120", "100", "100", "100", "160", "100", "100", "100", "100"}

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
    '點二下切換至資料顯示
    Private Sub DataGridView_DoubleClick(sender As System.Object, e As System.EventArgs) Handles DataGridView.DoubleClick
        TabControl.SelectedTab = Me.TabPage2
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

        If FIRM <> "總公司" Then
            strSearch &= " and 所屬工廠='" + FIRM + "'"
        End If

        '查詢語法
        strSSQL = "SELECT top " + PageCount.Text + " t1.一層名稱 AS 狀態,t2.簡稱 AS 客戶簡稱,m.* FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t1 ON m.狀態 = t1.一層代碼"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t2 ON m.客戶代號 = t2.客戶代號"
        'strSSQL &= " LEFT JOIN 司機主檔 AS t1 ON m.司機代號 = t1.司機代號"
        'strSSQL &= " LEFT JOIN 員工主檔 AS t2 ON m.過磅人員 = t2.員工代號"
        strSSQL &= " WHERE 1=1 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 日期 DESC,時間 DESC,工令號碼 DESC"

        '顯示欄位
        arrRowName = {"工令號碼", "日期", "時間", "車次序號", "客戶簡稱", "客戶單號", "所屬工廠", "狀態", "過磅狀態", "檢驗狀態"}

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
        'Status = butStatus
        Set_Control_RW(TabControl, butStatus)

        工令號碼.ReadOnly = True
        前工令號碼.ReadOnly = True
        依據標準.ReadOnly = True
        裝袋合計.ReadOnly = True
        客戶代號.Enabled = False
        客戶電話.Enabled = False
        司機代號.Enabled = False
        聯絡人.Enabled = False
        所屬工廠.ReadOnly = True
        '車次序號.Enabled = False
        Status = butStatus
        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
                ComboBox_DB(加工廠代號, DNS, "加工廠主檔", "加工廠代號", "公司名稱", "加工廠類型 = 'A'", "公司名稱 ASC")
                ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類='I'", "車次序號")
                '  ComboBox_DB(前工令號碼, DNS, "出貨退回主檔", "出貨退回編號", "出貨退回編號", "", "出貨退回編號 ASC")

                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = True
                btuSOld.Enabled = False
                Button2.Enabled = False

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                PictureBox1.Image = Nothing
                btuSOld.Enabled = True
                Button2.Enabled = True

                時間.Text = NowTime() : 開單人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                試片2.Checked = True

                If FIRM <> "總公司" Then
                    ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "' and 所屬工廠='" + FIRM + "'", "車次序號")
                Else
                    ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "'", "車次序號")
                End If


                進貨日期.Focus()

                所屬工廠.Text = FIRM
                ' ComboBox_DB(前工令號碼, DNS, "出貨退回主檔", "出貨退回編號", "出貨退回編號", "isnull(新工令號碼,'') = '' and 處理方式='轉入進貨單'", "工令號碼 ASC")

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                btuSOld.Enabled = True
                Button2.Enabled = True



                Dim 加工廠代號Value As String = 加工廠代號.SelectedValue
                Dim 客戶代號Value As String = 客戶代號.SelectedValue

                ComboBox_DB(加工廠代號, DNS, "(select a.*,b.公司名稱 from 過磅單項目檔 a left join 加工廠主檔 b on a.加工廠代號=b.加工廠代號 ) as T1 ", "加工廠代號", "公司名稱+' '+客戶代號", "車次序號 = '" & 車次序號.Text & "'", "序號 ASC")
                加工廠代號.SelectedValue = 加工廠代號Value

                ComboBox_DB(客戶代號, DNS, "(select a.*,b.公司名稱 from 過磅單項目檔 a left join 客戶主檔 b on a.客戶代號=b.客戶代號 ) as T1 ", "客戶代號", "公司名稱", "車次序號 = '" & 車次序號.Text & "'", "公司名稱 ASC")
                客戶代號.SelectedValue = 客戶代號Value

                客戶批號.Focus()
            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                btuSOld.Enabled = True
                Button2.Enabled = True

                PictureBox1.Image = Nothing

                時間.Text = NowTime() : 開單人員.SelectedValue = INI_Read("BASIC", "LOGIN", "UNAME")
                '工令號碼.Text = ERP_AutoNo(DNS, strPage, "進貨單主檔", "工令號碼")
                進貨日期.Focus()
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
        'Dim 車次比數 As Integer = dbCount(DNS, "進貨單主檔", "intCount", "車次序號 = '" & 車次序號.SelectedValue & "'") + 1
        Dim String5 As String = dbGetSingleRow(DNS, "進貨單主檔", "工令號碼", "車次序號 = '" & 車次序號.SelectedValue & "'", "工令號碼 DESC")
        If String5 = "" Then
            工令號碼.Text = 車次序號.Text + "01"
        Else
            'MsgBox(Mid(String5, Len(車次序號.Text) + 1, 2))
            工令號碼.Text = 車次序號.Text + CStr(CInt(Mid(String5, Len(車次序號.Text) + 1, 2)) + 1).PadLeft(2, "0")
        End If

        '工令號碼.Text = 車次序號.Text + 車次比數.ToString.PadLeft(2, "0")
        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號}
        Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        If blnCheck = False Then Return False : Exit Function
        '必數字
        'Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重, 扭力}
        'Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重", "扭力"}
        'blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        'If blnCheck = False Then Return False : Exit Function

        '代號是否有重複
        If dbDataCheck(DNS, "進貨單主檔", "工令號碼 = '" & 工令號碼.Text & "'") = True Then MsgBox("系統訊息：【工令號碼】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****

        '開啟儲存*****
        '過磅單主檔
        strIRow = "工令號碼, 前工令號碼, 日期, 時間,進貨日期,"
        strIRow &= "車次序號, 客戶代號, 加工廠代號, 開單人員,"
        strIRow &= "司機代號, 客戶單號, 客戶批號, 產品代碼,"
        strIRow &= "規格代碼, 長度代碼, 長度說明,品名分類代碼,"
        strIRow &= "加工方式代碼, 材質代碼, 規範分類, 強度級數,"
        strIRow &= "表面處理代碼, 電鍍別代碼, 次加工廠代號1, 次加工廠代號2,"
        strIRow &= "數量1, 單位代號1, 數量2, 單位代號2,"
        strIRow &= "數量3,單位代號3, 數量4, 單位代號4,"
        strIRow &= "淨重, 線材爐號, 依據標準, 表面硬度,"
        strIRow &= "心部硬度, 抗拉強度, 滲碳層, 扭力,"
        strIRow &= "華司材質, 華司硬度, 試片, 存放位置,"
        strIRow &= "運費種類, 回火溫度, 以前爐號, 預排爐號,"
        strIRow &= "注意事項1, 注意事項2, 注意事項3,"
        strIRow &= "品管備註1, 品管備註2, 品管備註3,"
        strIRow &= "製造備註1, 製造備註2, 製造備註3,"
        strIRow &= "流量, CP值, 氨值1,氨值2,"
        strIRow &= "氨值3, 氨值4, 加熱爐1,加熱爐2,"
        strIRow &= "加熱爐3, 加熱爐4, 加熱爐5,加熱爐6,加熱爐7,加熱爐8,"
        strIRow &= "加熱爐油溫, 加熱爐速度, 回火爐1,回火爐2,"
        strIRow &= "回火爐3, 回火爐4, 回火爐5, 回火爐6, 回火爐速度,裝袋合計,序號,"
        strIRow &= "狀態,牙分類,產品名稱,所屬工廠,扭力強度值,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 工令號碼.Text & "','" & 前工令號碼.Text & "','" & strSystemToDate(日期.Value.ToShortDateString) & "','" & 時間.Text & "','" & strSystemToDate(進貨日期.Value.ToShortDateString) & "',"
        strIValue &= "'" & 車次序號.SelectedValue & "','" & 客戶代號.SelectedValue & "','" & 加工廠代號.SelectedValue & "','" & 開單人員.SelectedValue & "',"
        strIValue &= "'" & 司機代號.SelectedValue & "','" & 客戶單號.Text & "','" & 客戶批號.Text & "','" & 產品代碼.SelectedValue & "',"
        strIValue &= "'" & 規格代碼.SelectedValue & "','" & 長度代碼.SelectedValue & "','" & 長度說明.Text & "','" & 品名分類代碼.SelectedValue & "',"
        strIValue &= "'" & 加工方式代碼.SelectedValue & "','" & 材質代碼.SelectedValue & "','" & 規範分類.Text & "','" & 強度級數.Text & "',"
        strIValue &= "'" & 表面處理代碼.SelectedValue & "','" & 電鍍別代碼.SelectedValue & "','" & 次加工廠代號1.SelectedValue & "','" & 次加工廠代號2.SelectedValue & "',"
        strIValue &= "'" & 數量1.Text & "','" & 單位代號1.SelectedValue & "','" & 數量2.Text & "','" & 單位代號2.SelectedValue & "',"
        strIValue &= "'" & 數量3.Text & "','" & 單位代號3.SelectedValue & "','" & 數量4.Text & "','" & 單位代號4.SelectedValue & "',"
        strIValue &= "'" & 淨重.Text & "','" & 線材爐號.Text & "','" & 依據標準.Text & "','" & 表面硬度.Text & "',"
        strIValue &= "'" & 心部硬度.Text & "','" & 抗拉強度.Text & "','" & 滲碳層.Text & "','" & 扭力.Text & "',"
        strIValue &= "'" & 華司材質.Text & "','" & 華司硬度.Text & "','" & IIf(試片1.Checked = True, "Y", "N") & "','" & 存放位置.Text & "',"
        strIValue &= "'" & 運費種類.SelectedValue & "','" & 回火溫度.Text & "','" & 以前爐號.Text & "','" & 預排爐號.Text & "',"
        strIValue &= "'" & 注意事項1.Text & "','" & 注意事項2.Text & "','" & 注意事項3.Text & "',"
        strIValue &= "'" & 品管備註1.Text & "','" & 品管備註2.Text & "','" & 品管備註3.Text & "',"
        strIValue &= "'" & 製造備註1.Text & "','" & 製造備註2.Text & "','" & 製造備註3.Text & "',"
        strIValue &= "'" & 流量.Text & "','" & CP值.Text & "','" & 氨值1.Text & "','" & 氨值2.Text & "',"
        strIValue &= "'" & 氨值3.Text & "','" & 氨值4.Text & "','" & 加熱爐1.Text & "','" & 加熱爐2.Text & "',"
        strIValue &= "'" & 加熱爐3.Text & "','" & 加熱爐4.Text & "','" & 加熱爐5.Text & "','" & 加熱爐6.Text & "','" & 加熱爐7.Text & "','" & 加熱爐8.Text & "',"
        strIValue &= "'" & 加熱爐油溫.Text & "','" & 加熱爐速度.Text & "','" & 回火爐1.Text & "','" & 回火爐2.Text & "',"
        strIValue &= "'" & 回火爐3.Text & "','" & 回火爐4.Text & "','" & 回火爐5.Text & "','" & 回火爐6.Text & "','" & 回火爐速度.Text & "','" & 裝袋合計.Text & "'," & "99.9" & ","
        strIValue &= "'" & "1" & "','" & 牙分類.SelectedValue & "','" & 產品名稱.Text & "','" & 所屬工廠.Text & "','" & 扭力.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "進貨單主檔", strIRow, strIValue)

        strIRow = "工令號碼"
        strIValue = "'" & 工令號碼.Text & "'"
        blnCheck = dbInsert(DNS, "進貨單頭部記號檔", strIRow, strIValue)

        Try
            Dim imgData As Byte()         ' storage for the img bytes
            imgData = ImgToByteArray(PictureBox1.Image, ImageFormat.Bmp)

            strUValue = "UPDATE 進貨單頭部記號檔 SET 頭部記號=@頭部記號 WHERE 工令號碼 = '" & 工令號碼.Text & "'"
            Dim sqlCommand As New SqlCommand
            sqlCommand.Parameters.Add("@頭部記號", SqlDbType.VarBinary)
            sqlCommand.Parameters("@頭部記號").Value = imgData

            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            With sqlCommand
                .CommandText = strUValue
                .Connection = objCon99
                .ExecuteNonQuery()
            End With

        Catch ex As Exception

        End Try

        If 前工令號碼.Text <> "" Then
            strSSQL = "update 出貨退回主檔"
            strSSQL &= "  set  新工令號碼 = '" & 工令號碼.Text & "'"
            strSSQL &= " where 出貨退回編號 = '" & 前工令號碼.Text & "'"
            blnCheck = dbExecute(DNS, strSSQL)
        End If


        FormKey = 工令號碼.Text

        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        '防呆*****
        '必輸入
        Dim objArray_Input() As Object = {工令號碼, 車次序號, 客戶代號, 開單人員, 司機代號}
        Dim strArray_Input() As String = {"工令號碼", "車次序號", "客戶代號", "開單人員", "司機代號"}
        blnCheck = blnInputCheck(objArray_Input, strArray_Input)

        '必數字
        'Dim objArray_Numeric() As Object = {數量1, 數量2, 數量3, 數量4, 淨重, 扭力}
        'Dim strArray_Numeric() As String = {"數量1", "數量2", "數量3", "數量4", "淨重", "扭力"}
        'blnCheck = blnInputNumeric(objArray_Numeric, strArray_Numeric)

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****

        '開啟儲存*****
        '客戶主檔
        strUValue = "前工令號碼 = '" & 前工令號碼.Text & "',"
        strUValue &= "進貨日期 = '" & strSystemToDate(進貨日期.Value.ToShortDateString) & "',"
        strUValue &= "日期 = '" & strSystemToDate(日期.Value.ToShortDateString) & "',"
        strUValue &= "時間 = '" & 時間.Text & "',"
        strUValue &= "車次序號 = '" & 車次序號.SelectedValue & "',"
        strUValue &= "客戶單號 = '" & 客戶單號.Text & "',"
        strUValue &= "客戶批號 = '" & 客戶批號.Text & "',"
        strUValue &= "長度說明 = '" & 長度說明.Text & "',"
        strUValue &= "規範分類 = '" & 規範分類.Text & "',"
        strUValue &= "強度級數 = '" & 強度級數.Text & "',"
        strUValue &= "數量1 = '" & 數量1.Text & "',"
        strUValue &= "數量2 = '" & 數量2.Text & "',"
        strUValue &= "數量3 = '" & 數量3.Text & "',"
        strUValue &= "數量4 = '" & 數量4.Text & "',"
        strUValue &= "裝袋合計 = '" & 裝袋合計.Text & "',"
        strUValue &= "淨重 = '" & 淨重.Text & "',"
        strUValue &= "線材爐號 = '" & 線材爐號.Text & "',"
        strUValue &= "依據標準 = '" & 依據標準.Text & "',"
        strUValue &= "表面硬度 = '" & 表面硬度.Text & "',"
        strUValue &= "心部硬度 = '" & 心部硬度.Text & "',"
        strUValue &= "抗拉強度 = '" & 抗拉強度.Text & "',"
        strUValue &= "滲碳層 = '" & 滲碳層.Text & "',"
        strUValue &= "扭力 = '" & 扭力.Text & "',"
        strUValue &= "扭力強度值 = '" & 扭力.Text & "',"
        strUValue &= "華司材質 = '" & 華司材質.Text & "',"
        strUValue &= "華司硬度 = '" & 華司硬度.Text & "',"
        strUValue &= "存放位置 = '" & 存放位置.Text & "',"
        strUValue &= "回火溫度 = '" & 回火溫度.Text & "',"
        strUValue &= "以前爐號 = '" & 以前爐號.Text & "',"
        strUValue &= "注意事項1 = '" & 注意事項1.Text & "',"
        strUValue &= "注意事項2 = '" & 注意事項2.Text & "',"
        strUValue &= "注意事項3 = '" & 注意事項3.Text & "',"
        strUValue &= "品管備註1 = '" & 品管備註1.Text & "',"
        strUValue &= "品管備註2 = '" & 品管備註2.Text & "',"
        strUValue &= "品管備註3 = '" & 品管備註3.Text & "',"
        strUValue &= "製造備註1 = '" & 製造備註1.Text & "',"
        strUValue &= "製造備註2 = '" & 製造備註2.Text & "',"
        strUValue &= "製造備註3 = '" & 製造備註3.Text & "',"
        strUValue &= "客戶代號 = '" & 客戶代號.SelectedValue & "',"
        strUValue &= "加工廠代號 = '" & 加工廠代號.SelectedValue & "',"
        strUValue &= "開單人員 = '" & 開單人員.SelectedValue & "',"
        strUValue &= "司機代號 = '" & 司機代號.SelectedValue & "',"
        strUValue &= "產品代碼 = '" & 產品代碼.SelectedValue & "',"
        strUValue &= "規格代碼 = '" & 規格代碼.SelectedValue & "',"
        strUValue &= "長度代碼 = '" & 長度代碼.SelectedValue & "',"
        strUValue &= "品名分類代碼 = '" & 品名分類代碼.SelectedValue & "',"
        strUValue &= "加工方式代碼 = '" & 加工方式代碼.SelectedValue & "',"
        strUValue &= "材質代碼 = '" & 材質代碼.SelectedValue & "',"
        strUValue &= "表面處理代碼 = '" & 表面處理代碼.SelectedValue & "',"
        strUValue &= "電鍍別代碼 = '" & 電鍍別代碼.SelectedValue & "',"
        strUValue &= "次加工廠代號1 = '" & 次加工廠代號1.SelectedValue & "',"
        strUValue &= "次加工廠代號2 = '" & 次加工廠代號2.SelectedValue & "',"
        strUValue &= "單位代號1 = '" & 單位代號1.SelectedValue & "',"
        strUValue &= "單位代號2 = '" & 單位代號2.SelectedValue & "',"
        strUValue &= "單位代號3 = '" & 單位代號3.SelectedValue & "',"
        strUValue &= "單位代號4 = '" & 單位代號4.SelectedValue & "',"
        strUValue &= "運費種類 = '" & 運費種類.SelectedValue & "',"
        strUValue &= "預排爐號 = '" & 預排爐號.Text & "',"
        strUValue &= "試片 = '" & IIf(試片1.Checked = True, "Y", "N") & "',"
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
        strUValue &= "回火爐速度 = '" & 回火爐速度.Text & "',"
        strUValue &= "牙分類 = '" & 牙分類.SelectedValue & "',"
        strUValue &= "產品名稱 = '" & 產品名稱.Text & "',"
        strUValue &= "所屬工廠 = '" & 所屬工廠.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "工令號碼 = '" & 工令號碼.Text & "'"

        blnCheck = dbEdit(DNS, "進貨單主檔", strUValue, strWValue)

        FormKey = 工令號碼.Text

        Try
            Dim imgData As Byte()         ' storage for the img bytes
            imgData = ImgToByteArray(PictureBox1.Image, ImageFormat.Bmp)

            strUValue = "UPDATE 進貨單頭部記號檔 SET 頭部記號=@頭部記號 WHERE 工令號碼 = '" & 工令號碼.Text & "'"
            Dim sqlCommand As New SqlCommand
            sqlCommand.Parameters.Add("@頭部記號", SqlDbType.VarBinary)
            sqlCommand.Parameters("@頭部記號").Value = imgData

            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            With sqlCommand
                .CommandText = strUValue
                .Connection = objCon99
                .ExecuteNonQuery()
            End With

        Catch ex As Exception

        End Try

        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return blnCheck
    End Function

    ' this is easily used from a class or converted to an extension
    Public Shared Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function
    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False

        '--開啟異動--
        blnCheck = dbDelete(DNS, "進貨單主檔", "工令號碼 = '" & 工令號碼.Text & "'")

        blnCheck = dbDelete(DNS, "進貨單頭部記號檔", "工令號碼 = '" & 工令號碼.Text & "'")

        If 前工令號碼.Text <> "" Then
            strSSQL = "update 出貨退回主檔"
            strSSQL &= "  set  新工令號碼 = ''"
            strSSQL &= " where 出貨退回編號 = '" & 前工令號碼.Text & "'"
            blnCheck = dbExecute(DNS, strSSQL)
        End If

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub

    Public Overrides Sub AfterEndEdit()
        ShowData(FormKey)
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
            'LB車次序號.Text = objDR99("車次序號").ToString

            長度.Text = objDR99("長度代碼").ToString
            產品代號.Text = objDR99("產品代碼").ToString
            試片1.Checked = IIf(objDR99("試片").ToString = "Y", True, False)
            試片2.Checked = IIf(objDR99("試片").ToString = "N", True, False)

            ControlReadData(TabControl, objDR99)
        End If
        Try
            objDR99.Close()    '關閉連結
            objCon99.Close()
            objCmd99.Dispose() '手動釋放資源
            objCon99.Dispose()
            objCon99 = Nothing '移除指標
        Catch ex As Exception

        End Try


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

#Region "物件異動選擇項"
    Private Sub 規格代碼_Leave(sender As System.Object, e As System.EventArgs) Handles 規格代碼.Leave, 規格代碼.SelectedIndexChanged
        If MyTableStatus = 0 Then
            Exit Sub
        End If

        'If 品名分類代碼.SelectedIndex > 0 And 規格代碼.SelectedIndex > 0 And 強度級數.SelectedIndex = 0 Then
        '    Dim 直徑規格數字 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼.SelectedValue & "'")
        '    'MsgBox(直徑規格數字.ToString)
        '    '資料庫公用變數
        '    Dim objConDB As SqlConnection
        '    Dim objCmdDB As SqlCommand
        '    Dim objDRDB As SqlDataReader
        '    Dim strSQLDB As String

        '    '開啟查詢
        '    objConDB = New SqlConnection(DNS)
        '    objConDB.Open()

        '    strSQLDB = "select * from 產品機械性質主檔 a "
        '    strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
        '    strSQLDB &= " and  isNull(a.強度級數,'')=''"
        '    strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString()
        '    strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString()

        '    objCmdDB = New SqlCommand(strSQLDB, objConDB)
        '    objDRDB = objCmdDB.ExecuteReader()
        '    If objDRDB.HasRows Then
        '        If objDRDB.Read Then
        '            依據標準.Text = objDRDB("依據標準").ToString
        '            表面硬度.Text = objDRDB("內部表面硬度").ToString
        '            心部硬度.Text = objDRDB("內部心部硬度").ToString
        '            抗拉強度.Text = objDRDB("內部抗拉強度").ToString
        '            滲碳層.Text = objDRDB("內部滲碳層").ToString
        '        End If
        '    Else
        '        MsgBox("找不到規格檔，機械性質")

        '        'objDRDB.Close()    '關閉連結
        '        'strSQLDB = "select * from 產品機械性質主檔 a "
        '        'strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
        '        'strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString()
        '        'strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString()
        '        'strSQLDB &= " order by 依據標準"

        '        'objCmdDB = New SqlCommand(strSQLDB, objConDB)
        '        'objDRDB = objCmdDB.ExecuteReader()

        '        'If objDRDB.HasRows Then
        '        '    If objDRDB.Read Then
        '        '        依據標準.Text = objDRDB("依據標準").ToString
        '        '        表面硬度.Text = objDRDB("內部表面硬度").ToString
        '        '        心部硬度.Text = objDRDB("內部心部硬度").ToString
        '        '        抗拉強度.Text = objDRDB("內部抗拉強度").ToString
        '        '        滲碳層.Text = objDRDB("內部滲碳層").ToString
        '        '    End If
        '        'Else
        '        '    MsgBox("找不到規格檔，機械性質")
        '        '    依據標準.Text = ""
        '        '    表面硬度.Text = ""
        '        '    心部硬度.Text = ""
        '        '    抗拉強度.Text = ""
        '        '    滲碳層.Text = ""
        '        'End If
        '    End If

        '    objDRDB.Close()    '關閉連結
        '    objConDB.Close()
        '    objCmdDB.Dispose() '手動釋放資源
        '    objConDB.Dispose()
        '    objConDB = Nothing '移除指標

        'End If

        If 品名分類代碼.SelectedIndex > 0 And 規格代碼.SelectedIndex > 0 Then
            Dim 直徑規格數字 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼.SelectedValue & "'")
            'MsgBox(直徑規格數字.ToString)
            '資料庫公用變數
            Dim objConDB As SqlConnection
            Dim objCmdDB As SqlCommand
            Dim objDRDB As SqlDataReader
            Dim strSQLDB As String

            '開啟查詢
            objConDB = New SqlConnection(DNS)
            objConDB.Open()

            strSQLDB = "select * from 產品機械性質主檔 a "
            strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
            strSQLDB &= " and a.強度級數='" + 強度級數.SelectedValue + "'"
            strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString
            strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString

            objCmdDB = New SqlCommand(strSQLDB, objConDB)
            objDRDB = objCmdDB.ExecuteReader()
            If objDRDB.HasRows Then
                If objDRDB.Read Then
                    依據標準.Text = objDRDB("依據標準").ToString
                    表面硬度.Text = objDRDB("內部表面硬度").ToString
                    心部硬度.Text = objDRDB("內部心部硬度").ToString
                    抗拉強度.Text = objDRDB("內部抗拉強度").ToString
                    滲碳層.Text = objDRDB("內部滲碳層").ToString
                End If
            Else
                objDRDB.Close()    '關閉連結
                strSQLDB = "select * from 產品機械性質主檔 a "
                strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
                strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString
                strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString

                objCmdDB = New SqlCommand(strSQLDB, objConDB)
                objDRDB = objCmdDB.ExecuteReader()
                If objDRDB.HasRows Then
                    If objDRDB.Read Then
                        依據標準.Text = objDRDB("依據標準").ToString
                        表面硬度.Text = objDRDB("內部表面硬度").ToString
                        心部硬度.Text = objDRDB("內部心部硬度").ToString
                        抗拉強度.Text = objDRDB("內部抗拉強度").ToString
                        滲碳層.Text = objDRDB("內部滲碳層").ToString
                    End If
                Else

                    MsgBox("找不到規格檔，機械性質")
                    依據標準.Text = ""
                    表面硬度.Text = ""
                    心部硬度.Text = ""
                    抗拉強度.Text = ""
                    滲碳層.Text = ""
                End If
            End If

            objDRDB.Close()    '關閉連結
            strSQLDB = "select * from 扭力規格主檔 a "
            strSQLDB &= " WHERE a.品名分類='" + 品名分類代碼.SelectedValue + "'"
            strSQLDB &= " and a.強度級數='" + 強度級數.SelectedValue + "'"
            strSQLDB &= " and a.直徑規格='" + 規格代碼.SelectedValue + "'"

            objCmdDB = New SqlCommand(strSQLDB, objConDB)
            objDRDB = objCmdDB.ExecuteReader()
            If objDRDB.HasRows Then
                If objDRDB.Read Then
                    扭力.Text = objDRDB("扭力值1").ToString
                Else
                    扭力.Text = ""
                End If
            End If

            objDRDB.Close()    '關閉連結
            objConDB.Close()
            objCmdDB.Dispose() '手動釋放資源
            objConDB.Dispose()
            objConDB = Nothing '移除指標

        End If


            'If Status <> 0 Then
            '    If 品名分類代碼.SelectedIndex > 0 And 規格代碼.SelectedIndex > 0 Then
            '        Dim 直徑規格數字 As Double = dbGetSingleRow(DNS, "s_一層代碼檔", "參數1", "類別 = 'S03N0004' and 一層代碼 = '" & 規格代碼.SelectedValue & "'")
            '        'MsgBox(直徑規格數字.ToString)
            '        '資料庫公用變數
            '        Dim objConDB As SqlConnection
            '        Dim objCmdDB As SqlCommand
            '        Dim objDRDB As SqlDataReader
            '        Dim strSQLDB As String

            '        '開啟查詢
            '        objConDB = New SqlConnection(DNS)
            '        objConDB.Open()

            '        If dbCount(DNS, "產品機械性質主檔", "intCount", "產品分類代號 = '" & 品名分類代碼.SelectedValue & "' and 強度級數='" & 強度級數.SelectedValue & "' and CAST(規格對照起 AS float) <=" + 直徑規格數字.ToString + " and CAST(規格對照迄 AS float) >= " + 直徑規格數字.ToString) <> 0 Then
            '            strSQLDB = "select * from 產品機械性質主檔 a "
            '            strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
            '            strSQLDB &= " and (a.強度級數='" + 強度級數.SelectedValue + "' or isNull(a.強度級數,'')='')"
            '            strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString
            '            strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString
            '        Else
            '            strSQLDB = "select * from 產品機械性質主檔 a "
            '            strSQLDB &= " WHERE a.產品分類代號='" + 品名分類代碼.SelectedValue + "'"
            '            strSQLDB &= " and CAST(a.規格對照起 AS float) <=" + 直徑規格數字.ToString
            '            strSQLDB &= " and CAST(a.規格對照迄 AS float) >=" + 直徑規格數字.ToString
            '        End If



            '        objCmdDB = New SqlCommand(strSQLDB, objConDB)
            '        objDRDB = objCmdDB.ExecuteReader()
            '        If objDRDB.HasRows Then
            '            If objDRDB.Read Then
            '                依據標準.Text = objDRDB("依據標準").ToString
            '                表面硬度.Text = objDRDB("內部表面硬度").ToString
            '                心部硬度.Text = objDRDB("內部心部硬度").ToString
            '                抗拉強度.Text = objDRDB("內部抗拉強度").ToString
            '                滲碳層.Text = objDRDB("內部滲碳層").ToString
            '            End If
            '        Else
            '            MsgBox("找不到規格檔，機械性質")
            '        End If

            '        objDRDB.Close()    '關閉連結
            '        strSQLDB = "select * from 扭力規格主檔 a "
            '        strSQLDB &= " WHERE a.品名分類='" + 品名分類代碼.SelectedValue + "'"
            '        strSQLDB &= " and a.強度級數='" + 強度級數.SelectedValue + "'"
            '        strSQLDB &= " and a.直徑規格='" + 規格代碼.SelectedValue + "'"

            '        objCmdDB = New SqlCommand(strSQLDB, objConDB)
            '        objDRDB = objCmdDB.ExecuteReader()
            '        If objDRDB.HasRows Then
            '            If objDRDB.Read Then
            '                扭力.Text = objDRDB("扭力值1").ToString
            '            End If
            '        End If

            '        objDRDB.Close()    '關閉連結
            '        objConDB.Close()
            '        objCmdDB.Dispose() '手動釋放資源
            '        objConDB.Dispose()
            '        objConDB = Nothing '移除指標
            '    End If
            'End If
    End Sub
    Private Sub 進貨日期_Leave(sender As System.Object, e As System.EventArgs) Handles 進貨日期.Leave
        If MyTableStatus <> 0 Then
            Dim s1 As String = 車次序號.Text

            If FIRM <> "總公司" Then
                ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類 = 'I' AND 日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "' and 所屬工廠='" + FIRM + "'", "車次序號")
            Else
                ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類 = 'I' AND 日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "'", "車次序號")
            End If


            車次序號.SelectedIndex = 車次序號.FindString(s1)
        End If
    End Sub

    Private Sub 車次序號_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 車次序號.SelectedIndexChanged
        If MyTableStatus <> 0 And 車次序號.SelectedIndex <> 0 Then
            ComboBox_DB(加工廠代號, DNS, "(select a.*,b.公司名稱 from 過磅單項目檔 a left join 加工廠主檔 b on a.加工廠代號=b.加工廠代號 ) as T1 ", "加工廠代號", "公司名稱+' '+客戶代號", "車次序號 = '" & 車次序號.Text & "'", "序號 ASC")
            ComboBox_DB(客戶代號, DNS, "(select a.*,b.公司名稱 from 過磅單項目檔 a left join 客戶主檔 b on a.客戶代號=b.客戶代號 ) as T1 ", "客戶代號", "公司名稱", "車次序號 = '" & 車次序號.Text & "'", "公司名稱 ASC")
            司機代號.SelectedValue = dbGetSingleRow(DNS, "過磅單主檔", "司機代號", "車次序號 = '" & 車次序號.Text & "'")
            'Dim 車次比數 As Integer = dbCount(DNS, "進貨單主檔", "intCount", "車次序號 = '" & 車次序號.SelectedValue & "'") + 1
            '工令號碼.Text = 車次序號.Text + 車次比數.ToString.PadLeft(2, "0")
        End If
    End Sub

    Private Sub 加工廠代號_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 加工廠代號.SelectedIndexChanged
        If Status <> 0 And 加工廠代號.SelectedIndex <> 0 Then
            '資料庫公用變數
            Dim objConDB As SqlConnection
            Dim objCmdDB As SqlCommand
            Dim objDRDB As SqlDataReader
            Dim strSQLDB As String

            '工令號碼.Text = 車次序號.Text + dbGetSingleRow(DNS, "過磅單項目檔", "序號", "車次序號 = '" & 車次序號.Text & "' and 加工廠代號=", )
            Dim strString As String = ""

            '開啟查詢
            objConDB = New SqlConnection(DNS)
            objConDB.Open()

            strSQLDB = "select a.*,b.公司名稱,c.簡稱,c.電話1,c.負責人,d.司機代號 from 過磅單項目檔 a "
            strSQLDB &= "left join 加工廠主檔 b on a.加工廠代號=b.加工廠代號 "
            strSQLDB &= "left join 客戶主檔 c on a.客戶代號=c.客戶代號 "
            strSQLDB &= "left join 過磅單主檔 d on a.過磅單號=d.過磅單號 "
            strSQLDB &= " WHERE a.車次序號='" + 車次序號.Text + "'"
            strSQLDB &= " and a.加工廠代號='" + 加工廠代號.SelectedValue + "'"
            strSQLDB &= " and a.序號='" + CStr(加工廠代號.SelectedIndex) + "'"

            objCmdDB = New SqlCommand(strSQLDB, objConDB)
            objDRDB = objCmdDB.ExecuteReader()

            If objDRDB.Read Then
                '工令號碼.Text = 車次序號.Text + objDRDB("序號").ToString.PadLeft(2, "0")
                客戶代號.SelectedValue = objDRDB("客戶代號").ToString
                客戶電話.Text = objDRDB("電話1").ToString
                聯絡人.Text = objDRDB("負責人").ToString
                司機代號.SelectedValue = objDRDB("司機代號").ToString
            End If

            objDRDB.Close()    '關閉連結
            objConDB.Close()
            objCmdDB.Dispose() '手動釋放資源
            objConDB.Dispose()
            objConDB = Nothing '移除指標
        End If

        If 加工廠代號.SelectedIndex <> 0 Then
            '開啟查詢
            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            strSQL99 = "SELECT * FROM 加工廠主檔"
            strSQL99 &= " WHERE 加工廠代號 = '" & 加工廠代號.SelectedValue & "'"
            objCmd99 = New SqlCommand(strSQL99, objCon99)
            objDR99 = objCmd99.ExecuteReader
            If objDR99.Read Then              
                前加負責人.Text = "負責人" + objDR99("負責人").ToString
                前加電話.Text = "前加電話" + objDR99("電話1").ToString
            Else
                前加負責人.Text = "負責人"
                前加電話.Text = "前加電話"
            End If
            objDR99.Close()    '關閉連結
            objCon99.Close()
            objCmd99.Dispose() '手動釋放資源
            objCon99.Dispose()
            objCon99 = Nothing '移除指標

        Else
            前加負責人.Text = "負責人"
            前加電話.Text = "前加電話"
        End If
    End Sub

    Private Sub 產品代號_Leave(sender As System.Object, e As System.EventArgs) Handles 產品代號.Leave
        If MyTableStatus <> 0 Then
            If dbCount(DNS, "s_一層代碼檔", "intCount", "類別 = 'S03N0001' and 一層代碼 = '" & 產品代號.Text & "'") > 0 Then
                產品代碼.SelectedValue = 產品代號.Text
            Else
                產品代碼.SelectedValue = ""
            End If
        End If

    End Sub

    Private Sub 產品代碼_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles 產品代碼.SelectedIndexChanged
        If MyTableStatus <> 0 Then
            產品代號.Text = 產品代碼.SelectedValue
            產品名稱.Text = 產品代碼.Text
        End If
    End Sub
    '裝袋合計合計處理
    Private Sub 數量1_TextChanged(sender As System.Object, e As System.EventArgs) Handles 數量4.TextChanged, 數量3.TextChanged, 數量2.TextChanged, 數量1.TextChanged
        If MyTableStatus <> 0 Then
            Dim A1, A2, A3, A4 As Integer
            Try
                If 數量1.Text = "" Then
                    A1 = 0
                Else
                    A1 = CInt(數量1.Text)
                End If

                If 數量2.Text = "" Then
                    A2 = 0
                Else
                    A2 = CInt(數量2.Text)
                End If

                If 數量3.Text = "" Then
                    A3 = 0
                Else
                    A3 = CInt(數量3.Text)
                End If

                If 數量4.Text = "" Then
                    A4 = 0
                Else
                    A4 = CInt(數量4.Text)
                End If

                裝袋合計.Text = (A1 + A2 + A3 + A4).ToString
            Catch ex As Exception

            End Try
        End If


    End Sub
    '如果「表面處理」選擇為非電鍍時，就不需要選擇電鍍別種類
    Private Sub 表面處理代碼_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles 表面處理代碼.SelectedIndexChanged
        If MyTableStatus <> 0 Then
            If 表面處理代碼.SelectedValue = "電鍍" Then
                電鍍別代碼.Enabled = True
                電鍍別代碼.SelectedValue = "乾性"
            Else
                電鍍別代碼.Enabled = False
                電鍍別代碼.SelectedIndex = 0
                If 表面處理代碼.SelectedValue = "白皮" Then
                    電鍍別代碼.SelectedValue = "白皮"
                End If

                If 表面處理代碼.SelectedValue = "黑化" Then
                    電鍍別代碼.SelectedValue = "黑化"
                End If
            End If
        End If
    End Sub
    '邊在輸入進貨資料時，系統就會一邊在幫我們蒐尋舊資料,品名分類、品名、強度級數、材質、規格、加工方式、線材爐號
    Private Sub 線材爐號_Leave(sender As System.Object, e As System.EventArgs) Handles 線材爐號.Leave
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        '查詢語法
        strSQL99 = "SELECT "
        strSQL99 &= " m.* FROM 進貨單主檔 AS m"
        strSQL99 &= " WHERE 1=1"
        If CK1.Checked = True And 產品代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.產品代碼 = '" & 產品代碼.SelectedValue & "'"
        If CK2.Checked = True And 規格代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.規格代碼 = '" & 規格代碼.SelectedValue & "'"
        If CK3.Checked = True And 長度代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.長度代碼 = '" & 長度代碼.SelectedValue & "'"
        If CK4.Checked = True And 品名分類代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.品名分類代碼 = '" & 品名分類代碼.SelectedValue & "'"
        If CK5.Checked = True And 加工方式代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.加工方式代碼 = '" & 加工方式代碼.SelectedValue & "'"
        If CK6.Checked = True And 材質代碼.SelectedIndex <> 0 Then strSQL99 &= " AND m.材質代碼 = '" & 材質代碼.SelectedValue & "'"
        If CK7.Checked = True And 強度級數.SelectedIndex <> 0 Then strSQL99 &= " AND m.強度級數 = '" & 強度級數.SelectedValue & "'"
        If CK8.Checked = True And 線材爐號.Text <> "" Then strSQL99 &= " AND m.線材爐號 = '" & 線材爐號.Text & "'"
        strSQL99 &= " order by 日期 desc"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            回火溫度.Text = objDR99("回火爐2").ToString
            以前爐號.Text = objDR99("預排爐號").ToString

            流量.Text = objDR99("流量").ToString
            CP值.Text = objDR99("CP值").ToString
            氨值1.Text = objDR99("氨值1").ToString
            氨值2.Text = objDR99("氨值2").ToString
            氨值3.Text = objDR99("氨值3").ToString
            氨值4.Text = objDR99("氨值4").ToString
            加熱爐1.Text = objDR99("加熱爐1").ToString
            加熱爐2.Text = objDR99("加熱爐2").ToString
            加熱爐3.Text = objDR99("加熱爐3").ToString
            加熱爐4.Text = objDR99("加熱爐4").ToString
            加熱爐5.Text = objDR99("加熱爐5").ToString
            加熱爐6.Text = objDR99("加熱爐6").ToString
            加熱爐油溫.Text = objDR99("加熱爐油溫").ToString
            加熱爐速度.Text = objDR99("加熱爐速度").ToString
            回火爐1.Text = objDR99("回火爐1").ToString
            回火爐2.Text = objDR99("回火爐2").ToString
            回火爐3.Text = objDR99("回火爐3").ToString
            回火爐4.Text = objDR99("回火爐4").ToString
            回火爐5.Text = objDR99("回火爐5").ToString
            回火爐6.Text = objDR99("回火爐6").ToString
            回火爐速度.Text = objDR99("回火爐速度").ToString

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標


    End Sub
#End Region
    '點選開啓舊檔視窗
    Private Sub btuSOld_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btuSOld.Click
        Dim S_S03N0120_1 As New S_S03N0120_1

        '開啟視窗
        S_S03N0120_1.MdiParent = fmMain
        S_S03N0120_1.sPageName = "S03N0120"
        S_S03N0120_1.Show()

        For Each MdiChildForm As Object In My.Forms.fmMain.MdiChildren
            If MdiChildForm.Name = "S_S03N0120_1" Then
                If CK1.Checked Then
                    MdiChildForm.產品代碼.SelectedValue = 產品代碼.SelectedValue
                    MdiChildForm.產品名稱.text = 產品名稱.Text
                End If
                If CK2.Checked Then
                    MdiChildForm.規格代碼.SelectedValue = 規格代碼.SelectedValue
                End If
                If CK3.Checked Then
                    MdiChildForm.長度代碼.SelectedValue = 長度代碼.SelectedValue
                End If
                If CK4.Checked Then
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
    '進入報表設計模式

    '開啓檔案,以載入圖片
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        With OpenFileDialog1
            Dim FileAddrValue As String = INI_Read("CONFIG", "SET", "HeadFile") 'DNS設定值
            .InitialDirectory = FileAddrValue
            .Filter = "Bitmaps|*.bmp"
            .FilterIndex = 1
        End With

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            PictureBox1.BorderStyle = BorderStyle.Fixed3D
        End If
    End Sub

#Region "報表處理"
    '列印
    Public Overrides Sub PrintWindows()
        TabControl.SelectedTab = Me.TabPage3
    End Sub
    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click

        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "客戶加工單.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", 工令號碼.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
        'report.Show()
        'report.Dispose()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        FRreport.Design()
    End Sub

    Private Sub TabPage3_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage3.Enter
        btnPreviewRep_Click(sender, e)
    End Sub

    Private Sub btnPreviewRep1_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep1.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl2
        FRreport.Load(thisFolder + "客戶供應製品接收檢驗記錄表.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", strSystemToDate(RepDate1.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey1", strSystemToDate(RepDate2.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey2", RepText1.Text)

        If RepText2.Text = "" Then RepText2.Text = RepText1.Text
        FRreport.SetParameterValue("RepKey3", RepText2.Text)

        FRreport.SetParameterValue("RepKey4", RepText3.Text)

        If RepText4.Text = "" Then RepText4.Text = RepText3.Text
        FRreport.SetParameterValue("RepKey5", RepText4.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep1_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep1.Click
        FRreport.Design()
    End Sub
#End Region



    Private Sub s工令號碼_Leave(sender As System.Object, e As System.EventArgs) Handles s工令號碼.Leave, BtnSerach.Click
        For i As Integer = 0 To DataGridView.RowCount() - 1
            If s工令號碼.Text = DataGridView.Rows(i).Cells(0).Value Then
                DataGridView.CurrentCell = DataGridView.Rows(i).Cells(0)
                intCol = 0
                intRow = i

                FlagMoveSeat(0) '讀取值
            End If
        Next
    End Sub

    Private Sub BtnOverLu_Click(sender As System.Object, e As System.EventArgs) Handles BtnOverLu.Click
        Dim strSQL As String = ""

        '查詢條件        
        If o客戶.SelectedValue <> "" Then strSQL &= " AND m.客戶代號 = '" & o客戶.SelectedValue & "'"
        If o規格.SelectedValue <> "" Then strSQL &= " AND m.規格代碼 = '" & o規格.SelectedValue & "'"
        If o狀態.SelectedValue <> "" Then strSQL &= " AND m.狀態 = '" & o狀態.SelectedValue & "'"
        If o工令號碼.Text <> "" Then strSQL &= " AND m.工令號碼 LIKE '%" & o工令號碼.Text & "%'"
        FillData(strSQL)
    End Sub

    Private Sub BtnNewProduct_Click(sender As System.Object, e As System.EventArgs) Handles BtnNewProduct.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S03N0001"
        frmLevel12.butDelete.Visible = False
        frmLevel12.ShowDialog()
        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
    End Sub

    Private Sub BtnNewLen_Click(sender As System.Object, e As System.EventArgs) Handles BtnNewLen.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S03N0005"
        frmLevel12.butDelete.Visible = False
        frmLevel12.ShowDialog()
        ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
    End Sub

    Private Sub 長度代碼_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 長度代碼.SelectedIndexChanged
        If MyTableStatus <> 0 And 長度代碼.SelectedIndex <> 0 Then
            長度.Text = 長度代碼.SelectedValue
        End If
    End Sub

    Private Sub BtnNewRemark_Click(sender As Object, e As EventArgs) Handles BtnNewRemark.Click
        Dim frmLevel1 As New frmLevel1
        frmLevel1.txtPage.Text = "S03N0012"
        frmLevel1.ShowDialog()

        txtAutoComplete()
    End Sub

    Private Sub 回火溫度_TextChanged(sender As Object, e As EventArgs) Handles 回火溫度.TextChanged
        If MyTableStatus <> 0 Then
            回火爐2.Text = 回火溫度.Text
        End If

    End Sub


    Private Sub BtnSelectBack_Click(sender As Object, e As EventArgs) Handles BtnSelectBack.Click
        Dim objCon01 As SqlConnection
        Dim objCmd01 As SqlCommand
        Dim objDR01 As SqlDataReader
        Dim strSQL01 As String

        Dim S_S03N0120_2 As New S_S03N0120_2

        '開啟視窗
        '  S_S03N0120_2.MdiParent = fmMain
        ' S_S03N0120_2.Show()

        S_S03N0120_2.ShowDialog()

        If S_S03N0120_2.DialogResult = Windows.Forms.DialogResult.OK Then
            前工令號碼.Text = S_S03N0120_2.SelectNO
            If S_S03N0120_2.SelectKind = "1" Then
                If MessageBox.Show("廠外退回-是否帶入前工令的資料？", "帶入資料", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                        = Windows.Forms.DialogResult.Yes Then

                    '開啟查詢
                    objCon99 = New SqlConnection(DNS)
                    objCon99.Open()

                    strSQL99 = "SELECT a.* FROM 進貨單主檔 a inner join 出貨退回主檔 b on a.工令號碼=b.工令號碼"
                    strSQL99 &= " WHERE b.出貨退回編號 = '" & 前工令號碼.Text & "'"

                    Dim 出貨退回工令號碼 As String = ""

                    objCmd99 = New SqlCommand(strSQL99, objCon99)
                    objDR99 = objCmd99.ExecuteReader

                    If objDR99.Read Then
                        '異動狀態*****
                        出貨退回工令號碼 = objDR99("工令號碼").ToString

                        長度.Text = objDR99("長度代碼").ToString
                        產品代號.Text = objDR99("產品代碼").ToString
                        試片1.Checked = IIf(objDR99("試片").ToString = "Y", True, False)
                        試片2.Checked = IIf(objDR99("試片").ToString = "N", True, False)

                        客戶單號.Text = objDR99("客戶單號").ToString
                        客戶批號.Text = objDR99("客戶批號").ToString
                        長度說明.Text = objDR99("長度說明").ToString
                        規範分類.Text = objDR99("規範分類").ToString
                        強度級數.Text = objDR99("強度級數").ToString
                        產品代碼.SelectedValue = objDR99("產品代碼").ToString

                        規格代碼.SelectedValue = objDR99("規格代碼").ToString
                        長度代碼.SelectedValue = objDR99("長度代碼").ToString
                        品名分類代碼.SelectedValue = objDR99("品名分類代碼").ToString
                        加工方式代碼.SelectedValue = objDR99("加工方式代碼").ToString
                        材質代碼.SelectedValue = objDR99("材質代碼").ToString
                        表面處理代碼.SelectedValue = objDR99("表面處理代碼").ToString
                        電鍍別代碼.SelectedValue = objDR99("電鍍別代碼").ToString
                        次加工廠代號1.SelectedValue = objDR99("次加工廠代號1").ToString
                        次加工廠代號2.SelectedValue = objDR99("次加工廠代號2").ToString
                        單位代號1.SelectedValue = objDR99("單位代號1").ToString
                        單位代號2.SelectedValue = objDR99("單位代號2").ToString
                        單位代號3.SelectedValue = objDR99("單位代號3").ToString
                        單位代號4.SelectedValue = objDR99("單位代號4").ToString
                        運費種類.SelectedValue = objDR99("運費種類").ToString
                        預排爐號.Text = objDR99("預排爐號").ToString


                        數量1.Text = objDR99("數量1").ToString
                        數量2.Text = objDR99("數量2").ToString
                        數量3.Text = objDR99("數量3").ToString
                        數量4.Text = objDR99("數量4").ToString
                        裝袋合計.Text = objDR99("裝袋合計").ToString
                        淨重.Text = objDR99("淨重").ToString
                        線材爐號.Text = objDR99("線材爐號").ToString
                        依據標準.Text = objDR99("依據標準").ToString
                        表面硬度.Text = objDR99("表面硬度").ToString
                        心部硬度.Text = objDR99("心部硬度").ToString
                        抗拉強度.Text = objDR99("抗拉強度").ToString
                        滲碳層.Text = objDR99("滲碳層").ToString
                        扭力.Text = objDR99("扭力").ToString
                        華司材質.Text = objDR99("華司材質").ToString
                        華司硬度.Text = objDR99("華司硬度").ToString
                        存放位置.Text = objDR99("存放位置").ToString
                        回火溫度.Text = objDR99("回火溫度").ToString
                        以前爐號.Text = objDR99("以前爐號").ToString
                        注意事項1.Text = objDR99("注意事項1").ToString
                        注意事項2.Text = objDR99("注意事項2").ToString
                        注意事項3.Text = objDR99("注意事項3").ToString
                        品管備註1.Text = objDR99("品管備註1").ToString
                        品管備註2.Text = objDR99("品管備註2").ToString
                        品管備註3.Text = objDR99("品管備註3").ToString
                        製造備註1.Text = objDR99("製造備註1").ToString
                        製造備註2.Text = objDR99("製造備註2").ToString
                        製造備註3.Text = objDR99("製造備註3").ToString



                        流量.Text = objDR99("流量").ToString
                        CP值.Text = objDR99("CP值").ToString
                        氨值1.Text = objDR99("氨值1").ToString
                        氨值2.Text = objDR99("氨值2").ToString
                        氨值3.Text = objDR99("氨值3").ToString
                        氨值4.Text = objDR99("氨值4").ToString
                        加熱爐1.Text = objDR99("加熱爐1").ToString
                        加熱爐2.Text = objDR99("加熱爐2").ToString
                        加熱爐3.Text = objDR99("加熱爐3").ToString
                        加熱爐4.Text = objDR99("加熱爐4").ToString
                        加熱爐5.Text = objDR99("加熱爐5").ToString
                        加熱爐6.Text = objDR99("加熱爐6").ToString
                        加熱爐7.Text = objDR99("加熱爐7").ToString
                        加熱爐8.Text = objDR99("加熱爐8").ToString
                        加熱爐油溫.Text = objDR99("加熱爐油溫").ToString
                        加熱爐速度.Text = objDR99("加熱爐速度").ToString
                        回火爐1.Text = objDR99("回火爐1").ToString
                        回火爐2.Text = objDR99("回火爐2").ToString
                        回火爐3.Text = objDR99("回火爐3").ToString
                        回火爐4.Text = objDR99("回火爐4").ToString
                        回火爐5.Text = objDR99("回火爐5").ToString
                        回火爐6.Text = objDR99("回火爐6").ToString
                        回火爐速度.Text = objDR99("回火爐速度").ToString
                        牙分類.SelectedValue = objDR99("牙分類").ToString
                        產品名稱.Text = objDR99("產品名稱").ToString

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
                    strSQL99 &= " WHERE 工令號碼 = '" & 出貨退回工令號碼 & "'"

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


                End If
            End If

            If S_S03N0120_2.SelectKind = "2" Then

                If MessageBox.Show("廠內退回-是否帶入前工令的資料？", "帶入資料", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                        = Windows.Forms.DialogResult.Yes Then

                    '開啟查詢
                    objCon01 = New SqlConnection(DNS)
                    objCon01.Open()

                    strSQL01 = "SELECT a.* FROM 進貨單主檔 a "
                    strSQL01 &= " WHERE a.工令號碼 = '" & 前工令號碼.Text & "'"


                    objCmd01 = New SqlCommand(strSQL01, objCon01)
                    objDR01 = objCmd01.ExecuteReader

                    If objDR01.Read Then
                        '異動狀態*****


                        進貨日期.Text = objDR01("進貨日期").ToString

                        If FIRM <> "總公司" Then
                            ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類 = 'I' AND 日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "' and 所屬工廠='" + FIRM + "'", "車次序號")
                        Else
                            ComboBox_DB(車次序號, DNS, "過磅單主檔", "車次序號", "車次序號", "分類 = 'I' AND 日期='" & strSystemToDate(進貨日期.Value.ToShortDateString) & "'", "車次序號")
                        End If

                        車次序號.SelectedValue = objDR01("車次序號").ToString

                        司機代號.SelectedValue = objDR01("司機代號").ToString
                        加工廠代號.SelectedValue = objDR01("加工廠代號").ToString
                        客戶代號.SelectedValue = objDR01("客戶代號").ToString


                        長度.Text = objDR01("長度代碼").ToString
                        產品代號.Text = objDR01("產品代碼").ToString
                        試片1.Checked = IIf(objDR01("試片").ToString = "Y", True, False)
                        試片2.Checked = IIf(objDR01("試片").ToString = "N", True, False)

                        強度級數.Text = objDR01("強度級數").ToString
                        產品代碼.SelectedValue = objDR01("產品代碼").ToString
                        規格代碼.SelectedValue = objDR01("規格代碼").ToString
                        長度代碼.SelectedValue = objDR01("長度代碼").ToString
                        品名分類代碼.SelectedValue = objDR01("品名分類代碼").ToString
                        加工方式代碼.SelectedValue = objDR01("加工方式代碼").ToString
                        材質代碼.SelectedValue = objDR01("材質代碼").ToString
                        表面處理代碼.SelectedValue = objDR01("表面處理代碼").ToString
                        電鍍別代碼.SelectedValue = objDR01("電鍍別代碼").ToString
                        次加工廠代號1.SelectedValue = objDR01("次加工廠代號1").ToString
                        次加工廠代號2.SelectedValue = objDR01("次加工廠代號2").ToString
                        單位代號1.SelectedValue = objDR01("單位代號1").ToString
                        單位代號2.SelectedValue = objDR01("單位代號2").ToString
                        單位代號3.SelectedValue = objDR01("單位代號3").ToString
                        單位代號4.SelectedValue = objDR01("單位代號4").ToString
                        運費種類.SelectedValue = objDR01("運費種類").ToString
                        預排爐號.Text = objDR01("預排爐號").ToString


                        客戶單號.Text = objDR01("客戶單號").ToString
                        客戶批號.Text = objDR01("客戶批號").ToString
                        長度說明.Text = objDR01("長度說明").ToString
                        規範分類.Text = objDR01("規範分類").ToString

                        數量1.Text = objDR01("數量1").ToString
                        數量2.Text = objDR01("數量2").ToString
                        數量3.Text = objDR01("數量3").ToString
                        數量4.Text = objDR01("數量4").ToString
                        裝袋合計.Text = objDR01("裝袋合計").ToString
                        淨重.Text = objDR01("淨重").ToString
                        線材爐號.Text = objDR01("線材爐號").ToString
                        依據標準.Text = objDR01("依據標準").ToString
                        表面硬度.Text = objDR01("表面硬度").ToString
                        心部硬度.Text = objDR01("心部硬度").ToString
                        抗拉強度.Text = objDR01("抗拉強度").ToString
                        滲碳層.Text = objDR01("滲碳層").ToString
                        扭力.Text = objDR01("扭力").ToString
                        華司材質.Text = objDR01("華司材質").ToString
                        華司硬度.Text = objDR01("華司硬度").ToString
                        存放位置.Text = objDR01("存放位置").ToString
                        回火溫度.Text = objDR01("回火溫度").ToString
                        以前爐號.Text = objDR01("以前爐號").ToString
                        注意事項1.Text = objDR01("注意事項1").ToString
                        注意事項2.Text = objDR01("注意事項2").ToString
                        注意事項3.Text = objDR01("注意事項3").ToString
                        品管備註1.Text = objDR01("品管備註1").ToString
                        品管備註2.Text = objDR01("品管備註2").ToString
                        品管備註3.Text = objDR01("品管備註3").ToString
                        製造備註1.Text = objDR01("製造備註1").ToString
                        製造備註2.Text = objDR01("製造備註2").ToString
                        製造備註3.Text = objDR01("製造備註3").ToString



                        流量.Text = objDR01("流量").ToString
                        CP值.Text = objDR01("CP值").ToString
                        氨值1.Text = objDR01("氨值1").ToString
                        氨值2.Text = objDR01("氨值2").ToString
                        氨值3.Text = objDR01("氨值3").ToString
                        氨值4.Text = objDR01("氨值4").ToString
                        加熱爐1.Text = objDR01("加熱爐1").ToString
                        加熱爐2.Text = objDR01("加熱爐2").ToString
                        加熱爐3.Text = objDR01("加熱爐3").ToString
                        加熱爐4.Text = objDR01("加熱爐4").ToString
                        加熱爐5.Text = objDR01("加熱爐5").ToString
                        加熱爐6.Text = objDR01("加熱爐6").ToString
                        加熱爐7.Text = objDR01("加熱爐7").ToString
                        加熱爐8.Text = objDR01("加熱爐8").ToString
                        加熱爐油溫.Text = objDR01("加熱爐油溫").ToString
                        加熱爐速度.Text = objDR01("加熱爐速度").ToString
                        回火爐1.Text = objDR01("回火爐1").ToString
                        回火爐2.Text = objDR01("回火爐2").ToString
                        回火爐3.Text = objDR01("回火爐3").ToString
                        回火爐4.Text = objDR01("回火爐4").ToString
                        回火爐5.Text = objDR01("回火爐5").ToString
                        回火爐6.Text = objDR01("回火爐6").ToString
                        回火爐速度.Text = objDR01("回火爐速度").ToString
                        牙分類.SelectedValue = objDR01("牙分類").ToString
                        產品名稱.Text = objDR01("產品名稱").ToString

                    End If

                    objDR01.Close()    '關閉連結
                    objCon01.Close()
                    objCmd01.Dispose() '手動釋放資源
                    objCon01.Dispose()
                    objCon01 = Nothing '移除指標

                    PictureBox1.Image = Nothing

                    objCon01 = New SqlConnection(DNS)
                    objCon01.Open()

                    strSQL01 = "SELECT 頭部記號 FROM 進貨單頭部記號檔"
                    strSQL01 &= " WHERE 工令號碼 = '" & 前工令號碼.Text & "'"

                    objCmd01 = New SqlCommand(strSQL01, objCon01)

                    Try
                        Dim pictureData As Byte() = DirectCast(objCmd01.ExecuteScalar(), Byte())
                        Dim pictures As Image = Nothing
                        Using stream As New System.IO.MemoryStream(pictureData)
                            pictures = Image.FromStream(stream)

                        End Using
                        PictureBox1.Image = pictures
                    Catch ex As Exception

                    End Try


                    objCon01.Close()
                    objCmd01.Dispose() '手動釋放資源
                    objCon01.Dispose()
                    objCon01 = Nothing '移除指標


                End If
            End If

            If S_S03N0120_2.SelectKind = "3" Then
                If MessageBox.Show("轉廠-是否帶入前工令的資料？", "帶入資料", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) _
                        = Windows.Forms.DialogResult.Yes Then

                    '開啟查詢
                    objCon99 = New SqlConnection(DNS)
                    objCon99.Open()

                    strSQL99 = "SELECT a.* FROM 進貨單主檔 a inner join 轉廠單項目檔 b on a.工令號碼=b.工令號碼"
                    strSQL99 &= " WHERE b.工令號碼 = '" & 前工令號碼.Text & "'"



                    objCmd99 = New SqlCommand(strSQL99, objCon99)
                    objDR99 = objCmd99.ExecuteReader

                    If objDR99.Read Then
                        '異動狀態*****

                        長度.Text = objDR99("長度代碼").ToString
                        產品代號.Text = objDR99("產品代碼").ToString
                        試片1.Checked = IIf(objDR99("試片").ToString = "Y", True, False)
                        試片2.Checked = IIf(objDR99("試片").ToString = "N", True, False)

                        客戶單號.Text = objDR99("客戶單號").ToString
                        客戶批號.Text = objDR99("客戶批號").ToString
                        長度說明.Text = objDR99("長度說明").ToString
                        規範分類.Text = objDR99("規範分類").ToString
                        強度級數.Text = objDR99("強度級數").ToString
                        產品代碼.SelectedValue = objDR99("產品代碼").ToString

                        規格代碼.SelectedValue = objDR99("規格代碼").ToString
                        長度代碼.SelectedValue = objDR99("長度代碼").ToString
                        品名分類代碼.SelectedValue = objDR99("品名分類代碼").ToString
                        加工方式代碼.SelectedValue = objDR99("加工方式代碼").ToString
                        材質代碼.SelectedValue = objDR99("材質代碼").ToString
                        表面處理代碼.SelectedValue = objDR99("表面處理代碼").ToString
                        電鍍別代碼.SelectedValue = objDR99("電鍍別代碼").ToString
                        次加工廠代號1.SelectedValue = objDR99("次加工廠代號1").ToString
                        次加工廠代號2.SelectedValue = objDR99("次加工廠代號2").ToString
                        單位代號1.SelectedValue = objDR99("單位代號1").ToString
                        單位代號2.SelectedValue = objDR99("單位代號2").ToString
                        單位代號3.SelectedValue = objDR99("單位代號3").ToString
                        單位代號4.SelectedValue = objDR99("單位代號4").ToString
                        運費種類.SelectedValue = objDR99("運費種類").ToString
                        預排爐號.Text = objDR99("預排爐號").ToString


                        數量1.Text = objDR99("數量1").ToString
                        數量2.Text = objDR99("數量2").ToString
                        數量3.Text = objDR99("數量3").ToString
                        數量4.Text = objDR99("數量4").ToString
                        裝袋合計.Text = objDR99("裝袋合計").ToString
                        淨重.Text = objDR99("淨重").ToString
                        線材爐號.Text = objDR99("線材爐號").ToString
                        依據標準.Text = objDR99("依據標準").ToString
                        表面硬度.Text = objDR99("表面硬度").ToString
                        心部硬度.Text = objDR99("心部硬度").ToString
                        抗拉強度.Text = objDR99("抗拉強度").ToString
                        滲碳層.Text = objDR99("滲碳層").ToString
                        扭力.Text = objDR99("扭力").ToString
                        華司材質.Text = objDR99("華司材質").ToString
                        華司硬度.Text = objDR99("華司硬度").ToString
                        存放位置.Text = objDR99("存放位置").ToString
                        回火溫度.Text = objDR99("回火溫度").ToString
                        以前爐號.Text = objDR99("以前爐號").ToString
                        注意事項1.Text = objDR99("注意事項1").ToString
                        注意事項2.Text = objDR99("注意事項2").ToString
                        注意事項3.Text = objDR99("注意事項3").ToString
                        品管備註1.Text = objDR99("品管備註1").ToString
                        品管備註2.Text = objDR99("品管備註2").ToString
                        品管備註3.Text = objDR99("品管備註3").ToString
                        製造備註1.Text = objDR99("製造備註1").ToString
                        製造備註2.Text = objDR99("製造備註2").ToString
                        製造備註3.Text = objDR99("製造備註3").ToString



                        流量.Text = objDR99("流量").ToString
                        CP值.Text = objDR99("CP值").ToString
                        氨值1.Text = objDR99("氨值1").ToString
                        氨值2.Text = objDR99("氨值2").ToString
                        氨值3.Text = objDR99("氨值3").ToString
                        氨值4.Text = objDR99("氨值4").ToString
                        加熱爐1.Text = objDR99("加熱爐1").ToString
                        加熱爐2.Text = objDR99("加熱爐2").ToString
                        加熱爐3.Text = objDR99("加熱爐3").ToString
                        加熱爐4.Text = objDR99("加熱爐4").ToString
                        加熱爐5.Text = objDR99("加熱爐5").ToString
                        加熱爐6.Text = objDR99("加熱爐6").ToString
                        加熱爐7.Text = objDR99("加熱爐7").ToString
                        加熱爐8.Text = objDR99("加熱爐8").ToString
                        加熱爐油溫.Text = objDR99("加熱爐油溫").ToString
                        加熱爐速度.Text = objDR99("加熱爐速度").ToString
                        回火爐1.Text = objDR99("回火爐1").ToString
                        回火爐2.Text = objDR99("回火爐2").ToString
                        回火爐3.Text = objDR99("回火爐3").ToString
                        回火爐4.Text = objDR99("回火爐4").ToString
                        回火爐5.Text = objDR99("回火爐5").ToString
                        回火爐6.Text = objDR99("回火爐6").ToString
                        回火爐速度.Text = objDR99("回火爐速度").ToString
                        牙分類.SelectedValue = objDR99("牙分類").ToString
                        產品名稱.Text = objDR99("產品名稱").ToString

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
                    strSQL99 &= " WHERE 工令號碼 = '" & 前工令號碼.Text & "'"

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


                End If
            End If
        End If

    End Sub

   
    Private Sub btnPreviewRep2_Click(sender As Object, e As EventArgs) Handles btnPreviewRep2.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl3
        FRreport.Load(thisFolder + "客戶加工單崗山.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", 工令號碼.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep2_Click(sender As Object, e As EventArgs) Handles btnDesignRep2.Click
        Dim thisFolder As String = ReportDir
        FRreport.Load(thisFolder + "客戶加工單崗山.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", 工令號碼.Text)
        FRreport.Design()
    End Sub
End Class
