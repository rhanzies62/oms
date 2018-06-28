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
using System.Globalization;

using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

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

            DTO.Address address = new DTO.Address();
            address.AddressLineOne = "22 P.halili St.";
            address.AddressLineTwo = "phalili";
            address.City = "Caloocan";
            address.PostalCode = "123";
            address.CreatedBy = "lorenz";
            address.UpdatedBy = "lorenz";
            address.UpdatedDate = convertedBack;
            address.CreatedDate = convertedBack;

            DTO.Role role = new DTO.Role();
            role.CreatedBy = "lorenz pascual";
            role.CreatedDate = convertedBack;
            role.UpdatedBy = "lorenz";
            role.UpdatedDate = convertedBack;
            role.Name = "Employee";
            role.Description = "Employee";

            DTO.Account account = new DTO.Account();
            account.UpdatedBy = "lorenz";
            account.UpdatedDate = convertedBack;
            account.CreatedBy = "lorenz";
            account.CreatedDate = convertedBack;
            account.PasswordHash = "password";
            account.Salt = "salt";
            account.Status = DTO.Status.Active;
            account.Role = role;
            account.UserName = "uname";
            
            user.Account = account;
            user.Address= address;
            user.FirstName = "fname";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = DTO.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";
            user.Status = Core.DTO.Status.Active;
            Response<DTO.User> res = _service.CreateUser(user);
        }

        [TestMethod]
        public void TestUpdateUser() {
            DTO.User user = new DTO.User();
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var convertedBack = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            user.ID = 3;
            user.AddressID = 6;
            user.AccountID = 1;
            user.FirstName = "kitt";
            user.LastName = "lname";
            user.MobileNumber = 09311212;
            user.CreatedBy = "lorenz";
            user.Gender = DTO.Gender.Male;
            user.UpdatedBy = "lorenz";
            user.UpdatedDate = convertedBack;
            user.CreatedDate = convertedBack;
            user.Email = "email@gmail.com";
            user.Status = DTO.Status.Active;
            Response<DTO.User> res = _service.UpdateUser(user);

        }
    }
}
