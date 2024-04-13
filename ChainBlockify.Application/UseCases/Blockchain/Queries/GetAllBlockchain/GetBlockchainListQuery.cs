using MediatR;

namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain
{
    public record GetBlockchainListQuery : IRequest<IEnumerable<GetBlockchainListDto>>;
}
