using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace CarRental.Controllers
{
    public class AccountController : BaseController
    {
        // Use the static users list from InquiriesController for demo
        private static System.Collections.Generic.List<UserModel> users = InquiriesController.users;

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
                users.Add(model);
                // Auto-login after registration
                HttpContext.Session.SetInt32("UserId", model.Id);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email)
        {
            var user = users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid email.");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home");
        }
    }
}
