using MediatR;

namespace FootballShopBackend.Application.Features.Review.Queries.GetReviewsList
{
    public class GetReviewsListQuery : IRequest<List<ReviewListVm>>
    {
    }
}
