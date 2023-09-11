using Api.Entities;

namespace Api.Services.ILikesService
{
    public interface ILikesService
    {
        Task<List<Like>> GetUserLikesAsync(string userName);
    }
}
