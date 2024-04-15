using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId
{
    internal class GetBlockchainInfoListByBlockchainIdQueryHandler<TEntity>(
        ILogger<GetBlockchainInfoListByBlockchainIdQueryHandler<TEntity>> _logger,
        IPagingRepository<TEntity> _pagingRepository
        ) : IRequestHandler<GetBlockchainInfoListByBlockchainIdQuery<TEntity>, IEnumerable<TEntity>> where TEntity : BaseTimestampEntity
    {
        public async Task<IEnumerable<TEntity>> Handle(
            GetBlockchainInfoListByBlockchainIdQuery<TEntity> request, 
            CancellationToken cancellationToken)
        {
            var result = _pagingRepository.GetPagingListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return await result;
        }
    }
}
