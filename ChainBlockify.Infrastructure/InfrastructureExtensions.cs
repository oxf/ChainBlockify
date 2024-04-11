using ChainBlockify.Application.Interfaces;
using ChainBlockify.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services)
        {
            services.AddTransient<IBlockchainInfoProvider, UrlBlockchainInfoProvider>();
            return services;
        }
    }
}
