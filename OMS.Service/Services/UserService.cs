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
    public class UserService : IUserService
    {

        private ICRUDRepository<Entities.User> _userRepo;
        public UserService()
        {
        }

        public UserService(ICRUDRepository<Entities.User> userRepo) {
            _userRepo = userRepo;
            AutoMapperCoreConfiguration.Configure();

        }
        public Response<DTO.User> CreateUser(DTO.User User)
        {
            Response<DTO.User> response = new Response<DTO.User>(); 
            try
            {
                _userRepo.Add(Mapper.Map<DTO.User, Entities.User>(User));
                response.Data = User;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public DTO.User GetActiveUser(int id)
        {
            return Mapper.Map<Entities.User, DTO.User>(_userRepo.GetSingle(u => u.ID.Equals(id) && u.Status.Equals(DTO.Status.Active)));
        }

        public DTO.User GetInactiveUser(int id)
        {
            return Mapper.Map<Entities.User, DTO.User>(_userRepo.GetSingle(u => u.ID.Equals(id) && u.Status.Equals(DTO.Status.Inactive)));
        }

        public IEnumerable<DTO.User> ListActiveUsers()
        {
            return Mapper.Map<IEnumerable<Entities.User>, IEnumerable<DTO.User>>(_userRepo.GetList(u => u.Status.Equals(DTO.Status.Active)));
        }

        public IEnumerable<DTO.User> ListUsersByRole(int id)
        {
            IEnumerable<DTO.User> response = new List<DTO.User>();
            response = Mapper.Map<IEnumerable<Entities.User>,IEnumerable<DTO.User>>(_userRepo.GetAll(u => u.Account.RoleID == id));
            return response;
        }

        public IEnumerable<DTO.User> ListInactiveUsers()
        {
            return Mapper.Map<IEnumerable<Entities.User>, IEnumerable<DTO.User>>(_userRepo.GetList(u => u.Status.Equals(DTO.Status.Inactive)));
        }

        public Response<DTO.User> RemoveUser(int id)
        {
            Response<DTO.User> response = new Response<DTO.User>();
            try
            {
                var user = _userRepo.GetSingle(u => u.ID.Equals(id));
                _userRepo.Remove(user);
                response.Data = Mapper.Map<Entities.User, DTO.User>(user);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.User> UpdateUser(DTO.User user)
        {
            Response<DTO.User> response = new Response<DTO.User>();
            try
            {
                _userRepo.Update(Mapper.Map<DTO.User, Entities.User>(user));
                response.Data = user;
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
