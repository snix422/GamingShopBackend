namespace FootballShopBackend.Application.Contracts.Infrastracture;

public interface ICurrentUserService
{
    string? UserId { get; }
    string? UserRole { get; }
    string UserEmail { get; }
}
