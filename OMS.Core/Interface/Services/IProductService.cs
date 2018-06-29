using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IProductService
    {
        IEnumerable<Product> ListProducts();
        IEnumerable<Product> ListProductsByVariant(int id);
        IEnumerable<Product> ListProductsByCategory(int id);

        Response<Product> CreateProduct(Product Product);

        Response<Product> UpdateProduct(Product Product);

        Response<Product> RemoveProduct(int id);

        Product GetProduct(int id);
        Product GetProduct(string name);

    }
}
