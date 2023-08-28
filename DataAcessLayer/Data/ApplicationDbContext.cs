using Booking.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using Microsoft.EntityFrameworkCore;

namespace Booking.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                .SelectMany(t => t.GetForeignKeys())
                                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cities> Cities { get; set; }

        public DbSet<Places> Places { get; set; }

        public DbSet<Countries> Countries { get; set; }

        public DbSet<Register> Register { get; set; }

        public DbSet<Booked> Booked { get; set; }

        public DbSet<Reviews> reviews { get; set; }

        public DbSet<BookingCart> BookingsCarts { get; set; }

        public DbSet<Hosts> Hosts { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Posts> posts { get; set; }

        public DbSet<MainComment> MainComments { get; set; }

        public DbSet<SubComment> SubComments { get; set; }
    }
}
