<%@ Page Language="C#" MasterPageFile="~/Agents/AgentsMasterPage.master" AutoEventWireup="true" CodeFile="frmNoticeorNewsEmails.aspx.cs" Inherits="Agents_frmNoticeorNewsEmails" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <center>
            <br />
            <br />
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
             <%--   <asp:AsyncPostBackTrigger ControlID="RadioButtonList1" EventName="SelectedIndexChanged" />
              <asp:AsyncPostBackTrigger ControlID="ddlPolicyId" EventName="SelectedIndexChanged" />
               <asp:AsyncPostBackTrigger ControlID="btnShowAll" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCloseGrid" EventName="Click" />
--%>           
    <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />

               </Triggers>
                <ContentTemplate>
<%--                    <table style="border: thin solid #5D7B9D; background-color:#5D7B9D; width: 450px; ">
                        <tr>
                            <td  colspan="2">
                                <b>Select the mode of operation you want </b>
                            </td>
                            </tr>
                            <tr>
                            <td >
                                <asp:RadioButtonList AutoPostBack="true" ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                    RepeatDirection="Horizontal">
                                    <asp:ListItem>Add New Record
                                    </asp:ListItem>
                                    <asp:ListItem>Modify Old Record</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            
                        </tr>
                    </table>
--%>            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 450px;">
                        <tr>
                        <td colspan="3" style="background-color:#5D7B9D"> Notice OR News Emails</td>
                        </tr>
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td>Premium Type</td>
                        <td><asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlType_SelectedIndexChanged"></asp:DropDownList></td>
                        </tr>  
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td>
                        Customers</td>  
                        <td><asp:ListBox ID="lbCust" runat="server" Height="120px" Width="140px"></asp:ListBox></td>
                        </tr>
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Subject</td>
                        <td >
                            <asp:DropDownList ID="ddlNewsId" runat="server" AutoPostBack="True" 
                                Height="44px" 
                                 Width="120px" >
                            </asp:DropDownList>
                            </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvNewsId" runat="server" ErrorMessage="*" ControlToValidate="ddlNewsId"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                     <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <%--<td >
                        <asp:Button ID="btnShowAll" Text="ShowAll" BorderColor="MediumSeaGreen" 
                                    BackColor="#797A80" ForeColor="White"  runat="server" Width="95px" 
                                onclick="btnShowAll_Click" CausesValidation="False" />
                        </td>--%>
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
<%--                         <tr>
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
--%>                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

