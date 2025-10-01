using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InquiriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<InquiresModel> Get()
        {
            return _context.Inquiries.Include(i => i.User).Include(i => i.Car).ToList();
        }

        [HttpPost]
        public IActionResult Post([FromBody] InquiresModel inquiry)
        {
            // Ensure the user and car exist
            var user = _context.Users.Find(inquiry.UserId);
            var car = _context.Cars.Find(inquiry.CarId);
            if (user == null || car == null)
            {
                return BadRequest("User or Car not found.");
            }
            inquiry.User = user;
            inquiry.Car = car;
            _context.Inquiries.Add(inquiry);
            _context.SaveChanges();
            return Ok(inquiry);
        }
    }
}
