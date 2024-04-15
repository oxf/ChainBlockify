using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_logger">Logger</param>
    /// <param name="_mediator">Mediator to send a command</param>
    /// <param name="_blockchainRepository">DB access for Blockchain entity</param>
    public class ResolveBlockchainInfoCommandHandler(ILogger<ResolveBlockchainInfoCommandHandler> _logger,
        IMediator _mediator,
        IRepository<Domain.Entities.Blockchain> _blockchainRepository,
        IValidator<ResolveBlockchainInfoCommand> _validator) : IRequestHandler<ResolveBlockchainInfoCommand, BaseBlockchainInfo>
    {
        /// <summary>
        /// Command turns BlockchainId into FetchBlockchainInfoCommand<> and sends the command via MediatR
        /// </summary>
        /// <param name="request">Request containing BlockchainId</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async Task<BaseBlockchainInfo> Handle(ResolveBlockchainInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var validationResult = _validator.Validate(request);
                if(!validationResult.IsValid)
                {
                    throw new ArgumentException(validationResult.ToString());
                }
                // Get Source
                Domain.Entities.Blockchain blockchain = await GetBlockchain(request.BlockchainId, cancellationToken);
                BlockchainBlockchainSource source = GetSource(blockchain);
                var dtoName = source.DtoName;
                try
                {
                    // Build the new type
                    ConstructorInfo constructor = BuildConstructor(dtoName);
                    // Create an instance using the constructor
                    object instance = constructor.Invoke(new object[] { source.Url });
                    // Send the command
                    var result = await _mediator.Send(instance);
                    return (BaseBlockchainInfo)result;
                }
                catch(Exception ex)
                {
                    throw new ArgumentException($"Couldn't build the generic FetchBlockchainInfoCommand<> using Dto: {dtoName} from blockchain {blockchain.Name}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"ResolveBlockchainInfoCommandHandler failed: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Logic to retrieve Blockchain entity from database by Id
        /// </summary>
        /// <param name="BlockchainId">Blockchain Id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Blockchain entity</returns>
        /// <exception cref="EntityNotFoundException">In case Blockchain was not found</exception>
        private async Task<Domain.Entities.Blockchain> GetBlockchain(int BlockchainId, CancellationToken cancellationToken)
        {
            var blockchain = await _blockchainRepository.GetByIdAsync(BlockchainId, cancellationToken);
            if (blockchain == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Blockchain), BlockchainId, $"Blockchain ID {BlockchainId} was not found");
            }
            return blockchain;
        }

        /// <summary>
        /// Get first available BlockchainBlockchainSource by BlockchainId
        /// TODO in the future if needed: add logic for retreiving the BlockchainBlockchainSource
        /// </summary>
        /// <param name="blockchain">Blockchain entity</param>
        /// <returns></returns>
        /// <exception cref="EntityNotFoundException">In case BlockchainBlockchainSource doesn't exist</exception>
        private BlockchainBlockchainSource GetSource(Domain.Entities.Blockchain blockchain)
        {
            var source = blockchain.Sources.FirstOrDefault();
            if (source == null)
            {
                throw new EntityNotFoundException(typeof(BlockchainBlockchainSource), 0, $"No Source found for Blockchain ID {blockchain.Id}");
            }
            return source;
        }

        /// <summary>
        /// Build FetchBlochchainInfoCommand for generic parameter Dto using reflection
        /// </summary>
        /// <param name="DtoName">Dto to use for command in String format</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private ConstructorInfo BuildConstructor(string DtoName)
        {
            Type dtoType = Type.GetType(DtoName);
            if (dtoType == null)
            {
                throw new ArgumentException($"Dto type not found for Dto: {DtoName}");
            }
            Type fetchCommandType = typeof(FetchBlockchainInfoCommand<>);
            Type constructedType = fetchCommandType.MakeGenericType(dtoType);
            ConstructorInfo constructor = constructedType.GetConstructor(new[] { typeof(string) });
            return constructor;
        }
    }
}
