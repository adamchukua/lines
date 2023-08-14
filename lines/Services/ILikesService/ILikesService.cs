using Lines.Entities;

namespace Lines.Services.ILikesService
{
    public interface ILikesService
    {
        Task<List<Like>> GetUserLikesAsync(string userName);
    }
}
