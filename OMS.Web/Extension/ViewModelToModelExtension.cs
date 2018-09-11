using OMS.Core.DTO;
using OMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMS.Web.Extension
{
    public static class ViewModelToModelExtension
    {
        public static Account MapToAccount(this UserCredentialViewModel model)
        {
            return new Account
            {
                UserName = model.Username,
                PasswordHash = model.Password
            };
        }
    }
}