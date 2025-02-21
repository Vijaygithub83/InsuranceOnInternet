<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmAgentsAcceptancy.aspx.cs" Inherits="Admin_frmAgentsAcceptancy" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div>
<center>
<br />
<asp:Label ID="lblHead" runat="server" Text="Agents Acceptancy Form" 
        style="color: #663300; font-weight: 700; font-size: medium; text-decoration: underline"></asp:Label>

<br />
<br />
<asp:Button ID="btnShow" runat="server" Text="Show Registered Agents" 
        onclick="btnShow_Click" />
<br />
<br />
<asp:GridView ID="GvAgents" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None"  
        PageSize="5" onpageindexchanging="GvAgents_PageIndexChanging" 
        onrowcommand="GvAgents_RowCommand">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>
<%--<asp:TemplateField HeaderText="Select">
<ItemTemplate>
<asp:CheckBox ID="chkSelect" runat="server" />
</ItemTemplate>
</asp:TemplateField>--%>
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
<ItemTemplate>
<asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:LinkButton ID="lblAccept" Text="Acceptancy" CausesValidation="false" CommandArgument='<%#Eval("UserId") %>' CommandName="Acceptancy"  runat="server" ></asp:LinkButton>
<asp:LinkButton ID="lblReject" Text="Reject" forecolor="Red" CausesValidation="false" CommandArgument='<%#Eval("UserId") %>' CommandName="Reject"  runat="server" ></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>

</Columns>
</asp:GridView>
<br />
<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</center>
</div>

</asp:Content>

