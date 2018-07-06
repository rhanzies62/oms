using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Mapper
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
           AutoMapper.Mapper.Initialize(cfg => {
               cfg.AddProfile<UserProfile>();
               cfg.AddProfile<RoleProfile>();
<<<<<<< HEAD
               cfg.AddProfile<ProductProfile>();
=======
               cfg.AddProfile<VariantProfile>();
>>>>>>> 0a7fef85fd3a3ef3757dec4506263b32e51a4bd0
           });
        }
    }
}
