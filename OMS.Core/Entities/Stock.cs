using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Stock : IAudit
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Product product { get; set; }
        [Required]
        public int GoodQuantity { get; set; }
        [Required]
        public int DamagedQuantity { get; set; }

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
