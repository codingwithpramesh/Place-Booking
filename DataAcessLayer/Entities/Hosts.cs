using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    internal class Hosts
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "This Field Must Be Required")]
        [ForeignKey("User_Id")]
        public int User_Id { get; set; }
    }
}
