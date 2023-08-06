using Booking.Models;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Cities> Cities { get; set; }

        public DbSet<Places> Places { get; set; }

        public DbSet<Countries> Countries { get; set; }

        public DbSet<Register> Register { get; set; }

       public DbSet<Booked> bookings { get; set; }

        public DbSet<Reviews> reviews { get; set; }
    }
}
