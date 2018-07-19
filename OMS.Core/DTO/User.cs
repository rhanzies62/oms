using OMS.Core.Entities;
using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class User : IAudit
    {
        [Required]
        public int ID { get; set; }
        [Required, StringLength(25)]
        public string FirstName { get; set; }
        [Required, StringLength(25)]
        public string LastName { get; set; }
        [Required]
        public int AddressID { get; set; }
        [Required]
        public int MobileNumber { get; set; }
        [Required, StringLength(25)]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public Address Address { get; set; }

        [Required]
        public int RoleID { get; set; }
        [Required]
        public Role Role { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        public Account account { get; set; }

        public IEnumerable<Order> Order { get; set; }

        public IEnumerable<Transaction> Transaction { get; set; }


    }
}
