using FootballShopBackend.Domain.Entities;

namespace FootballShopBackend.Application.Contracts.Persistance
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
