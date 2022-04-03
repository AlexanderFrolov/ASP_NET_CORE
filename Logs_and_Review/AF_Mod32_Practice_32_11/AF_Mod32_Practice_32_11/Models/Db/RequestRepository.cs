using Microsoft.EntityFrameworkCore;

namespace AF_Mod32_Practice_32_11.Models.Db
{
    public class RequestRepository : IRequestRepository
    {
        public readonly BlogContext _context;

        public RequestRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task Add(Request request)
        {
            var entry = _context.Entry(request);

            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            await _context.SaveChangesAsync();
        }

        public async Task<Request[]>  GetRequests()
        {
            return await _context.Requests.ToArrayAsync();
        }
    }
}
