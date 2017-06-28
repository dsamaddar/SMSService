Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Net

Partial Class frmSMSSubmission
    Inherits System.Web.UI.Page

    Dim SMSData As New clsSMSHistory()

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

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "SMSSubmission~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If


        If Not IsPostBack Then

        End If
    End Sub

End Class
