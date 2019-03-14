Public Class S_S03N0120_1
    Dim intCol As Integer
    Dim intRow As Integer
    Public sPageName As String
#Region "@Form及功能操作@"
    Private Sub S_S03N0120_1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '物件初始化*****
        ComboboxList() 'Combobox初始化項目
        SearchClear(Me.Name) '是否清空查詢資料
        DataRead(INI_Read("BASIC", "SEARCH", "DATA")) '搜尋字串

        '欄位名稱
        Dim arrColName() As String = {"工令號碼", "客戶簡稱", "規格", "表面硬度", "心部硬度", "抗拉強度", "滲碳層", "扭力", "回火溫度", "預排爐號"}
        Dim arrColWidth() As String = {"100", "100", "100", "80", "60", "60", "60", "60", "60", "60"}

        DataGridView.ColumnCount = arrColName.Length
        DataGridView.RowCount = 1

        For J As Integer = 0 To arrColName.Length - 1 Step 1
            With DataGridView
                .Columns(J).Name = arrColName(J) '欄位名稱
                .Columns(J).Width = arrColWidth(J) '欄位寬度
            End With
        Next
    End Sub

    '確定
    Private Sub btnDefine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefine.Click
        Dim strSQL As String = "" : Dim strValue As String = ""

        '程序專用*****
        Dim objCon99 As SqlConnection
        Dim objCmd99 As SqlCommand
        Dim objDR99 As SqlDataReader
        Dim strSQL99 As String
        Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值

        '資料查詢*****
        If DataGridView.Rows.Count > 0 Then

            '開啟查詢
            objCon99 = New SqlConnection(DNS)
            objCon99.Open()

            strSQL99 = "SELECT * FROM 進貨單主檔"
            strSQL99 &= " WHERE 工令號碼 = '" & DataGridView.Rows(intRow).Cells(0).Value.ToString & "'"

            objCmd99 = New SqlCommand(strSQL99, objCon99)
            objDR99 = objCmd99.ExecuteReader
            'MsgBox(DataGridView.Rows(intRow).Cells(0).Value.ToString)

            If objDR99.Read Then
                For Each MdiChildForm As Object In My.Forms.fmMain.MdiChildren
                    If MdiChildForm.Name = "S03N0120" Then
                        ' MsgBox(objDR99("工令號碼").ToString)
                        MdiChildForm.線材爐號.Text = objDR99("線材爐號").ToString
                        MdiChildForm.扭力.Text = objDR99("扭力").ToString
                        'MdiChildForm.華司材質.Text = objDR99("華司材質").ToString
                        'MdiChildForm.華司硬度.Text = objDR99("華司硬度").ToString
                        MdiChildForm.回火溫度.Text = objDR99("回火爐2").ToString
                        MdiChildForm.以前爐號.Text = objDR99("預排爐號").ToString

                        MdiChildForm.流量.Text = objDR99("流量").ToString
                        MdiChildForm.CP值.Text = objDR99("CP值").ToString
                        MdiChildForm.氨值1.Text = objDR99("氨值1").ToString
                        MdiChildForm.氨值2.Text = objDR99("氨值2").ToString
                        MdiChildForm.氨值3.Text = objDR99("氨值3").ToString
                        MdiChildForm.氨值4.Text = objDR99("氨值4").ToString
                        MdiChildForm.加熱爐1.Text = objDR99("加熱爐1").ToString
                        MdiChildForm.加熱爐2.Text = objDR99("加熱爐2").ToString
                        MdiChildForm.加熱爐3.Text = objDR99("加熱爐3").ToString
                        MdiChildForm.加熱爐4.Text = objDR99("加熱爐4").ToString
                        MdiChildForm.加熱爐5.Text = objDR99("加熱爐5").ToString
                        MdiChildForm.加熱爐6.Text = objDR99("加熱爐6").ToString
                        MdiChildForm.加熱爐油溫.Text = objDR99("加熱爐油溫").ToString
                        MdiChildForm.加熱爐速度.Text = objDR99("加熱爐速度").ToString
                        MdiChildForm.回火爐1.Text = objDR99("回火爐1").ToString
                        MdiChildForm.回火爐2.Text = objDR99("回火爐2").ToString
                        MdiChildForm.回火爐3.Text = objDR99("回火爐3").ToString
                        MdiChildForm.回火爐4.Text = objDR99("回火爐4").ToString
                        MdiChildForm.回火爐5.Text = objDR99("回火爐5").ToString
                        MdiChildForm.回火爐6.Text = objDR99("回火爐6").ToString
                        MdiChildForm.回火爐速度.Text = objDR99("回火爐速度").ToString
                    ElseIf MdiChildForm.Name = "S03N0200" Then
                        MdiChildForm.線材爐號.Text = objDR99("線材爐號").ToString

                        MdiChildForm.流量.Text = objDR99("流量").ToString
                        MdiChildForm.CP值.Text = objDR99("CP值").ToString
                        MdiChildForm.氨值1.Text = objDR99("氨值1").ToString
                        MdiChildForm.氨值2.Text = objDR99("氨值2").ToString
                        MdiChildForm.氨值3.Text = objDR99("氨值3").ToString
                        MdiChildForm.氨值4.Text = objDR99("氨值4").ToString
                        MdiChildForm.加熱爐1.Text = objDR99("加熱爐1").ToString
                        MdiChildForm.加熱爐2.Text = objDR99("加熱爐2").ToString
                        MdiChildForm.加熱爐3.Text = objDR99("加熱爐3").ToString
                        MdiChildForm.加熱爐4.Text = objDR99("加熱爐4").ToString
                        MdiChildForm.加熱爐5.Text = objDR99("加熱爐5").ToString
                        MdiChildForm.加熱爐6.Text = objDR99("加熱爐6").ToString
                        MdiChildForm.加熱爐油溫.Text = objDR99("加熱爐油溫").ToString
                        MdiChildForm.加熱爐速度.Text = objDR99("加熱爐速度").ToString
                        MdiChildForm.回火爐1.Text = objDR99("回火爐1").ToString
                        MdiChildForm.回火爐2.Text = objDR99("回火爐2").ToString
                        MdiChildForm.回火爐3.Text = objDR99("回火爐3").ToString
                        MdiChildForm.回火爐4.Text = objDR99("回火爐4").ToString
                        MdiChildForm.回火爐5.Text = objDR99("回火爐5").ToString
                        MdiChildForm.回火爐6.Text = objDR99("回火爐6").ToString
                        MdiChildForm.回火爐速度.Text = objDR99("回火爐速度").ToString

                    End If


                Next

            End If

        End If
        Me.Close()
    End Sub

    '取消
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'INI_Write("BASIC", "SEARCH", "PAGE", "")
        'INI_Write("BASIC", "SEARCH", "SQL", "")
        'INI_Write("BASIC", "SEARCH", "DATA", "")
        Me.Close()
    End Sub
