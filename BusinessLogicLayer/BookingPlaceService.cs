using Booking.Data;
using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BookingPlaceService : IBookingPlaceService
    {
        private readonly ApplicationDbContext _context;
        public BookingPlaceService( ApplicationDbContext context) 
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
            var data = _context.bookings.Where(x => x.Id == id).FirstOrDefault();
          _context.Remove(data);
          _context.SaveChanges();
        }

        public IEnumerable<Booked> GetAll()
        {
            var data = _context.bookings.ToList();
            return data;    
        }

        public Booked GetById(int id)
        {
           var data = _context.bookings.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public  Booked update(Booked cities)
        {
            _context.bookings.Update(cities);
            _context.SaveChanges();
            return cities;
            
        }

    
    }
}
