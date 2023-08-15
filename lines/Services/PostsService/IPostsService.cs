using Lines.Entities;

namespace Lines.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<Post>> GetAllPostsAsync(int pageNumber, int pageSize);
        Task<List<Post>> GetUserRepliesAsync(string userName);
    }
}
