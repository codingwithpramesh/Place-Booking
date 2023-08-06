
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Booking.Models
{
    public class Booked
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public int userID { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        public int placeId { get; set; }

      /*  [ValidateNever]
        public string? Image { get; set; }*/

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float PricePerNight { get; set; }

        public int Num_night { get; set; }


        //[ValidateNever
        //public IFormFile ImageFile { get; set; }



    }
}
