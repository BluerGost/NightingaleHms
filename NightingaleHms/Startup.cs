using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NightingaleHms.Startup))]
namespace NightingaleHms
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
