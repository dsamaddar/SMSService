<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    Theme="CommonSkin" CodeFile="frmSMSReport.aspx.vb" Inherits="frmSMSReport" Title=".:SMS-Service:Reports:." %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlReportParameters" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="6">
                                <div class="widget-title">
                                    SMS Reports
                                </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Date From
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="InputTxtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateFrom">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="reqFldDateFrom" runat="server" ControlToValidate="txtDateFrom"
                                    Display="None" ErrorMessage="Require: From Date" ValidationGroup="Report"></asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="reqFldDateFrom_ValidatorCalloutExtender" runat="server"
                                    CloseImageUrl="~/Sources/images/valClose.png" CssClass="customCalloutStyle" Enabled="True"
                                    TargetControlID="reqFldDateFrom" WarningIconImageUrl="~/Sources/images/Valwarning.png">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                            <td>
                                Date To
                            </td>
                            <td>
                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="InputTxtBox"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtIssueDate_CalendarExtender" runat="server" Enabled="True"
                                    TargetControlID="txtDateTo">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:RequiredFieldValidator ID="reqFldDateTo" runat="server" ControlToValidate="txtDateTo"
                                    Display="None" ErrorMessage="Require: To Date" ValidationGroup="Report"></asp:RequiredFieldValidator>
                                <cc1:ValidatorCalloutExtender ID="reqFldIssueDate_ValidatorCalloutExtender" runat="server"
                                    CloseImageUrl="~/Sources/images/valClose.png" CssClass="customCalloutStyle" Enabled="True"
                                    TargetControlID="reqFldDateTo" WarningIconImageUrl="~/Sources/images/Valwarning.png">
                                </cc1:ValidatorCalloutExtender>
                            </td>
                            <td>
                                <asp:Button ID="btnProcessReport" runat="server" Text="Process Report" ValidationGroup="Report" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlSMSReport" runat="server" SkinID="pnlInner">
                    <div style="max-height: 250px; max-width: 100%; overflow: auto">
                        <asp:GridView ID="grdSMSReport" runat="server" CssClass="mGrid">
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
