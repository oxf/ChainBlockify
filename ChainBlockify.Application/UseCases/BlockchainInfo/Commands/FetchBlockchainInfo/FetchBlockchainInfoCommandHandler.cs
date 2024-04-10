using ChainBlockify.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo
{
    public class FetchBlockchainInfoCommandHandler(
        IBlockchainInfoProvider _dataProvider) : IRequestHandler<FetchBlockchainInfoCommand, Unit>
    {
        public async Task<Unit> Handle(FetchBlockchainInfoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
