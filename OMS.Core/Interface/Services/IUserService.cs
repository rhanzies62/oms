using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IUserService
    {
        IEnumerable<User> ListAdmins();
        Response<User> CreateUser(User User);
    }
}
