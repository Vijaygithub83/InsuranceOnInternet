<%@ Page Language="C#" MasterPageFile="~/MainMasterPage.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login" Title="Untitled Page" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            font-weight: bold;
        }
        .style3
        {
            color: #CE0000;
        }
    </style>
</asp:Content>
--%>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <br />
        <br />
        <asp:Label ID="lblLogin" runat="server" 
            style="color: #009900; font-weight: 700" ></asp:Label>
        <br />
    <br />
        <table width="250" border="0" cellspacing="0" cellpadding="0" style="border: thin solid LightSteelBlue;
            background-color: LightSteelBlue">
           
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2" align="left" >
                    User Name
                </td>
                <td >
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtusername" runat="server" TabIndex="1" class="log_field" Style="height: 20px;
                        width: 188px;" />
                </td>
                <td >
                    <asp:RequiredFieldValidator ControlToValidate="txtusername" ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2" align="left" >
                    Password
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td colspan="2">
                    <span class="innertxt">
                        <asp:TextBox TextMode="Password" ID="txtpassword" runat="server" TabIndex="1" class="log_field"
                            Style="height: 20px; width: 188px;" /></span>
                </td>
                <td >
                    <asp:RequiredFieldValidator ControlToValidate="txtpassword" ID="RequiredFieldValidator2"
                        runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td >
                    &nbsp;
                </td>
                <td >
                    
                </td>
                <td align="right" >
                    <a href="#"></a>
                    <asp:Button runat="server" ID="ImgBtnEmail" TabIndex="3" Text="Login" Style="border-width: 0px;
                        color: #FFFFFF; font-weight: 700; background-color: #7CCFBE;" OnClick="ImgBtnEmail_Click"
                        Height="28px" Width="78px" />
                </td>
                <td >
                    &nbsp;
                </td>
            </tr>
        </table>
       <asp:Label ID="lblMsg" runat="server" ForeColor="red"></asp:Label>
        <br />
        <br />
    </center>
</asp:Content>
