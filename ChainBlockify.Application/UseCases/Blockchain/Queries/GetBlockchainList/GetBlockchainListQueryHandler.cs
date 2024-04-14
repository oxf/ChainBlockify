using AutoMapper;
using ChainBlockify.Application.Interfaces;
using MediatR;

namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain
{
    public class GetBlockchainListQueryHandler(
        IMapper _mapper,
        IRepository<ChainBlockify.Domain.Entities.Blockchain> _repository) : IRequestHandler<GetBlockchainListQuery, IEnumerable<GetBlockchainListDto>>
    {

        public async Task<IEnumerable<GetBlockchainListDto>> Handle(GetBlockchainListQuery query, CancellationToken cancellationToken)
        {
            var blockchainList = await _repository.GetAllAsync(cancellationToken);
            var transformedList = blockchainList.AsParallel().Select(x => _mapper.Map<GetBlockchainListDto>(x));
            return transformedList;
        }

    }
}
