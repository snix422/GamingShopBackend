using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Queries.GetBestsellers
{
    public class GetBestsellersQuery : IRequest<List<BestsellerVm>>
    {

    }
}
