using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Category
    {
        [Key]
        public int categoryId { get; set; }

        [Required, MaxLength(25)]
        public int variantRefId { get; set; }
        public Variant variant { get; set; }
        public string categoryName { get; set; }
        public string categoryDesc { get; set; }

        [ForeignKey("categoryRefId")]
        public ICollection<Product> product { get; set; }
    }
}
