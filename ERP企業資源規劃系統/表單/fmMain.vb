Public Class fmMain
    Dim DNS As String = INI_Read("CONFIG", "SET", "DNS") 'DNS設定值
    Public FIRM As String
    Public FIRMCODE As String


#Region "@資料庫共用變數@"
    Dim strCSQL As String '查詢數量
    Dim strSSQL As String '查詢資料

    '程序專用*****
    Dim objCon99 As SqlConnection
    Dim objCmd99 As SqlCommand
    Dim objDR99 As SqlDataReader
    Dim strSQL99 As String
#End Region
#Region "@固定公用變數@"
    Dim I As Integer '累進變數
    Dim strMessage As String = "" '訊息字串
    Dim strIRow, strIValue, strUValue, strWValue As String '資料處理參數(新增欄位；新增資料；異動資料；條件)      
#End Region

#Region "@Form及功能操作@"
    Private Sub fmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '++ 物件初始化 ++
        UsersPower(INI_Read("BASIC", "LOGIN", "UNAME")) '已授權系統權限
        H01N0310.Text = "關於 " & INI_Read("CONFIG", "SYSTEM", "NAME") & "(&A)"

        '系統狀態
        Me.Text = FIRM & "✯✯✯" & INI_Read("CONFIG", "SYSTEM", "NAME") & "✯✯✯" '系統名稱        
        'txtPhone.Text = "維修專線：" & INI_Read("CONFIG", "BASIC", "TEL") '維修專線
        txtPhone.Text = "工廠別：" & FIRM
        txtUser.Text = "系統登入者：" & INI_Read("BASIC", "LOGIN", "NAME") '登入者
        txtDate.Text = NowDate() & "　" & NowTime() '小時鐘

        Me.Controls(Me.Controls.Count - 1).BackColor = Me.BackColor

        'Dim S99N0201 As New S99N0201

        'S99N0201.MdiParent = Me
        'S99N0201.Show()

    End Sub
    Private Sub fmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ComputerShutdown() '關閉電腦
    End Sub

    '狀態列
    Private Sub Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer.Tick
        txtDate.Text = NowDate() & "　" & NowTime() '小時鐘
    End Sub
#End Region

#Region "功能項目"
#Region "基本功能"
    Private Sub S99N9999_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S99N9999.Click
        Dim S99N9999 As New S99N9999

        S99N9999.MdiParent = Me
        S99N9999.Show()
    End Sub
    Private Sub Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Close.Click
        ComputerShutdown() '關閉電腦
    End Sub
#End Region
#Region "系統"
    Private Sub S99N0101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S99N0101.Click
        Dim S99N0101 As New S99N0101

        S99N0101.MdiParent = Me
        S99N0101.Show()
    End Sub
#End Region
#Region "人事薪資"
    '員工主檔
    Private Sub S01N0100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0100.Click
        Dim S01N0100 As New S01N0100

        S01N0100.MdiParent = Me
        S01N0100.Show()
    End Sub
    '司機主檔
    Private Sub S01N0200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0200.Click
        Dim S01N0200 As New S01N0200

        S01N0200.MdiParent = Me
        S01N0200.Show()
    End Sub

    '人事薪資基本對照檔維護
    Private Sub S01N0001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0001.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S01N0001"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S01N0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0002.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0002"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S01N0003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0003.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0003"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S01N0004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0004.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0004"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S01N0005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0005.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0005"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S01N0006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0006.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S01N0006"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S01N0007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0007.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0007"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S01N0008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S01N0008.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S01N0008"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
#End Region
#Region "業務"
    '客戶主檔
    Private Sub S02N0100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0100.Click
        Dim S02N0100 As New S02N0100

        S02N0100.MdiParent = Me
        S02N0100.Show()
    End Sub
    '前加工廠
    Private Sub S02N0201_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0201.Click
        Dim S02N0201 As New S02N0201

        S02N0201.MdiParent = Me
        S02N0201.Show()
    End Sub
    '次加工廠
    Private Sub S02N0202_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0202.Click
        Dim S02N0202 As New S02N0202

        S02N0202.MdiParent = Me
        S02N0202.Show()
    End Sub
    '廠商主檔
    Private Sub S02N0300_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0300.Click
        Dim S02N0300 As New S02N0300

        S02N0300.MdiParent = Me
        S02N0300.Show()
    End Sub
    '報價作業
    Private Sub S02N0400_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0400.Click
        Dim S02N0400 As New S02N0400

        S02N0400.MdiParent = Me
        S02N0400.Show()
    End Sub

    '業務基本對照檔維護
    Private Sub S02N0001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0001.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0001"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S02N0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0002.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0002"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S02N0003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0003.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0003"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S02N0004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0004.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0004"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S02N0005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0005.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0005"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S02N0006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S02N0006.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S02N0006"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
