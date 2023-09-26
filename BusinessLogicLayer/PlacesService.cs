using Booking.Data;
using Booking.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using DataAccessLayer.Entities.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class PlacesService : IPlacesService
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PlacesService(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Places> Add(Places places, IFormFile file)
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
            await _context.AddAsync(places);
            await _context.SaveChangesAsync();
            return places;
        }

        public IEnumerable<Cities> Getcities()
        {
            var result = _context.Cities.ToList();
            return result;

        }



        public void Delete(int id)
        {
            Places data = _context.Places.FirstOrDefault(p => p.Id == id);
            _context.Places.Remove(data);
        }

        public IEnumerable<Places> GetAll()
        {
            IEnumerable<Places> data = _context.Places.ToList();
            return data;
        }

        public Places GetById(int id)
        {

            Places data = _context.Places.Include(x => x.MainComments).ThenInclude(y => y.SubComments).FirstOrDefault(x => x.Id == id);
            data.MainComments = data.MainComments.OrderByDescending(x => x.Id).ToList();
            return data;
        }


        public Task<Places> update(Places places, IFormFile file)
        {

            throw new NotImplementedException();
        }

        public Task<Places> Update(Places places, IFormFile file)
        {
            throw new NotImplementedException();
        }

        public Places GetPosts(int id)
        {
            return _context.Places.OrderBy(z => z.Id).Include(x => x.MainComments).ThenInclude(mc => mc.SubComments).FirstOrDefault(y => y.Id == id);
        }

        public List<Places> GetAllPost()
        {
            return _context.Places.Include(x => x.MainComments).ThenInclude(y => y.SubComments).ToList();
        }

        public List<Places> GetAllPost(string category)
        {
            Func<Places, bool> Incategory = (Places) => { return Places.Category.ToLower().Equals(category.ToLower()); };
            return _context.Places.OrderByDescending(x => x.Id).Where(Places => Incategory(Places)).ToList();
        }

        public void UpdatePost(Places Places)
        {
            _context.Places.Update(Places);
        }

        public void AddSubComment(SubComment subComment)
        {
            _context.SubComments.Add(subComment);
        }

        public void RemoveComment(int id)
        {
            _context.Places.Remove(GetPosts(id));
        }

        public async Task<bool> SavechangesAsync()
        {
            if (await _context.SaveChangesAsync()>0)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
