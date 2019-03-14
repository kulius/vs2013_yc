Imports FastReport
Imports FastReport.Utils
Public Class R01N0002
#Region "單用變數"
    Dim FRreport As New Report
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region
    Private Sub R01N0002_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 600
        ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
    End Sub

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + "操作員生產量明細.frx")        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))        FRreport.SetParameterValue("RepKey", 操作人員.SelectedValue)        FRreport.SetParameterValue("RepKey1", strSystemToDate(製造日期1.Value.ToShortDateString))        FRreport.SetParameterValue("RepKey2", strSystemToDate(製造日期2.Value.ToShortDateString))        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click

        FRreport.Load(ReportDir + "操作員生產量明細.frx")
        FRreport.Design()
    End Sub
End Class