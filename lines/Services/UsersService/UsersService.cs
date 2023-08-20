using AutoMapper;
using Lines.DTOs;
using Lines.Entities;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<User>> SearchUsersAsync(string searchQuery)
        {
            var users = await _dbContext.Users
                .Where(u => EF.Functions.Like(u.UserName.ToLower(), $"%{searchQuery}%") ||
                            EF.Functions.Like(u.UserName.ToLower(), $"%{searchQuery}%"))
                .ToListAsync();

            return users;
        }
    }
}
