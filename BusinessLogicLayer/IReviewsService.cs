using Booking.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{


    public interface IReviewsService
    {

        IEnumerable<Reviews> GetAll();

        Reviews GetById(int id);

        void Add(Reviews reviews);

        Reviews update(Reviews reviews);

        void Delete(int id);
    }
}
