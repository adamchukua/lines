using AutoMapper;
using Lines.DTOs;
using Lines.Entities;
using Lines.Services.PostsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostsService _postsService;
        private readonly IMapper _mapper;

        public PostsController(IPostsService postsService, IMapper mapper)
        {
            _postsService = postsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetAllPosts()
        {
            var posts = await _postsService.GetAllPostsAsync();
            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(posts);
            return Ok(postDtos);
        }

        [HttpGet("GetUserReplies")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetUserReplies(string userName)
        {
            var replies = await _postsService.GetUserRepliesAsync(userName);
            var replyDtos = _mapper.Map<List<PostBasicInfoDTO>>(replies);
            return Ok(replyDtos);
        }
    }
}
