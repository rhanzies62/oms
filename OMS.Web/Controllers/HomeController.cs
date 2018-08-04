using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Entities;
using OMS.Service.Services;

namespace OMS.Web.Controllers
{
    public class HomeController : Controller
    {

        


        private readonly ITestService _service;
        private readonly IOrderService _orderService;
<<<<<<< HEAD
=======
<<<<<<< HEAD
        private readonly IProductService _productService;
        public HomeController(ITestService service,IOrderService orderService, IProductService productService)
=======
>>>>>>> origin/Dev

        public HomeController(ITestService service)
>>>>>>> d22b3aa29488a2d06171c8a47f9e3e49167b49c9
        {
            _service = service;
            _orderService = orderService;
            _productService = productService;

        }


        public HomeController(IOrderService orderService)
        {
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

            return View(_productService.ListProducts());
        }



       [HttpPost]
        public ActionResult AddProductToOrder(int ProductId,int Quantity)
        {


            return View();

        }



        public ActionResult ShowOrder()
        {

            

            return View();


        }



        public ActionResult ShowOrder()
        {

            

            return View();


        }


    }
}