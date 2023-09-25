using AutoMapper;
using Api.DTOs;
using Api.Entities;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Api.Services.UsersService
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

        public async Task<List<User>> SearchUsersAsync(string searchQuery, int pageNumber, int pageSize)
        {
            var users = await _dbContext.Users
                .Where(u => EF.Functions.Like(u.UserName.ToLower(), $"%{searchQuery.ToLower()}%") ||
                            EF.Functions.Like(u.Name.ToLower(), $"%{searchQuery.ToLower()}%"))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return users;
        }
    }
}
