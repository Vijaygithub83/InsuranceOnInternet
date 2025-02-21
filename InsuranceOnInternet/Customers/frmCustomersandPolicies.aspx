<%@ Page Language="C#" MasterPageFile="~/Customers/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="frmCustomersandPolicies.aspx.cs" Inherits="Customers_frmCustomersandPolicies" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    <%--    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
    </style>
--%>
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <%--<asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="ddlPolicyRegdId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />--%>
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnContinue" EventName="Click" />

               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:window; width: 650px; ">
                         <tr>
                            <td style="text-align: center; background-color:#5D7B9D;" colspan="6" > 
                                 
                                <b style="color: #FFFFFF">Customers And Policies Master </b>
                            </td>
                           <%-- </tr>
                            <tr>--%>
                            <%--<td colspan="2" style="text-align: left; background-color:#5D7B9D;">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                    <asp:ListItem>Add New Record
                                    </asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left; background-color:#5D7B9D;" >
                                <asp:DropDownList ID="ddlPolicyRegdId" Enabled="False" runat="server" Height="44px"
                                    Width="120px"  AutoPostBack="True" 
                                    onselectedindexchanged="ddlPolicyRegdId_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>--%>
                            </tr>
                   <%-- </table>
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 550px;">
                        --%>
                                              
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                         <td > Agent Name </td>
                        <td  >
                        <asp:DropDownList ID="ddlAgent" runat="server" 
                                onselectedindexchanged="ddlAgent_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                           
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvAgent" runat="server" ErrorMessage="*" ControlToValidate="ddlAgent"></asp:RequiredFieldValidator>
                        </td>
                        <td >Policy Name</td>
                        <td >
                            <asp:DropDownList ID="ddlPolicy" runat="server" AutoPostBack="True" 
                                Height="44px" 
                                Width="120px" onselectedindexchanged="ddlPolicy_SelectedIndexChanged">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvPolicy" runat="server" ErrorMessage="*" ControlToValidate="ddlPolicy"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >Payment Type</td>
                        <td  >
                         <asp:DropDownList ID="ddlPayment" runat="server"></asp:DropDownList>                            
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvPayment" runat="server" ErrorMessage="*" ControlToValidate="ddlPayment"></asp:RequiredFieldValidator>
                           </td>
                           <td >Policy Amount</td>
                        <td >
                            <asp:ListBox ID="lbPolicyAmt" runat="server" Height="29px" 
                                ></asp:ListBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvConfirm" runat="server" ErrorMessage="*" ControlToValidate="lbPolicyAmt"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                       <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                         <td>Policy Term</td>
                        <td><asp:ListBox ID="lbTerm" runat="server" Height="29px" AutoPostBack="True" onselectedindexchanged="lbTerm_SelectedIndexChanged" 
                                ></asp:ListBox>
                            </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvTerm" runat="server" ErrorMessage="*" ControlToValidate="lbTerm"></asp:RequiredFieldValidator>

                          </td>
                        <td >Premium Confirmed</td>
                        <td >
                            <asp:TextBox ID="txtPremium" runat="server"></asp:TextBox>
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvPremium" runat="server" ErrorMessage="*" ControlToValidate="txtPremium"></asp:RequiredFieldValidator>
                            </td>
                        
                        
                        </tr>
                        
                       
                     <tr>
                        <td colspan="6"></td>
                        </tr>
                         <%--<tr>
                        <td >Current Premium Pay</td>
                        <td  >
                            <asp:TextBox ID="txtDueDate" runat="server" ></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" TargetControlID="txtDueDate" runat="server">
                            </cc1:CalendarExtender>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMinTerm" runat="server" ErrorMessage="*" ControlToValidate="txtMinTerm"></asp:RequiredFieldValidator>
                           </td>
                           <td >&nbsp;</td>
                        <td >
                            &nbsp;</td>
                           <td>
                               &nbsp;</td>
                        </tr>--%>
                        <%--<tr>
                        <td colspan="6"></td>
                        </tr>--%>
                        
                            <tr>
                                <td colspan="3">
                                    <%--<asp:Button ID="btnShowAll" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen" CausesValidation="False" ForeColor="White" 
                                        onclick="btnShowAll_Click" Text="ShowAll" Width="95px" />--%>
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnContinue" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen" ForeColor="White" Height="25px" 
                                        OnClick="btnContinue_Click" Text="Continue" Width="124px" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btncancel" runat="server" BackColor="#797A80" BorderColor="Red" 
                                        CausesValidation="False" ForeColor="White" Height="25px" 
                                        OnClick="btncancel_Click" Text="Cancel" Width="60px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6" style="background-color:#5D7B9D">
                                </td>
                            </tr>
<%--                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="grdCustPolicy" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" PageSize="5" Width="400px" onpageindexchanging="grdCustPolicy_PageIndexChanging" 
                                       >
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="AgentName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PolicyName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("PolicyName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PolicyAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("PolicyAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="RegdDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("CustRegdDate")%>'></asp:Label>
                                                </ItemTemplate>                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PaymentType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("TypeName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
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
--%>     
                   </caption>
                   <tr><td colspan="6">
                       <asp:Panel ID="pnl1" runat="server" Visible="False">
                           <table style="border: thin solid #5D7B9D; background-color:window; width: 300px; ">
                               <tr>
                                   <td class="style1" colspan="3" style=" background-color:#5D7B9D;">
                                       Payment Details</td>
                               </tr>
                               <tr>
                                   <td>
                                       PaymentType</td>
                                   <td>
                                       <asp:DropDownList ID="ddlPaymentAmt" runat="server">
                                       </asp:DropDownList>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvAmt" runat="server" 
                                           ControlToValidate="ddlPaymentAmt" ErrorMessage="*"></asp:RequiredFieldValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       Cheque/DD No</td>
                                   <td>
                                       <asp:TextBox ID="txtDDNo" runat="server"></asp:TextBox>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       Cheque/DD Date</td>
                                   <td>
                                       <asp:TextBox ID="txtChkDate" runat="server"></asp:TextBox>
                                       <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                                           TargetControlID="txtChkDate">
                                       </cc1:CalendarExtender>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvDDDate" runat="server" 
                                           ControlToValidate="txtChkDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                       Bank Name</td>
                                   <td>
                                       <asp:TextBox ID="txtBankName" runat="server"></asp:TextBox>
                                   </td>
                                   <td>
                                       <asp:RequiredFieldValidator ID="rfvBankName" runat="server" 
                                           ControlToValidate="txtBankName" ErrorMessage="*"></asp:RequiredFieldValidator>
                                   </td>
                               </tr>
                               <tr>
                                   <td colspan="3">
                                   </td>
                               </tr>
                               <tr>
                                   <td>
                                   </td>
                                   <td colspan="2">
                                       <asp:Button ID="btnPay" runat="server" BackColor="#797A80" 
                                           BorderColor="MediumSeaGreen" ForeColor="White" Height="25px" 
                                           OnClick="btnPay_Click" Text="Pay" Width="60px" />
                                       &nbsp;&nbsp;&nbsp;
                                       <asp:Button ID="btnClear" runat="server" BackColor="#797A80" BorderColor="Red" 
                                           CausesValidation="False" ForeColor="White" Height="25px" 
                                           OnClick="btnClear_Click" Text="Clear" Width="60px" />
                                   </td>
                               </tr>
                           </table>
                       </asp:Panel>
                       </td></tr>
<tr>
<td colspan="6" align="center">
    &nbsp;</td>
</tr>
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

