using Insurance.ApiProviders.Clients;
using Insurance.ApiProviders.Providers;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.IServices.Authentication;
using Insurance.IServices.Clients;
using Insurance.IServices.ServiceModels;
using Insurance.IServices.Policies;
using Insurance.Services.Authentication;
using Insurance.Services.Clients;
using Insurance.Services.Logging;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Insurance.IApiProviders.Models;

namespace Insurance.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAuthenticationService, AuthenticationService>();
            container.RegisterType<ILogService, LogService>();

            container.RegisterType<IClientsProvider<ClientServiceModel>,
                ClientDataProvider<ClientServiceModel>>(
                new InjectionConstructor("http://www.mocky.io/", "v2/5808862710000087232b75ac"));

            container.RegisterType<IClientService, ClientService>(
                new InjectionConstructor(new ResolvedParameter<IClientsProvider<ClientServiceModel>>()));

            container.RegisterType<IPoliciesProvider<PolicyServiceModel>,
             PoliciesProvider<PolicyServiceModel>>(
                new InjectionConstructor("http://www.mocky.io/", "v2/580891a4100000e8242b75c5"));

            container.RegisterType<IPolicyService, PolicyService>(
                 new InjectionConstructor(
                     new ResolvedParameter<IPoliciesProvider<PolicyServiceModel>>(),
                     new ResolvedParameter<IClientsProvider<ClientServiceModel>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}