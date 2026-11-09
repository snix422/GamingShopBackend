using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeaguesList
{
    public class GetLeaguesListQueryHandler : IRequestHandler<GetLeaguesListQuery, List<LeagueVm>>
    {

        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LeagueVm> _asyncRepository;

        public GetLeaguesListQueryHandler(IMapper mapper, IAsyncRepository<LeagueVm> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<List<LeagueVm>> Handle(GetLeaguesListQuery request, CancellationToken cancellationToken)
        {
            var leagues = (await _asyncRepository.ListAllAsync()).OrderBy(l => l.Name);

            return _mapper.Map<List<LeagueVm>>(leagues);
        }
    }
}
