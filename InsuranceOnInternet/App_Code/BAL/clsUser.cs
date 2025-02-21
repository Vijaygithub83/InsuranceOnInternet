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
/// Summary description for clsUser
/// </summary>
public class clsUser:clsConnection
{
	public clsUser()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CustId { get; set; }
    public int AgentId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PhoneNo { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime DOB { get; set; }
    public byte[] Image { get; set; }
    public string  FileName { get; set; }
    public DateTime DOR { get; set; }
    public string Role { get; set; }

    public string InsertUserRegistration()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@UserName", UserName);
            p[1] = new SqlParameter("@Password", Password);
            p[2] = new SqlParameter("@FirstName", FirstName);
            p[3] = new SqlParameter("@MiddleName", MiddleName);
            p[4] = new SqlParameter("@LastName", LastName);
            p[5] = new SqlParameter("@Email", Email);
            p[6] = new SqlParameter("@Address", Address);
            p[7] = new SqlParameter("@Phone", PhoneNo);
            p[8] = new SqlParameter("@DOB", DOB);
            p[9] = new SqlParameter("@DOR", DOR);
            p[10] = new SqlParameter("@Image", Image);
            p[11] = new SqlParameter("@FileName", FileName);
           p[12]=new SqlParameter ("@Message",SqlDbType.VarChar,250);
           p[12].Direction = ParameterDirection.Output;
           p[13] = new SqlParameter("@Role", Role);
           p[14] = new SqlParameter("@AgentId", AgentId);
           SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertUserRegistration", p);
           return p[12].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);          
        }
    }
    public string UpdateCustomerProfile()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@CustId", CustId);
            p[1] = new SqlParameter("@PhoneNo", PhoneNo);
            p[2] = new SqlParameter("@Email", Email);
            p[3] = new SqlParameter("@Image", Image);
            p[4] = new SqlParameter("@FileName", FileName);
            p[5] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@Address", Address);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateCustomerProfile", p);
            return p[5].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomerDetails()
    {
        try
        {
            //string str="select * from tbl_UserRegistrationMaster where "
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustomerDetails", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet UpdateAcceptancyCustomersByAgentId(int CustomerId)
    {
        try
        {
            string str = "update tbl_UserRegistrationMaster set Acceptancy =1 where UserId = "+ CustomerId + "and Role ='Customer' and AgentId=" + this.AgentId;
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }

    }

    public DataSet GetAcceptancyCustomersByAgentId()
    {
        try
        {
            string str = "select * from tbl_UserRegistrationMaster where Acceptancy = 0 and Role='Customer' and AgentId=" + this.AgentId;
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text,str );
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);            
        }
    }
    public string AcceptUsersAsCustomers()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@UserId", UserId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            p[2] = new SqlParameter("@AgentId", AgentId);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_AcceptUsersAsCustomers", p);
           return p[1].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);            
        }
    }
    public DataSet GetComplaintsStatusByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetComplaintsStatusByCustId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllCustomersData()
    {
        try
        {
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllCustomersData",null);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomersDataByDate()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@Date", DOR);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustomersDataByDate",p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
