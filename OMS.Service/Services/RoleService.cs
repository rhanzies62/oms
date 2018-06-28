using AutoMapper;
using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;
using OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using Entities = OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using OMS.Core.Mapper;

namespace OMS.Service.Services
{
    public class RoleService : IRoleService
    {
        private ICRUDRepository<Entities.Role> _userRepo;
        public RoleService()
        {
        }

        public RoleService(ICRUDRepository<Entities.Role> userRepo)
        {
            _userRepo = userRepo;
            AutoMapperCoreConfiguration.Configure();

        }

        public Response<DTO.Role> CreateRole(DTO.Role Role)
        {
            Response<DTO.Role> response = new Response<DTO.Role>();
            try
            {
                _userRepo.Add(Mapper.Map<DTO.Role, Entities.Role>(Role));
                response.Data = Role;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public DTO.Role GetRole(int id)
        {
            return Mapper.Map<Entities.Role, DTO.Role>(_userRepo.GetSingle(r => r.ID.Equals(id)));
        }

        public IEnumerable<DTO.Role> ListRoles()
        {
            return Mapper.Map<IEnumerable<Entities.Role>, IEnumerable<DTO.Role>>(_userRepo.GetAll());
        }

        public Response<DTO.Role> RemoveRole(int id)
        {
            Response<DTO.Role> response = new Response<DTO.Role>();
            try
            {
                var role = _userRepo.GetSingle(u => u.ID.Equals(id));
                _userRepo.Remove(role);
                response.Data = Mapper.Map<Entities.Role, DTO.Role>(role);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Role> UpdateRole(DTO.Role Role)
        {
            Response<DTO.Role> response = new Response<DTO.Role>();
            try
            {
                _userRepo.Update(Mapper.Map<DTO.Role, Entities.Role>(Role));
                response.Data = Role;
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
