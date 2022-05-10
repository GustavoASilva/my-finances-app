using Microsoft.AspNetCore.Mvc;
using MyFinances.Blazor.Shared.User;
using MyFinances.Core.Aggregates;
using MyFinances.Core.Aggregates.Specifications;
using MyFinances.Core.Interfaces;
using MyFinances.Infra.Services;

namespace MyFinances.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;

        public UsersController(IRepository<User> userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<IActionResult> Token(GenerateTokenRequest generateTokenRequest)
        {
            FindByLoginAndPasswordSpec spec = new (generateTokenRequest.Username, generateTokenRequest.Password);
            var user = await _userRepository.GetBySpecAsync(spec);
            
            if (user == null)
                return BadRequest();

            var token = _tokenService.GenerateToken(user);

            var generateTokenResponse = new GenerateTokenResponse()
            {
                AccessToken = token.AccessToken,
                ExpiresIn = token.ExpiresIn
            };

            return Ok(generateTokenResponse);
        }
    }
}
