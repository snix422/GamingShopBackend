using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;
using System.Runtime.CompilerServices;

namespace FootballShopBackend.Application.Features.Teams.Queries.GetTeamsList
{
    public class GetTeamsListQueryHandler : IRequestHandler<GetTeamsListQuery, List<TeamListVm>>
    {
        private readonly IAsyncRepository<Team> _asyncRepository;
        private readonly IMapper _mapper;

        public GetTeamsListQueryHandler(IAsyncRepository<Team> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<List<TeamListVm>> Handle(GetTeamsListQuery request, CancellationToken cancellationToken)
        {
            var teams = (await _asyncRepository.ListAllAsync()).OrderBy(t => t.Name);

            return _mapper.Map<List<TeamListVm>>(teams);
        }
    }
}
