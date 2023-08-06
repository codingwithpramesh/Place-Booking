using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Booking.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            _service.Register(register);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Register Register)
        {
            throw new NotImplementedException();

        }

        //[HttpPost, ActionName("Login")]
        /* public IActionResult Login()
         {

         }*/

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
