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
    public class Role:IAudit
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [Required,MaxLength(50)]
        public string Description { get; set; }


        [ForeignKey("RoleID")]
        public ICollection<Account> Account { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
