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

public partial class Customers_frmViewComplaintsStatus : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerId"] != null)
            { 
             
            }
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            objUser.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objUser.GetComplaintsStatusByCustId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvCompStatus.DataSource = ds.Tables[0];
                GvCompStatus.DataBind();
            }
            else
            {
                lblMsg.Text = "No Data Available..";
            }
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);            
        }
    }
}
