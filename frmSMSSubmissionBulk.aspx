<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    Theme="CommonSkin" CodeFile="frmSMSSubmissionBulk.aspx.vb" Inherits="frmSMSSubmissionBulk"
    Title=".:SMS-Service:SMS Submission Bulk:." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlUploadBulkSMS" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="3">
                                <div class="widget-title">
                                    Upload Bulk SMS
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:HyperLink ID="hplnkBulkSMSFormat" runat="server" NavigateUrl="~/Uploads/bulksms.xls">Bulk SMS Format</asp:HyperLink>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td>
                                <asp:FileUpload ID="flupFile" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnUpload" runat="server" Text="Upload" />
                                &nbsp;<asp:Button ID="btnViewFile" runat="server" Text="View File" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnProcessSMS" runat="server" Text="Process SMS" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlUploadedFile" runat="server" SkinID="pnlInner">
                    <div style="max-height: 300px; max-width: 100%; overflow: auto">
                        <asp:GridView ID="grdUploadedFile" runat="server" CssClass="mGrid" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="receivername">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreceivername" runat="server" Text='<%# Bind("receivername") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="receiverno">
                                    <ItemTemplate>
                                        <asp:Label ID="lblreceiverno" runat="server" Text='<%# Bind("receiverno") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="smsbody">
                                    <ItemTemplate>
                                        <asp:Label ID="lblsmsbody" runat="server" Text='<%# Bind("smsbody") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
