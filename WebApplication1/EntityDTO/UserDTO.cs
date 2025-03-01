using System.ComponentModel.DataAnnotations;

namespace WebApplication1.EntityDTO
{
    public class UserDTO
    {
        [Required]
        public string userName { get; set; }
        [Required]

        public string password { get; set; }
        [Required]
        [Compare(nameof(password))]
        public string passwordConf { get; set; }
        public List<int> RollsIds { get; set; }

    }
}
