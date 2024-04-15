using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Persistence.Repositories
{
    internal class BlockchainInfoPagingRepository<TTable>(AppDbContext _dbContext,
        ILogger<BlockchainInfoPagingRepository<TTable>> _logger) : IPagingRepository<TTable> where TTable : BaseTimestampEntity
    {
        public async Task<IEnumerable<TTable>> GetPagingListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            try
            {
                return await _dbContext.Set<TTable>()
                .OrderByDescending(x => x.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
            } catch (Exception ex)
            {
                throw new Exception($"Getting BlockchainInfo for database failed: {ex.Message}");
            }
        }
    }
}
