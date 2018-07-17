﻿using OMS.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.Entities
{
    public class Role:IAudit
    {
        [Key]
        public int ID { get; set; }
        [Required,MaxLength(20)]
        public string Name { get; set; }
        [Required,MaxLength(50)]
        public string Description { get; set; }


        [ForeignKey("RoleID")]
        public ICollection<User> User { get; set; }

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
