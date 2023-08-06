
using Booking.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class Register
    {
        [Key]
        public int Id { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public int age { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public string address { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        public string gender { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        public Roles Roles { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Email { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        public string password { get; set; }



        [Required(ErrorMessage = "This Field Must Be Required")]
        [Compare("password",ErrorMessage ="Password and confirm password must be same")]
        public string confirmpassword { get; set; }


    }
}
