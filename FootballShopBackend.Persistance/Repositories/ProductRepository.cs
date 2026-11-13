using FootballShopBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Persistance.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        private readonly FootballShopDbContext _dbContext;

        public ProductRepository(FootballShopDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsByName(string name)
        {
            var query = _dbContext.Products.AsQueryable();

            if(!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.ToLower().Contains(name.ToLower()));
            }

            return await query
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsByTeam(string teamName)
        {
            var query = _dbContext.Products.Include(p => p.Team).AsQueryable();

            if(!string.IsNullOrWhiteSpace(teamName))
            {
                query = query.Where(p => p.Team.Name.ToLower().Contains(teamName.ToLower()));
            }

            return await query
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
    
}
