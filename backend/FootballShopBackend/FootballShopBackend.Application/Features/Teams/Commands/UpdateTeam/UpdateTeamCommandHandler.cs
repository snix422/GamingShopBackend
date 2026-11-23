using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly IAsyncRepository<Team> _asyncRepository;
        private readonly IMapper _mapper;

        public UpdateTeamCommandHandler(IAsyncRepository<Team> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var teamToUpdate = await _asyncRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, teamToUpdate, typeof(UpdateTeamCommand), typeof(Team));
            await _asyncRepository.UpdateAsync(teamToUpdate);
        }
    }
}
