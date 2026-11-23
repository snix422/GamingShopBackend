using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Application.Features.Review.Queries.GetReviewsList;
using MediatR;

namespace FootballShopBackend.Application.Features.Reviews.Queries.GetReviewsList
{
    public class GetReviewsListQueryHandler : IRequestHandler<GetReviewsListQuery, List<ReviewListVm>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Review> _asyncRepository;

        public GetReviewsListQueryHandler(IMapper mapper, IAsyncRepository<Review> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<List<ReviewListVm>> Handle(GetReviewsListQuery request, CancellationToken cancellationToken)
        {
            var reviews = (await _asyncRepository.ListAllAsync()).OrderBy(r => r.PublishDate).ToList();

            return _mapper.Map<List<ReviewListVm>>(reviews);
        }
    }
}
