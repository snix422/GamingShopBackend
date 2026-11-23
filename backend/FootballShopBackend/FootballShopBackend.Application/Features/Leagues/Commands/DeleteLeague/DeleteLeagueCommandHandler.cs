using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Leagues.Commands.DeleteLeague
{
    public class DeleteLeagueCommandHandler : IRequestHandler<DeleteLeagueCommand>
    {
        private readonly IAsyncRepository<League> _asyncRepository;
        public DeleteLeagueCommandHandler(IAsyncRepository<League> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(DeleteLeagueCommand request, CancellationToken cancellationToken)
        {
            var leagueToDelete = await _asyncRepository.GetByIdAsync(request.LeagueId);

            await _asyncRepository.DeleteAsync(leagueToDelete);
        }
    }
}
