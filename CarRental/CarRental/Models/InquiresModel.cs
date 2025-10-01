namespace CarRental.Models;

public class InquiresModel
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public required string Message { get; set; }
    public int UserId { get; set; } // User who made the inquiry
    public UserModel User { get; set; }
}