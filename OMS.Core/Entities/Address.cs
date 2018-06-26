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
    public class Address :IAudit
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(25)]
        public string AddressLineOne { get; set; }
        [StringLength(25)]
        public string AddressLineTwo { get; set; }
        [Required, StringLength(25)]
        public string City { get; set; }
        [StringLength(25)]
        public string PostalCode { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("AddressID")]
        public ICollection<Order> Order { get; set; }
    }
}
