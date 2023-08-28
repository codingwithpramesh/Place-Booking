
using DataAccessLayer.Entities;
using DataAcessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Booked : IEntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int userID { get; set; }
        [ForeignKey("userID")]
        public Users User { get; set; }

        public int placeId { get; set; }
        [ForeignKey("placeId")]
        public Places places { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float PricePerNight { get; set; }

        public int NumberOfNight { get; set; }
    }
}
