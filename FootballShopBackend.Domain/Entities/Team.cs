namespace FootballShopBackend.Domain.Entities;

public class Team
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string LogoUrl { get; set; } = string.Empty;
    public Guid LeagueId { get; set; }
    public virtual League League { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    
}
