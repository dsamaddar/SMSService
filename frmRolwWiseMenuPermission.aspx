<%@ Page Language="VB" Theme="CommonSkin"  MasterPageFile="SMSMaster.master" AutoEventWireup="false" CodeFile="frmRolwWiseMenuPermission.aspx.vb" Inherits="frmRolwWiseMenuPermission" title=".:SMS-Service:Role Wise Menu Permission:." %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr align="center" >
            <td>
                <asp:Panel ID="pnlAvailableProfile" runat="server" Width="100%" 
                    SkinID="pnlInner" >
                    <table style="width:100%;">
                        <tr>
                            <td colspan="4">
                                <div class="widgettitle">Role Wise Menu Permission</div>
                            </td>
                        </tr>
                        <tr align="left" >
                            <td style="width:20px">
                                &nbsp;</td>
                            <td  style="width:150px">
                                &nbsp;</td>
                            <td style="width:230px" >
                                &nbsp;</td>
                            <td  >
                                &nbsp;</td>
                        </tr>
                        <tr  align="left" >
                            <td>
                                &nbsp;</td>
                            <td class="label">
                                Select Role</td>
                            <td>
                                <asp:DropDownList ID="drpRoleList" runat="server" CssClass="InputTxtBox" 
                                    Width="200px" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" CssClass="styled-button-1" 
                                    Text="Save Changes" />
                            </td>
                        </tr>
                        <tr align="left" >
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr align="center" >
            <td>
                <asp:Panel ID="pnlMenuPermission" runat="server" Width="100%"  SkinID="pnlInner" >
                    <table style="width:100%;">
                        <tr>
                            <td class="label">
                                All Menu List</td>
                        </tr>
                        <tr>
                            <td valign="top" >
                                <asp:GridView ID="grdAdminMenu" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="mGrid">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSelectAdminMenu" runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MenuID" Visible="False">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAdminMenuID" runat="server" Text='<%# Bind("MenuID") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("MenuID") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MenuName">
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("MenuName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("MenuName") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

