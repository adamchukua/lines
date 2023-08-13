using AutoMapper;
using Lines.DTOs;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly LinesDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(LinesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserWithPostsRepostsLikesDTO> GetUserAsync(string userName)
        {
            var user = await _dbContext.Users
                .Include(u => u.Posts)
                .Include(u => u.Reposts)
                .Include(u => u.Followers)
                .Include(u => u.Following)
                .Include(u => u.Likes)
                .Include(u => u.Likes)
                    .ThenInclude(l => l.Post)
                        .ThenInclude(p => p.User)
                .Include(u => u.Likes)
                    .ThenInclude(l => l.Post)
                        .ThenInclude(p => p.Replies)
                .FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserWithPostsRepostsLikesDTO>(user);
            return userDto;
        }
    }
}
