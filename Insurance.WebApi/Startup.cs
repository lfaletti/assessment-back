using Insurance.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Insurance.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            OAuthConfiguration.ConfigureOAuth(app);
        }
    }
}