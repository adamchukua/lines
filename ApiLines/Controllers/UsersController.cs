using AutoMapper;
using Api.DTOs;
using Api.Services.UsersService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
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

        [HttpGet("{userName}")]
        public async Task<ActionResult<UserWithPostsDTO>> GetUser(string userName)
        {
            var user = await _usersService.GetUserAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = _mapper.Map<UserWithPostsDTO>(user);
            return Ok(userDto);
        }

        [HttpGet("Search/{searchQuery}")]
        public async Task<ActionResult<List<UserWithPostsDTO>>> SearchUsers(string searchQuery, int pageNumber = 1, int pageSize = 7)
        {
            var users = await _usersService.SearchUsersAsync(searchQuery, pageNumber, pageSize);

            if (users.IsNullOrEmpty())
            {
                return NotFound();
            }

            var userDtos = _mapper.Map<List<UserWithPostsDTO>>(users);
            return Ok(userDtos);
        }
    }
}
