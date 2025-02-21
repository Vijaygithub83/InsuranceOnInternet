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

public partial class frmAgentRegistration : System.Web.UI.Page
{
    clsAgent objAgent = new clsAgent();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
          
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
        txtDOB.Text = "";
        //lblDOR.Text = "";
        BrowseImage1.Clearimage();

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objAgent.UserName = txtUserName.Text;
            objAgent.Password = txtPassword.Text;
            objAgent.FirstName = txtName.Text;
            objAgent.MiddleName = txtMName.Text;
            objAgent.LastName = txtLName.Text;
            objAgent.Address = txtAddress.Text;
            objAgent.PhoneNo = txtPhone.Text;
            objAgent.Email = txtEmail.Text;
            objAgent.Image = (byte[])Session["Photo"];
            objAgent.FileName = Convert.ToString(Session["FileName"]);
            objAgent.DOB = Convert.ToDateTime(txtDOB.Text);
            objAgent.DOR = Convert.ToDateTime( System.DateTime.Now.ToLongDateString().ToString());
            objAgent.Role = "UserA";
            lblMsg.Text = objAgent.InsertAgentRegistration();
            ClearData();
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
