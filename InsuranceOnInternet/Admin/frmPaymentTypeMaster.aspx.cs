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

public partial class Admin_frmPaymentTypeMaster : System.Web.UI.Page
{
    clsPayments objPayment = new clsPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        btnCloseGrid.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            RadioButtonList1.SelectedIndex = 0;
            ddlPaymentTypeId.Items.Insert(0,"--Select One--");
            ddlPaymentTypeId.Enabled=false;
        }
    }
     void ClearData()
    {
        txtName.Text = "";
        txtAbbreviation.Text = "";
        txtDesc.Text = "";
        lblMsg.Text = "";
    }
     void BindPaymentTypeIds()
     {
         try
         {
             //lblMsg.Text = "";
             DataSet ds = objPayment.GetAllPaymentTypeIds();
             if (ds.Tables[0].Rows.Count != 0)
             {
                 ddlPaymentTypeId.DataSource = ds.Tables[0];
                 ddlPaymentTypeId.DataValueField = "PaymentTypeId";
                 ddlPaymentTypeId.DataBind();
                 ddlPaymentTypeId.Items.Insert(0, "--Select One--");
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
                txtName.Focus();
                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;

                if (ddlPaymentTypeId.Items.Count != 0)
                    ddlPaymentTypeId.SelectedIndex = 0;

                ddlPaymentTypeId.Enabled = false;
                txtName.ReadOnly = false;
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdPayments.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                BindPaymentTypeIds();

                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                ddlPaymentTypeId.Enabled = true;
            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void ddlPaymentTypeId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (ddlPaymentTypeId.SelectedIndex != 0)
            {
                //ddlIncharge.Items.Clear();
                grdPayments.Visible = false;
                btnCloseGrid.Visible = false;
                objPayment.PaymentTypeId = Convert.ToInt32(ddlPaymentTypeId.SelectedItem.Value);
                //BindIncharges();
                DataSet ds = objPayment.GetPaymentTypeMasterDataByTypeId();
                DataRow dr = ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = dr["TypeName"].ToString();
                    txtAbbreviation.Text = dr["Abbreviation"].ToString();
                    txtDesc.Text = dr["Description"].ToString();
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record")
            {
                lblMsg.Text = "";

                txtName.Focus();
                objPayment.TypeName = txtName.Text;
                objPayment.Abbreviation = txtAbbreviation.Text;
                objPayment.Description = txtDesc.Text;
                objPayment.InsertPaymentTypeMaster();
                lblMsg.Text = "Your data inserted successfully..";

                BindPaymentTypeIds();

            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                lblMsg.Text = "";

                objPayment.PaymentTypeId = Convert.ToInt32(ddlPaymentTypeId.SelectedItem.Value);
                objPayment.TypeName = txtName.Text;
                objPayment.Abbreviation = txtAbbreviation.Text;
                objPayment.Description = txtDesc.Text;
                objPayment.UpdatePaymentTypeMaster();
                lblMsg.Text = "Your data Updated successfully..";


                ddlPaymentTypeId.SelectedIndex = 0;
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
        if(ddlPaymentTypeId.Items.Count !=0)
            ddlPaymentTypeId.SelectedIndex=0;
        ddlPaymentTypeId.Enabled=false;
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();
            if (ddlPaymentTypeId.Items.Count != 0)
                ddlPaymentTypeId.SelectedIndex = 0;
            lblMsg.Text = "";
            DataSet ds = objPayment.GetAllPaymentTypeMasterData();
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

            lblMsg.Text = "Error:Contact System Admin" + ex.Message;
        }
    }
    protected void btnCloseGrid_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            grdPayments.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
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
}
