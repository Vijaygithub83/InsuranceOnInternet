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
using System.Windows.Forms;
using System.Xml.Linq;

public partial class Admin_frmPolicyAgentsDetails : System.Web.UI.Page
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
            BindPolicyIds();
        }
        ddlAgent.Items.Insert(0, "--Select One--");
        ddlAgent.Enabled = false;
    }
    void ClearData()
    {
        txtDate.Text = "";
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
    void BindAgentsIds()
    {
        try
        {
            DataSet ds = objPolicy.GetAgentsByPolicyId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAgent.DataSource = ds.Tables[0];
                ddlAgent.DataValueField = "AgentId";
                ddlAgent.DataTextField = "FirstName";
                ddlAgent.DataBind();
                ddlAgent.Items.Insert(0, "--Select One--");
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
                if (ddlAgent.Items.Count != 0)
                    ddlAgent.SelectedIndex = 0;
                if (ddlPolicyId.Items.Count != 0)
                    ddlPolicyId.SelectedIndex = 0;
                grdPolicyAgents.Visible = false;
                btnCloseGrid.Visible = false;

                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;
                btnDelete.Enabled = false;
                btnDelete.Visible = false;

            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdPolicyAgents.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();

                if (ddlAgent.Items.Count != 0)
                    ddlAgent.SelectedIndex = 0;
                if (ddlPolicyId.Items.Count != 0)
                    ddlPolicyId.SelectedIndex = 0;

                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
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
                lblMsg.Text = "";

                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                objPolicy.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
                objPolicy.DOR = Convert.ToDateTime(txtDate.Text);

                lblMsg.Text = objPolicy.InsertPolicyAgentsDetails();
                ClearData();

            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                lblMsg.Text = "";

                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                objPolicy.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
                objPolicy.DOR = Convert.ToDateTime(txtDate.Text);

                lblMsg.Text = objPolicy.UpdatePolicyAgentsDetails();

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
        ddlPolicyId.SelectedIndex = 0;
        ddlAgent.SelectedIndex = 0;
    }
    protected void btnShowAll_Click(object sender, EventArgs e)
    {
        try
        {
            ClearData();

            lblMsg.Text = "";
            DataSet ds = objPolicy.GetAllPolicyAgentsData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPolicyAgents.DataSource = ds.Tables[0];
                grdPolicyAgents.DataBind();
                grdPolicyAgents.Visible = true;
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
            grdPolicyAgents.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void grdPolicyAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdPolicyAgents.PageIndex = e.NewPageIndex;
                grdPolicyAgents.DataSource = ds.Tables[0];
                grdPolicyAgents.DataBind();
                grdPolicyAgents.Visible = true;
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
    protected void ddlPolicyId_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            ClearData();  
            if (ddlPolicyId.SelectedIndex != 0)
            {
                if (RadioButtonList1.SelectedIndex == 0 && btnSubmit.Text == "Submit new record")
                {
                    grdPolicyAgents.Visible = false;
                    btnCloseGrid.Visible = false;
                    objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                    BindAgentsIds();
                    ddlAgent.Enabled = true;
                }
                else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
                {
                    grdPolicyAgents.Visible = false;
                    btnCloseGrid.Visible = false;
                    objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.SelectedItem.Value);
                    BindAgentsIds();
                    ddlAgent.Enabled = true;
                    DataSet ds = objPolicy.GetPolicyAgentsDataByPolicyId();
                    DataRow dr = ds.Tables[0].Rows[0];

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtDate.Text = dr["PolicyRegdDate"].ToString();

                        int AgentId = Convert.ToInt32(dr["AgentId"]);
                        if (AgentId > 0)
                        {
                            for (int i = 0; i < ddlAgent.Items.Count; i++)
                            {
                                if (ddlAgent.Items[i].Value == AgentId.ToString())
                                {

                                    j = i;
                                }
                                ddlAgent.Items[i].Selected = false;
                            }
                            ddlAgent.Items[j].Selected = true;
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
                objPolicy.PolicyId = Convert.ToInt32(ddlPolicyId.Text);
                lblMsg.Text = objPolicy.DeletePolicyAgentsDetails();

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Admin/frmPolicyAgentsDetails.aspx");
            }
            else
            {
                lblMsg.Text = "No Data Found";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}  
