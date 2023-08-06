using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq.Expressions;

namespace Booking.Controllers
{
    public class PlacesController : Controller
    {
        private readonly IPlacesService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PlacesController( IPlacesService service, IWebHostEnvironment webHostEnvironment)
        {
             _service = service;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            var Data = _service.GetAll();
            return View(Data);
           
        }

        public IActionResult PlacesView()
        {
            var Data = _service.GetAll();
            return View(Data);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public  IActionResult Created(Places place, IFormFile? file)
        {
              _service.Add(place);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Places place, IFormFile file)
        {
          
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            /*var data = _context.Places.Where(x => x.Id == id).FirstOrDefault();
            return View(data);*/

            /*var file = _context.Places.FirstOrDefault(x =>x.Id == id);
            if (file != null) return null;
            if (System.IO.File.Exists(file.Image)) ;
            return View(file);*/

          _service.Delete(id);
          return RedirectToAction("Index");
        }

        /* [HttpPost, ActionName("Delete")]
         public IActionResult Deleted(int id)
         {
             var data = _context.Places.FirstOrDefault(x => x.Id == id);
             _context.Places.Remove(data);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
    */

        public IActionResult Details(int id)
        {
            var Data = _service.GetById(id);
            return View(Data);
        }
    }
}
