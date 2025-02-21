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

public partial class frmUserRegistration : System.Web.UI.Page
{
    clsUser objUser = new clsUser();
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtAgentAddress.Visible = true;
               
        if (!IsPostBack)
        {
            BindAgentsIds();
        }
    }
    void ClearData()
    {
        txtName.Text = "";
        txtMName.Text = "";
        txtLName.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtAgentAddress.Text = "";
        txtDOB.Text = "";
        //lblDOR.Text = "";
        BrowseImage1.Clearimage();
        
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
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objUser.UserName = txtUserName.Text;
            objUser.Password = txtPassword.Text;
            objUser.FirstName = txtName.Text;
            objUser.MiddleName = txtMName.Text;
            objUser.LastName = txtLName.Text;
            objUser.Address = txtAddress.Text;
            objUser.PhoneNo = txtPhone.Text;
            objUser.Email = txtEmail.Text;
            objUser.Image = (byte[])Session["Photo"];
            objUser.FileName = Convert.ToString(Session["FileName"]);
            objUser.DOB = Convert.ToDateTime(txtDOB.Text);
            objUser.DOR = Convert.ToDateTime(System.DateTime.Now.ToLongDateString().ToString());
            objUser.AgentId = Convert.ToInt32(ddlAgent.SelectedItem.Value);
            objUser.Role = "Customer";
            lblMsg.Text = objUser.InsertUserRegistration();
            ClearData();
            ddlAgent.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;            
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
        lblMsg.Text = "";
        ddlAgent.SelectedIndex = 0;
    }
    protected void ddlAgent_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlAgent.SelectedIndex != 0)
            {
                objAgent.AgentId=Convert.ToInt32(ddlAgent.SelectedItem.Value);
                DataSet ds = objAgent.GetAgentAddressByAgentId();
                DataRow dr=ds.Tables[0].Rows[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtAgentAddress.Text = dr["Address"].ToString();
                    txtAgentAddress.Visible = true;
                }
                else
                {
                    lblMsg.Text = "No Records Found..";
                }
            }
            else
            {
                txtAgentAddress.Visible = false;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
