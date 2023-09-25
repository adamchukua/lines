using Api.DTOs;
using Api.Entities;
using Api.Infrastructure.Data;
using Api.Services.ILikesService;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Api.Tests
{
    [TestFixture]
    public class LikesServiceTests
    {
        private LinesDbContext _dbContext;
        private LikesService _likesService;
        private IMapper _mapper;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LinesDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                })
                .Build();

            _mapper = host.Services.GetRequiredService<IMapper>();

            _dbContext = new LinesDbContext(options);
            _likesService = new LikesService(_dbContext, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetUserLikesAsync_ShouldReturnUserLikes()
        {
            var userName = "testuser";
            var user = new User { Id = 1, UserName = userName, Name = "Test User" };
            await _dbContext.Users.AddAsync(user);

            var post = new Post { Id = 1, UserId = 1, Text = "Test post", CreatedAt = DateTime.Now };
            await _dbContext.Posts.AddAsync(post);

            var like = new Like { Id = 1, UserId = user.Id, PostId = post.Id };
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();

            var result = await _likesService.GetUserLikesAsync(userName);

            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.All(l => l.User.UserName == userName));
            Assert.IsTrue(result.All(l => l.Post.Id == post.Id));
        }

        [Test]
        public async Task AddLikeAsync_ShouldAddLike()
        {
            var likeDto = new AddLikeDTO { UserId = 1, PostId = 1 };

            var result = await _likesService.AddLikeAsync(likeDto);

            var addedLike = await _dbContext.Likes.FirstOrDefaultAsync(l => l.UserId == likeDto.UserId && l.PostId == likeDto.PostId);

            Assert.IsTrue(result);
            Assert.IsNotNull(addedLike);
        }

        [Test]
        public async Task DeleteLikeAsync_ShouldDeleteLike()
        {
            var userId = 1;
            var postId = 1;
            var likeDto = new DeleteLikeDTO { UserId = userId, PostId = postId };

            var like = new Like { Id = 1, UserId = userId, PostId = postId };
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();

            var result = await _likesService.DeleteLikeAsync(likeDto);

            var deletedLike = await _dbContext.Likes.FirstOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);

            Assert.IsTrue(result);
            Assert.IsNull(deletedLike);
        }

        [Test]
        public async Task CheckIsLikedByUserAsync_ShouldReturnTrueIfLiked()
        {
            var userId = 1;
            var postId = 1;
            var like = new Like { Id = 1, UserId = userId, PostId = postId };
            await _dbContext.Likes.AddAsync(like);
            await _dbContext.SaveChangesAsync();

            var likeDto = new CheckLikeDTO { UserId = userId, PostId = postId };

            var result = await _likesService.CheckIsLikedByUserAsync(likeDto);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckIsLikedByUserAsync_ShouldReturnFalseIfNotLiked()
        {
            var userId = 1;
            var postId = 1;
            var likeDto = new CheckLikeDTO { UserId = userId, PostId = postId };

            var result = await _likesService.CheckIsLikedByUserAsync(likeDto);

            Assert.IsFalse(result);
        }
    }
}
