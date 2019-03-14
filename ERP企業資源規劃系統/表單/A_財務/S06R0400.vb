Imports FastReport
Imports FastReport.Utils
Public Class S06R0400
#Region "單用變數"
    Dim FRreport As New Report
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region
    Private Sub S06R0400_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 600

        所屬年月.Format = DateTimePickerFormat.Custom
        所屬年月.CustomFormat = "yyyy 年 MM 月"
        'ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        'ComboBox_DB(爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
    End Sub

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + "加工收入明細表.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        'FRreport.SetParameterValue("RepKey", 爐號.SelectedValue)
        FRreport.SetParameterValue("RepKey1", CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0"))
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click

        FRreport.Load(ReportDir + "加工收入明細表.frx")
        FRreport.Design()
    End Sub
End Class