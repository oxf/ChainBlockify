using MediatR;

namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById
{
    public record GetBlockchainByIdQuery(int Id) : IRequest<GetBlockchainByIdDto?>;
}
