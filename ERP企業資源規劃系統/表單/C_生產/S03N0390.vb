Imports FastReport
Imports FastReport.Utils

Public Class S03N0390
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
    Dim TotalTime As Integer
    Dim strMessage As String = "" '訊息字串
    Dim strIRow, strIValue, strUValue, strWValue As String '資料處理參數(新增欄位；新增資料；異動資料；條件)      
#End Region
#Region "單用變數"
    Dim strPage As String = "FA" & Mid(Now.Year, 3, 2)
    Public NoShowPrice As Boolean = False
    Dim FRreport As New Report
#End Region

#Region "@Form及功能操作@"
    Private Sub S03N0390_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '物件初始化*****        
        TabControl1.SelectedTab = Me.TabPage1

        '按鍵
        Dim btnItems() As ToolStripButton = {butAddNew, butCopy, butDelete, butFind, butSearch, butPrint, butSave, butCancelEdit}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next
        BCtrl.Visible = False
        BasicPanel.Visible = False

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        PageCount.Visible = False
        CK司機代號.Checked = True
        If NoShowPrice Then
            單價.HeaderText = "單價X"
            單價.ReadOnly = True
            小計.HeaderText = "小計X"
            小計.ReadOnly = True
            Me.Text = "出貨統計表"
            CK司機代號.Checked = False

            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
        End If

        sender.WindowState = FormWindowState.Maximized
        'DataGridView_Basic() 'DataGridView初始化
        'FillData("") '載入資料集
    End Sub
    Private Sub S03N0390_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub
    Private Sub S03N0390_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then SendKeys.Send("{tab}")
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
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()
        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
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
        Dim blnCheck As Boolean = False '是否有查詢到資料
        'Dim arrRowName() As String

        '查詢語法
        'strSSQL = "SELECT  d.桶數 as 磅後桶數,d.單位,d.重量 as 磅後總重,d.備註"
        'strSSQL &= ",'false' as 選,m.客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        'strSSQL &= ",t5.一層名稱 AS 狀態,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        'strSSQL &= ",t11.簡稱 as 次加工廠商,t12.簡稱 as 二次廠商,單位代號1 AS 單位,t1.簡稱 as 客戶"
        'strSSQL &= ",產品名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,t4.一層名稱 AS 材質,t6.一層名稱 AS 表面"
        'strSSQL &= ",o.出貨日期,t13.姓名 AS 司機姓名,t14.憑單號碼 as 憑單號碼,m.*"
        'strSSQL &= ",* FROM 進貨單主檔 AS m inner JOIN 出貨單項目檔 as d on m.工令號碼=d.工令號碼 inner join 出貨單主檔 o on o.貨單序號=d.貨單序號 "
        'strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        ''strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        'strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        ''strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0006') AS t9 ON m.加工方式代碼 = t9.一層代碼 "
        'strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0009') AS t10 ON m.電鍍別代碼 = t10.一層代碼 "
        'strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON m.次加工廠代號1 = t11.加工廠代號"
        'strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON m.次加工廠代號2 = t12.加工廠代號"
        'strSSQL &= " LEFT JOIN 司機主檔 AS t13 ON o.司機代號 = t13.司機代號"
        'strSSQL &= " LEFT JOIN 應收帳款項目檔 AS t14 ON o.貨單序號 = t14.貨單序號"
        'strSSQL &= " WHERE 1=1 "
        'strSSQL &= strSearch
        'strSSQL &= " ORDER BY o.出貨日期,d.貨單序號,d.序號"

        strSSQL = "SELECT  d.桶數 as 磅後桶數,d.單位,d.重量 as 磅後總重,d.備註,d.序號"
        strSSQL &= ",'false' as 選,m.客戶批號 as 客戶工令,加工方式代碼 as 加工方式,電鍍別代碼 as 電鍍別,淨重 AS 重量"
        strSSQL &= ",t5.一層名稱 AS 狀態,預排爐號 as 爐號,數量1+數量2+數量3+數量4 as 桶數, 回火爐2 as 回温"
        strSSQL &= ",t11.簡稱 as 次加工廠商,t12.簡稱 as 二次廠商,單位代號1 AS 單位,t1.簡稱 as 客戶"
        strSSQL &= ",產品名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面"
        strSSQL &= ",o.出貨日期,t13.姓名 AS 司機姓名,t14.憑單號碼 as 憑單號碼,d.*,m.*"
        strSSQL &= " FROM 出貨單項目檔 AS d inner join 出貨單主檔 o on o.貨單序號=d.貨單序號 "
        strSSQL &= " left JOIN 進貨單主檔  as m on m.工令號碼=d.工令號碼  "
        strSSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號 "
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼 "
        strSSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t11 ON d.加工廠代號 = t11.加工廠代號"
        strSSQL &= " LEFT JOIN 加工廠主檔 AS t12 ON d.二次加工廠代號 = t12.加工廠代號 "
        strSSQL &= " LEFT JOIN 司機主檔 AS t13 ON o.司機代號 = t13.司機代號"
        strSSQL &= " LEFT JOIN 應收帳款項目檔 AS t14 ON o.貨單序號 = t14.貨單序號"
        strSSQL &= " WHERE 1=1 "
        strSSQL &= strSearch
        strSSQL &= " ORDER BY o.出貨日期,d.貨單序號,d.排序"


        '顯示欄位
        blnCheck = DataGridView_HeaderDB(OutDataDGV, DNS, strSSQL)

        '異動後初始化*****
        'SetControls(0)
        'FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Set_Control_RW(TabControl1, butStatus)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式


            Case 1 '新增模式


            Case 2 '修改模式


            Case 3 '複製模式

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

