using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VIidly.Startup))]
namespace VIidly
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
