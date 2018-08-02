using Insurance.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Insurance.Startup))]

namespace Insurance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OAuthConfiguration.ConfigureOAuth(app);
        }
    }
}