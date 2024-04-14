using AutoMapper;
using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById;
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
            // ChainBlockify API
            CreateMap<Blockchain, GetBlockchainListDto>();
            CreateMap<Blockchain, GetBlockchainByIdDto>();
            // Blockcypher API
            //CreateMap<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>()
            //
            CreateMap<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>()
            .Include<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>();

            CreateMap<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .IncludeBase<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>();

            CreateMap<BaseBlockchainInfoBlockcypherDto, BaseBlockchainInfo>()
            .Include<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>();

            CreateMap<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>()
                // Map other properties as needed
                .IncludeBase<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>();
        }
    }
}
