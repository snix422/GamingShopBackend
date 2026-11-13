namespace FootballShopBackend.Application.DTOs;

public class ProductDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Size { get; set; }

    public string ImageUrl { get; set; }
    public string TeamName { get; set; } = string.Empty;
}
