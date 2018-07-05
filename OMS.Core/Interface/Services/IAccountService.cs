using OMS.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Interface.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> ListAccounts();

        Response<Account> CreateAccount(Account Account);

        Response<Account> UpdateAccount(Account Account);

        Response<Account> RemoveAccount(int AccountID);

        Account GetAccount(int AccountID);

        Response<Account> ChangeAccountPassword(int AccountID,string AccountPassword,string AccountNewPassword);
    }
}
