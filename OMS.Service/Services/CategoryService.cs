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

        public DTO.Response<DTO.Category> CreateCategory(DTO.Category Category)
        {
            DTO.Response<DTO.Category> category = new DTO.Response<DTO.Category>();
            try
            {
                Category.CreatedDate = DateTime.UtcNow;
                Category.UpdatedDate = DateTime.UtcNow;
                _categoryRepo.Add(Mapper.Map<DTO.Category, Entities.Category>(Category));
                category.Success = true;
                category.Data = Category;
            }
            catch (Exception e)
            {
                category.ErrorMessage = e.GetBaseException().Message;
                category.Success = false;
            }
            return category;
        }

        public DTO.Category GetCategoryByID(int categoryID)
        {
            return Mapper.Map<Entities.Category, DTO.Category>(_categoryRepo.GetSingle(u => u.ID.Equals(categoryID)));
        }

        public IEnumerable<DTO.Category> ListCategories()
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetAll());
        }

        public IEnumerable<DTO.Category> ListCategoryByVariantID(int VariantID)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(c => c.VariantID.Equals(VariantID)));
        }

        public IEnumerable<DTO.Category> ListSubCategoryByCategoryID(int CategoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Category>, IEnumerable<DTO.Category>>(_categoryRepo.GetList(c => c.ParentCategoryId.Equals(CategoryID)));
        }

        public DTO.Response<DTO.Category> RemoveCategory(int categoryID)
        {
            DTO.Response<DTO.Category> category = new DTO.Response<DTO.Category>();
            try
            {
                Entities.Category Category = _categoryRepo.GetSingle(u => u.ID.Equals(categoryID));
                _categoryRepo.Remove(Category);
                category.Success = true;
                category.Data = Mapper.Map<Entities.Category, DTO.Category>(Category);
            }
            catch (Exception e)
            {
                category.ErrorMessage = e.GetBaseException().Message;
                category.Success = false;
            }
            return category;
        }

        public DTO.Response<DTO.Category> UpdateCategory(DTO.Category Category)
        {
            Category.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Category> category = new DTO.Response<DTO.Category>();
            try
            {
                _categoryRepo.Update(Mapper.Map<DTO.Category, Entities.Category>(Category));
                category.Success = true;
                category.Data = Category;
            }
            catch (Exception e)
            {
                category.ErrorMessage = e.GetBaseException().Message;
                category.Success = false;
            }
            return category;
        }
    }
}
