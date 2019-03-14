Imports FastReport
Imports FastReport.Utils
Public Class BaseReport
#Region "單用變數"
    Public FRreport As New Report
    Public DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region


End Class