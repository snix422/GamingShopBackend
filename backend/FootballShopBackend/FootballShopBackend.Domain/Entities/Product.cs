namespace FootballShopBackend.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid TeamId { get; set; }
    public Team Team { get; set; } 
    public string Size { get; set; } = string.Empty;
    public bool IsRecommended { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }
    public virtual ICollection<Product> RelatedProducts { get; set; } = new List<Product>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public string Slug => Name?.ToLower().Replace(" ", "-") ?? string.Empty;

}
