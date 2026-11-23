using MediatR;

namespace FootballShopBackend.Application.Features.Products.Queries.GetCoursesList
{
    public class GetProductsListQuery : IRequest<List<ProductListVm>>
    {
    }
}
