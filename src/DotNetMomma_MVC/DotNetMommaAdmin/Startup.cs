using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetMommaAdmin.Startup))]
namespace DotNetMommaAdmin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
