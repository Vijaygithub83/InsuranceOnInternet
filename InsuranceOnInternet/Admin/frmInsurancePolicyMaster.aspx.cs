using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.MobileControls.Adapters;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_frmInsurancePolicyMaster : System.Web.UI.Page
{
    clsPolicy objPolicy = new clsPolicy();
    int j;
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
            ddlPolicyId.Items.Insert(0, "--Select Policy--");
            ddlPolicyId.Enabled = false;
        }
        
    }
    void ClearData()
    {
        txtCovAmt.Text = "";
        txtEndDate.Text = "";
        txtLaunchDate.Text = "";
        txtMaxAge.Text = "";
        txtMinAge.Text = "";
        txtMinAmount.Text = "";
        txtMaxAmount.Text = "";
        txtMinTerm.Text = "";
        txtMaxTerm.Text = "";
        txtName.Text = "";
    
    }
    void BindCompanyIds()
    {
        try
        {
            DataSet ds = objPolicy.GetAllCompanyIds();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCompanyId.DataSource = ds.Tables[0];
                ddlCompanyId.DataValueField = "CompanyId";
                ddlCompanyId.DataTextField="CompanyName";
                ddlCompanyId.DataBind();
                ddlCompanyId.Items.Insert(0, "--Select Company--");
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
    void BindPolicyIds()
    {
        try
        {
            DataSet ds = objPolicy.GetAllPolicyIds();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPolicyId.DataSource = ds.Tables[0];
                ddlPolicyId.DataValueField = "PolicyId";
                //ddlPolicyId.DataTextField = "PolicyName";
                ddlPolicyId.DataBind();
                ddlPolicyId.Items.Insert(0, "--Select Policy--");
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
                txtName.Focus();
                ClearData();
                grdAllPolicies.Visible = false;
                btnCloseGrid.Visible = false;
                txtName.ReadOnly = false;
                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;
                if (ddlPolicyId.Items.Count != 0)
                    ddlPolicyId.SelectedIndex = 0;
                ddlPolicyId.Enabled = false;
                BindCompanyIds();
                ddlCompanyId.Enabled = true;
                btnDelete.Enabled = false;
                btnDelete.Visible= false;
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {
                txtName.ReadOnly = true;
                grdAllPolicies.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();
                BindCompanyIds();
                ddlCompanyId.Enabled = false;
                BindPolicyIds();
                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                ddlPolicyId.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
            }

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
            lblMsg.Text = "";
            if (ddlPolicyId.SelectedIndex != 0)
            {

                grdAllPolicies.Visible = false;
                btnCloseGrid.Visible = false;
                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);

                DataSet ds = objPolicy.GetPolicyMasterDataByPolicyId();
                DataRow dr = ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = dr["PolicyName"].ToString();
                    txtLaunchDate.Text = dr["LaunchDate"].ToString();
                    txtEndDate.Text = dr["EndDate"].ToString();
                    txtMinAge.Text = dr["MinAge"].ToString();
                    txtMaxAge.Text = dr["MaxAge"].ToString();
                    txtMinAmount.Text = dr["MinAmount"].ToString();
                    txtMaxAmount.Text = dr["MaxAmount"].ToString();
                    txtMinTerm.Text = dr["MinTerm"].ToString();
                    txtMaxTerm.Text = dr["MaxTerm"].ToString();
                    txtCovAmt.Text = dr["CoverageAmount%"].ToString();

                    int CompanyId = Convert.ToInt32(dr["CompanyId"]);

                    if (CompanyId > 0)
                    {
                        for (int i = 0; i < ddlCompanyId.Items.Count; i++)
                        {
                            if (ddlCompanyId.Items[i].Value==CompanyId.ToString())
                            {
                                j = i;
                            }
                            ddlCompanyId.Items[i].Selected = false;
                        }
                        ddlCompanyId.Items[j].Selected = true;
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
    string str1 = "";
    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record" || btnSubmit.Text == "Submit")
            {
                lblMsg.Text = "";
                byte[] data = encoding.GetBytes(str1);

                txtName.Focus();
                objPolicy.PolicyName = txtName.Text;
                objPolicy.LaunchDate =Convert.ToDateTime( txtLaunchDate.Text);
                objPolicy.EndDate =Convert.ToDateTime( txtEndDate.Text);
                objPolicy.MinAge =Convert.ToInt32(txtMinAge.Text);
                objPolicy.MaxAge = Convert.ToInt32(txtMaxAge.Text);
                objPolicy.MinAmount = Convert.ToDecimal(txtMinAmount.Text);
                objPolicy.MaxAmount = Convert.ToDecimal(txtMaxAmount.Text);
                objPolicy.MinTerm = txtMinTerm.Text;
                objPolicy.MaxTerm = txtMaxTerm.Text;
                objPolicy.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);
                objPolicy.CoverageAmount = Convert.ToInt32(txtCovAmt.Text);

                if (Session["DocFileContent"] != null && Session["DocFileName"] != null)
                {
                    objPolicy.TermsFileContent = (byte[])Session["DocFileContent"];
                    objPolicy.TermsFile = Session["DocFileName"].ToString();
                }
                else
                {
                    objPolicy.TermsFileContent = data;
                    objPolicy.TermsFile = "No File";
                }

                if (Session["PDFFileContent"] != null && Session["PDFFileName"] != null)
                {
                    objPolicy.BrochureFileContent = (byte[])Session["PDFFileContent"];
                    objPolicy.BrochureFile = Session["PDFFileName"].ToString();
                }
                else
                {
                    objPolicy.BrochureFileContent = data;
                    objPolicy.BrochureFile = "No File";
                }

                string str;
                string i = objPolicy.InsertPolicyMaster(out str);
                if (i != "")
                {
                    lblMsg.Text = str;
                    //ViewState["Id"] = "";
                }
                else
                    lblMsg.Text = "Data Not Inserted.. Try again";              
                ClearData();
                BindCompanyIds();
                ddlCompanyId.SelectedIndex = 0;
                
            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                btnDelete.Visible=false;
                lblMsg.Text = "";
                byte[] data = encoding.GetBytes(str1);

                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                //objPolicy.PolicyName = txtName.Text;
                objPolicy.LaunchDate = Convert.ToDateTime(txtLaunchDate.Text);
                objPolicy.EndDate = Convert.ToDateTime(txtEndDate.Text);
                objPolicy.MinAge = Convert.ToInt32(txtMinAge.Text);
                objPolicy.MaxAge = Convert.ToInt32(txtMaxAge.Text);
                objPolicy.MinAmount = Convert.ToDecimal(txtMinAmount.Text);
                objPolicy.MaxAmount = Convert.ToDecimal(txtMaxAmount.Text);
                objPolicy.MinTerm = txtMinTerm.Text;
                objPolicy.MaxTerm = txtMaxTerm.Text;
                //objPolicy.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);
                objPolicy.CoverageAmount = Convert.ToInt32(txtCovAmt.Text);

                if (Session["DocFileContent"] != null && Session["DocFileName"] != null)
                {
                    objPolicy.TermsFileContent = (byte[])Session["DocFileContent"];
                    objPolicy.TermsFile = Session["DocFileName"].ToString();
                }
                else
                {
                    objPolicy.TermsFileContent = data;
                    objPolicy.TermsFile = "No File";
                }

                if (Session["PDFFileContent"] != null && Session["PDFFileName"] != null)
                {
                    objPolicy.BrochureFileContent = (byte[])Session["PDFFileContent"];
                    objPolicy.BrochureFile = Session["PDFFileName"].ToString();
                }
                else
                {
                    objPolicy.BrochureFileContent = data;
                    objPolicy.BrochureFile = "No File";
                }

                string str;
                int i = objPolicy.UpdatePolicyMaster(out str);
                if (i == 1)
                {
                    lblMsg.Text = str;
                    //ViewState["Id"] = "";
                }
                else
                    lblMsg.Text = "Data Not Updated.. Try again";
                

                ClearData();
                ddlCompanyId.SelectedIndex = 0;
                ddlPolicyId.SelectedIndex = 0;
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
        if (ddlCompanyId.Items.Count != 0)
            ddlCompanyId.SelectedIndex = 0;
        ddlCompanyId.Enabled = false;
        if (ddlPolicyId.Items.Count != 0)
            ddlPolicyId.SelectedIndex = 0;
        ddlPolicyId.Enabled = false;
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();
            if (ddlPolicyId.Items.Count != 0)
                ddlPolicyId.SelectedIndex = 0;
            lblMsg.Text = "";
            DataSet ds = objPolicy.GetAllPoliciesMasterData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAllPolicies.DataSource = ds.Tables[0];
                grdAllPolicies.DataBind();
                grdAllPolicies.Visible = true;
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
            grdAllPolicies.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void grdAllPolicies_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAllPolicies.PageIndex = e.NewPageIndex;
                grdAllPolicies.DataSource = ds.Tables[0];
                grdAllPolicies.DataBind();
                grdAllPolicies.Visible = true;
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


    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.Text);
                ddlCompanyId.SelectedIndex = 0;
                string str;
                int i = objPolicy.DeletePolicyMaster(out str);
                if (i == 1)
                {
                    lblMsg.Text = str;
                    //ViewState["Id"] = "";
                }
                else
                    lblMsg.Text = "Data Not Deleted.. Try again";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Admin/frmInsurancePolicyMaster.aspx");
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
