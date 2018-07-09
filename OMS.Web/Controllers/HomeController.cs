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
        public HomeController(ITestService service)
        {
            _service = service;
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
            Product Prod = new Product();
            Prod.Name = "1 X 2 x 8ft";
            Prod.Description = "Plywood";
            Prod.Price = 67;
            Prod.CreatedBy = "Keith Van Capiral";
            Prod.CreatedDate = DateTime.UtcNow;
            Prod.UpdatedBy = "Keith";
            Prod.UpdatedDate = DateTime.UtcNow;

            Product Prod1 = new Product();
            Prod1.Name = "1 X 2 x 10ft";
            Prod1.Description = "Plywood";
            Prod1.Price = 67;
            Prod1.CreatedBy = "Keith Van Capiral";
            Prod1.CreatedDate = DateTime.UtcNow;
            Prod1.UpdatedBy = "Keith";
            Prod1.UpdatedDate = DateTime.UtcNow;





            List<Product> Products = new List<Product>();
            Products.Add(Prod);
            Products.Add(Prod1);




            return View(Products);
        }


    }
}