using FootballShopBackend.Application.Common;
using MediatR;

namespace FootballShopBackend.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<Result<string>>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
