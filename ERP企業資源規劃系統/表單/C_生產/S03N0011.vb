Public Class S03N0011
    Public mastconn As String = INI_Read("CONFIG", "SET", "DNS")

    Dim confid, confunit As String
    Dim sqlstr As String
    Dim bm As BindingManagerBase, mydataset As DataSet
    Dim UserId, UserName, UserUnit As String

    Private Sub S03N0011_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        所屬年月.ShowUpDown = True
        所屬年月.Format = DateTimePickerFormat.Custom
        所屬年月.CustomFormat = "yyyy 年 MM 月"

        Dim dt As Date = Now
        複製年月.ShowUpDown = True
        複製年月.Format = DateTimePickerFormat.Custom
        複製年月.CustomFormat = "yyyy 年 MM 月"
        複製年月.Value = dt.AddMonths(-1)

        Call LoadGridFunc()
    End Sub

    Sub LoadGridFunc()
        Dim sqlstr As String
        sqlstr = "SELECT   *  FROM  各爐產能設定 where 年月='" & CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0") & "'"
        mydataset = openmember("", "各爐產能設定", sqlstr)
        RecMove1.FilesPara = "mastconn=" & mastconn & "|sqlstr=" & sqlstr
        DataGrid1.DataSource = mydataset
        DataGrid1.DataMember = "各爐產能設定"
        bm = Me.BindingContext(mydataset, "各爐產能設定")
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
            bm.Current("年月") = CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tempDataSet As DataSet
        Dim retstr As String
        'sqlstr = "SELECT   *  FROM  各爐產能設定 where 年月='" & CStr(複製年月.Value.Year) + 複製年月.Value.Month.ToString.PadLeft(2, "0") & "'"

        sqlstr = "delete from 各爐產能設定 where 年月='" & CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0") & "'"
        retstr = runsql(mastconn, sqlstr)

        sqlstr = "select 一層代碼,b.* from s_一層代碼檔 a "
        sqlstr += " left join 各爐產能設定 b on a.一層代碼=b.爐號 and b.年月='" & CStr(複製年月.Value.Year) + 複製年月.Value.Month.ToString.PadLeft(2, "0") & "'"
        sqlstr += " where 類別='S03N0011'"

        tempDataSet = openmember("", "copydata", sqlstr)


        For intI = 0 To tempDataSet.Tables("copydata").Rows.Count - 1

            RecMove1.GenInsSql("年月", CStr(所屬年月.Value.Year) + 所屬年月.Value.Month.ToString.PadLeft(2, "0"), "T")
            RecMove1.GenInsSql("爐號", nz(tempDataSet.Tables("copydata").Rows(intI)("一層代碼"), ""), "T")
            RecMove1.GenInsSql("個人標準產量", nz(tempDataSet.Tables("copydata").Rows(intI)("個人標準產量"), "0"), "T")
            RecMove1.GenInsSql("標準總產量", nz(tempDataSet.Tables("copydata").Rows(intI)("標準總產量"), "0"), "T")
            RecMove1.GenInsSql("個人標準金額", nz(tempDataSet.Tables("copydata").Rows(intI)("個人標準金額"), "0"), "T")
            RecMove1.GenInsSql("標準總金額", nz(tempDataSet.Tables("copydata").Rows(intI)("標準總金額"), "0"), "T")
            sqlstr = "insert into 各爐產能設定 " & RecMove1.GenInsFunc
            retstr = runsql(mastconn, sqlstr)
        Next

        Call LoadGridFunc()
        TabControl1.SelectedIndex = 0
        MsgBox("新增成功")

    End Sub



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
End Class