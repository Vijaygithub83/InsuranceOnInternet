<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmInsuranceCompanyMaster.aspx.cs" Inherits="Admin_frmInsuranceCompanyMaster" Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <asp:Label ID="lblHeading" BackColor="Window" ForeColor="#5D7B9D" 
                runat="server" Text="Company Details"
                
                Style="font-size: small; font-weight: 700; font-family: Verdana; text-decoration: underline;"></asp:Label>
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="ddlCompanyId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:#5D7B9D; width: 550px; ">
                        <tr>
                            <td  colspan="2" class="style1">
                                <b>Select the mode of operation you want </b>
                            </td>
                            </tr>
                            <tr>
                            <td >
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                <asp:ListItem>Add New Record</asp:ListItem>
                                 <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left" >
                                <asp:DropDownList ID="ddlCompanyId" Enabled="False" runat="server" Height="44px"
                                    Width="120px" OnSelectedIndexChanged="ddlCompanyId_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 550px;">
                        <%--<tr>
                            <td style="text-align: left" colspan="2">
                                <b>Select the mode of operation you want </b>
                            </td>
                            </tr>
                            <tr>
                            <td class="style1">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Height="16px">
                                    <asp:ListItem>Add New Record
                                    </asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left" class="style6">
                                <asp:DropDownList ID="ddlDeptId" Enabled="False" runat="server" Height="44px"
                                    Width="120px" OnSelectedIndexChanged="ddlDeptId_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            </tr>
                        --%>
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Company Name</td>
                        <td ><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >PhoneNo</td>
                        <td  align="center"><asp:TextBox ID="txtPhone" runat="server" 
                                style="margin-left: 0px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="*" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Email</td>
                        <td align="center">
                         <asp:TextBox ID="txtEmail" runat="server" 
                                style="margin-left: 0px"></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                       <tr>
                        <td >Address</td>
                        <td  align="center"><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Height="80px" 
                                Width="166px"></asp:TextBox></td>
                        </tr>
                     <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >
                        <asp:Button ID="btnShowAll" Text="ShowAll" BorderColor="MediumSeaGreen" 
                                    BackColor="#797A80" ForeColor="White"  runat="server" Width="95px" 
                                onclick="btnShowAll_Click" CausesValidation="False" />
                        </td>
                        <td colspan="2" style="text-align: right; font-weight: 700;">
                                &nbsp;&nbsp;
                                <asp:Button ID="btnSubmit" BorderColor="MediumSeaGreen" 
                                    BackColor="#797A80" ForeColor="White" runat="server"
                                    Text="Submit" Height="25px" Width="124px" OnClick="btnSubmit_Click" 
                                    Enabled="False" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnDelete" BorderColor="Red" ForeColor="White" BackColor="#797A80" runat="server"
                                    Text="Delete" Height="25px" Width="60px"  OnClick="btnDelete_Click" Enabled="false"
                                    CausesValidation="False" />
                            <asp:Button ID="btncancel" BorderColor="Red" ForeColor="White"  BackColor="#797A80" runat="server" 
                                Text="Cancel" Height="25px" Width="60px" OnClick="btncancel_Click"  CausesValidation="False"/>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"  align="left" style="background-color:#5D7B9D">
                            </td>
                        </tr>
                         <tr>
                    <td colspan="3">
                        <asp:GridView AutoGenerateColumns="False" ID="grdAllCompanies" runat="server" 
                            Width="200px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            AllowPaging="True" PageSize="5" onpageindexchanging="grdAllCompanies_PageIndexChanging" 
                            >
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
                            <PagerStyle BackColor="#284775" ForeColor="White" 
                                HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="PaleGoldenrod" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                <td colspan="3">
                    <asp:Button BorderColor="Red" BackColor="#797A80" ID="btnCloseGrid" 
                        runat="server" Text="Close" Height="21px" 
                        Width="90px" CausesValidation="False" onclick="btnCloseGrid_Click" />
                </td>
                </tr>
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

   
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
    </style>


</asp:Content>



