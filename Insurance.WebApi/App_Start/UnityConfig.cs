using Insurance.ApiProviders.Clients;
using Insurance.ApiProviders.Policies;
using Insurance.Database;
using Insurance.Database.Roles;
using Insurance.Database.Users;
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
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Insurance.Database.Services.Identity;

namespace Insurance.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<InsuranceContext, InsuranceContext>();

            container.RegisterType<IInsuranceUserManager<IdentityUser,string>, InsuranceUserManager>(
                new InjectionConstructor(new ResolvedParameter<InsuranceContext>()));

            container.RegisterType<IInsuranceRoleManager, InsuranceRoleManager>(
                new InjectionConstructor(new ResolvedParameter<InsuranceContext>()));

            container.RegisterType<IInsuranceUserStore, InsuranceUserStore>(
             new InjectionConstructor(new ResolvedParameter<InsuranceContext>()));

            container.RegisterType<InsuranceRoleStore, InsuranceRoleStore>(
        new InjectionConstructor(new ResolvedParameter<InsuranceContext>()));


            container.RegisterType<IIdentityService, IdentityService>();
            container.RegisterType<ILogService, LogService>();

            container.RegisterType<IClientsProvider<ClientServiceModel>,
                ClientDataProvider<ClientServiceModel>>(
                new InjectionConstructor(ConfigurationManager.AppSettings["clientsExternalUrlBase"], ConfigurationManager.AppSettings["clientsExternalUrlResource"]));

            container.RegisterType<IClientService, ClientService>(
                new InjectionConstructor(
                    new ResolvedParameter<IClientsProvider<ClientServiceModel>>(),
                    new ResolvedParameter<IPoliciesProvider<PolicyServiceModel>>()
                ));

            container.RegisterType<IPoliciesProvider<PolicyServiceModel>,
             PoliciesProvider<PolicyServiceModel>>(
                new InjectionConstructor(ConfigurationManager.AppSettings["policiesExternalUrlBase"], ConfigurationManager.AppSettings["policiesExternalUrlResource"]));

            container.RegisterType<IPolicyService, PolicyService>(
                 new InjectionConstructor(
                     new ResolvedParameter<IPoliciesProvider<PolicyServiceModel>>(),
                     new ResolvedParameter<IClientsProvider<ClientServiceModel>>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}