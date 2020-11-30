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
    public partial class PaymentSagicor : System.Web.UI.Page
    {
        public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        string CustomerID = System.Web.HttpContext.Current.User.Identity.Name;
        SagicorLifeServices.SagicorLifeConnectSoapClient client = new SagicorLifeServices.SagicorLifeConnectSoapClient();
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
            cmd.CommandText = "select * from LinkedSagicorAccounts where CustUserName = '" + CustomerID + "'";
            SqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            List<string> accountInfo = client.GetSagicorInfo(rdr["SagicorAccNum"].ToString());
            Label accountNumber = new Label();
            Label accountHolder = new Label();
            Label accountEmail = new Label();
            Label accountPhonenumber = new Label();
            Label accountBalance = new Label();

            accountNumber.Text = "Sagicor Account Number: " + accountInfo[0];
            accountNumber.CssClass = "full-label";
            accountHolder.Text = "Sagicor Account Holder: " + accountInfo[1];
            accountHolder.CssClass = "full-label";
            accountEmail.Text = "Sagicor Account Email: " + accountInfo[2];
            accountEmail.CssClass = "full-label";
            accountPhonenumber.Text = "Sagicor Account Phone Number: " + accountInfo[3];
            accountPhonenumber.CssClass = "full-label";
            accountBalance.Text = "Sagicor Current Balance: $" + accountInfo[4];
            accountBalance.CssClass = "full-label";

            SagicorAccInfoHolder.Controls.Add(accountNumber);
            SagicorAccInfoHolder.Controls.Add(accountHolder);
            SagicorAccInfoHolder.Controls.Add(accountEmail);
            SagicorAccInfoHolder.Controls.Add(accountPhonenumber);
            SagicorAccInfoHolder.Controls.Add(accountBalance);

            rdr.Close();
            cmd.Dispose();
        }

        protected void PayToSagicor(object sender, EventArgs e)
        {
            decimal amount = Convert.ToDecimal(Amount.Text);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select SagicorAccNum from LinkedSagicorAccounts where CustUserName = '" + CustomerID + "'";
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            string linkedAccount = rdr["SagicorAccNum"].ToString();

            rdr.Close();
            cmd.Dispose();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select AccountBalance from JCBAccounts where AccountOwner = '" + CustomerID + "'";
            rdr = cmd.ExecuteReader();
            rdr.Read();
            decimal userBalance = Convert.ToDecimal(rdr["AccountBalance"]);

            if (userBalance >= amount)
            {
                if (client.PaySagicor(linkedAccount, amount))
                {
                    userBalance = userBalance - amount;
                    rdr.Close();
                    cmd.Dispose();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update JCBAccounts set AccountBalance = '" + userBalance + "' where AccountOwner = '" + CustomerID + "'";
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