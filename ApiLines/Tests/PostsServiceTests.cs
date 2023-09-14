using AutoMapper;
using Api.Entities;
using Api.Infrastructure.Data;
using Api.Profiles;
using Api.Services.PostsService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Api.Tests
{
    [TestFixture]
    public class PostsServiceTests
    {
        private LinesDbContext _dbContext;
        private IMapper _mapper;
        private PostsService _postsService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LinesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new LinesDbContext(options);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                })
                .Build();

            _mapper = host.Services.GetRequiredService<IMapper>();

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
            var user = new User { Id = 1, UserName = "testuser", Name = "testuser" };
            _dbContext.Users.Add(user);

            var posts = new List<Post>
            {
                new Post { Id = 1, UserId = user.Id, Text = "Test post 1", CreatedAt = DateTime.Now },
                new Post { Id = 2, UserId = user.Id, Text = "Test post 2", CreatedAt = DateTime.Now }
            };
            _dbContext.Posts.AddRange(posts);
            await _dbContext.SaveChangesAsync();

            var result = await _postsService.GetAllPostsAsync(1, 10);

            Assert.AreEqual(posts.Count, result.Count);
            Assert.IsTrue(result.All(p => posts.Any(expected => expected.Id == p.Id)));
        }

        [Test]
        public async Task GetUserRepliesAsync_ShouldReturnUserReplies()
        {
            var userName = "testuser";
            var user = new User { Id = 1, UserName = userName, Name = "Test User" };
            _dbContext.Users.Add(user);

            var replies = new List<Post>
            {
                new Post { Id = 1, UserId = user.Id, Text = "Reply 1", RepliedPostId = 100, CreatedAt = DateTime.Now },
                new Post { Id = 2, UserId = user.Id, Text = "Reply 2", RepliedPostId = 101, CreatedAt = DateTime.Now }
            };
            _dbContext.Posts.AddRange(replies);
            await _dbContext.SaveChangesAsync();

            var result = await _postsService.GetUserRepliesAsync(userName);

            Assert.AreEqual(replies.Count, result.Count);
            Assert.IsTrue(result.All(p => replies.Any(expected => expected.Id == p.Id)));
            Assert.IsTrue(result.All(p => p.User.UserName == userName));
            Assert.IsTrue(result.All(p => p.RepliedPostId != null));
        }

        [Test]
        public async Task SearchPostsAsync_ShouldReturnMatchingPosts()
        {
            var user = new User { Id = 1, UserName = "testuser", Name = "testuser" };
            _dbContext.Users.Add(user);

            var posts = new List<Post>
            {
                new Post { Id = 1, UserId = user.Id, Text = "Test post 1", CreatedAt = DateTime.Now },
                new Post { Id = 2, UserId = user.Id, Text = "Test post 2", CreatedAt = DateTime.Now }
            };
            _dbContext.Posts.AddRange(posts);
            await _dbContext.SaveChangesAsync();

            var searchQuery = "Test post";

            var result = await _postsService.SearchPostsAsync(searchQuery, 1, 10);

            Assert.AreEqual(posts.Count, result.Count);
            Assert.IsTrue(result.All(p => posts.Any(expected => expected.Id == p.Id)));
        }
    }
}
