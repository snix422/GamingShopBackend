using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Commands.CreateLeague
{
    public class CreateLeagueCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
