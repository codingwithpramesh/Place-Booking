using Booking.Data;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ReviewsService : IReviewsService
    {
        private readonly ApplicationDbContext _context;
        public ReviewsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Reviews reviews)
        {
            _context.Add(reviews);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            Reviews data = _context.reviews.Where(re => re.Id == id).FirstOrDefault();
            _context.reviews.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Reviews> GetAll()
        {
            IEnumerable<Reviews> data = _context.reviews.ToList();
            return data;
        }

        public Reviews GetById(int id)
        {
            Reviews data = _context.reviews.FirstOrDefault(x => x.Id == id);
            return data;
        }

        public Reviews update(Reviews reviews)
        {
            _context.reviews.Update(reviews);
            _context.SaveChanges(true);
            return reviews;
        }
    }
}
