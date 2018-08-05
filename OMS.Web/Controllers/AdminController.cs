using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Interface.Services;
using OMS.Core.DTO;

namespace OMS.Web.Controllers
{



    public class AdminController : Controller
    {

        private readonly ITestService _service;
        private readonly IProductService _productservice;
        private readonly IVariantService _variantService;
        private readonly ICategoryService _categoryService;
        private readonly IAccountService _accountService;
        public AdminController(ITestService service, IProductService productservice,IVariantService variantService,ICategoryService categoryService,IAccountService accountService)
        {
            _service = service;
            _productservice = productservice;
            _variantService = variantService;
            _categoryService = categoryService;
            _accountService = accountService;
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
            Response<Variant> response = _variantService.CreateVariant(variant);

            return View();
        }



        public ActionResult Products()
        {

            return View(_productservice.ListProducts());

        }
        
        public ActionResult CreateProducts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProducts(Product product)
        {
            Response<Product> response = _productservice.CreateProduct(product);
            return View();

        }



        public ActionResult Category() {

            return View(_categoryService.ListCategories());

        }

        public ActionResult CreateCategory()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            Response<Category> response = _categoryService.CreateCategory(category);
            return View();

        }

        public ActionResult Employee()
        {

            return View(_accountService.ListAccounts());

        }

        public ActionResult CreateEmployee()
        {
         
            return View();

        }
        [HttpPost]
        public ActionResult CreateEmployee(Account account)
        {
            Response<Account> response = _accountService.CreateAccount(account);
            return View();

        }

        public ActionResult Admin()
        {

            return View(_accountService.ListAccounts());

        }

 

        public ActionResult CreateAdmin()
        {

            return View();

        }
        [HttpPost]
        public ActionResult CreateAdmin(Account account)
        {

            Response<Account> response = _accountService.CreateAccount(account);
            return View();

        }



    }
}