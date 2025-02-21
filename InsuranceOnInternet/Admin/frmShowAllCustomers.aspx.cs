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

public partial class Admin_frmShowAllCustomers : System.Web.UI.Page
{
    clsUser objCust = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnPrint.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
           // BindData();
        }
    }
    //void BindData()
    //{
    //    try
    //    {
    //        DataSet ds = objCust.GetAllCustomersData();
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            gvCust.DataSource = ds.Tables[0];
    //            gvCust.DataBind();
    //        }
    //        else
    //        {
    //            lblMsg.Text = "No Customers Available..";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}
    protected void gvCust_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCust.PageIndex = e.NewPageIndex;
                gvCust.DataSource = ds.Tables[0];
                gvCust.DataBind();
                btnPrint.Visible = true;
            }
            else
            {
                lblMsg.Text = "No Customers Available..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            btnPrint.Visible = false;
            lblMsg.Text = "";
            txtDate.Text = "";
            gvCust.Visible = false;

            DataSet ds = objCust.GetAllCustomersData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCust.DataSource = ds.Tables[0];
                gvCust.DataBind();
                gvCust.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                lblMsg.Text = "No Customers Available..";
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
            gvCust.Visible = false;
            btnPrint.Visible = false;
            lblMsg.Text = "";

            objCust.DOR = Convert.ToDateTime(txtDate.Text);
            DataSet ds = objCust.GetCustomersDataByDate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvCust.DataSource = ds.Tables[0];
                gvCust.DataBind();
                gvCust.Visible = true;
                btnPrint.Visible = true;
            }
            else
            {
                lblMsg.Text = "No Customers Registered on this Date..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
