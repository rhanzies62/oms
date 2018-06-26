﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class Employee : Account
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
        public Gender Gender { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }

        [ForeignKey("EmployeeID")]
        public ICollection<Order> Order { get; set; }
    }
}
