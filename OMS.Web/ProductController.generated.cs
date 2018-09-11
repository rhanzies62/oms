// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace OMS.Web.Controllers
{
    public partial class ProductController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ProductController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult GetProduct()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetProduct);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult RemoveProduct()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.RemoveProduct);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ProductController Actions { get { return MVC.Product; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Product";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Product";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string ListProducts = "ListProducts";
            public readonly string CreateProduct = "CreateProduct";
            public readonly string GetCategory = "GetCategory";
            public readonly string GetProduct = "GetProduct";
            public readonly string RemoveProduct = "RemoveProduct";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string ListProducts = "ListProducts";
            public const string CreateProduct = "CreateProduct";
            public const string GetCategory = "GetCategory";
            public const string GetProduct = "GetProduct";
            public const string RemoveProduct = "RemoveProduct";
        }


        static readonly ActionParamsClass_ListProducts s_params_ListProducts = new ActionParamsClass_ListProducts();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListProducts ListProductsParams { get { return s_params_ListProducts; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListProducts
        {
            public readonly string search = "search";
            public readonly string categoryid = "categoryid";
        }
        static readonly ActionParamsClass_CreateProduct s_params_CreateProduct = new ActionParamsClass_CreateProduct();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateProduct CreateProductParams { get { return s_params_CreateProduct; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateProduct
        {
            public readonly string product = "product";
        }
        static readonly ActionParamsClass_GetProduct s_params_GetProduct = new ActionParamsClass_GetProduct();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetProduct GetProductParams { get { return s_params_GetProduct; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetProduct
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_RemoveProduct s_params_RemoveProduct = new ActionParamsClass_RemoveProduct();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_RemoveProduct RemoveProductParams { get { return s_params_RemoveProduct; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_RemoveProduct
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string CreateProduct = "CreateProduct";
                public readonly string Index = "Index";
            }
            public readonly string CreateProduct = "~/Views/Product/CreateProduct.cshtml";
            public readonly string Index = "~/Views/Product/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ProductController : OMS.Web.Controllers.ProductController
    {
        public T4MVC_ProductController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ListProductsOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string search, int categoryid);

        [NonAction]
        public override System.Web.Mvc.JsonResult ListProducts(string search, int categoryid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.ListProducts);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "search", search);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "categoryid", categoryid);
            ListProductsOverride(callInfo, search, categoryid);
            return callInfo;
        }

        [NonAction]
        partial void CreateProductOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateProduct()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateProduct);
            CreateProductOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateProductOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, OMS.Core.DTO.Product product);

        [NonAction]
        public override System.Web.Mvc.JsonResult CreateProduct(OMS.Core.DTO.Product product)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CreateProduct);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "product", product);
            CreateProductOverride(callInfo, product);
            return callInfo;
        }

        [NonAction]
        partial void GetCategoryOverride(T4MVC_System_Web_Mvc_JsonResult callInfo);

        [NonAction]
        public override System.Web.Mvc.JsonResult GetCategory()
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetCategory);
            GetCategoryOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GetProductOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.JsonResult GetProduct(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.GetProduct);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            GetProductOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void RemoveProductOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.JsonResult RemoveProduct(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.RemoveProduct);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            RemoveProductOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
