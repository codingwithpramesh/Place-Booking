using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingPlaceService _service;
        public BookingController(IBookingPlaceService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<Booked> Data = _service.GetAll();
            return View(Data);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult Created(Booked booked)
        {

            _service.Add(booked);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Booked data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Booked booked)
        {
            _service.update(booked);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Booked data = _service.GetById(id);
            return View(data);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Booked data = _service.GetById(id);
            return View(data);
        }
    }
}
