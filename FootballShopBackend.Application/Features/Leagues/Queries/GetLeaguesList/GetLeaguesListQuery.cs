using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeaguesList
{
    public class GetLeaguesListQuery : IRequest<List<LeagueVm>>
    {
    }
}
