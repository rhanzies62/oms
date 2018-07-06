using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using AutoMapper;
using OMS.Core.Interface.Repositories;

namespace OMS.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICRUDRepository<Entities.Category> _categoryRepo;
        public CategoryService(ICRUDRepository<Entities.Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public DTO.Response<DTO.Category> CreateCategory(DTO.Category category)
        {
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                category.CreatedDate = DateTime.UtcNow;
                category.UpdatedDate = DateTime.UtcNow;
                _categoryRepo.Add(Mapper.Map<DTO.Category, Entities.Category>(category));
                response.Success = true;
                response.Data = category;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Category GetCategoryByID(int categoryID)
        {
            return Mapper.Map<Entities.Category, DTO.Category>(_categoryRepo.GetSingle(u => u.ID.Equals(categoryID)));
        }

        public IEnumerable<DTO.Category> ListCategories()
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetAll());
        }

        public IEnumerable<DTO.Category> ListCategoryByVariantID(int variantID)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(c => c.VariantID.Equals(variantID)));
        }

        public IEnumerable<DTO.Category> ListSubCategoryByCategoryID(int categoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(c => c.ParentCategoryId.Equals(categoryID)));
        }

        public DTO.Response<DTO.Category> RemoveCategory(int categoryID)
        {
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                Entities.Category category = _categoryRepo.GetSingle(u => u.ID.Equals(categoryID));
                _categoryRepo.Remove(category);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Category, DTO.Category>(category);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Category> UpdateCategory(DTO.Category category)
        {
            category.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Category> response = new DTO.Response<DTO.Category>();
            try
            {
                _categoryRepo.Update(Mapper.Map<DTO.Category, Entities.Category>(category));
                response.Success = true;
                response.Data = category;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }
    }
}
