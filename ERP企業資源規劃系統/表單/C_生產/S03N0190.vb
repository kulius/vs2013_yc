Public Class S03N0190
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
    Private Sub S030190_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        BasicPanel.Width = WorkingArea_Width()
        BCtrl.Visible = False
        BasicPanel.Visible = False

        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        'DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S030190_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    '列印
    Public Overrides Sub PrintWindows()
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "簡稱+' '+客戶代號", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(s規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")

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
        strSSQL = "SELECT t5.一層名稱 AS 狀態,m.*,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",客戶簡稱 = case when t1.簡稱<>t7.簡稱 then t7.簡稱+'-'+t1.簡稱 else t1.簡稱 end ,t7.簡稱"
        strSSQL &= ",t2.一層名稱 AS 品名,t3.一層名稱+'X'+isnull(t8.一層名稱,'')+長度說明 AS 規格,t4.一層名稱 AS 材質,t5.一層名稱 AS 狀態,t6.一層名稱 AS 表面 FROM 進貨單主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        strSSQL &= " WHERE 1=1 and 狀態<='2'"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 工令號碼 DESC"

        '顯示欄位

        arrRowName = {"客戶簡稱", "爐號", "進貨日期", "工令號碼", "品名", "規格", "材質", "表面", "回温", "桶數", "淨重", "狀態", "表面硬度", "心部硬度", "線材爐號"}
        '"客戶", "工令號碼", "日期", "品名", "規格", "材質", "表面", "回温", "表面硬度", "心部硬度", "線材爐號", "狀態"
        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)

        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                DataGridView.Enabled = True

            Case 1 '新增模式
                DataGridView.Enabled = False


            Case 2 '修改模式
                DataGridView.Enabled = False

            Case 3 '複製模式
                DataGridView.Enabled = False

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
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        Return blnCheck
    End Function

    '刪除
    Public Overrides Sub DeleteData()
        Dim blnCheck As Boolean = False


        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        'Driver(strKey1) '扭力規格主檔        
    End Sub
    '扭力規格主檔
    Sub Driver(ByVal strKey1 As String)
    End Sub
#End Region

#Region "物件異動選擇項"

#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim str As String
        str = " "
        If s客戶代號.SelectedIndex <> 0 Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If

        If s工令號碼.Text <> "" Then
            str &= " and m.工令號碼 like '%" + s工令號碼.Text + "%'"
        End If

        If s規格代碼.SelectedIndex <> 0 Then
            str &= " and m.規格代碼 ='" + s規格代碼.SelectedValue + "'"
        End If

        FillData(str)
    End Sub

    Private Sub s客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s客戶代號.SelectedIndexChanged
        Try
            If s客戶代號.SelectedIndex <> 0 Then
                s客戶代號1.Text = s客戶代號.SelectedValue
            End If
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
End Class
