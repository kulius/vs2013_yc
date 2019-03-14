Imports FastReport
Imports FastReport.Utils
Public Class R01N0008
#Region "單用變數"
    Dim FRreport As New Report
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region
    Private Sub R01N0008_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 600
        ComboBox_DB(s爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
        'ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        'ComboBox_DB(爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
    End Sub

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        If 報表名稱.Text = "" Then
            Exit Sub
        End If
        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + 報表名稱.Text + ".frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", s爐號.SelectedValue)
        FRreport.SetParameterValue("RepKey1", strSystemToDate(製造日期1.Value.ToShortDateString))
        FRreport.SetParameterValue("RepKey2", strSystemToDate(製造日期2.Value.ToShortDateString))
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        If 報表名稱.Text = "" Then
            Exit Sub
        End If
        FRreport.Load(ReportDir + 報表名稱.Text + ".frx")
        FRreport.Design()
    End Sub

    Private Sub 報表名稱_SelectedIndexChanged(sender As Object, e As EventArgs) Handles 報表名稱.SelectedIndexChanged
        s爐號.Visible = False
        l爐號.Visible = False
        s爐號.SelectedIndex = 0
        If 報表名稱.Text = "各爐個人每日產量明細表" Then
            s爐號.Visible = True
            l爐號.Visible = True
        ElseIf 報表名稱.Text = "各爐個人不合格品明細表" Then
            s爐號.Visible = True
            l爐號.Visible = True
        End If



    End Sub
End Class