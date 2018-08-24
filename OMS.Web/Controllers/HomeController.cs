using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Web.Models;
using OMS.Core.DTO;

namespace OMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _service;
        private readonly IProductService _productservice;
        private readonly IOrderService _orderService;
        public HomeController(ITestService service, IProductService productservice,IOrderService orderService)
        {
            _service = service;
            _productservice = productservice;
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

  


            return View(_productservice.ListProducts());


        }



        public ActionResult AddToOrders() {

            return View();
        }

           [HttpPost] 
        public ActionResult AddToOrders(Order order)
        {


            Response<Order> response = _orderService.CreateOrder(order);
            if (response.Success.Equals(true))
            {
                ViewBag.Message = "Successfully Added";
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();
        }


        public ActionResult ShowOrders() {

            return View();

        }




  
    }
}