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
            user.AddressID = 1;
            user.FirstName = "Topan";
            user.LastName = "Admin";
            user.MobileNumber = 09311212;
            user.CreatedBy = "admin";
            user.Gender = Core.Entities.Gender.Male;
            user.UpdatedBy = "admin";
            user.UpdatedDate = DateTime.UtcNow;
            user.CreatedDate = DateTime.UtcNow;
            user.Email = "email@gmail.com";
            user.IsActive = true;
            user.account = new Account
            {
                CreatedBy = "admin",
                CreatedDate = DateTime.UtcNow,
                PasswordHash = "password",
                Status = 1,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.UtcNow,
                UserName = "tpadmin"
            };
            user.Role = new Role
            {
                UpdatedDate = DateTime.UtcNow,
                UpdatedBy = "admin",
                CreatedBy = "admin",
                CreatedDate = DateTime.UtcNow,
                Description = "System Admininstrator",
                Name = "SystemAdmin"
            };
            DTO.Response<DTO.User> res = _userService.CreateUser(user);
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
