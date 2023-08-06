using Booking.Data;
using Booking.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PlacesService : IPlacesService
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PlacesService(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment) 
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
       

        public async Task AddAsync(Places places, IFormFile file)
        {
            try
            {
                
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    places.Image = @"\Images\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    //Insert record
                    _context.Add(places);
                    await _context.SaveChangesAsync();
                    ;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Places> GetAll()
        {
            throw new NotImplementedException();
        }

        public Places GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Places update(Places places)
        {
            throw new NotImplementedException();
        }

        void IPlacesService.AddAsync(Places places, IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
