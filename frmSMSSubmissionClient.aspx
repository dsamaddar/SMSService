<%@ Page Language="VB" MasterPageFile="~/SMSMaster.master" AutoEventWireup="false"
    Theme="CommonSkin" CodeFile="frmSMSSubmissionClient.aspx.vb" Inherits="frmSMSSubmissionClient"
    Title=".:SMS-Service:SMS Submission Client:." %>

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

    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Panel ID="pnlClientVerification" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="4">
                                <div class="widget-title">
                                    Client SMS Submission</div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20px">
                            </td>
                            <td style="width: 250px">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
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
                                Search Client By Name/Agreement No/Mobile No/Address
                            </td>
                            <td>
                                <asp:TextBox ID="txtSearchText" runat="server" CssClass="InputTxtBox" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" />
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
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlAgreements" runat="server" SkinID="pnlInner">
                    <div style="max-height: 250px; max-width: 100%; overflow: auto">
                        <asp:GridView ID="grdAgreements" runat="server" CssClass="mGrid" AutoGenerateColumns="False">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="CustomerID" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Agr.Status">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("AgreementStatus") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Agr.No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAgrNo" runat="server" Text='<%# Bind("AgreementNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product">
                                    <ItemTemplate>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mobile" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" runat="server" Text='<%# Bind("Mobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Person" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("cpFirstName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Phone" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("cpPhone") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact Mobile" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("cpMobile") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="cpAddress1" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("cpAddress1") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ConcernedStuff" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("ConcernedStuff") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ConcernedDepartment" HeaderText="ConcernedDepartment"
                                    Visible="False" />
                                <asp:TemplateField HeaderText="GrossPrincipal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossPrincipal" runat="server" Text='<%# Bind("GrossPrincipal","{0:N2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InterestRate">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInterestRate" runat="server" Text='<%# Bind("InterestRate","{0:N2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPeriod" runat="server" Text='<%# Bind("Period") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="VerifiedMobileNo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVerifiedMobileNo" runat="server" Text='<%# Bind("VerifiedMobileNo") %>'></asp:Label>
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
                <asp:Panel ID="pnlSMSSubmission" runat="server" SkinID="pnlInner">
                    <table style="width: 100%;">
                        <tr>
                            <td colspan="6">
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
                                <asp:TextBox ID="txtReceiverName" runat="server" CssClass="InputTxtBox" Width="200px"></asp:TextBox>
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
                                Mobile No
                            </td>
                            <td>
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="InputTxtBox" Width="120px"></asp:TextBox>
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
                            </td>
                            <td>
                                <asp:Label ID="spnCharLeft" runat="server" Style="color: Red"></asp:Label>
                            </td>
                            <td>
                                Select Message Format
                            </td>
                            <td>
                                <asp:DropDownList ID="drpMessageFormat" runat="server" AutoPostBack="True" Width="150px">
                                    <asp:ListItem Value="SelectOption">-- Select Option --</asp:ListItem>
                                    <asp:ListItem Value="Welcome">Welcome &amp; Product Information Message</asp:ListItem>
                                    <asp:ListItem Value="Renewal">Renewal Message</asp:ListItem>
                                </asp:DropDownList>
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
                                <asp:TextBox ID="txtMessageBody" runat="server" CssClass="InputTxtBox" Height="100px"
                                    TextMode="MultiLine" Width="350px"></asp:TextBox>
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
                            </td>
                            <td>
                                <asp:Button ID="btnSubmitSMS" runat="server" Text="Submit SMS" />
                            </td>
                            <td>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
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
