using Lines.Entities;

namespace Lines.Services.UsersService
{
    public interface IUsersService
    {
        Task<User> GetUserAsync(string userName);
        Task<List<User>> SearchUsersAsync(string searchQuery, int count);
    }
}
