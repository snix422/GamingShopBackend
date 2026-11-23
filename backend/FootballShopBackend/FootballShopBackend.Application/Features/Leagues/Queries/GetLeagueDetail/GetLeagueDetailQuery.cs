using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail
{
    public record GetLeagueDetailQuery(Guid LeagueId) : IRequest<LeagueDetailVm>;
   
}
