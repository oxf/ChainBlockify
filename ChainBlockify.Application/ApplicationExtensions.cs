using AutoMapper;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }

    class MappingProfile: Profile
    {
        public MappingProfile() {
            Blockchain();
        }

        public void Blockchain()
        {
            CreateMap<Blockchain, GetBlockchainListDto>();
        }
    }
}
