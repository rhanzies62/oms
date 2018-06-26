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
    public class Category:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(30)]
        public string Description { get; set; }

        public int? VariantID { get; set; }
        public int? ParentCategoryId { get; set; }

        public Variant Variant { get; set; }

        [ForeignKey("ParentCategoryId")]
        public ICollection<Category> SubCategory { get; set; }

        [ForeignKey("CategoryID")]
        public ICollection<Product> Product { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
