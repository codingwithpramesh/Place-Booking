using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Booking.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesService _Service;
        public CountriesController(ICountriesService service)
        {
            _Service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<Countries> data = _Service.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Countries country)
        {
            _Service.Add(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Countries data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Countries countries)
        {

            _Service.update(countries);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Countries data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _Service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Countries data = _Service.GetById(id);
            return View(data);
        }
    }
}
