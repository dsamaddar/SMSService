Imports System.Data.SqlClient
Imports System.IO

Partial Class frmSMSSubmissionClient
    Inherits System.Web.UI.Page

    Dim ClientVerificationData As New clsClientVerification()
    Dim SMSData As New clsSMSHistory()

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
        Dim lblFirstName, lblVerifiedMobileNo As New Label
        Try
            lblFirstName = grdAgreements.SelectedRow.FindControl("lblFirstName")
            lblVerifiedMobileNo = grdAgreements.SelectedRow.FindControl("lblVerifiedMobileNo")

            txtReceiverName.Text = lblFirstName.Text
            txtMobileNo.Text = lblVerifiedMobileNo.Text
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnSubmitSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmitSMS.Click
        Dim SMS As New clsSMSHistory()

        Try
            SMS.UniqueID = Now.Ticks.ToString()
            SMS.ReceiverName = txtReceiverName.Text
            SMS.ReceiverNo = txtMobileNo.Text
            SMS.SMSBody = txtMessageBody.Text
            SMS.EntryBy = Session("LoginUserID")

            Dim check As Integer = SMSData.fnInsertSMSHistory(SMS)

            If check = 1 Then
                MessageBox("SMS Submitted for Approval")
                ClearForm()
            Else
                MessageBox("Error Occured.")
            End If
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtMessageBody.Text = ""
        txtMobileNo.Text = ""
        txtReceiverName.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "SMSSubClient~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub drpMessageFormat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpMessageFormat.SelectedIndexChanged

        Dim lblFirstName, lblAgrNo, lblGrossPrincipal, lblInterestRate, lblPeriod As New Label

        If grdAgreements.SelectedIndex = -1 Then
            MessageBox("Select An Agreement First.")
            Exit Sub
        End If

        lblFirstName = grdAgreements.SelectedRow.FindControl("lblFirstName")
        lblAgrNo = grdAgreements.SelectedRow.FindControl("lblAgrNo")
        lblGrossPrincipal = grdAgreements.SelectedRow.FindControl("lblGrossPrincipal")
        lblInterestRate = grdAgreements.SelectedRow.FindControl("lblInterestRate")
        lblPeriod = grdAgreements.SelectedRow.FindControl("lblPeriod")

        If drpMessageFormat.SelectedValue = "Welcome" Then
            txtMessageBody.Text = "Thank You for Choosing Reliance Finance Limited. Your Account (TDR#" & lblAgrNo.Text & ") of " & lblFirstName.Text & " TK. " & String.Format("{0:#,#.00}", lblGrossPrincipal.Text) & " @ " & lblInterestRate.Text & "% for " & lblPeriod.Text & " Months has been opened. For any query Please Contact 02-9570509 (10AM-6PM)."
        ElseIf drpMessageFormat.SelectedValue = "Renewal" Then
            txtMessageBody.Text = "Congratulation"
        Else
            MessageBox("Select Another Option.")
        End If

    End Sub
End Class
