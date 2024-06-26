﻿using AutoMapper;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain.Exceptions;
using FluentValidation;
using MediatR;

namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById
{
    public class GetBlockchainByIdQueryHandler(
        IMapper _mapper,
        IRepository<ChainBlockify.Domain.Entities.Blockchain> _repository,
        IValidator<GetBlockchainByIdQuery> _validator) : IRequestHandler<GetBlockchainByIdQuery, GetBlockchainByIdDto?>
    {

        public async Task<GetBlockchainByIdDto?> Handle(GetBlockchainByIdQuery query, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(query);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.ToString());
            }
            var blockchain = await _repository.GetByIdAsync(query.Id, cancellationToken);
            if(blockchain == null)
            {
                throw new EntityNotFoundException(typeof(Domain.Entities.Blockchain), query.Id, $"Blockchain ID {query.Id} was not found");
            }
            var transformedBlockchain = _mapper.Map<Domain.Entities.Blockchain, GetBlockchainByIdDto>(blockchain);
            return transformedBlockchain;
        }

    }
}
