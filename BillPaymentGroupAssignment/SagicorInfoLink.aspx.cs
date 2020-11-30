using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BillPaymentGroupAssignment
{
    public partial class SagicorInfoLink : System.Web.UI.Page
    {
        public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        string CustomerID = System.Web.HttpContext.Current.User.Identity.Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.User == null || !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        protected void LinkAccount(object sender, EventArgs e)
        {
            SagicorLifeServices.SagicorLifeConnectSoapClient client = new SagicorLifeServices.SagicorLifeConnectSoapClient();
            if (client.CheckSagicor(AccountNumber.Text, AccountEmail.Text, AccountPhoneNum.Text))
            {
                string inCmd = "insert into LinkedSagicorAccounts values (@CustUserName, @FlowAccNum)";
                SqlCommand cmd = new SqlCommand(inCmd, con);
                cmd.Parameters.AddWithValue("@CustUserName", CustomerID);
                cmd.Parameters.AddWithValue("@FlowAccNum", AccountNumber.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("~/LinkFlowSagicor.aspx");
            }
            else
            {
                LinkStatus.Visible = true;
                StatusText.Text = "No account with entered credentials were found";
            }
        }
    }
}