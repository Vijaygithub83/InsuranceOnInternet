<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmPolicyPaymentMaster.aspx.cs" Inherits="Admin_frmPolicyPaymentMaster" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <asp:Label ID="lblHeading" BackColor="Window" ForeColor="#5D7B9D" runat="server" Text="Policy Payment Master"
                Style="font-size: small; font-weight: 700; font-family: Verdana"></asp:Label>
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <%--<Triggers>               
               <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="ddlPaymentId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
               </Triggers>--%>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:window; width: 650px; ">
                         <%--<tr>
                            <td style="text-align: left; background-color:#5D7B9D;" colspan="3" 
                                 class="style1">
                                <b>Select the mode of operation you want </b>
                            </td>
                           
                            <td colspan="2" style="text-align: left; background-color:#5D7B9D;">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                    <asp:ListItem>Add New Record
                                    </asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td style="text-align: left; background-color:#5D7B9D;" >
                                <asp:DropDownList ID="ddlPaymentId" Enabled="False" runat="server" Height="44px"
                                    Width="120px" OnSelectedIndexChanged="ddlPaymentId_SelectedIndexChanged" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            </tr>
                  
                                              
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                         <td >Payment Date </td>
                        <td  >
                           <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" runat="server">
                            </cc1:CalendarExtender>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                        </td>
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
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        
                       
                        <tr>
                        <td > Amount</td>
                        <td >
                         <asp:TextBox ID="txtAmount" runat="server" 
                                ></asp:TextBox> 
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvamount" runat="server" ErrorMessage="*" ControlToValidate="txtAmount"></asp:RequiredFieldValidator>
                            </td>
                            <td >Check/DD No</td>
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
                        <td >Check/DD Date</td>
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
                           <td >Policy RegdId</td>
                        <td >
                            <asp:DropDownList ID="ddlRegdId" runat="server"></asp:DropDownList></td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvRegdId" runat="server" ErrorMessage="*" ControlToValidate="ddlRegdId"></asp:RequiredFieldValidator>
                               </td>
                        <td >Next Premium Due Date</td>
                        <td  >
                            <asp:TextBox ID="txtDueDate" runat="server" ></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender3" TargetControlID="txtDueDate" runat="server">
                            </cc1:CalendarExtender>
                           </td>
                           <td>
                           <asp:RequiredFieldValidator ID="rfvMinTerm" runat="server" ErrorMessage="*" ControlToValidate="txtDueDate"></asp:RequiredFieldValidator>
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
                                        BorderColor="MediumSeaGreen" Enabled="False" ForeColor="White" Height="25px" 
                                        OnClick="btnSubmit_Click" Text="Submit" Width="124px" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btncancel" runat="server" BackColor="#797A80" BorderColor="Red" 
                                        CausesValidation="False" ForeColor="White" Height="25px" 
                                        OnClick="btncancel_Click" Text="Cancel" Width="60px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="6" style="background-color:#5D7B9D">
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="grdPayments" runat="server" AllowPaging="True" 
                                        AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                                        GridLines="None" PageSize="5" Width="400px" 
                                        onpageindexchanging="grdPayments_PageIndexChanging">
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <Columns>
                                        <asp:TemplateField HeaderText="CustId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("CustomerId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PolicyRegnId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("PolicyRegnId")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TypeName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("TypeName")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("PaymentAmount")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("PaymentDate")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="NextPremiumDueDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("NextPremiumDueDate")%>'></asp:Label>
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

