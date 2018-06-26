using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Account : IAudit
    {

        [Required, StringLength(25)]
        public string UserName { get; set; }
        [Required, StringLength(25)]
        public string PasswordHash { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public int RoleID { get; set; }

        [ForeignKey("AccountID")]
        public ICollection<User> User { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
