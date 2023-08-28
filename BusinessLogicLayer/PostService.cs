using Booking.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PostService : IPostService
    {
        
        public PostService(ApplicationDbContext context)
        {
            
        }
        public void AddSubComment(SubComment subComment)
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPost()
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPost(string category)
        {
            throw new NotImplementedException();
        }

        public Posts GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Posts GetPosts(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SavechangesAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Posts post)
        {
            throw new NotImplementedException();
        }
    }
}
