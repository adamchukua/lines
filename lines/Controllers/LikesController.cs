using AutoMapper;
using Lines.DTOs;
using Lines.Services.ILikesService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lines.Controllers
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

        [HttpGet]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetUserLikes(string userName)
        {
            var likes = await _likesService.GetUserLikesAsync(userName);
            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(likes);
            return Ok(postDtos);
        }
    }
}
