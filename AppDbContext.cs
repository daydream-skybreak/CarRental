using Microsoft.EntityFrameworkCore;
using CarRental.Models;

namespace CarRental.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<InquiresModel> Inquiries { get; set; }
    }
}
