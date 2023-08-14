using Lines.Entities;
using Lines.Infrastructure.Data;

namespace Lines.Infrastructure
{
    public static class DataSeeder
    {
        public static void SeedData(LinesDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        UserName = "userone",
                        Name = "User One",
                        Description = "This is User One",
                        Avatar = "avatar1.jpg",
                        Email = "user1@example.com",
                        EmailConfirmed = true
                    },
                    new User
                    {
                        UserName = "usertwo",
                        Name = "User Two",
                        Description = "This is User Two",
                        Avatar = "avatar2.jpg",
                        Email = "user2@example.com",
                        EmailConfirmed = true
                    },
                    new User
                    {
                        UserName = "userthree",
                        Name = "User Ten",
                        Description = "This is User Ten",
                        Avatar = "avatar10.jpg",
                        Email = "user10@example.com",
                        EmailConfirmed = true
                    }
                };

                context.Users.AddRange(users);
                context.SaveChanges();
            }

            if (!context.Posts.Any())
            {
                var posts = new List<Post>
                {
                    new Post { Text = "Hello World!", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "ASP.NET Core is awesome!", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Twitter or X? Lines!", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Wow!", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Just had a great coding session!", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Learning new technologies is so exciting.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Working on a new project. Stay tuned!", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Chasing my dreams, one line of code at a time.", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Coding is my passion.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Always strive for excellence in your code.", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Tech world is evolving rapidly!", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Excited to share my latest project with you all.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Coding is an art.", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Remember to stay hydrated during long coding sessions.", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Building cool things with React.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Coding challenges make us better developers.", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Just deployed my app. Feels amazing!", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Keep calm and code on.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Refactoring is an essential part of coding.", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Happy coding, everyone!", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Code reviews help us learn and improve.", UserId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Coding is not just a job, it's a lifestyle.", UserId = 3, CreatedAt = DateTime.Now },
                    new Post { Text = "Just found a clever solution to a tricky problem.", UserId = 1, CreatedAt = DateTime.Now },
                    new Post { Text = "Sharing my coding journey on my blog.", UserId = 2, CreatedAt = DateTime.Now }
                };

                var replies = new List<Post>
                {
                    new Post { Text = "Agree! Freedom of speech is here!", UserId = 1, RepliedPostId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "+", UserId = 2, RepliedPostId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "Maybe without russians would be better :)", UserId = 3, RepliedPostId = 5, CreatedAt = DateTime.Now },
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
                context.Posts.AddRange(replies);
                context.SaveChanges();
            }

            if (!context.Reposts.Any())
            {
                var existingPosts = context.Posts.ToList();

                var reposts = new List<Repost>
                {
                    new Repost { PostId = existingPosts[0].Id, UserId = 1 },
                    new Repost { PostId = existingPosts[1].Id, UserId = 2 },
                };

                context.Reposts.AddRange(reposts);
                context.SaveChanges();
            }

            if (!context.Likes.Any())
            {
                var existingPosts = context.Posts.ToList();

                var likes = new List<Like>
                {
                    new Like { PostId = existingPosts[0].Id, UserId = 2, CreatedAt = DateTime.Now },
                    new Like { PostId = existingPosts[1].Id, UserId = 3, CreatedAt = DateTime.Now },
                    new Like { PostId = existingPosts[2].Id, UserId = 1, CreatedAt = DateTime.Now },
                };

                context.Likes.AddRange(likes);
                context.SaveChanges();
            }

            if (!context.Followers.Any())
            {
                var followers = new List<Follower>
                {
                    new Follower { FollowerId = 1, FollowingId = 2 },
                    new Follower { FollowerId = 1, FollowingId = 3 },
                    new Follower { FollowerId = 2, FollowingId = 3 },
                };

                context.Followers.AddRange(followers);
                context.SaveChanges();
            }
        }
    }
}
