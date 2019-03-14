Imports FastReport
Imports FastReport.Utils
Public Class S03N9904
    Public mastconn As String = INI_Read("CONFIG", "SET", "DNS")

    Dim confid, confunit As String
    Dim sqlstr As String
    Dim bm As BindingManagerBase, mydataset As DataSet
    Dim UserId, UserName, UserUnit As String
#Region "單用變數"
    Dim FRreport As New Report
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
#End Region
    Private Sub S06R0700_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Width = 900
        Me.Height = 600

        所屬年.ShowUpDown = True
        所屬年.Format = DateTimePickerFormat.Custom
        所屬年.CustomFormat = "yyyy 年 "

        ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")

        'Call LoadGridFunc()

        'ComboBox_DB(操作人員, DNS, "員工主檔", "員工代號", "姓名", "離職日期 = '' and (職稱代碼1='01' or 職稱代碼2='01' or 職稱代碼3='01' )", "姓名 ASC")
        'ComboBox_DB(爐號, DNS, "s_一層代碼檔", "一層代碼", "一層名稱", "類別 = 'S03N0011'", "一層名稱 ASC")
    End Sub

    Private Sub btnPreviewRep_Click(sender As System.Object, e As System.EventArgs)
        FRreport.Preview = PreviewControl1
        FRreport.Load(ReportDir + "空桶欠缺明細表.frx")
        FRreport.SetParameterValue("ConnStr", INI_Read("CONFIG", "SET", "DNS"))
        'FRreport.SetParameterValue("RepKey", 爐號.SelectedValue)
        'FRreport.SetParameterValue("RepKey1", strSystemToDate(出貨日期1.Value.ToShortDateString))
        'FRreport.SetParameterValue("RepKey2", strSystemToDate(出貨日期2.Value.ToShortDateString))
        FRreport.Prepare()
        FRreport.ShowPrepared()
    End Sub

    Private Sub btnDesignRep_Click(sender As System.Object, e As System.EventArgs)

        FRreport.Load(ReportDir + "空桶欠缺明細表.frx")
        FRreport.Design()
    End Sub

    Sub LoadGridFunc()
        Dim sqlstr As String
        sqlstr = "SELECT   *  FROM  客戶年欠桶 where 年='" & CStr(所屬年.Value.Year) & "' and 客戶代號 = '" & CStr(所屬年.Value.Year) & "'"
        mydataset = openmember("", "客戶年欠桶", sqlstr)
        RecMove1.FilesPara = "mastconn=" & mastconn & "|sqlstr=" & sqlstr
        If mydataset.Tables(0).Rows.Count = 0 Then

        End If



        DataGrid1.DataSource = mydataset
        DataGrid1.DataMember = "客戶年欠桶"
        bm = Me.BindingContext(mydataset, "客戶年欠桶")
        RecMove1.Setds = bm

    End Sub

    Sub transjob(ByVal JobName As String, ByVal JobPara As String) Handles RecMove1.TransJob
        Dim LastPos As Integer = bm.Position
        Select Case JobName
            Case "刪除記錄"
                Dim keyvalue, sqlstr, retstr As String
                lastpos = bm.Position
                keyvalue = bm.Current("autono")
                sqlstr = "delete from 各爐產能設定 where autono=" & keyvalue
                retstr = runsql(mastconn, sqlstr)
                If retstr = "sqlok" Then
                    mydataset.Tables("各爐產能設定").Rows.RemoveAt(JobPara)
                    mydataset.Tables("各爐產能設定").Clear()
                    Call LoadGridFunc()
                    bm.Position = LastPos
                End If

            Case "回寫記錄cmd"
                Dim keyvalue, sqlstr, retstr, updstr As String
                Dim Rmark As Integer
                keyvalue = bm.Current("autono")
                '******************************

                RecMove1.GenInsSql("年月", bm.Current("年月"), "T")
                RecMove1.GenInsSql("爐號", bm.Current("爐號"), "T")
                RecMove1.GenInsSql("個人標準產量", bm.Current("個人標準產量"), "T")
                RecMove1.GenInsSql("標準總產量", bm.Current("標準總產量"), "T")
                RecMove1.GenInsSql("個人標準金額", bm.Current("個人標準金額"), "T")
                RecMove1.GenInsSql("標準總金額", bm.Current("標準總金額"), "T")

                sqlstr = "update 各爐產能設定 set " & RecMove1.genupdfunc & " where autono=" & keyvalue
                '********************
                retstr = runsql(mastconn, sqlstr)
                If retstr = "sqlok" Then
                    mydataset.Tables("各爐產能設定").Rows.RemoveAt(JobPara)
                    mydataset.Tables("各爐產能設定").Clear()
                    Call LoadGridFunc()
                    bm.Position = LastPos
                    'MsgBox("更新成功")
                End If


            Case "新增記錄"
                Dim keyvalue, sqlstr, retstr, updstr As String
                RecMove1.GenInsSql("年月", bm.Current("年月"), "T")
                RecMove1.GenInsSql("爐號", bm.Current("爐號"), "T")
                RecMove1.GenInsSql("個人標準產量", bm.Current("個人標準產量"), "T")
                RecMove1.GenInsSql("標準總產量", bm.Current("標準總產量"), "T")
                RecMove1.GenInsSql("個人標準金額", bm.Current("個人標準金額"), "T")
                RecMove1.GenInsSql("標準總金額", bm.Current("標準總金額"), "T")
                sqlstr = "insert into 各爐產能設定 " & RecMove1.GenInsFunc
                retstr = runsql(mastconn, sqlstr)

                If retstr = "sqlok" Then
                    mydataset.Tables("各爐產能設定").Rows.RemoveAt(JobPara)
                    mydataset.Tables("各爐產能設定").Clear()
                    Call LoadGridFunc()
                    bm.Position = LastPos
                    MsgBox("新增成功")
                End If
        End Select
    End Sub
    Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If IsDBNull(bm.Current("年月")) Then
            bm.Current("年月") = CStr(所屬年.Value.Year) + 所屬年.Value.Month.ToString.PadLeft(2, "0")
        End If
    End Sub

    Private Sub DataGrid1_Navigate(sender As Object, ne As NavigateEventArgs)

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Call LoadGridFunc()
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim tempDataSet As DataSet
    '    Dim retstr As String
    '    'sqlstr = "SELECT   *  FROM  各爐產能設定 where 年月='" & CStr(複製年月.Value.Year) + 複製年月.Value.Month.ToString.PadLeft(2, "0") & "'"

    '    sqlstr = "delete from 各爐產能設定 where 年月='" & CStr(所屬年.Value.Year) + 所屬年.Value.Month.ToString.PadLeft(2, "0") & "'"
    '    retstr = runsql(mastconn, sqlstr)

    '    sqlstr = "select 一層代碼,b.* from s_一層代碼檔 a "
    '    sqlstr += " left join 各爐產能設定 b on a.一層代碼=b.爐號 and b.年月='" & CStr(複製年月.Value.Year) + 複製年月.Value.Month.ToString.PadLeft(2, "0") & "'"
    '    sqlstr += " where 類別='S03N0011'"

    '    tempDataSet = openmember("", "copydata", sqlstr)


    '    For intI = 0 To tempDataSet.Tables("copydata").Rows.Count - 1

    '        RecMove1.GenInsSql("年月", CStr(所屬年.Value.Year) + 所屬年.Value.Month.ToString.PadLeft(2, "0"), "T")
    '        RecMove1.GenInsSql("爐號", nz(tempDataSet.Tables("copydata").Rows(intI)("一層代碼"), ""), "T")
    '        RecMove1.GenInsSql("個人標準產量", nz(tempDataSet.Tables("copydata").Rows(intI)("個人標準產量"), "0"), "T")
    '        RecMove1.GenInsSql("標準總產量", nz(tempDataSet.Tables("copydata").Rows(intI)("標準總產量"), "0"), "T")
    '        RecMove1.GenInsSql("個人標準金額", nz(tempDataSet.Tables("copydata").Rows(intI)("個人標準金額"), "0"), "T")
    '        RecMove1.GenInsSql("標準總金額", nz(tempDataSet.Tables("copydata").Rows(intI)("標準總金額"), "0"), "T")
    '        sqlstr = "insert into 各爐產能設定 " & RecMove1.GenInsFunc
    '        retstr = runsql(mastconn, sqlstr)
    '    Next

    '    Call LoadGridFunc()
    '    TabControl1.SelectedIndex = 0
    '    MsgBox("新增成功")

    'End Sub



    Private Sub DataGrid1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.RowEnter
        'If IsDBNull(bm.Current("年月")) Then
        '    bm.Current("年月") = CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0")
        'End If
    End Sub


    Private Sub DataGrid1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellEndEdit
        Dim keyvalue, sqlstr, retstr, updstr As String
        keyvalue = bm.Current("autono")
        '******************************

        GenUpdsql("年月", bm.Current("年月"), "T")
        GenUpdsql("爐號", bm.Current("爐號"), "T")
        GenUpdsql("個人標準產量", bm.Current("個人標準產量"), "T")
        GenUpdsql("標準總產量", bm.Current("標準總產量"), "T")
        GenUpdsql("個人標準金額", bm.Current("個人標準金額"), "T")
        GenUpdsql("標準總金額", bm.Current("標準總金額"), "T")

        sqlstr = "update 各爐產能設定 set " & genupdfunc & " where autono=" & keyvalue
        '********************
        retstr = runsql(mastconn, sqlstr)
        If retstr <> "sqlok" Then
            MsgBox("更新失敗")
        End If
    End Sub

    Private Sub s客戶代號_SelectedIndexChanged(sender As Object, e As EventArgs) Handles s客戶代號.SelectedIndexChanged
        If s客戶代號.SelectedIndex <> 0 Then
            s客戶代碼.Text = s客戶代號.SelectedValue
        End If
    End Sub

    Private Sub s客戶代碼_Leave(sender As Object, e As EventArgs) Handles s客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代碼.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代碼.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub
End Class