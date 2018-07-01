using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using DTO = OMS.Core.DTO;
namespace OMS.Service.Services
{
    public class UserService : IUserService
    {
        private ICRUDRepository<DTO.User> _userRepo;
        public UserService(ICRUDRepository<DTO.User> userRepo)
        {
            _userRepo = userRepo;
        }
        public DTO.Response<DTO.User> CreateUser(DTO.User User)
        {
            DTO.Response<DTO.User> user = new DTO.Response<DTO.User>();
            try {
                _userRepo.Add(User);
                user.Success = true;
                user.Data = User;
            }
            catch (Exception e) {
                user.ErrorMessage = e.Message;
                user.Success = false;
            }
            return user;
        }

        public DTO.User GetUser(int userID, bool isActive)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO.User> ListUsers(bool isActive)
        {
            throw new NotImplementedException();
        }

        public DTO.Response<DTO.User> RemoveUser(int userID)
        {
            throw new NotImplementedException();
        }

        public DTO.Response<DTO.User> UpdateUser(DTO.User User)
        {
            throw new NotImplementedException();
        }
    }
}
