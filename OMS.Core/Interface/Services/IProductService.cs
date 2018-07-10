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

        Response<Product> CreateProduct(Product product);

        Response<Product> UpdateProduct(Product product);

        Response<Product> RemoveProduct(int productID);

        Product GetProductByID(int productID);

        IEnumerable<Product> ListProductsByVariantID(int variantID);

        IEnumerable<Product> ListProductsByCategory(int categoryID);
    }
}
