using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OMS.Core.Interface.Entity;

namespace OMS.Core.Entities
{
    public class Order:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public Transaction Transaction { get; set; }
        [Required]
        public Product Product { get; set; }
        [Required]
        public User User { get; set; }

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
