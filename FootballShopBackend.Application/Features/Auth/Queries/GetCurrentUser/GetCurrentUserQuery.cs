using FootballShopBackend.Application.DTOs;
using MediatR;

namespace FootballShopBackend.Application.Features.Auth.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery : IRequest<UserDTO>;
    
}
