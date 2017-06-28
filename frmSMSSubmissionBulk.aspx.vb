
Partial Class frmSMSSubmissionBulk
    Inherits System.Web.UI.Page

    Dim SMSData As New clsSMSHistory()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MenuIDs As String

        MenuIDs = Session("PermittedMenus")

        If InStr(MenuIDs, "SMSSubBulk~") = 0 Then
            Response.Redirect("~\frmSMSLogin.aspx")
        End If

        If Not IsPostBack Then
            btnProcessSMS.Enabled = False
        End If
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            Dim folder As String = ""
            Dim Title As String = ""
            Dim DocExt As String = ""
            Dim DocFullName As String = ""
            Dim DocPrefix As String = ""
            Dim FileSize As Integer = 0
            Dim DocFileName As String = ""

            If flupFile.HasFile Then

                folder = "\\VSRVREFLAPP\Uploads$\"
                FileSize = flupFile.PostedFile.ContentLength()
                If FileSize > 4194304 Then
                    MessageBox("File size should be within 4MB")
                    Exit Sub
                End If

                DocExt = System.IO.Path.GetExtension(flupFile.FileName)
                DocFileName = "SMS_" & DateTime.Now.ToString("ddMMyyHHmmss") & DocExt
                DocFullName = folder & DocFileName
                Session("UploadedFile") = DocFileName
                flupFile.SaveAs(DocFullName)
                MessageBox("Upload Complete.")
            Else
                MessageBox("Select A Document To Upload.")
                Exit Sub
            End If

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

    Protected Sub btnProcessSMS_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProcessSMS.Click
        Dim SMS As New clsSMSHistory()
        Dim lblreceivername, lblreceiverno, lblsmsbody As New Label
        Dim PositiveCounter As Integer = 0
        Dim NegativeCounter As Integer = 0
        Dim NotSubmittedSMS As String = ""

        Try
            For Each row As GridViewRow In grdUploadedFile.Rows
                lblreceivername = row.FindControl("lblreceivername")
                lblreceiverno = row.FindControl("lblreceiverno")
                lblsmsbody = row.FindControl("lblsmsbody")

                SMS.UniqueID = Now.Ticks.ToString()
                SMS.ReceiverName = lblreceivername.Text
                SMS.ReceiverNo = lblreceiverno.Text
                SMS.SMSBody = lblsmsbody.Text
                SMS.EntryBy = Session("LoginUserID")

                If Len(lblreceiverno.Text) = 13 Then
                    Dim check As Integer = SMSData.fnInsertSMSHistory(SMS)

                    If check = 1 Then
                        PositiveCounter += 1
                    Else
                        NegativeCounter += 1
                        NotSubmittedSMS = NotSubmittedSMS & "," & lblreceiverno.Text
                    End If
                Else

                End If
            Next

            MessageBox("" & PositiveCounter.ToString() & " SMS Submitted for Approval")
            If NegativeCounter = 0 Then
                MessageBox("" & NegativeCounter.ToString() & " SMS Error Occured." & NotSubmittedSMS)
            End If
            ClearForm()

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub

    Protected Sub ClearForm()
        Session("UploadedFile") = ""
        grdUploadedFile.DataSource = ""
        grdUploadedFile.DataBind()
    End Sub

    Protected Sub btnViewFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewFile.Click
        Try
            'Read XL to Gridview
            Dim MyConnection As System.Data.OleDb.OleDbConnection
            Dim DtSet As New System.Data.DataSet
            Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
            MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='\\VSRVREFLAPP\Uploads$\" & Session("UploadedFile") & "';Extended Properties='Excel 8.0;HDR=Yes;'")
            MyConnection.Open()
            MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [SMS$]", MyConnection)
            MyCommand.TableMappings.Add("Table", "reflbd.com")
            MyCommand.Fill(DtSet)
            grdUploadedFile.DataSource = DtSet.Tables(0)
            grdUploadedFile.DataBind()
            MyConnection.Close()
            btnProcessSMS.Enabled = True
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

    End Sub

End Class
