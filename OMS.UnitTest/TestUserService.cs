using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMS.Core.Interface.Services;
using OMS.Core.DTO;
using OMS.Service.Services;
using OMS.Core.Mapper;
using OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using OMS.Repository.Repositories;
using OMS.Repository;
using Moq;
using System.Globalization;

namespace OMS.UnitTest
{
    [TestClass]
    public class TestUserService
    {
        OMSContext context = new OMSContext();
        CRUDRepository<User> _userRepo;
        private UserService _service;
        [TestInitialize]
        public void initservice() {
            _userRepo = new CRUDRepository<User>(context);
            _service = new UserService(_userRepo);
        }

        [TestMethod]
        public void TestCreateUser()
        {

            UserViewModel user = new UserViewModel();
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var convertedBack = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            AccountViewModel account = new AccountViewModel();
            account.UpdatedBy = "lorenz";
            account.UpdatedDate = convertedBack;
            account.CreatedBy = "lorenz";
            account.CreatedDate = convertedBack;
            account.PasswordHash = "password";
            account.Salt = "salt";
            account.Status = Core.DTO.Status.Active;
            account.RoleID = 2;
            account.UserName = "uname";
            
            user.Account = account;
            user.AddressID = 6;
            user.FirstName = "fname";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = Core.DTO.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";

            Response<UserViewModel> res = _service.CreateUser(user);
        }

    }
}
