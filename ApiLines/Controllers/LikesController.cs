using AutoMapper;
using Api.DTOs;
using Api.Services.ILikesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : ControllerBase
    {
        private readonly ILikesService _likesService;
        private readonly IMapper _mapper;

        public LikesController(ILikesService likesService, IMapper mapper)
        {
            _likesService = likesService;
            _mapper = mapper;
        }

        [HttpGet("{userName}")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetUserLikes(string userName)
        {
            var likes = await _likesService.GetUserLikesAsync(userName);

            if (likes.IsNullOrEmpty())
            {
                return NotFound();
            }

            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(likes);
            return Ok(postDtos);
        }
    }
}
