using Api.DTOs;
using Api.Entities;

namespace Api.Services.ILikesService
{
    public interface ILikesService
    {
        Task<List<Like>> GetUserLikesAsync(string userName);
        Task<bool> AddLikeAsync(AddLikeDTO like);
        Task<bool> DeleteLikeAsync(DeleteLikeDTO like);
        Task<bool> CheckIsLikedByUserAsync(CheckLikeDTO like);
    }
}
