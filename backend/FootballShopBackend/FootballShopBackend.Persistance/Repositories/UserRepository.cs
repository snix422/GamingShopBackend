using AutoMapper;
using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;


namespace FootballShopBackend.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FootballShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepository(FootballShopDbContext dbContext, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var appUsers = await _userManager.Users.ToListAsync(cancellationToken);
            var users = new List<User>();

            foreach (var appUser in appUsers)
            {
                var roles = await _userManager.GetRolesAsync(appUser.Id);
                var role = roles.FirstOrDefault() ?? "User";
                users.Add(new User
                {
                    Id = appUser.Id,
                    Email = appUser.Email ?? string.Empty,
                    FirstName = appUser.FirstName ?? string.Empty,
                    RoleName = role
                });
            }

            return users;
        }

        public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var appUser = await _userManager.FindByIdAsync(id);

            if (appUser == null) return null;

            var roles = await _userManager.GetRolesAsync(appUser.Id);

            var role = roles.FirstOrDefault() ?? "User";

            return new User
            {
                Id = appUser.Id,
                Email = appUser.Email ?? string.Empty,
                FirstName = appUser.FirstName ?? string.Empty,
                RoleName = role
            };
        }
    }
}
