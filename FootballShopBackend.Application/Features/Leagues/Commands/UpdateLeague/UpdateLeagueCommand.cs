namespace FootballShopBackend.Application.Features.Leagues.Commands.UpdateLeague
{
    public class UpdateLeagueCommand 
    {
        public Guid LeagueId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
