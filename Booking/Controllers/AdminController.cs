﻿using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
