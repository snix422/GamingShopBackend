using FootballShopBackend.Application.Features.Auth.Commands.Login;
using FootballShopBackend.Application.Features.Auth.Commands.Register;
using FootballShopBackend.Application.Features.Auth.Queries.GetAllUsers;
using FootballShopBackend.Application.Features.Auth.Queries.GetCurrentUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace FootballShopBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _env;

        public AuthController(IMediator mediator, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _env = env;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _mediator.Send(new GetCurrentUserQuery());

            return Ok(user);
        }

        [HttpGet("users")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand request)
        {
            var userId = await _mediator.Send(request);

            if(!userId.IsSuccess)
            {
                return BadRequest(new { message = userId.Error});
            }

            return Ok(userId);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand request)
        {
            var result = await _mediator.Send(request);

            if(!result.IsSuccess)
            {
                return BadRequest(new { message = result.Error });
            }

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = _env.IsDevelopment() ? SameSiteMode.None : SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            };

            Response.Cookies.Append("AuthToken", result.Data, cookieOptions);

            return Ok(new {message = "Zalogowano pomyślnie"});
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("AuthToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = _env.IsDevelopment() ? SameSiteMode.None : SameSiteMode.Strict,

            });
            return Ok(new { message = "Wylogowano pomyślnie" });
        }
    }
}
