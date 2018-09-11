using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMS.Web.Controllers
{
    public partial class EmployeeController : BaseController
    {
        // GET: Employee
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}