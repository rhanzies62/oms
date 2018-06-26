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
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }

        public int? VariantID { get; set; }

        public Variant Variant { get; set; }

        [ForeignKey("CategoryID")]
        public ICollection<Product> Product { get; set; }
    }
}
