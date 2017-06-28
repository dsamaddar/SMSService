<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    CodeFile="frmSMSApproval.aspx.vb" Inherits="frmSMSApproval" Title=".:SMS-Service:Approval:." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlSMSApproval" runat="server">
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="widget-title">
                                    Pending SMS-Approval
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="max-height: 250px; max-width: 100%; overflow: auto">
                                    <asp:GridView ID="grdPendingSMS" runat="server" CssClass="mGrid" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SMSHistoryID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSMSHistoryID" runat="server" Text='<%# Bind("SMSHistoryID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ReceiverName" HeaderText="Receiver" />
                                            <asp:BoundField DataField="ReceiverNo" HeaderText="ReceiverNo" />
                                            <asp:BoundField DataField="SMSBody" HeaderText="SMSBody" />
                                            <asp:BoundField DataField="EntryBy" HeaderText="EntryBy" />
                                            <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApproveSMS" runat="server" Text="Approve SMS" OnClientClick="if ( !confirm('Are you sure you want to Approve?')) return false;" />
                &nbsp;<asp:Button ID="btnRejectSMS" runat="server" Text="Reject SMS" OnClientClick="if ( !confirm('Are you sure you want to Reject?')) return false;" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
