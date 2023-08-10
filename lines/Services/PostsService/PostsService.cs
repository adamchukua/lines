using Lines.Entities;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.PostsService
{
    public class PostsService : IPostsService
    {
        private readonly LinesDbContext _dbContext;

        public PostsService(LinesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetAllPostsAsync()
        {
            return await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .ToListAsync();
        }
    }
}
