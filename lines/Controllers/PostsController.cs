using AutoMapper;
using Lines.DTOs;
using Lines.Entities;
using Lines.Services.PostsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

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
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetAllPosts(int pageNumber = 1, int pageSize = 10)
        {
            var posts = await _postsService.GetAllPostsAsync(pageNumber, pageSize);

            if (posts.IsNullOrEmpty())
            {
                return NotFound();
            }

            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(posts);
            return Ok(postDtos);
        }

        [HttpGet("GetUserReplies/{userName}")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetUserReplies(string userName)
        {
            var replies = await _postsService.GetUserRepliesAsync(userName);

            if (replies.IsNullOrEmpty())
            {
                return NotFound();
            }

            var replyDtos = _mapper.Map<List<PostBasicInfoDTO>>(replies);
            return Ok(replyDtos);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetPost(long postId)
        {
            var post = await _postsService.GetPostAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            var postDto = _mapper.Map<PostBasicInfoDTO>(post);
            return Ok(postDto);
        }

        [HttpGet("GetPostReplies/{postId}")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetPostReplies(long postId)
        {
            var replies = await _postsService.GetPostRepliesAsync(postId);

            if (replies.IsNullOrEmpty())
            {
                return NotFound();
            }

            var replyDtos = _mapper.Map<List<PostBasicInfoDTO>>(replies);
            return Ok(replyDtos);
        }

        [HttpGet("Search/{searchQuery}")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> SearchPosts(string searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            var posts = await _postsService.SearchPostsAsync(searchQuery, pageNumber, pageSize);

            if (posts.IsNullOrEmpty())
            {
                return NotFound();
            }

            var postDtos = _mapper.Map<List<PostBasicInfoDTO>>(posts);
            return Ok(postDtos);
        }
    }
}
