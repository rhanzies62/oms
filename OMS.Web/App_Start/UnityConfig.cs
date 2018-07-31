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
            var container1 = new UnityContainer();
            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IProductService, ProductService>();
            var container2 = new UnityContainer();
            container.RegisterType<IVariantService, VariantService>();
            var container3 = new UnityContainer();
            container.RegisterType<ICategoryService, CategoryService>();
            var container4 = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            var container5 = new UnityContainer();
            container.RegisterType<IRoleService, RoleService>();
            var container6 = new UnityContainer();
            container.RegisterType<IOrderService, OrderService>();


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container1));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container1);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container2));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container2);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container3));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container3);


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container4));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container4);


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container5));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container5);

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container6));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container6);


        }
    }
}