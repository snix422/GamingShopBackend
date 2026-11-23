using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.DeleteTeam
{
    public record DeleteTeamCommand(Guid Id) : IRequest;
}
