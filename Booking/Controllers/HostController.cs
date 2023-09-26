using Booking.Models;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Booking.Controllers
{
    public class HostController : Controller
    {
        private readonly IHostService _Service;
        public HostController(HostService service)
        {
            _Service = service;
        }

        public IActionResult Index()
        {
            IEnumerable<Hosts> data = _Service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
         
           return View();
        }

        [HttpPost]
        public IActionResult Create(Hosts hosts)
        {
            try
            {
                _Service.Add(hosts);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Hosts data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Hosts hosts)
        {
            _Service.update(hosts);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Hosts data = _Service.GetById(id);
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
            Hosts data = _Service.GetById(id);
            return View(data);
        }
    }
}
