using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OMS.Core.DTO;
using System.Threading.Tasks;

namespace OMS.Core.Interface.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> ListCategories();

        IEnumerable<Category> ListSubCategories(int id);

        IEnumerable<Category> ListCategoriesByVariant(int id);

        Response<Category> CreateCategory(Category Category);

        Response<Category> UpdateCategory(Category Category);

        Response<Category> RemoveCategory(int id);

        Category GetCategory(int id);

    }
}
