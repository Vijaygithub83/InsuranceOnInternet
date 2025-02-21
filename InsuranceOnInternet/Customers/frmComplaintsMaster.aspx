<%@ Page Language="C#" MasterPageFile="~/Customers/CustomerMasterPage.master" AutoEventWireup="true" CodeFile="frmComplaintsMaster.aspx.cs" Inherits="Customers_frmComplaintsMaster" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <%--<asp:Label ID="lblHeading" BackColor="Window" ForeColor="#5D7B9D" runat="server" Text="Complaints Master"
                Style="font-size: small; font-weight: 700; font-family: Verdana"></asp:Label>--%>
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
            <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="ddlComplaintId" EventName="SelectedIndexChanged" /> 
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                    <table style="border: thin solid #5D7B9D; background-color:window ; width: 550px; ">
                        <tr>
                            <td  colspan="3" style="background-color:#5D7B9D;" >
                                <b style="color: #FFFFFF">Complaints Master </b>
                            </td>
                            </tr>
                            <tr>
                            <td colspan="2" style="text-align: left; background-color:#5D7B9D;">
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                 RepeatDirection="Horizontal" Height="16px" style="color: #FFFFFF">
                                 <asp:ListItem>Add New Record</asp:ListItem>
                                 <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                                </td>
                            <td style=" background-color:#5D7B9D">
                                <asp:DropDownList ID="ddlComplaintId" Enabled="False" runat="server" Height="44px"
                                    Width="120px"  AutoPostBack="True" OnSelectedIndexChanged="ddlComplaintId_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                   </table>
            
                    <table style="border: thin solid #7CCFBE; background-color: Window;  width: 550px;">
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
                            </tr>--%>
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                         <td >Policy Regd</td>
                        <td  >
                            <asp:DropDownList ID="ddlRegdId" runat="server" Width="226px" 
                                >
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvRegdId" runat="server" ErrorMessage="*" ControlToValidate="ddlRegdId"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        
                         <tr>
                        <td colspan="3"></td>
                        </tr>
                        
                        
                       <tr>
                       <td>Complaint Text</td>
                       <td><asp:TextBox ID="txtComplaint" TextMode="MultiLine" runat="server" 
                               Height="80px"></asp:TextBox></td>
                       <td>
                    <asp:RequiredFieldValidator ID="rfvComplaint" runat="server" ErrorMessage="*" ControlToValidate="txtComplaint"></asp:RequiredFieldValidator>
    
                       </td>
                       </tr>
                     <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3" align="left">
                            <asp:Button ID="btnShowAll" runat="server" BackColor="#797A80" 
                                 BorderColor="MediumSeaGreen" CausesValidation="False" ForeColor="White" 
                                 onclick="btnShowAll_Click" Text="ShowAll" Width="95px" />
                        </td>
                        <td colspan="3">
                                <asp:Button ID="btnSubmit" BorderColor="MediumSeaGreen" 
                                    BackColor="#797A80" ForeColor="White" runat="server"
                                    Text="Submit" Height="25px" Width="78px" OnClick="btnSubmit_Click" CssClass="auto-style1" 
                                     />&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnDelete" BorderColor="Red" ForeColor="White" BackColor="#797A80" runat="server"
                             Text="Delete" Height="25px" Width="60px" CausesValidation="False" OnClick="btnDelete_Click" />
                                <asp:Button ID="btncancel" BorderColor="Red" ForeColor="White" BackColor="#797A80" runat="server"
                                    Text="Cancel" Height="25px" Width="79px" OnClick="btncancel_Click" 
                                    CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3"  align="left" style="background-color:#5D7B9D">
                            </td>
                        </tr>
                    </table>
                        
                        <tr>
                    <td colspan="3">
                        <asp:GridView AutoGenerateColumns="False" ID="grdComplaints" runat="server" 
                            Width="400px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                            AllowPaging="True" PageSize="5" onpageindexchanging="grdComplaints_PageIndexChanging">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <Columns>
                        <asp:TemplateField HeaderText="PolicyRegnId">
                        <ItemTemplate >
                        <asp:Label ID="lblPolicyRegnId" runat="server" Text='<%#Eval("PolicyRegnId")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ComplaintText">
                        <ItemTemplate >
                        <asp:Label ID="lblComplaintText" runat="server" Text='<%#Eval("ComplaintText")%>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                       
                        </Columns>
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#999999" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                       </asp:GridView>
                    </td>
                </tr>
                <tr>
                <td colspan="6">
                    <asp:Button BorderColor="Red" BackColor="#5D7B9D" ID="btnCloseGrid" 
                        runat="server" Text="Close" ForeColor="White" Height="21px" 
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
        .auto-style1 {
            margin-left: 0px;
        }
    </style>
    </asp:Content>


