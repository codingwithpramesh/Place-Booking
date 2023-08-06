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
     /*   private readonly IWebHostEnvironment _environment;*/
        public BookingController(IBookingPlaceService service ) 
        { 
            _service = service;
       /*     _environment = environment;*/
        }

        public IActionResult Index()
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
        public IActionResult Created(Booked booked)
        {
            /* try
             {
                 if (ModelState.IsValid)
                 {
                    *//* string wwwRootPath = _environment.WebRootPath;
                     string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                     string extension = Path.GetExtension(file.FileName);
                     booked.Image = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                     string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                     using (var fileStream = new FileStream(path, FileMode.Create))
                     {
                         await file.CopyToAsync(fileStream);
                     }
                     //Insert record
                     _context.Add(booked);
                     await _context.SaveChangesAsync();
                     return RedirectToAction(nameof(Index));*//*
                 }
             }catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
             }
             return View();*/

            _service.Add(booked);
            return RedirectToAction("Index");
        }

        /* [HttpGet]
         public IActionResult Details(int id)
         {
             var data = _context.
         }
 */

        [HttpGet]
        public IActionResult Edit(int id)
        {
           var data = _service.GetById(id);
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
            var data = _service.GetById(id);
            return View(data);

        }

        [HttpPost , ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
             _service.Delete(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }





    }
}
