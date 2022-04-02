using Microsoft.EntityFrameworkCore;

namespace AspNETCoreMVCTemplate.Models
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly AppContextDB _context;

        public UserInfoRepository(AppContextDB context)
        {
            _context = context;
        }

        public async Task Add(UserInfo userInfo)
        {
            var entry = _context.Entry(userInfo);
            
            if(entry.State == EntityState.Detached)
                await _context.UserInfos.AddAsync(userInfo);

            await _context.SaveChangesAsync();  
        }

        public async Task<UserInfo[]> GetUsersInfo()
        {
            return await _context.UserInfos.OrderBy(a => a.Date).ToArrayAsync();
        }
    }
}
