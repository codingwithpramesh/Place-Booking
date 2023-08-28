using Booking.Data.Enum;
using Booking.Models;
using DataAccessLayer.Entities.Comment;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Posts
    {

        /* public int Id { get; set; }

         public string Title { get; set; }

         public string Body { get; set; }

         public string Image { get; set; }

         public string Descriptions { get; set; }

         public string Tags { get; set; }

         public string Category { get; set; }

         public DateTime Created { get; set; } = DateTime.Now;*/

        /// <summary>
        /// 
        /// </summary>
        /// 





        [Key]
        public int Id{ get; set; }

        public string Name { get; set; }

        [Required(ErrorMessage = "This Field Must Be Required")]
        public string Address { get; set; }

        public Roles Roles { get; set; }

        public int order { get; set; }

        public int ParentId { get; set; }

        [ValidateNever]
        public string Image { get; set; }

        public int Rating { get; set; }

        public List<Reviews> Reviews { get; set; }
        public string comment { get; set; }

        public int registerId { get; set; }
        [ForeignKey("registerId")]
        public Register Register { get; set; }

        public string User { get; set; }


        public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]
         public Places places { get; set; }


        public DateTime CreatedDate { get; set; }

       
    }
}
