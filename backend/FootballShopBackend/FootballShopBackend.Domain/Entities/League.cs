namespace FootballShopBackend.Domain.Entities;

public class League
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

}
