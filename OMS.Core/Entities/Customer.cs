using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]
        public string LastName { get; set; }
        [Required, StringLength(50)]
        public string Address { get; set; }
        [Required]
        public int MobileNumber { get; set; }

        public int Tin { get; set; }
        public string BusinessName { get; set; }
    }
}
