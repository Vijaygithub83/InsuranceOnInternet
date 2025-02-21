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

public partial class Customers_frmCustomersandPolicies : System.Web.UI.Page
{

    clsAgent objAgent = new clsAgent();
    clsPayments objPayment = new clsPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtPremium.Enabled = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Session["CustomerId"] != null)
            {
                BindAgentIds();
                BindPaymentTypes();
                lbPolicyAmt.Items.Insert(0, "--Select Amount--");
                lbPolicyAmt.Enabled = false;
                lbTerm.Items.Insert(0, "--Select Term--");
                lbTerm.Enabled = false;
                ddlPolicy.Items.Insert(0, "--Select Policy--");
                ddlPolicy.Enabled = false;
                ddlPayment.Items.Insert(0, "--Select Payment--");
                ddlPayment.Enabled = false;
            }
        }
    }
    void ClearData()
    {
        txtDDNo.Text = "";
        txtChkDate.Text = "";
        txtBankName.Text = "";
        txtPremium.Text = "";
    }
    void BindAgentIds()
    {
        try
        {
            objAgent.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objAgent.GetAgentsByCustId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAgent.DataSource = ds.Tables[0];
                ddlAgent.DataValueField = "AgentId";
                ddlAgent.DataTextField = "FirstName";
                ddlAgent.DataBind();
                ddlAgent.Items.Insert(0, "--Select Agent--");
            }
            else
            {
                lblMsg.Text = "No Records found..";
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
            //objAgent.AgentId = Convert.ToInt32(Session["AgentId"]);
            DataSet ds = objAgent.GetPaymentTypesByPolicyId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPayment.DataSource = ds.Tables[0];
                ddlPayment.DataValueField = "PaymentTypeId";
                ddlPayment.DataTextField = "TypeName";
                ddlPayment.DataBind();
                ddlPayment.Items.Insert(0, "--Select PaymentType--");
            }
            else
            {
                lblMsg.Text = "No Records found..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void BindPolicyIds()
    {
        try
        {
            objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
            DataSet ds = objAgent.GetPoliciesByAgentId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPolicy.DataSource = ds.Tables[0];
                ddlPolicy.DataValueField = "PolicyId";
                ddlPolicy.DataTextField = "PolicyName";
                ddlPolicy.DataBind();
                ddlPolicy.Items.Insert(0, "--Select Policy--");
            }
            else
            {
                lblMsg.Text = "No Records found..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void BindPaymentTypes()
    {
        try
        {
            DataSet ds = objAgent.GetPaymentTypes();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPaymentAmt.DataSource = ds.Tables[0];
                ddlPaymentAmt.DataValueField = "PaymentTypeId";
                ddlPaymentAmt.DataTextField = "TypeName";
                ddlPaymentAmt.DataBind();
                ddlPaymentAmt.Items.Insert(0, "--Select Amount--");
            }
            else
            {
                lblMsg.Text = "No Records found..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAgent.SelectedIndex != 0)
            {
                lblMsg.Text = "";
                objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
                DataSet ds = objAgent.GetPoliciesByAgentId();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlPolicy.DataSource = ds.Tables[0];
                    ddlPolicy.DataValueField = "PolicyId";
                    ddlPolicy.DataTextField = "PolicyName";
                    ddlPolicy.DataBind();
                    ddlPolicy.Items.Insert(0, "--Select One--");
                    ddlPolicy.Enabled = true;
                }
                else
                {
                    lblMsg.Text = "No Records found..";
                }
            }
            else
            {
                lblMsg.Text = "";
                txtPremium.Text = "";
                ddlPayment.SelectedIndex = 0;
                ddlPolicy.SelectedIndex = 0;
                ddlPaymentAmt.SelectedIndex = 0;
                lbTerm.SelectedIndex = 0;
                lbTerm.Enabled = false;
                lbPolicyAmt.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlPolicy_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPolicy.SelectedIndex != 0)
            {
                lbPolicyAmt.Items.Clear();
                lbTerm.Items.Clear();
                lbPolicyAmt.Items.Add("--Select Amount--");
                lbTerm.Items.Add("--Select Term--");
                objAgent.PolicyId = Convert.ToInt32(ddlPolicy.SelectedItem.Value);
                BindPaymentTypeIds();
                ddlPayment.Enabled = true;
                DataSet ds = objAgent.GetPolicyRangeByPolicyId();
                DataSet dsTerm = objAgent.GetPolicyTermsRangeByPolicyId();

                DataRow dr = ds.Tables[0].Rows[0];

                int MinVal = Convert.ToInt32(dr["MinAmount"]);
                int MaxVal = Convert.ToInt32(dr["MaxAmount"]);

                while (MinVal <= MaxVal)
                {
                    lbPolicyAmt.Items.Add(MinVal.ToString());
                    MinVal = MinVal + 25000;

                    lbPolicyAmt.Enabled = true;

                }

                DataRow drTerm = dsTerm.Tables[0].Rows[0];
                int MinTerm = Convert.ToInt32(drTerm["MinTerm"]);
                int MaxTerm = Convert.ToInt32(drTerm["MaxTerm"]);

                while (MinTerm <= MaxTerm)
                {
                    lbTerm.Items.Add(MinTerm.ToString());
                    MinTerm = MinTerm + 1;

                    lbTerm.Enabled = true;
                }
            }
            else
            {
                lbTerm.SelectedIndex = 0;
                lbTerm.Enabled = false;
                lbPolicyAmt.SelectedIndex = 0;
                lbPolicyAmt.Enabled = false;
                ddlPaymentAmt.SelectedIndex = 0;
                if (ddlPayment.Items.Count != 0)
                    ddlPayment.SelectedIndex = 0;
                txtPremium.Text = "";
                lblMsg.Text = "";
                //lbPolicyAmt.Items.Add("--Select Policy--");
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    //protected void btnShowAll_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ClearData();
    //        if (ddlPolicyRegdId.Items.Count != 0)
    //            ddlPolicyRegdId.SelectedIndex = 0;
    //        if (ddlAgent.Items.Count != 0)
    //            ddlAgent.SelectedIndex = 0;
    //        if (ddlPayment.Items.Count != 0)
    //            ddlPayment.SelectedIndex = 0;
    //        lblMsg.Text = "";

    //        objAgent.CustId = Convert.ToInt32(Session["CustomerId"]);
    //        DataSet ds = objAgent.GetCustomerPolicyMasterDataByCustId();
    //        ViewState["Data"] = ds;
    //        if (ds.Tables[0].Rows.Count != 0)
    //        {
    //            grdCustPolicy.DataSource = ds.Tables[0];
    //            grdCustPolicy.DataBind();
    //            grdCustPolicy.Visible = true;
    //            btnCloseGrid.Visible = true;
    //        }
    //        else
    //        {
    //            lblMsg.Text = "No Records Found..";
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = "Error:Contact System Admin" + ex.Message;
    //    }
    //}
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
        if (ddlPolicy.Items.Count != 0)
            ddlPolicy.SelectedIndex = 0;
        //if (ddlPolicyRegdId.Items.Count != 0)
        //    ddlPolicyRegdId.SelectedIndex = 0;
        if (ddlAgent.Items.Count != 0)
            ddlAgent.SelectedIndex = 0;
        if (ddlPayment.Items.Count != 0)
            ddlPayment.SelectedIndex = 0;
        if (lbPolicyAmt.Items.Count != 0)
            lbPolicyAmt.SelectedIndex = 0;
        if (lbTerm.Items.Count != 0)
            lbTerm.SelectedIndex = 0;
        lbPolicyAmt.Enabled = false;
        lbTerm.Enabled = false;
        ddlPayment.Enabled = false;
        pnl1.Visible = false;
    }
    //protected void btnCloseGrid_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        lblMsg.Text = "";
    //        grdCustPolicy.Visible = false;
    //        btnCloseGrid.Visible = false;
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}
    //protected void grdCustPolicy_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        DataSet ds = (DataSet)ViewState["Data"];
    //        if (ds.Tables[0].Rows.Count != 0)
    //        {
    //            grdCustPolicy.PageIndex = e.NewPageIndex;
    //            grdCustPolicy.DataSource = ds.Tables[0];
    //            grdCustPolicy.DataBind();
    //            grdCustPolicy.Visible = true;
    //            btnCloseGrid.Visible = true;
    //        }
    //        else
    //        {
    //            lblMsg.Text = "No Records Found..";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}
    protected void lbTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPayment.SelectedIndex != 0 && lbPolicyAmt.SelectedItem != null)
            {
                if (lbTerm.SelectedIndex != 0)
                {
                    objAgent.Amount = Convert.ToDecimal(lbPolicyAmt.SelectedItem.Value);
                    objAgent.PaymentTypeId = Convert.ToInt32(ddlPayment.SelectedItem.Value);
                    objAgent.PolicyTerm = Convert.ToInt32(lbTerm.SelectedItem.Value);
                    txtPremium.Text = Convert.ToString(objAgent.GetPremium());
                }
            }
            else
            {
                lblMsg.Text = "select PaymentType and PolicyAmount ..";
                txtPremium.Text = "";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            objAgent.CustId = Convert.ToInt32(Session["CustomerId"]);
            objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
            objAgent.PolicyId = Convert.ToInt32(ddlPolicy.SelectedItem.Value);
            objAgent.PaymentTypeId = Convert.ToInt32(ddlPayment.SelectedItem.Value);
            objAgent.Amount = Convert.ToDecimal(lbPolicyAmt.SelectedItem.Value);
            objAgent.PolicyTerm = Convert.ToInt32(lbTerm.SelectedItem.Value);
            objAgent.PremiumConfirm = Convert.ToDecimal(txtPremium.Text);

            objAgent.AmtPaymentTypeId = Convert.ToInt32(ddlPaymentAmt.SelectedItem.Value);
            objAgent.DDNo = txtDDNo.Text;
            objAgent.ChkDate = Convert.ToDateTime(txtChkDate.Text);
            objAgent.BankName = txtBankName.Text;

            lblMsg.Text = objAgent.InsertCustomerPolicyMaster();
            ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtDDNo.Text = "";
        txtChkDate.Text = "";
        txtBankName.Text = "";
        lblMsg.Text = "";
        if (ddlPayment.Items.Count != 0)
            ddlPayment.SelectedIndex = 0;
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            pnl1.Visible = true;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
