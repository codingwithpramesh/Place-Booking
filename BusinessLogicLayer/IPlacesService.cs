using Booking.Models;
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

        Places AddAsync(Places places, IFormFile file);

        Task<Places> update(Places places, IFormFile file);

        void Delete(int id);
    }
}
