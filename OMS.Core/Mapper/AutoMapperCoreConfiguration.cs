using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Common
{
    public static class AutoMapperCoreConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                //add your mapping profile here
            });
        }
    }
}
