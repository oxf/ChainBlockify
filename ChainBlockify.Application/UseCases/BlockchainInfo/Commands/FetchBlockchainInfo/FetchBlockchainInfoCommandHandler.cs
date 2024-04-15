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
    /// <summary>
    /// Command handler that receives URL, downloads BlockchainInfo and finally saves it into database
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="_logger"></param>
    /// <param name="_mapper"></param>
    /// <param name="_blockchainInfoRepository"></param>
    /// <param name="_dataProvider"></param>
    public class FetchBlockchainInfoCommandHandler<TDto, TEntity>(
        ILogger<FetchBlockchainInfoCommandHandler<TDto, TEntity>> _logger,
        IMapper _mapper,
        IRepository<TEntity> _blockchainInfoRepository,
        IBlockchainInfoProvider<TDto> _dataProvider) : IRequestHandler<FetchBlockchainInfoCommand<TDto>, BaseBlockchainInfo> where TEntity : BaseBlockchainInfo
    {
        public async Task<BaseBlockchainInfo> Handle(FetchBlockchainInfoCommand<TDto> request, CancellationToken cancellationToken)
        {
            try
            {
                // fetch data
                var response = await _dataProvider.GetBlockchainInfo(request.Url, cancellationToken);
                // create to entity
                var entityToSave = _mapper.Map<TEntity>(response);
                entityToSave.CreatedAt = DateTime.UtcNow;
                // save blockchaininfo
                var result = await _blockchainInfoRepository.CreateAsync(entityToSave, cancellationToken);
                _logger.LogInformation($"Saved BlockchainInfo ID {entityToSave.Id}");
                return result;
            } catch (Exception ex)
            {
                _logger.LogError($"Fetching BlockchainInfo failed for Url {request.Url}: {ex.Message}");
                throw;
            }
        }
    }
}
