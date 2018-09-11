using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.DTO;
using OMS.Core.Interface.Services;
using OMS.Web.Models;
using OMS.Web.Extension;
using System.Web.Security;
using Newtonsoft.Json;
using OMS.Web.Security;
using DTO = OMS.Core.DTO;

namespace OMS.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public AccountController(IAccountService accountService, IUserService userService)
        {

            _accountService = accountService;
            _userService = userService;

        }

        // GET: Account
        [OMSAuth]
        public virtual ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public virtual JsonResult Index(UserCredentialViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var result = _accountService.LoginAccount(viewmodel.MapToAccount());
                if (result.Success)
                {
                    var serializableObject = new AppSerializeModal
                    {
                        UserId = result.Data.ID,
                        Username = result.Data.UserName,
                        Email = result.Data.User?.Email,
                        FirstName = result.Data.User?.FirstName,
                        LastName = result.Data.User?.LastName
                    };
                    string userData = JsonConvert.SerializeObject(serializableObject);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, viewmodel.Username, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, enTicket);
                    faCookie.Expires = DateTime.Now.AddMinutes(15);
                    Response.Cookies.Add(faCookie);
                }
                return Json(result);
            }
            return Json(true);
        }
    }
}