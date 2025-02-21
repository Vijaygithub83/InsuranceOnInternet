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

public partial class Agents_frmViewCustomerComplaints : System.Web.UI.Page
{ 
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblReply.Visible = false;
            if (Session["AgentId"] != null)
            { 
             
            }
        }
    }
    protected void GvComplaints_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
           
            DataSet ds = (DataSet)ViewState["Data"];
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvComplaints.PageIndex = e.NewPageIndex;
                GvComplaints.DataSource = ds.Tables[0];
                GvComplaints.DataBind();
            }
            else
            {
                lblMsg.Text = "No Records Found..";
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
            objAgent.AgentId = Convert.ToInt32(Session["AgentId"]);
            DataSet ds = objAgent.GetCustComplaintsByAgentId();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvComplaints.DataSource = ds.Tables[0];
                GvComplaints.DataBind();
            }
            else
            {
                lblMsg.Text = "No Records Found..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void GvComplaints_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Reply")
            {
                tblReply.Visible = true;
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["Id"] = id;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
             objAgent.ComplaintId =Convert.ToInt32 (ViewState["Id"]);
             objAgent.AnswerText = txtAnswer.Text;
             lblMsg.Text = objAgent.UpdateComplaintsMaster();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
