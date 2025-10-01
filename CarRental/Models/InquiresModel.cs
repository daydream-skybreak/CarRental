using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models
{
    public class InquiresModel
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public CarModel Car { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}
