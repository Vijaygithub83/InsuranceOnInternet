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

public partial class Admin_frmCompaniesReportaspx : System.Web.UI.Page
{
    clsCompany objCompany = new clsCompany();
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
        DataSet ds = objCompany.GetAllCompaniesMasterData();
        ViewState["Data"] = ds;
        if (ds.Tables[0].Rows.Count != 0)
        {
            grdAllCompanies.DataSource = ds.Tables[0];
            grdAllCompanies.DataBind();            
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
    protected void grdAllCompanies_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAllCompanies.PageIndex = e.NewPageIndex;
                grdAllCompanies.DataSource = ds.Tables[0];
                grdAllCompanies.DataBind();               
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
}
