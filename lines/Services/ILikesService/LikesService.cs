using Lines.Entities;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.ILikesService
{
    public class LikesService : ILikesService
    {
        private readonly LinesDbContext _dbContext;

        public LikesService(LinesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Like>> GetUserLikesAsync(string userName)
        {
            var likes = await _dbContext.Likes
                .Include(l => l.User)
                .Include(l => l.Post)
                .ThenInclude(p => p.User)
                .Where(l => l.User.UserName == userName)
                .ToListAsync();

            return likes;
        }
    }
}
