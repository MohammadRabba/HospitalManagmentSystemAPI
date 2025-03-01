namespace WebApplication1.DBaccess
{
    public class User
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public ICollection<UserRoles> userRoles = new List<UserRoles>();
    }
}
