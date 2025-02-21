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
using Insurance.DAL;
using System.Data.SqlClient;
/// <summary>
/// Summary description for clsLogin
/// </summary>
public class clsLogin:clsConnection
{
	public clsLogin()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static  string UserName { get; set; }
    public static string Password { get; set; }
    public static string Role { get; set; }
    public static int CustId { get; set; }
    public static int EmpId { get; set; }
    public static int UserId { get; set; }
    public int BookedId { get; set; }
    public string  ReachDate {get; set;}
    public string ReachTime { get; set; }

    public int RegdUserId { get; set; }
    public int CustomerId { get; set; }
    public int AgentId { get; set; }
    public string OldPwd { get; set; }
    public string NewPwd { get; set; }
    public string ConfirmPwd { get; set; }

    public static string GetUserLogin(out int Id)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];

            p[0] = new SqlParameter("@UserName", UserName);
            p[1] = new SqlParameter("@Password", Password );
            p[2] = new SqlParameter("@Role", SqlDbType.VarChar,20);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@UserId", SqlDbType.Int);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "spLoginChecking", p);
            Id = Convert.ToInt32(p[3].Value);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string ChangePassword()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@OldPwd", OldPwd);
            p[1] = new SqlParameter("@NewPwd", NewPwd);
            p[2] = new SqlParameter("@ConfirmPwd", ConfirmPwd);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@UserId", RegdUserId);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_ChangePassword", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int GetUserIdByAgentId()
    {
        try
        {
            string str = "select userid from tbl_AgentsMaster where AgentId=" + this.AgentId;
            int i = (int)SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public int GetUserIdByCustomerId()
    {
        try
        {
            string str = "select userid from tbl_CustomersMaster where CustomerId=" + this.CustomerId;
            int i = (int)SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str);
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }








    //public  DataSet GetEmpCargoStatus(int EmpId)
    //{
    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[1];
    //        p[0] = new SqlParameter("@EmpId", EmpId);
    //        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetEmpCargoStatus", p);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);     
    //    }
    //}
    //public DataSet GetEmpCargoDispatchStatus(int EmpId)
    //{
    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[1];
    //        p[0] = new SqlParameter("@EmpId", EmpId);
    //        return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetEmpCargoDispatchStatus", p);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);
    //    }
    //}
    //public void UpdateReachStatusByBookedId()
    //{
    //    try
    //    {
    //        SqlParameter[] p = new SqlParameter[4];
    //        p[0] = new SqlParameter("@BookedId", BookedId);
    //        p[1] = new SqlParameter("@ReachDate", ReachDate);
    //        p[2] = new SqlParameter("@Time", ReachTime);
    //        p[3] = new SqlParameter("@EmpId", EmpId);
    //        SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateReachStatusByBookedId", p);
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new ArgumentException(ex.Message);      
    //    }
    //}
}
