using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities.ViewModel
{
    public class CommentViewModel
    {
        [Key]
        public int Id { get; set; }

        public int MainCommentId { get; set; }

      public string Message { get; set; }

    }
}
