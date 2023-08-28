using AspNetCoreHero.ToastNotification.Abstractions;
using Booking.Data;
using Booking.Models;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using DataAccessLayer.Entities.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace Booking.Controllers
{
    public class PlacesController : Controller
    {

        private readonly IPlacesService _Service;
        //  private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
       // private readonly INotyfService _notyf;
        public PlacesController(IPlacesService service, IWebHostEnvironment webHostEnvironment)
        {
            /*_context = context;*/
            _Service = service;
            _webHostEnvironment = webHostEnvironment;
          


        }
        public IActionResult Index()
        {
            IEnumerable<Places> Data = _Service.GetAll();
            return View(Data);

        }

        public IActionResult PlacesView()
        {
            IEnumerable<Places> Data = _Service.GetAll();
            return View(Data);

        }
        [HttpPost]
        public IActionResult Book(int id)
        {
            Places data = _Service.GetById(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var lstcities = _Service.Getcities().Select(x => new SelectListItem
            {

                Text=x.Name,
                Value=x.Id.ToString()

            });

            ViewData["cities"] = lstcities;
            ViewData["places"] = new Places();
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatedAsync(Places place, IFormFile? file)
        {
            try
            {
                await _Service.Add(place, file);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("CreatedAsync", "Places", ex);
            }
            
           /* try
            {
                if (ModelState.IsValid)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    place.Image = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    //Insert record
                    _context.Add(place);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();*/


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Places data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Places place, IFormFile file)
        {
           /* _Service.pla.update(place, file);*/
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Places data = _Service.GetById(id);
            return View(data);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _Service.Delete(id);
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
            Places Data = _Service.GetById(id);
            return View(Data);
        }

       /* public IActionResult Details()
        {
            return View();
        }*/

        public IActionResult PlacesComment(int id)
        {
            try
            {
                /* Places data = _Service.GetById(id);
                 Comments comment = new Comments();
                 comment.ParentId = id;
                 var reviews = _Service.GetById(id);
              //   comment.Reviews = reviews.re;
                 return View(data);*/
                Places data = _Service.GetById(id);
                return View(data);
            }catch (Exception ex)
            {
                return RedirectToAction("PlacesComment", "Places", ex);
            }
        }

        public IActionResult CommentsDetails(CommentViewModel vm)
        {
           /* if(!ModelState.IsValid)
                return Post()
                
            return View();*/
           return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Places", new { id = VM.Id });
            }

            var post = _Service.GetPosts(VM.Id);
            if (VM.MainCommentId == 0)
            {

                post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = VM.Message,
                    Created = DateTime.Now,
                });

                post.MainComments = post.MainComments.OrderByDescending(c => c.Created).ToList();

                _Service.UpdatePost(post);
            }
            else
            {
                var comment = new SubComment
                {
                    MainCommentId = VM.MainCommentId,
                    Message = VM.Message,
                    Created = DateTime.Now,
                };
                
                
                _Service.AddSubComment(comment);
            }
            await _Service.SavechangesAsync();
            return RedirectToAction("placescomment", new { Id = VM.Id  });
          
            
        }
    }
}
