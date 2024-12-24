using Domain.Contracts.Sevices;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Shop.UI.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        private readonly IUserService _userService = userService;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var result = _userService.Login(username, password);
            if (result)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["ErrorMessage"] = "نام کاربری یا پسورد اشتباه است. دوباره وارد شوید.";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult Register(string username, string password, string email, string mobile)
        {
            var result = _userService.Register(username, password, email, mobile);
            if(!result.IsSuccess)
            {
                TempData["ErrorMessage"] = result.Message;
                return Redirect("SignUp");
            }
            else
            {
                TempData["SuccessMessage"] = result.Message;
                return View ("Index");
            }
        }

    }
}
