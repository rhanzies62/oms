using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.Entities
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }
        public Product Product { get; set; }
        public Employee Employee { get; set; }

    }
}
