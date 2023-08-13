using Lines.DTOs;

namespace Lines.Services.UsersService
{
    public interface IUsersService
    {
        Task<UserDetailedInfoDTO> GetUserAsync(string userName);
    }
}
