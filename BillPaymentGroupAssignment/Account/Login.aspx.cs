using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using BillPaymentGroupAssignment.Models;

namespace BillPaymentGroupAssignment.Account
{
    public partial class Login : Page
    {
        /*On page load, this function redirects users to the default page if they are already logged in*/
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Default.aspx", false);
            }
        }

        /*This function allows users to sign in*/
        protected void SignIn(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Find(UserName.Text, Password.Text);

            if (user != null)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                StatusText.Text = "Invalid username or password.";
                LoginStatus.Visible = true;
            }
        }
    }
}