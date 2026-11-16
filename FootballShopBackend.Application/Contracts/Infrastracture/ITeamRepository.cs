using FootballShopBackend.Application.Contracts.Persistance;
using FootballShopBackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Contracts.Infrastracture
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeamsByName(string name);
        Task<List<Team>> GetTeamsByLeague(string league);
        Task<List<Team>> GetTeamsByCountry(string country);
    }
}
