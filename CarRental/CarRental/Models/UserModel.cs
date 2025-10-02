using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CarRental.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<CarModel>? Cars { get; set; }
        public ICollection<InquiresModel>? Inquiries { get; set; }
    }
}