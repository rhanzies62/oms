using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Product
    {   
        [Key]
        public int productId { get; set; }

        [Required,MaxLength(25)]
        public string productName { get; set; }
        public decimal productPrice { get; set; }
        public string productSize { get; set; }

        public int categoryRefId { get; set; }
        public Category category { get; set; }

        public int variantRefId { get; set; }
        public Variant variant { get; set; }


        [ForeignKey("productRefId")]
        public Order order { get; set; }
    }
}
