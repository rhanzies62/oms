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
    public class ProductService : IProductService
    {
        private ICRUDRepository<Entities.Product> _productRepo;
        public ProductService()
        {
        }

        public ProductService(ICRUDRepository<Entities.Product> productRepo)
        {
            _productRepo = productRepo;
            AutoMapperCoreConfiguration.Configure();

        }
        public Response<DTO.Product> CreateProduct(DTO.Product Product)
        {
            Response<DTO.Product> response = new Response<DTO.Product>();
            try
            {
                _productRepo.Add(Mapper.Map<DTO.Product, Entities.Product>(Product));
                response.Data = Product;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public DTO.Product GetProduct(string name)
        {
            return Mapper.Map<Entities.Product, DTO.Product>(_productRepo.GetSingle(u => u.Name.Equals(name)));
        }

        public DTO.Product GetProduct(int id)
        {
            return Mapper.Map<Entities.Product, DTO.Product>(_productRepo.GetSingle(u => u.ID.Equals(id)));
        }

        public IEnumerable<DTO.Product> ListProducts()
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetAll());
        }

        public IEnumerable<DTO.Product> ListProductsByCategory(int id)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p => p.CategoryID.Equals(id)));

        }

        public IEnumerable<DTO.Product> ListProductsByVariant(int id)
        {
            return Mapper.Map<IEnumerable<Entities.Product>, IEnumerable<DTO.Product>>(_productRepo.GetList(p => p.VariantID.Equals(id)));
        }

        public Response<DTO.Product> RemoveProduct(int id)
        {
            Response<DTO.Product> response = new Response<DTO.Product>();
            try
            {
                var product = _productRepo.GetSingle(u => u.ID.Equals(id));
                _productRepo.Remove(product);
                response.Data = Mapper.Map<Entities.Product, DTO.Product>(product);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Product> UpdateProduct(DTO.Product Product)
        {

            Response<DTO.Product> response = new Response<DTO.Product>();
            try
            {
                _productRepo.Update(Mapper.Map<DTO.Product, Entities.Product>(Product));
                response.Data = Product;
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
