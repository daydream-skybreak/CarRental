using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CarRental.Services;
using System.Linq;

namespace CarRental.Controllers
{
    public class BaseController : Controller
    {
        protected AppDbContext _context;

        public BaseController(AppDbContext context = null)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue && _context != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId.Value);
                if (user != null)
                {
                    ViewBag.UserName = user.Name;
                    ViewBag.UserInitials = string.Join("", user.Name.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).Select(s => s[0])).ToUpper();
                    ViewBag.IsAdmin = user.IsAdmin;
                }
                else
                {
                    ViewBag.UserName = null;
                    ViewBag.UserInitials = null;
                    ViewBag.IsAdmin = false;
                }
            }
            else
            {
                ViewBag.UserName = null;
                ViewBag.UserInitials = null;
                ViewBag.IsAdmin = false;
            }
            base.OnActionExecuting(context);
        }
    }
}
