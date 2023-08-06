using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService( ApplicationDbContext context) 
        {
            _context = context;
        }

        public  Register login(Register register)
        {
           /* var data = _context.Register.FirstOrDefault(x => x.Email == Register.Email && x.password == Register.password);

            *//*  var claims = new List<Claim>()
              {
                  new Claim(ClaimTypes.NameIdentifier, Register.Name),


              };*//*

            var identity = new ClaimsIdentity(new[]
            {
              new Claim(ClaimTypes.Email, Register.Email),
              new Claim(ClaimTypes.Role, Register.Roles.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

            // HttpContext.Session.SetString("Email", Register.Email);

            if (data.Roles == Data.Enum.Roles.Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if (data.Roles == Data.Enum.Roles.User)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            
*/

            throw new NotImplementedException();
        }

        public void Register(Register register)
        {
           _context.Register.Add(register);
            _context.SaveChanges();
           
        }
    }
}
