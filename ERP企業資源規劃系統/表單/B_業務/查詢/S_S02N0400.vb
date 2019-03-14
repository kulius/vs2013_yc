Public Class S_S02N0400
#Region "@Form及功能操作@"
    Private Sub S_S02N0400_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '物件初始化*****
        ComboboxList() 'Combobox初始化項目
        SearchClear(Me.Name) '是否清空查詢資料
        DataRead(INI_Read("BASIC", "SEARCH", "DATA")) '搜尋字串
    End Sub

    '確定
    Private Sub btnDefine_Click(sender As System.Object, e As System.EventArgs) Handles btnDefine.Click
        Dim strSQL As String = "" : Dim strValue As String = ""

        '查詢條件        
        If S_TextBox1.Text <> "" Then strSQL &= " AND m.報價單號 LIKE '%" & S_TextBox1.Text & "%'"
        If S_TextBox2.Text <> "" Then strSQL &= " AND t1.客戶代號 >= '" & S_TextBox2.Text & "'"
        If S_TextBox3.Text <> "" Then strSQL &= " AND t1.客戶代號 <= '" & S_TextBox3.Text & "'"

        If 報價日期起.Value.ToShortDateString <> Now.Date Or 報價日期迄.Value.ToShortDateString <> Now.Date Then strSQL &= " AND m.報價日期 >= '" & strSystemToDate(報價日期起.Value.ToShortDateString) & "' AND m.報價日期 <= '" & strSystemToDate(報價日期迄.Value.ToShortDateString) & "'"

        '查詢欄位值
        Dim objArray() As Object = {S_TextBox1, S_TextBox2, S_TextBox3, 報價日期起, 報價日期迄}
        strValue = SearchWrite(objArray)

        '記錄INI值
        INI_Write("BASIC", "SEARCH", "PAGE", Me.Name)
        INI_Write("BASIC", "SEARCH", "SQL", strSQL)
        INI_Write("BASIC", "SEARCH", "DATA", strValue)

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

    End Sub

    '搜尋字串
    Sub DataRead(ByVal strData As String)
        If strData <> "" Then
            Dim objArray() As Object = {S_TextBox1, S_TextBox2, S_TextBox3, 報價日期起, 報價日期迄}
            Dim strValue() As String = strData.Split(",")

            For I As Integer = 0 To objArray.Length - 1 Step 1
                Select Case objArray(I).GetType.Name
                    Case "TextBox"
                        Dim objTextBox As TextBox = objArray(I)
                        objTextBox.Text = strValue(I)

                    Case "DateTimePicker"
                        Dim objDateTimePicker As DateTimePicker = objArray(I)
                        objDateTimePicker.Value = strValue(I)
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

                Case "DateTimePicker"
                    Dim objDateTimePicker As DateTimePicker = objArray(I)
                    strString &= objDateTimePicker.Value.ToShortDateString & ","
            End Select
        Next

        Return strString
    End Function
#End Region
End Class