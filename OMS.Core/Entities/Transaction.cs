using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string Address { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public Employee Employee { get; set; }
        public Customer Customer { get; set; }



        [ForeignKey("TransactionId")]
        public ICollection<Order> order { get; set; }

    }
}
