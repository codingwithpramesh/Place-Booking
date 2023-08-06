using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("BookingId")]
        public int BookingId { get; set; }

        public int Rating { get; set; }

        public string? ReviewBody { get; set; }
    }
}
