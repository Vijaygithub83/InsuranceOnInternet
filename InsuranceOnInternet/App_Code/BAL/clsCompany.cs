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
/// Summary description for clsCompany
/// </summary>
public class clsCompany:clsConnection
{
	public clsCompany()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   

        private int companyId;
        private string companyName;
        private string address;
        private string phoneNo;
        private string email;

        public int CompanyId { get { return companyId; } set { companyId = value; } }
        public string CompanyName { get { return companyName; } set { companyName = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string PhoneNo { get { return phoneNo; } set { phoneNo = value; } }
        public string Email { get { return email; } set { email = value; } }

        public string InsertCompaniesMaster()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[5];
                p[0] = new SqlParameter("@CompanyName", CompanyName);
                p[1] = new SqlParameter("@Address", Address);
                p[2] = new SqlParameter("@PhoneNo", PhoneNo);
                p[3] = new SqlParameter("@Email", Email);
                p[4] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
                p[4].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertCompaniesMaster", p);
                return p[4].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public string UpdateCompaniesMaster()
        {
            try
            {
                SqlParameter[] p = new SqlParameter[6];
                p[0] = new SqlParameter("@CompanyName", CompanyName);
                p[1] = new SqlParameter("@Address", Address);
                p[2] = new SqlParameter("@PhoneNo", PhoneNo);
                p[3] = new SqlParameter("@Email", Email);
                p[4] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
                p[4].Direction = ParameterDirection.Output;
                p[5] = new SqlParameter("@CompanyId", CompanyId);
                SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdateCompaniesMaster", p);
                return p[4].Value.ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    public string DeleteCompaniesMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[6];
            p[0] = new SqlParameter("@CompanyName", CompanyName);
            p[1] = new SqlParameter("@Address", Address);
            p[2] = new SqlParameter("@PhoneNo", PhoneNo);
            p[3] = new SqlParameter("@Email", Email);
            p[4] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[4].Direction = ParameterDirection.Output;
            p[5] = new SqlParameter("@CompanyId", CompanyId);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeleteCompaniesMaster", p);
            return p[4].Value.ToString();
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
        public DataSet GetCompanyMasterDataByCompanyId()
        {
            try
            {
                string str = "select * from tbl_InsuranceCompaniesMaster where CompanyId="+this.CompanyId;
                return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public DataSet GetAllCompaniesMasterData()
        {
            try
            {
                string str = "select * from tbl_InsuranceCompaniesMaster ";
                return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
  }

