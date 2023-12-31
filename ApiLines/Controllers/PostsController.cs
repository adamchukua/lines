﻿using AutoMapper;
using Api.DTOs;
using Api.Entities;
using Api.Services.PostsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IdentityServer4.Extensions;

namespace Api.Controllers
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

        [HttpGet("user/{userName}/replies")]
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

        [HttpGet("{postId}/replies")]
        public async Task<ActionResult<List<PostBasicInfoDTO>>> GetPostReplies(long postId)
        {
            var replies = await _postsService.GetPostRepliesAsync(postId);

            if (replies.IsNullOrEmpty())
            {
                return new List<PostBasicInfoDTO>();
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

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<PostBasicInfoDTO>> AddPost(AddPostDTO post)
        {
            var addedPost = await _postsService.AddPostAsync(post);
            var addedPostDto = _mapper.Map<PostBasicInfoDTO>(addedPost);

            return Ok(addedPostDto);
        }
    }
}
