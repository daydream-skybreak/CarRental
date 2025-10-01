using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CarRental.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public int Year { get; set; }
        public string ImageUrl { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public UserModel Admin { get; set; }
        public ICollection<InquiresModel> Inquiries { get; set; }
    }
}
