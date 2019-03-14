Imports FastReport
Imports FastReport.Utils
Public Class S06N0100
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
    Dim FormKey As String = "" '目前編輯的KEY值
#End Region
#Region "單用變數"
    Dim strPage As String = ""
    Dim FRreport As New Report
#End Region

#Region "@Form及功能操作@"
    Private Sub S06N0100_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '按鍵
        Dim btnItems() As ToolStripButton = {}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next


        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集
    End Sub
    Private Sub S06N0100_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S06N0100_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        ControlFocus(TabPage6, e)
    End Sub
    Private Sub S06N0100_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If DataGridView.Focused Then
            intRow = DataGridView.CurrentCell.RowIndex
            If e.KeyCode = Keys.Down Then FlagMoveSeat(0)
            If e.KeyCode = Keys.Up Then FlagMoveSeat(0)
        End If
    End Sub
    '尋找
    Public Overrides Sub FindWindows()
    End Sub
    Public Overrides Function BeforeCancelEdit() As Boolean
        If 憑單號碼.Text <> "" Then
            MyTableStatus = 0
            SetControls(0)
            ShowData(憑單號碼.Text)
            Return False
        Else
            Return True
        End If

    End Function
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"憑單號碼", "客戶代號", "客戶", "請款日期", "金額", "含稅", "總計", "收款日期", "現金", "票據", "出貨日期起", "出貨日期迄"}
        Dim arrColWidth() As String = {"100", "100", "100", "100", "100", "100", "100", "100", "100", "100", "100", "100"}

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

        '查詢語法
        strSSQL = "SELECT top " + PageCount.Text + " m.*, t1.簡稱 as 客戶  FROM 應收帳款主檔 AS m"
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 憑單號碼 DESC"

        '顯示欄位
        arrRowName = {"憑單號碼", "客戶代號", "客戶", "請款日期", "金額", "含稅", "總計", "收款日期", "現金", "票據", "出貨日期起", "出貨日期迄"}

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
        Dim objDataGridViewR() As DataGridView = {OutDataDGV}

        Set_Control_RW(TabControl, butStatus)

        DataGridViewR_Control(objDataGridViewR, butStatus)

        憑單號碼.ReadOnly = True


        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = True
                客戶代碼.ReadOnly = True

            Case 1 '新增模式
                TabControl.SelectedTab = Me.TabPage2

                InvDataDGV.Rows.Clear()

                DataGridView.Enabled = False
                strPage = CStr(請款日期.Value.Year) + 請款日期.Value.Month.ToString.PadLeft(2, "0") + "-"

                Dim NowPayDate As DateTime

                If DateTime.Today.Day() < 20 Then
                    NowPayDate = DateAdd(DateInterval.Month, -1, Now)
                Else
                    NowPayDate = Now
                End If

                所屬年月.Text = CStr(NowPayDate.Year) + NowPayDate.Month.ToString.PadLeft(2, "0")
                收款日期.Checked = False
                '憑單號碼.Text = ERP_AutoNo_憑單號碼(DNS, strPage, "應收帳款主檔", "憑單號碼")
                客戶代碼.ReadOnly = False
                客戶代碼.Text = ""
                客戶代碼.Focus()

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                客戶代碼.ReadOnly = False
                客戶代碼.Focus()
            Case 3 '複製模式
                TabControl.SelectedTab = Me.TabPage2
                DataGridView.Enabled = False
                憑單號碼.Focus()
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

        憑單號碼.Text = ERP_AutoNo_憑單號碼(DNS, strPage, "應收帳款主檔", "憑單號碼")
        '代號是否有重複
        If dbDataCheck(DNS, "應收帳款主檔", "憑單號碼 = '" & 憑單號碼.Text & "'") = True Then MsgBox("系統訊息：【憑單號碼】已有相同之資料!!", MsgBoxStyle.Exclamation, "注意") : blnCheck = False

        If blnCheck = False Then Return False : Exit Function
        '防呆結束*****


        '開啟儲存*****
        strIRow = "憑單號碼,請款日期,出貨日期起,出貨日期迄,"
        strIRow &= "客戶代號,金額,含稅,總計,CK含稅,重量,"
        strIRow &= "所屬年月,收款日期,本期應收帳款,"
        strIRow &= "扣款,折讓,現金,票據,郵票,"
        strIRow &= "本期扣款,扣款備註,本期補請,補請備註,出貨金額,"
        strIRow &= "建立人員,建立日期,修改人員,修改日期"

        strIValue = "'" & 憑單號碼.Text & "','" & strSystemToDate(請款日期.Value.ToShortDateString) & "','" & strSystemToDate(出貨日期起.Value.ToShortDateString) & "','" & strSystemToDate(出貨日期迄.Value.ToShortDateString) & "',"
        strIValue &= "'" & 客戶代號.SelectedValue & "','" & 金額.Text & "','" & 含稅.Text & "','" & 總計.Text & "','" & IIf(CK含稅.Checked = True, "True", "False") & "','" & 重量.Text & "',"
        strIValue &= "'" & 所屬年月.Text & "','" & IIf(收款日期.Checked = True, strSystemToDate(收款日期.Value.ToShortDateString), "") & "','" & 本期應收帳款.Text & "',"
        strIValue &= "'" & 扣款.Text & "','" & 折讓.Text & "','" & 現金.Text & "','" & 票據.Text & "','" & 郵票.Text & "',"
        strIValue &= "'" & 本期扣款.Text & "','" & 扣款備註.Text & "','" & 本期補請.Text & "','" & 補請備註.Text & "','" & 出貨金額.Text & "',"
        strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "','" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        blnCheck = dbInsert(DNS, "應收帳款主檔", strIRow, strIValue)

        If blnCheck = False Then Return False : Exit Function

        FormKey = 憑單號碼.Text
        '應收帳款項目檔
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("貨單序號").Value,
                                           OutDataDGV.Rows(I).Cells("出貨日期").Value,
                                           OutDataDGV.Rows(I).Cells("合計").Value,
                                           OutDataDGV.Rows(I).Cells("總重量").Value}

            If strRowValue(0) <> "" Then
                strIRow = "憑單號碼,貨單序號,出貨日期,合計,總重量"
                strIValue = "'" & 憑單號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "'"
                dbInsert(DNS, "應收帳款項目檔", strIRow, strIValue)
            End If
        Next

        '先刪
        dbDelete(DNS, "應收帳款發票檔", "憑單號碼 = '" & 憑單號碼.Text & "'")
        '後加
        For I As Integer = 0 To InvDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {InvDataDGV.Rows(I).Cells("發票日期").Value,
                                           InvDataDGV.Rows(I).Cells("發票號碼").Value,
                                           InvDataDGV.Rows(I).Cells("銷售金額").Value,
                                           InvDataDGV.Rows(I).Cells("銷售稅額").Value,
                                           InvDataDGV.Rows(I).Cells("銷售總額").Value
                                           }

            If strRowValue(0) <> "" Then
                strIRow = "憑單號碼,發票日期,發票號碼,銷售金額,銷售稅額,銷售總額"
                strIValue = "'" & 憑單號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "'"
                dbInsert(DNS, "應收帳款發票檔", strIRow, strIValue)
            End If
        Next



        '--異動後初始化--        
        MessageBox.Show("※資料已新增" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'FillData("")
        Return blnCheck
    End Function
    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False
        strUValue = ""

        GetCtrlUpdateSql(TabControl, "BCtrl", strUValue)

        '無法SQL的欄位*****
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"
        strWValue = "憑單號碼 = '" & 憑單號碼.Text & "'"

        blnCheck = dbEdit(DNS, "應收帳款主檔", strUValue, strWValue)

        If blnCheck = False Then Return False : Exit Function

        FormKey = 憑單號碼.Text

        '先刪
        dbDelete(DNS, "應收帳款項目檔", "憑單號碼 = '" & 憑單號碼.Text & "'")
        '後加
        '應收帳款項目檔
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {OutDataDGV.Rows(I).Cells("貨單序號").Value,
                                           OutDataDGV.Rows(I).Cells("出貨日期").Value,
                                           OutDataDGV.Rows(I).Cells("合計").Value,
                                           OutDataDGV.Rows(I).Cells("總重量").Value}

            If strRowValue(0) <> "" Then
                strIRow = "憑單號碼,貨單序號,出貨日期,合計,總重量"
                strIValue = "'" & 憑單號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "'"
                dbInsert(DNS, "應收帳款項目檔", strIRow, strIValue)
            End If
        Next

        '先刪
        dbDelete(DNS, "應收帳款發票檔", "憑單號碼 = '" & 憑單號碼.Text & "'")
        '後加
        For I As Integer = 0 To InvDataDGV.RowCount - 1 Step 1
            Dim strRowValue() As String = {InvDataDGV.Rows(I).Cells("發票日期").Value,
                                           InvDataDGV.Rows(I).Cells("發票號碼").Value,
                                           InvDataDGV.Rows(I).Cells("銷售金額").Value,
                                           InvDataDGV.Rows(I).Cells("銷售稅額").Value,
                                           InvDataDGV.Rows(I).Cells("銷售總額").Value
                                           }

            If strRowValue(0) <> "" Then
                strIRow = "憑單號碼,發票日期,發票號碼,銷售金額,銷售稅額,銷售總額"
                strIValue = "'" & 憑單號碼.Text & "','" & strRowValue(0) & "','" & strRowValue(1) & "','" & strRowValue(2) & "','" & strRowValue(3) & "','" & strRowValue(4) & "'"
                dbInsert(DNS, "應收帳款發票檔", strIRow, strIValue)
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

        '--開啟異動--
        blnCheck = dbDelete(DNS, "應收帳款主檔", "憑單號碼 = '" & 憑單號碼.Text & "'")
        blnCheck = dbDelete(DNS, "應收帳款項目檔", "憑單號碼 = '" & 憑單號碼.Text & "'")


        '查詢語法
        'strSSQL = "update 進貨單主檔 set 狀態='9' "
        'strSSQL &= " where 工令號碼 in (select 工令號碼 from 出貨單項目檔 )"
        'blnCheck = dbExecute(DNS, strSSQL)

        'strSSQL = "update 進貨單主檔 set 狀態='5' "
        'strSSQL &= " where 工令號碼 not in (select 工令號碼 from 出貨單項目檔 ) and 過磅狀態='已過磅'"
        'blnCheck = dbExecute(DNS, strSSQL)

        '--異動後初始化--
        MessageBox.Show("※資料已刪除" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        FillData("")
    End Sub

    '新增修改後重載資料
    Public Overrides Sub AfterEndEdit()
        ShowData(FormKey)
    End Sub
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Weigh(strKey1) '
        WeighItem(strKey1) '
        InvItem(strKey1) '
    End Sub
    '應收帳款主檔主檔
    Sub Weigh(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 應收帳款主檔"
        strSQL99 &= " WHERE 憑單號碼 = '" & strKey1 & "'"

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

            If objDR99("收款日期").ToString = "" Then
                收款日期.Checked = False
            Else
                收款日期.Checked = True
            End If
            lb所屬年月.Text = "所屬年月:" + objDR99("所屬年月").ToString
        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '應收帳款項目檔
    Sub WeighItem(ByVal strKey1 As String)

        Dim blnCheck As Boolean = False '是否有查詢到資料


        '查詢語法
        strSSQL = "SELECT * from 應收帳款項目檔"
        strSSQL &= " WHERE 憑單號碼 = '" & strKey1 & "'"
        strSSQL &= " ORDER BY 貨單序號"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)

    End Sub

    Sub InvItem(ByVal strKey1 As String)

        Dim blnCheck As Boolean = False '是否有查詢到資料


        '查詢語法
        strSSQL = "SELECT * from 應收帳款發票檔"
        strSSQL &= " WHERE 憑單號碼 = '" & strKey1 & "'"

        '顯示欄位
        blnCheck = DataGridView_HeaderDB(InvDataDGV, DNS, strSSQL)

    End Sub

    Private Sub btnOutData_Click(sender As System.Object, e As System.EventArgs) Handles btnOutData.Click
        If 客戶代號.SelectedIndex <> 0 Then
            Dim blnCheck As Boolean = False '是否有查詢到資料
            Dim str As String = ""
            If 客戶代號.SelectedValue <> "" Then
                str &= " and a.客戶代號 ='" + 客戶代號.SelectedValue + "'"
            End If
            str &= " and a.出貨日期 >='" + strSystemToDate(出貨日期起.Value.ToShortDateString) + "'"
            str &= " and a.出貨日期 <='" + strSystemToDate(出貨日期迄.Value.ToShortDateString) + "'"


            strSSQL = "select a.貨單序號,a.出貨日期,SUM(b.小計) as 合計,sum(b.重量) as 總重量 "
            strSSQL &= " from 出貨單主檔 a inner join 出貨單項目檔 b on a.貨單序號=b.貨單序號"
            strSSQL &= " inner join 進貨單主檔 c on c.工令號碼=b.工令號碼"
            strSSQL &= " WHERE 1=1 and isnull(a.司機代號,'')<>'' and a.貨單序號 not in (select 貨單序號 from  應收帳款項目檔) "
            strSSQL &= str
            strSSQL &= " group by a.貨單序號,a.出貨日期 ORDER BY a.貨單序號"

            blnCheck = DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)


            If 客戶代號.SelectedValue <> "" Then
                str = " and a.客戶代號 ='" + 客戶代號.SelectedValue + "'"
            End If
            str &= " and a.應收帳款扣款日期 >='" + strSystemToDate(出貨日期起.Value.ToShortDateString) + "'"
            str &= " and a.應收帳款扣款日期 <='" + strSystemToDate(出貨日期迄.Value.ToShortDateString) + "'"

            strSSQL = "select * "
            strSSQL &= " from 出貨退回主檔 a"
            strSSQL &= " WHERE 1=1 and 退回金額 >0"
            strSSQL &= str


            blnCheck = DataGridView_HeaderDB(RetDataDGV, DNS, strSSQL)

            SumOutDataDGV()
        End If
    End Sub
#End Region

#Region "物件異動選擇項"

    '依日期變換 憑單號碼
    Private Sub 請款日期_ValueChanged(sender As System.Object, e As System.EventArgs) Handles 請款日期.ValueChanged
        If MyTableStatus = 1 Then
            strPage = Mid(CStr(請款日期.Value.Year - 1911), 2, 2) + 請款日期.Value.Month.ToString.PadLeft(2, "0") + "-"
            '憑單號碼.Text = ERP_AutoNo_憑單號碼(DNS, strPage, "應收帳款主檔", "憑單號碼")
        End If
    End Sub

    Private Sub 客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles 客戶代號.SelectedIndexChanged
        If 客戶代號.SelectedIndex <> 0 Then
            客戶代碼.Text = 客戶代號.SelectedValue
        End If
        If 客戶代號.SelectedIndex <> 0 And MyTableStatus <> 0 Then
            Dim paydate As String = dbGetSingleRow(DNS, "客戶帳款檔", "結帳日", "客戶代號 = '" & 客戶代碼.Text & "'", "")
            Dim NowPayDate As Date
            Dim NowPayDate1 As Date

            Dim Nowday As String = Now.Day.ToString()

            LB結帳日.Text = paydate
            Dim pay1 As String = ""
            Dim pay2 As String
            If paydate = "25" Then
                If DateTime.Today.Day() < 25 Then
                    NowPayDate = DateAdd(DateInterval.Month, -2, Now)
                    NowPayDate1 = DateAdd(DateInterval.Month, -1, Now)
                Else
                    NowPayDate = DateAdd(DateInterval.Month, -1, Now)
                    NowPayDate1 = Now
                End If
                pay1 = NowPayDate.Year.ToString() + "-" + NowPayDate.Month.ToString() + "-26"
                pay2 = NowPayDate1.Year.ToString() + "-" + NowPayDate1.Month.ToString() + "-25"
            Else
                If Nowday >= 25 Then
                    NowPayDate = Now
                    pay1 = NowPayDate.Year.ToString() + "-" + NowPayDate.Month.ToString() + "-01"
                    pay2 = NowPayDate.Year.ToString() + "-" + NowPayDate.Month.ToString() + "-" + DateTime.DaysInMonth(NowPayDate.Year, NowPayDate.Month).ToString()

                Else
                    NowPayDate = DateAdd(DateInterval.Month, -1, Now)
                    pay1 = NowPayDate.Year.ToString() + "-" + NowPayDate.Month.ToString() + "-01"
                    pay2 = NowPayDate.Year.ToString() + "-" + NowPayDate.Month.ToString() + "-" + DateTime.DaysInMonth(NowPayDate.Year, NowPayDate.Month).ToString()

                End If
            End If
            出貨日期起.Value = IIf(IsDate(pay1) = False, Now, pay1)
            出貨日期迄.Value = IIf(IsDate(pay2) = False, Now, pay2)
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

    Private Sub CK含稅_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CK含稅.CheckedChanged, 本期補請.TextChanged, 本期扣款.TextChanged
        If MyTableStatus <> 0 Then
            SumOutDataDGV()
        End If
    End Sub

    Private Sub TabPage3_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage3.Enter
        btnPreviewRep_Click(sender, e)
    End Sub
#End Region

#Region "報表"

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir
        PreviewControl1.ZoomWholePage()
        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "應收帳款憑單.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", 憑單號碼.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        FRreport.Design()
    End Sub
#End Region

    Sub SumOutDataDGV()

        Dim t筆數 As Integer = 0
        Dim t金額 As Integer = 0
        Dim t含稅 As Integer = 0
        Dim t重量 As Integer = 0

        Dim t退回筆數 As Integer = 0
        Dim t退回金額 As Integer = 0

        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            t筆數 = t筆數 + 1
            If IsNumeric(OutDataDGV.Rows(I).Cells("合計").Value) Then
                t金額 = t金額 + CInt(OutDataDGV.Rows(I).Cells("合計").Value)
            End If

            If IsNumeric(OutDataDGV.Rows(I).Cells("總重量").Value) Then
                t重量 = t重量 + CInt(OutDataDGV.Rows(I).Cells("總重量").Value)
            End If
        Next

        '退回處理
        For I As Integer = 0 To RetDataDGV.RowCount - 1 Step 1
            t退回筆數 = t退回筆數 + 1
            If IsNumeric(RetDataDGV.Rows(I).Cells("退回金額1").Value) Then
                t退回金額 = t退回金額 + CInt(RetDataDGV.Rows(I).Cells("退回金額1").Value)
            End If

        Next
        Lab退回金額.Text = "退回金額:" + t退回金額.ToString

        出貨金額.Text = t金額.ToString()
        金額.Text = t金額 - Val(本期扣款.Text) + Val(本期補請.Text)

        t含稅 = System.Math.Round((t金額 - Val(本期扣款.Text) + Val(本期補請.Text)) * 0.05, 0, MidpointRounding.AwayFromZero)

        重量.Text = t重量.ToString()
        '金額.Text = t金額.ToString("#,##0")

        If CK含稅.Checked Then
            含稅.Text = t含稅
            總計.Text = t金額 - Val(本期扣款.Text) + Val(本期補請.Text) + t含稅
        Else
            含稅.Text = 0
            總計.Text = t金額 - Val(本期扣款.Text) + Val(本期補請.Text)
        End If



    End Sub



    Private Sub 所屬年月_TextChanged(sender As System.Object, e As System.EventArgs) Handles 所屬年月.TextChanged
        strPage = 所屬年月.Text + "-"
    End Sub

    Private Sub 總計_TextChanged(sender As System.Object, e As System.EventArgs) Handles 總計.TextChanged
        If MyTableStatus <> 0 Then
            本期應收帳款.Text = 總計.Text
        End If

    End Sub

    Private Sub BtnSerach_Click(sender As System.Object, e As System.EventArgs) Handles BtnSerach.Click
        Dim str As String
        str = " "
        If s客戶代號.SelectedValue <> "" Then
            str &= " and m.客戶代號 ='" + s客戶代號.SelectedValue + "'"
        End If
        FillData(str)
    End Sub

    Private Sub S06N0100_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        If FIRM <> "總公司" Then
            MsgBox("必需在總公司，才能運作此程式")
            Me.Close()
        End If
    End Sub



    Private Sub Tab2_btnAdd_Click(sender As Object, e As EventArgs) Handles Tab2_btnAdd.Click
        If 客戶代碼.Text <> "" Then
            InvDataDGV.Rows.Add(New Object() {strSystemToDate(請款日期.Value.ToShortDateString), "", 金額.Text, 含稅.Text, 總計.Text})
        Else
            MsgBox("請輸入客戶代號")
            客戶代碼.Focus()
        End If
    End Sub

    Private Sub Tab2_btnDec_Click(sender As Object, e As EventArgs) Handles Tab2_btnDec.Click
        For Each r As DataGridViewRow In InvDataDGV.SelectedRows
            If Not r.IsNewRow Then
                InvDataDGV.Rows.Remove(r)
            End If
        Next
    End Sub


    Private Sub 票面金額1_TextChanged(sender As Object, e As EventArgs) Handles 票面金額5.TextChanged, 票面金額4.TextChanged, 票面金額3.TextChanged, 票面金額2.TextChanged, 票面金額1.TextChanged
        票據.Text = Val(票面金額1.Text) + Val(票面金額2.Text) + Val(票面金額3.Text) + Val(票面金額4.Text) + Val(票面金額5.Text)
    End Sub

    Private Sub 現金_TextChanged(sender As Object, e As EventArgs) Handles 郵票.TextChanged, 票據.TextChanged, 現金.TextChanged, 折讓2.TextChanged, 折讓1.TextChanged, 折讓.TextChanged, 扣款2.TextChanged, 扣款1.TextChanged, 扣款.TextChanged, 其他收入.TextChanged
        銷帳總額.Text = Val(現金.Text) + Val(郵票.Text) + Val(其他收入.Text) + Val(票據.Text) + Val(折讓.Text) + Val(折讓1.Text) + Val(折讓2.Text) + Val(扣款.Text) + Val(扣款1.Text) + Val(扣款2.Text)
    End Sub

    Private Sub 本期應收帳款_TextChanged(sender As Object, e As EventArgs) Handles 銷帳總額.TextChanged, 本期應收帳款.TextChanged
        差額.Text = Val(本期應收帳款.Text) - Val(銷帳總額.Text)
    End Sub
End Class
