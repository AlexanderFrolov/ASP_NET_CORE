using Microsoft.EntityFrameworkCore;

namespace AF_Mod32_Practice_32_11.Models.Db
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _context;

        public UserRepository(BlogContext context)
        {
            _context = context; 
        }

        public async Task Add(User user)
        {
            var entry = _context.Entry(user);

            if (entry.State == EntityState.Detached)
                await _context.Users.AddAsync(user);    

            await _context.SaveChangesAsync();
        }

        //public Task<User[]> GetUsersInfo()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
