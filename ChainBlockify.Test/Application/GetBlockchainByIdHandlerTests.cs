using AutoMapper;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetBlockchainById;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Domain.Exceptions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Test.Application
{
    public class GetBlockchainByIdHandlerTests
    {
        /// <summary>
        /// Test for valid query
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ValidId_ReturnsDto()
        {
            // Arrange
            int validId = 1;
            var mockRepository = Substitute.For<IRepository<Blockchain>>();
            var mockMapper = Substitute.For<IMapper>();
            var handler = new GetBlockchainByIdQueryHandler(mockMapper, mockRepository);
            var expectedBlockchain = new Domain.Entities.Blockchain { Id = 1, Name = "TestBlockchainName" };
            var expectedDto = new GetBlockchainByIdDto(1, "TestBlockchainName");

            mockRepository.GetByIdAsync(validId, Arg.Any<CancellationToken>())
                          .Returns(Task.FromResult(expectedBlockchain));
            mockMapper.Map<Domain.Entities.Blockchain, GetBlockchainByIdDto>(expectedBlockchain)
                      .Returns(expectedDto);

            // Act
            var result = await handler.Handle(new GetBlockchainByIdQuery(validId), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto, result);
        }

        /// <summary>
        /// Test for invalid query
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            int invalidId = -1;
            var mockRepository = Substitute.For<IRepository<Blockchain>>();
            var mockMapper = Substitute.For<IMapper>();
            var handler = new GetBlockchainByIdQueryHandler(mockMapper, mockRepository);

            mockRepository.GetByIdAsync(invalidId, Arg.Any<CancellationToken>())
                          .Returns(Task.FromResult<Domain.Entities.Blockchain>(null));

            // Act & Assert
            await Assert.ThrowsAsync<EntityNotFoundException>(async () =>
            {
                await handler.Handle(new GetBlockchainByIdQuery(invalidId), CancellationToken.None);
            });
        }
    }
}
