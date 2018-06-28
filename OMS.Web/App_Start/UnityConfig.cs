using OMS.Core.Interface.Services;
using OMS.Core.Interface.Repositories;
using OMS.Service.Services;
using System.Web.Http;
using System.Web.Mvc;
using OMS.Repository.Repositories;
using Unity;
using Unity.WebApi;

namespace OMS.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}