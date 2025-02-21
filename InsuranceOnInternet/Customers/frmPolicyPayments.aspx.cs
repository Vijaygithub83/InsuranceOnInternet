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

public partial class Customers_frmPolicyPayments : System.Web.UI.Page
{
    int j, k;
    clsPayments objPayment = new clsPayments();
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAmount.Enabled = false;
        btnCloseGrid.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Session["CustomerId"] != null)
            {
                BindPaymentTypeIds();
                BindPolicyRegdIds();
                BindPaymentTypeIds();
            } 
            RadioButtonList1.SelectedIndex = 0;
            btnDelete.Visible= false;
            ddlPaymentId.Items.Insert(0, "--Select PaymentId--");
            ddlPaymentId.Enabled = false;
        }
    }

    void ClearData()
    {
        
        txtAmount.Text = "";
        txtBankName.Text = "";
        txtDDNo.Text = "";
        txtDDDate.Text = "";

    }

    void BindPaymentIds()
    {
        try
        {
            lblMsg.Text = "";
            DataSet ds = objPayment.GetAllPaymentIds();
            if(ds.Tables[0].Rows.Count !=0)
            {
                ddlPaymentId.DataSource = ds.Tables[0];
                ddlPaymentId.DataValueField = "PaymentId";
                ddlPaymentId.DataBind();
                ddlPaymentId.Items.Insert(0, "--Select One");
            }
            else
            {
                lblMsg.Text = " No Records Found";
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void BindPaymentTypeIds()
    {
        try
        {
            lblMsg.Text = "";
            DataSet ds = objPayment.GetAllPaymentTypeIds();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlTypeId.DataSource = ds.Tables[0];
                ddlTypeId.DataValueField = "PaymentTypeId";
                ddlTypeId.DataTextField = "TypeName";
                ddlTypeId.DataBind();
                ddlTypeId.Items.Insert(0, "--Select One--");
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


    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (RadioButtonList1.SelectedIndex == 0)
            {
                grdPayments.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;

                if (ddlPaymentId.Items.Count != 0)
                    ddlPaymentId.SelectedIndex = 0;
                if (ddlTypeId.Items.Count != 0)
                    ddlTypeId.SelectedIndex = 0;
                if (ddlRegdId.Items.Count != 0)
                    ddlRegdId.SelectedIndex = 0;

                ddlPaymentId.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdPayments.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                BindPaymentTypeIds();
                BindPaymentIds();

                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;

                if (ddlPaymentId.Items.Count != 0)
                    ddlPaymentId.SelectedIndex = 0;
                if (ddlTypeId.Items.Count != 0)
                    ddlTypeId.SelectedIndex = 0;
                if (ddlRegdId.Items.Count != 0)
                    ddlRegdId.SelectedIndex = 0;

                ddlPaymentId.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Visible=true;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlPaymentId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (ddlPaymentId.SelectedIndex != 0)
            {

                grdPayments.Visible = false;
                btnCloseGrid.Visible = false;
                objPayment.PaymentId = Convert.ToInt32(ddlPaymentId.SelectedItem.Value);

                DataSet ds = objPayment.GetPolicyPaymentMasterDataByPaymentId();
                DataRow dr = ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtAmount.Text = dr["PaymentAmount"].ToString();
                    txtBankName.Text = dr["BankName"].ToString();

                    //txtDate.Text = dr["PaymentDate"].ToString();
                    txtDDDate.Text = dr["Cheque/DDDate"].ToString();
                    txtDDNo.Text = dr["Cheque/DDNo"].ToString();
                    // txtDueDate.Text = dr["NextPremiumDueDate"].ToString();

                    int RegdId = Convert.ToInt32(dr["PolicyRegnId"]);
                    int TypeId = Convert.ToInt32(dr["PaymentTypeId"]);

                    if (TypeId > 0)
                    {
                        for (int i = 0; i < ddlTypeId.Items.Count; i++)
                        {
                            if (ddlTypeId.Items[i].Value == TypeId.ToString())
                            {
                                j = i;
                            }
                            ddlTypeId.Items[i].Selected = false;
                        }
                        ddlTypeId.Items[j].Selected = true;
                        ddlTypeId.Enabled = false;
                    }

                    if (RegdId > 0)
                    {
                        for (int i = 0; i < ddlRegdId.Items.Count; i++)
                        {
                            if (ddlRegdId.Items[i].Value == RegdId.ToString())
                            {
                                k = i;
                            }
                            ddlRegdId.Items[i].Selected = false;
                        }
                        ddlRegdId.Items[k].Selected = true;
                        ddlRegdId.Enabled = false;
                    }
                    else
                    {
                        ddlRegdId.SelectedIndex = 0;
                    }
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
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();
            if (ddlTypeId.Items.Count != 0)
                ddlTypeId.SelectedIndex = 0;
            lblMsg.Text = "";
            objPayment.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objPayment.GetAllPolicyPaymentDataByCustId();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPayments.DataSource = ds.Tables[0];
                grdPayments.DataBind();
                grdPayments.Visible = true;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record" || btnSubmit.Text == "Submit")
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";

                objPayment.CustId = Convert.ToInt32(Session["CustomerId"]);
                //objPayment.PaymentDate = Convert.ToDateTime(txtDate.Text);
                objPayment.PaymentTypeId = Convert.ToInt32(ddlTypeId.SelectedItem.Value);
                objPayment.Amount = Convert.ToDecimal(txtAmount.Text);
                objPayment.DDNo = txtDDNo.Text;
                objPayment.ChkDate = Convert.ToDateTime(txtDDDate.Text);
                objPayment.Bank = txtBankName.Text;
                objPayment.PolicyRegnId = Convert.ToInt32(ddlRegdId.SelectedItem.Value);
                //objPayment.DueDate = Convert.ToDateTime(txtDueDate.Text);


                lblMsg.Text = objPayment.InsertPolicyPaymentMaster();
                ClearData();
                BindPaymentTypeIds();
               
            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                btnDelete.Visible = true;
                lblMsg.Text = "";
                objPayment.PaymentId = Convert.ToInt32(ddlPaymentId.SelectedItem.Value);
                //objPayment.PaymentDate = Convert.ToDateTime(txtDate.Text);
                objPayment.PaymentTypeId = Convert.ToInt32(ddlTypeId.SelectedItem.Value);
                objPayment.Amount = Convert.ToDecimal(txtAmount.Text);
                objPayment.DDNo = txtDDNo.Text;
                objPayment.ChkDate = Convert.ToDateTime(txtDDDate.Text);
                objPayment.Bank = txtBankName.Text;
                objPayment.PolicyRegnId = Convert.ToInt32(ddlRegdId.SelectedItem.Value);

                //objPayment.DueDate = Convert.ToDateTime(txtDueDate.Text);


                lblMsg.Text = objPayment.UpdatePolicyPaymentMaster();
                ClearData();
                ddlPaymentId.SelectedIndex = 0;
             
                
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
        if (ddlRegdId.Items.Count != 0)
            ddlRegdId.SelectedIndex = 0;
        if (ddlTypeId.Items.Count != 0)
            ddlTypeId.SelectedIndex = 0;
        lblMsg.Text = "";
    }
    protected void btnCloseGrid_Click(object sender, EventArgs e)
    {
        grdPayments.Visible = false;
        btnCloseGrid.Visible = false;
    }
    protected void grdPayments_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPayments.PageIndex = e.NewPageIndex;
                grdPayments.DataSource = ds.Tables[0];
                grdPayments.DataBind();
                grdPayments.Visible = true;
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
    protected void ddlRegdId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            objAgent.RegdId = Convert.ToInt32(ddlRegdId.SelectedItem.Value);
            txtAmount.Text = Convert.ToString(objAgent.GetPremiumAmount());
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
                btnDelete.Visible=false;
                lblMsg.Text = "";
                objPayment.PaymentId = Convert.ToInt32(ddlPaymentId.SelectedItem.Value);
                lblMsg.Text = objPayment.DeletePolicyPaymentMaster();
                ClearData();
                ddlPaymentId.SelectedIndex = 0;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Customers/frmPolicyPayments.aspx");
            }
            else
            {
                lblMsg.Text = "Data Not Found";
            }
        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