#End Region
#Region "生產"
    '過磅單作業
    Private Sub S03N0110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0110.Click
        Dim S03N0110 As New S03N0110

        S03N0110.MdiParent = Me
        S03N0110.Show()
    End Sub
    '進貨單作業
    Private Sub S03N0120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0120.Click
        Dim S03N0120 As New S03N0120

        S03N0120.MdiParent = Me
        S03N0120.Show()
    End Sub
    '客戶進貨庫存查詢作業
    Private Sub S03N0190_Click(sender As System.Object, e As System.EventArgs) Handles S03N0190.Click
        Dim S03N0190 As New S03N0190

        S03N0190.MdiParent = Me
        S03N0190.Show()
    End Sub
    '分爐排程作業
    Private Sub S03N0200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0200.Click
        Dim S03N0200 As New S03N0200

        S03N0200.MdiParent = Me
        S03N0200.Show()
    End Sub

    '生產管理基本對照檔維護
    Private Sub S03N0001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0001.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S03N0001"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S03N0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0002.Click

    End Sub
    Private Sub S03N0003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0003.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0003"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S03N0004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0004.Click
        Dim frmLevel12 As New frmLevel12
        'Dim a As Double
        frmLevel12.txtPage.Text = "S03N0004"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S03N0005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0005.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S03N0005"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S03N0006_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0006.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0006"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S03N0007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0007.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S03N0007"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub
    Private Sub S03N0008_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0008.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0008"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S03N0009_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0009.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0009"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S03N0010_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0010.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0010"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub
    Private Sub S03N0011_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0011.Click
        'Dim frmLevel12 As New frmLevel12

        'frmLevel12.txtPage.Text = "S03N0011"
        'frmLevel12.MdiParent = Me
        'frmLevel12.Show()

        Dim S03N0011 As New S03N0011

        S03N0011.MdiParent = Me
        S03N0011.Show()
    End Sub
    '待轉出貨處理
    Private Sub S03N0310_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0310.Click
        Dim S03N0310 As New S03N0310

        S03N0310.MdiParent = Me
        S03N0310.Show()
    End Sub
    '出貨單
    Private Sub S03N0320_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S03N0320.Click
        Dim S03N0320 As New S03N0320

        S03N0320.MdiParent = Me
        S03N0320.Show()
    End Sub
    '出貨單價設定
    Private Sub S03N0390_Click(sender As System.Object, e As System.EventArgs)
        Dim S03N0390 As New S03N0390

        S03N0390.MdiParent = Me
        S03N0390.NoShowPrice = True
        S03N0390.Show()
    End Sub
    '退回作業
    Private Sub S03N0330_Click(sender As Object, e As EventArgs) Handles S03N0330.Click
        Dim S03N0330 As New S03N0330

        S03N0330.MdiParent = Me
        S03N0330.Show()
    End Sub
#End Region
#Region "品質"
    '產品機械性質主檔
    Private Sub S04N0100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0100.Click
        Dim S04N0100 As New S04N0100

        S04N0100.MdiParent = Me
        S04N0100.Show()
    End Sub

    Private Sub S04N0001_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0001.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S04N0001"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub

    Private Sub S04N0002_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0002.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S04N0002"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub

    Private Sub S04N0003_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0003.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S04N0003"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub

    Private Sub S04N0004_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0004.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S04N0004"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()

    End Sub

    Private Sub S04N0005_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0005.Click
        Dim S04N0005 As New S04N0005

        S04N0005.MdiParent = Me
        S04N0005.Show()
    End Sub
    '品管作業
    Private Sub S04N0200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S04N0200.Click
        Dim S04N0200 As New S04N0200

        S04N0200.MdiParent = Me
        S04N0200.Show()
    End Sub
    '不合格品處理作業
    Private Sub S04N0300_Click(sender As Object, e As EventArgs) Handles S04N0300.Click
        Dim S04N0300 As New S04N0300

        S04N0300.MdiParent = Me
        S04N0300.Show()
    End Sub
