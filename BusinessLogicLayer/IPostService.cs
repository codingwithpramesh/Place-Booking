using Booking.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IPostService
    {
        Posts GetPosts(int id);

        List<Posts> GetAllPost();

        List<Posts> GetAllPost(string category);

        void UpdatePost(Posts post);

        void AddSubComment(SubComment subComment);

        Posts GetById(int id);

        void RemoveComment(int id);

        Task<bool> SavechangesAsync();
    }
}
