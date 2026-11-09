using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using MediatR;

namespace FootballShopBackend.Application.Features.Teams.Commands.DeleteTeam
{
    public class DeleteCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly IAsyncRepository<Team> _asyncRepository;

        public DeleteCommandHandler(IAsyncRepository<Team> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var teamToDelete = await _asyncRepository.GetByIdAsync(request.Id);

            await _asyncRepository.DeleteAsync(teamToDelete);

        }
    }
}
