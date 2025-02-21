<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmPoliciesReport.aspx.cs" Inherits="Admin_frmPoliciesReport" Title="Untitled Page" %>

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
<asp:Label ID="lblAgents" runat="server" Text="Policies Report" 
        style="font-weight: 700; text-decoration: underline; color: #5D7B9D" ></asp:Label>
<br />
<br />
<div id="divPolicy" >
                                    <asp:GridView ID="grdAllPolicies" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" PageSize="5" Width="200px" 
                                        onpageindexchanging="grdAllPolicies_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="PolicyName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("PolicyName")%>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="MinAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MinAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MaxAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MaxAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MinAge">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MinAge")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MaxAge">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MaxAge")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MinTerm">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MinTerm")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MaxTerm">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("MaxTerm")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Panel ID="pnl1" runat="server" Height="50px" ScrollBars="Vertical" 
                                                        Width="200px">
                                                        <asp:Label ID="txtDesc" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                                    </asp:Panel>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                    <br />
<asp:Button ID="btnPrint" runat="server" Text="Print Report" OnClientClick="callPrint('divPolicy')" />
<br />

<asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
<br />
</center>

</asp:Content>

