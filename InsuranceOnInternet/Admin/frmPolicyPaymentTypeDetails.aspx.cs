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

public partial class Admin_frmPolicyPaymentTypeDetails : System.Web.UI.Page
{
    int j;
    clsPolicy objPolicy = new clsPolicy();
    clsPayments objPayment = new clsPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnCloseGrid.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            RadioButtonList1.SelectedIndex = 0;
            BindPolicyIds();
            BindPaymentTypeIds();
        }
    }
    void ClearData()
    {
        //txtDate.Text = "";
    }
    void BindPolicyIds()
    {
        try
        {
            DataSet ds = objPolicy.GetAllPolicyIds();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPolicyId.DataSource = ds.Tables[0];
                ddlPolicyId.DataValueField = "PolicyId";
                ddlPolicyId.DataTextField = "PolicyName";
                ddlPolicyId.DataBind();
                ddlPolicyId.Items.Insert(0, "--Select One--");
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
    void BindPaymentTypeIds()
    {
        try
        {
            DataSet ds = objPayment.GetAllPaymentTypeIdsForPremium();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPayment.DataSource = ds.Tables[0];
                ddlPayment.DataValueField = "PaymentTypeId";
                ddlPayment.DataTextField = "TypeName";
                ddlPayment.DataBind();
                ddlPayment.Items.Insert(0, "--Select One--");
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
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (RadioButtonList1.SelectedIndex == 0)
            {
                if (ddlPayment.Items.Count != 0)
                    ddlPayment.SelectedIndex = 0;
                if (ddlPolicyId.Items.Count != 0)
                    ddlPolicyId.SelectedIndex = 0;
                grdPayment.Visible = false;
                btnCloseGrid.Visible = false;

                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdPayment.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();

                if (ddlPayment.Items.Count != 0)
                    ddlPayment.SelectedIndex = 0;
                if (ddlPolicyId.Items.Count != 0)
                    ddlPolicyId.SelectedIndex = 0;

                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
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
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record")
            {
                lblMsg.Text = "";

                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                objPolicy.PaymentTypeId = Convert.ToInt32(ddlPayment.SelectedItem.Value);
                
                lblMsg.Text = objPolicy.InsertPolicyPaymentTypeDetails();
                ClearData();

            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                lblMsg.Text = "";

                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                objPolicy.PaymentTypeId = Convert.ToInt32(ddlPayment.SelectedItem.Value);

                lblMsg.Text = objPolicy.UpdatePolicyPaymentTypeDetails();

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (ddlPayment.Items.Count != 0)
            ddlPayment.SelectedIndex = 0;
        if (ddlPolicyId.Items.Count != 0)
            ddlPolicyId.SelectedIndex = 0;
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();

            lblMsg.Text = "";
            DataSet ds = objPolicy.GetAllPolicyPaymentTypeData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPayment.DataSource = ds.Tables[0];
                grdPayment.DataBind();
                grdPayment.Visible = true;
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
            grdPayment.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlPolicyId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

              if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
                {
                    grdPayment.Visible = false;
                    btnCloseGrid.Visible = false;
                    objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                    //BindAgentsIds();
                    DataSet ds = objPolicy.GetPolicyPaymentTypesByPolicyId();
                    DataRow dr = ds.Tables[0].Rows[0];

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        

                        int TypeId = Convert.ToInt32(dr["PaymentTypeId"]);
                        if (TypeId > 0)
                        {
                            for (int i = 0; i < ddlPayment.Items.Count; i++)
                            {
                                if (ddlPayment.Items[i].Value == TypeId.ToString())
                                {

                                    j = i;
                                }
                                ddlPayment.Items[i].Selected = false;
                            }
                            ddlPayment.Items[j].Selected = true;
                        }
                    }
                    else
                    {
                        lblMsg.Text = "No data found ..";
                        ddlPayment.SelectedIndex = 0;
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
            ddlPayment.SelectedIndex = 0;
        }
    }
    protected void grdPayment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPayment.PageIndex = e.NewPageIndex;
                grdPayment.DataSource = ds.Tables[0];
                grdPayment.DataBind();
                grdPayment.Visible = true;
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
}
