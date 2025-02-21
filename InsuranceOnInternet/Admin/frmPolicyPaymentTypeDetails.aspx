<%@ Page Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="frmPolicyPaymentTypeDetails.aspx.cs" Inherits="Admin_frmPolicyPaymentTypeDetails" Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  Runat="Server">
    <div >
        <center style="height: 531px">
            <br />
            <asp:Label ID="lblHeading" BackColor="window" ForeColor="#5D7B9D" runat="server" Text="Policy PaymentType Details"
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
               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:#5D7B9D; width: 450px; ">
                        <tr>
                            <td  colspan="2">
                                <b style="color: #FFFFFF">Select the mode of operation you want </b>
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
                            
                        </tr>
                    </table>
            
                    <table style="border: thin solid #5D7B9D; background-color: window;  width: 450px;">
                        
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Policy Name</td>
                        <td >
                            <asp:DropDownList ID="ddlPolicyId" runat="server" AutoPostBack="True" 
                                Height="44px" 
                                 Width="120px" onselectedindexchanged="ddlPolicyId_SelectedIndexChanged">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="ddlPolicyId"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Payment Type</td>
                        <td  align="center">
                            <asp:DropDownList ID="ddlPayment" runat="server" AutoPostBack="True" 
                                 Height="44px" 
                                 Width="120px">
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvPayment" runat="server" ErrorMessage="*" ControlToValidate="ddlPayment"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <%--<tr>
                        <td >Policy Regd Date</td>
                        <td align="center">
                         <asp:TextBox ID="txtDate" runat="server" 
                                style="margin-left: 0px"></asp:TextBox> 
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" runat="server">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                      <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>--%>
                       
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
                                    />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btncancel" BorderColor="Red" ForeColor="White" BackColor="#797A80" runat="server"
                                    Text="Cancel" Height="25px" Width="60px" OnClick="btncancel_Click" 
                                    CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"  align="left" style="background-color:#5D7B9D">
                            </td>
                        </tr>
                         <tr>
                    <td colspan="3">
                        <asp:GridView AutoGenerateColumns="False" ID="grdPayment" runat="server" 
                            Width="300px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            AllowPaging="True" PageSize="5" onpageindexchanging="grdPayment_PageIndexChanging"  
                            >
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                        <asp:TemplateField HeaderText="PolicyName">
                        <ItemTemplate >
                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("PolicyName")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="PaymentType">
                        <ItemTemplate >
                        <asp:Label ID="lblAbbreviation" runat="server" Text='<%#Eval("TypeName")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="PolicyRegdDate">
                        <ItemTemplate >
                        <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("RegisteredDate")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Address">
                        <ItemTemplate > 
                        <asp:Panel ID="pnl1" runat="server" Height="50px" Width="200px"  ScrollBars="Vertical" >
                        <asp:Label ID="txtDesc" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                        </asp:Panel></ItemTemplate>
                        </asp:TemplateField>--%>
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

