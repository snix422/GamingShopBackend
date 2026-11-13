using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Commands.DeleteLeague
{
    public record DeleteLeagueCommand(Guid LeagueId) : IRequest;
    
}
