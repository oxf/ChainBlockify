using AutoMapper;
using ChainBlockify.Application.Interfaces;
using ChainBlockify.Application.UseCases.Blockchain.Queries.GetAllBlockchain;
using ChainBlockify.Domain.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainBlockify.Test.Application
{
    public class GetBlockchainListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsMappedBlockchainList()
        {
            // Arrange
            var mapper = Substitute.For<IMapper>();
            var repository = Substitute.For<IRepository<Blockchain>>();
            var cancellationToken = new CancellationToken();
            var query = new GetBlockchainListQuery();

            var blockchainList = new List<Blockchain> 
            {
                new Blockchain { Id = 1, Name = "Bitcoin" },
                new Blockchain { Id = 2, Name = "Ethereum" }
            };

            repository.GetAllAsync(cancellationToken).Returns(Task.FromResult<IEnumerable<Blockchain>>(blockchainList));

            var handler = new GetBlockchainListQueryHandler(mapper, repository);

            var expectedDtoList = new List<GetBlockchainListDto>
            {
                new GetBlockchainListDto(1, "Bitcoin", null),
                new GetBlockchainListDto (2, "Ethereum", null)
            };

            mapper.Map<GetBlockchainListDto>(Arg.Any<Blockchain>()).Returns(x =>
            {
                var blockchain = x.ArgAt<Blockchain>(0);
                return new GetBlockchainListDto(blockchain.Id, blockchain.Name, null);
            });

            // Act
            var result = await handler.Handle(query, cancellationToken);

            // Assert
            Assert.Equal(expectedDtoList.Count, result.Count());
            foreach (var expectedDto in expectedDtoList)
            {
                Assert.Contains(result, dto => dto.Id == expectedDto.Id && dto.Name == expectedDto.Name);
            }
        }
    }
}
