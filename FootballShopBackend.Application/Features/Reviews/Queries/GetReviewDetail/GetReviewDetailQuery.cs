using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail;

public record GetReviewDetailQuery(Guid ReviewId) : IRequest<ReviewDetailVm>;

