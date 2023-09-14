using AutoMapper;
using Api.DTOs;
using Api.Entities;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Web.Http.ModelBinding;

namespace Api.Services.PostsService
{
    public class PostsService : IPostsService
    {
        private readonly LinesDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostsService(LinesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public Task<List<Post>> SearchPostsAsync(string searchQuery, int pageNumber, int pageSize)
        {
            var posts = _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => EF.Functions.Like(p.Text.ToLower(), $"%{searchQuery.ToLower()}%"))
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return posts;
        }

        public async Task<Post> AddPostAsync(AddPostDTO postDto)
        {
            var user = await _dbContext.Users.FindAsync(postDto.UserId); // Retrieve the user by ID

            if (user == null)
            {
                return null;
            }

            var post = _mapper.Map<Post>(postDto);
            post.User = user;

            await _dbContext.Posts.AddAsync(post);
            await _dbContext.SaveChangesAsync();

            return post;
        }
    }
}