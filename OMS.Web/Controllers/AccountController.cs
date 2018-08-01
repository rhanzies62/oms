using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMS.Core.Interface.Services;
using OMS.Core.DTO;

namespace OMS.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;


        public AccountController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        // GET: Account
        public ActionResult Index()
        {




            return View();
        }

        [HttpPost]
        public ActionResult Index(Account account)
        {


           Response<Account> response =  _accountService.LoginAccount(account);
            




            return View();

        
        }

    }
}