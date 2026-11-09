using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamsList
{
    public class GetTeamsListQuery : IRequest<List<TeamListVm>>
    {
    }
}
