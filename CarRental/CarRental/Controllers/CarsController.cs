using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CarRental.Controllers
{
    public class CarsController : BaseController
    {
        private readonly AppDbContext _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        // View: List all cars
        public IActionResult Index()
        {
            var cars = _context.Cars.Include(c => c.Admin).ToList();
            return View(cars);
        }

        // View: Show form to create a new car
        public IActionResult Create()
        {
            return View();
        }

        // View: Handle form submission to create a new car
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarModel car)
        {
            if (ModelState.IsValid)
            {
                // Get current user (admin) from session
                var adminId = HttpContext.Session.GetInt32("UserId");
                if (adminId == null)
                {
                    return RedirectToAction("Login", "Account");
                }
                car.AdminId = adminId.Value;
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }
    }
}
