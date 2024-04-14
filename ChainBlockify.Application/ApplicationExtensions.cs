using AutoMapper;
using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using MediatR;
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
            services.AddTransient<IRequestHandler<FetchBlockchainInfoCommand<BlockchainInfoBtcBlockcypherDto>, BaseBlockchainInfo>, FetchBlockchainInfoCommandHandler<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>>();
            services.AddTransient<IRequestHandler<FetchBlockchainInfoCommand<BlockchainInfoEthBlockcypherDto>, BaseBlockchainInfo>, FetchBlockchainInfoCommandHandler<BlockchainInfoEthBlockcypherDto, BlockchainInfoEth>>();
            services.AddTransient<IRequestHandler<FetchBlockchainInfoCommand<BlockchainInfoDashBlockcypherDto>, BaseBlockchainInfo>, FetchBlockchainInfoCommandHandler<BlockchainInfoDashBlockcypherDto, BlockchainInfoDash>>();
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
            CreateMap<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>();
            CreateMap<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>()
                .IncludeBase<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>();
            CreateMap<BaseBlockchainInfoBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>();
            CreateMap<BlockchainInfoBtcBlockcypherDto, BlockchainInfoBtc>()
                .IncludeBase<BlockchainInfoBtcBlockcypherDto, BaseBlockchainInfo>();
            // ETH
            CreateMap<BlockchainInfoEthBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoEthBlockcypherDto, BlockchainInfoEth>();
            CreateMap<BlockchainInfoEthBlockcypherDto, BlockchainInfoEth>()
                .IncludeBase<BlockchainInfoEthBlockcypherDto, BaseBlockchainInfo>();
            CreateMap<BaseBlockchainInfoBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoEthBlockcypherDto, BlockchainInfoEth>();
            CreateMap<BlockchainInfoEthBlockcypherDto, BlockchainInfoEth>()
                .IncludeBase<BlockchainInfoEthBlockcypherDto, BaseBlockchainInfo>();
            // DASH
            CreateMap<BlockchainInfoDashBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoDashBlockcypherDto, BlockchainInfoDash>();
            CreateMap<BlockchainInfoDashBlockcypherDto, BlockchainInfoDash>()
                .IncludeBase<BlockchainInfoDashBlockcypherDto, BaseBlockchainInfo>();
            CreateMap<BaseBlockchainInfoBlockcypherDto, BaseBlockchainInfo>()
                .Include<BlockchainInfoDashBlockcypherDto, BlockchainInfoDash>();
            CreateMap<BlockchainInfoDashBlockcypherDto, BlockchainInfoDash>()
                .IncludeBase<BlockchainInfoDashBlockcypherDto, BaseBlockchainInfo>();
        }
    }
}
