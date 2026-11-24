using AutoMapper;
using FootballShopBackend.Application.Contracts.Infrastracture;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Queries.GetBestsellers
{
    public class GetBestsellersQueryHandler : IRequestHandler<GetBestsellersQuery, List<BestsellerVm>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetBestsellersQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<BestsellerVm>> Handle(GetBestsellersQuery request, CancellationToken cancellationToken)
        {
            var bestsellers = (await _productRepository.GetBestsellers()).OrderBy(b => b.Name);

            return _mapper.Map<List<BestsellerVm>>(bestsellers);
        }
    }
}
