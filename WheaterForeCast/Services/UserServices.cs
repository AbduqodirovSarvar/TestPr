using Microsoft.EntityFrameworkCore;
using WheaterForeCast.DB;
using WheaterForeCast.Entities;

namespace WheaterForeCast.Services
{

    public class UserServices
    {
        private readonly AppDbContext context;

        public UserServices(AppDbContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<User> AddUser(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<bool> DeleteUser(Guid guid)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == guid);
            if (user == null)
            {
                return false;
            }

            context.Remove(user);
            return (await context.SaveChangesAsync()) > 0;
        }

    }
}
