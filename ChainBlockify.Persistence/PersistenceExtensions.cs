﻿using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Persistence
{
    public static class PersistenceExtensions
    {
        public static void ConfigurePersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            services.AddTransient<IRepository<Blockchain>, BlockchainRepository>();
            services.AddTransient<IRepository<BlockchainInfoBtc>, BlockchainInfoBtcRepository>();
            services.AddTransient<IRepository<BlockchainInfoEth>, BlockchainInfoEthRepository>();
            services.AddTransient<IRepository<BlockchainInfoDash>, BlockchainInfoDashRepository>();
            services.AddTransient<IPagingRepository<BlockchainInfoBtc>, BlockchainInfoPagingRepository<BlockchainInfoBtc>>();
            services.AddTransient<IPagingRepository<BlockchainInfoEth>, BlockchainInfoPagingRepository<BlockchainInfoEth>>();
            services.AddTransient<IPagingRepository<BlockchainInfoDash>, BlockchainInfoPagingRepository<BlockchainInfoDash>>();
        }
    }
}
