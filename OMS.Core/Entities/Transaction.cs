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
    public class Transaction:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int AddressID { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public int UserID { get; set; }
        public User User { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        [ForeignKey("TransactionId")]
        public ICollection<Order> order { get; set; }

    }
}
