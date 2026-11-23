using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail
{
    public record GetTeamDetailQuery(Guid TeamId) : IRequest<TeamDetailVm>;
    
}
