Public Class S03N0410
    Public mastconn As String = INI_Read("CONFIG", "SET", "DNS")
    Public DNS As String = INI_Read("CONFIG", "SET", "DNS")

    Dim confid, confunit As String
    Dim sqlstr As String
    Dim bm, bm1 As BindingManagerBase, mydataset, mydataset1 As DataSet
    Dim UserId, UserName, UserUnit As String

    Private Sub S03N0410_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        進貨日期.ShowUpDown = True
        'ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")
        Call LoadGridFunc()
    End Sub

    Sub LoadGridFunc()
        Dim sqlstr As String
        'sqlstr = "SELECT   *  FROM  各爐產能設定 where 年月='" & CStr(進貨日期.Value.Year) + 進貨日期.Value.Month.ToString.PadLeft(2, "0") & "'"

        '查詢語法
        sqlstr = "SELECT 工令號碼,報價單價,t5.一層名稱 AS 狀態"
        sqlstr &= ",t1.簡稱 as 客戶簡稱"
        sqlstr &= ",產品名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面,m.規格代碼,m.長度代碼,加工方式代碼,表面硬度,心部硬度,m.淨重,m.品管備註1,m.客戶代號 FROM 進貨單主檔 AS m"
        sqlstr &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        sqlstr &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        sqlstr &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        sqlstr &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        sqlstr &= " WHERE 1=1 "
        If Trim(s客戶代碼.Text) <> "" Then
            sqlstr &= " and m.客戶代號 ='" + Trim(s客戶代碼.Text) + "'"
        End If

        sqlstr &= " and m.進貨日期 ='" + strSystemToDate(進貨日期.Value.ToShortDateString) + "'"
        sqlstr &= " ORDER BY 工令號碼 DESC"

        mydataset = openmember("", "進貨單", sqlstr)
        'RecMove1.FilesPara = "mastconn=" & mastconn & "|sqlstr=" & sqlstr
        DataGrid1.DataSource = mydataset
        DataGrid1.DataMember = "進貨單"
        bm = Me.BindingContext(mydataset, "進貨單")
        'RecMove1.Setds = bm

        Dim objConSC As SqlConnection
        Dim objCmdSC As SqlCommand
        Dim objDRSC As SqlDataReader
        Dim strSQLSC As String

        'ComboBox_DB(s客戶代號, DNS, "客戶主檔", "客戶代號", "公司名稱", "往來否 = 'Y'", "公司名稱 ASC")

        Dim List As New DataTable()
        List.Columns.Add(New DataColumn("ID", System.Type.GetType("System.String")))
        List.Columns.Add(New DataColumn("NAME", System.Type.GetType("System.String")))


        '加入顯示
        '開啟產生
        objConSC = New SqlConnection(DNS)
        objConSC.Open()

        strSQLSC = "select m.客戶代號,t1.簡稱 FROM 進貨單主檔 AS m LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        strSQLSC &= " WHERE 1=1 "
        strSQLSC &= " and m.進貨日期 ='" + strSystemToDate(進貨日期.Value.ToShortDateString) + "'"
        strSQLSC &= " group by m.客戶代號,t1.簡稱"


        objCmdSC = New SqlCommand(strSQLSC, objConSC)
        objDRSC = objCmdSC.ExecuteReader

        Dim I As Integer = 1
        List.Rows.Add(List.NewRow())
        List.Rows(0)(0) = "" : List.Rows(0)(1) = ""
        Do While objDRSC.Read
            List.Rows.Add(List.NewRow())
            List.Rows(I)(0) = Trim(objDRSC("客戶代號").ToString)
            List.Rows(I)(1) = Trim(objDRSC("簡稱").ToString)

            I += 1
        Loop

        objDRSC.Close()    '關閉連結
        objConSC.Close()
        objCmdSC.Dispose() '手動釋放資源
        objConSC.Dispose()
        objConSC = Nothing '移除指標


        s客戶代號.DataSource = List
        s客戶代號.ValueMember = "ID"
        s客戶代號.DisplayMember = "NAME"

        Try
            s客戶代號.SelectedValue = s客戶代碼.Text
        Catch ex As Exception

        End Try



    End Sub

    Sub transjob(ByVal JobName As String, ByVal JobPara As String)
        
    End Sub



    Private Sub BtnSearch_Click_1(sender As Object, e As EventArgs) Handles BtnSearch.Click
        LoadGridFunc()

        
    End Sub

    Private Sub DataGrid1_CellEndEdit_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellEndEdit
        Dim view As DataGridView = CType(sender, DataGridView)

        Dim value As String = ""
        Dim value1 As String = ""
        Dim data As Single = 0
        Select Case e.ColumnIndex
            Case 1
                Dim keyvalue, sqlstr, retstr, updstr As String
                Dim Rmark As Integer
                keyvalue = bm.Current("工令號碼")
                '******************************

                If Not IsDBNull(bm.Current("報價單價")) Then
                    GenUpdsql("報價單價", bm.Current("報價單價"), "T")

                    sqlstr = "update 進貨單主檔 set " & genupdfunc & " where 工令號碼='" & keyvalue & "'"
                    '********************
                    retstr = runsql(mastconn, sqlstr)
                    If retstr <> "sqlok" Then
                        MsgBox("更新失敗")
                    End If
                End If

        End Select

    End Sub


    Private Sub DataGrid1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGrid1.CellClick
        Dim sqlstr As String
        'sqlstr = "SELECT   *  FROM  各爐產能設定 where 年月='" & CStr(進貨日期.Value.Year) + 進貨日期.Value.Month.ToString.PadLeft(2, "0") & "'"

        '查詢語法
        sqlstr = "SELECT 進貨日期,t8.工令號碼,t8.單價,t5.一層名稱 AS 狀態"
        sqlstr &= ",t1.簡稱 as 客戶簡稱"
        sqlstr &= ",產品名稱 AS 品名,m.規格代碼+'X'+m.長度代碼+長度說明 AS 規格,m.材質代碼 AS 材質,m.表面處理代碼 AS 表面,m.規格代碼,m.長度代碼,m.加工方式代碼,m.表面硬度,m.心部硬度,m.客戶代號 FROM 進貨單主檔 AS m"
        sqlstr &= " LEFT JOIN 客戶主檔 AS t1 ON m.客戶代號 = t1.客戶代號"
        sqlstr &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = 'S03N0001') AS t2 ON m.產品代碼 = t2.一層代碼"
        sqlstr &= " LEFT JOIN (select * from s_一層代碼檔 where 類別 = '狀態') AS t5 ON m.狀態 = t5.一層代碼"
        sqlstr &= " LEFT JOIN 加工廠主檔 AS t7 ON m.加工廠代號 = t7.加工廠代號"
        sqlstr &= " inner JOIN 出貨單項目檔 AS t8 ON m.工令號碼 = t8.工令號碼"
        sqlstr &= " WHERE 1=1 and t8.單價 <> 0"
        If CK品名.Checked Then
            sqlstr &= " and m.產品名稱 ='" + bm.Current("品名") + "'"
        End If
        If CK規格.Checked Then
            sqlstr &= " and m.規格代碼 ='" + bm.Current("規格代碼") + "'"
        End If
        If CK長度.Checked Then
            sqlstr &= " and m.長度代碼 ='" + bm.Current("長度代碼") + "'"
        End If
        If CK材質.Checked Then
            sqlstr &= " and m.材質代碼 ='" + bm.Current("材質") + "'"
        End If
        If CK表面.Checked Then
            sqlstr &= " and m.表面處理代碼 ='" + bm.Current("表面") + "'"
        End If
        If CK加工方式.Checked Then
            sqlstr &= " and m.加工方式代碼 ='" + bm.Current("加工方式代碼") + "'"
        End If
        If CK心部硬度.Checked Then
            sqlstr &= " and m.心部硬度 ='" + bm.Current("心部硬度") + "'"
        End If
        If CK表面硬度.Checked Then
            sqlstr &= " and m.表面硬度 ='" + bm.Current("表面硬度") + "'"
        End If

        If CK客戶.Checked Then
            sqlstr &= " and m.客戶代號 ='" + bm.Current("客戶代號") + "'"
        End If

        sqlstr &= " ORDER BY 進貨日期 DESC"

        mydataset1 = openmember("", "出貨單價", sqlstr)
        'RecMove1.FilesPara = "mastconn=" & mastconn & "|sqlstr=" & sqlstr
        DataGrid_Det.DataSource = mydataset1
        DataGrid_Det.DataMember = "出貨單價"
        bm1 = Me.BindingContext(mydataset1, "出貨單價")
    End Sub

    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAutoPrice_Click(sender As Object, e As EventArgs) Handles btnAutoPrice.Click
        Dim retstr As String


        sqlstr = "  Update 進貨單主檔 "
        sqlstr &= " set 報價單價="
        sqlstr &= " (select top 1 isnull(b.單價,0) as 單價  from 進貨單主檔 m inner join 出貨單項目檔 b  on m.工令號碼=b.工令號碼"
        sqlstr &= " where m.客戶代號=進貨單主檔.客戶代號 and isnull(b.單價,0)<>0 "
        If CK品名.Checked Then
            sqlstr &= " and m.產品名稱 =進貨單主檔.產品名稱 "
        End If
        If CK規格.Checked Then
            sqlstr &= " and m.規格代碼 =進貨單主檔.規格代碼 "
        End If
        If CK長度.Checked Then
            sqlstr &= " and m.長度代碼 =進貨單主檔.長度代碼 "
        End If
        If CK材質.Checked Then
            sqlstr &= " and m.材質代碼 =進貨單主檔.材質代碼 "
        End If
        If CK表面.Checked Then
            sqlstr &= " and m.表面處理代碼 =進貨單主檔.表面處理代碼 "
        End If
        If CK加工方式.Checked Then
            sqlstr &= " and m.加工方式代碼 =進貨單主檔.加工方式代碼 "
        End If
        If CK心部硬度.Checked Then
            sqlstr &= " and m.心部硬度 =進貨單主檔.心部硬度 "
        End If
        If CK表面硬度.Checked Then
            sqlstr &= " and m.表面硬度 =進貨單主檔.表面硬度"
        End If

        If CK客戶.Checked Then
            sqlstr &= " and m.客戶代號 =進貨單主檔.客戶代號 "
        End If

        sqlstr &= " ORDER BY 進貨日期 DESC ) where isnull(進貨單主檔.報價單價,0) = 0 and 進貨單主檔.進貨日期 ='" + strSystemToDate(進貨日期.Value.ToShortDateString) + "'"

        If Trim(s客戶代碼.Text) <> "" Then
            sqlstr &= " and 進貨單主檔.客戶代號 ='" + Trim(s客戶代碼.Text) + "'"
        End If
        '********************
        retstr = runsql(mastconn, sqlstr)

        If retstr <> "sqlok" Then
            MsgBox("更新失敗")
        Else
            BtnSearch.PerformClick()
            MsgBox("自動填入完成")
        End If
    End Sub

    Private Sub s客戶代碼_Leave(sender As Object, e As EventArgs) Handles s客戶代碼.Leave
        If dbCount(DNS, "客戶主檔", "intCount", "客戶代號 = '" & s客戶代碼.Text & "'") > 0 Then
            s客戶代號.SelectedValue = s客戶代碼.Text
        Else
            s客戶代號.SelectedValue = ""
        End If
    End Sub

    Private Sub s客戶代號_SelectedIndexChanged(sender As Object, e As EventArgs) Handles s客戶代號.SelectedIndexChanged
        If s客戶代號.SelectedIndex <> 0 Then
            s客戶代碼.Text = s客戶代號.SelectedValue
        End If
    End Sub


End Class