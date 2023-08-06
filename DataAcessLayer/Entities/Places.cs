
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Places
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("HostId")]
        public int HostId { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Address { get; set; }

        [ValidateNever]
        public string Image { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        [ForeignKey("City_Id")]
        public int City_Id { get; set; }
    }
}
