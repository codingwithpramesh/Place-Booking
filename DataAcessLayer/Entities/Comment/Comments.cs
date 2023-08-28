using Booking.Data.Enum;
using Booking.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.Comment
{
    public class Comments
    {



        /*  public string Name { get; set; }

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

         *//* public int registerId { get; set; }
          [ForeignKey("registerId")]*/
        /*public  Register Register { get; set; }*//*

        public string User { get; set; }


       *//* public int PlaceId { get; set; }
        [ForeignKey("PlaceId")]*//*
       // public Places places { get; set; }


        public DateTime CreatedDate { get; set; }*/

        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }


    }
}
