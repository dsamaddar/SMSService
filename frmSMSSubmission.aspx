<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    Theme="CommonSkin" CodeFile="frmSMSSubmission.aspx.vb" Inherits="frmSMSSubmission"
    Title=".:SMS-Service:SMS Submission:." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type='text/javascript'>
    $('#<%= spnCharLeft.ClientID %>').css('display', 'none');
    var maxLimit = 450;
    $(document).ready(function () {
        $('#<%= txtMessageBody.ClientID %>').keyup(function () {
            var lengthCount = this.value.length;              
            if (lengthCount > maxLimit) {
                this.value = this.value.substring(0, maxLimit);
                var charactersLeft = maxLimit - lengthCount + 1;                   
            }
            else {                   
                var charactersLeft = maxLimit - lengthCount;                   
            }
            $('#<%= spnCharLeft.ClientID %>').css('display', 'block');
            $('#<%= spnCharLeft.ClientID %>').text(charactersLeft + ' Characters left');
        });
    });
    </script>

    <table style="width: 100%">
        <tr>
            <td>
                <asp:Panel ID="pnlSMSSubmission" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <div class="widget-title">
                                    SMS Submission</div>
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
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Receiver Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtReceiverName" runat="server" CssClass="InputTxtBox" 
                                    Width="200px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Mobile No
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="InputTxtBox" 
                                    Width="120px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Label ID="spnCharLeft" runat="server" Style="color: Red"></asp:Label>
                                
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                Message Body
                            </td>
                            <td>
                                <asp:TextBox ID="txtMessageBody" runat="server" CssClass="InputTxtBox" 
                                    Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSubmitSMS" runat="server" Text="Submit SMS" />
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
            </td>
        </tr>
    </table>
</asp:Content>
