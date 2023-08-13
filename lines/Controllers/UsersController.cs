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

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDetailedInfoDTO>> GetUser(string userName)
        {
            var user = await _usersService.GetUserAsync(userName);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
