using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo
{
    public class FetchBlockchainInfoCommand: IRequest<Unit>
    {
        public int BlockchainId { get; set; }
    }
}
