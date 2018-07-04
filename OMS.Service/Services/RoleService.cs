using OMS.Core.Interface;
using OMS.Core.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;
using AutoMapper;

namespace OMS.Service.Services
{
    public class RoleService : IRoleService
    {
        private ICRUDRepository<Entities.Role> _roleRepo;
        public RoleService(ICRUDRepository<Entities.Role> roleRepo)
        {
            _roleRepo = roleRepo;
        }

        public DTO.Response<DTO.Role> CreateRole(DTO.Role Role)
        {
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                _roleRepo.Add(Mapper.Map<DTO.Role, Entities.Role>(Role));
                role.Success = true;
                role.Data = Role;
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.Message;
                role.Success = false;
            }
            return role;

        }

        public DTO.Role GetRole(int roleID)
        {
            return Mapper.Map<Entities.Role, DTO.Role>(_roleRepo.GetSingle(u => u.ID.Equals(roleID)));
        }

        public IEnumerable<DTO.Role> ListRoles()
        {
            return Mapper.Map<IEnumerable<Entities.Role>, IEnumerable<DTO.Role>>(_roleRepo.GetAll());
        }

        public DTO.Response<DTO.Role> RemoveRole(int roleID)
        {
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                Entities.Role Role = _roleRepo.GetSingle(u => u.ID.Equals(roleID));
                _roleRepo.Remove(Role);
                role.Success = true;
                role.Data = Mapper.Map<Entities.Role, DTO.Role>(Role);
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.Message;
                role.Success = false;
            }
            return role;

        }

        public DTO.Response<DTO.Role> UpdateRole(DTO.Role Role)
        {
            DTO.Response<DTO.Role> role = new DTO.Response<DTO.Role>();
            try
            {
                _roleRepo.Update(Mapper.Map<DTO.Role, Entities.Role>(Role));
                role.Success = true;
                role.Data = Role;
            }
            catch (Exception e)
            {
                role.ErrorMessage = e.Message;
                role.Success = false;
            }
            return role;

        }
    }
}
