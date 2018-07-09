using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;
namespace OMS.Core.Interface.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> ListCategories();
        
        Response<Category> CreateCategory(Category category);

        Response<Category> UpdateCategory(Category category);

        Response<Category> RemoveCategory(int categoryID);

        Category GetCategoryByID(int categoryID);

        IEnumerable<Category> ListCategoryByVariantID(int variantID);
        IEnumerable<Category> ListSubCategoryByCategoryID(int categoryID);

    }
}
