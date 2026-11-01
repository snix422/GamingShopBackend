using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Commands.DeleteProduct
{
    public class DeleteReviewCommand : IRequest
    {
        public Guid ReviewId { get; set; }
    
    }
}
