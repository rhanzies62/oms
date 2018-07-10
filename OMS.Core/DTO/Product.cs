using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Product : IAudit
    {
        [Required]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(25)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int CategoryID { get; set; }
        //public Category Category { get; set; }

        public int VariantID { get; set; }

        //public Variant Variant { get; set; }

        //public IEnumerable<Order> order { get; set; }

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
