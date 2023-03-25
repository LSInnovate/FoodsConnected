using FoodsConnected.Contexts.UserInfo.Entities;

namespace FoodsConnected.Services.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<bool> UserNameExistsAsync(string userName);
        void AddUser(UserEntity user);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<UserEntity>> GetUsersAsync();
        Task<UserEntity?> GetUserAsync(int userId);
        void DeleteUser(UserEntity user);
    }
}
