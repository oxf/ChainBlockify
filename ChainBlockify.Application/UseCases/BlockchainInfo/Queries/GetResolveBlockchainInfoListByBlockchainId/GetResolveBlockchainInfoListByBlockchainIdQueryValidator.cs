using ChainBlockify.Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Queries.GetBlockchainInfoListByBlockchainId
{
    public class GetResolveBlockchainInfoListByBlockchainIdQueryValidator: AbstractValidator<GetResolveBlockchainInfoListByBlockchainIdQuery>
    {
        public GetResolveBlockchainInfoListByBlockchainIdQueryValidator() {
            RuleFor(query => query.BlockchainId).GreaterThan(0);
            RuleFor(query => query.PageNumber).GreaterThan(0);
            RuleFor(query => query.PageSize).GreaterThan(0);
        }
    }
}
