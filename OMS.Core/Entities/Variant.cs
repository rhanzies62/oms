using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Variant
    {
        [Key]
        public int variantId { get; set; }

        [Required,MaxLength(25)]
        public int variantName { get; set; }
        public int variantDesc { get; set; }

        [ForeignKey("variantRefId")]
        public ICollection<Category> category { get; set; }
        public ICollection<Product> product { get; set; }

    }
}
