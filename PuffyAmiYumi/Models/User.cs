namespace PuffyAmiYumi.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
    }

    public static class ApplicationRoles
    {
        public const string Member = "Member";
        public const string Admin = "Admin";
    }
}