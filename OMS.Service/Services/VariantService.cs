using AutoMapper;
using OMS.Core.Interface.Repositories;
using OMS.Core.Interface.Services;
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
        private readonly ICRUDRepository<Entities.Variant> _variantRepo;
        public VariantService(ICRUDRepository<Entities.Variant> variantRepo)
        {
            _variantRepo = variantRepo;
        }

        public DTO.Response<DTO.Variant> CreateVariant(DTO.Variant Variant)
        {
            DTO.Response<DTO.Variant> variant = new DTO.Response<DTO.Variant>();
            try
            {
                Variant.CreatedDate = DateTime.UtcNow;
                Variant.UpdatedDate = DateTime.UtcNow;
                _variantRepo.Add(Mapper.Map<DTO.Variant, Entities.Variant>(Variant));
                variant.Success = true;
                variant.Data = Variant;
            }
            catch (Exception e)
            {
                variant.ErrorMessage = e.GetBaseException().Message;
                variant.Success = false;
            }
            return variant;

        }

        public DTO.Variant GetVariantByVariantID(int VariantID)
        {
            return Mapper.Map<Entities.Variant, DTO.Variant>(_variantRepo.GetSingle(u => u.ID.Equals(VariantID)));
        }

        public IEnumerable<DTO.Variant> ListVariants()
        {
            return Mapper.Map<IEnumerable<Entities.Variant>, IEnumerable<DTO.Variant>>(_variantRepo.GetAll());
        }

        public DTO.Response<DTO.Variant> RemoveVariant(int VariantID)
        {
            DTO.Response<DTO.Variant> variant = new DTO.Response<DTO.Variant>();
            try
            {
                Entities.Variant Variant = _variantRepo.GetSingle(u => u.ID.Equals(VariantID));
                _variantRepo.Remove(Variant);
                variant.Success = true;
                variant.Data = Mapper.Map<Entities.Variant, DTO.Variant>(Variant);
            }
            catch (Exception e)
            {
                variant.ErrorMessage = e.GetBaseException().Message;
                variant.Success = false;
            }
            return variant;
        }

        public DTO.Response<DTO.Variant> UpdateVariant(DTO.Variant Variant)
        {
            Variant.UpdatedDate = DateTime.UtcNow;
            DTO.Response<DTO.Variant> variant = new DTO.Response<DTO.Variant>();
            try
            {
                _variantRepo.Update(Mapper.Map<DTO.Variant, Entities.Variant>(Variant));
                variant.Success = true;
                variant.Data = Variant;
            }
            catch (Exception e)
            {
                variant.ErrorMessage = e.GetBaseException().Message;
                variant.Success = false;
            }
            return variant;

        }
    }
}
