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
using Entities = OMS.Core.Entities;
using DTO = OMS.Core.DTO;

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

        

        public IEnumerable<DTO.User> ListAdmins()
        {
            IEnumerable<DTO.User> response = new List<DTO.User>();
            response = Mapper.Map<IEnumerable<Entities.User>,IEnumerable<DTO.User>>(_userRepo.GetAll(u => u.Account.RoleID == 1));
            return response;
        }
    }
}
