Imports FastReport
Imports FastReport.Utils
Public Class R01N0001
#Region "單用變數"
    Dim FRreport As New Report
    Public DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + "司機載貨明細.frx")        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))        FRreport.SetParameterValue("RepKey", 司機代號.SelectedValue)        FRreport.SetParameterValue("RepKey1", strSystemToDate(統計日期1.Value.ToShortDateString))        FRreport.SetParameterValue("RepKey2", strSystemToDate(統計日期2.Value.ToShortDateString))        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub


    Private Sub R01N0001_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox_DB(司機代號, DNS, "司機主檔", "司機代號", "姓名", "", "姓名 ASC")
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        FRreport.Load(ReportDir + "司機載貨明細.frx")
        FRreport.Design()
    End Sub
End Class