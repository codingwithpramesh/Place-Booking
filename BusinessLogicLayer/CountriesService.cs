using Booking.Data;
using Booking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CountriesService : ICountriesService
    {
        private readonly  ApplicationDbContext _context;
        public CountriesService( ApplicationDbContext context) 
        { 
            _context = context;
        }

        public void Add(Countries countries)
        {
            _context.Countries.Add(countries);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var data = _context.Countries.FirstOrDefault(x => x.Id == id);
            _context.Countries.Remove(data);
            _context.SaveChanges();
         
        }

        public IEnumerable<Countries> GetAll()
        {
           var data = _context.Countries.ToList();
           return data;
        }

        public Countries GetById(int id)
        {
            var data =_context.Countries.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public Countries update(Countries countries)
        {
            _context.Countries.Update(countries);
            _context.SaveChanges();
            return countries;
        }
    }
}