#End Region
#Region "製程"
    '製造過程登錄
    Private Sub S05N0100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S05N0100.Click
        Dim S05N0100 As New S05N0100

        S05N0100.MdiParent = Me
        S05N0100.Show()
    End Sub
    '產量數據登錄
    Private Sub S05N0200_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles S05N0200.Click
        Dim S05N0200 As New S05N0200

        S05N0200.MdiParent = Me
        S05N0200.Show()
    End Sub
#End Region
#Region "產量統計"

#End Region
#Region "財務"
    '應收帳款統計
    Private Sub S06N0100_Click(sender As System.Object, e As System.EventArgs) Handles S06N0100.Click
        Dim S06N0100 As New S06N0100

        S06N0100.MdiParent = Me
        S06N0100.Show()
    End Sub
#End Region
#Region "視窗"
    Private Sub W01N0111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles W01N0111.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub W01N0112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles W01N0112.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub W01N0113_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles W01N0113.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
#End Region
#Region "說明"
    Private Sub H01N0110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H01N0110.Click
        '開啟更新程式並關閉主程式
        Shell(Application.StartupPath & "\SYS\Upgrade.exe", AppWinStyle.NormalFocus) : End
    End Sub
    Private Sub H01N0210_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H01N0210.Click
        Dim H01N0210 As New fmBuy

        H01N0210.MdiParent = Me
        H01N0210.Show()
    End Sub
    Private Sub H01N0310_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles H01N0310.Click
        Dim H01N0310 As New fmAbout

        H01N0310.MdiParent = Me
        H01N0310.Show()
    End Sub
#End Region
#End Region

#Region "副程式"
    '使用者功能權限內容
    Sub UsersPower(ByVal strUserID As String)
        Dim blnCheck As Boolean = False
        Dim objSystemID() As ToolStripMenuItem = {S01N0000, S01N0100, S01N0200, S01N0300, S01N0400, S01N0500, S01N0600, _
                                                  S02N0000, S02N0100, S02N0201, S02N0202, S02N0203, S02N0300, S02N0400, _
                                                  S03N0000, S03N0100, S03N0200, S03N0300, S03N9999, _
                                                  S04N0000, S04N0100, S04N0200, S04N0300, _
                                                  S05N0000, S05N0100, S05N0200, _
                                                  S06N0000, S06N0100, S06N0200, S06N0300, S06N0400, S06N0500, _
                                                  S99N0000, S99N0101}

        '開啟查詢
        For I As Integer = 0 To objSystemID.Length - 1 Step 1
            objSystemID(I).Enabled = IIf(dbDataCheck(DNS, "員工權限檔", "員工代號 = '" & strUserID & "' AND 子功能代碼 = '" & objSystemID(I).Name & "'") = True, True, False)
        Next


        Dim mnuItem As ToolStripMenuItem
        Dim submnuItem As ToolStripMenuItem
        Dim refMenuItem As New ToolStripMenuItem()
        Dim CtrlCount As Integer = 0

        For Each ctrl As ToolStripMenuItem In MenuStrip.Items
            CtrlCount = dbCount(DNS, "員工權限檔", "intCount", "員工代號 = '" & strUserID & "' AND 子功能代碼 like '" & ctrl.Name & "%'")
            If CtrlCount > 0 Then
                ctrl.Visible = True
            Else
                ctrl.Visible = False
            End If
            For Each subItem As Object In ctrl.DropDownItems
                If TypeOf subItem Is ToolStripMenuItem Then
                    mnuItem = DirectCast(subItem, ToolStripMenuItem)
                    mnuItem.Visible = IIf(dbDataCheck(DNS, "員工權限檔", "員工代號 = '" & strUserID & "' AND 子功能代碼 = '" & mnuItem.Name & "'") = True, True, False)
                    mnuItem.Enabled = True
                    For Each subItem1 As Object In mnuItem.DropDownItems
                        If TypeOf subItem1 Is ToolStripMenuItem Then
                            submnuItem = DirectCast(subItem1, ToolStripMenuItem)
                            submnuItem.Visible = IIf(dbDataCheck(DNS, "員工權限檔", "員工代號 = '" & strUserID & "' AND 子功能代碼 = '" & submnuItem.Name & "'") = True, True, False)
                            submnuItem.Enabled = True
                        End If
                    Next
                End If

            Next
        Next
    End Sub

    'Public Sub SetMenus()
    '    Dim mnuItem As ToolStripMenuItem
    '    Dim refMenuItem As New ToolStripMenuItem()

    '    '初始设置所有菜单不可见
    '    For Each ctrl As ToolStripMenuItem In MenuStrip.Items
    '        ctrl.Visible = False
    '        For Each subItem As Object In ctrl.DropDownItems
    '            If subItem.GetType = ToolStripMenuItem Then
    '                mnuItem = DirectCast(subItem, ToolStripMenuItem)
    '                mnuItem.Visible = False
    '            End If
    '        Next
    '    Next

    '    '取得相应用户对应的菜单项权限
    '    Dim sqlFunc As String = String.Format("select *** from *** ")
    '    Dim adp As New SqlDataAdapter(sqlFunc, conn)
    '    Dim ds As New DataSet()
    '    adp.Fill(ds)

    '    '设置菜单项的可见或可用性
    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        '遍历主菜单
    '        For Each ctrl As ToolStripMenuItem In mainMenu.Items
    '            If ctrl.Name.ToUpper().Trim() = dr(0).ToString().ToUpper().Trim() Then
    '                ctrl.Visible = True
    '                ctrl.Enabled = True
    '                Exit For
    '            End If

    '            '遍历子菜单
    '            For Each subItem As Object In ctrl.DropDownItems
    '                If subItem.[GetType]() = refMenuItem.[GetType]() Then
    '                    mnuItem = DirectCast(subItem, ToolStripMenuItem)
    '                    If mnuItem.Name.ToUpper().Trim() = dr(0).ToString().ToUpper().Trim() Then
    '                        mnuItem.Visible = True
    '                        mnuItem.Enabled = True
    '                        Exit For
    '                    End If
    '                End If
    '            Next
    '        Next
    '    Next
    'End Sub