#End Region

#Region "ComboBox及讀取查詢值"
    'ComboBox
    Sub ComboboxList()
        Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值

        ComboBox_DB(產品代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼+' '+一層名稱", "類別 = 'S03N0001'", "一層代碼 ASC")
        ComboBox_DB(規格代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0004'", "一層代碼 ASC")
        ComboBox_DB(長度代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0005'", "一層代碼 ASC")
        ComboBox_DB(品名分類代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0003'", "一層代碼 ASC")
        ComboBox_DB(加工方式代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0006'", "一層代碼 ASC")
        ComboBox_DB(材質代碼, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S03N0007'", "一層代碼 ASC")
        ComboBox_DB(強度級數, DNS, "s_一層代碼檔", "一層代碼", "一層代碼", "類別 = 'S04N0002'", "一層代碼 ASC")

    End Sub

    '搜尋字串
    Sub DataRead(ByVal strData As String)
        'If strData <> "" Then
        '    Dim objArray() As Object = {S_ComboBox1, S_TextBox1, S_TextBox2, S_TextBox3}
        '    Dim strValue() As String = strData.Split(",")

        '    For I As Integer = 0 To objArray.Length - 1 Step 1
        '        Select Case objArray(I).GetType.Name
        '            Case "TextBox"
        '                Dim objTextBox As TextBox = objArray(I)
        '                objTextBox.Text = strValue(I)
        '            Case "ComboBox"
        '                Dim objComboBox As ComboBox = objArray(I)
        '                objComboBox.SelectedValue = strValue(I)
        '        End Select
        '    Next
        'End If
    End Sub
#End Region

#Region "副程式"
    '是否清空查詢資料
    Sub SearchClear(ByVal strPage As String)
        If strPage <> INI_Read("BASIC", "SEARCH", "PAGE") Then
            INI_Write("BASIC", "SEARCH", "PAGE", "")
            INI_Write("BASIC", "SEARCH", "SQL", "")
            INI_Write("BASIC", "SEARCH", "DATA", "")
        End If
    End Sub

    '記錄查詢值
    Function SearchWrite(ByVal objArray() As Object) As String
        Dim strString As String = ""

        'For I As Integer = 0 To objArray.Length - 1 Step 1
        '    Select Case objArray(I).GetType.Name
        '        Case "TextBox"
        '            Dim objTextBox As TextBox = objArray(I)
        '            strString &= objTextBox.Text & ","
        '        Case "ComboBox"
        '            Dim objComboBox As ComboBox = objArray(I)
        '            strString &= objComboBox.SelectedValue & ","
        '    End Select
        'Next

        Return strString
    End Function
#End Region

    Private Sub btnSerData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSerData.Click
        Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
        Dim strSQL As String = ""
        Dim arrRowName() As String
        '查詢語法
        strSQL = "SELECT 客戶簡稱 = case when t1.簡稱<>t7.簡稱 then t7.簡稱+'-'+t1.簡稱 else t1.簡稱 end"
        strSQL &= ",t3.一層名稱+'X'+isnull(t8.一層名稱,'')+長度說明 AS 規格"
        strSQL &= ",m.回火爐2 as 回火溫度"
        strSQL &= ",m.* FROM 進貨單主檔 AS m"
        strSQL &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0004') AS t3 ON m.規格代碼 = t3.一層代碼"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0007') AS t4 ON m.材質代碼 = t4.一層代碼"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0008') AS t6 ON m.表面處理代碼 = t6.一層代碼"
        strSQL &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        strSQL &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0005') AS t8 ON m.長度代碼 = t8.一層代碼 "
        'strSQL &= " LEFT JOIN 出貨單項目檔 AS t9 ON m.工令號碼 = t9.工令號碼  "
        strSQL &= " WHERE 1=1"
        If 產品代碼.SelectedValue <> "" Then strSQL &= " AND m.產品代碼 = '" & 產品代碼.SelectedValue & "'"
        If 規格代碼.SelectedValue <> "" Then strSQL &= " AND m.規格代碼 = '" & 規格代碼.SelectedValue & "'"
        If 長度代碼.SelectedValue <> "" Then strSQL &= " AND m.長度代碼 = '" & 長度代碼.SelectedValue & "'"
        If 品名分類代碼.SelectedValue <> "" Then strSQL &= " AND m.品名分類代碼 = '" & 品名分類代碼.SelectedValue & "'"
        If 加工方式代碼.SelectedValue <> "" Then strSQL &= " AND m.加工方式代碼 = '" & 加工方式代碼.SelectedValue & "'"
        If 材質代碼.SelectedValue <> "" Then strSQL &= " AND m.材質代碼 = '" & 材質代碼.SelectedValue & "'"
        If 強度級數.SelectedValue <> "" Then strSQL &= " AND m.強度級數 = '" & 強度級數.SelectedValue & "'"
        If 線材爐號.Text <> "" Then strSQL &= " AND m.線材爐號 = '" & 線材爐號.Text & "'"
        If 產品名稱.Text <> "" Then strSQL &= " AND m.產品名稱 = '" & 產品名稱.Text & "'"

        strSQL &= " ORDER BY 進貨日期 DESC"

        '顯示欄位
        arrRowName = {"工令號碼", "客戶簡稱", "規格", "表面硬度", "心部硬度", "抗拉強度", "滲碳層", "扭力", "回火溫度", "預排爐號"}

        '開啟產生DataGridView
        DataGridViewR_DB(DataGridView, DNS, strSQL, arrRowName)



    End Sub


    Private Sub DataGridView_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellClick
        intCol = e.ColumnIndex
        intRow = e.RowIndex
    End Sub

    Private Sub Label2_Click(sender As System.Object, e As System.EventArgs) Handles Label2.Click

    End Sub


End Class