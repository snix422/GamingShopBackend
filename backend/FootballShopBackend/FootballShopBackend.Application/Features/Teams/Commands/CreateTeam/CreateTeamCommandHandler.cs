using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.CreateTeam
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, Guid>
    {

        private readonly IAsyncRepository<Team> _asyncRepository;
        private readonly IMapper _mapper;

        public CreateTeamCommandHandler(IAsyncRepository<Team> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTeamCommandValidator();
            
            var validationResult = validator.Validate(request);

            if(validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }

            var team = _mapper.Map<Team>(request);

            team = await _asyncRepository.AddAsync(team);

            return team.Id;
        }
    
    

    }
}
