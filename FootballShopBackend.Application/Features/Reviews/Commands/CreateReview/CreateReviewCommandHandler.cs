using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballShopBackend.Application.Features.Reviews.Commands.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Review> _reviewRepository;
        private readonly IAsyncRepository<Product> _productRepository;

        private readonly IAsyncRepository<Author> _authorRepository;

        public CreateReviewCommandHandler(IMapper mapper, IAsyncRepository<Review> asyncRepository, IAsyncRepository<Product> productRepository, IAsyncRepository<Author> authorRepository)
        {
            _mapper = mapper;
            _reviewRepository = asyncRepository;
            _productRepository = productRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReviewCommandValidator();
            var validationResult = validator.Validate(request);

            if(validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var author = await _authorRepository.GetByIdAsync(request.AuthorId);

            if (author == null)
            {
                throw new ValidationException($"Author with id {request.AuthorId} does not exist.");
            }

            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
            {
                throw new ValidationException($"Product with id {request.ProductId} does not exist.");
            }

            var review = _mapper.Map<Review>(request);

            var createdReview = await _reviewRepository.AddAsync(review);
            return createdReview.Id;
        }
    }
}
