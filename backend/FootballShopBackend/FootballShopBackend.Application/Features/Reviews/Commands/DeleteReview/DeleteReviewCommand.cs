using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Commands.DeleteProduct
{
    public record DeleteReviewCommand(Guid ReviewId) : IRequest;
    
}
