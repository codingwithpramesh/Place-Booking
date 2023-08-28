using Booking.Models;
using DataAcessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class Reviews : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int Order { get; set; }

        public int Rating { get; set; }

        public string ReviewBody { get; set; }

        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public Register Register { get; set; }

        public int BookingId { get; set; }
        [ForeignKey("BookingId")]
        public Booked Booked { get; set; }

        public int ParentId { get; set; }
    }
}
