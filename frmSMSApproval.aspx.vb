
Partial Class frmSMSApproval
    Inherits System.Web.UI.Page

    Dim SMSHistoryData As New clsSMSHistory()

    Protected Sub btnApproveSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApproveSMS.Click
        Dim SMS As New clsSMSHistory()
        Dim chkSelect As New CheckBox
        Dim lblSMSHistoryID As New Label
        Dim check As Integer = 0

        For Each row As GridViewRow In grdPendingSMS.Rows
            chkSelect = row.FindControl("chkSelect")
            lblSMSHistoryID = row.FindControl("lblSMSHistoryID")
            If chkSelect.Checked = True Then
                SMS.SMSHistoryID = lblSMSHistoryID.Text
                SMS.ApprovedBy = Session("LoginUserID")
                check = SMSHistoryData.fnApproveSMS(SMS)
                If check = 0 Then
                    MessageBox("SMS Approval Failed: " & lblSMSHistoryID.Text)
                End If
            End If
        Next

        GetPendingSMSForApproval()
    End Sub

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnRejectSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRejectSMS.Click
        Dim SMS As New clsSMSHistory()
        Dim chkSelect As New CheckBox
        Dim lblSMSHistoryID As New Label
        Dim check As Integer = 0

        For Each row As GridViewRow In grdPendingSMS.Rows
            chkSelect = row.FindControl("chkSelect")
            lblSMSHistoryID = row.FindControl("lblSMSHistoryID")
            If chkSelect.Checked = True Then
                SMS.SMSHistoryID = lblSMSHistoryID.Text
                SMS.RejectedBy = Session("LoginUserID")
                check = SMSHistoryData.fnRejectSMS(SMS)
                If check = 0 Then
                    MessageBox("SMS Rejection Failed: " & lblSMSHistoryID.Text)
                End If
            End If
        Next

        GetPendingSMSForApproval()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "SMSApproval~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then
            GetPendingSMSForApproval()
            If grdPendingSMS.Rows.Count = 0 Then
                btnApproveSMS.Enabled = False
                btnRejectSMS.Enabled = False
            End If
        End If
    End Sub

    Protected Sub GetPendingSMSForApproval()
        grdPendingSMS.DataSource = SMSHistoryData.fnGetPendingSMSForApproval()
        grdPendingSMS.DataBind()
    End Sub

    Protected Sub chkSelectAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim chkSelect, chkSelectAll As New CheckBox

        chkSelectAll = grdPendingSMS.HeaderRow.FindControl("chkSelectAll")

        If chkSelectAll.Checked = True Then
            For Each row In grdPendingSMS.Rows
                chkSelect = row.FindControl("chkSelect")
                chkSelect.Checked = True
            Next
        Else
            For Each row In grdPendingSMS.Rows
                chkSelect = row.FindControl("chkSelect")
                chkSelect.Checked = False
            Next
        End If

    End Sub

End Class
