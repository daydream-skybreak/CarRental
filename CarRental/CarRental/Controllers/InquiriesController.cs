using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiriesController : ControllerBase
    {
        public static List<InquiresModel> inquiries = new();
        // Demo static users list
        public static List<UserModel> users = new()
        {
            new UserModel { Id = 1, Name = "Alice", Email = "alice@example.com", IsAdmin = false },
            new UserModel { Id = 2, Name = "Bob", Email = "bob@example.com", IsAdmin = false },
            new UserModel { Id = 3, Name = "Admin", Email = "admin@example.com", IsAdmin = true }
        };

        [HttpGet]
        public IEnumerable<InquiresModel> Get() => inquiries;

        [HttpPost]
        public IActionResult Post([FromBody] InquiresModel inquiry)
        {
            inquiry.Id = inquiries.Count + 1;
            // Set the User property based on UserId
            inquiry.User = users.FirstOrDefault(u => u.Id == inquiry.UserId);
            inquiries.Add(inquiry);
            return Ok(inquiry);
        }
    }
}
