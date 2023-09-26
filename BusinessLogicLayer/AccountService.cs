using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Http;
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

        public Register login(Register register)
        {
           Register data = _context.Register.Where(x =>x.Id == register.Id).FirstOrDefault();
           return register;
        }

        public async  Task<Register> loginAsync(Register register)
        {
            Register data = _context.Register.FirstOrDefault(x => x.Email == register.Email && x.password == register.password);

            List<Claim> claims = new List<Claim>()
              {
                  new Claim(ClaimTypes.NameIdentifier, register.Name),


              };

            ClaimsIdentity identity = new ClaimsIdentity(new[]
            {
              new Claim(ClaimTypes.Email, register.Email),
              new Claim(ClaimTypes.Role, register.Roles.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            return data;




            
        }

        public void Register(Register register)
        {
           _context.Register.Add(register);
            _context.SaveChanges();
           
        }
    }
}
