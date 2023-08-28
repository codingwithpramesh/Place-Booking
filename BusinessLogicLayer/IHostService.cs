using Booking.Models;
using DataAccessLayer.Entities;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public interface IHostService
    {
        IEnumerable<Hosts> GetAll();

        Hosts GetById(int id);

        void Add(Hosts hosts);

        Hosts update(Hosts hosts);

        void Delete(int id);
    }
}
