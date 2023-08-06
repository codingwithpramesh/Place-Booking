using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Cities
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        [ForeignKey("CountryId")]
        public int CountryId { get; set; }
    }
}
