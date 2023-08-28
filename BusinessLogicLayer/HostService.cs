using Booking.Data;
using Booking.Models;
using DataAccessLayer.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class HostService : IHostService
    {
        private readonly ApplicationDbContext _context;
        public HostService(ApplicationDbContext Context) 
        {
            _context = Context;
        }

        public void Add(Hosts hosts)
        {
            Log.Information("Logging Information");
            var data = _context.Hosts.Add(hosts);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Log.Information("Logging Information");
            var data = _context.Hosts.FirstOrDefault(x => x.Id == id);
            _context.Hosts.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Hosts> GetAll()
        {
            var result = _context.Hosts.ToList();
            return result;
        }

        public Hosts GetById(int id)
        {
            var data = _context.Hosts.FirstOrDefault(c => c.Id == id);
            return data;
        }

        public Hosts update(Hosts hosts)
        {
            _context.Hosts.Update(hosts);
            _context.SaveChanges();
            return hosts;
        }
    }
}
