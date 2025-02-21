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

public partial class Agents_frmNoticeORNewsMaster : System.Web.UI.Page
{
    clsNews objNews = new clsNews();
    clsPayments objPayment = new clsPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AgentId"] != null)
            { 
             
            }
            //BindUserstoGrid();
            //BindPremiumTypes();
        }
    }
    void ClearData()
    {
        txtDate.Text = "";
        txtText.Text = "";
        txtSub.Text = "";
        //lbCust.Items.Clear();
    }
    string str1 = "";
    System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            byte[] data = encoding.GetBytes(str1);

            objNews.AgentId = Convert.ToInt32(Session["AgentId"]);
            objNews.NewsDate = Convert.ToDateTime(txtDate.Text);
            objNews.NewsText = txtText.Text;
            objNews.Subject = txtSub.Text;

            if (Session["DocFileContent"] != null && Session["DocFileName"] != null)
            {
                objNews.DocFileContent = (byte[])Session["DocFileContent"];
                objNews.DocFile = Session["DocFileName"].ToString();
            }
            else
            {
                objNews.DocFileContent = data;
                objNews.DocFile = "No File";
            }

            string str;
            int i = objNews.InsertNewsMaster(out str);
            if (i == 1)
            {
                lblMsg.Text = str;
                //ViewState["Id"] = "";
            }
            else
                lblMsg.Text = "Data Not Inserted.. Try again";


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
    }
   //protected void Button1_Click(object sender, EventArgs e)
   // {
   //     try
   //     {
   //         if (FileUpload1.FileName != "")
   //         {
   //             FileUpload1.SaveAs(Server.MapPath("~/Uploads/" + FileUpload1.FileName));
   //             ViewState["File"] = "~/Uploads/" + FileUpload1.FileName;
   //         }
   //     }
   //     catch (Exception ex)
   //     {
   //         lblMsg.Text = ex.Message;
   //     }
   // }
    
}
