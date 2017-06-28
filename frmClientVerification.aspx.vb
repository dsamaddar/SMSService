Imports System.Data.SqlClient
Imports System.IO

Partial Class frmClientVerification
    Inherits System.Web.UI.Page

    Dim ClientVerificationData As New clsClientVerification()

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        grdAgreements.DataSource = ClientVerificationData.fnSearchForMobileVerificaiton(txtSearchText.Text, GetConnection())
        grdAgreements.DataBind()
    End Sub

    Protected Function GetConnection() As SqlConnection
        Dim drpBranchSelection As DropDownList = Master.FindControl("drpBranchSelection")

        Dim con As SqlConnection

        If drpBranchSelection.SelectedValue = "HOCon" Then
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("HOCon").ConnectionString)
        ElseIf drpBranchSelection.SelectedValue = "AgrabadCon" Then
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("AgrabadCon").ConnectionString)
        ElseIf drpBranchSelection.SelectedValue = "DhanmondiCon" Then
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("DhanmondiCon").ConnectionString)
        ElseIf drpBranchSelection.SelectedValue = "UttaraCon" Then
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("UttaraCon").ConnectionString)
        ElseIf drpBranchSelection.SelectedValue = "GECCon" Then
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("GECCon").ConnectionString)
        Else
            con = New SqlConnection(ConfigurationManager.ConnectionStrings("BEFTNConnectionString").ConnectionString)
        End If

        Return con
    End Function

    Protected Sub grdAgreements_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAgreements.SelectedIndexChanged
        Dim lblFirstName, lblMobile, lblAgrNo, lblVerifiedMobileNo As New Label

        lblFirstName = grdAgreements.SelectedRow.FindControl("lblFirstName")
        lblMobile = grdAgreements.SelectedRow.FindControl("lblMobile")
        lblAgrNo = grdAgreements.SelectedRow.FindControl("lblAgrNo")
        lblVerifiedMobileNo = grdAgreements.SelectedRow.FindControl("lblVerifiedMobileNo")

        lblClientName.Text = lblFirstName.Text
        lblAgreementNo.Text = lblAgrNo.Text
        lblMobile.Text = lblMobileNo.Text
        If lblVerifiedMobileNo.Text = "" Then
            txtVerifiedMobileNo.Text = lblMobile.Text
        Else
            txtVerifiedMobileNo.Text = lblVerifiedMobileNo.Text
        End If

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim ClientVerification As New clsClientVerification()

        If grdAgreements.SelectedIndex = -1 Then
            MessageBox("No Agreement Selected.")
            Exit Sub
        End If

        If lblAgreementNo.Text = "" Then
            MessageBox("No Agreement Selected.")
            Exit Sub
        End If

        If txtVerifiedMobileNo.Text = "" Then
            MessageBox("Verified Mobile No Empty.")
            Exit Sub
        End If

        Dim check As Integer = ClientVerification.fnUpdateVerifiedMobileNo(lblAgreementNo.Text, txtVerifiedMobileNo.Text, GetConnection())



        If check = 1 Then
            MessageBox("Verified Mobile No Updated.")
            CleanForm()
        Else
            MessageBox("Update Failed.")
        End If

    End Sub

    Protected Sub CleanForm()
        grdAgreements.SelectedIndex = -1
        lblAgreementNo.Text = ""
        lblClientName.Text = ""
        lblMobileNo.Text = ""
        txtVerifiedMobileNo.Text = ""
    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim MenuIDs As String

            MenuIDs = Session("PermittedMenus")

            If InStr(MenuIDs, "ClientVerification~") = 0 Then
                Response.Redirect("~\frmSMSLogin.aspx")
            End If
        End If
    End Sub

End Class