#End Region



#Region "報表"
    '司機載貨明細表
    Private Sub R01N0001_Click(sender As System.Object, e As System.EventArgs) Handles R01N0001.Click
        Dim R01N0001 As New R01N0001

        R01N0001.MdiParent = Me
        R01N0001.Show()
    End Sub

    Private Sub R01N0002_Click(sender As System.Object, e As System.EventArgs) Handles R01N0002.Click
        Dim R01N0002 As New R01N0002

        R01N0002.MdiParent = Me
        R01N0002.Show()
    End Sub

    Private Sub R01N0003_Click(sender As System.Object, e As System.EventArgs) Handles R01N0003.Click
        Dim R01N0003 As New R01N0003

        R01N0003.MdiParent = Me
        R01N0003.Show()
    End Sub

    Private Sub R01N0004_Click(sender As System.Object, e As System.EventArgs) Handles R01N0004.Click
        Dim R01N0004 As New R01N0004

        R01N0004.MdiParent = Me
        R01N0004.Show()
    End Sub

    Private Sub R01N0005_Click(sender As System.Object, e As System.EventArgs) Handles R01N0005.Click
        Dim R01N0005 As New R01N0005

        R01N0005.MdiParent = Me
        R01N0005.Show()
    End Sub

    Private Sub R01N0006_Click(sender As System.Object, e As System.EventArgs) Handles R01N0006.Click
        Dim R01N0006 As New R01N0006

        R01N0006.MdiParent = Me
        R01N0006.Show()
    End Sub

    Private Sub R01N0007_Click(sender As System.Object, e As System.EventArgs) Handles R01N0007.Click
        Dim R01N0007 As New R01N0007

        R01N0007.MdiParent = Me
        R01N0007.Show()
    End Sub
