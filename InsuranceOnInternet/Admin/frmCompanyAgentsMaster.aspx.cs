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

public partial class Admin_frmCompanyAgentsMaster : System.Web.UI.Page
{
    int j;
    clsCompany objCompany = new clsCompany();
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        grdAgents.Visible = false;
        btnCloseGrid.Visible = false;
        if (!IsPostBack)
        {
            btnDelete.Visible = false;
            RadioButtonList1.SelectedIndex = 0;
            BindCompanyIds();
            BindAgentsIds();

        }
       
    }
    void ClearData()
    {
        //txtDate.Text = "";
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
                ddlCompanyId.DataTextField="CompanyName";
                ddlCompanyId.DataBind();
                ddlCompanyId.Items.Insert(0, "--Select One--");
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
            DataSet ds = objAgent.GetAllAgents();
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
                if(ddlAgent.Items.Count !=0)
                ddlAgent.SelectedIndex = 0;
                if (ddlCompanyId.Items.Count != 0)
                    ddlCompanyId.SelectedIndex = 0;

                btnSubmit.Text = "Submit new record";
                btnSubmit.Enabled = true;
                btnDelete.Visible = false;
             
                
            }
            else if (RadioButtonList1.SelectedIndex == 1)
            {

                grdAgents.Visible = false;
                btnCloseGrid.Visible = false;
                ClearData();

                if (ddlAgent.Items.Count != 0)
                    ddlAgent.SelectedIndex = 0;
                if (ddlCompanyId.Items.Count != 0)
                    ddlCompanyId.SelectedIndex = 0;

                btnSubmit.Text = "Modify record";
                btnSubmit.Enabled = true;
                btnDelete.Visible = true;
                btnDelete.Enabled=true;
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
            if (RadioButtonList1.SelectedIndex == 0 && (btnSubmit.Text == "Submit new record" || btnSubmit.Text == "Submit"))
            {
                btnDelete.Visible = false;
                lblMsg.Text = "";
              
                objAgent.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);
                objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
                //objAgent.DOR = Convert.ToDateTime(txtDate.Text);

                lblMsg.Text = objAgent.InsertCompanyAgentsMaster();
                ClearData();
                
            }

            else if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                lblMsg.Text = "";

                objAgent.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);
                objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
                //objAgent.DOR = Convert.ToDateTime(txtDate.Text);

               lblMsg.Text = objAgent.UpdateCompanyAgentsMaster();
                
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
            
            lblMsg.Text = "";
            DataSet ds = objAgent.GetAllCompanyAgentsData();
            ViewState["Data"] = ds;
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAgents.DataSource = ds.Tables[0];
                grdAgents.DataBind();
                grdAgents.Visible = true;
                btnCloseGrid.Visible = true;
            }
            else
            {
                lblMsg.Text = "No Records Found..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text =  ex.Message;
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        ClearData();
        lblMsg.Text = "";
        ddlCompanyId.SelectedIndex = 0;
        ddlAgent.SelectedIndex = 0;
    }
    protected void btnCloseGrid_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            grdAgents.Visible = false;
            btnCloseGrid.Visible = false;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void grdAgents_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            DataSet ds = (DataSet)ViewState["Data"];
            if (ds.Tables[0].Rows.Count != 0)
            {
                grdAgents.PageIndex = e.NewPageIndex;
                grdAgents.DataSource = ds.Tables[0];
                grdAgents.DataBind();
                grdAgents.Visible = true;
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
            if (RadioButtonList1.SelectedIndex == 1 && btnSubmit.Text == "Modify record")
            {
                if (ddlCompanyId.SelectedIndex != 0)
                {

                    grdAgents.Visible = false;
                    btnCloseGrid.Visible = false;
                    objAgent.CompanyId = Convert.ToInt32(ddlCompanyId.SelectedItem.Value);

                    DataSet ds = objAgent.GetCompanyAgentsDataByCompanyId();
                    DataRow dr = ds.Tables[0].Rows[0];
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        //txtDate.Text = dr["RegisteredDate"].ToString();

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
            if(RadioButtonList1.SelectedIndex == 1)
            {
                btnDelete.Visible=false;
                lblMsg.Text = "";

                objAgent.CompanyId = Convert.ToInt32(ddlCompanyId.Text);
                //objAgent.DOR = Convert.ToDateTime(txtDate.Text);

                lblMsg.Text = objAgent.DeleteCompanyAgentsMaster();

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

                Response.Redirect("~/Admin/frmCompanyAgentsMaster.aspx");
            }
            else
            {
                lblMsg.Text = "No data found ..";
            }

        }
        catch(Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }

    protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        objAgent.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
    }
}
