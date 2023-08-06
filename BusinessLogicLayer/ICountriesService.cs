using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface ICountriesService
    {

        IEnumerable<Countries> GetAll();

        Countries GetById(int id);

        void Add(Countries countries);

        Countries update(Countries countries);

        void Delete(int id);
    }
}
