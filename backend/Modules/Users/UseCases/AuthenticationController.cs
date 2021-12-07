using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using way.Modules.Users.Dtos;
using way.Modules.Users.Repositories;
using way.Utils;

namespace way.Modules.Users.UseCases
{
    [ApiController]
    [Route("users")]
    public class AuthenticationController : ControllerBase
    {
        private readonly AuthenticationService _service;

        public AuthenticationController(IUsersRepository repository)
        {
            _service = new AuthenticationService(repository);
        }

        [HttpPost]
        [Route("login")]

        public async Task<ActionResult> AuthenticateUserAsync(LoginUserDto userDto)
        {
            try
            {
                var token = await _service.GetUserByEmailAsync(userDto.Email, userDto.Password);
                var user = TokenService.GetUserRole(token);
                
                return StatusCode(200, token);
            } catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }
}
