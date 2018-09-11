using Insurance.ApiProviders.Clients;
using Insurance.ApiProviders.Policies;
using Insurance.Database.Services.Identity;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.ApiProviders.Identity;
using Insurance.ApiProviders.IClients;
using Insurance.ApiProviders.ILogging;
using Insurance.ApiProviders.IPolicies;
using Insurance.ApiProviders.Models;
using Insurance.ApiProviders.Clients;
using Insurance.ApiProviders.Logging;
using Insurance.ApiProviders.Policies;
using System.Configuration;
using Unity;
using Unity.Injection;

namespace Insurance.ApiProviders.Test
{
    public class UnityConfig
    {
        public static IUnityContainer RegisterAllServices()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILogService, LogService>();

            container.RegisterType<IClientsProvider<ClientServiceModel>,
                ClientDataProvider<ClientServiceModel>>(
                new InjectionConstructor(ConfigurationManager.AppSettings["clientsExternalUrlBase"],
                    ConfigurationManager.AppSettings["clientsExternalUrlResource"]));

            container.RegisterType<IClientService, ClientService>(
                new InjectionConstructor(
                    new ResolvedParameter<IClientsProvider<ClientServiceModel>>(),
                    new ResolvedParameter<IPoliciesProvider<PolicyServiceModel>>()
                ));

            container.RegisterType<IPoliciesProvider<PolicyServiceModel>,
                PoliciesProvider<PolicyServiceModel>>(
                new InjectionConstructor(ConfigurationManager.AppSettings["policiesExternalUrlBase"],
                    ConfigurationManager.AppSettings["policiesExternalUrlResource"]));

            container.RegisterType<IPolicyService, PolicyService>(
                new InjectionConstructor(
                    new ResolvedParameter<IPoliciesProvider<PolicyServiceModel>>(),
                    new ResolvedParameter<IClientsProvider<ClientServiceModel>>()));

            return container;
        }
    }
}