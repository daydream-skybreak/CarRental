using Microsoft.AspNetCore.Mvc;

namespace CarRental.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "CarRental API" });
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return Ok(new { message = "Redirected to Cars in MVC; API has no privacy page." });
        }
    }
}


