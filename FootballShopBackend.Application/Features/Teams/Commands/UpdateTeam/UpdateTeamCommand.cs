using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public Guid LeagueId { get; set; }

    }
}
