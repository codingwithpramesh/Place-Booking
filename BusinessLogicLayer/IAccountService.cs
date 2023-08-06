using Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IAccountService
    {
        void Register(Register register);

       Register login(Register register);
    }
}
