using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMS.Core.DTO;

namespace OMS.Core.Interface.Services
{
    public interface IUserService<T> where T : class
    {
        IEnumerable<UserViewModel> ListAdmins();
        Response<UserViewModel> CreateUser(UserViewModel UserDTO);
    }
}
