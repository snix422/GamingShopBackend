using MediatR;

namespace FootballShopBackend.Application.Features.Products.Queries.GetProductDetail;

public record GetProductDetailQuery(Guid Id) : IRequest<ProductDetailVm>;
