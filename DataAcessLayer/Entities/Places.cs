
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Comment;
using DataAcessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Booking.Models
{
    public class Places : IEntityBase
    {
        public Places()
        {
            MainComments =  new  List<MainComment>();

        }

        [Key]
        public int Id { get; set; }

        public int HostId { get; set; }
        [ForeignKey("HostId")]
        public Hosts Hosts { get; set; }

        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Address { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public Cities Cities { get; set; }


        public string Category { get; set; }

        public List<MainComment> MainComments { get; set; }
    }
}
