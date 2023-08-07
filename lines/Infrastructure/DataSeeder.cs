using lines.Entities;
using lines.Infrastructure.Data;

namespace lines.Infrastructure
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
                };

                var replies = new List<Post>
                {
                    new Post { Text = "Agree! Freedom of speech is here!", UserId = 1, RepliedPostId = 2, CreatedAt = DateTime.Now },
                    new Post { Text = "+", UserId = 3, RepliedPostId = 2, CreatedAt = DateTime.Now },
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
