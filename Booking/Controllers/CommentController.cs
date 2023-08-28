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
      /*  [HttpPost]
        public async Task<IActionResult> Comment(CommentViewModel VM)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("post", new {id = VM.Id});
            }

            var post = _Service.GetPosts(VM.Id);
            if(VM.MainCommentId == 0)
            {
               *//* post.MainComments = post.MainComments ?? new List<MainComment>();

                post.MainComments.Add(new MainComment
                {
                    Message = VM.Message,
                    Created = DateTime.Now,
                }) ;*//*

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
            return RedirectToAction("post", new {Id = VM.Id});*/
           /* return View();*/
       // }
    }
}
