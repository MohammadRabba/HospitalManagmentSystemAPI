namespace WebApplication1.DBaccess
{
    public class Roll
    {
        public int Id { get; set; }
        public string name { get; set; }
        public ICollection<UserRoles> userRoles { get; set; } = new List<UserRoles>();
    }
}
