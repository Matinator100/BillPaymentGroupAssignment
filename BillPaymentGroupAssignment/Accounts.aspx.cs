using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BillPaymentGroupAssignment.Models;


namespace BillPaymentGroupAssignment
{
    public partial class Accounts : System.Web.UI.Page
    {
        /*global variables to store connection to database and current user ID*/
        public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        string CustomerID = System.Web.HttpContext.Current.User.Identity.Name;

        /*On Page Load, Account.aspx page calls this function which connects to the database and displays the account information for the connected user*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            if (System.Web.HttpContext.Current.User == null || !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Must be logged in the view Accounts');window.location ='/Account/Login.aspx';", true);
                return;
            }
            else
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from JCBAccounts where AccountOwner = '" + CustomerID + "'";
                SqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                AccNum.Text = "Account Number: " + rdr["AccountNumber"].ToString();
                AccName.Text = "Name on the Account: " + rdr["AccountName"].ToString();
                AccBalance.Text = "Account Balance: $" + rdr["AccountBalance"].ToString();
            }

        }
    }
}