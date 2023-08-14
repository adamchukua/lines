using Lines.Entities;

namespace Lines.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<Post>> GetAllPostsAsync();
    }
}
