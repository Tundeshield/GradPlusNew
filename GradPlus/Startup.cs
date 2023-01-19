using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GradPlus.Startup))]
namespace GradPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
