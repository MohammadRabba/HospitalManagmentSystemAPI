using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EntityDTO
{
    public class LoginDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]

        public string password { get; set; }
    }

}
