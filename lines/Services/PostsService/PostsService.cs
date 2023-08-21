using AutoMapper;
using Lines.DTOs;
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

        public async Task<List<Post>> GetAllPostsAsync(int pageNumber, int pageSize)
        {
            var posts = await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Include(p => p.ParentPost)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return posts;
        }

        public async Task<List<Post>> GetUserRepliesAsync(string userName)
        {
            var replies = await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => p.User.UserName == userName && p.RepliedPostId != null)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return replies;
        }

        public async Task<Post> GetPostAsync(long postId)
        {
            var post = await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Include(p => p.ParentPost)
                .ThenInclude(p => p.User)
                .Where(p => p.Id == postId)
                .OrderByDescending(p => p.CreatedAt)
                .SingleAsync();

            return post;
        }

        public async Task<List<Post>> GetPostRepliesAsync(long postId)
        {
            var replies = await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => p.RepliedPostId == postId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return replies;
        }

        public Task<List<Post>> SearchPostsAsync(string searchQuery)
        {
            var posts = _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => EF.Functions.Like(p.Text.ToLower(), $"%{searchQuery.ToLower()}%"))
                .ToListAsync();

            return posts;
        }
    }
}
