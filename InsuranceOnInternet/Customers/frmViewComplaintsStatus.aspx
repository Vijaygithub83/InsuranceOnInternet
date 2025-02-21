<%@ Page Language="C#" MasterPageFile="~/Customers/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="frmViewComplaintsStatus.aspx.cs" Inherits="Customers_frmViewComplaintsStatus" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<center>
<br />
<br />
<asp:Button ID="btnShow" runat="server" Text="Show Complaints Status" 
        onclick="btnShow_Click" />
<br />
<br />
<asp:GridView ID="GvCompStatus" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
        GridLines="None" 
        PageSize="5"  Width="450px">
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#999999" />
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
<Columns>

<asp:TemplateField HeaderText="ComplaintDate">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("ComplaintDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="ComplaintText">
                        <ItemTemplate > 
                        <asp:Panel ID="pnl1" runat="server" Height="50px" Width="200px"  ScrollBars="Vertical" >
                        <asp:Label ID="txtComp" runat="server" Text='<%#Eval("ComplaintText")%>'></asp:Label>
                        </asp:Panel></ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField HeaderText="AnswerDate">
<ItemTemplate>
<asp:Label ID="lblDate" runat="server" Text='<%#Eval("AnswerDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="AnswerText">
                        <ItemTemplate > 
                        <asp:Panel ID="pnl1" runat="server" Height="50px" Width="200px"  ScrollBars="Vertical" >
                        <asp:Label ID="txtAnswer" runat="server" Text='<%#Eval("AnswerText")%>'></asp:Label>
                        </asp:Panel></ItemTemplate>
                        </asp:TemplateField>
<asp:TemplateField HeaderText="AgentName">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>

<%--<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:LinkButton ID="lblAccept" Text="Acceptancy" CausesValidation="false" CommandArgument='<%#Eval("UserId") %>' CommandName="Acceptancy" runat="server" ></asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>--%>

</Columns>
</asp:GridView>
<br />
<br />
<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
</center>
</div>

</asp:Content>

