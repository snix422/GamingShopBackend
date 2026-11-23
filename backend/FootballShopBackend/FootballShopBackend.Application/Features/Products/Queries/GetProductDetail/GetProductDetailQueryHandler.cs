using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Products.Queries.GetProductDetail
{
    public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _asyncRepository;

        public GetProductDetailQueryHandler(IMapper mapper, IAsyncRepository<Product> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }
        public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
        {
            var product = await _asyncRepository.GetByIdAsync(request.Id);
            
            var productDeatailDto = _mapper.Map<ProductDetailVm>(product);

            return productDeatailDto;
        }
    }
}
