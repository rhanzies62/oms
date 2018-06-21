using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Transaction
    {
        [Key]
        public int transId { get; set; }

        [Required]
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public int orderId { get; set; }
        public int employeeId { get; set; }
        public decimal totalPrice { get; set; }
        
        public Order order { get; set; }
        public Employee employee { get; set; }

    }
}
