using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Account
    {
        [Required, StringLength(25)]
        public string UserName { get; set; }
        [Required, StringLength(25)]
        public string Password { get; set; }
        [Required]
        public AccountType Type { get; set; }
        [Required]
        public int Status { get; set; }

    }
}
