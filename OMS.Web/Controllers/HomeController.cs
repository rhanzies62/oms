using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Entities;

namespace OMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _service;
        private readonly IProductService _productservice;
        public HomeController(ITestService service, IProductService productservice)
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

            List<Product> prodList = new List<Product>();
            Product prod = new Product();
            prod.CategoryID = 1;
            prod.ID = 1;
            prod.Name = "Plywood";
            prod.Price = 1000;
            prod.Description = "sample";

            Product prod1 = new Product();
            prod1.CategoryID = 2;
            prod1.ID = 2;
            prod1.Name = "Plywood1";
            prod1.Price = 2000;
            prod1.Description = "sample1";

            prodList.Add(prod1);
            prodList.Add(prod);


        return View(prodList);


        }




        }
}