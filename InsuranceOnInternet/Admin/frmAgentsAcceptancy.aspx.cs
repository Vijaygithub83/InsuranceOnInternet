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
public partial class Admin_frmAgentsAcceptancy : System.Web.UI.Page
{
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {

        }
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            DataSet ds = objAgent.GetAllRegdAgents();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvAgents.DataSource = ds.Tables[0];
                GvAgents.DataBind();
            }
            else
            {
                lblMsg.Text = "No Registered Agents Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    void AgentAcceptancyByAdmin(int AgentId)
    {
        DataSet ds = objAgent.UpdateAcceptancyAgentsByAdmin(AgentId);

    }

    void AgentRejectedByAdmin(int AgentId)
    {
        DataSet ds = objAgent.UpdateRejectAgentsByAdmin(AgentId);

    }
    protected void GvAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvAgents.DataSource = ds.Tables[0];
                GvAgents.DataBind();
            }
            else
            {
                lblMsg.Text = "No Registered Users Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void SendMails(int Id)
    {
        DataSet ds = (DataSet)ViewState["Data"];
        DataRow dr = ds.Tables[0].Select("UserId=" + Id)[0];

        MailMessage objMail = new MailMessage();
        objMail.From = "InsuranceOnInternet";
        objMail.To = "Localhost";
        objMail.Subject = "Status of Agents Request";
        objMail.Body = "Your Request for Agent is Accepted.. Your Email : " + dr["Email"].ToString();
        SmtpMail.SmtpServer = "LocalHost";
        SmtpMail.Send(objMail);

    }
    protected void GvAgents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Acceptancy")
            {
                objAgent.UserId = Convert.ToInt32(e.CommandArgument);
                lblMsg.Text = objAgent.AcceptUsersAsAgents();

                AgentAcceptancyByAdmin(Convert.ToInt32(e.CommandArgument));

                // SendMails(Convert.ToInt32(e.CommandArgument));
                btnShow_Click(sender, e);
            }
            else 
            {
                objAgent.UserId = Convert.ToInt32(e.CommandArgument);
                lblMsg.Text = objAgent.RejectUsersAsAgents();

                AgentRejectedByAdmin(Convert.ToInt32(e.CommandArgument));

                // SendMails(Convert.ToInt32(e.CommandArgument));
                btnShow_Click(sender, e);
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}

    
