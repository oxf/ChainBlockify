using ChainBlockify.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChainBlockify.Persistence
{
    internal class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        DbSet<Blockchain> BlockchainDbSet { get; set; }
        DbSet<BlockchainSource> BlockchainSourceDbSet { get; set; }
        DbSet<BlockchainBlockchainSource> BlockchainBlockchainSourceDbSet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}