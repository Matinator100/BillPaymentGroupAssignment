using System;
using System.Collections.Generic;
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
using System.Web.UI.WebControls;

namespace BillPaymentGroupAssignment
{
    public partial class PaymentFlow : System.Web.UI.Page
    {
        /*global variables to store connection string to database, current user ID as well as flow web service connection*/
        public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        string CustomerID = System.Web.HttpContext.Current.User.Identity.Name;
        
        FlowServices.FlowConnectSoapClient client = new FlowServices.FlowConnectSoapClient();

        /*On Page Load, This function connects to the database, redirects users to login if they are not connected and displays the account information of the linked flow account*/
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

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from LinkedFlowAccounts where CustUserName = '" + CustomerID + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
                
            rdr.Read();
            List<string> accountInfo = client.GetFlowInfo(rdr["FlowAccNum"].ToString());
            Label accountNumber = new Label();
            Label accountHolder = new Label();
            Label accountEmail = new Label();
            Label accountPhonenumber = new Label();
            Label accountBalance = new Label();

            accountNumber.Text = "Flow Account Number: " + accountInfo[0];
            accountNumber.CssClass = "full-label";
            accountHolder.Text = "Flow Account Holder: " + accountInfo[1];
            accountHolder.CssClass = "full-label";
            accountEmail.Text = "Flow Account Email: " + accountInfo[2];
            accountEmail.CssClass = "full-label";
            accountPhonenumber.Text = "Flow Account Phone Number: " + accountInfo[3];
            accountPhonenumber.CssClass = "full-label";
            accountBalance.Text = "Flow Current Balance: $" + accountInfo[4];
            accountBalance.CssClass = "full-label";

            FlowAccInfoHolder.Controls.Add(accountNumber);
            FlowAccInfoHolder.Controls.Add(accountHolder);
            FlowAccInfoHolder.Controls.Add(accountEmail);
            FlowAccInfoHolder.Controls.Add(accountPhonenumber);
            FlowAccInfoHolder.Controls.Add(accountBalance);

            rdr.Close();
            cmd.Dispose();
        }

        /*This function send the account number and amount to be paid to the flow web service for it to update its system*/
        protected void PayToFlow(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal(Amount.Text);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select FlowAccNum from LinkedFlowAccounts where CustUserName = '" + CustomerID + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            string linkedAccount = rdr["FlowAccNum"].ToString();

            rdr.Close();
            cmd.Dispose();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select AccountBalance from JCBAccounts where AccountOwner = '" + CustomerID + "'";
            rdr = cmd.ExecuteReader();
            rdr.Read();
            decimal userBalance = Convert.ToDecimal(rdr["AccountBalance"]);

            if(userBalance >= amount)
            {
                if(client.PayFlow(linkedAccount, amount))
                {
                    userBalance = userBalance - amount; 
                    rdr.Close();
                    cmd.Dispose();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update JCBAccounts set AccountBalance = '" +userBalance+ "' where AccountOwner = '" + CustomerID + "'";
                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/LinkFlowSagicor.aspx");
                }
                else
                {
                    PayStatus.Visible = true;
                    StatusText.Text = "Payment unsuccessful";
                }
            }
            else 
            {
                PayStatus.Visible = true;
                StatusText.Text = "Your Account does not have enough funds";
            }

        }
    }
}