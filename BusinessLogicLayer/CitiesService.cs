using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CitiesService : ICitiesService
    {
        private readonly ApplicationDbContext _context;
        public CitiesService( ApplicationDbContext context) 
        {
            _context = context;
        }
        public void Add(Cities cities)
        {
            Log.Information("Logging Information");
            var data = _context.Cities.Add(cities);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            Log.Information("Logging Information");
            var data = _context.Cities.FirstOrDefault(x => x.Id == id);
            _context.Cities.Remove(data);
            _context.SaveChanges();
        }


        public IEnumerable<Countries> GetAllCountries()
        {
            var result = _context.Countries.ToList();
            return result;
        }

        public IEnumerable<Cities> GetAll()
        {
           
            var result = _context.Cities.ToList();
            return result;
           
        }

        public Cities GetById(int id)
        {
           var data =_context.Cities.FirstOrDefault(c => c.Id == id);
           IEnumerable<Cities> cities =_context.Cities.Where(c => c.Id == id);
           return data;
        }

       public Cities update(Cities cities)
        {
            _context.Cities.Update(cities);
            _context.SaveChanges();
            return cities;
        }
    }
}
