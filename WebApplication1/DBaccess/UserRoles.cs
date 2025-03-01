namespace WebApplication1.DBaccess
{
    public class UserRoles
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public int rollID { get; set; }
        public Roll Roll { get; set; }
    }
}
