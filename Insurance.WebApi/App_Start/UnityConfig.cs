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
using System.Configuration;
using Insurance.Database.Users;
using Insurance.Database;
using Microsoft.AspNet.Identity.EntityFramework;
using Insurance.Database.Roles;
using Unity.Lifetime;

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


            container.RegisterType<IAuthenticationService, AuthenticationService>();
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