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
    public class AccountService : IAccountService
    {

        private ICRUDRepository<Entities.Account> _accountRepo;
        public AccountService()
        {
        }

        public AccountService(ICRUDRepository<Entities.Account> accountRepo)
        {
            _accountRepo = accountRepo;
            AutoMapperCoreConfiguration.Configure();

        }


        public Response<DTO.Account> CreateAccount(DTO.Account User)
        {
            Response<DTO.Account> response = new Response<DTO.Account>();
            try
            {
                _accountRepo.Add(Mapper.Map<DTO.Account, Entities.Account>(User));
                response.Data = User;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;

        }

        public DTO.Account GetActiveAccount(int id)
        {
            return Mapper.Map<Entities.Account, DTO.Account>(_accountRepo.GetSingle(u => u.ID.Equals(id) && u.Status.Equals(DTO.Status.Active)));

        }

        public DTO.Account GetInactiveAccount(int id)
        {
            return Mapper.Map<Entities.Account, DTO.Account>(_accountRepo.GetSingle(u => u.ID.Equals(id) && u.Status.Equals(DTO.Status.Inactive)));
        }

        public IEnumerable<DTO.Account> ListAccountsByRole(int id)
        {
            return Mapper.Map<IEnumerable<Entities.Account>, IEnumerable<DTO.Account>>(_accountRepo.GetList(u => u.RoleID.Equals(id)));
        }

        public IEnumerable<DTO.Account> ListActiveAccounts()
        {
            return Mapper.Map<IEnumerable<Entities.Account>, IEnumerable<DTO.Account>>(_accountRepo.GetList(u => u.Status.Equals(DTO.Status.Active)));

        }

        public IEnumerable<DTO.Account> ListInactiveAccounts()
        {
            return Mapper.Map<IEnumerable<Entities.Account>, IEnumerable<DTO.Account>>(_accountRepo.GetList(u => u.Status.Equals(DTO.Status.Inactive)));
        }

        public Response<DTO.Account> LoginAccount(string user, string pass)
        {
            Response<DTO.Account> response = new Response<DTO.Account>();
            try
            {
                var account = _accountRepo.GetSingle(u => (u.UserName.Equals(user) && u.PasswordHash.Equals(pass)));
                response.Data = Mapper.Map<Entities.Account, DTO.Account>(account);
                if (account != null)
                {
                    response.Success = true;
                }
                else {
                    response.Success = false;
                    response.ErrorMessage = "Wrong Username or Password";
                }
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Account> RemoveAccount(int id)
        {
            Response<DTO.Account> response = new Response<DTO.Account>();
            try
            {
                var account = _accountRepo.GetSingle(u => u.ID.Equals(id));
                _accountRepo.Remove(account);
                response.Data = Mapper.Map<Entities.Account, DTO.Account>(account);
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }
            return response;
        }

        public Response<DTO.Account> UpdateAccount(DTO.Account Account)
        {
            Response<DTO.Account> response = new Response<DTO.Account>();
            try
            {
                _accountRepo.Update(Mapper.Map<DTO.Account, Entities.Account>(Account));
                response.Data = Account;
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
