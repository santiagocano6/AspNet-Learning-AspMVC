using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstudioASP.Startup))]
namespace EstudioASP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
