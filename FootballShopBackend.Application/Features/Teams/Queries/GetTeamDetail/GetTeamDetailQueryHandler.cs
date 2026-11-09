using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamDetail
{
    public class GetTeamDetailQueryHandler : IRequestHandler<GetTeamDetailQuery, TeamDetailVm>
    {
        private readonly IAsyncRepository<Team> _asyncRepository;
        private readonly IMapper _mapper;

        public GetTeamDetailQueryHandler(IAsyncRepository<Team> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<TeamDetailVm> Handle(GetTeamDetailQuery request, CancellationToken cancellationToken)
        {
            var team = await _asyncRepository.GetByIdAsync(request.TeamId);

            return _mapper.Map<TeamDetailVm>(team);
        }
    }
}
