using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMS.Core.Interface.Services;
using OMS.Service.Services;
using OMS.Core.Mapper;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
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
        CRUDRepository<Entities.User> _userRepo;
        private UserService _service;
        [TestInitialize]
        public void initservice() {
            _userRepo = new CRUDRepository<Entities.User>(context);
            _service = new UserService(_userRepo);
        }

        [TestMethod]
        public void TestCreateUser()
        {

            DTO.User user = new DTO.User();
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var convertedBack = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            DTO.Account account = new DTO.Account();
            account.UpdatedBy = "lorenz";
            account.UpdatedDate = convertedBack;
            account.CreatedBy = "lorenz";
            account.CreatedDate = convertedBack;
            account.PasswordHash = "password";
            account.Salt = "salt";
            account.Status = DTO.Status.Active;
            account.RoleID = 2;
            account.UserName = "uname";
            
            user.Account = account;
            user.AddressID = 6;
            user.FirstName = "fname";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = DTO.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";

            DTO.Response<DTO.User> res = _service.CreateUser(user);
        }

    }
}
