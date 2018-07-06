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

        public DTO.Response<DTO.Product> CreateProduct(DTO.Product Product)
        {
            DTO.Response<DTO.Product> product = new DTO.Response<DTO.Product>();
            try
            {
                Product.CreatedDate = DateTime.UtcNow;
                Product.UpdatedDate = DateTime.UtcNow;
                _productRepo.Add(Mapper.Map<DTO.Product, Entities.Product>(Product));
                product.Success = true;
                product.Data = Product;
            }
            catch (Exception e)
            {
                product.ErrorMessage = e.GetBaseException().Message;
                product.Success = false;
            }
            return product;

        }

        public DTO.Product GetProductByID(int ProductID)
        {
            return Mapper.Map<Entities.Product, DTO.Product>(_productRepo.GetSingle(u => u.ID.Equals(ProductID)));
        }

        public IEnumerable<DTO.Product> ListProducts()
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetAll());
        }

        public IEnumerable<DTO.Product> ListProductsByCategory(int CategoryID)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p => p.CategoryID.Equals(CategoryID)));
        }

        public IEnumerable<DTO.Product> ListProductsByVariantID(int VariantID)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p=>p.VariantID.Equals(VariantID)));
        }

        public DTO.Response<DTO.Product> RemoveProduct(int ProductID)
        {
            DTO.Response<DTO.Product> product = new DTO.Response<DTO.Product>();
            try
            {
                Entities.Product Product = _productRepo.GetSingle(u => u.ID.Equals(ProductID));
                _productRepo.Remove(Product);
                product.Success = true;
                product.Data = Mapper.Map<Entities.Product, DTO.Product>(Product);
            }
            catch (Exception e)
            {
                product.ErrorMessage = e.GetBaseException().Message;
                product.Success = false;
            }
            return product;
        }

        public DTO.Response<DTO.Product> UpdateProduct(DTO.Product Product)
        {
            Product.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Product> product = new DTO.Response<DTO.Product>();
            try
            {
                _productRepo.Update(Mapper.Map<DTO.Product, Entities.Product>(Product));
                product.Success = true;
                product.Data = Product;
            }
            catch (Exception e)
            {
                product.ErrorMessage = e.GetBaseException().Message;
                product.Success = false;
            }
            return product;
        }
    }
}
