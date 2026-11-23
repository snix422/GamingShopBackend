using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Commands.UpdateLeague;

public class UpdateLeagueCommandHandler : IRequestHandler<UpdateLeagueCommand>
{
    private readonly IAsyncRepository<League> _asyncRepository;
    private readonly IMapper _mapper;

    public UpdateLeagueCommandHandler(IAsyncRepository<League> asyncRepository, IMapper mapper)
    {
        _asyncRepository = asyncRepository;
        _mapper = mapper;
    }
    public async Task Handle(UpdateLeagueCommand request, CancellationToken cancellationToken)
    {
        var leagueToUpdate = await _asyncRepository.GetByIdAsync(request.LeagueId);
        _mapper.Map(request, leagueToUpdate, typeof(UpdateLeagueCommand), typeof(League));
        await _asyncRepository.UpdateAsync(leagueToUpdate);
    }
}
