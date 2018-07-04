using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class Address : IAudit
    {
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string AddressLineOne { get; set; }
        [StringLength(25)]
        public string AddressLineTwo { get; set; }
        [Required, StringLength(25)]
        public string City { get; set; }
        [StringLength(10)]
        public string PostalCode { get; set; }

        public IEnumerable<User> User { get; set; }
        public IEnumerable<Transaction> Transaction { get; set; }


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
