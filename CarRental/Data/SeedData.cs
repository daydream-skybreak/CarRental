using CarRental.Models;
using CarRental.Services;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (!context.Users.Any())
        {
            var users = new List<UserModel>
            {
                new UserModel { Name = "Alice Johnson", Email = "alice@example.com", Password = "Password123!", IsAdmin = true },
                new UserModel { Name = "Bob Smith", Email = "bob@example.com", Password = "Password123!", IsAdmin = false },
                new UserModel { Name = "Charlie Brown", Email = "charlie@example.com", Password = "Password123!", IsAdmin = false }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        if (!context.Cars.Any())
        {
            var cars = new List<CarModel>
            {
                new CarModel
                {
                    Make = "Toyota",
                    Model = "Camry",
                    Year = 2021,
                    Price = 50.0m,
                    ImageUrl = "https://example.com/toyota_camry.jpg",
                    AdminId = context.Users.First(u => u.IsAdmin).Id
                },
                new CarModel
                {
                    Make = "Honda",
                    Model = "Civic",
                    Year = 2020,
                    Price = 45.0m,
                    ImageUrl = "https://example.com/honda_civic.jpg",
                    AdminId = context.Users.First(u => u.IsAdmin).Id
                },
                new CarModel
                {
                    Make = "Ford",
                    Model = "Mustang",
                    Year = 2019,
                    Price = 70.0m,
                    ImageUrl = "https://example.com/ford_mustang.jpg",
                    AdminId = context.Users.First(u => u.IsAdmin).Id
                }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }

        if (!context.Inquiries.Any())
        {
            var inquiries = new List<InquiresModel>
            {
                new InquiresModel
                {
                    CarId = context.Cars.First().Id,
                    UserId = context.Users.First(u => !u.IsAdmin).Id,
                    Message = "Is this car available next weekend?"
                },
                new InquiresModel
                {
                    CarId = context.Cars.Skip(1).First().Id,
                    UserId = context.Users.Skip(1).First(u => !u.IsAdmin).Id,
                    Message = "Can I rent this car for a week?"
                },
                new InquiresModel
                {
                    CarId = context.Cars.Last().Id,
                    UserId = context.Users.First(u => !u.IsAdmin).Id,
                    Message = "What is the mileage of this car?"
                }
            };

            context.Inquiries.AddRange(inquiries);
            context.SaveChanges();
        }
    }
}
