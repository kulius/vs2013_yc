﻿'::::::::::::::::::
'::: 系統參數   :::
'::: 硬體序號  :::
'::::::::::::::::::
Imports System.Net
Imports System.Net.NetworkInformation

Module SystemValue
    '硬體序號
    Public Declare Sub GetSystemInfo Lib "kernel32" (ByRef lpSystemInfo As SYSTEM_INFO) 'CPU序號

    Public Sub MySystemValue()

    End Sub

#Region "日期及時間"
    ''' <summary>
    ''' 日期(yyyy-mm-dd;yyy-mm-dd)
    ''' </summary>
    ''' <param name="type">顯示種類(AD：西元年(預設) CD：民國年)(可省略)</param>
    ''' <returns>年月日(String)</returns>    
    Function NowDate(Optional type As String = "AD") As String
        Dim strString As String
        Dim dtDay As Date
        Dim strYear, strMonth, strDay As String

        dtDay = Today
        strYear = Year(dtDay) - IIf(type = "AD", 0, 1911)
        strMonth = Month(dtDay)
        strDay = Microsoft.VisualBasic.Day(dtDay)

        '日期補數
        strYear = strZero(IIf(type = "AD", 4, 3), strYear)
        strMonth = strZero(2, strMonth)
        strDay = strZero(2, strDay)

        strString = strYear & "-" & strMonth & "-" & strDay

        Return strString
    End Function

    ''' <summary>
    ''' 時間(24小時制)(hh:mm:ss)
    ''' </summary>
    ''' <returns>24小時制(String)</returns>
    Function NowTime() As String
        Dim strHour, strMinute, strSecond As String
        Dim strString As String

        strHour = Hour(Now)
        strMinute = Minute(Now)
        strSecond = Second(Now)

        '補數
        strHour = strZero(2, strHour)
        strMinute = strZero(2, strMinute)
        strSecond = strZero(2, strSecond)

        strString = strHour & ":" & strMinute & ":" & strSecond

        Return strString
    End Function
#End Region

#Region "日期及時間字串轉換"
    ''' <summary>
    ''' 系統日期轉日期(yyyymmdd->yyyy-mm-dd)
    ''' </summary>
    ''' <param name="strDate">日期字串</param>
    ''' <param name="Kind">分隔符號(預設：/)(可省略)</param>
    ''' <returns>轉換後日期(String)</returns>    
    Function strSystemToDate(ByVal strDate As String, Optional Kind As String = "/") As String
        Dim strString As String = "" '傳回變數值
        Dim strYear, strMonth, strDay As String
        Dim strDateArray() As String

        If strDate <> "" Then
            strDateArray = strDate.Split(Kind)

            strYear = strZero(4, Int(strDateArray(0)))
            strMonth = strZero(2, Int(strDateArray(1)))
            strDay = strZero(2, Int(strDateArray(2)))

            strString = strYear & "-" & strMonth & "-" & strDay
        End If

        Return strString
    End Function

    ''' <summary>
    ''' 字串日期轉日期(yyyymmdd->yyyy-mm-dd)
    ''' </summary>
    ''' <param name="strDate">日期字串</param>
    ''' <param name="type">顯示種類(AD：西元年(預設) CD：民國年)(可省略)</param>
    ''' <param name="Kind">分隔符號(預設：-)(可省略)</param>
    ''' <returns>轉換後日期(String)</returns>
    Function strStringToDate(ByVal strDate As String, Optional type As String = "AD", Optional Kind As String = "-") As String
        Dim strString As String = "" '傳回變數值
        Dim strYear, strMonth, strDay As String

        If strDate <> "" Then
            Select Case type
                Case "CD" '民國年
                    strYear = Mid(strDate, 1, 3)
                    strMonth = Mid(strDate, 4, 2)
                    strDay = Mid(strDate, 6, 2)

                Case Else
                    strYear = Mid(strDate, 1, 4)
                    strMonth = Mid(strDate, 5, 2)
                    strDay = Mid(strDate, 7, 2)
            End Select

            strString = strYear & Kind & strMonth & Kind & strDay
        End If

        Return strString
    End Function

    ''' <summary>
    ''' 日期轉字串日期(yyyy-mm-dd->yyyymmdd)
    ''' </summary>
    ''' <param name="strDate">日期字串</param>
    ''' <param name="type">顯示種類(AD：西元年(預設) CD：民國年)(可省略)</param>
    ''' <param name="Kind">分隔符號(預設：-)(可省略)</param>
    ''' <returns>轉換後日期(String)</returns>
    Function strDateToString(ByVal strDate As String, Optional type As String = "AD", Optional Kind As String = "-") As String
        Dim strString As String = "" '傳回變數值
        Dim strYear, strMonth, strDay As String
        Dim strDateArray() As String

        If strDate <> "" Then
            strDateArray = strDate.Split(Kind)

            strYear = strZero(IIf(type = "AD", 4, 3), Int(strDateArray(0)))
            strMonth = strZero(2, Int(strDateArray(1)))
            strDay = strZero(2, Int(strDateArray(2)))

            strString = strYear & strMonth & strDay
        End If

        Return strString
    End Function

    ''' <summary>
    ''' 日期分隔符號轉換(yyyy-mm-dd->yyyy/mm/dd)
    ''' </summary>
    ''' <param name="strDate">日期字串</param>
    ''' <param name="Before">來源分隔符號</param>
    ''' <param name="After">異動後分隔符號</param>
    ''' <returns>轉換後日期(String)</returns>
    Function strDateKindToDateKind(ByVal strDate As String, ByVal Before As String, ByVal After As String) As String
        Dim strString As String = "" '傳回變數值

        If strDate <> "" Then strString = Replace(strDate, Before, After)

        Return strString
    End Function
#End Region

#Region "硬體序號"
    ''' <summary>
    ''' CPU序號
    ''' </summary>
    ''' <returns>系統值(String)</returns>
    Function strCPU() As String
        Dim strString As String = "" '傳回變數值

        Dim CPUInfo As SYSTEM_INFO
        GetSystemInfo(CPUInfo)
        strString = CPUInfo.dwProcessorType

        Return strString
    End Function
    ''' <summary>
    ''' MAC序號
    ''' </summary>
    ''' <returns>系統值(String)</returns>
    Function strMAC() As String
        Dim strString As String = "" '傳回變數值
        Dim mac As String = "" 'MAC值

        Dim NWIntertface As NetworkInterface()

        NWIntertface = NetworkInterface.GetAllNetworkInterfaces
        For Each NWI As NetworkInterface In NWIntertface
            mac = NWI.GetPhysicalAddress.ToString
            Exit For
        Next

        strString = mac

        Return strString
    End Function
#End Region
End Module
