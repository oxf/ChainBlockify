using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.BlockchainInfo.Commands.ResolveBlockchainInfo;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Test.Application
{
    public class ResolveBlockchainInfoCommandHandlerTests
    {
        //[Fact]
        //public async Task Handle_ValidRequest_ReturnsCorrectResult()
        //{
        //    // Arrange
        //    var logger = Substitute.For<ILogger<ResolveBlockchainInfoCommandHandler>>();
        //    var mediator = Substitute.For<IMediator>();
        //    var repository = Substitute.For<IRepository<Blockchain>>();

        //    var handler = new ResolveBlockchainInfoCommandHandler(logger, mediator, repository);

        //    var blockchainId = 1;
        //    var blockchain = new Blockchain { Id = blockchainId, Name = "TestBlockchain" };
        //    var source = new BlockchainBlockchainSource { Id = 1, Blockchains = blockchain, DtoName = "ChainBlockify.Application.DTOs.Blockcypher.BlockchainInfoBtcBlockcypherDto", Url = "http://example.com" };

        //    repository.GetByIdAsync(blockchainId, Arg.Any<CancellationToken>()).Returns(Task.FromResult(blockchain));
        //    blockchain.Sources = new List<BlockchainBlockchainSource> { source };

        //    var fetchCommandResult = Substitute.For<BaseBlockchainInfo>();
        //    mediator.Send(Arg.Any<object>()).Returns(Task.FromResult(fetchCommandResult));

        //    var command = new ResolveBlockchainInfoCommand(blockchainId);

        //    // Act
        //    var result = await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsType<BaseBlockchainInfo>(result);
        //    Assert.Equal(fetchCommandResult, result);

        //    await mediator.Received().Send(Arg.Any<object>());
        //}

        [Fact]
        public async Task Handle_BlockchainNotFound_ThrowsEntityNotFoundException()
        {
            // Arrange
            var logger = Substitute.For<ILogger<ResolveBlockchainInfoCommandHandler>>();
            var mediator = Substitute.For<IMediator>();
            var repository = Substitute.For<IRepository<Blockchain>>();

            var handler = new ResolveBlockchainInfoCommandHandler(logger, mediator, repository);

            var blockchainId = 1;

            repository.GetByIdAsync(blockchainId, Arg.Any<CancellationToken>()).Returns(Task.FromResult<Blockchain>(null));

            var command = new ResolveBlockchainInfoCommand(blockchainId);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_NoSourceFound_ThrowsEntityNotFoundException()
        {
            // Arrange
            var logger = Substitute.For<ILogger<ResolveBlockchainInfoCommandHandler>>();
            var mediator = Substitute.For<IMediator>();
            var repository = Substitute.For<IRepository<Blockchain>>();

            var handler = new ResolveBlockchainInfoCommandHandler(logger, mediator, repository);

            var blockchainId = 1;
            var blockchain = new Blockchain { Id = blockchainId, Name = "TestBlockchain" };

            repository.GetByIdAsync(blockchainId, Arg.Any<CancellationToken>()).Returns(Task.FromResult(blockchain));
            blockchain.Sources = new List<BlockchainBlockchainSource>();

            var command = new ResolveBlockchainInfoCommand (blockchainId);

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(() => handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_FetchCommandConstructionFails_ThrowsArgumentException()
        {
            // Arrange
            var logger = Substitute.For<ILogger<ResolveBlockchainInfoCommandHandler>>();
            var mediator = Substitute.For<IMediator>();
            var repository = Substitute.For<IRepository<Blockchain>>();

            var handler = new ResolveBlockchainInfoCommandHandler(logger, mediator, repository);

            var blockchainId = 1;
            var blockchain = new Blockchain { Id = blockchainId, Name = "TestBlockchain" };
            var source = new BlockchainBlockchainSource { Id = 1, Blockchains = blockchain, DtoName = "NonExistingDto", Url = "http://example.com" };

            repository
                .GetByIdAsync(blockchainId, Arg.Any<CancellationToken>())
                .Returns<Task<Blockchain>>(_ => Task.FromResult(blockchain));

            blockchain.Sources = new List<BlockchainBlockchainSource> { source };

            var command = new ResolveBlockchainInfoCommand (blockchainId);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
