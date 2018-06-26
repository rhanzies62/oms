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
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Description { get; set; }

        [ForeignKey("VariantID")]
        public ICollection<Category> Category { get; set; }
        [ForeignKey("VariantID")]
        public ICollection<Product> Product { get; set; }

    }
}
