<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="frmLogout.aspx.cs" Inherits="Employee_frmLogout" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<center>
    <br />
    <br />
    
    <table>
    <tr>
    <td colspan="2">
        <h4><b><asp:Label ID="lblId" runat="server" Text="You are Signed Out Successfully.."></asp:Label></b></h4>
        </td>
        </tr>
        <%--<tr>
        <td colspan="2"><asp:Label ID="Label1" runat="server" Text="If u want to Login again please Click on below link"></asp:Label></td>
        </tr>
        <tr>
        <td colspan="2" align="center">
        <asp:LinkButton ID="lnkLogin" runat="server" Text="Login" onclick="lnkLogin_Click"></asp:LinkButton>
        </td>
        </tr>--%>
        </table>
    
</center>
</div>
</asp:Content>

