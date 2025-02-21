using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Mail;
public partial class Admin_frmUsersAcceptancy : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AgentId"] != null)
            { 
              
            }
              
        }
    }
    protected void GvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvUsers.PageIndex = e.NewPageIndex;
                GvUsers.DataSource = ds.Tables[0];
                GvUsers.DataBind();
            }
            else
            {
                lblMsg.Text = "No Registrered Users Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            objUser.AgentId = Convert.ToInt32(Session["AgentId"]);
            DataSet ds = objUser.GetAcceptancyCustomersByAgentId();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvUsers.DataSource = ds.Tables[0];
                GvUsers.DataBind();
            }
            else
            {
                GvUsers.EmptyDataText = "No Registrered Users Available..";
                GvUsers.DataBind();
                //lblMsg.Text = "No Registrered Users Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;            
        }
    }

    void CustomerAcceptancyByAgentId(int CustomerId)
    {
        DataSet ds = objUser.UpdateAcceptancyCustomersByAgentId(CustomerId);

    }

        void SendMails(int Id)
    {
        DataSet ds = (DataSet)ViewState["Data"];
        DataRow dr = ds.Tables[0].Select("UserId=" + Id)[0];

        MailMessage objMail = new MailMessage();
        objMail.From = "InsuranceOnInternet";
        objMail.To = "Localhost";
        objMail.Subject = "Status of Customers Request";
        objMail.Body = "Your Request for Customer is Accepted..Your Email : " + dr["Email"].ToString() ;
        SmtpMail.SmtpServer = "LocalHost";
        SmtpMail.Send(objMail);

    }
    protected void GvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Acceptancy")
            {
                objUser.UserId = Convert.ToInt32(e.CommandArgument);
                objUser.AgentId = Convert.ToInt32(Session["AgentId"]);
                lblMsg.Text = objUser.AcceptUsersAsCustomers();

                CustomerAcceptancyByAgentId(Convert.ToInt32(e.CommandArgument));

                //SendMails(Convert.ToInt32(e.CommandArgument));
                btnShow_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;          
        }
    }
}
