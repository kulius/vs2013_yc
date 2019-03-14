Imports FastReport
Imports FastReport.Utils
Public Class S06R0600
#Region "單用變數"
    Dim FRreport As New Report
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region
#Region "@資料庫共用變數@"
    Dim strCSQL As String '查詢數量
    Dim strSSQL As String '查詢資料

    '程序專用*****
    Dim objCon99 As SqlConnection
    Dim objCmd99 As SqlCommand
    Dim objDR99 As SqlDataReader
    Dim strSQL99 As String
#End Region
    Private Sub S06R0600_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 600
        txtAutoComplete()
        '所屬年月.Format = DateTimePickerFormat.Custom
        '所屬年月.CustomFormat = "yyyy 年 MM 月"
        'ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        'ComboBox_DB(爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
    End Sub

    Public Sub txtAutoComplete()
        Dim namesCollection As AutoCompleteStringCollection = New AutoCompleteStringCollection
        '開啟查詢
        objCon99 = New SqlConnection(DNS)
        objCon99.Open()

        strSQL99 = "SELECT  憑單號碼 FROM 應收帳款主檔"
        'strSQL99 &= " WHERE 類別 = 'S03N0012'"

        objCmd99 = New SqlCommand(strSQL99, objCon99)
        objDR99 = objCmd99.ExecuteReader

        If objDR99.HasRows Then
            While objDR99.Read
                namesCollection.Add(objDR99("憑單號碼").ToString)
            End While
        End If

        objDR99.Close()

        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox1.AutoCompleteCustomSource = namesCollection
        TextBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox2.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox2.AutoCompleteCustomSource = namesCollection
    End Sub
    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + "應收帳款標籤.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", TextBox1.Text)
        FRreport.SetParameterValue("RepKey1", TextBox2.Text)
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click

        FRreport.Load(ReportDir + "應收帳款標籤.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", TextBox1.Text)
        FRreport.SetParameterValue("RepKey1", TextBox2.Text)
        FRreport.Design()
    End Sub
End Class