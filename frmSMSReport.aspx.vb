
Partial Class frmSMSReport
    Inherits System.Web.UI.Page

    Dim SMSData As New clsSMSHistory()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "Report~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub btnProcessReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcessReport.Click
        Try
            grdSMSReport.DataSource = SMSData.fnGetSMSReport(Convert.ToDateTime(txtDateFrom.Text), Convert.ToDateTime(txtDateTo.Text))
            grdSMSReport.DataBind()
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

End Class
