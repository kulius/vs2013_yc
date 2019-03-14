Public Class S_S03N0110
#Region "@Form及功能操作@"
    Private Sub S_S04N0100_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****
        ComboboxList() 'Combobox初始化項目
        SearchClear(Me.Name) '是否清空查詢資料
        DataRead(INI_Read("BASIC", "SEARCH", "DATA")) '搜尋字串
    End Sub

    '確定
    Private Sub btnDefine_Click(sender As System.Object, e As System.EventArgs) Handles btnDefine.Click
        Dim strSQL As String = "" : Dim strValue As String = ""

        '查詢條件        
        If S_ComboBox1.SelectedValue <> "" Then strSQL &= " AND m.司機代號 = '" & S_ComboBox1.SelectedValue & "'"
        If S_TextBox1.Text <> "" Then strSQL &= " AND m.車次序號 LIKE '%" & S_TextBox1.Text & "%'"
        If CK1.Checked = True Then strSQL &= " AND m.日期 = '" & strSystemToDate(S_Date.Value.ToShortDateString) & "'"
        'If S_TextBox3.Text <> "" Then strSQL &= " AND m.過磅單號 <= '" & S_TextBox3.Text & "'"

        '查詢欄位值
        Dim objArray() As Object = {S_ComboBox1, S_TextBox1, S_Date}
        strValue = SearchWrite(objArray)

        '記錄INI值
        INI_Write("BASIC", "SEARCH", "PAGE", Me.Name)
        INI_Write("BASIC", "SEARCH", "SQL", strSQL)
        INI_Write("BASIC", "SEARCH", "DATA", strValue)
        For Each MdiChildForm As Object In My.Forms.fmMain.MdiChildren
            If MdiChildForm.Name = "S03N0110" Then
                MdiChildForm.FillData(INI_Read("BASIC", "SEARCH", "SQL"))
            End If
        Next
        Me.Close()
    End Sub

    '取消
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        INI_Write("BASIC", "SEARCH", "PAGE", "")
        INI_Write("BASIC", "SEARCH", "SQL", "")
        INI_Write("BASIC", "SEARCH", "DATA", "")

        Me.Close()
    End Sub
#End Region

#Region "ComboBox及讀取查詢值"
    'ComboBox
    Sub ComboboxList()
        Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值

        ComboBox_DB(S_ComboBox1, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
    End Sub

    '搜尋字串
    Sub DataRead(ByVal strData As String)
        If strData <> "" Then
            Dim objArray() As Object = {S_ComboBox1, S_TextBox1, S_Date}
            Dim strValue() As String = strData.Split(",")

            For I As Integer = 0 To objArray.Length - 1 Step 1
                Select Case objArray(I).GetType.Name
                    Case "TextBox"
                        Dim objTextBox As TextBox = objArray(I)
                        objTextBox.Text = strValue(I)
                    Case "ComboBox"
                        Dim objComboBox As ComboBox = objArray(I)
                        objComboBox.SelectedValue = strValue(I)
                End Select
            Next
        End If
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

        For I As Integer = 0 To objArray.Length - 1 Step 1
            Select Case objArray(I).GetType.Name
                Case "TextBox"
                    Dim objTextBox As TextBox = objArray(I)
                    strString &= objTextBox.Text & ","
                Case "ComboBox"
                    Dim objComboBox As ComboBox = objArray(I)
                    strString &= objComboBox.SelectedValue & ","
            End Select
        Next

        Return strString
    End Function
#End Region
End Class