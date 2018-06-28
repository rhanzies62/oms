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

namespace OMS.Service.Services
{
    public class UserService : IUserService<UserViewModel>
    {

        private ICRUDRepository<User> _userRepo;
        public UserService()
        {
        }

        public UserService(ICRUDRepository<User> userRepo) {
            _userRepo = userRepo;
            AutoMapperCoreConfiguration.Configure();

        }
        public Response<UserViewModel> CreateUser(UserViewModel UserDTO)
        {
            Response<UserViewModel> response = new Response<UserViewModel>(); 
            try
            {
                _userRepo.Add(Mapper.Map<UserViewModel,User>(UserDTO));
                response.Data = UserDTO;

            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        

        public IEnumerable<UserViewModel> ListAdmins()
        {
            IEnumerable<UserViewModel> response = new List<UserViewModel>();
            response = Mapper.Map<IEnumerable<User>,IEnumerable<UserViewModel>>(_userRepo.GetAll(u => u.Account.RoleID == 1));
            return response;
        }
    }
}
