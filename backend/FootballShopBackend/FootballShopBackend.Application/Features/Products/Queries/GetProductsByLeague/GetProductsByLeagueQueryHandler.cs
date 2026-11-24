using AutoMapper;
using FootballShopBackend.Application.Contracts.Infrastracture;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Queries.GetProductsByLeague
{
    public class GetProductsByLeagueQueryHandler : IRequestHandler<GetProductsByLeagueQuery, List<ProductVm>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductsByLeagueQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductVm>> Handle(GetProductsByLeagueQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByLeague(request.leagueName);

            return _mapper.Map<List<ProductVm>>(products);
        }
    }
}
