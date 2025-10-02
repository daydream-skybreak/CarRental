using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCarsAndInquiriesToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "alice@example.com", true, "Alice Johnson", "Password123!" },
                    { 2, "bob@example.com", false, "Bob Smith", "Password123!" },
                    { 3, "charlie@example.com", false, "Charlie Brown", "Password123!" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AdminId", "ImageUrl", "Make", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 1, 1, "https://example.com/toyota_camry.jpg", "Toyota", "Camry", 50.0m, 2021 },
                    { 2, 1, "https://example.com/honda_civic.jpg", "Honda", "Civic", 45.0m, 2020 },
                    { 3, 1, "https://example.com/ford_mustang.jpg", "Ford", "Mustang", 70.0m, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Inquiries",
                columns: new[] { "Id", "CarId", "Message", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Is this car available next weekend?", 2 },
                    { 2, 2, "Can I rent this car for a week?", 3 },
                    { 3, 3, "What is the mileage of this car?", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inquiries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inquiries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inquiries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
