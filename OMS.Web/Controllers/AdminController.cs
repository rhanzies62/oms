using OMS.Core.Interface.Services;
using OMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IVariantService _variantService;
        public AdminController(IVariantService variantService, IProductService productService)
        {
            _variantService = variantService;
            _productService = productService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Variants()
        {
            return View(_variantService.ListVariants());
        }


        public ActionResult CreateVariants()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateVariants(Variant variant)
        {
            Response<Variant> response = new Response<Variant>();
            response = _variantService.CreateVariant(variant);
            
            return View(response.ErrorMessage);
        }

        public ActionResult Products()
        {
            return View(_productService.ListProducts());
        }
        public ActionResult CreateProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProducts(Product product)
        {
            Response<Product> response = new Response<Product>();
            response = _productService.CreateProduct(product);
            return View(response.ErrorMessage);
        }


        public ActionResult Category()
        {

            return View();
        }

        public ActionResult CreateCategory()
        {

            return View();
        }


        public ActionResult Employee()
        {

            return View();
        }

        public ActionResult CreateEmployee()
        {

            return View();
        }

        public ActionResult Admin()
        {

            return View();
        }

        public ActionResult CreateAdmin()
        {

            return View();
        }

    }
}