namespace CarRental.Models;

public class CarModel
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int? AdminId { get; set; } // Already nullable
    public UserModel? Admin { get; set; } // Already nullable
}