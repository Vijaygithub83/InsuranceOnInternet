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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        string url = Request.Url.ToString();
        string[] split = url.Split('/');
        for (int i = 0; i < split.Length; i++)
        {
            if (split[i] == "Admin")
            {
                lblLogin.Text = "Admin Login";
            }
            else if (split[i] == "Agents")
            {
                lblLogin.Text = "Agent Login";
            }
            else if (split[i] == "Customers")
            {
                lblLogin.Text = "Customer Login";
            }
           
        }
        if (Session["UserName"] != null)
        {
            FormsAuthentication.SignOut();
        }

    }
    clsLogin objLogin = new clsLogin();
    
    protected void ImgBtnEmail_Click(object sender, EventArgs e)
    {
        string str1 = null;
        string[] UserName = null;
        try
        {
            if (txtusername.Text.Contains("@"))
            {
                string str = txtusername.Text;
                UserName = str.Split('@');
                clsLogin.UserName = UserName[0].ToString();
                str1 = UserName[0].ToString();
            }
            else
            {
                clsLogin.UserName = txtusername.Text.Trim();
                str1 = txtusername.Text.Trim();
                Session["Name"] = str1;
            }
            clsLogin.Password = txtpassword.Text.Trim();
            int id;
            string Role = clsLogin.GetUserLogin(out id);

            if (Role == "NoUser")
                lblMsg.Text = "User Name and password mismatch. Try again.";
            else
            {
                Session["UserId"] =id ;

                if (Role.ToLower() == "admin")
                {
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Admin", false);
                }
                else if (Role.ToLower() == "agent")
                {
                    Session["AgentId"] = clsAgent.GetAgentIdByUserId(Convert.ToInt32(Session["UserId"]));
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Agents", false);
                }
                else if (Role.ToLower() == "customer")
                {
                    Session["CustomerId"] = clsAgent.GetCustomerIdByUserId(Convert.ToInt32(Session["UserId"]));
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Customers", false);
                }
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
