using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Collections.Generic;

namespace BillPaymentGroupAssignment
{
    /// <summary>
    /// Summary description for FlowConnect
    /// </summary>
    [WebService(Namespace = "http://Flow.com/webservices")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FlowConnect : System.Web.Services.WebService
    {
        
        [WebMethod]
        public bool CheckFlow(string userAccNum, string userAccEmail, string userAccPhoneNum)
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from FlowAccounts where AccountNumber = '" + userAccNum + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            if(!rdr.Read())
            {
                return false;
            }
            else 
            {
                rdr.Close();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                if (userAccNum == rdr["AccountNumber"].ToString() && userAccEmail == rdr["AccountEmail"].ToString() && userAccPhoneNum == rdr["AccountPhoneNumber"].ToString())
                {
                    return true;
        
                }
                
            }
            return false;

        }

        [WebMethod]
        public List<string> GetFlowInfo(string accNum)
        {
            var accountInfo = new List<string>();
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from FlowAccounts where AccountNumber = '" + accNum + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                return null;
            }
            else
            {
                rdr.Close();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                accountInfo.Add(rdr["AccountNumber"].ToString());
                accountInfo.Add(rdr["AccountName"].ToString());
                accountInfo.Add(rdr["AccountEmail"].ToString());
                accountInfo.Add(rdr["AccountPhoneNumber"].ToString());
                accountInfo.Add(rdr["AccountBalance"].ToString());
                return accountInfo;
                
            }

        }
       [WebMethod]
        public bool PayFlow(string accNum, decimal amount)
        {
            string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select AccountBalance from FlowAccounts where AccountNumber = '"+accNum+"'";
            SqlDataReader rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                rdr.Close();
                return false;
            }
            else
            {
                rdr.Close();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                decimal currBalance = Convert.ToDecimal(rdr["AccountBalance"]);
                rdr.Close();
                cmd.Dispose();
                string inCmd = "update FlowAccounts set AccountBalance = @newAccBalance where AccountNumber = '" + accNum + "'";
                cmd = new SqlCommand(inCmd, con);
                cmd.Parameters.AddWithValue("@newAccBalance", (currBalance + amount));
                cmd.ExecuteNonQuery();
                return true;
            }

        }

    }
}
