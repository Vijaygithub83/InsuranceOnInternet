using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Insurance.DAL;
/// <summary>
/// Summary description for clsNews
/// </summary>
public class clsNews:clsConnection
{
	public clsNews()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int TypeId { get; set; }
    public int NewsId { get; set; }
    public string NewsText { get; set; }
    public string Subject { get; set; }
    public DateTime NewsDate { get; set; }
    public string DocFile { get; set; }
    public byte[] DocFileContent { get; set; }
    public int UserId { get; set; }
    public int CustId { get; set; }
    public int AgentId { get; set; }

    public int InsertNewsMaster(out string outMsg)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@NewsDate", NewsDate);
            p[1] = new SqlParameter("@NewsText", NewsText);
            p[2] = new SqlParameter("@DocFile", DocFile);            
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@AgentId", AgentId);
            p[5] = new SqlParameter("@DocFileContent", DocFileContent);
            p[6] = new SqlParameter("@Subject", Subject);
         int i= SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertNewsMaster", p);
         outMsg = p[3].Value.ToString();
         return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);            
        }
    }
    //public string UpdateNewsMaster()
    //{
    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[5];
    //        p[0] = new SqlParameter("@NewsDate", NewsDate);
    //        p[1] = new SqlParameter("@NewsText", NewsText);
    //        p[2] = new SqlParameter("@NewsFile", NewsFile);
    //        p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
    //        p[3].Direction = ParameterDirection.Output;
    //        p[4] = new SqlParameter("@NewsId", NewsId);
    //        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateNewsMaster", p);
    //        return p[3].Value.ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //}
    public DataSet GetNewsByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetNewsByCustId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllNewsIds()
    {
        try
        {
            string str = "select NoticeorNewsId from tbl_NoticeorNewsMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetNewsIdsByAgent()
    {
        try
        {
            string str = "select NoticeorNewsId,Subject from tbl_NoticeorNewsMaster where AgentId="+this.AgentId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetNewsMasterDataByNewsId()
    {
        try
        {
            string str = "select * from tbl_NoticeorNewsMaster where NoticeorNewsId="+this.NewsId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string InsertNewsEmails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@NewsId", NewsId);
            p[1] = new SqlParameter("@UserId", UserId);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertNewsEmails", p);
            return p[2].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetUserIdsByAgentId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure,"sp_GetUserIdsByAgentId",p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetUsersPolicies()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetUsersPolicies", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomersByType()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@AgentId", AgentId);
            p[1] = new SqlParameter("@TypeId", TypeId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustomersByPremiumType", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
