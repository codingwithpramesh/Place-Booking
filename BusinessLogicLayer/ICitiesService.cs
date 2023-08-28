using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  interface ICitiesService 
    {
        IEnumerable<Cities> GetAll();

        Cities GetById(int id);

        IEnumerable<Countries> GetAllCountries();

        void Add(Cities cities);

        Cities update(Cities cities);

        void Delete(int id);


    }
}
