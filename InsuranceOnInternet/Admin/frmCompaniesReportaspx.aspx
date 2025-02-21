<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmCompaniesReportaspx.aspx.cs" Inherits="Admin_frmCompaniesReportaspx" Title="Untitled Page" %>

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

<center>
<br />
<br />
<asp:Label ID="lblAgents" runat="server" Text="Companies Report" 
        style="font-weight: 700; text-decoration: underline; color: #5D7B9D" ></asp:Label>
<br />
<br />
<div id="divCompany" >
                        <asp:GridView AutoGenerateColumns="False" ID="grdAllCompanies" runat="server" 
                            Width="200px" 
                            AllowPaging="True" PageSize="5" onpageindexchanging="grdAllCompanies_PageIndexChanging" 
                            >
                        <Columns>
                        <asp:TemplateField HeaderText="CompanyName">
                        <ItemTemplate >
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("CompanyName")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PhoneNo">
                        <ItemTemplate >
                        <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("PhoneNo")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                        <ItemTemplate >
                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                        <ItemTemplate > 
                        <asp:Panel ID="pnl1" runat="server" Height="50px" Width="200px"  ScrollBars="Vertical" >
                        <asp:Label ID="txtDesc" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </asp:Panel></ItemTemplate>
                        </asp:TemplateField>
                       </Columns>
                        </asp:GridView>
                        </div>
                                    <br />
<asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClientClick="callPrint('divCompany')" />
<br />

<asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
<br />
</center>

</asp:Content>

