<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="frmHome.aspx.cs" Inherits="frmHome" Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <div>
<center>
    <br />
    <asp:Label ID="lblHead" runat="server" Text="New Policies" 
        style="font-weight: 700; text-decoration: underline; color: #5D7B9D; font-size: large"></asp:Label>
    <br />
    <br />
    <table>
    <tr>
    <td>
    <asp:GridView ID="gvPolicies" runat="server" AllowPaging="True" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" onpageindexchanging="gvPolicies_PageIndexChanging" 
            onrowcommand="gvPolicies_RowCommand" PageSize="5">
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
    <asp:TemplateField HeaderText="PolicyName">
    <ItemTemplate>
                                                    <asp:Label ID="lblPolName" runat="server" Text='<%#Eval("PolicyName")%>'></asp:Label>
                                                </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="CompanyName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LaunchDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("LaunchDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EndDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("EndDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Terms&Conditions">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkTerms" runat="server" Text="Terms&Conditions" CommandArgument='<%#Eval("PolicyId") %>' CommandName="Terms" ></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </td>
        </tr>
        <tr>
        <td>
        <asp:Label ID="lblMsg" runat="server"  ForeColor="red"></asp:Label>
        </td>
        </tr>
        <tr>
        <td>
        </td>
        </tr>
        </table>
    
</center>
</div>

</asp:Content>

