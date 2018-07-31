using OMS.Core.Interface.Services;
using System;
using OMS.Core.Resource;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Entities;
using OMS.Core.DTO;

namespace OMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _service;
        private readonly IProductService _productService;
        private readonly IVariantService _variantService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IOrderService _orderService;
        public HomeController(ITestService service, IVariantService variantService, IProductService productService, ICategoryService categoryService, IUserService userService, IRoleService roleService, IOrderService orderService)
        {
            _service = service;
            _variantService = variantService;
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
            _roleService = roleService;
            _orderService = orderService;
        }







        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = _service.GetName(); //"Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult ProductList()
        {

            return View();

        }






        public ActionResult ShowOrders()
        {


            return View();


        }

    }
}