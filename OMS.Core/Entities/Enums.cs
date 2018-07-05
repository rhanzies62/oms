﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public enum Gender
    {
        [Description("Male")]
        Male,
        [Description("Female")]
        Female,
    }
    public enum Status
    {
        [Description("Active")]
        Active,
        [Description("Inactive")]
        Inactive,
    }
}
