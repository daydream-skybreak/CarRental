using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarRental.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inquiries()
        {
            // Use the static inquiries list from InquiriesController
            var inquiries = InquiriesController.inquiries;
            return View(inquiries);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            var user = userId.HasValue ? InquiriesController.users.FirstOrDefault(u => u.Id == userId.Value) : null;
            if (user == null || !user.IsAdmin)
            {
                context.Result = RedirectToAction("Login", "Account");
                return;
            }
            base.OnActionExecuting(context);
        }
    }
}