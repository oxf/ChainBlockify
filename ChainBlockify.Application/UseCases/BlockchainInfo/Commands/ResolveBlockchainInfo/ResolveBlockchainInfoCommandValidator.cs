using FluentValidation;
using MediatR;

namespace ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo
{
    public class ResolveBlockchainInfoCommandValidator : AbstractValidator<ResolveBlockchainInfoCommand>
    {
        public ResolveBlockchainInfoCommandValidator()
        {
            RuleFor(query => query.BlockchainId).GreaterThan(0);
        }
    }
}
