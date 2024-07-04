using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Xml;
/// <summary>
/// Summary description for BusinessLayer
/// </summary>
/// 
namespace DataAccessClassDAL
{
    public class DataAccessClass
    {
        public DataAccessClass()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private SqlConnection objCon;
        private SqlCommand objCom;
        private SqlDataReader objDtReader;
        private SqlParameter objParm;
        int return_value;
        SqlDataAdapter objAdp;
        private string constr = System.Configuration.ConfigurationManager.ConnectionStrings["EmpContext"].ToString();
        private string strValue;
        public DataSet GetDataSetForPrc(string strSql, Hashtable htable)
        {
            DataSet dsResult = new DataSet();
            SqlCommand cmdObj = new SqlCommand();
            SqlConnection conn = new SqlConnection(constr);
            cmdObj.CommandText = strSql;
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = conn;
            try
            {
                objAdp = new SqlDataAdapter(cmdObj);
                foreach (DictionaryEntry dist in htable)
                {
                    objAdp.SelectCommand.Parameters.AddWithValue((string)dist.Key, dist.Value);
                }
                objAdp.Fill(dsResult);
            }
            catch
            {
                throw;
            }
            return dsResult;
        }
        public DataSet GetDataSetForPrc(string strSql)
        {
            DataSet dsResult = new DataSet();
            SqlCommand cmdObj = new SqlCommand();
            SqlConnection conn = new SqlConnection(constr);
            cmdObj.CommandText = strSql;
            cmdObj.CommandType = CommandType.StoredProcedure;
            cmdObj.Connection = conn;
            try
            {
                objAdp = new SqlDataAdapter(cmdObj);
                objAdp.Fill(dsResult);
            }
            catch
            {
                throw;
            }
            return dsResult;
        }
    }
}