using Booking.Models;
using DataAccessLayer.Entities.Comment;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IPlacesService
    {
        IEnumerable<Places> GetAll();

        Places GetById(int id);

        Task<Places> Add(Places places, IFormFile file);

        Task<Places> Update(Places places, IFormFile file);

        void Delete(int id);

      //  CommentsModel Comment(CommentsModel comment);




        IEnumerable<Cities> Getcities();





        /// comments 
        /// 


        Places GetPosts(int id);

        List<Places> GetAllPost();

        List<Places> GetAllPost(string category);

        void UpdatePost(Places Places);

        void AddSubComment(SubComment subComment);

       

        void RemoveComment(int id);

        Task<bool> SavechangesAsync();
    }
}
