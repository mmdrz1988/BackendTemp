using DPEprojectTask.Domain.Contracts;
using DPEprojectTask.Domain.Model.Users;
using DPEprojectTask.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DPEprojectTask.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<CustomIdentityUser> Get(int id)
        {
            var user= await _appDbContext.customIdentityUsers.FirstOrDefaultAsync(u => u.Id == id); 
            return user;
        }
        public async Task Save(CustomIdentityUser user)
        {
            _appDbContext.customIdentityUsers.Update(user);
        }
    }
}
