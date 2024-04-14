using ChainBlockify.Application.DTOs.Blockcypher;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.FetchBlockchainInfo
{
    public record FetchBlockchainInfoCommand(int BlockchainId) : IRequest<BlockchainInfoBtc>;
}
