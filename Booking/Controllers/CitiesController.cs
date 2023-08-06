using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICitiesService _service;

        public CitiesController(ICitiesService service)
        {
            _service = service; 
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Cities city)
        {
            try
            {
                _service.Add(city);
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Cities city)
        {
           _service.update(city);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var data =   _service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
           _service.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }
    }
}
