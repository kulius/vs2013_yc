Imports FastReport
Imports FastReport.Utils
Public Class PreviewReport
#Region "單用變數"
    Dim FRreport As New Report
    Public DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs) Handles btnDesignRep.Click
        Dim thisFolder As String = ReportDir
        FRreport.Load(thisFolder + lblReportFile.Text)
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", lblRepKey.Text)

        If lblRepKey1.Text <> "" Then
            FRreport.SetParameterValue("RepKey1", lblRepKey1.Text)
        End If
        If lblRepKey2.Text <> "" Then
            FRreport.SetParameterValue("RepKey2", lblRepKey2.Text)
        End If
        If lblRepKey3.Text <> "" Then
            FRreport.SetParameterValue("RepKey3", lblRepKey3.Text)
        End If
        If lblRepKey4.Text <> "" Then
            FRreport.SetParameterValue("RepKey4", lblRepKey4.Text)
        End If
        If lblRepKey5.Text <> "" Then
            FRreport.SetParameterValue("RepKey5", lblRepKey5.Text)
        End If

        FRreport.Design()
    End Sub

    Public Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs) Handles btnPreviewRep.Click
        Dim thisFolder As String = ReportDir

        FRreport.Preview = PreviewControl1
        FRreport.Load(thisFolder + lblReportFile.text)
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        FRreport.SetParameterValue("RepKey", lblRepKey.Text)

        If lblRepKey1.Text <> "" Then
            FRreport.SetParameterValue("RepKey1", lblRepKey1.Text)
        End If
        If lblRepKey2.Text <> "" Then
            FRreport.SetParameterValue("RepKey2", lblRepKey2.Text)
        End If
        If lblRepKey3.Text <> "" Then
            FRreport.SetParameterValue("RepKey3", lblRepKey3.Text)
        End If
        If lblRepKey4.Text <> "" Then
            FRreport.SetParameterValue("RepKey4", lblRepKey4.Text)
        End If
        If lblRepKey5.Text <> "" Then
            FRreport.SetParameterValue("RepKey5", lblRepKey5.Text)
        End If

        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub
End Class