namespace AF_Mod32_Practice_32_11.Models.Db
{
    public interface IUserRepository
    {
        Task Add(User user);
        //Task<User[]> GetUsersInfo();
        
    }
}
