using FootballShopBackend.Application.Common;
using FootballShopBackend.Application.DTOs;
using FootballShopBackend.Application.Features.Auth.Commands.Login;
using FootballShopBackend.Application.Features.Auth.Commands.Register;

namespace FootballShopBackend.Application.Contracts.Infrastracture
{
    public interface IAuthService
    {
        Task<Result<string>> RegisterAsync(RegisterUserVM dto);
        Task<Result<string>> LoginAsync(LoginUserVM dto);
    }
}
