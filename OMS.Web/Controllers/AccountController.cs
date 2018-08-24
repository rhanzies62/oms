using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.DTO;
using OMS.Core.Interface.Services;


namespace OMS.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        public AccountController(IAccountService accountService,IUserService userService){

            _accountService = accountService;
            _userService = userService;

            }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account account)
        {
            Response<Account> response =_accountService.LoginAccount(account);

            if (response.Success.Equals(true))
            {
                //HttpCookie aCookie = new HttpCookie("AccountInfo");

                //aCookie.Values["Username"] = response.Data.UserName.ToString();
                //Response.Cookies.Add(aCookie);


                return RedirectToAction("Index", "Home");

            }

            else {
                TempData["Message"] = "You are not authorized.";
                return RedirectToAction("Index", "Account");
            }





            
        }



    }
}