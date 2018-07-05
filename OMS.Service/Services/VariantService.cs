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
    public class VariantService : IVariantService
    {
        private ICRUDRepository<Entities.Variant> _variantRepo;
        public VariantService()
        {
        }

        public VariantService(ICRUDRepository<Entities.Variant> variantRepo)
        {
            _variantRepo = variantRepo;
            AutoMapperCoreConfiguration.Configure();

        }
        public Response<DTO.Variant> CreateVariants(DTO.Variant Variant)
        {
            Response<DTO.Variant> response = new Response<DTO.Variant>();
            try
            {
                _variantRepo.Add(Mapper.Map<DTO.Variant, Entities.Variant>(Variant));
                response.Data = Variant;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public DTO.Variant GetVariant(int id)
        {
            return Mapper.Map<Entities.Variant, DTO.Variant>(_variantRepo.GetSingle(u => u.ID.Equals(id)));
        }

        public IEnumerable<DTO.Variant> ListVariants()
        {
            return Mapper.Map<IEnumerable<Entities.Variant>, IEnumerable<DTO.Variant>>(_variantRepo.GetAll());

        }

        public Response<DTO.Variant> RemoveVariants(int id)
        {
            Response<DTO.Variant> response = new Response<DTO.Variant>();
            try
            {
                var Variant = _variantRepo.GetSingle(u => u.ID.Equals(id));
                _variantRepo.Remove(Variant);
                response.Data = Mapper.Map<Entities.Variant, DTO.Variant>(Variant);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Variant> UpdateVariants(DTO.Variant Variant)
        {
            Response<DTO.Variant> response = new Response<DTO.Variant>();
            try
            {
                _variantRepo.Update(Mapper.Map<DTO.Variant, Entities.Variant>(Variant));
                response.Data = Variant;
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
