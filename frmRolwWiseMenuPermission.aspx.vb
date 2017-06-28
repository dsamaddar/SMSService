
Partial Class frmRolwWiseMenuPermission
    Inherits System.Web.UI.Page

    Dim MenuData As New clsMenuDataAccess()
    Dim RoleData As New clsRoleDataAccess()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "RoleWiseMnuPerm~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then
            ShowRoleList()
            ShowMenuList(grdAdminMenu, "Admin")
        End If
    End Sub

    Protected Sub ShowMenuList(ByVal grd As GridView, ByVal MenuGroupID As String)
        grd.DataSource = MenuData.fnGetMenuListByGroup(MenuGroupID)
        grd.DataBind()
    End Sub

    Protected Sub ShowRoleList()
        drpRoleList.DataTextField = "RoleName"
        drpRoleList.DataValueField = "RoleID"
        drpRoleList.DataSource = RoleData.fnGetRoleList()
        drpRoleList.DataBind()

        Dim A As New ListItem()

        A.Text = "N\A"
        A.Value = "N\A"

        drpRoleList.Items.Insert(0, A)
    End Sub

    Protected Sub GetMenuPermission(ByVal MenuIDList As String)

        Dim chkSelectAdminMenu, chkSelectRequisitionMenu, chkSelectProcurementMenu, chkSelectBalanceTransferMenu, chkSelectReportMenu, chkSelectAcceptRequisitionMenu As New System.Web.UI.WebControls.CheckBox()
        Dim lblAdminMenuID, lblRequisitionMenuID, lblProcurementMenuID, lblBalanceTransferMenuID, lblReportMenuID, lblAcceptRequisitionMenuID As New System.Web.UI.WebControls.Label()


        For Each rw As GridViewRow In grdAdminMenu.Rows
            lblAdminMenuID = rw.FindControl("lblAdminMenuID")
            If MenuIDList.Contains(lblAdminMenuID.Text) Then
                chkSelectAdminMenu = rw.FindControl("chkSelectAdminMenu")
                chkSelectAdminMenu.Checked = True
                rw.ForeColor = Drawing.Color.Green
                rw.Font.Bold = True
            End If
        Next
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click


        If drpRoleList.SelectedValue = "N\A" Then
            MessageBox("Select Proper Role")
            Exit Sub
        End If

        Dim MenuIDList As String = ""

        Dim chkSelectAdminMenu, chkSelectRequisitionMenu, chkSelectProcurementMenu, chkSelectBalanceTransferMenu, chkSelectReportMenu, chkSelectAcceptRequisitionMenu As New System.Web.UI.WebControls.CheckBox()
        Dim lblAdminMenuID, lblRequisitionMenuID, lblProcurementMenuID, lblBalanceTransferMenuID, lblReportMenuID, lblAcceptRequisitionMenuID As New System.Web.UI.WebControls.Label()

        For Each rw As GridViewRow In grdAdminMenu.Rows
            chkSelectAdminMenu = rw.FindControl("chkSelectAdminMenu")

            If chkSelectAdminMenu.Checked = True Then
                lblAdminMenuID = rw.FindControl("lblAdminMenuID")
                MenuIDList += lblAdminMenuID.Text & "~"
            End If
        Next

        Dim Role As New clsRole()

        Role.RoleID = drpRoleList.SelectedValue
        Role.MenuIDList = MenuIDList
        Role.LastUpdatedBy = Session("LoginUserID")

        Dim Check As Integer = RoleData.fnUpdateRolePermission(Role)

        If Check = 1 Then
            MessageBox("Successfully Inserted.")
            'Response.Redirect("frmRolwWiseMenuPermission.aspx")
        Else
            MessageBox("Error Found.")
        End If

    End Sub

    Protected Sub ClearMenuSelection()

        Dim chkSelectAdminMenu, chkSelectRequisitionMenu, chkSelectProcurementMenu, chkSelectBalanceTransferMenu, chkSelectReportMenu, chkSelectAcceptRequisitionMenu As New System.Web.UI.WebControls.CheckBox()
        Dim lblAdminMenuID, lblRequisitionMenuID, lblProcurementMenuID, lblBalanceTransferMenuID, lblReportMenuID, lblAcceptRequisitionMenuID As New System.Web.UI.WebControls.Label()

        For Each rw As GridViewRow In grdAdminMenu.Rows
            chkSelectAdminMenu = rw.FindControl("chkSelectAdminMenu")
            If chkSelectAdminMenu.Checked = True Then
                chkSelectAdminMenu.Checked = False
                rw.ForeColor = Drawing.Color.Black
                rw.Font.Bold = False
            End If
        Next
    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub drpRoleList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpRoleList.SelectedIndexChanged
        ClearMenuSelection()
        If drpRoleList.SelectedValue <> "N\A" Then

            Dim MenuIDList As String = RoleData.fnGetRoleWiseMenuIDs(drpRoleList.SelectedValue)
            GetMenuPermission(MenuIDList)
        Else

            MessageBox("Select Role Properly.")
            Exit Sub
        End If
    End Sub

End Class
