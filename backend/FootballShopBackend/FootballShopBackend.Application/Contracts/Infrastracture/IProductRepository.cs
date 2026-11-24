using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Contracts.Infrastracture
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductsByName(string name);
        Task<List<Product>> GetProductsByTeam(string teamName);
        Task<List<Product>> GetProductsByLeague(string leagueName);
        Task<List<Product>> GetBestsellers();
    }
}
