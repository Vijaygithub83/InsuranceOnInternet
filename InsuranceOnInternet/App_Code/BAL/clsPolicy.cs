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
/// Summary description for clsPolicy
/// </summary>
public class clsPolicy:clsConnection
{
	public clsPolicy()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DateTime DOR { get; set; }

    public int PaymentTypeId { get; set; }
    public int AgentId { get; set; }
    public int PolicyId { get; set; }
    public int CompanyId { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public string PolicyName { get; set; }
    public string MinTerm { get; set; }
    public string MaxTerm { get; set; }
    public string  Terms { get; set; }
    public string Conditions { get; set; }
    public DateTime LaunchDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal MinAmount { get; set; }
    public decimal MaxAmount { get; set; }
    public int CoverageAmount { get; set; }
    public string TermsFile { get; set; }
    public byte[] TermsFileContent { get; set; }
    public string BrochureFile { get; set; }
    public byte[] BrochureFileContent { get; set; }

    public string InfoBrochure { get; set; }


    public string InsertPolicyMaster(out string outMsg)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[16];
            p[0] = new SqlParameter("@PolicyName",PolicyName);
            p[1] = new SqlParameter("@CompanyId",CompanyId);
            p[2] = new SqlParameter("@LaunchDate",LaunchDate);
            p[3] = new SqlParameter("@EndDate",EndDate);
            p[4] = new SqlParameter("@MinAmount",MinAmount);
            p[5] = new SqlParameter("@MaxAmount",MaxAmount);
            p[6] = new SqlParameter("@MinAge", MinAge);
            p[7] = new SqlParameter("@MaxAge",MaxAge);
            p[8] = new SqlParameter("@MinTerm",MinTerm);
            p[9] = new SqlParameter("@MaxTerm",MaxTerm);
            p[10] = new SqlParameter("@CoverageAmount", CoverageAmount);
            p[11] = new SqlParameter("@TermsFile", TermsFile);
            p[12] = new SqlParameter("@TermsFileContent", TermsFileContent);
            p[13] = new SqlParameter("@BrochureFile", BrochureFile);
            p[14] = new SqlParameter("@BrochureFileContent", BrochureFileContent);
            p[15] = new SqlParameter("@Message",SqlDbType.VarChar,250);
            p[15].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPolicyMaster", p);
            return outMsg = p[15].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);            
        }
    }
    //pendiing
    public int UpdatePolicyMaster(out string outMsg)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[15];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            //p[1] = new SqlParameter("@CompanyId", CompanyId);
            p[1] = new SqlParameter("@LaunchDate", LaunchDate);
            p[2] = new SqlParameter("@EndDate", EndDate);
            p[3] = new SqlParameter("@MinAmount", MinAmount);
            p[4] = new SqlParameter("@MaxAmount", MaxAmount);
            p[5] = new SqlParameter("@MinAge", MinAge);
            p[6] = new SqlParameter("@MaxAge", MaxAge);
            p[7] = new SqlParameter("@MinTerm", MinTerm);
            p[8] = new SqlParameter("@MaxTerm", MaxTerm);
            p[9] = new SqlParameter("@CoverageAmount", CoverageAmount);
            p[10] = new SqlParameter("@TermsFile", TermsFile);
            p[11] = new SqlParameter("@TermsFileContent", TermsFileContent);
            p[12] = new SqlParameter("@BrochureFile", BrochureFile);
            p[13] = new SqlParameter("@BrochureFileContent", BrochureFileContent);
            p[14] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[14].Direction = ParameterDirection.Output;

         int i=  SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePolicyMaster", p);
            outMsg= p[14].Value.ToString();
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public int DeletePolicyMaster(out string outMsg)
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[1].Direction = ParameterDirection.Output;

            int i = SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeletePolicyMaster", p);
            outMsg = p[1].Value.ToString();
            return i;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllPolicyIds()
    {
        try
        {
            string str = "select PolicyId,PolicyName from tbl_InsurancePolicyMaster ";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAgentsByPolicyId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAgentsByPolicyId", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPoliciesMasterData()
    {
        try
        {
           // string str="select "
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllPoliciesMasterData", null);

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyMasterDataByPolicyId()
    {
        try
        {
            string str = "select * from tbl_InsurancePolicyMaster where PolicyId=" + this.PolicyId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);      
        }
    }
    public DataSet GetAllCompanyIds()
    {
        try
        {
            string str = "select CompanyId,CompanyName from tbl_InsuranceCompaniesMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);      
            
        }
    }
    public string InsertPolicyAgentsDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@AgentId", AgentId);
            p[2] = new SqlParameter("@DOR", DOR);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPolicyAgentsDetails", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdatePolicyAgentsDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@AgentId", AgentId);
            p[2] = new SqlParameter("@DOR", DOR);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePolicyAgentsDetails", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string DeletePolicyAgentsDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeletePolicyAgentsDetails", p);
            return p[1].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPolicyAgentsData()
    {
        try
        {
            //string str = "select * from tbl_InsuranceCompanyAgentsMaster ";

            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllPolicyAgentsData", null);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyAgentsDataByPolicyId()
    {
        try
        {
            string str = "select * from tbl_PolicyAgentsDetails where PolicyId=" + this.PolicyId;

            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string InsertPolicyPaymentTypeDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@TypeId", PaymentTypeId);            
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPolicyPaymentTypeDetails", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdatePolicyPaymentTypeDetails()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[3];
            p[0] = new SqlParameter("@PolicyId", PolicyId);
            p[1] = new SqlParameter("@TypeId", PaymentTypeId);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 100);
            p[2].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePolicyPaymentTypeDetails", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPolicyPaymentTypeData()
    {
        try
        {
            //string str = "select * from tbl_InsuranceCompanyAgentsMaster ";

            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllPolicyPaymentTypeData", null);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyPaymentTypesByPolicyId()
    {
        try
        {
            string str = "select * from tbl_PolicyPaymentTypeDetails where PolicyId=" + this.PolicyId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
