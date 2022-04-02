using Microsoft.EntityFrameworkCore;

namespace AspNETCoreMVCTemplate.Models
{
    public class AppContextDB : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }

        public AppContextDB(DbContextOptions<AppContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>().ToTable("UserInfos");
        }
    }
}
