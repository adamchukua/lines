using AutoMapper;
using Lines.DTOs;
using Lines.Entities;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly LinesDbContext _dbContext;

        public UsersService(LinesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUserAsync(string userName)
        {
            var user = await _dbContext.Users
                .Include(u => u.Posts)
                .Include(u => u.Reposts)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }
    }
}
