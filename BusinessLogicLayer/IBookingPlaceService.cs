using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IBookingPlaceService
    {
        IEnumerable<Booked> GetAll();

        Booked GetById(int id);

        void Add(Booked booked);

        Booked update(Booked booked);

        void Delete(int id);

    }
}
