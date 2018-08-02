using OMS.Core.Interface.Services;
using OMS.Service.Services;
using System.Web.Http;
using System.Web.Mvc;
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
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<IVariantService, VariantService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRoleService, RoleService>();
   
        DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}