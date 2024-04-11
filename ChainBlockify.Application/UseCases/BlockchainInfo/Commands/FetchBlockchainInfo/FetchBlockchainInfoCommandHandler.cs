using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo
{
    public class FetchBlockchainInfoCommandHandler(
        ILogger<FetchBlockchainInfoCommandHandler> _logger,
        IBlockchainInfoProvider<BaseBlockchainInfoBlockcypherDto> _dataProvider) : IRequestHandler<FetchBlockchainInfoCommand, BaseBlockchainInfoBlockcypherDto>
    {
        public async Task<BaseBlockchainInfoBlockcypherDto> Handle(FetchBlockchainInfoCommand request, CancellationToken cancellationToken)
        {
            string url = "https://api.blockcypher.com/v1/btc/main";
            var response = await _dataProvider.GetBlockchainInfo(url, cancellationToken);
            _logger.LogInformation("Downloaded response");
            return response;
        }
    }
}
