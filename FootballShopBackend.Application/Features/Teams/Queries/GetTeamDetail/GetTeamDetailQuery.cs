using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail
{
    public class GetTeamDetailQuery : IRequest<TeamDetailVm>
    {
        public Guid TeamId { get; set; }
    }
}
