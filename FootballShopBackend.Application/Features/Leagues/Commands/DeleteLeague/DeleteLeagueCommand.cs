using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Commands.DeleteLeague
{
    public class DeleteLeagueCommand : IRequest
    {
        public Guid LeagueId { get; set; }
    }
}
