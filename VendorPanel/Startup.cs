using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VendorPanel.Startup))]
namespace VendorPanel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
