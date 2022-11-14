using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontPanel.Startup))]

namespace FrontPanel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}