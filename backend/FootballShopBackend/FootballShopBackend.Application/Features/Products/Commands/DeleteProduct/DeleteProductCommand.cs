using MediatR;

namespace FootballShopBackend.Application.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : IRequest;
    
}
