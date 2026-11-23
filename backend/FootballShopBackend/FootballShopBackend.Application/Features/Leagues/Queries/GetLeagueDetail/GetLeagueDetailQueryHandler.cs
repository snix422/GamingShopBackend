using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Queries.GetLeagueDetail
{
    public class GetLeagueDetailQueryHandler : IRequestHandler<GetLeagueDetailQuery, LeagueDetailVm>
    {
        private readonly IAsyncRepository<League> _asyncRepository;
        private readonly IMapper _mapper;

        public GetLeagueDetailQueryHandler(IAsyncRepository<League> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<LeagueDetailVm> Handle(GetLeagueDetailQuery request, CancellationToken cancellationToken)
        {
            var leagueDetail = await _asyncRepository.GetByIdAsync(request.LeagueId);

            return _mapper.Map<LeagueDetailVm>(leagueDetail);
        }
    }
}
