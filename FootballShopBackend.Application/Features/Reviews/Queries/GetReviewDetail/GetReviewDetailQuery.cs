using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail;

public class GetReviewDetailQuery : IRequest<ReviewDetailVm>
{
    public Guid ReviewId { get; set; }
}
