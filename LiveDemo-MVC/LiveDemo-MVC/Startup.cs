using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LiveDemo_MVC.Startup))]
namespace LiveDemo_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
