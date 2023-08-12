using AutoMapper;
using Lines.Entities;
using Lines.Infrastructure.Data;
using Lines.Profiles;
using Lines.Services.PostsService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Lines.Tests
{
    [TestFixture]
    public class PostsServiceTests
    {
        private LinesDbContext _dbContext;
        private PostsService _postsService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LinesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new LinesDbContext(options);
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PostProfile>();
                cfg.AddProfile<UserProfile>();
            });
            var _mapper = mapperConfig.CreateMapper();

            _postsService = new PostsService(_dbContext, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetAllPostsAsync_ShouldReturnAllPosts()
        {
            var user = new User { Id = 1, UserName = "testuser", Name = "testuser"};
            _dbContext.Users.Add(user);

            var posts = new List<Post>
            {
                new Post { Id = 1, UserId = user.Id, Text = "Test post 1", CreatedAt = DateTime.Now },
                new Post { Id = 2, UserId = user.Id, Text = "Test post 2", CreatedAt = DateTime.Now }
            };
            _dbContext.Posts.AddRange(posts);
            await _dbContext.SaveChangesAsync();

            var result = await _postsService.GetAllPostsAsync();

            Assert.AreEqual(posts.Count, result.Count);
            Assert.IsTrue(result.All(p => posts.Any(expected => expected.Id == p.Id)));
        }
    }
}
