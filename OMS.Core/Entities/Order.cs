﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OMS.Core.Interface.Entity;

namespace OMS.Core.Entities
{
    public class Order:IAudit
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int ProductID { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public int TransactionId { get; set; }

        public Transaction Transaction { get; set; }
        public Product Product { get; set; }
        public User User { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
