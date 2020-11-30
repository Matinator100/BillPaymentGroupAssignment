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
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BillPaymentGroupAssignment
{
    public partial class LinkFlowSagicor : System.Web.UI.Page
    {
        /*global variables to store connection to database and current user ID and connection to both the flow and Sagicor web service*/
        public static string strcon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strcon);
        string CustomerID = System.Web.HttpContext.Current.User.Identity.Name;
        FlowServices.FlowConnectSoapClient client = new FlowServices.FlowConnectSoapClient();
        SagicorLifeServices.SagicorLifeConnectSoapClient client2 = new SagicorLifeServices.SagicorLifeConnectSoapClient();

        /*On Page Load, The page calls this function which connects to the database, checks if the user is logged in and displays wither the account details for linked accounts or the options to link to that account*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.User == null || !System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Must be logged in the Link Accounts');window.location ='/Account/Login.aspx';", true);
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
            if (!rdr.Read())
            {
                rdr.Close();
                Button LinkAcc = new Button();
                LinkAcc.Text = "Link a Flow Acount";
                LinkAcc.Enabled = true;
                LinkAcc.CssClass = "btn btn-primary";
                LinkAcc.Click += this.LoadFlowLinkPage;
                FlowAccInfoHolder.Controls.Add(LinkAcc);
            }
            else
            {
                rdr.Close();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                List<string> accountInfo = client.GetFlowInfo(rdr["FlowAccNum"].ToString());
                Label accountNumber = new Label();
                Label accountHolder = new Label();
                Label accountEmail = new Label();
                Label accountPhonenumber = new Label();
                Label accountBalance = new Label();
                Button unLinkAccBtn = new Button();
                Button makePaymentBtn = new Button();

                unLinkAccBtn.Text = "Unlink";
                unLinkAccBtn.Enabled = true;
                unLinkAccBtn.Click += this.UnlinkFlow;
                unLinkAccBtn.CssClass = "btn btn-primary mr-4";
                makePaymentBtn.Text = "Make a Payment";
                makePaymentBtn.Enabled = true;
                makePaymentBtn.Click += this.PaymentFlow;
                makePaymentBtn.CssClass = "btn btn-primary mr-4";

                accountNumber.Text =  "Flow Account Number: "+accountInfo[0];
                accountNumber.CssClass = "full-label";
                accountHolder.Text = "Flow Account Holder: "+accountInfo[1];
                accountHolder.CssClass = "full-label";
                accountEmail.Text = "Flow Account Email: "+accountInfo[2];
                accountEmail.CssClass = "full-label";
                accountPhonenumber.Text = "Flow Account Phone Number: "+ accountInfo[3];
                accountPhonenumber.CssClass = "full-label";
                accountBalance.Text = "Flow Current Balance: $"+accountInfo[4];
                accountBalance.CssClass = "full-label";

                FlowAccInfoHolder.Controls.Add(accountNumber);
                FlowAccInfoHolder.Controls.Add(accountHolder);
                FlowAccInfoHolder.Controls.Add(accountEmail);
                FlowAccInfoHolder.Controls.Add(accountPhonenumber);
                FlowAccInfoHolder.Controls.Add(accountBalance);
                FlowAccInfoHolder.Controls.Add(unLinkAccBtn);
                FlowAccInfoHolder.Controls.Add(makePaymentBtn);

            }

            rdr.Close();
            cmd.Dispose();
            con.Close();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from LinkedSagicorAccounts where CustUserName = '" + CustomerID + "'";
            rdr = cmd.ExecuteReader();
            if (!rdr.Read())
            {
                rdr.Close();
                Button LinkAcc = new Button();
                LinkAcc.Text = "Link a Sagicor Acount";
                LinkAcc.Enabled = true;
                LinkAcc.CssClass = "btn btn-primary";
                LinkAcc.Click += this.LoadSagicorLinkPage;
                SagicorAccInfoHolder.Controls.Add(LinkAcc);
            }
            else
            {
                rdr.Close();
                rdr = cmd.ExecuteReader();
                rdr.Read();
                List<string> accountInfo = client2.GetSagicorInfo(rdr["SagicorAccNum"].ToString());
                Label accountNumber = new Label();
                Label accountHolder = new Label();
                Label accountEmail = new Label();
                Label accountPhonenumber = new Label();
                Label accountBalance = new Label();
                Button unLinkAccBtn = new Button();
                Button makePaymentBtn = new Button();

                unLinkAccBtn.Text = "Unlink";
                unLinkAccBtn.Enabled = true;
                unLinkAccBtn.Click += this.UnlinkSagicor;
                unLinkAccBtn.CssClass = "btn btn-primary mr-4";
                makePaymentBtn.Text = "Make a Payment";
                makePaymentBtn.Enabled = true;
                makePaymentBtn.Click += this.PaymentSagicor;
                makePaymentBtn.CssClass = "btn btn-primary mr-4";

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
                SagicorAccInfoHolder.Controls.Add(unLinkAccBtn);
                SagicorAccInfoHolder.Controls.Add(makePaymentBtn);
            }
            rdr.Close();
            cmd.Dispose();
        }

        /*This function redirects to the FlowInfoLink.aspx page*/
        protected void LoadFlowLinkPage(object sender, EventArgs e)
        {
            Response.Redirect("~/FlowInfoLink.aspx");
        }

        /*This function redirects to the SagicorInfoLink.aspx page*/
        protected void LoadSagicorLinkPage(object sender, EventArgs e)
        {
            Response.Redirect("~/SagicorInfoLink.aspx");
        }

        /*This function deletes linked flow accounts*/
        protected void UnlinkFlow(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from LinkedFlowAccounts where CustUserName = '" + CustomerID +"'";
            cmd.ExecuteNonQuery();
            Response.Redirect("~/LinkFlowSagicor.aspx");
        }

        /*This function deletes linked Sagicor accounts*/
        protected void UnlinkSagicor(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from LinkedSagicorAccounts where CustUserName = '" + CustomerID + "'";
            cmd.ExecuteNonQuery();
            Response.Redirect("~/LinkFlowSagicor.aspx");
        }

        /*This function redirects to the PaymentFlow.aspx page*/
        protected void PaymentFlow(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentFlow.aspx");
        }

        /*This function redirects to the PaymentSagicor.aspx page*/
        protected void PaymentSagicor(object sender, EventArgs e)
        {
            Response.Redirect("~/PaymentSagicor.aspx");
        }
    }
}