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

        Response<Account> CreateAccount(Account account);

        Response<Account> UpdateAccount(Account account);

        Response<Account> RemoveAccount(int accountID);

        Account GetAccountByID(int accountID);

        Response<Account> ChangeAccountPassword(Account account,string newPassword);

        Response<Account> LoginAccount(Account account);
    }
}
