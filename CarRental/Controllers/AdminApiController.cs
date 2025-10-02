using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Services;

namespace CarRental.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AdminApiController : ControllerBase
	{
		private readonly AppDbContext _context;

		public AdminApiController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("inquiries")]
		public IActionResult GetInquiries()
		{
			var inquiries = _context.Inquiries.Include(i => i.User).Include(i => i.Car).ToList();
			return Ok(inquiries);
		}
	}
}

 