#End Region





    Private Sub S06N0110_Click(sender As System.Object, e As System.EventArgs) Handles S06N0110.Click
        Dim S03N0390 As New S03N0390

        S03N0390.MdiParent = Me
        S03N0390.Show()
    End Sub

    Private Sub S06R0100_Click(sender As System.Object, e As System.EventArgs) Handles S06R0100.Click
        Dim S06R0100 As New S06R0100

        S06R0100.MdiParent = Me
        S06R0100.Show()
    End Sub

    Private Sub S06R0200_Click(sender As System.Object, e As System.EventArgs) Handles S06R0200.Click
        Dim S06R0200 As New S06R0200

        S06R0200.MdiParent = Me
        S06R0200.Show()
    End Sub

    Private Sub S06R0300_Click(sender As System.Object, e As System.EventArgs) Handles S06R0300.Click
        Dim S06R0300 As New S06R0300

        S06R0300.MdiParent = Me
        S06R0300.Show()
    End Sub


    Private Sub S06R0400_Click(sender As System.Object, e As System.EventArgs) Handles S06R0400.Click
        Dim S06R0400 As New S06R0400

        S06R0400.MdiParent = Me
        S06R0400.Show()
    End Sub

    Private Sub S06R0500_Click(sender As System.Object, e As System.EventArgs) Handles S06R0500.Click
        Dim S06R0500 As New S06R0500

        S06R0500.MdiParent = Me
        S06R0500.Show()
    End Sub

    Private Sub S03N9902_Click(sender As System.Object, e As System.EventArgs) Handles S03N9902.Click
        Dim S03N0390 As New S03N0390

        S03N0390.MdiParent = Me
        S03N0390.NoShowPrice = True
        S03N0390.Show()
    End Sub

    Private Sub S06R0600_Click(sender As System.Object, e As System.EventArgs) Handles S06R0600.Click
        Dim S06R0600 As New S06R0600

        S06R0600.MdiParent = Me
        S06R0600.Show()
    End Sub

    Private Sub S01N0700_Click(sender As System.Object, e As System.EventArgs) Handles S01N0700.Click
        Dim frmLevel12 As New frmLevel12

        frmLevel12.txtPage.Text = "S01N0700"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub


    Private Sub S03N0012_Click(sender As Object, e As EventArgs) Handles S03N0012.Click
        Dim frmLevel1 As New frmLevel1

        frmLevel1.txtPage.Text = "S03N0012"
        frmLevel1.MdiParent = Me
        frmLevel1.Show()
    End Sub

    Private Sub S99N0201_Click(sender As Object, e As EventArgs) Handles S99N0201.Click
        Dim S99N0201 As New S99N0201

        S99N0201.MdiParent = Me
        S99N0201.Show()
    End Sub


    Private Sub R01N008_Click(sender As Object, e As EventArgs) Handles R01N008.Click
        Dim R01N0008 As New R01N0008

        R01N0008.MdiParent = Me
        R01N0008.Show()
    End Sub

    Private Sub S03N0191_Click(sender As Object, e As EventArgs) Handles S03N0191.Click
        Dim S03N0191 As New S03N0191

        S03N0191.MdiParent = Me
        S03N0191.Show()
    End Sub

    Private Sub S04R0100_Click(sender As Object, e As EventArgs) Handles S04R0100.Click
        Dim S04R0100 As New S04R0100

        S04R0100.MdiParent = Me
        S04R0100.Show()
    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub S03N0400_Click(sender As Object, e As EventArgs) Handles S03N0400.Click
        Dim S03N0400 As New S03N0400

        S03N0400.MdiParent = Me
        S03N0400.Show()
    End Sub

    Private Sub S03N0500_Click(sender As Object, e As EventArgs) Handles S03N0500.Click
        Dim S03N0500 As New S03N0500

        S03N0500.MdiParent = Me
        S03N0500.Show()
    End Sub

    Private Sub S06R0700_Click(sender As Object, e As EventArgs) Handles S06R0700.Click
        Dim S06R0700 As New S06R0700

        S06R0700.MdiParent = Me
        S06R0700.Show()
    End Sub


    Private Sub S03N0410_Click(sender As Object, e As EventArgs) Handles S03N0410.Click
        Dim S03N0410 As New S03N0410

        S03N0410.MdiParent = Me
        S03N0410.Show()
    End Sub

    Private Sub S03N9901_Click(sender As Object, e As EventArgs) Handles S03N9901.Click

    End Sub

    Private Sub S03N9904_Click(sender As Object, e As EventArgs) Handles S03N9904.Click
        Dim S03N9904 As New S03N9904

        S03N9904.MdiParent = Me
        S03N9904.Show()
    End Sub

    Private Sub S03_Click(sender As Object, e As EventArgs) Handles S03.Click

    End Sub

    Private Sub S03N0013_Click(sender As Object, e As EventArgs) Handles S03N0013.Click
        Dim frmLevel12 As New frmLevel12
        frmLevel12.txtPage.Text = "S03N0011"
        frmLevel12.MdiParent = Me
        frmLevel12.Show()
    End Sub

    Private Sub R01N009_Click(sender As Object, e As EventArgs) Handles R01N009.Click
        Dim R01N0009 As New R01N0009

        R01N0009.MdiParent = Me
        R01N0009.Show()
    End Sub
End Class