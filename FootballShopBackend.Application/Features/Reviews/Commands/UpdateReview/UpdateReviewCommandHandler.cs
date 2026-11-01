using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Reviews.Commands.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Review> _asyncRepository;

        public UpdateReviewCommandHandler(IMapper mapper, IAsyncRepository<Review> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var reviewToUpdate = await _asyncRepository.GetByIdAsync(request.ReviewId);
            _mapper.Map(request, reviewToUpdate, typeof(UpdateReviewCommand), typeof(Review));
            await _asyncRepository.UpdateAsync(reviewToUpdate);
        }
    }
}
