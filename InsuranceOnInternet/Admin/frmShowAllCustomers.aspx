<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmShowAllCustomers.aspx.cs" Inherits="Admin_frmShowAllCustomers" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script language="javascript" type="text/javascript">
 
    function callPrint(elementId)
    {
       var prtContent = document.getElementById(elementId);                
       var WinPrint = window.open('','', 'left=0,top=0,width=1000,height=600,toolbar=2,scrollbars=2,status=0');
       var docColor="Black";
       var strInnerHTML=prtContent.innerHTML;
       var strModifiedInnerHTMl=strInnerHTML.replace(/white/g,docColor);
       WinPrint.document.write(strModifiedInnerHTMl);
       WinPrint.document.close();
       WinPrint.focus();
       WinPrint.print();
       WinPrint.close();
    }   
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divCust" >
    <center>
<br />
<br />
<asp:Label ID="lblAgents" runat="server" Text="Customers Report" 
        style="font-weight: 700; text-decoration: underline; color: #5D7B9D" ></asp:Label>
<br />
<br />
<table>
<tr>
<td>Select Required Date</td>
<td><asp:TextBox ID="txtDate" runat="server" ></asp:TextBox>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
    </cc1:CalendarExtender>
</td>
<td><asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator></td>
<td><asp:Button ID="btnShow" runat="server" Text="Show" onclick="btnShow_Click" /></td>
</tr>
<tr>
<td colspan="4"><asp:Button ID="btnShowAll" runat="server" 
        Text="Show All Customers" CausesValidation="false" onclick="btnShowAll_Click" /></td>
</tr>
<tr>
<td colspan="4"></td>
</tr>
<tr><td colspan="4">

<asp:GridView id="gvCust" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" PageSize="5" 
        onpageindexchanging="gvCust_PageIndexChanging">
<Columns>
<asp:TemplateField HeaderText="CustomerName">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PolicyName">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("PolicyName") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="RegdDate">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("RegdDate") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Email">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("Email") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="PhoneNo">
<ItemTemplate>
<asp:Label ID="lblName" runat="server" Text='<%#Eval("PhoneNo") %>'></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Address">
<ItemTemplate>
<asp:Panel ID="pnl1" runat="server" ScrollBars="Vertical" Height="50px" Width="200px">
<asp:Label ID="lblName" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
</asp:Panel>
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</td>
</tr>
</table>
</center>
</div>
<div>
<center>
<br />
<asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClientClick="callPrint('divCust')" />
<br />

<asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
<br />
</center>
</div>
</asp:Content>

