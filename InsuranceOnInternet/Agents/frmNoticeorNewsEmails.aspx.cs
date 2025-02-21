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

public partial class Agents_frmNoticeorNewsEmails : System.Web.UI.Page
{
    clsNews objNews = new clsNews();
    clsAgent objAgent = new clsAgent();
    clsPayments objPayment = new clsPayments();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            if (Session["AgentId"] != null)
            { 
            
            }
            //BindCustomerIds();
            BindNewsIds();
            BindPremiumTypes();
        }
    }
    
    void BindNewsIds()
    {
        try
        {
            objNews.AgentId = Convert.ToInt32(Session["AgentId"]);
            DataSet ds = objNews.GetNewsIdsByAgent();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlNewsId.DataSource = ds.Tables[0];
                ddlNewsId.DataValueField = "NoticeorNewsId";
                ddlNewsId.DataTextField = "Subject";
                ddlNewsId.DataBind();
                ddlNewsId.Items.Insert(0, "--Select Subject--");
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
    void ClearData()
    {
        lbCust.Items.Clear();
    }
    //void BindCustomerIds()
    //{
    //    try
    //    {
    //        objAgent.AgentId=Convert.ToInt32(Session["AgentId"]);
    //        DataSet ds = objAgent.GetCustomersByAgentId();
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            ddlCust.DataSource = ds.Tables[0];
    //            ddlCust.DataValueField = "CustomerId";
    //            ddlCust.DataTextField = "FirstName";
    //            ddlCust.DataBind();
    //            ddlCust.Items.Insert(0, "--Select One--");
    //        }
    //        else
    //        {
    //            lblMsg.Text = "No Records Found..";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMsg.Text = ex.Message;
    //    }
    //}
    void BindPremiumTypes()
    {
        try
        {
            DataSet ds = objPayment.GetAllPaymentTypeIdsForPremium();
            if (ds.Tables[0].Rows.Count != 0)
            {
                ddlType.DataSource = ds.Tables[0];
                ddlType.DataValueField = "PaymentTypeId";
                ddlType.DataTextField = "TypeName";
                ddlType.DataBind();
                ddlType.Items.Insert(0, "--Select One--");
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

            for (int i = 0; i < lbCust.Items.Count; i++)
            {
                objNews.NewsId = Convert.ToInt32(ddlNewsId.SelectedItem.Value);
                objNews.UserId = Convert.ToInt32(lbCust.Items[i].Value);
                 objNews.InsertNewsEmails();
            }
            lblMsg.Text = "Data Inserted Successfully..";
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message; 
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (ddlType.Items.Count != 0)
            ddlType.SelectedIndex = 0;
        
        if(ddlNewsId.Items.Count !=0)
        ddlNewsId.SelectedIndex = 0;
        lbCust.Items.Clear();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlType.SelectedIndex != 0)
            {
                lblMsg.Text = "";
                ClearData();
                objNews.AgentId = Convert.ToInt32(Session["AgentId"]);
                objNews.TypeId = Convert.ToInt32(ddlType.SelectedItem.Value);
                DataSet ds = objNews.GetCustomersByType();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbCust.DataSource = ds.Tables[0];
                    lbCust.DataTextField = "UserName";
                    lbCust.DataValueField = "UserId";
                    lbCust.DataBind();
                }
                else
                {
                    lblMsg.Text = "No Customers Available in this Type of Premium..";
                }
            }
            else
            {
                lbCust.Items.Clear();
                lblMsg.Text = "";
                ddlNewsId.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
}
