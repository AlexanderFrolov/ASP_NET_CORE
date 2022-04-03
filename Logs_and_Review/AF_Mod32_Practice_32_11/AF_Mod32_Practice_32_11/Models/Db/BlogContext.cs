using Microsoft.EntityFrameworkCore;

namespace AF_Mod32_Practice_32_11.Models.Db
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserBlog> UserBlogs { get; set; }  


        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<UserBlog>().ToTable("UserBlogs");

        }


    }

    

}
