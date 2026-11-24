using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Queries.GetProductsByLeague
{
    public record GetProductsByLeagueQuery(string leagueName) : IRequest<List<ProductVm>>;
   
}
