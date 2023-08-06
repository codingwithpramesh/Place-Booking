using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class ReviewsController : Controller
    {

        private readonly IReviewsService _service;
        public ReviewsController(IReviewsService service)
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
        public IActionResult Create(Reviews reviews)
        {
            _service.Add(reviews);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _service.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Reviews reviews) 
        {
            _service.update(reviews);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _service.GetById(id);
            return View(data);
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
            _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
