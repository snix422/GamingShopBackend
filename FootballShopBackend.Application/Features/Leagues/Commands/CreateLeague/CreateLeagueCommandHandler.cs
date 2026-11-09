using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FootballShopBackend.Application.Features.Leagues.Commands.CreateLeague
{
    public class CreateLeagueCommandHandler : IRequestHandler<CreateLeagueCommand, Guid>
    {
        private readonly IAsyncRepository<League> _asyncRepository;
        private readonly IMapper _mapper;

        public CreateLeagueCommandHandler(IAsyncRepository<League> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateLeagueCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeagueCommandValidator();
            var validationResult = validator.Validate(request);

            if(validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var league = _mapper.Map<League>(request);

            var createdLeague = await _asyncRepository.AddAsync(league);

            return createdLeague.Id;
        }
    }
}
