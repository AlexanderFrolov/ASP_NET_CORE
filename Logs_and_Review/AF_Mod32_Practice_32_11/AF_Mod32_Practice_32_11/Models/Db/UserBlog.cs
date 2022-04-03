namespace AF_Mod32_Practice_32_11.Models.Db
{
    public class UserBlog
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
    }
}
