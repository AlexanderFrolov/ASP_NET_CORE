namespace AspNETCoreMVCTemplate.Models
{
    public interface IUserInfoRepository
    {
        Task Add(UserInfo userInfo);
        Task<UserInfo[]> GetUsersInfo();
    }
}
