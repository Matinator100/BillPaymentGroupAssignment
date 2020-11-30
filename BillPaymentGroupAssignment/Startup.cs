using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BillPaymentGroupAssignment.Startup))]
namespace BillPaymentGroupAssignment
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
