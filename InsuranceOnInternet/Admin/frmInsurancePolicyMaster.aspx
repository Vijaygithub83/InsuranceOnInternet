<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmInsurancePolicyMaster.aspx.cs" Inherits="Admin_frmInsurancePolicyMaster" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/BrowseDocFile.ascx" TagName="BrowseDoc1" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/BrowsePPTFile.ascx" TagName="BrowsePDF" TagPrefix="uc2" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <asp:Label ID="lblHeading" BackColor="Window" ForeColor="#5D7B9D" runat="server" Text="Insurance Policy Master"
                Style="font-size: small; font-weight: 700; font-family: Verdana"></asp:Label>
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="ddlPolicyId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
             
               <asp:PostBackTrigger ControlID="Doc1" />
               <asp:PostBackTrigger ControlID="PDF" />

               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:window; width: 700px; ">
                         <tr>
                            <td style="text-align: left; background-color:#5D7B9D;" colspan="3" 
                                 class="style1">
                                <b>Select the mode of operation you want </b>
                            </td>
                           <%-- </tr>
                            <tr>--%>
                            <td colspan="2" style="text-align: left; background-color:#5D7B9D;">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                    <asp:ListItem>Add New Record</asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left; background-color:#5D7B9D;" >
                                <asp:DropDownList ID="ddlPolicyId" Enabled="False" runat="server" Height="44px"
                                    Width="120px" OnSelectedIndexChanged="ddlPolicyId_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            </tr>
                   <%-- </table>
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 550px;">
                        --%>
                                              
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                         <td >Policy Name</td>
                        <td  >
                           <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </td>
                        <td >Company Name</td>
                        <td >
                            <asp:DropDownList ID="ddlCompanyId" runat="server" AutoPostBack="True" 
                                Height="44px" 
                                Width="120px">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvCompany" runat="server" ErrorMessage="*" ControlToValidate="ddlCompanyId"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >Launch Date</td>
                        <td  >
                            <asp:TextBox ID="txtLaunchDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtLaunchDate" runat="server">
                            </cc1:CalendarExtender>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ErrorMessage="*" ControlToValidate="txtLaunchDate"></asp:RequiredFieldValidator>
                        </td>
                        <td >End Date</td>
                        <td  >
                            <asp:TextBox ID="txtEndDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtEndDate" runat="server">
                            </cc1:CalendarExtender>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvEndDate" runat="server" ErrorMessage="*" ControlToValidate="txtEndDate"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >Min Amount</td>
                        <td >
                         <asp:TextBox ID="txtMinAmount" runat="server" 
                                ></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvMinamount" runat="server" ErrorMessage="*" ControlToValidate="txtMinAmount"></asp:RequiredFieldValidator>
                            </td>
                            <td >Max Amount</td>
                        <td >
                         <asp:TextBox ID="txtMaxAmount" runat="server" 
                                ></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvMaxAmount" runat="server" ErrorMessage="*" ControlToValidate="txtMaxAmount"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                       <tr>
                        <td >Min Age</td>
                        <td  >
                            <asp:TextBox ID="txtMinAge" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMinAge" runat="server" ErrorMessage="*" ControlToValidate="txtMinAge"></asp:RequiredFieldValidator>
                           </td>
                           <td >Max Age</td>
                        <td >
                            <asp:TextBox ID="txtMaxAge" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMaxAge" runat="server" ErrorMessage="*" ControlToValidate="txtMaxAge"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                     <tr>
                        <td colspan="6"></td>
                        </tr>
                         <tr>
                        <td >Min Term</td>
                        <td  >
                            <asp:TextBox ID="txtMinTerm" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMinTerm" runat="server" ErrorMessage="*" ControlToValidate="txtMinTerm"></asp:RequiredFieldValidator>
                           </td>
                           <td >Max Term</td>
                        <td >
                            <asp:TextBox ID="txtMaxTerm" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMaxTerm" runat="server" ErrorMessage="*" ControlToValidate="txtMaxTerm"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                            <td>
                                Policy Coverage Amount %</td>
                            <td>
                                <asp:TextBox ID="txtCovAmt" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvCovAmt" runat="server" 
                                    ControlToValidate="txtCovAmt" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td>Terms & Conditions</td>
                            <td >
                                <uc1:BrowseDoc1 ID="Doc1" runat="server" />
                                </td>
                           
                            <%--<td >
                            <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtMaxTerm"></asp:RequiredFieldValidator>
                           </td--%>
                            </tr>
                            <tr>
                                <td colspan="6">
                                </td>
                            </tr>
                            <tr>
                            <td colspan ="3"></td>
                            <td>Info Brochure</td>
                            <td >
                                 <uc2:BrowsePDF ID="PDF" runat="server" />
                            </td>
                            
                            </tr>
                            <tr>
                                <td colspan="6">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnShowAll" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen" CausesValidation="False" ForeColor="White" 
                                        onclick="btnShowAll_Click" Text="ShowAll" Width="95px" />
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen" Enabled="False" ForeColor="White" Height="25px" 
                                        OnClick="btnSubmit_Click" Text="Submit" Width="124px" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" BackColor="#797A80" BorderColor="Red" 
                                        CausesValidation="False" ForeColor="White" Height="25px" 
                                          Text="Delete" Width="60px" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btncancel" runat="server" BackColor="#797A80" BorderColor="Red" 
                                        CausesValidation="False" ForeColor="White" Height="25px" 
                                        OnClick="btncancel_Click" Text="Cancel" Width="60px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6" style="background-color:#5D7B9D">
                                </td>
                            </tr>
                            </table>
                            <br />
                            <table>
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="grdAllPolicies" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" PageSize="5" Width="200px" 
                                        onpageindexchanging="grdAllPolicies_PageIndexChanging">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
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
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#999999" />
                                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:Button ID="btnCloseGrid" runat="server" BackColor="#797A80" ForeColor="White"
                                        BorderColor="Red" CausesValidation="False" Height="21px" 
                                        onclick="btnCloseGrid_Click" Text="Close" Width="90px" />
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






