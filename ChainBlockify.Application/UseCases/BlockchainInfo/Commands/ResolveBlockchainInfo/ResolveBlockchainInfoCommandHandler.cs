using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo
{
    public class ResolveBlockchainInfoCommandHandler(IMediator _mediator) : IRequestHandler<ResolveBlockchainInfoCommand, BaseBlockchainInfo>
    {
        public Task<BaseBlockchainInfo> Handle(ResolveBlockchainInfoCommand request, CancellationToken cancellationToken)
        {
            return _mediator.Send(new FetchBlockchainInfoCommand<BlockchainInfoEthBlockcypherDto>(2));
        }
    }
}
