Public Class S_S03N0120_2
    Dim strCSQL As String '查詢數量
    Dim strSSQL As String '查詢資料

    Dim intCol As Integer
    Dim intRow As Integer

    '程序專用*****
    Dim objCon99 As SqlConnection
    Dim objCmd99 As SqlCommand
    Dim objDR99 As SqlDataReader
    Dim strSQL99 As String

    Public SelectNO As String
    Public SelectKind As String

    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值

    Private Sub 廠內退回_CheckedChanged(sender As Object, e As EventArgs) Handles 廠內退回.CheckedChanged
        BackDataDGV.Columns(0).HeaderCell.Value = "出貨退回編號"
        BackDataDGV.Columns(1).HeaderCell.Value = "工令號碼"
        BackDataDGV.Columns(2).HeaderCell.Value = "退回備註"

        Dim strSQL As String = ""
        '查詢語法
        'strSQL = "SELECT 工令號碼 as 出貨退回編號,工令號碼,不合格品處理 as 退回備註 from 進貨單主檔"
        'strSQL &= " WHERE 處理方式='轉入進貨單' and 工令號碼 not in (select 前工令號碼 from 進貨單主檔)"
        'strSQL &= " order by 工令號碼 ASC"

        strSQL = "SELECT 工令號碼 as 出貨退回編號,工令號碼,不合格品處理 as 退回備註,b.前工令號碼"
        strSQL &= " from 進貨單主檔 a"
        strSQL &= " left join (select 前工令號碼 from 進貨單主檔) b on a.工令號碼=b.前工令號碼"
        strSQL &= " WHERE 處理方式='轉入進貨單' and b.前工令號碼 is null"
        strSQL &= " order by 工令號碼 ASC"


        DataGridView_HeaderDB(BackDataDGV, DNS, strSQL)

    End Sub

    Private Sub 廠外退回_CheckedChanged(sender As Object, e As EventArgs) Handles 廠外退回.CheckedChanged
        BackDataDGV.Columns(0).HeaderCell.Value = "出貨退回編號"
        BackDataDGV.Columns(1).HeaderCell.Value = "工令號碼"
        BackDataDGV.Columns(2).HeaderCell.Value = "退回備註"

        Dim strSQL As String = ""
        '查詢語法
        'strSQL = "SELECT * from 出貨退回主檔"
        'strSQL &= " WHERE isnull(新工令號碼,'') = '' and 處理方式='轉入進貨單' and 工令號碼 not in (select 前工令號碼 from 進貨單主檔)"
        'strSQL &= " order by 工令號碼 ASC"

        strSQL = "SELECT * from 出貨退回主檔 a"
        strSQL &= " left join (select 前工令號碼 from 進貨單主檔) b on a.工令號碼=b.前工令號碼"
        strSQL &= " WHERE isnull(新工令號碼,'') = '' and 處理方式='轉入進貨單' and b.前工令號碼 is null"
        strSQL &= " order by 工令號碼 ASC"


        DataGridView_HeaderDB(BackDataDGV, DNS, strSQL)
    End Sub

    Private Sub btnDefine_Click(sender As Object, e As EventArgs) Handles btnDefine.Click
        SelectNO = ""
        SelectNO = BackDataDGV.Rows(intRow).Cells(0).Value.ToString
        If 廠外退回.Checked Then
            SelectKind = "1"
        End If

        If 廠內退回.Checked Then
            SelectKind = "2"
        End If

        If 轉廠.Checked Then
            SelectKind = "3"
            SelectNO = BackDataDGV.Rows(intRow).Cells(1).Value.ToString
        End If

        If SelectNO = "" Then
            MsgBox("尚未選擇,工令號碼")
        End If

        'For Each MdiChildForm As Object In My.Forms.fmMain.MdiChildren
        '    If MdiChildForm.Name = "S03N0120" Then
        '        MdiChildForm.前工令號碼.Text = BackDataDGV.Rows(intRow).Cells(0).Value.ToString
        '    End If
        'Next
    End Sub

    Private Sub BackDataDGV_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles BackDataDGV.CellClick
        intCol = e.ColumnIndex
        intRow = e.RowIndex
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub 轉廠_CheckedChanged(sender As Object, e As EventArgs) Handles 轉廠.CheckedChanged

        BackDataDGV.Columns(0).HeaderCell.Value = "轉廠單號"
        BackDataDGV.Columns(1).HeaderCell.Value = "工令號碼"
        BackDataDGV.Columns(2).HeaderCell.Value = "備註"

        Dim strSQL As String = ""
        '查詢語法
        'strSQL = "SELECT * from 轉廠單項目檔"
        'strSQL &= " WHERE 工令號碼 not in (select 前工令號碼 from 進貨單主檔)"
        'strSQL &= " order by 工令號碼 ASC"


        strSQL = "SELECT * from 轉廠單項目檔 a "
        strSQL &= " left join (select 前工令號碼 from 進貨單主檔) b on a.工令號碼=b.前工令號碼"
        strSQL &= " where b.前工令號碼 Is null"
        strSQL &= " order by 工令號碼 ASC"


        DataGridView_HeaderDB(BackDataDGV, DNS, strSQL)
    End Sub
End Class