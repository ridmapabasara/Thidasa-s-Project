using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ThidasaAssignemnt.Startup))]
namespace ThidasaAssignemnt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
