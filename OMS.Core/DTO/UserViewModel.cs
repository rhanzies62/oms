using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core.DTO
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressID { get; set; }
        public int MobileNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public AddressViewModel Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public int AccountID { get; set; }
        public AccountViewModel Account { get; set; }

        public ICollection<OrderViewModel> Order { get; set; }
        public ICollection<TransactionViewModel> Transaction { get; set; }

    }
}
