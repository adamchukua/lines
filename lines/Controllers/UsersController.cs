﻿using AutoMapper;
using Lines.DTOs;
using Lines.Services.UsersService;
using Microsoft.AspNetCore.Mvc;

namespace Lines.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UsersController(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<UserWithPostsRepostsLikesDTO>> GetUser(string userName)
        {
            var user = await _usersService.GetUserAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserWithPostsRepostsLikesDTO>(user);
            return Ok(userDto);
        }
    }
}
