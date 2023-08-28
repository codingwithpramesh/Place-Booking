using DataAcessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Cities : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Name { get; set; }
      
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Countries Countries { get; set; }
    }
}
