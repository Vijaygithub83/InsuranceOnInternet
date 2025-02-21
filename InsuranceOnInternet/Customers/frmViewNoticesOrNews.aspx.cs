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

public partial class Customers_frmViewNoticesOrNews : System.Web.UI.Page
{
    clsNews objNews = new clsNews();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CustomerId"] != null)
            {
                BindData();
            }
        }
    }
    protected void GvNews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "NewsFile")
            {
                objNews.NewsId = Convert.ToInt32(e.CommandArgument);
                DataSet ds = objNews.GetNewsMasterDataByNewsId();
                byte[] FileContent = (byte[])ds.Tables[0].Rows[0][5];
                string FileName = (string)ds.Tables[0].Rows[0][4];
                string[] fileSplit = FileName.Split('.');
                int Loc = fileSplit.Length;
                string FileExtention = "." + fileSplit[Loc - 1].ToUpper();

                int i = 0;
                if (FileExtention == ".DOC" || FileExtention == ".DOCX")
                {
                    Response.ContentType = "application/vnd.ms-word";
                    Response.AddHeader("content-disposition", "inline;filename=" + FileName);
                    i = 1;
                }
                else if (FileExtention == ".XL" || FileExtention == ".XLS" || FileExtention == ".XLSX")
                {
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("content-disposition", "inline;filename=" + FileName);
                    i = 1;
                }
                else if (FileExtention == ".PDF")
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline;filename=" + FileName);
                    i = 1;
                }
                else if (FileExtention == ".TXT")
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AddHeader("content-disposition", "inline;filename=" + FileName);
                    i = 1;
                }
                if (i == 1)
                {
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(FileContent);
                    Response.End();
                }
                else
                    lblMsg.Text = "No File Attached..";
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        
    }
    void BindData()
    {
        try
        {
            objNews.CustId = Convert.ToInt32(Session["CustomerId"]);
            DataSet ds = objNews.GetNewsByCustId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GvNews.DataSource = ds.Tables[0];
                GvNews.DataBind();
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
    //protected void GvNews_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}
