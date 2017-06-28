
Partial Class SMSMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub drpBranchSelection_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpBranchSelection.SelectedIndexChanged
        Session("BRANCH") = drpBranchSelection.SelectedValue
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                lblEmpLoggedInUser.Text = "Welcome " + Session("EmployeeName") + " ! "
                Session("BRANCH") = drpBranchSelection.SelectedValue

                Dim mnu As New Menu
                Dim MenuIDs As String

                mnu = Me.FindControl("mnuControl")
                MenuIDs = Session("PermittedMenus")

                mnu.Items(0).Enabled = IIf(InStr(MenuIDs, "ClientVerification~"), True, False)
                mnu.Items(1).Enabled = IIf(InStr(MenuIDs, "SMSSubmission~"), True, False)
                mnu.Items(1).ChildItems(0).Enabled = IIf(InStr(MenuIDs, "SMSSubClient~"), True, False)
                mnu.Items(1).ChildItems(1).Enabled = IIf(InStr(MenuIDs, "SMSSubBulk~"), True, False)
                mnu.Items(2).Enabled = IIf(InStr(MenuIDs, "SMSApproval~"), True, False)
                mnu.Items(3).Enabled = IIf(InStr(MenuIDs, "SendSMS~"), True, False)
                mnu.Items(4).Enabled = IIf(InStr(MenuIDs, "Administration~"), True, False)
                mnu.Items(4).ChildItems(1).Enabled = IIf(InStr(MenuIDs, "RoleMgt~"), True, False)
                mnu.Items(4).ChildItems(2).Enabled = IIf(InStr(MenuIDs, "RoleWiseMnuPerm~"), True, False)
                mnu.Items(4).ChildItems(3).Enabled = IIf(InStr(MenuIDs, "UsrRoleMgt~"), True, False)
                mnu.Items(5).Enabled = IIf(InStr(MenuIDs, "Report~"), True, False)

            Catch ex As Exception
                MessageBox(ex.Message)
            End Try
        End If

    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
        Try
            Dim lbl As New System.Web.UI.WebControls.Label
            lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                       & "window.alert(" & "'" & strMsg & "'" & ")</script>"
            Page.Controls.Add(lbl)
        Catch ex As Exception

        End Try
    End Sub

End Class

