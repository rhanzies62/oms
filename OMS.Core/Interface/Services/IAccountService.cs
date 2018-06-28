using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IAccountService
    {
        IEnumerable<Account> ListActiveAccounts();
        IEnumerable<Account> ListInactiveAccounts();

        IEnumerable<Account> ListAccountsByRole(int id);

        Response<Account> CreateAccount(Account User);

        Response<Account> UpdateAccount(Account User);

        Response<Account> RemoveAccount(int id);

        Account GetActiveAccount(int id);
        Account GetInactiveAccount(int id);

    }
}
