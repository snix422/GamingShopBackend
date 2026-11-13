using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _asyncRepository;

        public UpdateProductCommandHandler(IMapper mapper, IAsyncRepository<Product> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var courseToUpdate = await _asyncRepository.GetByIdAsync(request.ProductId);
            _mapper.Map(request, courseToUpdate, typeof(UpdateProductCommand), typeof(Product));
            await _asyncRepository.UpdateAsync(courseToUpdate);
        }
    }
}
