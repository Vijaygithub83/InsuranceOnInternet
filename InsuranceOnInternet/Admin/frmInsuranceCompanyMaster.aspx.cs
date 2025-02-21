using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_frmInsuranceCompanyMaster : System.Web.UI.Page
{
    clsCompany objCompany = new clsCompany();


    protected void Page_Load(object sender, EventArgs e)
    {
        btnCloseGrid.Visible = false;
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            btnDelete.Visible = false;
            RadioButtonList1.SelectedIndex = 0;
            ddlCompanyId.Items.Insert(0, "--Select Company--");
            ddlCompanyId.Enabled = false;
        }
    }
    void ClearData()
    {
        try
        {
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    void BindCompanyIds()
    {
        try
        {
            DataSet ds = objCompany.GetAllCompanyIds();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCompanyId.DataSource = ds.Tables[0];
                ddlCompanyId.DataValueField = "CompanyId";
                ddlCompanyId.DataTextField = "CompanyName";
                ddlCompanyId.DataBind();
                ddlCompanyId.Items.Insert(0, "--Select One--");
            }
            else
            {
                lblMsg.Text = "No Records Found..";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (RadioButtonList1.SelectedIndex == 0)
            {
                txtName.Focus();
                ClearData();
                grdAllCompanies.Visible = false;
                btnCloseGrid.Visible = false;
                txtName.ReadOnly = false;
                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;
                if (ddlCompanyId.Items.Count != 0)
                    ddlCompanyId.SelectedIndex = 0;
                ddlCompanyId.Enabled = false;
                BindCompanyIds();
                btnDelete.Visible = false;


                //ddlCompanyId.Enabled = true;

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdAllCompanies.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                BindCompanyIds();
                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                ddlCompanyId.Enabled = true;
                btnDelete.Visible = true;
                btnDelete.Enabled = true;


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
            if (ddlCompanyId.Items.Count != 0)
                ddlCompanyId.SelectedIndex = 0;
            lblMsg.Text = "";
            DataSet ds = objCompany.GetAllCompaniesMasterData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAllCompanies.DataSource = ds.Tables[0];
                grdAllCompanies.DataBind();
                grdAllCompanies.Visible = true;
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record" || btnSubmit.Text == "Submit")
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
                txtName.Focus();
                objCompany.CompanyName = txtName.Text;
                objCompany.Address = txtAddress.Text;
                objCompany.PhoneNo = txtPhone.Text;
                objCompany.Email = txtEmail.Text;
                lblMsg.Text = objCompany.InsertCompaniesMaster();
                BindCompanyIds();

            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                lblMsg.Text = "";
                objCompany.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);
                objCompany.CompanyName = txtName.Text;
                objCompany.Address = txtAddress.Text;
                objCompany.PhoneNo = txtPhone.Text;
                objCompany.Email = txtEmail.Text;
                lblMsg.Text = objCompany.UpdateCompaniesMaster();
                ddlCompanyId.SelectedIndex = 0;

            }

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }



    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 0)
        {
            ClearData();
            txtName.Focus();
            lblMsg.Text = "";
        }
        else
        {
            ClearData();
            ddlCompanyId.SelectedIndex = 0;
            lblMsg.Text = "";
        }
    }
    protected void btnCloseGrid_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            grdAllCompanies.Visible = false;
            btnCloseGrid.Visible = false;
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
                grdAllCompanies.Visible = true;
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
    protected void ddlCompanyId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            if (ddlCompanyId.SelectedIndex != 0)
            {

                grdAllCompanies.Visible = false;
                btnCloseGrid.Visible = false;
                objCompany.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);

                DataSet ds = objCompany.GetCompanyMasterDataByCompanyId();
                DataRow dr = ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = dr["CompanyName"].ToString();
                    txtPhone.Text = dr["PhoneNo"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
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
            if (RadioButtonList1.SelectedIndex == 1)
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
                objCompany.CompanyId = Convert.ToInt32(ddlCompanyId.Text);
                objCompany.CompanyName = string.Empty;
                objCompany.Address = string.Empty;
                objCompany.PhoneNo = string.Empty;
                objCompany.Email = string.Empty;
                lblMsg.Text = objCompany.DeleteCompaniesMaster();
                ddlCompanyId.SelectedIndex = 0;


                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Admin/frmInsuranceCompanyMaster.aspx");



            }
            else
            {
                lblMsg.Text = "No data found ..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}

