using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;
using OMS.Repository;
using OMS.Repository.Repositories;
using System.Globalization;
using OMS.Service.Services;

namespace OMS.UnitTest
{
    [TestClass]
    public class TestUserService
    {
        OMSContext context = new OMSContext();
        CRUDRepository<Entities.User> _userRepo;
        private UserService _service;
        [TestInitialize]
        public void initservice()
        {
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
            
            user.AccountID = 1;
            user.AddressID = 1;
            user.FirstName = "fname";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = Entities.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";
            user.IsActive = true;
            DTO.Response<DTO.User> res = _service.CreateUser(user);
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            DTO.User user = new DTO.User();
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var convertedBack = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            user.ID = 1;
            user.AddressID = 1;
            user.AccountID = 1;
            user.FirstName = "lorenz";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = Entities.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";
            user.IsActive = true;
            DTO.Response<DTO.User> res = _service.UpdateUser(user);

        }
    }
}
