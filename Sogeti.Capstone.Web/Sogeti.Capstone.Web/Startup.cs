using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sogeti.Capstone.Web.Startup))]
namespace Sogeti.Capstone.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
