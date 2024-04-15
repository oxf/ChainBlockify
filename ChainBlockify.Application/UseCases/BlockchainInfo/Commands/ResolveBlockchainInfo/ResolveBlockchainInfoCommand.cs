using ChainBlockify.Application.DTOs.Blockcypher;
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
    /// <summary>
    /// Command body
    /// </summary>
    /// <param name="BlockchainId">BlockchainId</param>
    public record ResolveBlockchainInfoCommand(int BlockchainId) : IRequest<BaseBlockchainInfo>;
}
