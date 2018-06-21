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
        public int orderId { get; set; }

        [Required]
        public DateTime orderDate { get; set; }
        public int orderQuan { get; set; }
        public int productRefId { get; set; }
        public int employeeRefId { get; set; }

        public Employee employee { get; set; }
        public Product product { get; set; }
    }
}
