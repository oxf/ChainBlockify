using ChainBlockify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChainBlockify.Persistence
{
    internal class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        internal DbSet<Blockchain> BlockchainDbSet { get; set; }
        internal DbSet<BlockchainSource> BlockchainSourceDbSet { get; set; }
        internal DbSet<BlockchainBlockchainSource> BlockchainBlockchainSourceDbSet { get; set; }
        internal DbSet<BlockchainInfoBtc> BlockchainInfoBtcDbSet { get; set; }
        internal DbSet<BlockchainInfoEth> BlockchainInfoEthDbSet { get; set; }
        internal DbSet<BlockchainInfoDash> BlockchainInfoDashDbSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}