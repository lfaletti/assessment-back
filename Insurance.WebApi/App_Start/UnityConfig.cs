using Insurance.Services.Authentication;
using Insurance.Services.Authentications;
using Insurance.Services.Clients;
using Insurance.Services.Models;
using Insurance.Services.Policies;
using Insurance.Services.Providers;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace Insurance.WebApi4
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAuthenticationService, AuthenticationService>();

            container.RegisterType<IClientService, ClientService>(
                new InjectionConstructor(new ClientDataProvider<Client, ClientCollection>("http://www.mocky.io/", "v2/5808862710000087232b75ac")));

            container.RegisterType<IPolicyService, PolicyService>(
                new InjectionConstructor(new PolicyDataProvider<Policy, PolicyCollection>("http://www.mocky.io/", "v2/580891a4100000e8242b75c5")));

 
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}