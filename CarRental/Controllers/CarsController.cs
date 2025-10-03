using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace CarRental.Controllers
{
    public class CarsController : BaseController
    {
        private new readonly AppDbContext _context;

        public CarsController(AppDbContext context): base(context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cars = _context.Cars.Include(c => c.Admin).ToList();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarModel car, IFormFile imageFile)
        {
            Console.WriteLine($"ModelState.IsValid: {ModelState.IsValid}");
            foreach (var key in ModelState.Keys)
            {
                var errors = ModelState[key].Errors;
                foreach (var error in errors)
                {
                    Console.WriteLine($"ModelState error for '{key}': {error.ErrorMessage}");
                }
            }
            var adminId = HttpContext.Session.GetInt32("UserId");
            if (adminId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            if (ModelState.IsValid)
            {
                Console.Write("the model is valid");
                if (imageFile == null || imageFile.Length == 0)
                {
                    ModelState.AddModelError("ImageFile", "Please upload an image file.");
                    return View(car);
                }
                var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                var ext = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                {
                    ModelState.AddModelError("ImageFile", "Only image files are allowed.");
                    return View(car);
                }
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "cars");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);
                var uniqueFileName = Guid.NewGuid().ToString() + ext;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                car.ImageUrl = "/images/cars/" + uniqueFileName;
                car.AdminId = adminId.Value;
                _context.Cars.Add(car);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public IActionResult Details(int id)
        {
            var car = _context.Cars.Include(c => c.Admin).FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();
            return View(car);
        }
    }
}
