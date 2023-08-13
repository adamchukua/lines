using Lines.DTOs;

namespace Lines.Services.UsersService
{
    public interface IUsersService
    {
        Task<UserWithPostsRepostsLikesDTO> GetUserAsync(string userName);
    }
}
