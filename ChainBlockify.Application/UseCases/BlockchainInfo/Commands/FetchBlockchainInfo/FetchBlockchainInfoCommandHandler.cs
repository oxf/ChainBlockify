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
        IRepository<TEntity> _blockchainInfoRepository,
        IBlockchainInfoProvider<TDto> _dataProvider) : IRequestHandler<FetchBlockchainInfoCommand<TDto>, BaseBlockchainInfo> where TEntity : BaseBlockchainInfo
    {
        public async Task<BaseBlockchainInfo> Handle(FetchBlockchainInfoCommand<TDto> request, CancellationToken cancellationToken)
        {
            var response = await _dataProvider.GetBlockchainInfo(request.Url, cancellationToken);
            var entityToSave = _mapper.Map<TEntity>(response);
            entityToSave.CreatedAt = DateTime.UtcNow;
            // save blockchaininfo
            var result = await _blockchainInfoRepository.CreateAsync(entityToSave, cancellationToken);
            _logger.LogInformation("Downloaded response" + entityToSave);
            return result;
        }
    }
}
