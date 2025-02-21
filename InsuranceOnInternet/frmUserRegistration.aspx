<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true" CodeFile="frmUserRegistration.aspx.cs" Inherits="frmUserRegistration" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<%@ Register src="~/UserControls/BrowseImage.ascx" tagname="BrowseImage" tagprefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div >
        <center>           
           
            <br />
            <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
               </Triggers>
                <ContentTemplate>
                   
            
                    <table style="border: thin solid #5D7B9D; background-color: Window;  width: 350px; ">
                        <tr>
                        <td colspan="6" align="center" style=" background-color:#5D7B9D" >
                            <b>User Registration Form </b>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >UserFirstName</td>
                        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ControlToValidate="txtName" ></asp:RequiredFieldValidator>
                        </td>
                        <td colspan="3" rowspan="4">
                            
                            <uc1:BrowseImage ID="BrowseImage1" runat="server" 
                                DefaultImageUrl="~/Images/NoImage.jpg" />
                            
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                            <td >MiddleName</td>
                            <td><asp:TextBox ID="txtMName" runat="server"></asp:TextBox></td>
                        <td>
                        
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >LastName</td>
                        <td><asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        </td>                        
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                        DOB
                        </td>
                        <td><asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDOB" runat="server">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                       <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ErrorMessage="*" ControlToValidate="txtDOB" ></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            Agent
                        </td>
                        <td valign="middle">
                            <asp:DropDownList ID="ddlAgent" runat="server" 
                                onselectedindexchanged="ddlAgent_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList> &nbsp;
                            <asp:TextBox ID="txtAgentAddress" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td>
                        
                       <asp:RequiredFieldValidator ID="rfvAgent" runat="server" ErrorMessage="*" ControlToValidate="ddlAgent" ></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td>
                        Email
                        </td>
                        <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txtEmail"
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                            <td>PhoneNo</td>
                            <td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" 
                                    ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    
                                                          <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" runat="server" 
                                    ErrorMessage="*" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
       
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td >
                            UserName</td>
                        <td >
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        </td>
                        <td >
                      <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName" ></asp:RequiredFieldValidator>
                        </td>
                        <td rowspan="2" >
                        Address
                        </td>
                        <td rowspan="2" >
                            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" Height="80px" 
                                Width="176px"></asp:TextBox>
                            </td>
                        <td rowspan="2" >
                            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" 
                                ControlToValidate="txtAddress" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" 
                                ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                        <td colspan="6"></td>
                        </tr>
                        <tr>
                        <td colspan="3">
                            &nbsp;</td>
                        <td colspan="3">
                         <asp:Button ID="btnSubmit" runat="server"  Text="Submit" 
                                ForeColor="White" BorderColor="MediumSeaGreen" BackColor="#797A80" 
                                onclick="btnSubmit_Click" />
                          &nbsp;
                        <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" ForeColor="White" 
                                BorderColor="red" BackColor="#797A80" onclick="btnCancel_Click" />
                        </td>
                        </tr>
                         
                        <tr>
                        <td colspan="6" style="background-color:#5D7B9D"></td>
                        </tr>
                        
               
                        </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>
        </center>
    </div>

</asp:Content>

