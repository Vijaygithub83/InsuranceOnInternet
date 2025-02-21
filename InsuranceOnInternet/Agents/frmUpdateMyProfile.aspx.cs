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

public partial class Agents_frmUpdateMyProfile : System.Web.UI.Page
{
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AgentId"] != null)
            {
                GetPersonalDetails();
            }
            
        }
    }
    void ClearData()
    {
        txtAddress.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
    }
    void GetPersonalDetails()
    {
         objAgent.AgentId = Convert.ToInt32(Session["AgentId"]);
        DataSet ds=objAgent.GetAgentDetails();
        DataRow dr=ds.Tables[0].Rows[0];
        if(ds.Tables[0].Rows.Count >0)
        {
            txtEmail.Text = dr["Email"].ToString();
            txtAddress.Text = dr["Address"].ToString();
            txtPhone.Text = dr["PhoneNo"].ToString();
            BrowseImage1.BindImage(dr["FileName"].ToString(), (byte[])dr["Image"]);            
            
        }
        
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            objAgent.AgentId = Convert.ToInt32(Session["AgentId"]);
            objAgent.PhoneNo = txtPhone.Text;
            objAgent.Email = txtEmail.Text;
            objAgent.Address = txtAddress.Text;
            objAgent.Image = (byte[])Session["Photo"];
            objAgent.FileName = Convert.ToString(Session["FileName"]);
            lblMsg.Text =objAgent. UpdateAgentProfile();
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
    }
}
