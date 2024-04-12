using ChainBlockify.Application.Interfaces;
using ChainBlockify.Domain;
using ChainBlockify.Domain.Entities;
using ChainBlockify.Infrastructure;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;
using System.Text.Json;

namespace ChainBlockify.Test.Infrastructure
{
    public class UrlBlockchainDataProviderTest
    {
        [Fact]
        public async Task GetBlockchainInfo_Success()
        {
            // Arrange
            var logger = Substitute.For<ILogger<UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>>>();
            var httpClient = Substitute.For<IHttpClientFactory>();
            var baseUrl = "https://api.blockcypher.com/v1";
            var currency = "btc";
            var cancellationToken = CancellationToken.None;

            var dataProvider = new UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>(logger, httpClient);

            var content = new MemoryStream();
            var blockchainInfo = new BlockchainInfoBtc();

            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(content)
            };

            //httpClient.GetCli(Arg.Any<string>(), Arg.Any<CancellationToken>())
            //    .Returns(Task.FromResult(responseMessage));

            JsonSerializer.DeserializeAsync<BaseBlockchainInfo>(content, Arg.Any<JsonSerializerOptions>(), cancellationToken)
                .Returns(await Task.FromResult(blockchainInfo));

            // Act
            var result = await dataProvider.GetBlockchainInfo(currency, cancellationToken);

            // Assert
            logger.DidNotReceive().LogError(Arg.Any<string>());
            //Assert.Equal(blockchainInfo, result);
        }

        [Fact]
        public async Task GetBlockchainInfo_HandlesHttpRequestException()
        {
            // Arrange
            var logger = Substitute.For<ILogger<UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>>>();
            var httpClient = Substitute.For<IHttpClientFactory>();
            var baseUrl = "https://api.blockcypher.com/v1";
            var currency = "btc";
            var cancellationToken = CancellationToken.None;

            var dataProvider = new UrlBlockchainInfoProvider<BlockchainInfoBtcBlockcypherDto>(logger, httpClient);

            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);

            //httpClient.GetAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
            //    .Returns(Task.FromResult(responseMessage));

            // Act + Assert
            await Assert.ThrowsAsync<HttpRequestException>(() => dataProvider.GetBlockchainInfo(currency, cancellationToken));
            logger.Received().LogError(Arg.Any<string>());
        }
    }
}