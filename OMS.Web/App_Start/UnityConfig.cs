using OMS.Core.Entities;
using OMS.Repository.Repositories;
using OMS.Core.Interface.Repositories;
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
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductService, ProductService>();

 
   
        DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            container.RegisterType<IVariantService, VariantService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<ICRUDRepository<Variant>, CRUDRepository<Variant>>();
            container.RegisterType<ICRUDRepository<Product>, CRUDRepository<Product>>();
            container.RegisterType<ICRUDRepository<Category>, CRUDRepository<Category>>();
            container.RegisterType<ICRUDRepository<User>, CRUDRepository<User>>();
            container.RegisterType<ICRUDRepository<Role>, CRUDRepository<Role>>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


            var orderContainer = new UnityContainer();

            orderContainer.RegisterType<IOrderService, OrderService>();
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(orderContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(orderContainer);







        }
    }
}