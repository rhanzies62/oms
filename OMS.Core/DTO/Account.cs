using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Account : IAudit
    {
        [Required]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string UserName { get; set; }
        [Required, StringLength(25)]
        public string PasswordHash { get; set; }
        //public Role Role { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public int RoleID { get; set; }

        public IEnumerable<User> User { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }


    }
}
