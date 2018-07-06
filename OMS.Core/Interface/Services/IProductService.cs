using OMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Interface.Services
{
    public interface IProductService
    {
        IEnumerable<Product> ListProducts();

        Response<Product> CreateProduct(Product Product);

        Response<Product> UpdateProduct(Product Product);

        Response<Product> RemoveProduct(int ProductID);

        Product GetProductByID(int ProductID);

        IEnumerable<Product> ListProductsByVariantID(int VariantID);

        IEnumerable<Product> ListProductsByCategory(int CategoryID);
    }
}
