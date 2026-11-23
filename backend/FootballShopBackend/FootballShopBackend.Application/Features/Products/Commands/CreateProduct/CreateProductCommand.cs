using MediatR;

namespace FootballShopBackend.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid TeamId { get; set; }
    public bool IsRecommended { get; set; }
    public string Size { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Size: {Size}, ImageUrl: {ImageUrl}, Description: {Description}, Price: {Price}";
    }

}
