using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CarRental.Controllers
{
    public class InquiriesController : BaseController
    {
        private readonly AppDbContext _context;

        public InquiriesController(AppDbContext context):  base(context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inquiries = _context.Inquiries.Include(i => i.User).Include(i => i.Car).ToList();
            return View(inquiries);
        }

        public IActionResult Details(int id)
        {
            var inquiry = _context.Inquiries.Include(i => i.User).Include(i => i.Car).FirstOrDefault(i => i.Id == id);
            if (inquiry == null)
                return NotFound();
            return View(inquiry);
        }

        [HttpGet]
        public IActionResult Create(int carId)
        {
            ViewBag.CarId = carId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int CarId, string Message)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                TempData["InquiryError"] = "You must be logged in to send an inquiry.";
                return RedirectToAction("Details", "Cars", new { id = CarId });
            }
            var inquiry = new InquiresModel
            {
                CarId = CarId,
                UserId = userId.Value,
                Message = Message
            };
            _context.Inquiries.Add(inquiry);
            _context.SaveChanges();
            TempData["InquirySuccess"] = "Your inquiry has been sent!";
            return RedirectToAction("Details", "Cars", new { id = CarId });
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                