namespace FootballShopBackend.Application.Features.Products.Queries.GetCoursesList;

public class ProductListVm
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Size { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Double Price { get; set; }
}
