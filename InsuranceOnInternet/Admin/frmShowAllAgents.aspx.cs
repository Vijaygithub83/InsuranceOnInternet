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

public partial class Admin_frmShowAllAgents : System.Web.UI.Page
{
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    void BindData()
    {
        try
        {
            DataSet ds = objAgent.GetAllAgentsData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAgents.DataSource = ds.Tables[0];
                gvAgents.DataBind();
            }
            else
            {
                lblMsg.Text = "No Agents Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void gvAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvAgents.PageIndex = e.NewPageIndex;
                gvAgents.DataSource = ds.Tables[0];
                gvAgents.DataBind();
            }
            else
            {
                lblMsg.Text = "No Agents Available..";
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void gvAgents_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
