using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Application.Features.Products.Queries.GetProductsByLeague
{
    public class ProductVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Size { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string TeamName { get; set; } = string.Empty;

        public Double Price { get; set; }
    }
}
