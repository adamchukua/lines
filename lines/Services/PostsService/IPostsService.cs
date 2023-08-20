using Lines.Entities;

namespace Lines.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<Post>> GetAllPostsAsync(int pageNumber, int pageSize);
        Task<List<Post>> GetUserRepliesAsync(string userName);
        Task<Post> GetPostAsync(long postId);
        Task<List<Post>> GetPostRepliesAsync(long postId);
    }
}
