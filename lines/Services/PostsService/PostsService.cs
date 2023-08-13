using AutoMapper;
using Lines.DTOs;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.PostsService
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

        public async Task<List<PostBasicInfoDTO>> GetAllPostsAsync()
        {
            var posts = await _dbContext.Posts
                .Include(p => p.User)
                .Include(p => p.Reposts)
                .Include(p => p.Likes)
                .Include(p => p.Replies)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(posts);
            return postDtos;
        }
    }
}
