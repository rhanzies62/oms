using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMS.Core.Entities
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }

        [Required,MaxLength(25)]
        public string empFname { get; set; }
        public string empLname { get; set; }
        public string empAddress { get; set; }
        public DateTime empBirthdate { get; set; }
        public Gender empGender { get; set; }

        [ForeignKey("employeeRefId")]
        public Order order { get; set; }
    }
}
