namespace AF_Mod32_Practice_32_11.Models.Db
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public List<UserBlog> UserBlogs { get; set; } = new List<UserBlog>();
    }
}
