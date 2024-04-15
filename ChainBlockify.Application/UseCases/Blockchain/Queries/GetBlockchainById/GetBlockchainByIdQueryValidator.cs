using FluentValidation;
using MediatR;

namespace ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById
{
    public class GetBlockchainByIdQueryValidator : AbstractValidator<GetBlockchainByIdQuery>
    {
        public GetBlockchainByIdQueryValidator()
        {
            RuleFor(query => query.Id).GreaterThan(0);
        }
    }
}
