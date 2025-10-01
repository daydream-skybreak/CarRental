namespace CarRental.Models;

public class UserModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public bool IsAdmin { get; set; }
    public List<CarModel> UploadedCars { get; set; } = new();
    public List<InquiresModel> Inquiries { get; set; } = new();
}