using AutoMapper;
using Lines.Entities;
using Lines.Infrastructure.Data;
using Lines.Profiles;
using Lines.Services.UsersService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Lines.Tests
{
    [TestFixture]
    public class UsersServiceTests
    {
        private LinesDbContext _dbContext;
        private UsersService _usersService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<LinesDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new LinesDbContext(options);
            _usersService = new UsersService(_dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetUserAsync_ExistingUser_ReturnsUserDto()
        {
            var user = new User
            {
                UserName = "userone",
                Name = "User One",
                Description = "This is User One",
                Avatar = "avatar1.jpg",
                Email = "user1@example.com",
                EmailConfirmed = true
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            var userDto = await _usersService.GetUserAsync(user.UserName);

            Assert.NotNull(userDto);
        }

        [Test]
        public async Task GetUserAsync_NonExistentUser_ReturnsNull()
        {
            var nonExistentUserName = "nonexistentuser";

            var userDto = await _usersService.GetUserAsync(nonExistentUserName);

            Assert.Null(userDto);
        }
    }
}
