using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OMS.Repository.Repositories;
using OMS.Repository;
using OMS.Service.Services;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using OMS.Core.Mapper;
namespace OMS.UnitTest
{
    [TestClass]
    public class RoleUnitTest
    {
        OMSContext context = new OMSContext();
        CRUDRepository<Entities.Role> _roleRepo;
        CRUDRepository<Entities.Category> _catRepo;
        private RoleService _service;
        private CategoryService _catservice;

        [TestInitialize]
        public void initservice()
        {
            AutoMapperCoreConfiguration.Configure();
            _roleRepo = new CRUDRepository<Entities.Role>(context);
            _service = new RoleService(_roleRepo);

            _catRepo = new CRUDRepository<Entities.Category>(context);
            _catservice = new CategoryService(_catRepo);
        }
        [TestMethod]
        public void TestMethod1()
        {
            DTO.Role Role = new DTO.Role();
            Role.Name = "Driver";
            Role.Description = "Driver of th van";
            Role.CreatedBy = "lorenz";
            Role.CreatedDate = DateTime.UtcNow;
            Role.UpdatedBy = "lorenz";
            Role.UpdatedDate = DateTime.UtcNow;

            DTO.Response<DTO.Role> role = _service.CreateRole(Role);
        }
        [TestMethod]
        public void TestMethod2()
        {
            DTO.Category Category = new DTO.Category();
            Category.Name = "Driver";
            Category.Description = "Driver of th van";
            Category.CreatedBy = "lorenz";
            Category.CreatedDate = DateTime.UtcNow;
            Category.UpdatedBy = "lorenz";
            Category.UpdatedDate = DateTime.UtcNow;
            Category.VariantID = 1;

            DTO.Response<DTO.Category> category = _catservice.CreateCategory(Category);
        }
    }
}
