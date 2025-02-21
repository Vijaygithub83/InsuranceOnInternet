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

public partial class Customers_frmComplaintsMaster : System.Web.UI.Page
{
    clsAgent objComplaint = new clsAgent();
    clsPayments objPayment = new clsPayments();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RadioButtonList1.SelectedIndex = 0;
            btnDelete.Visible = false;
            if (Session["CustomerId"] != null)
            {
                BindPolicyRegdIds();
                BindComplaintIds();
            }
            
        }
    }
    void ClearData()
    {
        txtComplaint.Text = "";
        //txtRegdId.Text = "";
    }
    void BindPolicyRegdIds()
    {
        try
        {

            objPayment.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objPayment.GetPoliciesByCustId();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlRegdId.DataSource = ds.Tables[0];
                ddlRegdId.DataValueField = "PolicyRegnId";
                ddlRegdId.DataTextField = "PolicyName";
                ddlRegdId.DataBind();
                ddlRegdId.Items.Insert(0, "--Select Policy--");
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

    void BindComplaintIds()
    {
        try
        {
            objPayment.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objPayment.GetComplaintsIdsByCustId();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlComplaintId.DataSource = ds.Tables[0];
                ddlComplaintId.DataValueField = "ComplaintId";
                ddlComplaintId.DataBind();
                ddlComplaintId.Items.Insert(0, "--Select Policy--");
            }
            else
            {
                lblMsg.Text = "No Records Found..";
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (RadioButtonList1.SelectedIndex == 0)
            {
                ClearData();
                grdComplaints.Visible = false;
                btnCloseGrid.Visible = false;
                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;
                if (ddlComplaintId.Items.Count != 0)
                    ddlComplaintId.SelectedIndex = 0;
                ddlComplaintId.Enabled = false;
                BindComplaintIds();
                btnDelete.Enabled = false;
                btnDelete.Visible=false;


                //ddlCompanyId.Enabled = true;

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdComplaints.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                BindComplaintIds();
                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                ddlComplaintId.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Visible = true;


            }

        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record" || btnSubmit.Text == "Submit")
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
                objComplaint.CustId = Convert.ToInt32(Session["CustomerId"]);
                objComplaint.RegdId = Convert.ToInt32(ddlRegdId.SelectedItem.Value);

                objComplaint.ComplaintText = txtComplaint.Text;
                lblMsg.Text = objComplaint.InsertComplaintsMaster();
                ClearData();
                BindComplaintIds();

            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                btnDelete.Visible = true;
                lblMsg.Text = "";
                objComplaint.ComplaintId = Convert.ToInt32(ddlComplaintId.SelectedItem.Value);
                objComplaint.RegdId = Convert.ToInt32(ddlRegdId.SelectedItem.Value);
                objComplaint.ComplaintText = txtComplaint.Text;
                lblMsg.Text = objComplaint.UpdateComplaintMaster();
                ClearData();
                ddlComplaintId.SelectedIndex = 0;

            }
            
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;            
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
        lblMsg.Text = "";
    }

    protected void grdComplaints_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdComplaints.PageIndex = e.NewPageIndex;
                grdComplaints.DataSource = ds.Tables[0];
                grdComplaints.DataBind();
                grdComplaints.Visible = true;
                btnCloseGrid.Visible = true;
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




    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();
            if (ddlComplaintId.Items.Count != 0)
                ddlComplaintId.SelectedIndex = 0;
            lblMsg.Text = "";
            objPayment.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objPayment.GetComplaintsByCustId();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdComplaints.DataSource = ds.Tables[0];
                grdComplaints.DataBind();
                grdComplaints.Visible = true;
                btnCloseGrid.Visible = true;
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

    protected void btnCloseGrid_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            grdComplaints.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlComplaintId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (ddlComplaintId.SelectedIndex != 0)
            {

                grdComplaints.Visible = false;
                btnCloseGrid.Visible = false;
                objComplaint.ComplaintId = Convert.ToInt32(ddlComplaintId.SelectedItem.Value);

                DataSet ds = objComplaint.GetComplaintIdByCustId();
                DataRow dr = ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtComplaint.Text = dr["ComplaintText"].ToString();
                }
                else
                {
                    lblMsg.Text = "No data found ..";
                }
            }
            else
            {
                ClearData();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if(RadioButtonList1.SelectedIndex == 1)
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
                objComplaint.ComplaintId = Convert.ToInt32(ddlComplaintId.SelectedItem.Value);
                lblMsg.Text = objComplaint.DeleteComplaintMaster();
                ClearData();
                ddlComplaintId.SelectedIndex = 0;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Customers/frmComplaintsMaster.aspx");
            }
            else
            {
                lblMsg.Text = "No Record Found";
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
