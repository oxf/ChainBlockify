using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo
{
    public class ResolveBlockchainInfoCommandHandler(IMediator _mediator,
        IRepository<Domain.Entities.Blockchain> _blockchainRepository) : IRequestHandler<ResolveBlockchainInfoCommand, BaseBlockchainInfo>
    {
        public async Task<BaseBlockchainInfo> Handle(ResolveBlockchainInfoCommand request, CancellationToken cancellationToken)
        {

            // get blockchain by id
            var blockchain = await _blockchainRepository.GetByIdAsync(request.BlockchainId, cancellationToken);
            if (blockchain == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Blockchain), request.BlockchainId, $"Blockchain ID {request.BlockchainId} was not found");
            }
            // BECAUSE OF PROTOTYPE - TAKE ALWAYS FIRST AVAILABLE SOURCE (later BlockchainSourceId can be passed in query);
            // fetch data
            var source = blockchain.Sources.FirstOrDefault();
            if (source == null)
            {
                throw new EntityNotFoundException(typeof(BlockchainBlockchainSource), 0, $"No Source found for Blockchain ID {request.BlockchainId}");
            }
            switch(blockchain.Id)
            {
                case 1:
                    return await _mediator.Send(new FetchBlockchainInfoCommand<BlockchainInfoBtcBlockcypherDto>(source.Url));
                case 2:
                    return await _mediator.Send(new FetchBlockchainInfoCommand<BlockchainInfoEthBlockcypherDto>(source.Url));
                case 3:
                    return await _mediator.Send(new FetchBlockchainInfoCommand<BlockchainInfoDashBlockcypherDto>(source.Url));
                default:
                    throw new ArgumentException();
            }
        }
    }
}
