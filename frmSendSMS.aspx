<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    Theme="CommonSkin" CodeFile="frmSendSMS.aspx.vb" Inherits="frmSendSMS" Title=".:SMS-Service:Send Pending SMS:." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlSendingSMS" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <div class="widget-title">
                                    Send Pending SMS
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div>
                                    <asp:GridView ID="grdPendingSMS" runat="server" AutoGenerateColumns="False" CssClass="mGrid">
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
                                            <asp:TemplateField HeaderText="CSMSID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUniqueID" runat="server" Text='<%# Bind("UniqueID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ReceiverName" HeaderText="Receiver" />
                                            <asp:TemplateField HeaderText="ReceiverNo">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblReceiverNo" runat="server" Text='<%# Bind("ReceiverNo") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SMSBody">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSMSBody" runat="server" Text='<%# Bind("SMSBody") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ReceiverNo" HeaderText="ReceiverNo" />
                                            <asp:BoundField DataField="EntryDate" HeaderText="EntryDate" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSendSMS" runat="server" Text="Send SMS"  OnClientClick="if ( !confirm('Are you sure you want to SEND NOW?')) return false;" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
