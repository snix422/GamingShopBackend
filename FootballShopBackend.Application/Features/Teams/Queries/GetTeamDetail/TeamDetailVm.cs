namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail
{
    public class TeamDetailVm
    {
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public Guid LeagueId { get; set; }

    }
}
