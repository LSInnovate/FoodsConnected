using FoodsConnected.Contexts.UserInfo.Entities;
using Microsoft.EntityFrameworkCore;

namespace FoodsConnected.Contexts.UserInfo
{
    public class UserInfoContext : DbContext
    {
        public UserInfoContext(DbContextOptions<UserInfoContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; } = null!;
    }
}
