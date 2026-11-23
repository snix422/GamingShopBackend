using FootballShopBackend.Application.Contracts.Persistance;
using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Commands.DeleteProduct
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IAsyncRepository<Review> _asyncRepository;

        public DeleteReviewCommandHandler(IAsyncRepository<Review> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToDelete = await _asyncRepository.GetByIdAsync(request.ReviewId);
            await _asyncRepository.DeleteAsync(reviewToDelete);
        }
    }
}
