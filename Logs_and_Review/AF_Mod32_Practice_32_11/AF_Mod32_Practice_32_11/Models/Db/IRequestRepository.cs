namespace AF_Mod32_Practice_32_11.Models.Db
{
    public interface IRequestRepository
    {
        Task Add(Request request);
        Task<Request[]> GetRequests();
    }
}
