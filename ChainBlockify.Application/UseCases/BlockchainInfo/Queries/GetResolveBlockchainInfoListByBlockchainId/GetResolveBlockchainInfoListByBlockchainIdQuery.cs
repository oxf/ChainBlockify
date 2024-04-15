using ChainBlockify.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId
{
    public record GetResolveBlockchainInfoListByBlockchainIdQuery(int BlockchainId,
        int PageNumber,
        int PageSize): IRequest<List<BaseBlockchainInfo>>;
}
