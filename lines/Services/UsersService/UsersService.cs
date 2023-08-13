using AutoMapper;
using Lines.DTOs;
using Lines.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Lines.Services.UsersService
{
    public class UsersService : IUsersService
    {
        private readonly LinesDbContext _dbContext;
        private readonly IMapper _mapper;

        public UsersService(LinesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserDetailedInfoDTO> GetUserAsync(string userName)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserDetailedInfoDTO>(user);
            return userDto;
        }
    }
}
