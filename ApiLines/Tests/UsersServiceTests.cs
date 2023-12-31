﻿using AutoMapper;
using Api.Entities;
using Api.Infrastructure.Data;
using Api.Profiles;
using Api.Services.UsersService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Api.Tests
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
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
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
        public async Task GetUserAsync_ExistingUser_ReturnsUser()
        {
            var user = new User
            {
                UserName = "userone111",
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

        [Test]
        public async Task SearchUsersAsync_ExistingUsers_ReturnsMatchingUsers()
        {
            var user1 = new User
            {
                UserName = "userone",
                Name = "User One",
                Description = "This is User One",
                Avatar = "avatar1.jpg",
                Email = "user1@example.com",
                EmailConfirmed = true
            };

            var user2 = new User
            {
                UserName = "usertwo",
                Name = "User Two",
                Description = "This is User Two",
                Avatar = "avatar2.jpg",
                Email = "user2@example.com",
                EmailConfirmed = true
            };

            _dbContext.Users.AddRange(user1, user2);
            _dbContext.SaveChanges();

            var searchQuery = "user";

            var matchingUsers = await _usersService.SearchUsersAsync(searchQuery, 1, 10);

            Assert.AreEqual(2, matchingUsers.Count);
            CollectionAssert.Contains(matchingUsers, user1);
            CollectionAssert.Contains(matchingUsers, user2);
        }

        [Test]
        public async Task SearchUsersAsync_NonExistentUsers_ReturnsEmptyList()
        {
            var searchQuery = "nonexistentuser";

            var matchingUsers = await _usersService.SearchUsersAsync(searchQuery, 1, 10);

            Assert.IsEmpty(matchingUsers);
        }
    }
}
