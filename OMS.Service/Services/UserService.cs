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
        private ICRUDRepository<Entities.User> _userRepo;
        public UserService(ICRUDRepository<Entities.User> userRepo)
        {
            _userRepo = userRepo;
        }
        public DTO.Response<DTO.User> CreateUser(DTO.User User)
        {
            DTO.Response<DTO.User> user = new DTO.Response<DTO.User>();
            try {
                _userRepo.Add(Mapper.Map<DTO.User,Entities.User>(User));
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
            
            return Mapper.Map<Entities.User,DTO.User>(_userRepo.GetSingle(u => u.ID.Equals(userID) && u.IsActive.Equals(isActive)));
        }

        public IEnumerable<DTO.User> ListUsers(bool isActive)
        {
            return Mapper.Map<IEnumerable<Entities.User>,IEnumerable<DTO.User>>(_userRepo.GetList(u => u.IsActive.Equals(isActive)));
        }

        public DTO.Response<DTO.User> RemoveUser(int userID)
        {
            DTO.Response<DTO.User> user = new DTO.Response<DTO.User>();
            try
            {
                Entities.User User = _userRepo.GetSingle(u=>u.ID.Equals(userID)); 
                _userRepo.Remove(User);
                user.Success = true;
                user.Data = Mapper.Map<Entities.User,DTO.User>(User);
            }
            catch (Exception e)
            {
                user.ErrorMessage = e.Message;
                user.Success = false;
            }
            return user;
        }

        public DTO.Response<DTO.User> UpdateUser(DTO.User User)
        {
            DTO.Response<DTO.User> user = new DTO.Response<DTO.User>();
            try
            {
                _userRepo.Update(Mapper.Map < DTO.User, Entities.User >(User));
                user.Success = true;
                user.Data = User;
            }
            catch (Exception e)
            {
                user.ErrorMessage = e.Message;
                user.Success = false;
            }
            return user;
        }
    }
}
