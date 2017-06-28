Imports System.Net
Imports System.Xml
Imports System.IO

Partial Class frmSendSMS
    Inherits System.Web.UI.Page

    Dim SMSHistoryData As New clsSMSHistory()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "SendSMS~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then
            GetPendingSMSForSending()
        End If
    End Sub

    Protected Sub GetPendingSMSForSending()
        grdPendingSMS.DataSource = SMSHistoryData.fnGetPendingSMSForSending()
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

    Protected Sub btnSendSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendSMS.Click
        Dim SMS As New clsSMSHistory()
        Dim chkSelect As New CheckBox
        Dim lblUniqueID, lblReceiverNo, lblSMSBody As New Label
        Dim check As Integer = 0
        Dim Counter As Integer = 0
        Dim xmlString As String = ""
        Try
            For Each row As GridViewRow In grdPendingSMS.Rows
                chkSelect = row.FindControl("chkSelect")
                If chkSelect.Checked = True Then
                    lblUniqueID = row.FindControl("lblUniqueID")
                    lblReceiverNo = row.FindControl("lblReceiverNo")
                    lblSMSBody = row.FindControl("lblSMSBody")

                    If Len(lblReceiverNo.Text) = 13 Then
                        xmlString = SendSMS(lblUniqueID.Text, lblReceiverNo.Text, lblSMSBody.Text)
                        SMS = ParseXML(xmlString)
                        SMS.UniqueID = lblUniqueID.Text
                        If SMS.LOGIN = "SUCCESSFULL" And Len(SMS.ReferenceNo) > 1 Then
                            check = SMSHistoryData.fnSMSSentConfirmation(SMS)
                            Counter += 1
                        End If
                    End If

                End If
            Next

            MessageBox("Total : " & Counter.ToString() & " SMS Sent")

            GetPendingSMSForSending()
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try
    End Sub

    Private Function SendSMS(ByVal CSMSID As String, ByVal ReceiverNo As String, ByVal SMSBody As String) As String
        Dim SMS As New clsSMSHistory()
        Dim sid As [String] = "companyname"
        Dim user As [String] = "username"
        Dim pass As [String] = "yourpass"
        Dim URI As [String] = "api-url"
        'Dim myParameters As [String] = "user=" & user & "&pass=" & pass & "&sms[0][0]=88***********&sms[0][1]=" & System.Web.HttpUtility.UrlEncode("Test SMS1" & vbLf & "Test SMS2" & vbLf & "Test SMS API3") & "&sms[0][2]=" & "1234567890" & "&sms[1][0]=88***********&sms[1][1]=" & System.Web.HttpUtility.UrlEncode("TESTSMS2" & vbLf & "TESTSMS3") & "&sms[1][2]=" & "1234567890" & "&sid=" & sid
        Dim myParameters As [String] = "user=" & user & "&pass=" & pass & "&sms[0][0]=" & ReceiverNo & "&sms[0][1]=" & SMSBody & "&sms[0][2]=" & CSMSID & "&sid=" & sid
        Using wc As New WebClient()
            wc.Headers(HttpRequestHeader.ContentType) = "application/x-www-form-urlencoded"
            Dim HtmlResult As String = wc.UploadString(URI, myParameters)
            Return HtmlResult
        End Using
    End Function

    Private Function ParseXML(ByVal xmlString As String) As clsSMSHistory
        Try
            Dim SMS As New clsSMSHistory()

            Using reader As XmlReader = XmlReader.Create(New StringReader(xmlString))
                reader.ReadToFollowing("LOGIN")
                SMS.LOGIN = reader.ReadElementContentAsString()
                reader.ReadToFollowing("REFERENCEID")
                SMS.ReferenceNo = reader.ReadElementContentAsString()
            End Using
            Return SMS
        Catch ex As Exception
            MessageBox(ex.Message)
            Return Nothing
        End Try
    End Function

    Private Sub MessageBox(ByVal strMsg As String)
        Dim lbl As New System.Web.UI.WebControls.Label
        lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                   & "window.alert(" & "'" & strMsg & "'" & ")</script>"
        Page.Controls.Add(lbl)
    End Sub

End Class
