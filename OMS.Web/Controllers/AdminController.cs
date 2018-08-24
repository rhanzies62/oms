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
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;
        public AdminController(IUserService userService,IRoleService roleService, ITestService service, IProductService productservice,IVariantService variantService,ICategoryService categoryService,IAccountService accountService)
        {
            _service = service;
            _productservice = productservice;
            _variantService = variantService;
            _categoryService = categoryService;
            _accountService = accountService;
            _roleService = roleService;
            _userService = userService;
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

            variant.CreatedBy = Request.Cookies["Username"].Value;
            Response<Variant> response = _variantService.CreateVariant(variant);

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
           // product.CreatedBy = Request.Cookies["Username"].Value;
            Response<Product> response = _productservice.CreateProduct(product);
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



        public ActionResult Category() {

            return View(_categoryService.ListCategories());

        }

        public ActionResult CreateCategory()
        {
            
          var varlist =  _variantService.ListVariants();
            SelectList list = new SelectList(varlist ,"ID", "Name",1);
            ViewBag.variantlist = list;


            return View();



        }

        

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
         //  category.CreatedBy = Request.Cookies["Username"].Value;
            Response<Category> response = _categoryService.CreateCategory(category);
         
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
            account.CreatedBy = Request.Cookies["Username"].Value;
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

        public ActionResult Role()
        {

            

            var listRole = _roleService.ListRoles();
            

          


            return View(_roleService.ListRoles());

        }


        public ActionResult CreateRole()
        {

            return View();

        }

        [HttpPost]
        public ActionResult CreateRole(Role role)
        {

            Response<Role> response = _roleService.CreateRole(role);
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


        public ActionResult CreateUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {

            Response<User> response = _userService.CreateUser(user);
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





    }
}