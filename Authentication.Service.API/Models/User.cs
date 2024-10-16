using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Authentication.Service.API.Models
{
    public class User
    {
        [Key]
        public int userId { get; set; }

        [Required]
        public string username { get; set; } = null!;

        [Required]
        public string password { get; set; } = null!;

        [EmailAddress]
        [Required]
        public string email { get; set; } = null!;
    
    }
}
