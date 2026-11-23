using FootballShopBackend.Application.DTOs;
using MediatR;

namespace FootballShopBackend.Application.Features.Auth.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>;
    
}
