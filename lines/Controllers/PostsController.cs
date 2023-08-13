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

        public PostsController(IPostsService postsService)
        {
            _postsService = postsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetAllPosts()
        {
            var posts = await _postsService.GetAllPostsAsync();
            return Ok(posts);
        }
    }
}
