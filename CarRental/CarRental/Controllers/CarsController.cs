using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Collections.Generic;

namespace CarRental.Controllers
{
    public class CarsController : BaseController
    {
        private static List<CarModel> cars = CarsApiController.cars;

        // View: List all cars
        public IActionResult Index()
        {
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
                car.Id = cars.Count + 1;
                cars.Add(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }
    }
}
