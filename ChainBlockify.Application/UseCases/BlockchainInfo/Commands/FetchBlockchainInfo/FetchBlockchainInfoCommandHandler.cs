using AutoMapper;
using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo
{
    public class FetchBlockchainInfoCommandHandler<TDto, TEntity>(
        ILogger<FetchBlockchainInfoCommandHandler<TDto, TEntity>> _logger,
        IMapper _mapper,
        IRepository<Domain.Entities.Blockchain> _blockchainRepository,
        IRepository<TEntity> _blockchainInfoRepository,
        IBlockchainInfoProvider<TDto> _dataProvider) : IRequestHandler<FetchBlockchainInfoCommand<TDto>, BaseBlockchainInfo> where TEntity : BaseBlockchainInfo
    {
        public async Task<BaseBlockchainInfo> Handle(FetchBlockchainInfoCommand<TDto> request, CancellationToken cancellationToken)
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
            if (source == null) {
                throw new EntityNotFoundException(typeof(BlockchainBlockchainSource), 0, $"No Source found for Blockchain ID {request.BlockchainId}");
            }
            var response = await _dataProvider.GetBlockchainInfo(source.Url, cancellationToken);
            var entityToSave = _mapper.Map<TEntity>(response);
            entityToSave.CreatedAt = DateTime.UtcNow;
            // save blockchaininfo
            var result = await _blockchainInfoRepository.CreateAsync(entityToSave, cancellationToken);
            _logger.LogInformation("Downloaded response" + entityToSave);
            return result;
        }
    }
}
