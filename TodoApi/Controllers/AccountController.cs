using Microsoft.AspNetCore.Mvc;
using TodoApi.Aplication.Services;
using TodoApi.Domain.Dtos;
using TodoApi.Domain.Entities;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AccountController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        [Consumes("application/json")]
        public async Task<ActionResult> Register([FromBody] RegisterFormDto registerDto)
        {
            bool userAlreadyExists = _usersService.CheckIfUserAlreadyExists(registerDto.Name);
            
            if (!ModelState.IsValid){ return BadRequest(); }

            if (userAlreadyExists){ return Conflict(); }

            await _usersService.RegisterAsync(registerDto.Name, registerDto.Password);
            return Ok();
        }

        [HttpPost("login")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginFormDto userLoginData)
        {
            bool userAlreadyExists = _usersService.CheckIfUserAlreadyExists(userLoginData.Name);

            if (!userAlreadyExists){ return Unauthorized("Invalid user name"); }


            var LoggedInUser = await _usersService.LoginAsync(userLoginData);

            if (LoggedInUser == null) { return Unauthorized("invalid pasword"); }

            
            var token = _usersService.GenerateJwt(LoggedInUser);

            var userDto = new UserDto
            {
                Name = LoggedInUser.Name,
                Token = token,
            };
            return Ok(userDto);
        }
    }
}
