using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Collections.Generic;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsApiController : ControllerBase
    {
        // Shared static list for both API and view controllers
        public static List<CarModel> cars = new();

        [HttpGet]
        public IEnumerable<CarModel> Get() => cars;

        [HttpPost]
        public IActionResult Post([FromBody] CarModel car)
        {
            car.Id = cars.Count + 1;
            cars.Add(car);
            return Ok(car);
        }
    }
}

