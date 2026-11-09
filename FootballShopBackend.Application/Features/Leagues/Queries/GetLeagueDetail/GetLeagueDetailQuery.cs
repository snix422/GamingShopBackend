using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail
{
    public class GetLeagueDetailQuery : IRequest<LeagueDetailVm>
    {
        public int LeagueId { get; set; }
    }
}
