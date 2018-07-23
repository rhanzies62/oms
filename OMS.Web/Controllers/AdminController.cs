using OMS.Core.Interface.Services;
using OMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Resource;

namespace OMS.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IVariantService _variantService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;

        public AdminController(IVariantService variantService, IProductService productService, ICategoryService categoryService, IUserService userService)
        {
            _variantService = variantService;
            _productService = productService;
            _categoryService = categoryService;
            _userService = userService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region variant
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
            if (response.Success.Equals(true)) {
                ViewBag.Message = OMSResource.SuccessfullyAdded;
            }else {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();
        }
        #endregion
        #region products
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
            if (response.Success.Equals(true))
            {
                ViewBag.Message = OMSResource.SuccessfullyAdded;
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();
        }

        #endregion
        #region category
        public ActionResult Category()
        {
            return View(_categoryService.ListCategories());
        }

        public ActionResult CategoryByVariantID(int variantID)
        {
            return View(_categoryService.ListCategoryByVariantID(variantID));
        }

        public ActionResult SubCategoryByCategoryID(int categoryID)
        {
            return View(_categoryService.ListSubCategoryByCategoryID(categoryID));
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            Response<Category> response = new Response<Category>();
            response = _categoryService.CreateCategory(category);
            if (response.Success.Equals(true))
            {
                ViewBag.Message = OMSResource.SuccessfullyAdded;
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();
        }

        #endregion
        #region user
        public ActionResult ActiveUserList()
        {
            return View(_userService.ListUsers(true));
        }
        public ActionResult InActiveUserList()
        {
            return View(_userService.ListUsers(false));
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            Response<User> response = new Response<User>();
            response = _userService.CreateUser(user);
            if (response.Success.Equals(true))
            {
                ViewBag.Message = OMSResource.SuccessfullyAdded;
            }
            else
            {
                ViewBag.Message = response.ErrorMessage;
            }
            return View();
        }

        #endregion

    }
}