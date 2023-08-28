using Booking.Data;
using Booking.Models;

namespace BusinessLogicLayer
{
    public class BookingPlaceService : IBookingPlaceService
    {
        private readonly ApplicationDbContext _context;
        public BookingPlaceService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Booked booked)
        {
            _context.Add(booked);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var data = _context.Booked.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Booked> GetAll()
        {
            var data = _context.Booked.ToList();
            return data;
        }

        public Booked GetById(int id)
        {
            var data = _context.Booked.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public Booked update(Booked cities)
        {
            _context.Booked.Update(cities);
            _context.SaveChanges();
            return cities;

        }


    }
}
