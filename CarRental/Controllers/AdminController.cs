using Microsoft.EntityFrameworkCore;
using CarRental.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarRental.Controllers
{
    public class AdminController : BaseController
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inquiries()
        {
            var inquiries = _context.Inquiries.Include(i => i.User).Include(i => i.Car).ToList();
            return View(inquiries);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = userId.HasValue ? _context.Users.FirstOrDefault(u => u.Id == userId.Value) : null;
            if (user == null || !user.IsAdmin)
            {
                context.Result = RedirectToAction("Login", "Account");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}