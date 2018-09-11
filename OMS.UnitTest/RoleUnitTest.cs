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
    }
}
