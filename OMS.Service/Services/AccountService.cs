using OMS.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;
using Entities = OMS.Core.Entities;
using OMS.Core.Interface.Repositories;
using DTO = OMS.Core.DTO;
using AutoMapper;
using OMS.Core.Common;

namespace OMS.Service.Services
{
    public class AccountService : IAccountService
    {
        private ICRUDRepository<Entities.Account> _accountRepo;
        public AccountService(ICRUDRepository<Entities.Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
        public Response<Account> CreateAccount(Account Account)
        {
            DTO.Response<DTO.Account> account = new DTO.Response<DTO.Account>();
            try
            {
                Account.PasswordHash = Cryptography.HashPassword(Account.PasswordHash);
                Account.Salt = Cryptography.CreateSalt();
                _accountRepo.Add(Mapper.Map<DTO.Account, Entities.Account>(Account));
                account.Success = true;
                account.Data = Account;
            }
            catch (Exception e)
            {
                account.ErrorMessage = e.Message;
                account.Success = false;
            }
            return account;
        }

        public Account GetAccount(int AccountID)
        {
            return Mapper.Map<Entities.Account, DTO.Account>(_accountRepo.GetSingle(u => u.ID.Equals(AccountID)));
        }

        public IEnumerable<Account> ListAccounts()
        {
            return Mapper.Map<IEnumerable<Entities.Account>, IEnumerable<DTO.Account>>(_accountRepo.GetAll());
        }

        public Response<Account> RemoveAccount(int AccountID)
        {
            DTO.Response<DTO.Account> account = new DTO.Response<DTO.Account>();
            try
            {
                Entities.Account Account = _accountRepo.GetSingle(u => u.ID.Equals(AccountID));
                _accountRepo.Remove(Account);
                account.Success = true;
                account.Data = Mapper.Map<Entities.Account, DTO.Account>(Account);
            }
            catch (Exception e)
            {
                account.ErrorMessage = e.Message;
                account.Success = false;
            }
            return account;

        }

        public Response<Account> UpdateAccount(Account Account)
        {
            DTO.Response<DTO.Account> account = new DTO.Response<DTO.Account>();
            try
            {
                _accountRepo.Update(Mapper.Map<DTO.Account, Entities.Account>(Account));
                account.Success = true;
                account.Data = Account;
            }
            catch (Exception e)
            {
                account.ErrorMessage = e.Message;
                account.Success = false;
            }
            return account;

        }
    }
}
