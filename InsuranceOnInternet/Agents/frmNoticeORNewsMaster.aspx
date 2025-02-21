<%@ Page Language="C#" MasterPageFile="~/Agents/AgentsMasterPage.master" AutoEventWireup="true" CodeFile="frmNoticeORNewsMaster.aspx.cs" Inherits="Agents_frmNoticeORNewsMaster" Title="Untitled Page" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControls/BrowseDocFile.ascx" TagName="BrowseDoc" TagPrefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript" language="javascript">

function toggleAllCheckboexs(toggle)
{
				n = document.forms[0].length;
				var frm = document.forms[0];
				for(i=0;i<frm.length;i++)
				
					if(frm.elements[i].type=="checkbox")
						if (frm.elements[i].name.indexOf('Cbx')==0)
							frm.elements[i].checked=toggle;
			}
</script>

    <div>
        <center>
            <%--<br />
            <asp:Label ID="lblHeading" BackColor="Window" ForeColor="#5D7B9D" runat="server" Text="Notice OR News Master"
                Style="font-size: small; font-weight: 700; font-family: Verdana"></asp:Label>
            <br />--%>
            <br />
           <%-- <asp:UpdatePanel ID="panel1" runat="server">
               <Triggers>               
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
               <asp:AsyncPostBackTrigger ControlID="btnSubmit" EventName="Click" />
               
               
               <asp:AsyncPostBackTrigger ControlID="btncancel" EventName="Click" />
               </Triggers>
                <ContentTemplate>--%>
                    <table style="border: thin solid #5D7B9D; background-color:Window; width: 500px; ">
                        <tr>
                            <td  colspan="3" style="background-color:#5D7B9D">
                                <b>Notice OR News Master </b>
                            </td>
                            </tr>
                            
                        
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        
                        <tr>
                        <td >Notice or News Date</td>
                        <td ><asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                            <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" runat="server">
                            </cc1:CalendarExtender>
                        </td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvDate" runat="server" ErrorMessage="*" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td>Subject</td>
                        <td><asp:TextBox ID="txtSub" runat="server" Width="194px"></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvSub" runat="server" ErrorMessage="*" ControlToValidate="txtSub"></asp:RequiredFieldValidator>
      
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Notice or News Text</td>
                        <td  >
                            <asp:TextBox ID="txtText" TextMode="MultiLine" runat="server" Height="106px" Width="200px" 
                                ></asp:TextBox></td>
                        <td>
                        <asp:RequiredFieldValidator ID="rfvText" runat="server" ErrorMessage="*" ControlToValidate="txtText"></asp:RequiredFieldValidator>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                        <tr>
                        <td >Notice or News File</td>
                        <td >
                            <uc2:BrowseDoc ID="Doc" runat="server" /> 
                            </td>
                        <td>
                            &nbsp;</td>
                        </tr>
                        <tr>
                        <td colspan="3"></td>
                        </tr>
                       
<%--                     <tr>
                        <td colspan="3">
                        <asp:GridView ID="gvNews" runat="server" CellPadding="4" ForeColor="#333333" 
                                GridLines="None" AutoGenerateColumns="False" Width="357px" PageSize="5" 
                                onrowdatabound="gvNews_RowDataBound" 
                                onpageindexchanging="gvNews_PageIndexChanging">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                         <Columns>
                         <asp:TemplateField>
                         <HeaderTemplate>
                                            <input name="Cbx"  runat="server" onclick="toggleAllCheckboexs(this.checked)" type="checkbox" />Select
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                        <asp:CheckBox ID="chkCustId" runat="server" Text='<%#Eval("CustomerId") %>' />
                           </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="CustomerId">
                         <ItemTemplate>
                         <asp:Label id="lblCustId" runat="server" Text='<%#Eval("CustomerId") %>' ></asp:Label>
                         </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PolicyName">
                         <ItemTemplate>
                         <asp:Label ID="lblName" Text='<%#Eval("PolicyName") %>' runat="server"></asp:Label>
                         </ItemTemplate>
                         </asp:TemplateField>
                         <asp:TemplateField HeaderText="PaymentType">
                         <ItemTemplate>
                         <asp:Label ID="lblType" Text='<%#Eval("TypeName") %>' runat="server"></asp:Label>
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
--%>                        <tr>
                       
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
                       </table>
                       <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>

            
        </center>
    </div>

</asp:Content>

