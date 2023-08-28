using DataAcessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class Countries :IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Must Be Required")]
        public int CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
