using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IOT_PMS.Startup))]
namespace IOT_PMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
