using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<InquiresModel> Inquiries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>().HasData(
                new UserModel { Id = 1, Name = "Alice Johnson", Email = "alice@example.com", Password = "Password123!", IsAdmin = true },
                new UserModel { Id = 2, Name = "Bob Smith", Email = "bob@example.com", Password = "Password123!", IsAdmin = false },
                new UserModel { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com", Password = "Password123!", IsAdmin = false }
            );

            modelBuilder.Entity<CarModel>().HasData(
                new CarModel { Id = 1, Make = "Toyota", Model = "Camry", Year = 2021, Price = 50.0m, ImageUrl = "https://example.com/toyota_camry.jpg", AdminId = 1 },
                new CarModel { Id = 2, Make = "Honda", Model = "Civic", Year = 2020, Price = 45.0m, ImageUrl = "https://example.com/honda_civic.jpg", AdminId = 1 },
                new CarModel { Id = 3, Make = "Ford", Model = "Mustang", Year = 2019, Price = 70.0m, ImageUrl = "https://example.com/ford_mustang.jpg", AdminId = 1 }
            );

            modelBuilder.Entity<InquiresModel>().HasData(
                new InquiresModel { Id = 1, CarId = 1, UserId = 2, Message = "Is this car available next weekend?" },
                new InquiresModel { Id = 2, CarId = 2, UserId = 3, Message = "Can I rent this car for a week?" },
                new InquiresModel { Id = 3, CarId = 3, UserId = 2, Message = "What is the mileage of this car?" }
            );
        }
    }
}
