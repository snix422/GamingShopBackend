using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewDetail
{
    public class GetReviewDetailQueryHandler : IRequestHandler<GetReviewDetailQuery, ReviewDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Review> _asyncRepository;

        public GetReviewDetailQueryHandler(IMapper mapper, IAsyncRepository<Review> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<ReviewDetailVm> Handle(GetReviewDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _asyncRepository.GetByIdAsync(request.ReviewId);
            var productDetailDto = _mapper.Map<ReviewDetailVm>(product);
            return productDetailDto;
        }
    }
}
