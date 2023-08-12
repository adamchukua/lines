using Lines.DTOs;

namespace Lines.Services.PostsService
{
    public interface IPostsService
    {
        Task<List<PostBasicInfoDTO>> GetAllPostsAsync();
    }
}
