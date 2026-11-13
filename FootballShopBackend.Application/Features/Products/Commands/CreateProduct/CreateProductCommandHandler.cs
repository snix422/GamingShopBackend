using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Application.Exceptions;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _asyncRepository;

        public CreateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var team = await _asyncRepository.GetByIdAsync(request.TeamId);
            if(team == null)
            {
                throw new NotFoundException($"Team with {request.TeamId} not found");
            };
            var validator = new CreateProductCommandValidator(_asyncRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if(validationResult.Errors.Count >0)
            {
                throw new ValidationException(validationResult);
            }

            var product = _mapper.Map<Product>(request);
            product = await _asyncRepository.AddAsync(product);
            return product.Id;
        }
    }
}
