using FootballShopBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Persistance.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        private readonly FootballShopDbContext _dbContext;
        public TeamRepository(FootballShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Team>> GetTeamsByName(string name)
        {
            var query = _dbContext.Teams.AsQueryable();
            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(t => t.Name.ToLower().Contains(name.ToLower()));
            }
            return await query
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<List<Team>> GetTeamsByLeague(string league)
        {
            var query = _dbContext.Teams.Include(t => t.League).AsQueryable();
            if (!string.IsNullOrWhiteSpace(league))
            {
                query = query.Where(t => t.League.Name.ToLower().Contains(league.ToLower()));
            }
            return await query
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

        public async Task<List<Team>> GetTeamsByCountry(string country)
        {
            var query = _dbContext.Teams.AsQueryable();
            if (!string.IsNullOrWhiteSpace(country))
            {
                query = query.Where(t => t.Country.ToLower().Contains(country.ToLower()));
            }
            return await query
                .OrderBy(t => t.Name)
                .ToListAsync();
        }

    }
}
