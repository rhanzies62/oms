using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using AutoMapper;
using OMS.Core.Interface.Services;
using OMS.Core.Interface.Repositories;

namespace OMS.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ICRUDRepository<Entities.Product> _productRepo;
        public ProductService(ICRUDRepository<Entities.Product> productRepo)
        {
            _productRepo = productRepo;
        }

        public DTO.Response<DTO.Product> CreateProduct(DTO.Product product)
        {
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                product.CreatedDate = DateTime.UtcNow;
                product.UpdatedDate = DateTime.UtcNow;
                _productRepo.Add(Mapper.Map<DTO.Product, Entities.Product>(product));
                response.Success = true;
                response.Data = product;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;

        }

        public DTO.Product GetProductByID(int productID)
        {
            return Mapper.Map<Entities.Product, DTO.Product>(_productRepo.GetSingle(u => u.ID.Equals(productID)));
        }

        public IEnumerable<DTO.Product> ListProducts()
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetAll());
        }

        public IEnumerable<DTO.Product> ListProductsByCategory(int categoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p => p.Category.ID.Equals(categoryID)));
        }

        public IEnumerable<DTO.Product> ListProductsByVariantID(int variantID)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p=>p.Variant.ID.Equals(variantID)));
        }

        public DTO.Response<DTO.Product> RemoveProduct(int productID)
        {
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                Entities.Product product = _productRepo.GetSingle(u => u.ID.Equals(productID));
                _productRepo.Remove(product);
                response.Success = true;
                response.Data = Mapper.Map<Entities.Product, DTO.Product>(product);
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.GetBaseException().Message;
                response.Success = false;
            }
            return response;
        }

        public DTO.Response<DTO.Product> UpdateProduct(DTO.Product product)
        {
            product.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Product> response = new DTO.Response<DTO.Product>();
            try
            {
                _productRepo.Update(Mapper.Map<DTO.Product, Entities.Product>(product));
                response.Success = true;
                response.Data = product;
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
