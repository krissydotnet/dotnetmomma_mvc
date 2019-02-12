using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetMomma_MVC.Startup))]
namespace DotNetMomma_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
