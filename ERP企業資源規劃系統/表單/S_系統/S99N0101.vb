Public Class S99N0101
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
    Private Sub S99N0101_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****        
        '寬
        MainPanel.Width = WorkingArea_Width()
        SplitContainer.Width = WorkingArea_Width()

        '按鍵
        Dim btnItems() As ToolStripButton = {butAddNew, butCopy, butDelete, butPrint}
        For I As Integer = 0 To btnItems.Length - 1 Step 1 : btnItems(I).Visible = False : Next

        '頁面
        Me.Text = dbGetSingleRow(DNS, "系統模組功能檔", "功能名稱", "功能代碼 = '" & Me.Name.ToString & "'")
        ComboBoxList() 'Combobox初始化
        DataGridView_Basic() 'DataGridView初始化
        FillData("") '載入資料集        
    End Sub
    Private Sub S99N0101_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        MySystemControl() '清除背景全域物件
    End Sub

    '尋找
    Public Overrides Sub FindWindows()
        Dim S_S99N0101 As New S_S99N0101

        '開啟視窗
        S_S99N0101.MdiParent = fmMain
        S_S99N0101.Show()
    End Sub
#End Region

#Region "DataGridView及ComboBox"
    'ComboBox初始化
    Sub ComboBoxList()

    End Sub

    'DataGridView初始化
    Sub DataGridView_Basic()
        '欄位名稱
        Dim arrColName() As String = {"員工代號", "廠別", "部門", "僱用性質", "姓名", "最後登入時間", "允許登入"}
        Dim arrColWidth() As String = {"100", "100", "100", "120", "160", "180", "100"}

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
    Private Sub DataGridViewR_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DataGridViewR.Paint
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
        strSSQL = "SELECT * from 員工主檔"
        strSSQL &= " WHERE 1=1"
        strSSQL &= strSearch
        strSSQL &= " ORDER BY 員工代號"

        '顯示欄位
        arrRowName = {"員工代號", "廠別", "部門", "僱用性質", "姓名", "最後登入時間", "允許登入"}

        '開啟產生DataGridView
        blnCheck = DataGridView_DB(DataGridView, DNS, strSSQL, arrRowName, txtCount)

        '異動後初始化*****
        SetControls(0)
        FlagMoveSeat(0)
        If blnCheck = False Then MessageBox.Show("系統目前查無資料。", "查詢結果", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    '輸入控制項的 ReadOnly 屬性及 Enabled 屬性
    Public Overrides Sub SetControls(ByVal butStatus As Integer)
        Dim objDataGridViewR() As DataGridView = {DataGridViewR}

        Dim objTextBoxM() As TextBox = {M_TextBox1, M_TextBox2}
        Dim objComboBoxM() As ComboBox = {}
        Dim objRadioButtonM() As RadioButton = {}
        Dim objDateTimePickerM() As DateTimePicker = {}

        DataGridViewR_Control(objDataGridViewR, butStatus)
        Main_Control(objTextBoxM, objComboBoxM, objRadioButtonM, objDateTimePickerM, butStatus)

        '0:一般模式 1:新增模式 2:修改模式 3:複製模式
        Select Case butStatus
            Case 0 '一般模式
                TabControl.SelectedTab = Me.TabPage1
                DataGridView.Enabled = True

            Case 2 '修改模式
                TabControl.SelectedTab = Me.TabPage2
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
                DataGridView.CurrentCell = DataGridView.Item(0, intRow)
                Dim strKey As String = DataGridView.CurrentCell.Value

                '停在選定之儲存格
                ShowData(strKey)
                txtSeat.Text = intRow + 1 '目前位置
                DataGridView.CurrentCell = DataGridView.Item(intCol, intRow) '選取位置
            Catch ex As Exception

            End Try
        End If
    End Sub

    '修改
    Public Overrides Function UpdateData() As Boolean
        Dim blnCheck As Boolean = False

        '開啟儲存*****
        '客戶主檔
        strUValue = "密碼 = '" & M_TextBox3.Text & "',"
        strUValue &= "修改人員 = '" & INI_Read("BASIC", "LOGIN", "UNAME") & "',"
        strUValue &= "修改日期 = '" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

        strWValue = "員工代號 = '" & M_TextBox1.Text & "'"

        blnCheck = dbEdit(DNS, "員工主檔", strUValue, strWValue)

        '開啟儲存
        '先刪
        dbDelete(DNS, "員工權限檔", "員工代號 = '" & M_TextBox1.Text & "'")

        '後加
        For I As Integer = 0 To DataGridViewR.RowCount - 1 Step 1
            '寫入鉤選值
            If CType(DataGridViewR.Item(0, I), DataGridViewCheckBoxCell).Value = True Then
                DataGridViewR.CurrentCell = DataGridViewR.Item(1, I) '功能代碼
                Dim strSystemID As String = DataGridViewR.CurrentCell.Value

                DataGridViewR.CurrentCell = DataGridViewR.Item(4, I) '新增
                Dim blnInsert As Boolean = DataGridViewR.CurrentCell.Value

                DataGridViewR.CurrentCell = DataGridViewR.Item(5, I) '修改
                Dim blnEdit As Boolean = DataGridViewR.CurrentCell.Value

                DataGridViewR.CurrentCell = DataGridViewR.Item(6, I) '刪除
                Dim blnDelete As Boolean = DataGridViewR.CurrentCell.Value

                DataGridViewR.CurrentCell = DataGridViewR.Item(7, I) '列印
                Dim blnPrint As Boolean = DataGridViewR.CurrentCell.Value


                '開啟儲存
                strIRow = "員工代號,子功能代碼,"
                strIRow &= "新增權限,異動權限,刪除權限,列印權限,"
                strIRow &= "修改人員,修改日期"

                strIValue = "'" & M_TextBox1.Text & "','" & strSystemID & "',"
                strIValue &= "'" & IIf(blnInsert = True, "Y", "N") & "','" & IIf(blnEdit = True, "Y", "N") & "','" & IIf(blnDelete = True, "Y", "N") & "','" & IIf(blnPrint = True, "Y", "N") & "',"
                strIValue &= "'" & INI_Read("BASIC", "LOGIN", "UNAME") & "','" & INI_Read("BASIC", "LOGIN", "DATE") & "'"

                blnCheck = dbInsert(DNS, "員工權限檔", strIRow, strIValue)
            End If
        Next


        '--異動後初始化--        
        MessageBox.Show("※資料已修改" & IIf(blnCheck = True, "成功", "失敗") & "！", "系統訊息", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Try : DataGridViewR.CurrentCell = DataGridViewR.Item(0, 0) : Catch ex As Exception : End Try '將值放回(0,0)儲存格

        Return blnCheck
    End Function
#End Region

#Region "資料查詢"
    '資料查詢
    Public Sub ShowData(ByVal strKey1 As String)
        Users(strKey1) '員工主檔
        ' UsersPower(strKey1) '員工權限檔
    End Sub
    '員工主檔
    Sub Users(ByVal strKey1 As String)
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT * FROM 員工主檔"
        strSQL99 &= " WHERE 員工代號 = '" & strKey1 & "'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.Read Then
            M_TextBox1.Text = objDR99("員工代號").ToString
            M_TextBox2.Text = objDR99("姓名").ToString
            M_TextBox3.Text = objDR99("密碼").ToString

        End If

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標
    End Sub
    '員工權限檔
    Sub UsersPower(ByVal strKey1 As String)
        DataGridViewR.Rows.Clear() '清除DataGridView儲存格

        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT *,"
        strSQL99 &= " (SELECT 模組名稱 FROM 系統模組檔 WHERE 系統模組功能檔.模組代碼 = 系統模組檔.模組代碼) AS 模組別"
        strSQL99 &= " FROM 系統模組功能檔"
        strSQL99 &= " WHERE 1=1"
        strSQL99 &= " ORDER BY 功能代碼 ASC"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        Do While objDR99.Read
            '--計算DataGridView的欄位數--
            I = DataGridViewR.RowCount
            DataGridViewR.RowCount = I + 1

            '--#顯示欄位值------
            Dim blnCheck As Boolean = False : Dim strValue As String = ""
            Dim arrRowName() As String = {"查詢", "功能代碼", "模組別", "功能名稱", "新增權限", "異動權限", "刪除權限", "列印權限"}

            For J As Integer = 0 To arrRowName.Length - 1 Step 1
                Select Case arrRowName(J).ToString
                    Case "查詢"
                        blnCheck = ADOODBC.dbDataCheck(DNS, "員工權限檔", "員工代號 = '" & strKey1 & "' AND 子功能代碼 = '" & objDR99("功能代碼").ToString & "'")
                        With CType(DataGridViewR.Item(J, I), DataGridViewCheckBoxCell)
                            .Value = blnCheck
                        End With

                    Case "新增權限", "異動權限", "刪除權限", "列印權限"
                        strValue = ADOODBC.dbGetSingleRow(DNS, "員工權限檔", arrRowName(J).ToString, "員工代號 = '" & strKey1 & "' AND 子功能代碼 = '" & objDR99("功能代碼").ToString & "'")
                        With CType(DataGridViewR.Item(J, I), DataGridViewCheckBoxCell)
                            .Style.BackColor = IIf(objDR99(arrRowName(J).ToString).ToString = "Y", Color.White, Color.Black)
                            .ReadOnly = IIf(strValue = "Y", False, True)
                            .Value = IIf(strValue = "Y", True, False)
                        End With

                    Case Else
                        With CType(DataGridViewR.Item(J, I), DataGridViewTextBoxCell)
                            .Value = objDR99(arrRowName(J)).ToString
                        End With
                End Select
            Next
            '--#End 顯示欄位值--
        Loop

        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標


        '異動後初始化*****
        Try : DataGridViewR.CurrentCell = DataGridViewR.Item(0, 0) : Catch ex As Exception : End Try '將值放回(0,0)儲存格
    End Sub
#End Region

    Private Sub btnSelectALL_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectALL.Click
        Dim g As Integer
        For g = Me.DataGridViewR.Rows.Count - 1 To 0 Step -1
            Me.DataGridViewR.Rows(g).Cells(0).Value = True
            Me.DataGridViewR.Rows(g).Cells(4).Value = True
            Me.DataGridViewR.Rows(g).Cells(5).Value = True
            Me.DataGridViewR.Rows(g).Cells(6).Value = True
            Me.DataGridViewR.Rows(g).Cells(7).Value = True
        Next
    End Sub

    Private Sub btnDelALL_Click(sender As System.Object, e As System.EventArgs) Handles btnDelALL.Click
        Dim g As Integer
        For g = Me.DataGridViewR.Rows.Count - 1 To 0 Step -1
            Me.DataGridViewR.Rows(g).Cells(0).Value = False
            Me.DataGridViewR.Rows(g).Cells(4).Value = False
            Me.DataGridViewR.Rows(g).Cells(5).Value = False
            Me.DataGridViewR.Rows(g).Cells(6).Value = False
            Me.DataGridViewR.Rows(g).Cells(7).Value = False
        Next
    End Sub

    Private Sub btnAddFun_Click(sender As System.Object, e As System.EventArgs) Handles btnAddFun.Click
        Dim mnuItem As ToolStripMenuItem
        Dim submnuItem As ToolStripMenuItem
        Dim refMenuItem As New ToolStripMenuItem()

        For Each ctrl As ToolStripMenuItem In fmMain.MenuStrip.Items
            Dim blnCheck As Boolean = False
            'ctrl.Visible = True
            For Each subItem As Object In ctrl.DropDownItems
                If TypeOf subItem Is ToolStripMenuItem Then
                    mnuItem = DirectCast(subItem, ToolStripMenuItem)
                    If dbDataCheck(DNS, "系統模組功能檔", "功能代碼 = '" & mnuItem.Name & "'") = False Then
                        MsgBox(ctrl.Name + "-" + mnuItem.Text + "-" + mnuItem.Name)
                        '開啟儲存
                        strIRow = "功能代碼,模組代碼,功能名稱,"
                        strIRow &= "新增權限,異動權限,刪除權限,列印權限"

                        strIValue = "'" & mnuItem.Name & "','" & ctrl.Name & "','" & mnuItem.Text & "',"
                        strIValue &= "'" & "Y" & "','" & "Y" & "','" & "Y" & "','" & "Y" & "'"
                        blnCheck = dbInsert(DNS, "系統模組功能檔", strIRow, strIValue)
                    End If
                    For Each subItem1 As Object In mnuItem.DropDownItems
                        If TypeOf subItem1 Is ToolStripMenuItem Then
                            submnuItem = DirectCast(subItem1, ToolStripMenuItem)
                            If dbDataCheck(DNS, "系統模組功能檔", "功能代碼 = '" & submnuItem.Name & "'") = False Then
                                MsgBox(ctrl.Name + "-" + submnuItem.Text + "-" + submnuItem.Name)
                                strIRow = "功能代碼,模組代碼,功能名稱,"
                                strIRow &= "新增權限,異動權限,刪除權限,列印權限"

                                strIValue = "'" & submnuItem.Name & "','" & ctrl.Name & "','" & submnuItem.Text & "',"
                                strIValue &= "'" & "Y" & "','" & "Y" & "','" & "Y" & "','" & "Y" & "'"
                                blnCheck = dbInsert(DNS, "系統模組功能檔", strIRow, strIValue)
                            End If
                        End If
                    Next
                End If

            Next
        Next
    End Sub

    Private Sub TabPage2_Enter(sender As System.Object, e As System.EventArgs) Handles TabPage2.Enter
        UsersPower(M_TextBox1.Text) '員工權限檔
    End Sub

    Private Sub BtnCopyUser_Click(sender As System.Object, e As System.EventArgs) Handles BtnCopyUser.Click
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "delete from 員工權限檔"
        strSQL99 &= " WHERE 員工代號='" & M_TextBox1.Text & "'"


        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objCmd99.ExecuteNonQuery()

        strSQL99 = "insert into 員工權限檔(員工代號,子功能代碼,新增權限,異動權限,刪除權限,列印權限,修改人員,修改日期)"
        strSQL99 &= " select '" & M_TextBox1.Text & "',子功能代碼,新增權限,異動權限,刪除權限,列印權限,修改人員,修改日期 from 員工權限檔 where 員工代號='" & CopyUser.Text & "'"


        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objCmd99.ExecuteNonQuery()


        objDR99.Close()    '關閉連結
        objCon99.Close()
        objCmd99.Dispose() '手動釋放資源
        objCon99.Dispose()
        objCon99 = Nothing '移除指標

        UsersPower(M_TextBox1.Text) '員工權限檔
    End Sub
End Class
