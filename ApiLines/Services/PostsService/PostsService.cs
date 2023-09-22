using AutoMapper;
using Api.DTOs;
using Api.Entities;
using Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Web.Http.ModelBinding;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            var query = _dbContext.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new Post
                {
                    Id = p.Id,
                    Text = p.Text,
                    User = p.User == null ? null : new User
                    {
                        UserName = p.User.UserName,
                        Name = p.User.Name,
                        Avatar = p.User.Avatar,
                    },
                    Reposts = new List<Repost>(new Repost[p.Reposts.Count()]),
                    Likes = new List<Like>(new Like[p.Likes.Count()]),
                    Replies = new List<Post>(new Post[p.Replies.Count()]),
                    ParentPost = p.ParentPost == null ? null : new Post
                    {
                        Id = p.ParentPost.Id,
                        Text = p.ParentPost.Text,
                        User = p.ParentPost.User,
                        Reposts = new List<Repost>(new Repost[p.ParentPost.Reposts.Count()]),
                        Likes = new List<Like>(new Like[p.ParentPost.Likes.Count()]),
                        Replies = new List<Post>(new Post[p.ParentPost.Replies.Count()]),
                    }
                });

            var posts = await query.AsNoTracking().ToListAsync();

            return posts;
        }


        public async Task<List<Post>> GetUserRepliesAsync(string userName)
        {
            var query = _dbContext.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => p.User.UserName == userName && p.RepliedPostId != null);

            var replies = await query.AsNoTracking().ToListAsync();

            return replies;
        }

        public async Task<Post> GetPostAsync(long postId)
        {
            var query = _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Include(p => p.ParentPost)
                .ThenInclude(p => p.User)
                .Where(p => p.Id == postId)
                .OrderByDescending(p => p.CreatedAt);

            var post = await query.AsNoTracking().SingleAsync();

            return post;
        }

        public async Task<List<Post>> GetPostRepliesAsync(long postId)
        {
            var query = _dbContext.Posts
                .OrderByDescending(p => p.CreatedAt)
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => p.RepliedPostId == postId)
                .OrderByDescending(p => p.CreatedAt);

            var replies = await query.AsNoTracking().ToListAsync();

            return replies;
        }

        public async Task<List<Post>> SearchPostsAsync(string searchQuery, int pageNumber, int pageSize)
        {
            var query = _dbContext.Posts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .Where(p => EF.Functions.Like(p.Text.ToLower(), $"%{searchQuery.ToLower()}%"));

            var posts = await query.AsNoTracking().ToListAsync();

            return posts;
        }

        public async Task<Post> AddPostAsync(AddPostDTO postDto)
        {
            var user = await _dbContext.Users.FindAsync(postDto.UserId);

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