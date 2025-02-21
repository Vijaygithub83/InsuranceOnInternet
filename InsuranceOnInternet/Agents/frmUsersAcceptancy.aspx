<%@ Page Language="C#" MasterPageFile="~/Agents/AgentsMasterPage.master" AutoEventWireup="true" CodeFile="frmUsersAcceptancy.aspx.cs" Inherits="Admin_frmUsersAcceptancy" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>

<br />
<br />
<asp:Label ID="lblHead" runat="server" Text="Customers Acceptancy Form" 
        style="color: #663300; font-weight: 700; font-size: medium; text-decoration: underline"></asp:Label>

<br />
<br />
<asp:Button ID="btnShow" runat="server" Text="Show Registered Customers" 
        onclick="btnShow_Click" />
<br />
<br />
<asp:GridView ID="GvUsers" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" onpageindexchanging="GvUsers_PageIndexChanging" 
        PageSize="5" onrowcommand="GvUsers_RowCommand">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>

<asp:TemplateField HeaderText="UserId">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("UserId") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="DOB">
<ItemTemplate>
<asp:Label ID="lblDOB" runat="server" Text='<%#Eval("DOB") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
<ItemTemplate>
<asp:Label ID="lblEMail" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
                        <ItemTemplate > 
                        <asp:Panel ID="pnl1" runat="server" Height="50px" Width="200px"  ScrollBars="Vertical" >
                        <asp:Label ID="txtAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </asp:Panel></ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField HeaderText="Acceptancy">
<ItemTemplate>
<asp:LinkButton ID="lblAccept" Text="Acceptancy" CausesValidation="false" CommandArgument='<%#Eval("UserId") %>' CommandName="Acceptancy" runat="server" ></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>

<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</center>
</div>
</asp:Content>

