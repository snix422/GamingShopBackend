using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
