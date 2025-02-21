<%@ Page Language="C#" MasterPageFile="~/Customers/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="frmPolicyPayments.aspx.cs" Inherits="Customers_frmPolicyPayments" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div >
        <center>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="ddlPaymentId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
                   <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:window; width: 550px; ">
                         <tr>
                            <td style="text-align: center; background-color:#5D7B9D; color: #FFFFFF;" colspan="6" 
                                 >
                                <b>Policy Payment Details</b></td>
                           </tr>
                            <tr>
                            <td colspan="2" style="text-align: left; background-color:#5D7B9D;">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                    <asp:ListItem>Add New Record</asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left; background-color:#5D7B9D;" >
                                <asp:DropDownList ID="ddlPaymentId" Enabled="False" runat="server" Height="44px"
                                    Width="120px" OnSelectedindexchanged="ddlPaymentId_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            </tr>
                         </table>
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 550px;">
                        
                                       
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                         <td >Policy RegdId</td>
                        <td  >
                            <asp:DropDownList ID="ddlRegdId" runat="server" 
                                onselectedindexchanged="ddlRegdId_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvRegdId" runat="server" ErrorMessage="*" ControlToValidate="ddlRegdId"></asp:RequiredFieldValidator>
                        </td>
                        <td > Premium Amount</td>
                        <td >
                         <asp:TextBox ID="txtAmount" runat="server" 
                                ></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvamount" runat="server" ErrorMessage="*" ControlToValidate="txtAmount"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        
                       
                        <tr>
                        
                            <td >Payment TypeId</td>
                        <td >
                            <asp:DropDownList ID="ddlTypeId" runat="server" AutoPostBack="True" 
                                 Height="44px" 
                                Width="120px">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvTypeId" runat="server" ErrorMessage="*" ControlToValidate="ddlTypeId"></asp:RequiredFieldValidator>
                        </td>
                            <td >Cheque/DD No</td>
                        <td >
                         <asp:TextBox ID="txtDDNo" runat="server" 
                                ></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvDDNo" runat="server" ErrorMessage="*" ControlToValidate="txtDDNo"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                       <tr>
                        <td >Cheque/DD Date</td>
                        <td  >
                            <asp:TextBox ID="txtDDDate" runat="server" ></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDDDate" runat="server">
                            </cc1:CalendarExtender>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvDDDate" runat="server" ErrorMessage="*" ControlToValidate="txtDDDate"></asp:RequiredFieldValidator>
                           </td>
                           <td >Bank Name</td>
                        <td >
                            <asp:TextBox ID="txtBankName" runat="server" ></asp:TextBox>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvBankName" runat="server" ErrorMessage="*" ControlToValidate="txtBankName"></asp:RequiredFieldValidator>
                           </td>
                        </tr>
                     
                         
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        
                            <tr>
                                <td colspan="3">
                                    <asp:Button ID="btnShowAll" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen" CausesValidation="False" ForeColor="White" 
                                        onclick="btnShowAll_Click" Text="ShowAll" Width="95px" />
                                </td>
                                <td colspan="3">
                                    <asp:Button ID="btnSubmit" runat="server" BackColor="#797A80" 
                                        BorderColor="MediumSeaGreen"  ForeColor="White" Height="25px" 
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
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="grdPayments" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" PageSize="5" Width="400px" 
                                        onpageindexchanging="grdPayments_PageIndexChanging">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                        <asp:TemplateField HeaderText="PolicyName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("PolicyName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PremiumAmount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("PaymentAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PaymentDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("PaymentDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PaymentType">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("TypeName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                             <asp:TemplateField HeaderText="NextPremiumDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("DueDate")%>'></asp:Label>
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
                        </caption>
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

