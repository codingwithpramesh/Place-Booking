using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class Countries
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public int Country_Code { get; set; }


        public string Country_Name { get; set; }
    }
}
