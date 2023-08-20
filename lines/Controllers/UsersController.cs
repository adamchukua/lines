using AutoMapper;
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
        public async Task<ActionResult<List<UserWithPostsDTO>>> SearchUsers(string searchQuery)
        {
            var users = await _usersService.SearchUsersAsync(searchQuery);

            if (users == null)
            {
                return NotFound();
            }

            var userDtos = _mapper.Map<List<UserWithPostsDTO>>(users);
            return Ok(userDtos);
        }
    }
}
