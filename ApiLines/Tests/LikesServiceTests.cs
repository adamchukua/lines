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
                .UseInMemoryDatabase(databaseName: "TestDatabase")
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
            _dbContext.Users.Add(user);

            var post = new Post { Id = 1, UserId = 2, Text = "Test post", CreatedAt = DateTime.Now };
            _dbContext.Posts.Add(post);

            var likes = new List<Like>
            {
                new Like { Id = 1, UserId = user.Id, PostId = post.Id },
                new Like { Id = 2, UserId = user.Id, PostId = post.Id }
            };
            _dbContext.Likes.AddRange(likes);
            await _dbContext.SaveChangesAsync();

            var result = await _likesService.GetUserLikesAsync(userName);

            Assert.AreEqual(likes.Count, result.Count);
            Assert.IsTrue(result.All(l => likes.Any(expected => expected.Id == l.Id)));
            Assert.IsTrue(result.All(l => l.User.UserName == userName));
            Assert.IsTrue(result.All(l => l.Post.Id == post.Id));
        }
    }
}
