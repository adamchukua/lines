using Api.DTOs;
using Api.Entities;
using Api.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.ILikesService
{
    public class LikesService : ILikesService
    {
        private readonly LinesDbContext _dbContext;
        private readonly IMapper _mapper;

        public LikesService(LinesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<bool> AddLikeAsync(AddLikeDTO likeDto)
        {
            var like = _mapper.Map<Like>(likeDto);
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CheckIsLikedByUserAsync(CheckLikeDTO likeDto)
        {
            var likeExists = await _dbContext.Likes
                .AnyAsync(like => like.PostId == likeDto.PostId && like.UserId == likeDto.UserId);

            return likeExists;
        }
    }
}
