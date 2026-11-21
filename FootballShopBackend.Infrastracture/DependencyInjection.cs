using FootballShopBackend.Application.Contracts.Infrastracture;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballShopBackend.Infrastracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthService, IAuthService>();

            return services;
        }

    }
}
