using AutoMapper;
using OMS.Core.DTO;
using OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
using OMS.Core.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;

namespace OMS.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private ICRUDRepository<Entities.Category> _categoryRepo;
        public CategoryService()
        {
        }

        public CategoryService(ICRUDRepository<Entities.Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
            AutoMapperCoreConfiguration.Configure();

        }
        public Response<DTO.Category> CreateCategory(DTO.Category Category)
        {
            Response<DTO.Category> response = new Response<DTO.Category>();
            try
            {
                _categoryRepo.Add(Mapper.Map<DTO.Category, Entities.Category>(Category));
                response.Data = Category;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public DTO.Category GetCategory(int id)
        {
            return Mapper.Map<Entities.Category, DTO.Category>(_categoryRepo.GetSingle(u => u.ID.Equals(id)));
        }

        public IEnumerable<DTO.Category> ListCategories()
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetAll());
        }

        public IEnumerable<DTO.Category> ListCategoriesByVariant(int id)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(u => u.VariantID.Equals(id)));
        }

        public IEnumerable<DTO.Category> ListSubCategories(int id)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(u => u.ParentCategoryId.Equals(id)));
        }

        public Response<DTO.Category> RemoveCategory(int id)
        {
            Response<DTO.Category> response = new Response<DTO.Category>();
            try
            {
                var Category = _categoryRepo.GetSingle(u => u.ID.Equals(id));
                _categoryRepo.Remove(Category);
                response.Data = Mapper.Map<Entities.Category, DTO.Category>(Category);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Category> UpdateCategory(DTO.Category Category)
        {
            Response<DTO.Category> response = new Response<DTO.Category>();
            try
            {
                _categoryRepo.Update(Mapper.Map<DTO.Category, Entities.Category>(Category));
                response.Data = Category;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }
    }
}
