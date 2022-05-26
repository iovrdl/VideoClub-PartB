using Microsoft.Owin;
using Owin;
using VideoClub.Web;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace VideoClub.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}