#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)

    End Sub

#End Region
#Region "物件異動選擇項"
    Private Sub s客戶代號_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles s客戶代號.SelectedIndexChanged
        If s客戶代號.SelectedIndex <> 0 Then
            s客戶代碼.Text = s客戶代號.SelectedValue
            Dim paydate As String = dbGetSingleRow(DNS, "客戶帳款檔", "結帳日", "客戶代號 = '" & s客戶代號.SelectedValue & "'", "")
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

    Private Sub s客戶代碼_Leave(sender As System.Object, e As System.EventArgs) Handles s客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代碼.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代碼.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub
#End Region

    '按下確認 查詢資料
    Private Sub btnSerach_Click(sender As System.Object, e As System.EventArgs) Handles btnSerach.Click
        Dim str As String = ""
        If s客戶代號.SelectedIndex <> 0 Then

            If s客戶代號.SelectedValue <> "" Then
                str &= " and o.客戶代號 ='" + s客戶代號.SelectedValue + "'"
            End If
        End If

        str &= " and o.出貨日期 >='" + strSystemToDate(出貨日期起.Value.ToShortDateString) + "'"
        str &= " and o.出貨日期 <='" + strSystemToDate(出貨日期迄.Value.ToShortDateString) + "'"

        If CK貨單序號.Checked Then
            str &= " and d.貨單序號 not in (select 貨單序號 from  應收帳款項目檔)"
        End If

        If CK司機代號.Checked Then
            str &= " and isnull(o.司機代號,'')<>'' "
        End If

        FillData(str)
        SumOutDataDGV()

    End Sub

    Private Sub OutDataDGV_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles OutDataDGV.CellEndEdit
        Dim view As DataGridView = CType(sender, DataGridView)

        Try
            Dim value As String = ""
            Dim value1 As String = ""
            Dim data As Single = 0
            Select Case e.ColumnIndex
                Case 9
                    If OutDataDGV.Rows(e.RowIndex).Cells("憑單號碼").Value = "" Then
                        value = view.CurrentCell.Value
                        value1 = value * OutDataDGV.Rows(e.RowIndex).Cells("磅後總重").Value
                        'OutDataDGV.Rows(e.RowIndex).Cells("小計").Value = Math.Round((value * OutDataDGV.Rows(e.RowIndex).Cells("磅後總重").Value), 0, MidpointRounding.AwayFromZero)
                        OutDataDGV.Rows(e.RowIndex).Cells("小計").Value = CInt(Fix(value1 + 0.5))


                        strUValue = "單價 = '" & value & "'"
                        strUValue &= ",小計 = '" & OutDataDGV.Rows(e.RowIndex).Cells("小計").Value & "'"
                        strWValue = "工令號碼 = '" & OutDataDGV.Rows(e.RowIndex).Cells("工令號碼").Value.ToString() & "' and 貨單序號='" & OutDataDGV.Rows(e.RowIndex).Cells("貨單序號").Value.ToString() & "' and 序號='" & OutDataDGV.Rows(e.RowIndex).Cells("序號").Value.ToString() & "'"
                        dbEdit(DNS, "出貨單項目檔", strUValue, strWValue)
                    Else
                        MsgBox("已列應數帳款" + OutDataDGV.Rows(e.RowIndex).Cells("憑單號碼").Value + "，不可修改單價")

                    End If


            End Select
            SumOutDataDGV()
        Catch ex As Exception

        End Try
    End Sub

    Sub SumOutDataDGV()

        Dim 筆數 As Integer = 0
        Dim 重量 As Integer = 0
        Dim 金額 As Integer = 0
        Dim 含稅 As Integer = 0

        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            筆數 = 筆數 + 1
            重量 = 重量 + IIf(IsNumeric(OutDataDGV.Rows(I).Cells("磅後總重").Value) = False, 0, CInt(OutDataDGV.Rows(I).Cells("磅後總重").Value))
            If IsNumeric(OutDataDGV.Rows(I).Cells("小計").Value) Then
                金額 = 金額 + CInt(OutDataDGV.Rows(I).Cells("小計").Value)
            End If
            含稅 = System.Math.Round(金額 * 0.05, 0, MidpointRounding.AwayFromZero)
        Next

        t筆數.Text = 筆數.ToString("#,##0")
        t重量.Text = 重量.ToString("#,##0")
        t金額.Text = 金額.ToString("#,##0")

        If CK含稅.Checked Then
            t含稅.Text = 含稅
            t總金額.Text = 金額 + 含稅
        Else
            t含稅.Text = 0
            t總金額.Text = 金額
        End If

    End Sub

    Private Sub CK含稅_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CK含稅.CheckedChanged
        SumOutDataDGV()
    End Sub

    Private Sub btnWritePrice_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnPreviewRep_Click(sender As Object, e As EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + "單價_出貨統計表.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", s客戶代號.SelectedValue)
        FRreport.SetParameterValue("RepKey1", strSystemToDate(出貨日期起.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey2", strSystemToDate(出貨日期迄.Value.ToShortDateString))
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As Object, e As EventArgs) Handles btnDesignRep.Click
        FRreport.Design()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl2
        FRreport.Load(thisFolder + "單價_發票明細.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", s客戶代號.SelectedValue)
        FRreport.SetParameterValue("RepKey1", strSystemToDate(出貨日期起.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey2", strSystemToDate(出貨日期迄.Value.ToShortDateString))
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FRreport.Design()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedIndex = 2 Then
            btnPreviewRep.PerformClick()
        ElseIf TabControl1.SelectedIndex = 3 Then
            Button1.PerformClick()
        End If
    End Sub

    Private Sub btnAutoPrice_Click(sender As Object, e As EventArgs) Handles btnAutoPrice.Click
        Dim value As String = ""
        Dim value1 As String = ""
        For I As Integer = 0 To OutDataDGV.RowCount - 1 Step 1
            If OutDataDGV.Rows(I).Cells("憑單號碼").Value = "" Then
                If IsNumeric(OutDataDGV.Rows(I).Cells("報價單價").Value) Then
                    value = OutDataDGV.Rows(I).Cells("報價單價").Value
                    value1 = value * OutDataDGV.Rows(I).Cells("磅後總重").Value
                    'OutDataDGV.Rows(e.RowIndex).Cells("小計").Value = Math.Round((value * OutDataDGV.Rows(e.RowIndex).Cells("磅後總重").Value), 0, MidpointRounding.AwayFromZero)
                    OutDataDGV.Rows(I).Cells("小計").Value = CInt(Fix(value1 + 0.5))


                    strUValue = "單價 = '" & OutDataDGV.Rows(I).Cells("報價單價").Value & "'"
                    strUValue &= ",小計 = '" & OutDataDGV.Rows(I).Cells("小計").Value & "'"
                    strWValue = "工令號碼 = '" & OutDataDGV.Rows(I).Cells("工令號碼").Value.ToString() & "' and 貨單序號='" & OutDataDGV.Rows(I).Cells("貨單序號").Value.ToString() & "' and 序號='" & OutDataDGV.Rows(I).Cells("序號").Value.ToString() & "'"
                    dbEdit(DNS, "出貨單項目檔", strUValue, strWValue)
                End If
            End If
        Next

        btnSerach.PerformClick()

        MsgBox("自動填入完成")
    End Sub
End Class
