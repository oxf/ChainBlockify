using AutoMapper;
using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo;
using ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId;
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
            services.AddTransient<IRequestHandler<GetBlockchainInfoListByBlockchainIdQuery<BlockchainInfoBtc>, IEnumerable<BlockchainInfoBtc>>, GetBlockchainInfoListByBlockchainIdQueryHandler<BlockchainInfoBtc>>();
            services.AddTransient<IRequestHandler<GetBlockchainInfoListByBlockchainIdQuery<BlockchainInfoEth>, IEnumerable<BlockchainInfoEth>>, GetBlockchainInfoListByBlockchainIdQueryHandler<BlockchainInfoEth>>();
            services.AddTransient<IRequestHandler<GetBlockchainInfoListByBlockchainIdQuery<BlockchainInfoDash>, IEnumerable<BlockchainInfoDash>>, GetBlockchainInfoListByBlockchainIdQueryHandler<BlockchainInfoDash>>();
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }

    class MappingProfile : Profile
    {
        private const string BASE_URL = "https://localhost:7173/blockchain";
        public MappingProfile()
        {
            Blockchain();
        }

        public void Blockchain()
        {
            // ChainBlockify API
            CreateMap<Blockchain, GetBlockchainListDto>()
            .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => GenerateKeyValuePairs(src.Id)));
            CreateMap<Blockchain, GetBlockchainByIdDto>()
            .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => GenerateKeyValuePairs(src.Id)));
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

        private List<KeyValuePair<string, string>> GenerateKeyValuePairs(int id)
        {
            var keyValuePairs = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("Get Info From DB", $"{BASE_URL}/{id}/info"),
                new KeyValuePair<string, string>("Fetch Info From API", $"{BASE_URL}/{id}/fetch")
            };
            return keyValuePairs;
        }
    }
}
