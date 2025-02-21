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
/// Summary description for clsPayments
/// </summary>
public class clsPayments:clsConnection
{
    public clsPayments()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CustId { get; set; }
    public int PaymentTypeId { get; set; }
    public string TypeName { get; set; }
    public string Abbreviation { get; set; }
    public string Description { get; set; }
    public int AgentId { get; set; }
    public int PolicyRegnId { get; set; }
    public int PaymentId { get; set; }
    public DateTime PaymentDate { get; set; }
    public DateTime ChkDate { get; set; }
    public DateTime DueDate { get; set; }
    public string Bank { get; set; }
    public string DDNo { get; set; }
    public decimal Amount { get; set; }

    public DataSet InsertPaymentTypeMasterForPremium()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@TypeName", TypeName);
            p[1] = new SqlParameter("@Abbreviation", Abbreviation);
            p[2] = new SqlParameter("@Desc", Description);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPaymentTypeMasterForPremium", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet UpdatePaymentTypeMasterForPremium()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@TypeName", TypeName);
            p[1] = new SqlParameter("@Abbreviation", Abbreviation);
            p[2] = new SqlParameter("@Desc", Description);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@TypeId", PaymentTypeId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePaymentTypeMasterForPremium", p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPaymentTypeIdsForPremium()
    {
        try
        {
            string str = "select PaymentTypeId,TypeName from tbl_PaymentTypeMasterForPremium ";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPaymentTypeMasterDataByTypeIdForPremium()
    {
        try
        {
            string str = "select * from tbl_PaymentTypeMasterForPremium where PaymentTypeId=" + this.PaymentTypeId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPaymentTypeMasterDataForPremium()
    {
        try
        {
            string str = "select * from tbl_PaymentTypeMasterForPremium ";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    // This is for Policy //


    public string InsertPaymentTypeMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[4];
            p[0] = new SqlParameter("@TypeName", TypeName);
            p[1] = new SqlParameter("@Abbreviation", Abbreviation);
            p[2] = new SqlParameter("@Desc", Description);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPaymentTypeMaster", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdatePaymentTypeMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[5];
            p[0] = new SqlParameter("@TypeName", TypeName);
            p[1] = new SqlParameter("@Abbreviation", Abbreviation);
            p[2] = new SqlParameter("@Desc", Description);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@TypeId", PaymentTypeId);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePaymentTypeMaster", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPaymentTypeIds()
    {
        try
        {
            string str = "select PaymentTypeId,TypeName from tbl_PaymentTypeMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetAllPaymentIds()
    {
        try
        {
            string str = "select PaymentId from tbl_PolicyPaymentMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetPaymentTypeMasterDataByTypeId()
    {
        try
        {
            string str = "select * from tbl_PaymentTypeMaster where PaymentTypeId=" + this.PaymentTypeId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPaymentTypeMasterData()
    {
        try
        {
            string str = "select * from tbl_PaymentTypeMaster ";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string InsertPolicyPaymentMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[8];
            //p[0] = new SqlParameter("@PaymentDate", PaymentDate);
            p[0] = new SqlParameter("@Amount", Amount);
            p[1] = new SqlParameter("@DDNo", DDNo);
            p[2] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[2].Direction = ParameterDirection.Output;
            p[3] = new SqlParameter("@TypeId", PaymentTypeId);
            p[4] = new SqlParameter("@ChkDate", ChkDate);
            p[5] = new SqlParameter("@Bank", Bank);
            p[6] = new SqlParameter("@CustId", CustId);
            p[7] = new SqlParameter("@RegnId", PolicyRegnId);
            //p[7] = new SqlParameter("@DueDate", DueDate);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_InsertPolicyPaymentMaster", p);
            return p[2].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public string UpdatePolicyPaymentMaster()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[9];
            p[0] = new SqlParameter("@PaymentDate", PaymentDate);
            p[1] = new SqlParameter("@Amount", Amount);
            p[2] = new SqlParameter("@DDNo", DDNo);
            p[3] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[3].Direction = ParameterDirection.Output;
            p[4] = new SqlParameter("@TypeId", PaymentTypeId);
            p[5] = new SqlParameter("@ChkDate", ChkDate);
            p[6] = new SqlParameter("@Bank", Bank);
            //p[7] = new SqlParameter("@DueDate", DueDate);
            p[7] = new SqlParameter("@PaymentId", PaymentId);
            p[8] = new SqlParameter("@RegnId", PolicyRegnId);
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_UpdatePolicyPaymentMaster", p);
            return p[3].Value.ToString();
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public string DeletePolicyPaymentMaster()
    { 
        try
        {
            SqlParameter[] p = new SqlParameter[2];
            p[0] = new SqlParameter("@PaymentId", PaymentId);
            p[1] = new SqlParameter("@Message", SqlDbType.VarChar, 250);
            p[1].Direction = ParameterDirection.Output;
            SqlHelper.ExecuteNonQuery(clsConnection.Connection, CommandType.StoredProcedure, "sp_DeletePolicyPaymentMaster", p);
            return p[1].Value.ToString();
        }
        catch(Exception ex) 
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPolicyPaymentMasterData()
    {
        try
        {
            // string str="select "
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllPolicyPaymentMasterData", null);

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPolicyPaymentDataByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetAllPolicyPaymentDataByCustId",p);

        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetComplaintsByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure, "sp_GetComplaintsByCustId", p);
        }
        catch(Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPolicyPaymentMasterDataByPaymentId()
    {
        try
        {
            string str = "select * from tbl_PolicyPaymentMaster where PaymentId="+this.PaymentId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPaymentIds()
    {
        try
        {
            string str = "select PaymentId from tbl_PolicyPaymentMaster ";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPaymentIdsByCustId()
    {
        try
        {
            string str = "select PaymentId from tbl_PolicyPaymentMaster where CustomerId="+this.CustId;
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetAllPolicyRegdIds()
    {
        try
        {
            string str = "select PolicyRegnId from tbl_CustomersAndPoliciesMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
    public DataSet GetPoliciesByCustId()
    {
        try
        {
            SqlParameter[] p = new SqlParameter[1];
            p[0] = new SqlParameter("@CustId", CustId);
            //string str = "select PolicyRegnId from tbl_CustomersAndPoliciesMaster where CustomerId="+this.CustId;
            //return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.StoredProcedure,"sp_GetPoliciesByCust",p);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    public DataSet GetComplaintsIdsByCustId()
    {
        try
        {
            string str = "select ComplaintId from tbl_ComplaintsMaster";
            return SqlHelper.ExecuteDataset(clsConnection.Connection, CommandType.Text, str);
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}
