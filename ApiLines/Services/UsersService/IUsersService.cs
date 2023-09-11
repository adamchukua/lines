using Api.Entities;

namespace Api.Services.UsersService
{
    public interface IUsersService
    {
        Task<User> GetUserAsync(string userName);
        Task<List<User>> SearchUsersAsync(string searchQuery, int pageNumber, int pageSize);
    }
}
