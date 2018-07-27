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

        public HomeController(ITestService service)
        {
            _service = service;
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



            return View();
        }



        public ActionResult ShowOrder()
        {

            

            return View();


        }


    }
}