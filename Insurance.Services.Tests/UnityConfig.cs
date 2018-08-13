using System.Configuration;
using Insurance.ApiProviders.Clients;
using Insurance.ApiProviders.Policies;
using Insurance.IApiProviders.Clients;
using Insurance.IApiProviders.Policies;
using Insurance.IServices.IAuthentication;
using Insurance.IServices.IClients;
using Insurance.IServices.ILogging;
using Insurance.IServices.IPolicies;
using Insurance.IServices.ServiceModels;
using Insurance.Services.Authentication;
using Insurance.Services.Logging;
using Insurance.Services.Policies;
using Insurance.Services.Clients;
using Unity;
using Unity.Injection;

namespace Insurance.Services.Test
{
    public class UnityConfig
    {
        public static IUnityContainer RegisterAllServices()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IAuthenticationService, AuthenticationService>();
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