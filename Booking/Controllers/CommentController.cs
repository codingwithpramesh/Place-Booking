using BusinessLogicLayer;
using DataAccessLayer.Entities.Comment;
using DataAccessLayer.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Controllers
{
    public class CommentController : Controller
    {

        private readonly IPostService _Service;
        public CommentController(IPostService service) 
        { 
            _Service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
