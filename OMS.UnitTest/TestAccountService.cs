using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMS.Repository;
using OMS.Repository.Repositories;
using OMS.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;


namespace OMS.UnitTest
{
    [TestClass]
    public class TestAccountService
    {
        OMSContext context = new OMSContext();
        CRUDRepository<Entities.Account> _accountRepo;
        private AccountService _service;
        [TestInitialize]
        public void initservice()
        {
            _accountRepo = new CRUDRepository<Entities.Account>(context);
            _service = new AccountService(_accountRepo);
        }
        [TestMethod]
        public void TestLoginAccount()
        {
            string username = "uname";
            string password = "password";
            var account = _service.LoginAccount(username,password);

        }
    }

}