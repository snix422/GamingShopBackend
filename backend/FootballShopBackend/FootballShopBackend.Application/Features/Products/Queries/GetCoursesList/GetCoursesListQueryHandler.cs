using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Products.Queries.GetCoursesList
{
    public class GetCoursesListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductListVm>>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Product> _asyncRepository;

        public GetCoursesListQueryHandler(IMapper mapper, IAsyncRepository<Product> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<List<ProductListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var allProducts = (await _asyncRepository.ListAllAsync()).OrderBy(p => p.Name);
            return _mapper.Map<List<ProductListVm>>(allProducts);
        }
    }
}
