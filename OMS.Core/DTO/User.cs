using OMS.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace OMS.Core.DTO
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required, StringLength(25)]
        public string FirstName { get; set; }

        [Required, StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public int MobileNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

    }
}
