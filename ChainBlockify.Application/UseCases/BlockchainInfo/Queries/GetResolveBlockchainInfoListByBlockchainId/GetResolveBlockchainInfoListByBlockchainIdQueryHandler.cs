using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId
{
    internal class GetResolveBlockchainInfoListByBlockchainIdQueryHandler(
        IMediator _mediator,
        ILogger<GetResolveBlockchainInfoListByBlockchainIdQueryHandler> _logger,
        IRepository<Domain.Entities.Blockchain> _blockchainRepository
        ) : IRequestHandler<GetResolveBlockchainInfoListByBlockchainIdQuery, List<BaseBlockchainInfo>>
    {
        public async Task<List<BaseBlockchainInfo>> Handle(
            GetResolveBlockchainInfoListByBlockchainIdQuery request,
            CancellationToken cancellationToken)
        {
            var blockchain = await _blockchainRepository.GetByIdAsync(request.BlockchainId, cancellationToken);
            if (blockchain == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Blockchain), request.BlockchainId, $"Blockchain ID {request.BlockchainId} was not found");
            }
            var tableName = blockchain.DbTableName;
            var type = Type.GetType(tableName);
            try
            {
                // Build the new type
                ConstructorInfo constructor = BuildConstructor(tableName);
                // Create an instance using the constructor
                object instance = constructor.Invoke(new object[] { request.PageNumber, request.PageSize });
                // Send the command
                object? result = await _mediator.Send(instance);
                if (result is List<BlockchainInfoBtc> btcList)
                {
                    var baseList = btcList.Cast<BaseBlockchainInfo>().ToList();
                    return baseList;
                }
                else if (result is List<BlockchainInfoEth> ethList)
                {
                    var baseList = ethList.Cast<BaseBlockchainInfo>().ToList();
                    return baseList;
                }
                else if (result is List<BlockchainInfoDash> dashList)
                {
                    var baseList = dashList.Cast<BaseBlockchainInfo>().ToList();
                    return baseList;
                }
                throw new Exception("Failed to retreive the correct command return type");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Couldn't build the generic GetBlockchainInfoListByBlockchainId<> using Table: {tableName} from blockchain {blockchain.Name}");
            }
        }

        /// <summary>
        /// Build FetchBlochchainInfoCommand for generic parameter Dto using reflection
        /// </summary>
        /// <param name="DtoName">Dto to use for command in String format</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private ConstructorInfo BuildConstructor(string TableName)
        {
            Type dtoType = Type.GetType($"{TableName}, ChainBlockify.Domain");
            if (dtoType == null)
            {
                throw new ArgumentException($"TableName type not found for Dto: {TableName}");
            }
            Type fetchCommandType = typeof(GetBlockchainInfoListByBlockchainIdQuery<>);
            Type constructedType = fetchCommandType.MakeGenericType(dtoType);
            ConstructorInfo constructor = constructedType.GetConstructor(new[] { typeof(int), typeof(int) });
            return constructor;
        }
    }
}
