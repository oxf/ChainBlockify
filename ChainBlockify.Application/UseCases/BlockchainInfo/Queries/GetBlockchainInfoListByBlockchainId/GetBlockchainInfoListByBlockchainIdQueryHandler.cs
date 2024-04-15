using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId
{
    internal class GetBlockchainInfoListByBlockchainIdQueryHandler(
        ILogger<GetBlockchainInfoListByBlockchainIdQueryHandler> _logger
        ) : IRequestHandler<GetBlockchainInfoListByBlockchainIdQuery, GetBlockchainInfoListByBlockchainIdDto>
    {
        public Task<GetBlockchainInfoListByBlockchainIdDto> Handle(
            GetBlockchainInfoListByBlockchainIdQuery request, 
            CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
