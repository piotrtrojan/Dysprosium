using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dysprosium.WebApp.Startup))]

namespace Dysprosium.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}