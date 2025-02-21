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
/// Summary description for clsAgent
/// </summary>
public class clsAgent:clsConnection 
{
	public clsAgent()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CompanyId { get; set; }
    public decimal PremiumConfirm { get; set; }
    public decimal Amount { get; set; }
    public int RegdId { get; set; }
    public int CustId { get; set; }
    public int PaymentTypeId { get; set; }
    public int AmtPaymentTypeId { get; set; }
    public int PolicyId { get; set; }
    public int PolicyTerm { get; set; }
    public string DDNo { get; set; }
    public DateTime ChkDate { get; set; }
    public string BankName { get; set; }

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
    public string FileName { get; set; }
    public DateTime DOR { get; set; }
    public string Role { get; set; }
    public string ComplaintText { get; set; }
    public int ComplaintId { get; set; }
    public string AnswerText { get; set; }

    public string InsertAgentRegistration()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[14];
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
            p[12] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[12].Direction = ParameterDirection.Output;
            p[13] = new SqlParameter("@Role", Role);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertAgentRegistration", p);
            return p[12].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdateAgentProfile()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[7];
            p[0] = new SqlParameter("@Agentid", AgentId);
            p[1] = new SqlParameter("@PhoneNo", PhoneNo);
            p[2] = new SqlParameter("@Email", Email);
            p[3] = new SqlParameter("@Image", Image);
            p[4] = new SqlParameter("@FileName", FileName);
            p[5] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[5].Direction = ParameterDirection.Output;
            p[6] = new SqlParameter("@Address", Address);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateAgentProfile", p);
            return p[5].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAgentDetails()
    {
        try
        { 
            //string str="select * from tbl_UserRegistrationMaster where "
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAgentDetails", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllRegdAgents()
    {
        try
        {
            string str = "select * from tbl_UserRegistrationMaster where Acceptancy = 0 and Role='Agent'"; 
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public static int GetAgentIdByUserId(int intUserId)
    {
        try
        {
            string str = "select AgentId from tbl_AgentsMaster where UserId="+intUserId;

            int Id=Convert.ToInt32(SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str));
            return Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public static int GetCustomerIdByUserId(int intUserId)
    {
        try
        {
            string str = "select CustomerId from tbl_CustomersMaster where UserId=" + intUserId;

           int Id=Convert.ToInt32( SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str));
           return Id;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPoliciesByAgentId()
    {
        try
        {
            //string str = "select * from tbl_UserRegistrationMaster where Role='UserA'";
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetPoliciesByAgentId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyRangeByPolicyId()
    {
        try
        {
            string str = "select MinAmount,MaxAmount from tbl_InsurancePolicyMaster where PolicyId=" + this.PolicyId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyTermsRangeByPolicyId()
    {
        try
        {
            string str = "select MinTerm,MaxTerm from tbl_InsurancePolicyMaster where PolicyId=" + this.PolicyId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllAgents()
    {
        try
        {
            string str = "select * from dbo.tbl_UserRegistrationMaster where UserId in (select distinct UserId from dbo.tbl_AgentsMaster)";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllAgentsData()
    {
        try
        {
            //string str = "select * from tbl_UserRegistraionMaster where Role='Agent'";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllAgentsData", null);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllCompanyAgentsData()
    {
        try
        {
           //string str = "select * from tbl_InsuranceCompanyAgentsMaster ";

            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure,"sp_GetAllCompanyAgentsData",null);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCompanyAgentsDataByCompanyId()
    {
        try
        {
            string str = "select * from tbl_InsuranceCompanyAgentsMaster where CompanyId="+this.CompanyId;

            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string AcceptUsersAsAgents()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@UserId", UserId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_AcceptUsersAsAgents", p);
            return p[1].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string RejectUsersAsAgents()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@UserId", UserId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_RejectUsersAsAgents", p);
            return p[1].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAgentAddressByAgentId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAgentAddressByAgentId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string InsertCompanyAgentsMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@CompanyId", CompanyId);
            p[1] = new SqlParameter("@AgentId", AgentId);
            //p[2] = new SqlParameter("@DOR", DOR);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertCompanyAgentsMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdateCompanyAgentsMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@CompanyId", CompanyId);
            p[1] = new SqlParameter("@AgentId", AgentId);
            //p[2] = new SqlParameter("@DOR", DOR);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateCompanyAgentsMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string DeleteCompanyAgentsMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@CompanyId", CompanyId);
            p[1] = new SqlParameter("@AgentId", AgentId);
            //p[2] = new SqlParameter("@DOR", DOR);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeleteCompanyAgentsMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string InsertCustomerPolicyMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[12];
            p[0] = new SqlParameter("@CustId", CustId);
            p[1] = new SqlParameter("@PolicyId", PolicyId);
            //p[2] = new SqlParameter("@Date", DOR);
            p[2] = new SqlParameter("@AgentId", AgentId);
            p[3] = new SqlParameter("@Amount", Amount);
            p[4] = new SqlParameter("@PaymentType", PaymentTypeId);
            p[5] = new SqlParameter("@Confirm", PremiumConfirm);
            p[6] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[6].Direction = ParameterDirection.Output;
             p[7] = new SqlParameter("@TypeId", AmtPaymentTypeId);
             p[8] = new SqlParameter("@DDNo", DDNo);
             p[9] = new SqlParameter("@ChkDate", ChkDate);
             p[10] = new SqlParameter("@BankName", BankName);
             p[11] = new SqlParameter("@Term", PolicyTerm);
             SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertCustomerPolicyMaster", p);
             return p[6].Value.ToString();

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdateCustomerPolicyMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[8];
            p[0] = new SqlParameter("@CustId", CustId);
            p[1] = new SqlParameter("@PolicyId", PolicyId);
            //p[2] = new SqlParameter("@Date", DOR);
            p[2] = new SqlParameter("@AgentId", AgentId);
            p[3] = new SqlParameter("@amount", Amount);
            p[4] = new SqlParameter("@PaymentType", PaymentTypeId);
            p[5] = new SqlParameter("@Confirm", PremiumConfirm);
            p[6] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[6].Direction = ParameterDirection.Output;
            p[7] = new SqlParameter("@RegdId", RegdId);
            SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateCustomerPolicyMaster", p);
            return p[6].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomerPolicyMasterDataByRegdId()
    {
        try
        {
            string str = "select * from tbl_CustomersAndPoliciesMaster where PolicyRegnId="+this.RegdId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetRegdIdsByAgentId()
    {
        try
        {
            string str = "select PolicyRegnId from tbl_CustomersAndPoliciesMaster where AgentId="+this.AgentId;
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetRegdIdsByCustId()
    {
        try
        {
            string str = "select PolicyRegnId from tbl_CustomersAndPoliciesMaster where CustId=" + this.CustId;
            
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetCustomerPolicyMasterDataByAgentId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0]=new SqlParameter ("@AgentId",AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure,"sp_GetCustomerPolicyMasterDataByAgentId",p );
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomerPolicyMasterDataByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustomerPolicyMasterDataByCustId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string InsertComplaintsMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@CustId", CustId);
            //p[1] = new SqlParameter("@RegdId", RegdId);           
            p[1] = new SqlParameter("@Text", ComplaintText);           
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@RegdId", RegdId);
            SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertComplaintsMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string UpdateComplaintMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@CustomerId", CustId);
            //p[1] = new SqlParameter("@RegdId", RegdId);           
            p[1] = new SqlParameter("@ComplaintText", ComplaintText);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@RegdId", RegdId);
            SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateComplaintMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string DeleteComplaintMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@ComplaintId", ComplaintId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeleteComplaintMaster", p);
            return p[1].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }


    public DataSet GetComplaintIdByCustId()
    {
        try
        {
            string str = "select * from tbl_ComplaintsMaster where ComplaintId=" + this.ComplaintId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustComplaintsByAgentId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustComplaintsByAgentId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdateComplaintsMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@ComplaintId", ComplaintId);
            p[1] = new SqlParameter("@AnswerText", AnswerText);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateComplaintsMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAgentIdByUserId()
    {
        try
        {
            string str = "select AgentId from tbl_AgentsMaster where UserId=" + this.UserId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetCustomersByAgentId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@AgentId", AgentId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetCustomersByAgentId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAgentsByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAgentsByCustId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPaymentTypesByPolicyId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetPaymentTypesByPolicyId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public decimal GetPremium()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@Amount", Amount);
            p[1] = new SqlParameter("@TypeId", PaymentTypeId);
            p[2] = new SqlParameter("@Term", PolicyTerm);
            p[3]=new SqlParameter ("@Premium",SqlDbType.Decimal);
            p[3].Direction = ParameterDirection.Output;
           SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetPremium", p);
           return Convert.ToDecimal(p[3].Value);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPaymentTypes()
    {
        try
        {
            string str = "select PaymentTypeId,TypeName from tbl_PaymentTypeMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text,str);

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public decimal GetPremiumAmount()
    {
        try
        {
            string str = "select distinct PremiumConfirmed from tbl_CustomersAndPoliciesMaster where PolicyRegnId=" + this.RegdId;
            decimal p = (decimal)SqlHelper.ExecuteScalar(clsConnection.Connection, CommandType.Text, str);
            return p;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet UpdateAcceptancyAgentsByAdmin(int AgentId)
    {
        try
        {
            string str = "update tbl_UserRegistrationMaster set Acceptancy =1, Reject=0 where UserId = " + AgentId + "and Role ='Agent'";
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet UpdateRejectAgentsByAdmin(int AgentId)
    {
        try
        {
            string str = "update tbl_UserRegistrationMaster set Acceptancy =0, Reject =1 where UserId = " + AgentId + "and Role ='Agent'";
            //SqlParameter[] p = new SqlParameter[1];
            //p[0] = new SqlParameter("@UserId", UserId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
