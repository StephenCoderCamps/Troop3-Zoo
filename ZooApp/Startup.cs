using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooApp.Startup))]
namespace ZooApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
