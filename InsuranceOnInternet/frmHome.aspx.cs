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

public partial class frmHome : System.Web.UI.Page
{
    clsPolicy objPolicy = new clsPolicy();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";               
        if (!IsPostBack)
        {
            DataSet ds = objPolicy.GetAllPoliciesMasterData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPolicies.DataSource = ds.Tables[0];
                gvPolicies.DataBind();
            }
        }
    }


    protected void gvPolicies_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvPolicies.PageIndex = e.NewPageIndex;
                gvPolicies.DataSource = ds.Tables[0];
                gvPolicies.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void gvPolicies_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Terms")
            {
                objPolicy.PolicyId = Convert.ToInt32(e.CommandArgument);
                DataSet ds = objPolicy.GetPolicyMasterDataByPolicyId();
                if (ds.Tables[0].Rows.Count != 0)
                {

                    string filename = ds.Tables[0].Rows[0][11].ToString();
                    if (filename != "")
                    {
                        string path = Server.MapPath(filename);
                        System.IO.FileInfo file = new System.IO.FileInfo(path);
                        if (file.Exists)
                        {
                            Response.Clear();
                            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                            Response.AddHeader("Content-Length", file.Length.ToString());
                            Response.ContentType = "application/octet-stream";
                            Response.WriteFile(file.FullName);
                            Response.End();
                        }

                        else
                        {
                            lblMsg.Text="file does not exist.";
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
