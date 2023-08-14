using Lines.Entities;

namespace Lines.Services.UsersService
{
    public interface IUsersService
    {
        Task<User> GetUserAsync(string userName);
    }
}
