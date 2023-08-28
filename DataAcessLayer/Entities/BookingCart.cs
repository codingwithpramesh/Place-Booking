using Booking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities
{
    public class BookingCart 
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Users Users { get; set; }

        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Countries Countries { get; set; }

        public int Quantity { get; set; }

        public int RegisterId { get; set; }
        [ForeignKey("RegisterId")]
        public Register Register { get; set; }

        public int citiesId { get; set; }
        [ForeignKey("citiesId")]
        public Cities Cities { get; set; }
    }
}
