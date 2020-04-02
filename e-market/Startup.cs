using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(e_market.Startup))]
namespace e_market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
