namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail
{
    public class LeagueDetailVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
