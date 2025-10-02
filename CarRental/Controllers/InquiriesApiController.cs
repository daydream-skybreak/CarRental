using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using CarRental.Services;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiriesApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InquiriesApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var inquiries = _context.Inquiries.Include(i => i.User).Include(i => i.Car).ToList();
            return Ok(inquiries);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inquiry = _context.Inquiries.Include(i => i.User).Include(i => i.Car).FirstOrDefault(i => i.Id == id);
            if (inquiry == null)
            {
                return NotFound();
            }
            return Ok(inquiry);
        }

        public class CreateInquiryRequest
        {
            public int CarId { get; set; }
            public string Message { get; set; } = string.Empty;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateInquiryRequest request)
        {
            var inquiry = new InquiresModel
            {
                CarId = request.CarId,
                Message = request.Message,
            };
            _context.Inquiries.Add(inquiry);
            _context.SaveChanges();
            return Ok(inquiry);
        }
    }
}


