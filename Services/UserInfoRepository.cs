using FoodsConnected.Contexts.UserInfo;
using FoodsConnected.Contexts.UserInfo.Entities;
using FoodsConnected.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodsConnected.Services
{
    public class UserInfoRepository : IUserInfoRepository
    {
        public UserInfoContext _context { get; }

        public UserInfoRepository(UserInfoContext context)
        {
            _context = context ?? 
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> UserNameExistsAsync(string userName, int? excludingUserId = null)
        {
            return await _context.Users.Where(w => w.Name.ToLower() == userName.ToLower() && w.Id != excludingUserId).AnyAsync();
        }

        public void AddUser(UserEntity user)
        {
            _context.Users.Add(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<IEnumerable<UserEntity>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(o => o.Name).ToListAsync();
        }

        public async Task<UserEntity?> GetUserAsync(int userId)
        {
            return await _context.Users.Where(w => w.Id == userId).FirstOrDefaultAsync();
        }

        public void DeleteUser(UserEntity user)
        {
            _context.Users.Remove(user);
        }
    }
}
