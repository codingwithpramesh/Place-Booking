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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PlacesController(IPlacesService service, IWebHostEnvironment webHostEnvironment)
        {
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


        public IActionResult Details(int id)
        {
            Places Data = _Service.GetById(id);
            return View(Data);
        }


        public IActionResult PlacesComment(int id)
        {
            try
            {

                Places data = _Service.GetById(id);
                return View(data);
            }
            catch (Exception ex)
            {
                return RedirectToAction("PlacesComment", "Places", ex);
            }
        }

        public IActionResult CommentsDetails(CommentViewModel vm)
        {
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
            return RedirectToAction("placescomment", new { Id = VM.Id });


        }
    }
}
