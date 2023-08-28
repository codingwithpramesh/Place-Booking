using DataAcessLayer.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class Users :IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
    }
}
