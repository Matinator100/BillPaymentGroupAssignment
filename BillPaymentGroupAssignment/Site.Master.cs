using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace BillPaymentGroupAssignment
{
    public partial class SiteMaster : MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                lblUser.Text = "Hello " + System.Web.HttpContext.Current.User.Identity.Name;
            }
            else
            {
                lblUser.Visible = false;
                signOutBtn.Visible = false;
                signOutBtn.Enabled = false;
            }

            if (string.Compare(Request.Url.LocalPath, "/LinkFlowSagicor") == 0 || string.Compare(Request.Url.LocalPath, "/LinkFlowSagicor.aspx") == 0)
            {
                FlowSagicorLink.CssClass = "nav-link active";
            }
        }

        protected void SignOut(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            Response.Redirect("~/Account/Login.aspx");
        }

    }

}