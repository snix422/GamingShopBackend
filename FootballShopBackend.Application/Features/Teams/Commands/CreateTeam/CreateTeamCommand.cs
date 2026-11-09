using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.CreateTeam
{
    public class CreateTeamCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public Guid LeagueId { get; set; }
    }
}
